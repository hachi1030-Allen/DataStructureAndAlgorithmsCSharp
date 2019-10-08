using System;
using System.Collections.Generic;
using System.Collections;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private int _count;

        #region Add
        /// <summary>
        /// Adds the provided value to the binary tree.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            // Case 1: The tree is empty, allocate the head
            if (_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            }
            // Case 2: The tree is not empty so find the right location to insert
            else 
            {
                AddTo(_head, value);
            }
        }

        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            // Case 1: value is less than the current node value
            if (value.CompareTo(node.Value) < 0)
            {
                // if there is no left child, then make this the left child.
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // else recursively add to the left until it can be done.
                    AddTo(node.Left, value);
                }
            }
            // Case 2: value is greater than the current node value
            else
            {
                // if there is no right child, make this the right child
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // else recursively add to the right until it can be done.
                    AddTo(node.Right, value);
                }
            }
        }
        #endregion
        /// <summary>
        /// Determines if the specified value exists in the binary tree.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>True if the tree contains the value, otherwise false</returns>
        public bool Contains(T value)
        {
            // defer to the node search helper function.
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }
        /// <summary>
        /// Finds and returns the first node containing the specified value. If the value
        /// is not found, returns null. Also returns the parent of the found node ( or null )
        /// which is used in Remove method.
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <param name="parent">The parent of the found node ( or null )</param>
        /// <returns>The found node (or null)</returns>
        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            // Now, try to find data in the tree.
            BinaryTreeNode<T> current = _head;
            parent = null;
            while (current != null)
            {
                int result = value.CompareTo(current.Value);
                if (result > 0)
                {
                    // if the value is greater than the current, go left.
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // if the value is less than the current, go right.
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    // we have a match, break the loop
                    break;
                }
            }
            return current;
        }

        #region Remove
        /// <summary>
        /// Removes the first occurance of the specified value from the tree
        /// </summary>
        /// <param name="value">The value to remove</param>
        /// <returns>Ture if the value was removed, otherwise false</returns>
        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;

            // First step is to find the node.
            current = FindWithParent(value, out parent);
            // The node does not exist
            if (current == null)
            {
                return false;
            }

            // Found, first make the count - 1 and then we deal with how to promote the children nodes.
            _count--;

            // Case 1: If current has no right child, then current's left replaces current.
            if (current.Right == null)
            {
                // Remove is the head node
                if (parent == null)
                {
                    _head = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    // We use current's Left child to replace current
                    // but needs to see if it should be parent's right or left child.
                    if (result > 0)
                    {
                        // if parent value is greater than the current value
                        // make the current left child a left child of parent
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        // if parent value is less than current value
                        // make the current left child a right child of parent
                        parent.Right = current.Left;
                    }
                }
            }
            // Case 2: If current's right child has no left child, then current's right child replaces current.
            else if (current.Right.Left == null)
            {
                // Make the current's Right child's Left node to be current's Left node.
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // if parent value is greater than the current value
                        // make the current right child to be the left child of parent
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        // if parent value is less than the current value
                        // make the current right child to be the right child of parent
                        parent.Right = current.Right;
                    }
                }
            }
            // Case 3: If current's right child has a left child, replace current with current's
            // right child's left-most child
            else
            {
                // find the right's left-most child.
                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // The parent's left subtree becomes the leftmost's right subtree
                leftmostParent.Left = leftmost.Right;

                // Make the leftmost node to be the current node
                // by assigning the current's left and right to leftmost's left and right
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                // Same logic to see whether the leftmost be assigned to parent's left or right side
                if (parent == null)
                {
                    _head = parent;
                }
                else
                {
                    int result = (parent.CompareTo(current.Value));
                    if (result > 0)
                    {
                        // if parent value is greater than current value
                        // make leftmost the parent's left child
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        // if parent value is less than current value
                        // make leftmost the parent's right child
                        parent.Right = leftmost;
                    }
                }
            }
            return true;
        }
        #endregion

        #region Pre-Order Traversal
        /// <summary>
        /// Performs the provided action on each binary tree value in pre-order traversal order.
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }
        #endregion

        #region Post-Order Traversal
        /// <summary>
        /// Performs the provided action on each binary tree value in post-order traversal order.
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }

        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }
        #endregion

        #region In-Order Traversal
        /// <summary>
        /// Performs the provided action on each binary tree value in in-order traversal order.
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);
            }
        }
        #endregion

        #region In-Order Enumeration
        /*
            Note: Recursive method is not a good idea for a production environment
            For example, if you have million of tree nodes and when you call the above function,
            you will encounter a Stack Overflow and the app will crash.
            You do not want these kind of things happen in your production environment.
        */

        // So here is the non-recursive version of In-Order traversal using a Stack
        /// <summary>
        /// Enumerates the values contains in the binary tree in in-order traversal order.
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<T> InOrderTraversal()
        {
            // This is a non-recursive algorithm using a stack to demonstrate removing
            // recursion to makke using the yield syntax easier.
            if (_head != null)
            {
                // store the nodes we've skipped in this stack (avoids recursion)
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = _head;

                // when removing recursion, we need to keep track of whether or not
                // we should be going to the left node or the right node.
                // previously when using recursion, we just keep going left until it's null
                // and then return to move to next line of code.
                bool goLeftNext = true;
                
                // start by pushing Head onto the stack
                stack.Push(current);

                while (stack.Count > 0)
                {
                    // If we are heading left...
                    if (goLeftNext)
                    {
                        // push everything but the left-most node to the stack
                        // we will yield the left-most after this block.
                        while (current.Left != null)
                        {
                            // bug? Need to push current.Left? Since above already pushed the current which is the head?
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    // in-order is left -> yield -> right
                    yield return current.Value;

                    // if we can go right then do so
                    if (current.Right != null)
                    {
                        current = current.Right;
                        // Once we've gone right once, we need to start
                        // going left again.
                        goLeftNext = true;
                    }
                    else
                    {
                        // if we cannot go right then we need to pop off the parent node
                        // so we can process it and then go to it's right node
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
        /// <summary>
        /// Returns an enumerator that performs an in-order traversal of the binary tree
        /// </summary>
        /// <returns>The in-order enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return  InOrderTraversal();
        }
        /// <summary>
        /// Returns an enumerator that performs an in-order traversal of the binary tree
        /// </summary>
        /// <returns>The in-order enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        /// <summary>
        /// Removes all items from the tree
        /// </summary>
        public void Clear()
        {
            _head = null;
            _count = 0;
        }
        /// <summary>
        /// The number of nodes in the tree
        /// </summary>
        public int Count
        {
            get { return _count; }
        }
    }
}