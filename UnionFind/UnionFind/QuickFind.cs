using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    public class QuickFind<T> : IUnionFind<T>
    {
        Dictionary<T, int> items = new Dictionary<T, int>(); // Maps T to the index
        List<int> ids = new List<int>();

        public QuickFind(T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                items[elements[i]] = i;
                ids.Add(i);
            }
        }

        public bool AreConnected(T p, T q)
        {
            if (p == null || q == null) throw new ArgumentNullException("Elements cannot be null.");
            return ids[items[p]] == ids[items[q]];
        }

        public int Find(T p)
        {
            if (p == null) throw new ArgumentNullException("Element cannot be null.");
            return ids[items[p]];
        }

        public bool Union(T p, T q)
        {
            if (p == null || q == null) throw new ArgumentNullException("Elements cannot be null.");

            int pID = ids[items[p]];
            int qID = ids[items[q]];

            if (pID == qID) return false;

            for (int i = 0; i < ids.Count; i++)
            {
                if (ids[i] == qID)
                {
                    ids[i] = pID;
                }
            }

            return true;
        }
    }
}

