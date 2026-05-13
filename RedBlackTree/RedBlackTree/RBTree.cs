using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    public class RBTree<T> where T : IComparable<T>
    {
        public Node<T> Root;

        public Node<T> LeftRotate(Node<T> node)
        {
            var newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;
            node.IsRed = true;
            newRoot.IsRed = false;
            return newRoot;
        }

        public Node<T> RightRotate(Node<T> node)
        {
            var newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;
            node.IsRed = true;
            newRoot.IsRed = false;
            return newRoot;
        }

        public void FlipColor(Node<T> node)
        {
            node.IsRed = !node.IsRed;
            if (node.Left != null)
                node.Left.IsRed = !node.Left.IsRed;
            if (node.Right != null)
                node.Right.IsRed = !node.Right.IsRed;
        }

        public bool isRed(Node<T> node)
        {
            return node != null && node.IsRed;
        }
    }
}
