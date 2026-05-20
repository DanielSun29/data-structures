using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    public class RBTree<T> where T : IComparable<T>
    {
        public Node<T> Root;


        public RBTree()
        {
            Root = null;
        }

        public Node<T> Search(T value)
        {
            Node<T> current = Root;
            while (current != null)
            {
                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else if (value.CompareTo(current.Value) > 0)
                {
                    current = current.Right;
                }
                else if (value.CompareTo(current.Value) == 0)
                {
                    return current;
                }
            }
            return null;
        }

        public bool Contains(T value)
        {
            return Search(value) != null;
        }

        public void Insert(T value)
        {
            Root = Insert(Root, value);
            Root.IsRed = false;
        }

        private Node<T> Insert(Node<T> node, T value)
        {
            if (node == null)
            {
                return new Node<T>(value) { IsRed = true };
            }

            if (isRed(node.Left) && isRed(node.Right))
            {
                FlipColor(node);
            }

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(node.Right, value);
            }

            node = FixUp(node);

            return node;
        }

        public void Remove(T value)
        {
            if (Root == null) return;
            Root = Delete(Root, value);
            if (Root != null)
            {
                Root.IsRed = false;
            }
        }

        private Node<T> Delete(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left != null)
                {
                    if (!isRed(node.Left) && !isRed(node.Left.Left))
                    {
                        node = MoveRedLeft(node);
                    }
                    node.Left = Delete(node.Left, value);
                }
            }
            else
            {
                if (isRed(node.Left))
                {
                    node = RightRotate(node);
                }
                if (value.CompareTo(node.Value) == 0 && node.Right == null)
                {
                    return null;
                }
                if (node.Right != null)
                {
                    if (!isRed(node.Right) && !isRed(node.Right.Left))
                    {
                        node = MoveRedRight(node);
                    }

                    if (value.CompareTo(node.Value) == 0)
                    {
                        DeleteNode(node);
                    }
                    else
                    {
                        node.Right = Delete(node.Right, value);
                    }
                }
            }


            node = FixUp(node);
            return node;
        }

        private void DeleteNode(Node<T> node)
        {
            if (node.Right == null)
            {
                return;
            }

            Node<T> min = node.Right;
            while (min.Left != null)
            {
                min = min.Left;
            }

            node.Value = min.Value;
            node.Right = Delete(node.Right, min.Value);
        }

        public List<T> Recursion()
        {
            return InOrderRec(Root);
        }
        public List<T> InOrderRec(Node<T> curr)
        {
            List<T> list = new List<T>();
            if (curr == null)
            {
                return list;
            }
            list.AddRange(InOrderRec(curr.Left));
            list.Add(curr.Value);
            list.AddRange(InOrderRec(curr.Right));
            return list;
        }

        private Node<T> FixUp(Node<T> node)
        {
            if (isRed(node.Right) && !isRed(node.Left))
            {
                node = LeftRotate(node);
            }
            if (isRed(node.Left) && isRed(node.Left.Left))
            {
                node = RightRotate(node);
            }
            return node;
        }

        private Node<T> MoveRedRight(Node<T> node)
        {
            FlipColor(node);
            if (node.Left is not null)
            {
                if (isRed(node.Left.Left))
                {
                    node = RightRotate(node);
                    FlipColor(node);
                }
            }
            return node;
        }

        private Node<T> MoveRedLeft(Node<T> node)
        {
            FlipColor(node);
            if (isRed(node.Right.Left))
            {
                node.Right = RightRotate(node.Right);
                node = LeftRotate(node);
                FlipColor(node);
            }
            return node;
        }

        private Node<T> LeftRotate(Node<T> node)
        {
            var newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;
            node.IsRed = true;
            newRoot.IsRed = false;
            return newRoot;
        }

        private Node<T> RightRotate(Node<T> node)
        {
            var newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;
            node.IsRed = true;
            newRoot.IsRed = false;
            return newRoot;
        }

        private void FlipColor(Node<T> node)
        {
            node.IsRed = !node.IsRed;
            if (node.Left != null)
                node.Left.IsRed = !node.Left.IsRed;
            if (node.Right != null)
                node.Right.IsRed = !node.Right.IsRed;
        }

        public bool isRed(Node<T> node)
        {
            return node != null && node.IsRed;
        }
    }
}