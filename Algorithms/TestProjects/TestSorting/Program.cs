using System;
using Sorting;

namespace TestSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            int[] arr = new int[] {3,7,8,5,2,1,6,4};
            // MergeSort<int> sort = new MergeSort<int>();
            QuickSortPickLast<int> sort = new QuickSortPickLast<int>();
            sort.Sort(arr);

            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
