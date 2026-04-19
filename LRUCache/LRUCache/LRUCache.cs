using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace LRUCache
{
    public class LRUCache<TKey, TValue> : ICache<TKey, TValue>
    {
        public int Capacity;

        private int Count { get { return Values.Count; } }

        public LRUCache(int capacity)
        {
            Capacity = capacity;
        }

        public LRUCache()
        {
            Capacity = 100;
        }

        public LinkedList<TKey> Keys = new LinkedList<TKey>();

        public Dictionary<TKey, TValue> Values = new Dictionary<TKey, TValue>();

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (Values.ContainsKey(key))
            {
                Keys.Remove(key);
                Keys.AddFirst(key);
                value = Values[key];
                return true;
            }
            value = default;
            return false;
        }

        public void Put(TKey key, TValue value)
        {
            if (Count >= Capacity)
            {
                var lastKey = Keys.Last.Value;
                Keys.RemoveLast();
                Values.Remove(lastKey);
            }

            if (!Values.ContainsKey(key))
            {
                Values.Add(key, value);
                Keys.AddFirst(key);
            }
            else
            {
                Keys.Remove(key);
                Keys.AddFirst(key);
                Values[key] = value;
            }
        }
    }
}
