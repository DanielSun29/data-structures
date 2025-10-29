using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_List
{
    internal class List<T>:IEnumerable<T>//This means when T is created it is Enumerable
    {

        private T[] items;

        private int nextIndex = 0;

        public int Count//Making Count not to be able to change out side of the class
        {
            get { return nextIndex; }
        }

        public List(int capacity = 5)
        {
            items = new T[capacity];
        }

        public void Add(T item)
        {
            if(nextIndex >= items.Length)
            {
                T[] temp = new T[items.Length*2];
                for (int i = 0; i < items.Length; i++)
                {
                    temp[i] = items[i];
                }
                items = temp;
                items[nextIndex] = item;
            }
            else
            {
                items[nextIndex] = item;
            }
            nextIndex++;
        }

        public bool Remove(T item)//Removes all the items called "item"
        {
            bool exist = false;
            for (int i = 0;i < items.Length;i++)
            {
                if (items[i].Equals(item))//CompareTo returns: 1 is list[i] > item; 0 is =; -1 is <              Equals returns boolean
                {
                    exist = true;
                    for(int j = i;j < items.Length-1;j++)
                    {
                        items[j] = items[j + 1];
                    }
                    nextIndex--;
                    i--;
                }
            }
            return exist;
        }

        public void View()
        {
            for (int i = 0;i < nextIndex;i++)
            {
                Console.WriteLine(items[i].ToString());
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < nextIndex;i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
