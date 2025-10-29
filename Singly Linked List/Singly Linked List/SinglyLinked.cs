using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singly_Linked_List
{
    internal class SinglyLinked<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }

        //Constructors & Functions

        public void AddFirst(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value);
                Tail = Head;
            }
            else
            {
                Node<T> temp = Head;
                Head = new Node<T>(value, temp);
            }
            Count++;
        } //add a new head at the beginning of the list

        public void AddLast(T value)
        {
            if (Tail == null)
            {
                Head = new Node<T>(value);
                Tail = Head;
            }
            else
            {
                Tail.Next = new Node<T>(value);
                Tail = Tail.Next;

            }
            Count++;
        } //add a new tail at the end of the list

        public void AddBefore(Node<T> node, T value)
        {
            if (node == Head)
            {
                AddFirst(value);
                Count++;
                return;
            }
            else if (node == null)
            {
                throw new NullReferenceException("Node is null");
            }
            else if (Head == null)
            {
                throw new NullReferenceException("Head is null");
            }
            else
            {
                Node<T> currentNode = Head;
                while (currentNode != null && currentNode.Next != node)
                {
                    currentNode = currentNode.Next;
                }

                if (currentNode == null)
                {
                    throw new NullReferenceException("Input node don't exist");
                }
                else
                {
                    Node<T> temp = new Node<T>(value);
                    currentNode.Next = temp;
                    temp.Next = node;
                }
            }
            Count++;
        } //add a new node before any specified (and extant) node


        public void AddAfter(Node<T> node, T value)
        {
            if (node == Tail)
            {
                AddLast(value);
            }
            else if (node == null)
            {
                throw new NullReferenceException("Input is null");
            }
            else if (Head == null)
            {
                throw new NullReferenceException("Head is null");
            }
            else
            {
                Node<T> currentNode = Head;
                while (currentNode != null && currentNode != node)
                {
                    currentNode = currentNode.Next;
                }

                if (currentNode == null)
                {
                    throw new NullReferenceException("Input node don't exist");
                }
                else
                {
                    Node<T> addedNode = new Node<T>(value, currentNode.Next);
                    currentNode.Next = addedNode;
                }
            }
            Count++;
        }//add a new node after any specified (and extant) node


        public bool RemoveFirst()
        {
            if (Head == null)
            {
                return false;
            }
            else
            {
                Head = Head.Next;
                Count--;
                return true;
            }
        }//remove the first node

        public bool RemoveLast()
        {
            if (Head == null)
            {
                throw new NullReferenceException("Head is null");
            }
            else
            {
                Node<T> curr = Head;
                while (curr.Next != Tail)
                {
                    curr = curr.Next;
                }
                Tail = curr;
                Count--;
                return true;
            }
        }//remove the last node 


        public bool Remove(T value)
        {
            if (Head == null)
            {
                throw new NullReferenceException("Head is null");
            }
            else if (value == null)
            {
                throw new NullReferenceException("Input is null");
            }
            else if (Head.Value.Equals(value))
            {
                RemoveFirst();
                return true;
            }
            else if (Tail.Value.Equals(value))
            {
                RemoveLast();
                return true;
            }
            else
            {
                Node<T> curr = Head;
                while (curr.Next != Tail)
                {
                    if (curr.Next.Value.Equals(value))
                    {
                        curr.Next = curr.Next.Next;
                        Count--;
                        return true;
                    }
                    curr = curr.Next;
                }
                return false;
            }
        }//find and remove a node containing the given value

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }//delete every node in the linked list

        public Node<T> Search(T value)
        {
            if (Head == null)
            {
                return null;
            }
            else if (value == null)
            {
                return null;
            }
            else
            {
                Node<T> curr = Head;
                while (curr.Next != Tail)
                {
                    if (curr.Value.Equals(value))
                    {
                        return curr;
                    }
                    curr = curr.Next;
                }
                return null;
            }
        }//search for a given value and return a node that contains it, return null if none is found

        public bool Contains(T value)
        {
            return Search(value) != null;
        }//search for a given value and return if you found it.

        public bool Contains(Node<T> node)
        {
            if (Head == null)
            {
                return false;
            }
            else if (node == null)
            {
                return false;
            }
            else
            {
                Node<T> curr = Head;
                while (curr != null)
                {
                    if (curr.Equals(node))
                    {
                        return true;
                    }
                    curr = curr.Next;
                }
                return false;
            }
        }//search for a given node and return if you found it.
    }
}
