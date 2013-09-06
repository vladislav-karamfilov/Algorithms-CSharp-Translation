using System;

class knapsack5
{
    const int MaxN = 30;    /* Максимален брой предмети */
    const int MaxCapacity = 1000;  /* Максимална вместимост на раницата */
    const int TotalCapacity = 70;   /* Обща вместимост на раницата */
    const int N = 8;    /* Брой предмети */

    static int[] F = new int[MaxCapacity];     /* Целева функция */
    static int[] best = new int[MaxCapacity];  /* Последен добавен предмет при достигане на максимума */

    static int[] m = new int[] { 0, 30, 15, 50, 10, 20, 40, 5, 65 }; /* Тегло на предметите */
    static int[] c = new int[] { 0, 5, 3, 9, 1, 2, 7, 1, 12 };       /* Стойност на предметите */

    static bool IsUsed(int i, int j)
    {
        /* Проверява дали j участва в оптималното множество, определено от F[i] */
        while (i != 0 && best[i] != 0)
            if (best[i] == j)
                return true;
            else
                i -= m[best[i]];
        return false;
    }

    static void Calculate()
    {
        for (int i = 1; i <= TotalCapacity; i++)
            for (int j = 1; j <= N; j++)
                if (i >= m[j])
                    if (F[i] < F[i - m[j]] + c[j])
                        if (!IsUsed(i - m[j], j))
                        {
                            F[i] = F[i - m[j]] + c[j];
                            best[i] = j;
                        }
    }

    static void PrintSet() /* Извежда едно възможно множество от предмети, за което */
    {               /* се постига максимална стойност на целевата функция */
        int value = TotalCapacity;
        while (value != 0)
        {
            Console.Write("{0} ", best[value]);
            value -= m[best[value]];
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Брой предмети: {0}", N);
        Console.WriteLine("Максимална допустима обща маса: {0}", TotalCapacity);
        Calculate();
        Console.WriteLine("Максимална постигната ценност: {0}", F[TotalCapacity]);
        Console.Write("Вземете следните предмети: ");
        PrintSet();
    }
}
