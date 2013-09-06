using System;

class hedonia
{
    const int Max = 100;
    const int NotCalculated = 2;

    static int[,] values = new int[Max, Max]; /* Целева функция */
    static readonly string checkString = "NNNNNNNNECINNxqpCDNNNNNwNNNtNNNNs"; /* Изречение за проверка */
    static int n; /* Дължина на изречението */

    static void Init()
    {
        n = checkString.Length;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                values[i, j] = NotCalculated;
    }

    static int Check(int start, int end)
    {
        int k;
        if (values[start, end] != NotCalculated)
            return values[start, end];
        else
        {
            /* Вместо следващите 2 реда */
            if (start == end)
                values[start, end] = (checkString[start] >= 'p' && checkString[start] <= 'z') ? 1 : 0;
            else if ('N' == checkString[start])
                values[start, end] = Check(start + 1, end);
            else if ('C' == checkString[start] || 'D' == checkString[start] 
                || 'E' == checkString[start] || 'I' == checkString[start])
            {
                k = start + 1;
                while (k < end && !(Check(start + 1, k) != 0 && Check(k + 1, end) != 0))
                    k++;
                values[start, end] = (k != end) ? 1 : 0;
            }
            else
                values[start, end] = 0;

            return values[start, end];
        }
    }

    static void Main()
    {
        Init();
        Console.WriteLine("Изречението е {0}", Check(0, n - 1) != 0 ? "правилно!" : "НЕПРАВИЛНО!!!");
    }
}
