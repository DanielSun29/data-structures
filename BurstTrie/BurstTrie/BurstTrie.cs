using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BurstTrie
{
    public class BurstTrie : ICollection<string>
    {
        private BurstNode root;

        public int max { get; private set; }

        public int Count => root.Count;

        public bool IsReadOnly => false;

        public BurstTrie()
        {
            root = new InternalNode(this);
            max = 5;
        }

        public BurstTrie(int max)
        {
            root = new InternalNode(this);
            this.max = max;
        }

        public void Insert(string value)
        {
            string lowered = value.ToLower();
            root.Insert(lowered, 0);
        }
        public bool Remove(string value)
        {
            string lowered = value.ToLower();
            bool success;

            root.Remove(lowered, 0, out success);
            return success;
        }

        public void Add(string item)
        {
            Insert(item);
        }

        public void Clear()
        {
            root = new InternalNode(this);
        }

        public bool Contains(string item)
        {
            return root.Search(item, 0) != null;
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
            // Traverse the Trie and yield return each value
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       
    }

}
