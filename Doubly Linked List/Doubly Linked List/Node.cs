using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_Linked_List
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; } // the only change

        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
            Previous = null;
        }

        public Node(T value, Node<T> next, Node<T> previous)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }
}
