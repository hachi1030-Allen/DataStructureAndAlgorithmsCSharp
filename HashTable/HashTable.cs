using System;
using System.Collections.Generic;

namespace HashTable
{
    /// <summary>
    /// A key/value associative collection
    /// </summary>
    /// <typeparam name="TKey">The key type of the key/value pair</typeparam>
    /// <typeparam name="TValue">The value type of the key/value pair</typeparam>
    public class HashTable<TKey, TValue>
    {
        // If the array exceeds this fill percentage it will grow
        // In this example the fill factor is the total number of items 
        // regardless of whether they are collisions or not.
        const double _fillFactor = 0.75;

        // the maximum number of items to store before growing.
        // This is just a cached value of the fill factor calculation
        int _maxItemAtCurrentSize;

        // the number of items in the hash table
        int _count;

        // The array where the items are stored.
        HashTableArray<TKey, TValue> _array;
        /// <summary>
        /// Constructs a hash table with the default capacity
        /// </summary>
        public HashTable() : this(1000)
        {

        }
    }
}
