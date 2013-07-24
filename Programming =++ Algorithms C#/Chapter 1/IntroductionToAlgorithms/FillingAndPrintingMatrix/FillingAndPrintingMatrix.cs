using System;

class FillingAndPrintingMatrix
{
    static int[,] A = new int[5, 4];
    static int[,] B = new int[5, 4];

    static void Main()
    {
        FillMatrixByRows();
        FillMatrixByColumns();
        PrintMatrix(A);
        PrintMatrix(B);
    }

    static void FillMatrixByRows()
    {
        for (int row = 0; row < A.GetLength(0); row++)
            for (int col = 0; col < A.GetLength(1); col++)
            {
                Console.Write("Въведи число на ред {0} колона {1}: ", row, col);
                A[row, col] = int.Parse(Console.ReadLine());
            }
    }

    static void FillMatrixByColumns()
    {
        for (int col = 0; col < A.GetLength(1); col++)
            for (int row = 0; row < A.GetLength(0); row++)
            {
                Console.Write("Въведи число на ред {0} колона {1}: ", row, col);
                A[row, col] = int.Parse(Console.ReadLine());
            }
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
                Console.Write("{0, 3} ", matrix[row, col]);
            Console.WriteLine();
        }
    }
}
