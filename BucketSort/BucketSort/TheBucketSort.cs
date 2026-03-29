using System;
using System.Collections.Generic;
using System.Text;

namespace BucketSort
{
    public class TheBucketSort<T>
    {
        const int BUCKETCOUNT = 4;
        public static List<KeyValuePair<int, T>> Sort(List<KeyValuePair<int, T>> values)
        {
            int min = values.Min(kvp => kvp.Key);
            int max = values.Max(kvp => kvp.Key);
            int range = max - min + 1;

            int bucketCap = (range/BUCKETCOUNT % BUCKETCOUNT == 0) ? (range / BUCKETCOUNT) : (range / BUCKETCOUNT + 1);

            List<KeyValuePair<int, T>> output = new List<KeyValuePair<int, T>>();
            int offset = -min;
            List<KeyValuePair<int, T>>[] buckets = new List<KeyValuePair<int, T>>[BUCKETCOUNT];

            foreach (KeyValuePair<int, T> kvp in values)
            {
                if (buckets[(kvp.Key + offset) / bucketCap] == null)
                {
                    buckets[(kvp.Key + offset) / bucketCap] = new List<KeyValuePair<int, T>>();
                }
                buckets[(kvp.Key + offset) / bucketCap].Add(kvp);
            }
            foreach (List<KeyValuePair<int, T>> bucket in buckets)
            {
                if (bucket == null)
                {
                    continue;
                }
                InsertionSort(bucket);
                output.AddRange(bucket);
            }

            return output;
        }
        static void InsertionSort(List<KeyValuePair<int, T>> list)
        {
            if (list == null || list.Count <= 1)
            {
                return;
            }

            for (int i = 1; i < list.Count; i++)
            {
                var current = list[i];
                int j = i - 1;

                // Shift elements that are greater than current.Key to the right
                while (j >= 0 && list[j].Key > current.Key)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = current;
            }
        }
    }
}
