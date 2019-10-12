using System;
using Tracker;
namespace Sorting
{
    public class SelectionSort<T>: Tracker<T>, ISorter<T>
        where T: IComparable<T>
    {
        public void Sort(T[] items)
        {
            // starts with first index
            // This index indicates where the unsorted part from.
            int sortedRangeEnd = 0;
            while (sortedRangeEnd < items.Length)
            {
                int nextIndex = FindIndexOfSmallestFromIndex(items, sortedRangeEnd);
                // Swap the smallest item to the current sortedRangeEnd index.
                Swap(items, sortedRangeEnd, nextIndex);

                sortedRangeEnd++;
            }
        }

        private int FindIndexOfSmallestFromIndex(T[] items, int sortedRangeEnd)
        {
            // Set the currentSmallest to be the first element of the unsorted part.
            // And also the currentSmallest index is pointing to the first index of unsorted part.
            T currentSmallest = items[sortedRangeEnd];
            int currentSmallestIndex = sortedRangeEnd;

            for (int i = sortedRangeEnd + 1; i < items.Length; i++)
            {
                // replace the currentSmallest element whenever we found a smaller element.
                // And also update the currentSmallestIndex to the smaller element.
                if (Compare(currentSmallest, items[i]) > 0)
                {
                    currentSmallest = items[i];
                    currentSmallestIndex = i;
                }
            }
            return currentSmallestIndex;
        }
    }
}