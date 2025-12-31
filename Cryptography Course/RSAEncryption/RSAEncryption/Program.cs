using System.Security.Cryptography;
using System;
using System.Text;

namespace RSAEncryption
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Below is encrypt, above is RandomNumberGenerator demo

            Console.WriteLine("Text to encrypt:");
            string? plainText = Console.ReadLine();
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            RSA rsa = RSA.Create(keySizeInBits: 2048);
            byte[] cipherTextBytes = rsa.Encrypt(plainTextBytes, RSAEncryptionPadding.OaepSHA256);

            Console.WriteLine("Create new keys?");
            string publicKey = "";
            string privateKey = "";
            if (Console.ReadLine() == "y")
            {
                publicKey = rsa.ToXmlString(includePrivateParameters: false);
                privateKey = rsa.ToXmlString(includePrivateParameters: true);
            }
            else
            {
                File.ReadAllText("key.xml");
            }

            byte[] encryptedBytes = rsa.Encrypt(plainTextBytes, RSAEncryptionPadding.OaepSHA256);

            //rsa.Dispose(); // This destroys the object
            //rsa = RSA.Create(keySizeInBits: 2048);
            //If I have these lines which reset the rsa the decryption wont work
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256);
            string decrypted = Encoding.UTF8.GetString(decryptedBytes);

            string cipherText = Encoding.UTF8.GetString(cipherTextBytes);
            //string cipherText = Convert.ToBase64String(encryptedBytes);

            Console.WriteLine($"Ciphertext:{cipherText}");

            Console.WriteLine($"Ciphertext:{decrypted}");

            //File.WriteAllText();
            //File.ReadAllText();

            Console.WriteLine("Save private & public key?(press y for yes)");
            bool save = Console.ReadLine() == "y";
            if (save)
            {
                File.WriteAllText("key.xml", publicKey);
                File.WriteAllText("key.xml", privateKey);
            }
        }

        static void Keys(byte[] plainTextBytes)
        {
            RSA rsa = RSA.Create(keySizeInBits: 2048);

            string publicKey = rsa.ToXmlString(includePrivateParameters: false);
            string privateKey = rsa.ToXmlString(includePrivateParameters: true);

            byte[] encryptedBytes = rsa.Encrypt(plainTextBytes, RSAEncryptionPadding.OaepSHA256);
            string cipherText = Convert.ToBase64String(encryptedBytes);

            //rsa.Dispose();
            //rsa = RSA.Create(keySizeInBits: 2048);
            //If I have these lines which reset the rsa the decryption wont work
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256);
            string decrypted = Encoding.UTF8.GetString(decryptedBytes);
        }

        //Random stuff demo

        //byte[] values = { 1, 2, 3, 4 };

        //var rng = RandomNumberGenerator.Create();
        //rng.GetBytes(values);
    }
}
