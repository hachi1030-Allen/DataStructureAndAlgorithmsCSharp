using System;
using System.Collections.Generic;
using System.Collections;

namespace Stack_LinkedList
{
    public class Stack<T> : IEnumerable<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        private bool IsEmpty()
        {
            return _list.Count == 0;
        }

        /// <summary>
        /// Adds the specified item to the stack
        /// </summary>
        /// <param name="item">The item to be added</param>
        public void Push(T item)
        {
            _list.AddFirst(item);
        }
        /// <summary>
        /// Removes and returns the top item from the stack.
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T value = _list.First.Value;
            _list.RemoveFirst();

            return value;
        }
        /// <summary>
        /// Return the top item from the stack without removing it from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _list.First.Value;
        }
        /// <summary>
        /// The current number of items in the stack
        /// </summary>
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }
        /// <summary>
        /// Remove all items from the stack
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }
        /// <summary>
        /// Enumerates each item in the stack in LIFO order.false The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        /// <summary>
        /// Enumerates each item in the stack in LIFO order.false The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
