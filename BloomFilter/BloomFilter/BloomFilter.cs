using System;
using System.Collections.Generic;
using System.Text;

namespace BloomFilter
{
    public class BloomFilter<T>
    {

        public List<Func<T, int>> hashFunctions;

        public bool[] bitArray;

        public BloomFilter(int cap)
        {
            hashFunctions = [HashFuncOne, HashFuncTwo, HashFuncThree];
            bitArray = new bool[cap];
        }


        public void LoadHashFunc(Func<T, int> hashFunc)
        {
            hashFunctions.Add(hashFunc);
        }

        public void Insert(T item)
        {
            foreach (var hashFunc in hashFunctions)
            {
                int index = Math.Abs(hashFunc(item) % bitArray.Length);
                bitArray[index] = true;
            }
        }

        public bool ProbablyContains(T item)
        {
            foreach (var hashFunc in hashFunctions)
            {
                int index = Math.Abs(hashFunc(item) % bitArray.Length);
                if (!bitArray[index])
                {
                    return false;
                }
            }
            return true;
        }

        private int HashFuncOne(T item)
        {
            return item.GetHashCode();
        }

        private int HashFuncTwo(T item)
        {
            string dummyString = "dummystring";
            return (dummyString, item).GetHashCode();
        }

        private int HashFuncThree(T item)
        {
            int hash = 17;
            hash *= (HashFuncOne(item), HashFuncTwo(item)).GetHashCode();
            return hash;
        }
    }

}
