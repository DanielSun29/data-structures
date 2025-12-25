using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SubstitutionCipher
{
    internal class Program
    {
        const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Insert key:");
                string shuffledAlpha = GenerateShuffledAlpha(Console.ReadLine());
                Console.WriteLine(shuffledAlpha);
                Console.WriteLine("Insert message:");
                string input = Console.ReadLine();
                input = input.ToUpper();
                string cipherText = Encrypt(input, shuffledAlpha);
                Console.WriteLine(cipherText);
                Console.WriteLine("Decrypted: " + Decrypt(cipherText, shuffledAlpha));
            }
        }

        static public int KeyToSeed(string key)
        {
            int output = key.GetHashCode(); // Get Hash Code is 1 of the 4 basic functions to every object
            return output;
        }

        static string GenerateShuffledAlpha(string key)
        {
            Random rng = new Random(KeyToSeed(key));
            char[] shuffledAlpha = ALPHABET.ToCharArray();
            rng.Shuffle(shuffledAlpha);
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < shuffledAlpha.Length; i++)
            {
                output.Append(shuffledAlpha[i]);
            }
            return output.ToString();
        }

        static string Encrypt(string input, string shuffledAlpha)
        {
            input = input.ToUpper();
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (31 < input[i] && input[i] < 65) // includes the punctuation and spaces
                {
                    output.Append(input[i]);
                    continue;
                }

                int letterNumber = (int)input[i] - 65;
                output.Append(shuffledAlpha[letterNumber]);
            }
            return output.ToString();
        }

        static string Decrypt(string cipherText, string key)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (31 < cipherText[i] && cipherText[i] < 65)
                {
                    output.Append(cipherText[i]);
                    continue;
                }

                int curr = 0;

                while (key[curr] != cipherText[i])
                {
                    curr++;
                }
                char originalLetter = (char)(curr + 65);
                output.Append(originalLetter);
            }
            return output.ToString();
        }
    }
}
