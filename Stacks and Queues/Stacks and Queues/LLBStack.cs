using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_and_Queues
{
    public class LLBStack<T>
    {
        public int Count { get; private set; }
        private LinkedList<T> data;

        public LLBStack()
        {
            data = new LinkedList<T>();
            Count = 0;
        }

        public void Push(T value)
        {
            data.AddFirst(value);
            Count++;
        }

        public T Pop()
        {
            T temp = data.First.Value;
            data.RemoveFirst();
            Count--;
            return temp;
        }

        public T Peek()
        {
            return data.First.Value;
        }


        // Optional Functions
        public void Clear()
        {
            data.Clear();
            Count = 0;
        }
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
