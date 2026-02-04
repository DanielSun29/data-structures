using System;
using System.Collections.Generic;
using System.Text;

namespace SortedDoublyLinkedList
{
    public class List<T> where T : IComparable<T>
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

        public bool Contains(T value)
        {
            Node<T> curr = Head;
            while (curr.Next != null && curr.Next.Value.CompareTo(value) < 0)
            {
                curr = curr.Next;
            }
            return curr.Next != null && curr.Next.Value.CompareTo(value) == 0;
        }

        public void Remove(T value)
        {
            Node<T> curr = Head;
            while (curr.Next != null && curr.Next.Value.CompareTo(value) < 0)
            {
                curr = curr.Next;
            }
            if (curr.Next != null && curr.Next.Value.CompareTo(value) == 0)
            {
                RemoveLinks(curr.Next);
                Count--;
            }
        }

        private static void RemoveLinks(Node<T> node)
        {
            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }
            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }
        }

        public bool IsSorted()
        {
            Node<T> curr = Head;
            while (curr.Next != null)
            {
                if (curr.Value.CompareTo(curr.Next.Value) > 0) return false;
                curr = curr.Next;
            }
            return true;
        }
    }
}
