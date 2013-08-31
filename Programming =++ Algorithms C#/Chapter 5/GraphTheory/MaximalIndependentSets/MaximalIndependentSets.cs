using System;
using System.Collections.Generic;

class MaximalIndependentSets
{
    const int VerticesCount = 8;
    static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
    {
        { 0, 1, 0, 0, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 0, 1, 0, 0 },
        { 0, 1, 0, 1, 1, 0, 0, 0 },
        { 0, 0, 1, 0, 1, 0, 1, 0 },
        { 0, 0, 1, 1, 0, 1, 0, 0 },
        { 1, 1, 0, 0, 1, 0, 1, 1 },
        { 0, 0, 0, 1, 0, 1, 0, 0 },
        { 1, 0, 0, 0, 0, 1, 0, 0 }
    };
    

    static void Main()
    {
        Console.WriteLine("Всички максимални независими множества в графа са:");
        FindMaxIndependentSets(0);
    }

    static void FindMaxIndependentSets(int last)
    {

    }



    static void PrintSet()
    {
        
    }
}
