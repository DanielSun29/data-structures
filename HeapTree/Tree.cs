using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapTree
{
    public class Tree<T> where T : IComparable<T>
    {
        public T[] heap;
        public int size;

        public Tree(int capacity)
        {
            heap = new T[capacity];
            size = 0;
        }

        public void Insert(T value)
        {
            if (size == heap.Length)
            {
                Resize();
            }
            heap[size] = value;
            size++;
            HeapifyUp(size - 1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            if (index > 0 && heap[index].CompareTo(heap[parentIndex]) < 0)
            {
                T temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;
                HeapifyUp(parentIndex);
            }
        }

        public void Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }
            heap[0] = heap[size - 1];
            size--;
            HeapifyDown(0);
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallestIndex = index;

            if (leftChildIndex < size && heap[leftChildIndex].CompareTo(heap[smallestIndex]) < 0)
            {
                smallestIndex = leftChildIndex;
            }

            if (rightChildIndex < size && heap[rightChildIndex].CompareTo(heap[smallestIndex]) < 0)
            {
                smallestIndex = rightChildIndex;
            }

            if (smallestIndex != index)
            {
                T temp = heap[index];
                heap[index] = heap[smallestIndex];
                heap[smallestIndex] = temp;
                HeapifyDown(smallestIndex);
            }
        }

        private void Resize()
        {
            T[] temp = new T[heap.Length * 2];
            Array.Copy(heap, temp, heap.Length);
            heap = temp;
        }

        public static T[] Sort(T[] input)
        {
            Tree<T> heap = new Tree<T>(input.Length);
            
            for (int i = 0; i < input.Length; i++)
            {
                heap.Insert(input[i]);
            }

            T[] output = new T[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = heap.heap[0];
                heap.Pop();
            }

            return output;
        }
    }
}
