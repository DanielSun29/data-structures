using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    public class Node<T> where T : IComparable<T>
    {
        public bool IsRed;

        public T Value;

        public Node<T> Left;
        public Node<T> Right;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, bool isRed)
        {
            Value = value;
            IsRed = isRed;
        }
    }
}
