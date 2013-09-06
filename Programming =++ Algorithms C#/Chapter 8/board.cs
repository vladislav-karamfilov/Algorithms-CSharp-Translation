using System;

class board
{
    const int Max = 100;
    const int N = 9; /* Брой накрайници */

    static int[] values = new int[Max]; /* Целева функция */
    static int[] nextConductor = new int[Max]; 
    static int[] permutation = new int[] { 0, 9, 1, 3, 6, 2, 7, 5, 4, 8 }; /* Изх. пермутация */

    static void Solve()
    {
        /* Инициализиране */
        for (int i = 1; i <= N; i++)
        {
            values[i] = 1;
        }

        /* Основен цикъл */
        for (int k = N; k >= 1; k--)
            for (int i = k + 1; i <= N; i++)
                if (permutation[k] < permutation[i])
                    if (1 + values[i] > values[k])
                    {
                        values[k] = 1 + values[i];
                        nextConductor[k] = i;
                    }
    }

    static void Print()
    {
        int i, max, index = 1;
        for (max = values[index], i = 2; i <= N; i++)
            if (values[i] > max)
            {
                max = values[i];
                index = i;
            }
        Console.WriteLine("Максимален брой кабели: {0}", max);
        do
        {
            Console.Write("{0} ", index);
            index = nextConductor[index];
        } while (index != 0);
        Console.WriteLine();
    }

    static void Main()
    {
        Solve();
        Print();
    }
}
