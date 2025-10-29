using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Doubly_Linked_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5] {1,2,3,4,5 };
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            int number = 2;
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddLast(arr[i]);
            }
            Node<int> temp = list.Search(number);
            Console.WriteLine($"{temp.Value}");
        }
    }
}
