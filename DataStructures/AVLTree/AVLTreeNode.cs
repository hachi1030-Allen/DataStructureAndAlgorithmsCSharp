using System;

namespace AVLTree
{
    /// <summary>
    /// An AVL tree node class
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    public class AVLTreeNode<TNode> : IComparable<TNode>
        where TNode: IComparable
    {
        #region Fields and Properties
        AVLTree<TNode> _tree;
        AVLTreeNode<TNode> _left;
        public AVLTreeNode<TNode> Left
        {
            get { return _left; }
            internal set
            {
                _left = value;
                if (_left != null)
                {
                    _left.Parent = this;
                }
            }
        }

        AVLTreeNode<TNode> _right;
        public AVLTreeNode<TNode> Right
        {
            get { return _right; }
            internal set
            {
                _right = value;
                if (_right != null)
                {
                    _right.Parent = this;
                }
            }
        }

        public AVLTreeNode<TNode> Parent { get; internal set; }
        public TNode Value { get; private set; }

        private int LeftHeight
        {
            get
            {
                return MaxChildHeight(Left);
            }
        }

        private int RightHeight
        {
            get
            {
                return MaxChildHeight(Right);
            }
        }
        /// <summary>
        /// Indicate whether the tree is balanced or not.
        /// </summary>
        private TreeState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                {
                    return TreeState.LeftHeavy;
                }

                if (RightHeight - LeftHeight > 1)
                {
                    return TreeState.RightHeavy;
                }

                return TreeState.Balanced;
            }
        }

        private int BalanceFactor
        {
            get
            {
                return RightHeight - LeftHeight;
            }
        }
        #endregion

        
        public AVLTreeNode(TNode value, AVLTreeNode<TNode> parent, AVLTree<TNode> tree)
        {
            Value = value;
            Parent = parent;
            _tree = tree;
        }

        #region Methods
        /// <summary>
        /// Recursively get the max child height for some tree node.
        /// For example
        ///        4
        ///       / \
        ///      2   6
        ///      \
        ///       3
        /// For node 4, the max child height is 2 because the left tree for node 4 has 2 level
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int MaxChildHeight(AVLTreeNode<TNode> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }
            return 0;
        }

        /// <summary>
        /// The key algorithm to balance the tree
        /// whenever we add / remove a tree node which
        /// casues the tree to be not balanced
        /// </summary>
        internal void Balance()
        {
            if (State == TreeState.RightHeavy)
            {
                if (Right != null && Right.BalanceFactor < 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    LeftRotation();
                }
            }
            else if (State == TreeState.LeftHeavy)
            {
                if (Left != null && Left.BalanceFactor > 0)
                {
                    RightLeftRotation();
                }
                else
                {
                    RightRotation();
                }
            }
        }

        private void LeftRotation()
        {
            //     a (this)
            //      \
            //       b
            //        \
            //         c
            //
            // becomes
            //       b
            //      / \
            //     a   c

            // Note: We are applying LeftRotation on node a which is the current root node.

            // Step 1: Make the right node to be the new root.
            AVLTreeNode<TNode> newRoot = Right;
            // Step 2: Replace the current root with the new root
            ReplaceRoot(newRoot);
            // Step 3: take the ownership of right's left child as right (now parent)
            // In the above a b c sample, new root b does not have left,
            // so the Right (a's right child) has no element to take ownership.
            Right = newRoot.Left;
            // Step 4: the new root takes this as it's left (this is the a node)
            newRoot.Left = this;
        }

        private void RightRotation()
        {
            //     c (this)
            //    /
            //   b
            //  /
            // a
            //
            // becomes
            //       b
            //      / \
            //     a   c

            // Note: RightRotation is basically the opposite of LeftRotation

            AVLTreeNode<TNode> newRoot = Left;
            // replace the current root with the new root
            ReplaceRoot(newRoot);
            // take ownership of left's right child as left (now parent)
            Left = newRoot.Right;
            // the new root takes this as it's right
            newRoot.Right = this;
        }

        private void ReplaceRoot(AVLTreeNode<TNode> newRoot)
        {
            // If this node is a subtree 
            // which means it has a parent node
            if (this.Parent != null)
            {
                // If this node is the left child of its parent
                if (this.Parent.Left == this)
                {
                    this.Parent.Left = newRoot;
                }
                // If this node is the right child of its parent
                else if (this.Parent.Right == this)
                {
                    this.Parent.Right = newRoot;
                }
            }
            // If this node does not have parent
            // which means it's a root node
            // Then replace the tree head with newRoot
            else
            {
                _tree._head = newRoot;
            }
            // Make newRoot's parent as this's parent
            newRoot.Parent = this.Parent;
            // make this's parent as newRoot
            this.Parent = newRoot;
        }

        private void LeftRightRotation()
        {
            // Step 1: Apply the RightRotation to this's Right node.
            Right.RightRotation();
            // Step 2: Apply LeftRotation to this
            LeftRotation();
        }

        private void RightLeftRotation()
        {
            // Opposite with LeftRightRotation()
            Left.LeftRotation();
            RightRotation();
        }

        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
        #endregion
    }
    /// <summary>
    /// An enum that indicates whether the tree is balanced
    /// or LeftHeavy or RightHeavy
    /// </summary>
    public enum TreeState
    {
        Balanced,
        LeftHeavy,
        RightHeavy,
    }
}
