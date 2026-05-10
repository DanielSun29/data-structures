using System;
using System.Collections.Generic;
using System.Text;

namespace B_Tree
{
    public class TheBTree<T> where T : IComparable<T>
    {
        Node<T> root;

        int count;

        public TheBTree()
        {
            root = null;
            count = 0;
        }

        public Node<T> Search(T key) => SearchHelper(root, key);

        private Node<T> SearchHelper(Node<T> node, T key)
        {
            if (node == null)
            {
                return null;
            }

            int i = 0;
            while (i < node.keys.Count && key.CompareTo(node.keys[i]) > 0)
            {
                i++;
            }

            if (i < node.keys.Count && key.CompareTo(node.keys[i]) == 0)
            {
                return node;
            }

            return SearchHelper(node.children.Count > 0 ? node.children[i] : null, key);
        }

        public void Insert(T key)
        {
            if (root == null)
            {
                root = new Node<T>();
                root.keys.Add(key);
                count++;
                return;
            }

            if (root.keys.Count == 3)
            {
                root = TopSplit(root);
            }

            if (Search(key) != null)
            {
                return;
            }

            InsertHelper(root, key);
        }

        private void InsertHelper(Node<T> node, T key)
        {
            int i = 0;
            while (i < node.keys.Count && key.CompareTo(node.keys[i]) > 0)
            {
                i++;
            }


            // Check if children is null or it will explode
            if (node.children[i].keys.Count == 3)
            {
                node = InternalSplit(node, i);
            }
            i = 0;
            while (i < node.keys.Count && key.CompareTo(node.keys[i]) > 0)
            {
                i++;
            }

            if (node.children.Count == 0)
            {
                node.keys.Insert(i, key);
                count++;
                return;
            }
            InsertHelper(node.children[i], key);
        }

        private Node<T> InternalSplit(Node<T> node, int splitIndex)
        {
            Node<T> newNode = node;
            newNode.keys.Insert(splitIndex, node.children[splitIndex].keys[1]);

            newNode.children[splitIndex].keys.RemoveAt(1);

            return newNode;
        }

        private Node<T> TopSplit(Node<T> node)
        {
            Node<T> newNode = new Node<T>();
            newNode.keys.Add(node.keys[1]);

            newNode.children.Add(new Node<T>());
            newNode.children[0].keys.Add(node.keys[0]);

            newNode.children.Add(new Node<T>());
            newNode.children[1].keys.Add(node.keys[2]);

            if (node.children.Count == 4)
            {
                newNode.children[0].children.Add(node.children[0]);
                newNode.children[0].children.Add(node.children[1]);
                newNode.children[1].children.Add(node.children[2]);
                newNode.children[1].children.Add(node.children[3]);
            }
       
            return newNode;
        }

        public bool contains(T key) => Search(key) != null;
    }
}
