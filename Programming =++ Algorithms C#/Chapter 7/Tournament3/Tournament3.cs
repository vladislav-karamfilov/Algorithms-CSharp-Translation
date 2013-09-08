using System;

namespace Tournament3
{
    class Tournament3
    {
        static void CopyMatrix(int[,] matrix, int stX, int stY, int cnt, int addValue)
        {
            for (int i = 0; i < cnt; i++)
                for (int j = 0; j < cnt; j++)
                    matrix[i + stX, j + stY] = matrix[i + 1, j + 1] + addValue;
        }

        static void FindSolution(int[,] matrix, int n) /* Построява таблицата */
        {
            if (n % 2 == 0) /* Ако n е четно, задачата се свежда към n-1 */
                n--;

            /* Попълване на таблицата за n - тук е гарантирано нечетно. */
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i + j < n)
                        matrix[i, j] = i + j + 1;
                    else
                        matrix[i, j] = i + j + 1 - n;

            /* Възстановяване на стойността на n */
            if (n % 2 == 1) n++;
            for (int i = 0; i < n; i++)
            {
                if (n % 2 == 0) /* Запълване на последния стълб и ред при четно n */
                    matrix[i, n - 1] = matrix[n - 1, i] = matrix[i, i];
                matrix[i, i] = 0; /* Запълване с 0 на главния диагонал */
            }

        }

        static void PrintMatrix(int[,] matrix) /* Извежда резултата */
        {
            int length = matrix.GetLength(0);
            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            int numberOfTeams = 5;
            int[,] matrix = new int[numberOfTeams, numberOfTeams];
            FindSolution(matrix, numberOfTeams);
            PrintMatrix(matrix);
        }
    }
}
