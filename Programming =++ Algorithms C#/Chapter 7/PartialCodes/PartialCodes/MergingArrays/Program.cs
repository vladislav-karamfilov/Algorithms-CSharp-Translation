using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergingArrays
{
    class Program
    {
        static void MergeWithThreeIndexes(List<int> a, List<int> b)
        {
            int n = a.Count;
            int m = b.Count;
            List<int> c = new List<int>();
            int i = 0, j = 0, k = 0;
            while (i < n && j < m)
            {
                int smallestElement = (a[i] < b[j]) ? a[i++] : b[j++];
                c.Add(smallestElement);
            }
            if (i == n)
                while (j < m)
                    c.Add(b[j++]);
            else
                while (i < n)
                    c.Add(a[i++]);
        }

        static void MergeWithArrayCopy(List<int> a, List<int> b)
        {
            int i = 0, j = 0, k = 0;
            int n = a.Count;
            int m = b.Count;
            List<int> c = new List<int>();
            while (i < n && j < m)
            {
                int smallestElement = (a[i] < b[j]) ? a[i++] : b[j++];
                c.Add(smallestElement);
            }
            if (i == n)
            {

            }
        }

        static void Main()
        {
        }
    }

    internal struct Element
    {
        public int Key { get; set; }
    }
}
