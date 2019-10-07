using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue.Array
{
    public class Queue<T> : IEnumerable<T>
    {
        T[] _items = new T[0];
        
        // The number of items in the queue
        int _size = 0;

        // The index of the first (oldest) item in the queue, initialize with 0 becuase it will be the first.
        int _head = 0;
        // The index of the last (newest) item in the queue. Initialize with -1 because initially there is no last item.
        int _tail = -1;
        /// <summary>
        /// Add an item to the back of the queue
        /// </summary>
        /// <param name="item">The item to place in the queue</param>
        public void Enqueue(T item)
        {
            // If array needs to grow
            if (_items.Length == _size)
            {
                int newLength = (_size == 0)? 4: _size * 2;
                T[] newArray = new T[newLength];

                if (_size > 0)
                {
                    // copy contents...
                    // if the array has no wrapping, just copy the valid range
                    // else copy from head to end of the array and then 0 to tail
                    // if tail is less than head we've wrapped
                    int targetIndex = 0;

                    if (_tail < _head)
                    {
                        // copy the _items from _items[head] to items[end] -> newArray[0] to newArray[N]
                        for (int index = _head; index < _items.Length; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }

                        // copy _items[0] to _items[tail] -> newArray[N+1]
                        for (int index = 0; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        // just copy items[0] to items[end] -> newArray[N+1]
                        for (int index= 0; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }
                    _head = 0;
                    _tail = targetIndex - 1; // compensate the extra bunp
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }
                _items = newArray;
            }

            // now we have a proper sized array and can focus on wrapping issues.

            // if _tail is at the end of the array we need to wrap around
            // When doing enqueue, only tail is handled, head will not be changed. Head will be changed when dequeue is called.
            if (_tail == _items.Length - 1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            _items[_tail] = item;
            _size++;
        }
        /// <summary>
        /// Removes and returns the front item from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The Queue is empty.");
            }
            T value = _items[_head];
            if (_head == _items.Length - 1)
            {
                // if the head is at the last index in the array - wrap around.
                _head = 0;
            }
            else
            {
                // move to the next value
                _head++;
            }
            _size--;

            return value;
        }
        /// <summary>
        /// Return the front item from the queue without removing the item from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The Queue is empty.");
            }
            return _items[_head];
        }
        /// <summary>
        /// The number of items in the queue
        /// </summary>
        public int Count
        {
            get { return _size; }
        }
        /// <summary>
        /// Removes all items from the queue
        /// </summary>
        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            // The same logic as copying the array to new array since we need to enumerate them in queue order.
            if (_size > 0)
            {
                // if the queue wraps then handle that case.
                if (_tail < _head)
                {
                    // head -> end
                    for (int index = _head; index < _items.Length; index++)
                    {
                        yield return _items[index];
                    }
                    // 0 -> tail
                    for (int index = 0; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
                else
                {
                    for (int index = 0; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
