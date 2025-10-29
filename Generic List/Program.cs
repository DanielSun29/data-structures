using System.ComponentModel.Design;

namespace Generic_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            List<List<int>> list1 = new List<List<int>>();
            //IEnumerable
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            //IEnumerable
            while (true)
            {
                Console.WriteLine("Press 1 to add to the list, 2 to Remove a certain value, 3 to view your list");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    Console.WriteLine("Adding item:");
                    bool parse = int.TryParse(Console.ReadLine(), out int addInput);
                    list.Add(addInput);
                }
                else if (userChoice == "2")
                {
                    Console.WriteLine("Removing item:");
                    bool parse = int.TryParse(Console.ReadLine(), out int removeInput);
                    list.Remove(removeInput);
                }
                else if (userChoice == "3")
                {
                    Console.WriteLine();
                    list.View();
                }
                else
                {
                    Console.WriteLine("Incorrect Input");
                }
            }
        }
    }
}
