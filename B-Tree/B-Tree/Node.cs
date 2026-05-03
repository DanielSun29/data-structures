using System;
using System.Collections.Generic;
using System.Text;

namespace B_Tree
{
    public class Node<T> where T : IComparable<T>
    {
        int type;

        public List<Node<T>> children;
        public List<T> keys;

        public Node(int type)
        {
            this.type = type;
            children = new List<Node<T>>(type);
            keys = new List<T>(type - 1);
        }
    }
}
