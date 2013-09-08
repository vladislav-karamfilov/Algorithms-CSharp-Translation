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

    class CList
    {
        public int Point { get; set; }

        public Element[] Data { get; set; }

        public CList Next { get; set; }

        public int Length { get; set; }
    }

    class MergingSortedArrays
    {
        static Random rand = new Random();
        private const int NumberOfArrays = 6;
        private const int ArraysLength = 12;

        static CList InitializeArray(int modul)
        {
            var head = new CList();
            for (int i = 0; i < NumberOfArrays; i++)
            {
                var currentList = new CList();
                currentList.Length = NumberOfArrays;
                currentList.Point = 0;
                currentList.Data = new Element[ArraysLength];
                currentList.Data[0].Key = rand.Next() % modul;
                for (int j = 1; j < ArraysLength; j++)
                    currentList.Data[j].Key = currentList.Data[j - 1].Key + rand.Next() % modul;
                currentList.Next = head;
                head = currentList;
            }

            return head;
        }

        static void PrintArrays(CList list)
        {
            do
            {
                foreach (var element in list.Data)
                    Console.Write("{0} ", element.Key);
                Console.WriteLine();
                list = list.Next;
            } while (list.Next != null);
        }

        private static void MergeArrays(CList head)
        {
            var current = new CList();
            current.Next = head;
            head = current;
            for (int i = 0; i < NumberOfArrays * ArraysLength; i++)
            {
                current = head;
                var minElement = head;
                while (current.Next.Data != null)
                {
                    var k1 = current.Next.Data[current.Next.Point];
                    var k2 = minElement.Next.Data[minElement.Next.Point];
                    if (k1.Key < k2.Key)
                        minElement = current;
                    current = current.Next;
                }
                Console.WriteLine(minElement.Next.Data[minElement.Next.Point].Key);
                if (minElement.Next.Length - 1 == minElement.Next.Point)
                {
                    var q = minElement.Next;
                    minElement = minElement.Next.Next;
                }
                else
                {
                    minElement.Next.Point++;
                }
            }
        }

        static void Main()
        {
            var head = InitializeArray(500);
            Console.WriteLine("Масивите преди сортирането:");
            PrintArrays(head);
            MergeArrays(head);
        }
    }
}
