using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class Node<T> where T: IComparable<T>
    {
        public Node<T>?/* ? makes it can be null without getting an error*/ Left { get; set; } //Instead of Next
        public Node<T>? Right { get; set; } //Instead of Previous

        public T Value { get; set; }
        public Node(T value)
        {
            Left = null;
            Right = null;
            Value = value;
        }
    }
}
