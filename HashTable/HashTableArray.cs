using System;
using System.Collections.Generic;

namespace HashTable
{
    /// <summary>
    /// The fixed size array of the nodes in the hash tablel
    /// </summary>
    /// <typeparam name="TKey">The key type of the hash table</typeparam>
    /// <typeparam name="TValue">The value type of the hash table</typeparam>
    class HashTableArray<TKey, TValue>
    {
        HashTableArrayNode<TKey, TValue>[] _array;
        /// <summary>
        /// Constructs a new hash table array with the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity of the array</param>
        public HashTableArray(int capacity)
        {
            _array = new HashTableArrayNode<TKey, TValue>[capacity];
            // This will also initialize all the nodes for the HashTableArrayNode,
            // we should not have done this in a production code because we should Lazy these
            // we should only instantate these nodes when needed.
            for (int i = 0; i < capacity; i++)
            {
                _array[i] = new HashTableArrayNode<TKey, TValue>();
            }
        }
        /// <summary>
        /// Adds the key/value pair to the node. If the key already exists in the
        /// node array, an ArgumentException will be thrown
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            _array[GetIndex(key)].Add(key, value);
        }
    }
}