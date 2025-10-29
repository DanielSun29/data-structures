using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_and_Queues
{
    public class LLBQueue<T>
    {
        public int Count { get; private set; } // The amount of items in the Queue
        private LinkedList<T> data; // Backing for the Queue

        public LLBQueue()
        {
            data = new LinkedList<T>();
            Count = 0;
        }// Construct the Queue

        public void Enqueue(T value)
        {
            data.AddLast(value);
            Count++;
        }// Add an item to the end of the Queue
        public T Dequeue()
        {
            var temp = data.First;
            data.RemoveFirst();
            Count--;
            return temp.Value;
        }// Remove and get the item at the front of the Queue
        public T Peek()
        {
            return data.First.Value;
        }// Get the item at the front of the Queue


        // Optional Functions
        public bool IsEmpty()
        {
            return data.Count == 0;
        }// Returns if the Queue is empty
        public void Clear()
        {
            data.Clear();
        }// Deletes all data in the Queue
    }
}
