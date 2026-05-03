using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BurstTrie
{
    public class TheBurstTrie : ICollection<string>
    {
        private BurstNode root;

        public int max { get; private set; }

        public int Count => root.Count;

        public bool IsReadOnly => false;

        public TheBurstTrie()
        {
            root = new InternalNode(this);
            max = 5;
        }

        public TheBurstTrie(int max)
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

        public List<string> GetAll()
        {
            List<string> output = new List<string>();
            root.GetAll(output);
            return output;
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
            return Search(item) != null;
        }
        public BurstNode? Search(string prefix)
        {
            return root.Search(prefix.ToLower(), 0);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            List<string> output = new List<string>();
            root.GetAll(output);
            for (int i = 0; i < output.Count; i++)
            {
                array[arrayIndex + i] = output[i];
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            List<string> output = new List<string>();
            root.GetAll(output);
            for (int i = 0; i < output.Count; i++)
            {
                yield return output[i];
            }
            // Traverse the Trie and yield return each value
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       
    }

}
