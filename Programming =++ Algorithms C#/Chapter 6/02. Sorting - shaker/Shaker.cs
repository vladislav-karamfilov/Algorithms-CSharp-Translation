using System;

class Shaker
{
    const int MAX = 100;
    const int TEST_LOOP_CNT = 100;

    struct CElem
    {
        public int key;
        /* .............
        Някакви данни
        ............. */
    };

    static void swap(ref CElem x1, ref CElem x2)
    {
        CElem tmp = x1;
        x1 = x2;
        x2 = tmp;
    }

    static void init(CElem[] m, uint n) /* Запълва масива със случайни цели числа */
    {
        uint i;
        Random rand = new Random();
        for (i = 0; i < n; i++)
            m[i].key = (int)(rand.Next() % n);
    }

    static void shakerSort(CElem[] m, uint n)
    {
        uint k = n, r = n - 1;
        uint l = 1, j;
        do
        {
            for (j = r; j >= l; j--)
                if (m[j - 1].key > m[j].key)
                {
                    swap(ref m[j - 1], ref m[j]);
                    k = j;
                }

            l = k + 1;
            for (j = l; j <= r; j++)
                if (m[j - 1].key > m[j].key)
                {
                    swap(ref m[j - 1], ref m[j]);
                    k = j;
                }

            r = k - 1;
        }
        while (l <= r);
    }

    static void print(CElem[] m, uint n) /* Извежда ключовете на масива на екрана */
    {
        uint i;
        for (i = 0; i < n; i++)
            Console.Write("{0,4}", m[i].key);
        Console.WriteLine();
    }

    static void check(CElem[] m, CElem[] saveM, uint n)
    {
        uint i, j;
        bool[] found = new bool[n + 1]; /* третира се като масив от булев тип */

        /* 1. Проверка за наредба във възходящ ред */
        for (i = 0; i < n - 1; i++)
            if (m[i].key <= m[i + 1].key == false)
                Environment.Exit(0);

        /* 2. Проверка за пермутация на изходните елементи */
        
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
                if (found[j] == false && m[i].key == saveM[j].key)
                {
                    found[j] = true;
                    break;
                }
            if (j < n == false) /* Пропада, ако не е намерен съответен */
                Environment.Exit(0);
        }
    }

    static void Main(string[] args)
    {
        CElem[] m = new CElem[MAX], 
        saveM = new CElem[MAX];
        uint loopInd;
        Console.WriteLine("start -- ");
        for (loopInd = 1; loopInd <= TEST_LOOP_CNT; loopInd++)
        {
            init(m, MAX);
            m.CopyTo(saveM, 0); /* Запазва се копие на масива */            
            Console.WriteLine("Масивът преди сортирането:");
            print(m, MAX);
            shakerSort(m, MAX);
            Console.WriteLine("Масивът след сортирането:");
            print(m, MAX);
            check(m, saveM, MAX);
        }
    }
}