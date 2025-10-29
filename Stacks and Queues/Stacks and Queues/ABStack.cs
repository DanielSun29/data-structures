using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_and_Queues
{
    public class ABStack<T>
    {
        public int Count { get; private set; }
        private T[] data;

        public ABStack(int capacity)
        {
            data = new T[capacity];
            Count = 0;

        }



        public void Push(T value)
        {
            if (Count != data.Length)
            {
                data[Count] = value;
            }
            else
            {
                Resize(data.Length * 2);
                data[Count] = value;
            }
            Count++;
        }
        public T Pop()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("No elements in stack");
            }
            T[] temp = new T[data.Length];
            T value = data[Count];
            for (int i = 0; i < Count - 1; i++)
            {
                temp[i] = data[i];
            }
            data = temp;
            Count--;
            return value;
        }
        public T Peek()
        {
            return data[Count - 1];
        }
        private void Resize(int size)
        {
            T[] temp = new T[size];
            for (int i = 0; i < Count && i < size; i++)
            {
                temp[i] = data[i];
            }
            data = temp;
        }

        // Optional Functions
        public void Clear()
        {
            data = new T[Count];
            Count = 0;
        }
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
