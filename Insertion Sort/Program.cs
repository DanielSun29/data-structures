using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Insertion_Sort
{
    internal class Program
    {
        public static void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while (j > 0 && arr[j-1] >= arr[j])
                {
                    int current = arr[j];
                    arr[j] = arr[j-1];
                    arr[j-1] = current;
                    j--;
                    foreach (int k in arr)
                    {
                        Console.Write(k);
                    }
                    Console.Write("\n");
                }
            }
        }

        static void Main(string[] args)
        {
            int[] data = { 5, 2, 1, 4, 3 };
            Sort(data);
            Console.WriteLine("\nResult:");
            foreach (int i in data)
            {
                Console.WriteLine(i);
            }
        }
    }
}
