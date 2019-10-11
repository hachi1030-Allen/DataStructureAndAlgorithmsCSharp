using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue_LinkedList
{
    public class Queue<T> : IEnumerable<T>
    {
        LinkedList<T> _items = new LinkedList<T>();
        /// <summary>
        /// Adds an item to the back of the queue
        /// </summary>
        /// <param name="item">Item been added</param>
        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }
        /// <summary>
        /// Removes and returns the front item from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Dequeue()
        {
            // Handle if the queue is empty.
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            // store the front item's value in a temporary variable
            T value = _items.First.Value;
            // remove the front item.
            _items.RemoveFirst();
            // return the front item value.
            return value;
        }
        /// <summary>
        /// Returns the front item from the queue without removing it from the queue
        /// </summary>
        /// <returns>The front item in the queue</returns>
        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _items.First.Value;
        }
        /// <summary>
        /// The number of items in the queue
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }
        /// <summary>
        /// Remove all items from the queue
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }
        /// <summary>
        /// Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        /// <summary>
        /// Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
