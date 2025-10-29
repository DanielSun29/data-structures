using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Stacks_and_Queues
{
    public class ABQueue<T>
    {
        public int Count { get; private set; } // The amount of items in the Queue
        private T[] data; // Backing for the Queue
        private int head; // The point to remove at
        private int tail; // The point to add at

        public ABQueue(int size)
        {
            data = new T[size];
            head = 0;
            tail = 0;
        }// Construct the Queue

        public void Enqueue(T value)
        {
            if (Count >= data.Length-1)
            {
                Resize(data.Length * 2);
            }
            if (tail == data.Length)
            {
                tail = 0;
            }
            data[tail] = value;
            tail++;
            Count++;
        }// Add an item to the end of the Queue
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Queue is Empty");
            }
            else if (head == data.Length)
            {
                head = 0;
            }
            T temp = data[head];
            head++;
            Count--;
            return temp;
        }// Remove and get the item at the front of the Queue
        public T Peek()
        {
            return data[head];
        }// Get the item at the front of the Queue

        private void Resize(int size)
        {
            T[] temp = new T[size];
            int curr = 0;
            for (int i = head; i < size && i < data.Length; i++)
            {
                temp[curr] = data[i];
                curr++;
            }
            for (int i = 0; i < size-head && i < head; i++)
            {
                temp[curr] = data[i];
                curr++;
            }
            data = temp;
            head = 0;
            tail = curr;
        }// Resize and re-index the data 

        // Optional Functions
        public bool IsEmpty()
        {
            return Count == 0;
        }// Returns if the Queue is empty
        public void Clear()
        {
            data = new T[Count];
            Count = 0;
            tail = 0;
        }// Deletes all data in the Queue
    }
}
