using System;

namespace Singly_Linked_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SinglyLinked<int> list = new SinglyLinked<int>();
            list.AddFirst(1);
            list.AddLast(3);
            list.AddLast(5);
            list.AddBefore(list.Tail, 4);
            list.AddAfter(list.Head, 2);

            Console.WriteLine("List:");
            Node<int> curr = list.Head;
            while (curr != list.Tail)
            {
                Console.Write($"{curr.Value},");
                curr = curr.Next;
            }
            Console.WriteLine($"{list.Tail.Value}");


            //Write remove here:

            Console.WriteLine("\nAfter Removal");
            list.RemoveFirst();

            curr = list.Head;
            if (list.Head != null)
            {
                while (curr != list.Tail)
                {
                    Console.Write($"{curr.Value},");
                    curr = curr.Next;
                }
                Console.Write($"{list.Tail.Value}");
            }
            else
            {
                Console.WriteLine("List is null");
            }


            //Write search here
            Console.WriteLine("\nSearch:");
            Node<int> searchResult = list.Search(2);
            if (searchResult != null)
            {
                Console.WriteLine($"\nSearch result: {searchResult.Value}");
            }
            else
            {
                Console.WriteLine("\nNo result");
            }


            //Write contains here
            Console.WriteLine("\nContains:");
            Node<int> node = new Node<int>(3);
            if (list.Contains(node))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}