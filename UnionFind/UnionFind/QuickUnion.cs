using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace UnionFind
{
    internal class QuickUnion<T> : IUnionFind<T>
    {
        Dictionary<T, T> parents; // Maps each element to its parent in the tree
        Dictionary<T, int> items; // Maps each element to its index

        public QuickUnion(T[] elements)
        {
            items = new Dictionary<T, int>();
            parents = new Dictionary<T, T>();
            for (int i = 0; i < elements.Length; i++)
            {
                items[elements[i]] = i;
                parents[elements[i]] = elements[i]; // Each element is its own parent initially
            }
        }

        public bool AreConnected(T p, T q)
        {
            throw new NotImplementedException();
        }

        public int Find(T p)
        {
            throw new NotImplementedException();
        }

        public bool Union(T p, T q)
        {
            throw new NotImplementedException();
        }
    }
}
