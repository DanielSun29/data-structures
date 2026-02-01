using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> root { get; set; }
        public int count;

        public Tree()
        {

        }

        private Node<T> Rotation(Node<T> curr)
        {
            if (curr.Balance < -1)
            {
                if (curr.Left != null)
                {
                    if (curr.Left.Balance > 0)
                    {
                        curr.Left = curr.Left.LeftRotate();
                    }
                }
                return curr.RightRotate();
            }
            if (curr.Balance > 1)
            {
                if (curr.Right != null)
                {
                    if (curr.Right.Balance < 0)
                    {
                        curr.Right = curr.Right.RightRotate();
                    }
                }
                return curr.LeftRotate();
            }
            return curr;
        }

        public void Insert(T value)
        {
            if (value == null)
            {
                throw new NullReferenceException("value is null");
            }
            root = InsertHelper(root, value);
            count++;
        }

        private Node<T> InsertHelper(Node<T> curr, T value)
        {
            if (curr == null)
            {
                return new Node<T>(value);
            }
            if (value.CompareTo(curr.Value) < 0)
            {
                var temp = InsertHelper(curr.Left, value);
                curr.Left = temp;
            }
            else if (value.CompareTo(curr.Value) > 0)
            {
                var temp = InsertHelper(curr.Right, value);
                curr.Right = temp;
            }
            if (value.CompareTo(curr.Value) == 0)
            {
                throw new DuplicateKeyException("Inserted Duplicate");
            }

            return Rotation(curr);
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

        public bool IsBalanced()
        {
            if (root == null)
            {
                return true;
                //throw new NullReferenceException("Tree is empty");
            }
            if (Math.Abs(root.Balance) > 1)
            {
                return false;
            }
            return true;
        }

        public bool Remove(T value)
        {
            if (value == null) throw new NullReferenceException("value to remove is null");
            if (root == null) throw new NullReferenceException("root is null");
            if (!Contains(value)) return false;
            root = RemoveHelper(root, value);
            count--;
            return true;
        }

        public Node<T> RemoveHelper(Node<T> curr, T value)
        {
            if (curr == null) return null;
            if (value.CompareTo(curr.Value) < 0)
            {
                var temp = RemoveHelper(curr.Left, value);
                curr.Left = temp;
            }
            else if (value.CompareTo(curr.Value) > 0)
            {
                var temp = RemoveHelper(curr.Right, value);
                curr.Right = temp;
            }
            else
            {
                // one child or no child
                if (curr.Left == null) return curr.Right;
                if (curr.Right == null) return curr.Left;

                // two children: (smaller largest value)
                Node<T> temp = curr.Left;
                while (temp.Right != null)
                {
                    temp = temp.Right;
                }
                // Copy the smaller largest value to this node
                curr.Value = temp.Value;
                // Delete the smaller largest node
                curr.Left = RemoveHelper(curr.Left, temp.Value);
            }
            return Rotation(curr);
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

        public class DuplicateKeyException(string? message) : Exception(message);
    }
}
