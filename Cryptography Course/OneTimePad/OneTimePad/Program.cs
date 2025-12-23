using System.Diagnostics.Metrics;
using System.Text;

namespace OneTimePad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Message:");
            string message = Console.ReadLine().ToUpper();
            string key = generateKey(message.Length);
            Console.WriteLine("Key: " + key);
            byte[] encyrpted = Encrypt(message, key);
            Console.WriteLine("encrypted: ");
            foreach (byte b in encyrpted) { Console.Write((char)b + " "); }
            byte[] decrypted = Decrypt(encyrpted, key);
            Console.WriteLine("Decrypted: ");
            foreach (byte b in decrypted) { Console.Write((char)b); }

        }

        public static string generateKey(int length)
        {
            StringBuilder key = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                key.Append((char)Random.Shared.Next(65, 91));
            }
            return key.ToString();
        }

        // a ^ key = x
        // x ^ key = a

        public static byte[] Encrypt(string message, string key)
        {
            byte[] output = new byte[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                output[i] = (byte)(message[i] ^ key[i]);
            }
            return output;
        }

        public static byte[] Decrypt(byte[] message, string key)
        {
            byte[] output = new byte[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                output[i] = (byte)(message[i] ^ key[i]);
            }
            return output;
        }
    }
}
