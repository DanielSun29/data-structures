using System;
using System.Collections.Generic;
using System.Text;

namespace B_Tree
{
    internal class TheBTree<T> where T : IComparable<T>
    {
        Node<T> root;

        int count;

        public TheBTree()
        {
            root = null;
            count = 0;
        }

        public void Insert(T key)
        {
            if (root == null)
            {
                root = new Node<T>(2);
                root.keys.Add(key);
                count++;
                return;
            }
        }
    }
}
