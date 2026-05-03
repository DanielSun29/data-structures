using System;
using System.Collections.Generic;
using System.Text;

namespace BurstTrie
{
    public class InternalNode : BurstNode
    {
        public InternalNode(TheBurstTrie parent) : base(parent)
        {
        }

        BurstNode[] children = new BurstNode[27];

        public override int Count => GetCount();

        private int GetCount()
        {
            int count = 0;
            foreach (var child in children)
            {
                if (child != null)
                {
                    count += child.Count;
                }
            }
            return count;
        }

        public override BurstNode Insert(string value, int index)
        {
            char c = value[index];

            if (children[c - 'a'] == null)
            {
                children[c - 'a'] = new ContainerNode(ParentTrie);
            }
            children[c - 'a'].Insert(value, index + 1);

            return this;
        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            char c = value[index];

            if (Count < ParentTrie.max && index > 0)
            {
                // Unburst
                ContainerNode newNode = new ContainerNode(ParentTrie);



                List<string> allValues = new List<string>();
                GetAll(allValues);

                foreach (var val in allValues)
                {
                    newNode.Insert(val, index);
                }

                success = true;
                return this;
            }

            children[c - 'a'].Remove(value, index + 1, out success);
            return this;
        }

        public override BurstNode? Search(string prefix, int index)
        {
            if (children[prefix[index] - 'a'] == null)
            {
                return null;
            }

            if (index == prefix.Length - 1)
            {
                return this;
            }

            return children[prefix[index] - 'a'].Search(prefix, index + 1);
        }

        internal override void GetAll(List<string> output)
        {
            foreach (var val in children)
            {
                if (val is not null)
                {
                    val.GetAll(output);
                }
            }
        }
    }
}
