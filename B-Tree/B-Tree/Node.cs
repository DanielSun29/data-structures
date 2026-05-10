using System;
using System.Collections.Generic;
using System.Text;

namespace B_Tree
{
    public class Node<T> where T : IComparable<T>
    {
        public List<Node<T>> children;
        public List<T> keys;

        public Node()
        {
            children = new List<Node<T>>();
            keys = new List<T>();
        }
    }
}
