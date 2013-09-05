using System;
using System.Collections.Generic;
using System.Text;

namespace MergingSortedArrays
{
    struct Element
    {
        public int Key { get; set; }

        public Element(int key) : this()
        {
            this.Key = key;
        }
    }

    class MergingSortedArrays
    {
        static Random rand = new Random();
        private const int NumberOfArrays = 6;
        private const int ArraysLength = 12;

        static IEnumerable<Element[]> InitializeArray(int modul)
        {
            var list = new LinkedList<Element[]>();
            for (int i = 0; i < NumberOfArrays; i++)
            {
                var array = new Element[ArraysLength];
                array[0].Key = rand.Next() % modul;
                for (int j = 1; j < ArraysLength; j++)
                {
                    array[j].Key = array[j - 1].Key + rand.Next() % modul;
                }
                list.AddLast(array);
            }
            return list;
        }

        static void PrintArrays(IEnumerable<Element[]> list)
        {
            var stringBuilder = new StringBuilder();
            foreach (var innerArray in list)
            {
                foreach (var element in innerArray)
                {
                    stringBuilder.Append(element.Key + " ");
                }

                stringBuilder.AppendLine();
            }
            Console.Write(stringBuilder);
        }

        private static void MergeArrays(LinkedList<Element[]> list)
        {
            Element k1, k2;
            var tempList = new LinkedList<Element[]>();
            var tempListMin = new LinkedList<Element[]>();
            //tempList.AddFirst(list.First);
            for (int i = 0; i < NumberOfArrays * ArraysLength; i++)
            {
                tempList.AddFirst(list.First);
                tempListMin.AddFirst(list.First);
                //TODO: Implement logic
            }
        }

        static void Main()
        {
            var list = InitializeArray(500);
            Console.WriteLine("Масивите преди сортирането:");
            PrintArrays(list);
            MergeArrays(list);
            PrintArrays(list);
        }
    }
}
