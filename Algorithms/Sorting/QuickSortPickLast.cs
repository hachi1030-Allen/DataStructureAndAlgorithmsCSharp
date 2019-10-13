using System;
using Tracker;
namespace Sorting
{
    public class QuickSortPickLast<T>: Tracker<T>, ISorter<T>
        where T: IComparable<T>
    {
        public void Sort(T[] items)
        {
            QuickSort(items, 0, items.Length - 1);
        }
        /// <summary>
        /// This function takes last element as pivot,
        /// places the pivot element as its correct
        /// position in sorted array, and places all
        /// smaller (smaller than pivot) to left of pivot
        /// and all greater elements to the right of pivot
        /// </summary>
        /// <param name="items">The items / sub items to apply the partition</param>
        /// <param name="low">The low index</param>
        /// <param name="high">The high index</param>
        /// <returns>The index of the pivot after applying partition</returns>
        private int partition(T[] items, int low, int high)
        {
            T pivot = items[high];

            // index of smaller element
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                // If current element is smaller than pivot
                if (Compare(items[j], pivot) < 0)
                {
                    i++;

                    // swap items[i] and items[j]
                    T temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;
                }
            }

            // swap items[i+1] and item[high] which is pivot
            T temp1 = items[i+1];
            items[i+1] = items[high];
            items[high] = temp1;

            return i + 1;
        }

        private void QuickSort(T[] items, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, items[pi] is
                   now at right place */
                int pi = partition(items, low, high);

                // Recursively sort elements before
                // partition and after partition
                QuickSort(items, low, pi - 1);
                QuickSort(items, pi + 1, high);
            }
        }
    }
}