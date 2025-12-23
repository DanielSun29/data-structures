using System.Text;

namespace OneTimePadVisual
{
    public partial class Form1 : Form
    {
        private string input = "";
        private string key = "";
        private byte[] decrypted;
        byte[] encrypted;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void Encrypt_Button_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;
            key = generateKey(input.Length);
            keylabel.Text = key;
            encrypted = Encrypt(input, key);
            encryptedlabel.Text = "";
            foreach (byte b in encrypted) { encryptedlabel.Text += ((char)b + " "); }
        }

        private void encryptedlabel_Click(object sender, EventArgs e)
        {

        }

        private void decryptbutton_Click(object sender, EventArgs e)
        {
            decrypted = Decrypt(encrypted, key);
            decryptlabel.Text = "";
            foreach (byte b in decrypted) { decryptlabel.Text += ((char)b + " "); }
        }

        private void decryptlabel_Click(object sender, EventArgs e)
        {

        }
    }
}
