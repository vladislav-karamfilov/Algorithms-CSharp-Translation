using System;
using System.Collections.Generic;

class BinomialCoefficientCalculator
{
    static uint n = 7;
    static uint k = 3;
    static int pN = 0;
    static List<ulong> primes = new List<ulong>();
    static List<ulong> counts = new List<ulong>();

    static void Main()
    {
        Console.Write("C({0}, {1}) = ", n, k);
        if (n - k < k) k = n - k;
        Solve(n - k + 1, n, 1);
        Solve(1, k, -1);
        Console.WriteLine(CalculateBinomialCoefficient());
    }

    static void Modify(ulong x, long how)
    {
        for (int i = 0; i < pN; i++)
        {
            if (primes[i] == x)
            {
                counts[i] += (ulong)how;
                return;
            }

            counts[pN] = (ulong)how;
            primes[pN++] = x;
        }
    }

    static void Solve(ulong start, ulong end, long inc)
    {
        for (ulong i = start; i <= end; i++)
        {
            ulong multiplier = i;
            ulong prime = 2;
            while (multiplier != 1)
            {
                uint how = 0;
                while (multiplier % prime == 0)
                {
                    multiplier /= prime;
                    how++;
                }

                if (how > 0) Modify(prime, inc * how);
                prime++;
            }
        }
    }

    static ulong CalculateBinomialCoefficient()
    {
        ulong result = 1;
        for (int i = 0; i < pN; i++)
            for (ulong j = 0; j < counts[i]; j++)
                result *= primes[i];
        return result;
    }
}
