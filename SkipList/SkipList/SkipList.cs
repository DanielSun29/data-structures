using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    public class SkipList<T> : ICollection<T> where T : IComparable<T>
    {
        public Node<T> Head { get; set; }

        public int Count { get; set; }

        public bool IsReadOnly => false;

        public SkipList()
        {
            Head = new Node<T>(default(T));
        }

        private int ChooseRandomHeight(int headHeight)
        {
            int height = 1;
            Random rand = new Random();
            while (rand.Next(0, 2) == 0 && height <= headHeight + 1)
            {
                height++;
            }
            return height;
        }

        public bool Contains(T value)
        {
            Node<T> current = Head;
            while (current != null)
            {
                while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
                {
                    current = current.Next;
                }
                if (current.Next != null && current.Next.Value.CompareTo(value) == 0)
                {
                    return true;
                }
                current = current.Down;
            }
            return false;
        }

        public void Insert(T value)
        {
            Stack<Node<T>> path = GetPath(value);
            int nodeHeight = ChooseRandomHeight(Head.Height);
            Node<T>? downNode = null;
            for (int i = 0; i < nodeHeight; i++)
            {
                if (i >= Head.Height)
                {
                    Node<T> newHead = new Node<T>(default(T), Head);
                    Head = newHead;
                }
                Node<T> prevNode = path.Count > 0 ? path.Pop() : Head;
                Node<T> newNode = downNode != null ? new Node<T>(value, downNode) : new Node<T>(value);
                newNode.Next = prevNode.Next;
                prevNode.Next = newNode;
                downNode = newNode;
            }
            Count++;
        }

        public bool Remove(T value)
        {
            Stack<Node<T>> path = GetPath(value);
            bool found = false;
            while (path.Count > 0)
            {
                Node<T> current = path.Pop();
                if (current.Next != null && current.Next.Value.CompareTo(value) == 0)
                {
                    found = true;
                    current.Next = current.Next.Next;
                }
            }
            if (found)
            {
                Count--;
                return true;
            }
            return false;
        }

        private Stack<Node<T>> GetPath(T value)
        {
            Stack<Node<T>> path = new Stack<Node<T>>();
            Node<T> current = Head;
            while (current != null)
            {
                while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
                {
                    current = current.Next;
                }
                path.Push(current);
                current = current.Down;
            }
            return path;
        }

        public void Add(T item)
        {
            Insert(item);
        }

        public void Clear()
        {
            Head = new Node<T>(default(T));
            Count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            T[] temp = this.ToArray();
            Array.Copy(temp, 0, array, arrayIndex, temp.Length);
        }

        bool ICollection<T>.Remove(T item)
        {
            return Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current.Down != null)
            {
                current = current.Down;
            }
            while (current.Next != null)
            {
                yield return current.Next.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
