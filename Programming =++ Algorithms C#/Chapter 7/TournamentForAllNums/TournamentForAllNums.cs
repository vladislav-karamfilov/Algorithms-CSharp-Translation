using System;

namespace TournamentForAllNums
{
    class TournamentForAllNums
    {
        static void CopyMatrix(int[,] matrix, int stX, int stY, int cnt, int addValue)
        {
            for (int i = 0; i < cnt; i++)
                for (int j = 0; j < cnt; j++)
                    matrix[i + stX, j + stY] = matrix[i + 1, j + 1] + addValue;
        }

        static void FindSolution(int[,] matrix, int n) /* Построява таблицата */
        {
            if (n % 2 == 0)
                n--;
            for (int i = 0; i < n * (n + 1); i++)
                matrix[i % (n + 1), i / (n + 1)] = i % n + 1;
            if (n % 2 == 1)
                n++;
            for (int i = 0; i < n; i++)
            {
                if (n % 2 == 0)
                    matrix[i, n - 1] = matrix[n - 1, i] = matrix[i, i];
                matrix[i, i] = 0;
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            int length = matrix.GetLength(0);
            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                    Console.Write("{0} ", matrix[row, col]);
                Console.WriteLine();
            }
        }

        static void Main()
        {
            int numberOfTeams = 3;
            int[,] matrix = new int[numberOfTeams, numberOfTeams];
            FindSolution(matrix, numberOfTeams);
            PrintMatrix(matrix);
        }
    }
}
