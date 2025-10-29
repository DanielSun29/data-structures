using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singly_Linked_List
{
    internal class Node<T>
    {
        public T Value;
        public Node<T>? Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        } // Implement the constructors
        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
