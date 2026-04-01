using System;
using System.Collections.Generic;
using System.Text;

namespace RadixSort
{
    public class TheRadixSort<T>
    {
        public static List<int> IntSort(List<int> input)
        {
            if (input == null || input.Count == 0) return input;

            int min = input.Min();
            int max = input.Max();
            int range = max - min + 1;
            int offset = -min;

            for (int i = 0; i < input.Count; i++)
            {
                input[i] += offset;
            }

            min = input.Min();
            max = input.Max();

            int exp = 1;
            while (max / exp > 0)
            {
                IntRadixHelper(input, exp);
                exp *= 10;
            }

            for (int i = 0; i < input.Count; i++)
            {
                input[i] -= offset;
            }

            return input;
        }

        private static void IntRadixHelper(List<int> input, int exp)
        {
            int n = input.Count;
            List<int> output = new List<int>(new int[n]);
            int[] count = new int[10]; // 10 here is radix

            for (int i = 0; i < n; i++)
            {
                count[(input[i] / exp) % 10]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--) // going backwards
            {
                output[count[(input[i] / exp) % 10] - 1] = input[i];
                count[(input[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
            {
                input[i] = output[i];
            }
        }

        public static List<KeyValuePair<int, T>> Sort(List<KeyValuePair<int, T>> input)
        {
            int min = input.Min(kvp => kvp.Key);
            int max = input.Max(kvp => kvp.Key);

            int range = max - min + 1;
            int offset = -min;

            for (int i = 0; i < input.Count; i++)
            {
                input[i] = new KeyValuePair<int, T>(input[i].Key + offset, input[i].Value);
            }


            min = input.Min(kvp => kvp.Key);
            max = input.Max(kvp => kvp.Key);

            int exp = 1;
            while (max / exp > 0)
            {
                RadixHelper(input, exp);
                exp *= 10;
            }

            for (int i = 0; i < input.Count; i++)
            {
                input[i] = new KeyValuePair<int, T>(input[i].Key - offset, input[i].Value);
            }

            return input;
        }

        private static void RadixHelper(List<KeyValuePair<int, T>> input, int exp)
        {
            int n = input.Count;
            List<KeyValuePair<int, T>> output = new List<KeyValuePair<int, T>>(new KeyValuePair<int, T>[n]);
            int[] count = new int[10]; // 10 here is radix

            for (int i = 0; i < n; i++)
            {
                count[(input[i].Key / exp) % 10]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--) // going backwards
            {
                output[count[(input[i].Key / exp) % 10] - 1] = input[i];
                count[(input[i].Key / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
            {
                input[i] = output[i];
            }
        }

        public static List<KeyValuePair<int, T>> VarBaseSort(List<KeyValuePair<int, T>> input, int b) // b is the base
        {
            int min = input.Min(kvp => kvp.Key);
            int max = input.Max(kvp => kvp.Key);

            int range = max - min + 1;
            int offset = -min;

            for (int i = 0; i < input.Count; i++)
            {
                input[i] = new KeyValuePair<int, T>(input[i].Key + offset, input[i].Value);
            }


            min = input.Min(kvp => kvp.Key);
            max = input.Max(kvp => kvp.Key);

            int exp = 1;
            while (max / exp > 0)
            {
                BasedRadixHelper(input, exp, b);
                exp *= b;
            }

            for (int i = 0; i < input.Count; i++)
            {
                input[i] = new KeyValuePair<int, T>(input[i].Key - offset, input[i].Value);
            }

            return input;
        }

        private static void BasedRadixHelper(List<KeyValuePair<int, T>> input, int exp, int b)
        {
            int n = input.Count;
            List<KeyValuePair<int, T>> output = new List<KeyValuePair<int, T>>(new KeyValuePair<int, T>[n]);
            int[] count = new int[b]; // b here is radix
            for (int i = 0; i < n; i++)
            {
                count[(input[i].Key / exp) % b]++;
            }
            for (int i = 1; i < b; i++)
            {
                count[i] += count[i - 1];
            }
            for (int i = n - 1; i >= 0; i--) // going backwards
            {
                output[count[(input[i].Key / exp) % b] - 1] = input[i];
                count[(input[i].Key / exp) % b]--;
            }
            for (int i = 0; i < n; i++)
            {
                input[i] = output[i];
            }
        }
    }
}
