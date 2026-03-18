using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    public static class Extensions
    {
        public static bool Contains<TKey, TValue>(this PriorityQueue<TKey, TValue> queue, TKey item)
        {
            return queue.UnorderedItems.FirstOrDefault(x => x.Element!.Equals(item)).Element is not null;
        }
    }
}
