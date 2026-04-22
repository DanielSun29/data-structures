using System;
using System.Collections.Generic;
using System.Text;

namespace BurstTrie
{
    public class InternalNode : BurstNode
    {
        public InternalNode(BurstTrie parent) : base(parent)
        {
        }

        BurstNode[] children = new BurstNode[27];

        public override int Count => throw new NotImplementedException();

        public override BurstNode Insert(string value, int index)
        {
            throw new NotImplementedException();
        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            throw new NotImplementedException();
        }

        public override BurstNode? Search(string prefix, int index)
        {
            throw new NotImplementedException();
        }

        internal override void GetAll(List<string> output)
        {
            throw new NotImplementedException();
        }
    }
}
