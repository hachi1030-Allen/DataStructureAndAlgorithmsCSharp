using System;
using System.Collections.Generic;
using System.Collections;

namespace DoublyLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; } 
        public int Length { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerable<T> GetEnumeratorReverse()
        {
            LinkedListNode<T> current = Tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if (Tail == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
            }

            // Set new Tail
            Tail = newNode;
            Length++;
        }

        public void AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            newNode.Next = Head;

            if (Head == null)
            {
                Tail = newNode;
            }
            else
            {
                Head.Previous = newNode;
            }
            Head = newNode;
            Length++;
        }

        public bool Contains(T value)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public LinkedListNode<T> FindFirst (T value)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public LinkedListNode<T> FindLast(T value)
        {
            LinkedListNode<T> current = Tail;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Previous;
            }
            return null;
        }

        public bool Remove( T value)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    // end of list
                    if (current.Next == null)
                    {
                        // remove last node from list
                        Tail = current.Previous;
                    }
                    else 
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (current.Previous == null)
                    {
                        Head = current.Next;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

                    current = null;
                    Length--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
                // If empty after removal
                if (Head == null)
                {
                    Tail = null;
                }
                Length--;
            }
        }

        public void RemoveLast()
        {
            if (Tail != null)
            {
                Tail = Tail.Previous;
                if (Tail == null)
                {
                    Head = null;
                }
                Length--;
            }
        }

        // IEnumerator IEnumerable.GetEnumerator()
        // {
        //     return ((IEnumerable<T>)this).GetEnumerator();
        // }
    }
}