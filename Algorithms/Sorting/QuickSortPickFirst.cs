using System;
using Tracker;
namespace Sorting
{
    public class QuickSortPickFirst<T> : Tracker<T>, ISorter<T>
        where T: IComparable<T>
    {
        public void Sort(T[] items)
        {
            QuickSort(items, 0, items.Length - 1);
        }

        private void QuickSort(T[] items, int low, int high)
        {
            if (low < high)
            {
                int splitPoint = partition(items, low, high);

                QuickSort(items, low, splitPoint - 1);
                QuickSort(items, splitPoint + 1, high);
            }
        }

        private int partition(T[] items, int low, int high)
        {
            // First, set the left and right pointers
            int left = low + 1;
            int right = high;
            T pivotValue = items[low];

            while (true)
            {
                // Since left go first, so even the extreme sitution,
                // left is going straightforward to right.
                while (left <= right)
                {
                    // Left keep moving if the items[left] is smaller than pivot
                    if (items[left].CompareTo(pivotValue) < 0)
                    {
                        left++;
                    }
                    else {
                        break;
                    }
                }
                while (right > left)
                {
                    // right keeps moving left if the items[right] is larger than pivot
                    if (items[right].CompareTo(pivotValue) > 0)
                    {
                        right--;
                    }
                    else
                    {
                        break;
                    }
                }
                // This is where to break the infinite loop
                // Which is to stop moving left and right.
                if (left >= right)
                {
                    break;
                }

                // Swap left and right items
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;

                // Advance each one step
                left++;
                right--;
            }

            // swap pivot with left - 1 position
            items[low] = items[left - 1];
            items[left - 1] = pivotValue;

            return (left - 1);
        }
    }
}