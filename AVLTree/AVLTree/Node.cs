using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class Node<T> where T : IComparable<T>
    {
        public Node<T> Left { get; internal set; }
        public Node<T> Right { get; internal set; }

        public T Value { get; internal set; }

        internal int Height { get; set; }
        internal int Balance
        {
            get
            {
                UpdateHeight();
                if (Left == null && Right == null) return 0;
                return (Right != null ? Right.Height : 0) - (Left != null ? Left.Height : 0);
                /*
                 return (Right?.Height ?? 0) - (Left?.Height ?? 0);
                 these 2 are equal, look at notes in base converter
                 */
            }
        } //Implement this!

        public Node(T value)
        {
            Left = null;
            Right = null;
            Value = value;
            Height = 1;
        }//Implement this!

        void UpdateHeight()
        {
            if (Left == null && Right == null)
            {
                Height = 1;
            }
            else if (Left == null && Right != null)
            {
                Height = Right.Height + 1;
            }
            else if (Right == null && Left != null)
            {
                Height = Left.Height + 1;
            }
            else
            {
                if (Left.Height >= Right.Height)
                {
                    Height = Left.Height + 1;
                }
                else
                {
                    Height = Right.Height + 1;
                }
            }
        }//--Optional, for your convenience-- implement this!


        // Rotations: return the new root after rotation

        internal Node<T> RightRotate()
        {
            Node<T> newRoot = Left;
            Node<T> temp = newRoot.Right;
            newRoot.Right = this;
            Left = temp;
            UpdateHeight();
            newRoot.UpdateHeight();
            return newRoot;
        }

        internal Node<T> LeftRotate()
        {
            Node<T> newRoot = Right;
            Node<T> temp = newRoot.Left;
            newRoot.Left = this;
            Right = temp;
            UpdateHeight();
            newRoot.UpdateHeight();
            return newRoot;
        }


    }

}
