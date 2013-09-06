using System;

class breaknum
{
    const int Max = 100;
    const int N = 10;

    static int[,] values = new int[Max, Max]; /* Целева функция */

    /* Намира броя на представянията на n като сума от естествени числа */
    static int GetNum(int n)
    {
        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= n; j++)
                if (1 == j)
                    values[i, j] = 1;
                else if (1 == i)
                    values[i, j] = 1;
                else if (i < j)
                    values[i, j] = values[i, i];
                else if (i == j)
                    values[i, j] = 1 + values[i, i - 1];
                else
                    values[i, j] = values[i, j - 1] + values[i - j, j];
        return values[n, n];
    }

    static void Main()
    {
        Console.WriteLine("Броят на представянията на {0} като сума от естествени числа е: {1}",
            N, GetNum(N));
    }
}
