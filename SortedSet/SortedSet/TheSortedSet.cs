using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RedBlackTree;

namespace SortedSet
{
    public class TheSortedSet<T> : ISortedSet<T> where T : IComparable<T>
    {

        private RBTree<T> tree;

        public IComparer<T> Comparer { get; set; }

        public int Count => tree == null ? 0 : tree.Recursion().Count;

        public bool Add(T item)
        {
           if (tree == null)
           {
                tree = new RBTree<T>();
           }
           if (tree.Contains(item))
           {
                return false;
           }
            tree.Insert(item);
            return true;
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (tree == null)
            {
                tree = new RBTree<T>();
            }
            foreach (var item in items)
            {
                if (!tree.Contains(item))
                {
                    Add(item);
                }
            }
        }

        public T Ceiling(T item)
        {
            List<T> list = tree.Recursion();
            int i = 0;
            while (item.CompareTo(list[i]) > 0)
            {
                i++;
            }
            return list[i];
        }

        public void Clear()
        {
            tree = new RBTree<T>();
        }

        public bool Contains(T item)
        {
            return tree.Contains(item);
        }

        public T Floor(T item)
        {
            List<T> list = tree.Recursion();
            int i = 0;
            while (item.CompareTo(list[i]) > 0)
            {
                i++;
            }
            return list[i - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> list = tree.Recursion();
            foreach(T item in list)
            {
                yield return item;
            }
        }

        public ISortedSet<T> Intersection(ISortedSet<T> other)
        {
            TheSortedSet<T> output = new TheSortedSet<T>();
            foreach (T item in other)
            {
                if (tree.Contains(item))
                {
                    output.Add(item);
                }
            }
            return output;
        }

        public T Max()
        {
            Node<T> current = tree.Root;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current.Value;
        }

        public T Min()
        {
            Node<T> current = tree.Root;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current.Value;
        }

        public bool Remove(T item)
        {
            if (tree.Contains(item))
            {
                tree.Remove(item);
                return true;
            }
            return false;
        }

        public ISortedSet<T> Union(ISortedSet<T> other)
        {
            RBTree<T> result = tree;
            foreach (var item in other)
            {
                if (!result.Contains(item))
                {
                    result.Insert(item);
                }
            }
            TheSortedSet<T> output = new TheSortedSet<T>();
            output.tree = result;
            return output;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
