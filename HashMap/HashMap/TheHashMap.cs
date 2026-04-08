using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    public class TheHashMap<TKey, TValue>
    {

        LinkedList<KeyValuePair<TKey, TValue>>[] buckets;

        private readonly IEqualityComparer<TKey> keyComparer;
        private readonly int initialCapacity = 10;

        public int count { get; private set; }

        public TheHashMap(IEqualityComparer<TKey> comparer)
        {
            keyComparer = comparer;
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[initialCapacity];
            /* rest of the constructor goes here */
        }

        public TheHashMap()
        {
            keyComparer = EqualityComparer<TKey>.Default;
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[initialCapacity];
            /* rest of the constructor goes here */
        }

        // My own indexer
        public TValue this[TKey key]
        {
            get { return GetValue(key); }
            set { Add(new KeyValuePair<TKey, TValue>(key, value)); }

            // Feel free to call functions from the getter/setter if you'd like!
        }

        public TValue GetValue(TKey key)
        {
            // calculate index and lookup the corresponding bucket
            int index = Math.Abs(key.GetHashCode() % buckets.Length);

            foreach (var pair in buckets[index])
            {
                if (keyComparer.Equals(pair.Key, key))
                {
                    return pair.Value;
                }
            }// then search the bucket to find your key-value pair

            throw new KeyNotFoundException("Key not found");
        }

        bool Add(KeyValuePair<TKey, TValue> item)
        {

            if (count == initialCapacity)
            {
                ReHash();
            }

            // calculate index and lookup the corresponding bucket
            int index = Math.Abs(item.Key.GetHashCode() % buckets.Length);

            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            foreach (var pair in buckets[index])
            {
                if (keyComparer.Equals(pair.Key, item.Key))
                {
                    throw new Exception("Duplicate Key"); // key exists
                }
            }
            buckets[index].AddLast(item);
            count++;
            return true;
        }

        public bool Remove(TKey key)
        {
            int index = Math.Abs(key.GetHashCode() % buckets.Length);
            if (buckets[index] != null)
            {
                var current = buckets[index].First;
                while (current != null)
                {
                    if (keyComparer.Equals(current.Value.Key, key))
                    {
                        buckets[index].Remove(current);
                        count--;
                        return true;
                    }
                    current = current.Next;
                }
            }
            return false; // key not found
        }

        private void ReHash()
        {
            var oldBuckets = buckets;
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[buckets.Length * 2];
            count = 0;
            foreach (var bucket in oldBuckets)
            {
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                    {
                        int index = Math.Abs(pair.Key.GetHashCode() % buckets.Length);

                        if (buckets[index] == null)
                        {
                            buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                        }
                        buckets[index].AddLast(new KeyValuePair<TKey, TValue>(pair.Key, pair.Value));
                        count++;

                    }
                }
            }
        }
    }
}
