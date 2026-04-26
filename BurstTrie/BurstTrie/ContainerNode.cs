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
            if (Count > ParentTrie.max)
            {
                InternalNode tempInternal = new InternalNode(ParentTrie);
                var nodes = tree.InOrderRec();
                foreach (var node in nodes)
                {
                    tempInternal.Insert(node, index + 1);
                }
                tempInternal.Insert(value, index + 1);
                return tempInternal;
            }

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
            var temp = tree.Search(prefix);
            if (temp is not null) return new ContainerNode(this.ParentTrie).Insert(temp.Value, index);
            var values = tree.InOrderRec();
            var node= new ContainerNode(this.ParentTrie);
            foreach (var value in values)
            {
                if (value.StartsWith(prefix))
                {
                    node.Insert(value, index);
                }
            }
            return node;
        }

        internal override void GetAll(List<string> output)
        {
            output.AddRange(tree.InOrderRec());
        }
    }
}
