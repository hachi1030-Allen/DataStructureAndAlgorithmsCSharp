using System;
using Tracker;

namespace Sorting
{
    public class MergeSort<T> : Tracker<T>, ISorter<T>
        where T: IComparable<T>
    {
        public void Sort(T[] items)
        {
            if (items.Length <= 1)
            {
                return;
            }
            // In case it's odd size array
            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;

            T[] left = new T[leftSize];
            T[] right = new T[rightSize];
            // Copy leftSize items from items array from 0 index to the left array starting from 0 index.
            Array.Copy(items, 0, left, 0, leftSize);
            // Copy rightSize items from items array from leftSize index to the right array starting from 0 index.
            Array.Copy(items, leftSize, right, 0, rightSize);
            // Recursively call Sort on the left and right.
            Sort(left);
            Sort(right);

            // Restructure and merge the result back to items.
            Merge(items, left, right);
        }

        private void Merge(T[] items, T[] left, T[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;

            int remaining = left.Length + right.Length;

            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    Assign(items, targetIndex, right[rightIndex++]);
                }
                else if (rightIndex >= right.Length)
                {
                    Assign(items, targetIndex, left[leftIndex++]);
                }
                else if (Compare(left[leftIndex], right[rightIndex]) < 0)
                {
                    Assign(items, targetIndex, left[leftIndex++]);
                }
                else 
                {
                    Assign(items, targetIndex, right[rightIndex++]);
                }
                targetIndex++;
                remaining--;
            }
        }
    }
}