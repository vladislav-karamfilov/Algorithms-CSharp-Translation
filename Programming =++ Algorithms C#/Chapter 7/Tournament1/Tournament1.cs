using System;

namespace Tournament1
{
    class TournamentPowerOf2
    {
        static void CopyMatrix(int[,] matrix, int stX, int stY, int cnt, int addValue)
        {
            for (int i = 0; i < cnt; i++)
            {
                for (int j = 0; j < cnt; j++)
                {
                    matrix[i + stX, j + stY] = matrix[i + 1, j + 1] + addValue;
                }
            }
        }

        static void FindSolution(int[,] matrix, int n) /* Построява таблицата */
        {
            matrix[1, 1] = 0;
            for (int i = 1; i <= n; i <<= 1)
            {
                CopyMatrix(matrix, i + 1, 1, i, i);
                CopyMatrix(matrix, i + 1, i + 1, i, 0);
                CopyMatrix(matrix, 1, i + 1, i, i);
            }
        }

        static void PrintMatrix(int[,] matrix)
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
            int numberOfTeams = 8;
            int[,] matrix = new int[numberOfTeams, numberOfTeams];
            FindSolution(matrix, numberOfTeams);
            PrintMatrix(matrix);
        }
    }
}
