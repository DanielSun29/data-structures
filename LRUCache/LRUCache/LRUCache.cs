using System;
using System.Collections.Generic;
using System.Text;

namespace LRUCache
{
    internal class LRUCache<TKey, TValue> : ICache<TKey, TValue>
    {
        public LinkedList<TKey> Keys = new LinkedList<TKey>();

        public Dictionary<TKey, TValue> Values = new Dictionary<TKey, TValue>();

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (Values.ContainsKey(key))
            {

            }
            throw new NotImplementedException();
        }

        public void Put(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }
    }
}
