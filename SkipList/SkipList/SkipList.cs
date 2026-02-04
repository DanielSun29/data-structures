using System;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    public class SkipList<T> where T : IComparable<T>
    {
        public Node<T> Head { get; set; }

        public int Count { get; set; }

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

        public void Insert(T value)
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
                Node<T> newNode = new Node<T>(value, downNode);
                newNode.Next = prevNode.Next;
                prevNode.Next = newNode;
                downNode = newNode;
            }
            Count++;
        }
    }
}
