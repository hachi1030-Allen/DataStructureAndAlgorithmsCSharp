﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack_Array
{
    public class Stack<T> : IEnumerable<T>
    {
        // The array of items contained in the stack. Initialized to 0 length,
        // will grow as needed during Push.
        T[] _items = new T[0];
        // The current number of items in the stack.
        int _size;
        /// <summary>
        /// Adds the specified item to the stack.
        /// </summary>
        /// <param name="item">The item</param>
        public void Push(T item)
        {
            // _size = 0 ... first push.
            // _size == length ... growth boundary
            if (_size == _items.Length)
            {
                // initialize size of 4, otherwise double the current length
                int newLength = _size == 0? 4: _size * 2;
                // allocate, copy and assign the new array
                T[] newArray = new T[newLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            // add the item to the stack array and increase the size.
            _items[_size] = item;
            _size++;
        }
        /// <summary>
        /// Returns the top item from the stack and remove it from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            _size--;
            // Array is 0 index based. So we already decrement 1 for the size.
            return _items[_size];
        }
        /// <summary>
        /// Returns the top item from the stack without removing it from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            return _items[_size - 1];
        }
        /// <summary>
        /// The current number of items in the stack.
        /// </summary>
        public int Count
        {
            get { return _size; }
        }
        /// <summary>
        /// Removes all items from stack
        /// Note that this is too simple, if you have objects that have their own Dispose methods, you have to take care about them 
        /// because this approach will leave references to them
        /// </summary>
        public void Clear()
        {
            _size = 0;
        }
        /// <summary>
        /// Enumerates each item in the stack in LIFO order. The stack remains unalerted
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }
        /// <summary>
        /// Enumerates each item in the stack in LIFO order. The stack remains unalerted
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
