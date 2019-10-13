using System;
using Sorting;

namespace TestSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            int[] arr = new int[] {3,8,2,1,5,4,6,7};
            MergeSort<int> sort = new MergeSort<int>();
            sort.Sort(arr);

            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
