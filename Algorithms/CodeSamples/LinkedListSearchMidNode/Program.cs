using System;
using System.Collections.Generic;

namespace LinkedListSearchMidNode
{
    /// <summary>
    /// This program is used to do a demonstration on a LinkedList Search Algorithm
    /// Requirement: There is a LinkedList, try to find the mid item of the List, but
    /// you can only go through the list once and you cannot use the Count property of
    /// that LinkedList
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var oddList = new LinkedList<int>();
            oddList.AddFirst(1);
            oddList.AddFirst(2);
            oddList.AddFirst(3);
            oddList.AddFirst(4);
            oddList.AddFirst(5);
            Console.WriteLine("The middle item of the odd list is {0}", GetMidItem(oddList).Value);

            var evenList = new LinkedList<int>();
            evenList.AddFirst(1);
            evenList.AddFirst(2);
            evenList.AddFirst(3);
            evenList.AddFirst(4);
            evenList.AddFirst(5);
            evenList.AddFirst(6);
            evenList.AddFirst(7);
            evenList.AddFirst(8);
            Console.WriteLine("The middle item of the even list is {0}", GetMidItem(evenList).Value);
            Console.ReadLine();
        }
        /// <summary>
        /// To do a sample, I will just assume that the LinkedList is based on Integer value type
        /// </summary>
        /// <param name="list">The LinkedList to search</param>
        /// <returns>The Mid List Node</returns>
        private static LinkedListNode<int> GetMidItem(LinkedList<int> list)
        {
            // For the detail explaination of the algorithm
            // Refer to my own notes
            var twoStepsPointer = list.First;
            var oneStepsPointer = list.First;
            while (twoStepsPointer.Next != null)
            {
                if (twoStepsPointer.Next.Next == null)
                {
                    return oneStepsPointer.Next;
                }
                else
                {
                    twoStepsPointer = twoStepsPointer.Next.Next;
                    oneStepsPointer = oneStepsPointer.Next;
                }
            }
            return oneStepsPointer;
        }
    }
}
