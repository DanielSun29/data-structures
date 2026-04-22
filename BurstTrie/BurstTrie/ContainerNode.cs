using System;
using System.Collections.Generic;
using System.Text;
using BST;

namespace BurstTrie
{
    public class ContainerNode : BurstNode
    {
        public ContainerNode(BurstTrie parent) : base(parent)
        {
        }

        BST<string> tree = new BST<string>();

        public override int Count => tree.Count;

        public override BurstNode Insert(string value, int index)
        {
           tree.RecursiveInsert(value);
           return this;
        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            success = tree.Remove(value);
            return this;
        }

        public override BurstNode? Search(string prefix, int index)
        {
            return tree.Search(prefix) != null ? this : null;
        }

        internal override void GetAll(List<string> output)
        {
            output.AddRange(tree.InOrderRec());
        }
    }
}
