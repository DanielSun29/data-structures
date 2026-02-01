using System;
using System.Collections.Generic;
using System.Text;

namespace SortedDoublyLinkedList
{
    internal class List<T> where T : IComparable<T>
    {
        public Node<T> Head { get; set; }

        public int Count { get; set; }

        public List()
        {
            Head = new Node<T>(default(T),null,null);
            Count = 0;
        }


        private void ConnectNodes(Node<T> previous, Node<T> newNode, Node<T> next)
        {
            newNode.Next = next;
            if (next != null)
            {
                next.Previous = newNode;
            }
            newNode.Previous = previous;
            previous.Next = newNode;
        }


        public void Add(T value)
        {
            Node<T> temp = new Node<T>(value);
            Node<T> curr = Head;
            while (curr.Next != null && curr.Next.Value.CompareTo(value) < 0)
            {
                curr = curr.Next;
            }
            ConnectNodes(curr, temp, curr.Next);
            Count++;
        }
    }
}
