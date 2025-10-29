using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Doubly_Linked_List
{
    public class DoublyLinked<T>
    {
        public int Count { get; private set; }

        public Node<T> Head { get; private set; }

        public void AddFirst(T value)
        {
            if (Head == null)
            {
                var temp = new Node<T>(value, null, null);
                Head = temp;
                Head.Previous = Head;
                Head.Next = Head;

            }
            else
            {
                Node<T> temp = Head;
                Head = new Node<T>(value, temp, temp.Previous);
                temp.Previous.Next = Head;
                temp.Previous = Head;
            }
            Count++;
        }//add a new head at the beginning of the list

        public void AddBefore(Node<T> node, T value)
        {
            if (node == Head)
            {
                AddFirst(value);
            }
            else if (Head == null)
            {
                throw new NullReferenceException("Head is null");
            }
            else if (node == null || value == null)
            {
                throw new NullReferenceException("Input is null");
            }
            else
            {
                Node<T> temp = new Node<T>(value, node, node.Previous);
                node.Previous.Next = temp;
                node.Previous = temp;
            }
            Count++;
        }//add a new node before any specified (and extant) node


        public void AddLast(T value)
        {
            if (Head == null)
            {
                AddFirst(value);
            }
            else
            {
                Node<T> temp = new Node<T>(value, Head, Head.Previous);
                Head.Previous.Next = temp;
                Head.Previous = temp;
            }
            Count++;
        }//add a new tail at the end of the list

        public void AddAfter(Node<T> node, T value)
        {
            if (node == Head.Previous)
            {
                AddLast(value);
            }
            else if (Head == null)
            {
                throw new NullReferenceException("Head is null");
            }
            else if (node == null || value == null)
            {
                throw new NullReferenceException("Input is null");
            }
            else
            {
                Node<T> temp = new Node<T>(value, node.Next, node);
                node.Next.Previous = temp;
                node.Next = temp;
            }
            Count++;
        }//add a new node after any specified (and extant) node

        public bool RemoveFirst()
        {
            if (Head == null)
            {
                return false;
            }
            Head.Previous.Next = Head.Next;
            Head.Next.Previous = Head.Previous;
            Head = Head.Next;
            Count--;
            return true;
        }//remove the first node

        public bool RemoveLast()
        {
            if (Head == null)
            {
                return false;
            }
            Head.Previous.Previous.Next = Head;
            Head.Previous = Head.Previous.Previous;
            Count--;
            return true;
        }//remove the last node 

        public bool Remove(T value)
        {
            if (Head == null)
            {
                return false;
            }
            else if (Head.Value.Equals(value))
            {
                RemoveFirst();
                Count--;
                return true;
            }
            else if (Head.Previous.Value.Equals(value))
            {
                RemoveLast();
                Count--;
                return true;
            }

            Node<T> curr = Head;
            while (curr.Next != Head)
            {
                if (curr.Value.Equals(value))
                {
                    curr.Previous.Next = curr.Next;
                    curr.Next.Previous = curr.Previous;
                    Count--;
                    return true;
                }
                curr = curr.Next;
            }
            return false;
        }//find and remove a node containing the given value

        public void Clear()
        {
            Head = null;
            Count = 0;
        }//delete every node in the linked list

        public Node<T> Search(T value)//search for a given value and return a node that contains it, return null if none is found
        {
            if (Head == null)
            {
                return null;
            }

            if (Head.Previous.Value.Equals(value))
            {
                return Head.Previous;
            }

            Node<T> curr = Head;
            while (curr.Next != Head)
            {
                if (curr.Value.Equals(value))
                {
                    return curr;
                }
                curr = curr.Next;
            }
            return null;
        }
        public bool Contains(T value)
        {
            if (Head == null)
            {
                return false;
            }

            if (Head.Previous.Value.Equals(value))
            {
                return true;
            }

            Node<T> curr = Head;
            while (curr.Next != Head)
            {
                if (curr.Value.Equals(value))
                {
                    return true;
                }
                curr = curr.Next;
            }
            return false;
        }//search for a given value and return if you found it.

        public bool Contains(Node<T> value)
        {
            if (Head == null)
            {
                return false;
            }

            if (Head.Previous.Equals(value))
            {
                return true;
            }

            Node<T> curr = Head;
            while (curr.Next != Head)
            {
                if (curr == value)
                {
                    return true;
                }
                curr = curr.Next;
            }
            return false;
        }//Check if the given node belongs to this list in O(1) time
    }
}
