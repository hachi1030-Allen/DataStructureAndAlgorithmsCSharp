using System;
using System.Collections.Generic;
using System.Collections;

namespace Set
{
    public class Set<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        private readonly List<T> _items = new List<T>();
        public Set() {}
        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public void Add(T item)
        {
            if (_items.Contains(item))
            {
                throw new InvalidOperationException("Item already exists in Set.");
            }
            _items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                // Add will make sure the item is unique
                // Check above implementation
                Add(item);
            }
        }

        private void AddSkipDuplicates(T item)
        {
            if (!Contains(item))
            {
                _items.Add(item);
            }
        }
        private void AddRangeSkipDuplicates(IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                AddSkipDuplicates(item);
            }
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public int Count
        {
            get { return _items.Count; }
        }
        /// <summary>
        /// Union (并集)
        /// </summary>
        /// <param name="other">The other Set to be unioned with</param>
        /// <returns>A set that contains all the element in current Set and the other Set</returns>
        public Set<T> Union(Set<T> other)
        {
            // Use current Set to initialize the result
            Set<T> result = new Set<T>(_items);
            // Use the above private method to add a range
            // but needs to skip the duplicates
            result.AddRangeSkipDuplicates(other._items);

            return result;
        }
        /// <summary>
        /// Intersection (交集)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Set<T> Intersection(Set<T> other)
        {
            // Use default constructor to initalize the result set
            Set<T> result = new Set<T>();
            foreach(T item in _items)
            {
                // Only need to check whether the item is contained
                // in the other Set, because we are adding elements
                // only from the original Set. Therefore, the unique
                // can be gurranteed because the original Set must only
                // have unique elements
                if (other._items.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public Set<T> Difference(Set<T> other)
        {
            Set<T> result = new Set<T>(_items);
            foreach(T item in other._items)
            {
                result.Remove(item);
            }
            return result;
        }
        /// <summary>
        /// SymmatricDifference is actually returning:
        /// elements that in current Set or in other Set
        /// the implementation is to get the difference for
        /// their union set and their intersection set
        /// A real sample for this is: get the students who chose
        /// Course A or Course B but not both
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Set<T> SymmetricDifference(Set<T> other)
        {
            Set<T> intersecion = Intersection(other);
            Set<T> union = Union(other);

            return union.Difference(intersecion);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
