using System;

class catalan
{
    struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    const int Max = 80;
    const int Infinity = int.MaxValue;
    const int N = 5;

    static double[,] distances = new double[Max, Max];
    static double[,] values = new double[Max, Max];
    static Coordinates[] coords = new Coordinates[] 
        { 
            new Coordinates() { X = 1, Y = 1 }, 
            new Coordinates() { X = 5, Y = -2 }, 
            new Coordinates() { X = 10, Y = 1 }, 
            new Coordinates() { X = 7, Y = 7 }, 
            new Coordinates() { X = 1, Y = 7 } 
        
        };

    static void CalculateDistances()
    {
        for (int i = 0; i < N - 1; i++)
            for (int j = i + 1; j < N; j++)
                distances[i, j] = Math.Sqrt((coords[i].X - coords[j].X) *
                    (coords[i].X - coords[j].X) +
                    (coords[i].Y - coords[j].Y) *
                    (coords[i].Y - coords[j].Y));
    }

    static void Solve()
    {
        for (int j = 1; j < N; j++)
            for (int i = 1; i < N - j; i++)
            {
                values[i, i + j] = Infinity;
                for (int k = i; k < i + j; k++)
                {
                    double t = values[i, k] + values[k + 1, i + j] + distances[i - 1, k] 
                        + distances[k, i + j] + distances[i - 1, i + j];

                    if (t < values[i, i + j])
                    {
                        values[i, i + j] = t;
                        values[i + j, i] = k;
                    }
                }
            }
    }

    static void PrintResult()
    {
        double p = distances[0, N - 1]; /* Пресмятане на периметъра */
        for (int i = 0; i < N; i++)
            p += distances[i, i + 1];
        Console.WriteLine("Дължината на мин. разрез е {0:F2}", (values[1, N - 1] - p) / 2);
    }

    /* Извеждане на минималния разрез на екрана */
    static void WriteCut(int left, int right)
    {
        if (left != right)
        {
            WriteCut(left, (int)values[right, left]);
            WriteCut((int)values[right, left] + 1, right);
            if (left != 1 || right != N - 1)
                Console.WriteLine("({0}, {1}) ", left, right + 1);
        }
    }

    static void Main()
    {
        CalculateDistances();
        Solve();
        PrintResult();
        Console.WriteLine("Диагонали от минималния разрез: ");
        WriteCut(1, N - 1);
    }
}
