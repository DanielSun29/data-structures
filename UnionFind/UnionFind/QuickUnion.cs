using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace UnionFind
{
    public class QuickUnion<T> : IUnionFind<T>
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
            if (p == null || q == null) return false;

            int rootP = Find(p);
            int rootQ = Find(q);

            if (rootP == rootQ)
            {
                return true; // They are in the same union
            }
            else
            {
                return false; // They are in different unions
            }
        }

        public int Find(T p)
        {
            List<T> visited = new List<T>(); // To keep track of visited nodes for path compression

            while (parents[p] != null && !parents[p].Equals(p))
            {
                p = parents[p]; // Move up the tree
            }

            foreach (var node in visited)
            {
                parents[node] = p; // Path compression
            }

            return items[p]; // Return the index of the root element
        }

        public bool Union(T p, T q)
        {
            if (p == null || q == null) return false;

            if (AreConnected(p, q))
            {
                return false; // They are already in the same union
            }

            int rootQWeight = 0;
            int rootPWeight = 0;

            while (parents[q] != null && !parents[q].Equals(q))
            {
                rootQWeight++;
                q = parents[q]; // Move up the tree
            }

            while (parents[p] != null && !parents[p].Equals(p))
            {
                rootPWeight++;
                p = parents[p]; // Move up the tree
            }

            if (rootQWeight < rootPWeight)
            {
                parents[q] = p; // Attach smaller tree to larger tree
            }
            else
            {
                parents[p] = q;
            }

            return true;
        }
    }
}
