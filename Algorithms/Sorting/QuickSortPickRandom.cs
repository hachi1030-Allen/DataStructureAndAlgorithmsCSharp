using System;
using Tracker;
namespace Sorting
{
    public class QuickSortPickRandom<T> : Tracker<T>, ISorter<T>
        where T: IComparable<T>
    {
        public void Sort(T[] items)
        {
            QuickSort(items, 0, items.Length - 1);
        }

        private void QuickSort(T[] items, int left, int right)
        {
            // When left >= right, means the sort is done
            if (left < right)
            {
                int pivotIndex = _pivotRng.Next(left, right);
                int newPivot = partition(items, left, right, pivotIndex);
                             
                QuickSort(items, left, newPivot - 1);
                QuickSort(items, newPivot + 1, right);
            }
        }

        private int partition(T[] items, int left, int right, int pivotIndex)
        {
            T pivotValue = items[pivotIndex];
            // This is actually to put the pivot to the last element?
            Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (Compare(items[i], pivotValue) < 0)
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }
            
            Swap(items, storeIndex, right);
            return storeIndex;
        }

        Random _pivotRng = new Random();
    }
}