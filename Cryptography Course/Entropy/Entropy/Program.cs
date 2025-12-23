using System.Text;

namespace Entropy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string compressed = Compress(Console.ReadLine());
            Console.WriteLine("Compressed: " + compressed);
            Console.WriteLine("Decompressed: " + Decompress(compressed));
        }

        static public string Compress(string input)
        {
            StringBuilder output = new StringBuilder();
            int count = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (i > 0 && input[i] == input[i - 1])
                {
                    count++;
                }
                else if (i == 0)
                {
                    output.Append(input[i]);
                }
                else
                {
                    output.Append(count);
                    count = 1;
                    output.Append(input[i]);
                }
            }
            output.Append(count);
            return output.ToString();
        }

        static public string Decompress(string input)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < input.Length; i += 2)
            {
                for (int j = 0; j < (int)input[i+1] - 48; j++)
                {
                    output.Append(input[i]);
                }
            }
            return output.ToString();
        }
    }
}
