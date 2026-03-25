using System;
using System.Collections.Generic;
using System.Text;

namespace CountingSort
{
    public class TheCountingSort<T>
    {
        public static List<int> IntSort(List<int> values)
        {
            int min = values.Min();
            int max = values.Max();
            int range = max - min + 1;
            List<int> output = new List<int>();
            int offset = -min;
            int[] buckets = new int[range];
            foreach (int value in values)
            {
                buckets[value + offset]++;
            }
            for (int i = 0; i < buckets.Length; i++)
            {
                int n = buckets[i];
                for (int j = 0; j < n; j++)
                {
                    output.Add(i - offset);
                }
            }
            return output;
        }

        public static List<KeyValuePair<int, T>> Sort(List<KeyValuePair<int, T>> values)
        {
            int min = values.Min(kvp => kvp.Key);
            int max = values.Max(kvp => kvp.Key);
            int range = max - min + 1;
            List<KeyValuePair<int, T>> output = new List<KeyValuePair<int, T>>();
            int offset = -min;
            List<T>[] buckets = new List<T>[range];
            foreach (KeyValuePair<int, T> kvp in values)
            {
                if (buckets[kvp.Key + offset] == null)
                {
                    buckets[kvp.Key + offset] = new List<T>();
                }
                buckets[kvp.Key + offset].Add(kvp.Value);
            }
            for (int i = 0; i < buckets.Length; i++)
            {
                List<T> bucket = buckets[i];
                if (bucket == null) continue;
                foreach (T value in bucket)
                {
                    output.Add(new KeyValuePair<int, T>(i - offset, value));
                }
            }
            return output;
        }

        //void yeet()
        //{
        //    KeyValuePair<int, string> bobl;
        //    bobl.
        //}
    }
}
