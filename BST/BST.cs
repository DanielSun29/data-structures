using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class BST<T> where T : IComparable<T> //Where T is comparable
    {
        public int count = 0;

        public Node<T> root;

        public BST()
        {
        }

        public BST(T rootValue)
        {
            root = new Node<T>(rootValue);
            count = 1;
        }



        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (count == 0)
            {
                root = new Node<T>(value);
                count++;
                return;
            }
            
            Node<T> curr = root;
            while (true)
            {
                if (value.CompareTo(curr.Value) == 0 && curr != root)
                {
                    throw new DuplicateKeyException("Inserted Duplicate");
                }

                if (value.CompareTo(curr.Value) < 0)
                {
                    if (curr.Left == null)
                    {
                        curr.Left = new Node<T>(value);
                        break;
                    }
                    else
                    {
                        curr = curr.Left;
                    }
                }
                else if (value.CompareTo(curr.Value) > 0)
                {
                    if (curr.Right == null)
                    {
                        curr.Right = new Node<T>(value);
                        break;
                    }
                    else
                    {
                        curr = curr.Right;
                    }
                }
            }
            count++;
        }


        public Node<T> Search(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (count == 0)
            {
                throw new NullReferenceException("Tree is empty");
            }

            Node<T> curr = root;
            while (curr != null)
            {
                if (value.CompareTo(curr.Value) == 0)
                {
                    return curr;
                }

                if (value.CompareTo(curr.Value) < 0)
                {
                    curr = curr.Left;
                }
                else if (value.CompareTo(curr.Value) > 0)
                {
                    curr = curr.Right;
                }
            }
            return null;
        }

        public bool Contains(T value)
        {
            return Search(value) != null;
        }

        public T Minimum(Node<T> nodeToGetMinOf)
        {
            if (nodeToGetMinOf == null)
            {
                throw new ArgumentNullException(nameof(nodeToGetMinOf));
            }
            if (nodeToGetMinOf.Value == null)
            {
                throw new ArgumentNullException(nameof(nodeToGetMinOf) + ".Value");
            }

            Node<T> curr = nodeToGetMinOf;
            while (curr.Left != null)
            {
                curr = curr.Left;
            }
            return curr.Value;
        }

        public T Maximum(Node<T> nodeToGetMaxOf)
        {
            if (nodeToGetMaxOf == null)
            {
                throw new ArgumentNullException(nameof(nodeToGetMaxOf));
            }
            if (nodeToGetMaxOf.Value == null)
            {
                throw new ArgumentNullException(nameof(nodeToGetMaxOf) + ".Value");
            }

            Node<T> curr = nodeToGetMaxOf;
            while (curr.Right != null)
            {
                curr = curr.Right;
            }
            return curr.Value;
        }

        public T[] LevelOrder()
        {
            if (root == null)
            {
                throw new NullReferenceException("tree is null");
            }
            Queue<Node<T>> movement = new Queue<Node<T>>();
            Queue<T> output = new Queue<T>();
            Node<T> curr = root;
            movement.Enqueue(curr);
            while (movement.Count > 0)
            {
                curr = movement.Dequeue();
                output.Enqueue(curr.Value);
                if (curr.Left != null)
                {
                    movement.Enqueue(curr.Left);
                }
                if (curr.Right != null)
                {
                    movement.Enqueue(curr.Right);
                }
            }
            return output.ToArray();
        }//Returns node values in Level-Order

        public T[] PreOrder()
        {
            if (root == null)
            {
                throw new NullReferenceException("tree is null");
            }
            Stack<Node<T>> movement = new Stack<Node<T>>();
            Queue<T> output = new Queue<T>();
            Node<T> curr = root;
            movement.Push(curr);
            while (movement.Count > 0)
            {
                curr = movement.Pop();
                output.Enqueue(curr.Value);
                if (curr.Right != null)
                {
                    movement.Push(curr.Right);
                }
                if (curr.Left != null)
                {
                    movement.Push(curr.Left);
                }
            }
            return output.ToArray();
        }//Returns node values in Pre-Order

        public T[] PostOrder()
        {
            if (root == null)
            {
                throw new NullReferenceException("tree is null");
            }
            Stack<Node<T>> movement = new Stack<Node<T>>();
            Stack<T> output = new Stack<T>();
            Node<T> curr = root;
            movement.Push(curr);
            while (movement.Count > 0)
            {
                curr = movement.Pop();
                output.Push(curr.Value);
                if (curr.Left != null)
                {
                    movement.Push(curr.Left);
                }
                if (curr.Right != null)
                {
                    movement.Push(curr.Right);
                }
            }
            return output.ToArray();
        }//Returns node values in Post-Order

        public T[] InOrder()
        {
            if (root == null)
            {
                throw new NullReferenceException("tree is null");
            }
            Stack<Node<T>> movement = new Stack<Node<T>>();
            Queue<T> output = new Queue<T>();
            Node<T> curr = root;
            while (count != output.Count)
            {
                if (curr != null)
                {
                    movement.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = movement.Pop();
                    output.Enqueue(curr.Value);
                    curr = curr.Right;
                }
            }
            return output.ToArray();
        }//Returns node values in In-Order

        public bool Remove(T value)
        {
            if (value == null) throw new NullReferenceException("value to remove is null");
            if (root == null) return false;
            Node<T> curr = root;

            if (root.Value.Equals(value))
            {
                root = Remove(root);
            }

            while (true)
            {
                if (value.CompareTo(curr.Value) < 0)
                {
                    curr = curr.Left;
                }
                else if (value.CompareTo(curr.Value) > 0)
                {
                    curr = curr.Right;
                }
                else if (curr.Value.Equals(value))
                {
                    curr = Remove(curr);
                    return true;
                }
                else if (curr == null)
                {
                    return false;
                }
            }
        }

        private Node<T> Remove(Node<T> nodeToRemove)
        {
            if (nodeToRemove == null) throw new NullReferenceException("Node to Remove is null");

            count--;

            if (nodeToRemove.Left == null) return nodeToRemove.Right;
            if (nodeToRemove.Right == null) return nodeToRemove.Left;

            Node<T> largestSmallerNode = Search(Maximum(nodeToRemove.Left));
            nodeToRemove.Value = largestSmallerNode.Value;
            largestSmallerNode = largestSmallerNode.Left;
            return nodeToRemove;
        }
    }

    public class DuplicateKeyException(string? message) : Exception(message);
}
