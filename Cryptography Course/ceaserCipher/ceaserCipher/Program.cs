using System.Text;

namespace caesarCipher
{
    class LetterHolder : IComparable<LetterHolder>
    {
        public char Letter { get; set; }
        public int Count { get; set; }

        public int CompareTo(LetterHolder other)
            => Count.CompareTo(other.Count); // Basically says when being used in CompareTo run the thing after the arrow key
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input;
                StringBuilder ciphertext = new StringBuilder();
                Console.WriteLine("message to encrypt: ");
                input = Console.ReadLine();
                input = input.ToUpper();
                int shiftAmount = Random.Shared.Next(1, 26);
                foreach (char letter in input)
                {
                    if (32 <= letter && letter <= 47)
                    {
                        ciphertext.Append(letter);
                    }
                    else
                    {
                        int letterNumber = letter - 65;
                        letterNumber += shiftAmount;
                        ciphertext.Append((char)((letterNumber % 26) + 65));
                    }

                }

                Console.WriteLine(shiftAmount);
                Console.WriteLine("Encrypted message: " + ciphertext.ToString());

                Console.WriteLine("");

                bool wordSearch = false;
                string wordToSearch = "";
                while (wordSearch == false)
                {
                    Console.WriteLine("Engage word search?(y/n)");
                    string userInput = Console.ReadLine();
                    if (userInput == "y")
                    {
                        wordSearch = true;
                        Console.WriteLine("What word do you want to search for?");
                        wordToSearch = Console.ReadLine().ToUpper();
                    }
                    else if (userInput == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }

                Decrypt(ciphertext.ToString(), wordSearch, wordToSearch);
            }
        }

        public static LetterHolder[] frequencyCheck(string input)
        {
            LetterHolder[] frequency = new LetterHolder[26];
            for (int i = 0; i < 26; i++)
            {
                frequency[i] = new LetterHolder();
                frequency[i].Letter = (char)(i + 'A');
            }
            input = input.ToUpper();
            foreach (char letter in input)
            {
                if (letter > 'Z' || letter < 'A')
                {
                    continue;
                }
                frequency[letter - 65].Count++;
            }
            return frequency;
        }

        public static int WordSearch(string input, string goalWord)
        {
            int count = 0;
            string[] words = input.Split(' ');
            foreach (string word in words)
            {
                if (word == goalWord)
                {
                    count++;
                }
            }
            return count;
        }

        public static void Decrypt(string input, bool wordSearch, string wordToSearch)
        {
            for (int i = 1; i < 26; i++)
            {
                StringBuilder result = new StringBuilder();
                input = input.ToUpper();
                int shiftAmount = i;
                foreach (char letter in input)
                {
                    if (32 <= letter && letter <= 47)
                    {
                        result.Append(letter);
                    }
                    else
                    {
                        int letterNumber = letter - 65;
                        letterNumber += shiftAmount;
                        result.Append((char)((letterNumber % 26) + 65));
                    }

                }

                LetterHolder[] frequency = frequencyCheck(result.ToString());
                LetterHolder[] sortedOrder = new LetterHolder[frequency.Length];
                Array.Copy(frequency, sortedOrder, frequency.Length);
                Array.Sort(sortedOrder);

                if (frequency['E' - 65].CompareTo(sortedOrder[sortedOrder.Length - 4]) >= 0 || frequency['T' - 65].CompareTo(sortedOrder[sortedOrder.Length - 4]) >= 0)
                {
                    if (wordSearch == true)
                    {
                        if (WordSearch(input, wordToSearch) > 0)
                        {
                            Console.WriteLine("Decrypted message: " + result.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Decrypted message: " + result.ToString());
                    }
                }
            }
        }
    }
}
