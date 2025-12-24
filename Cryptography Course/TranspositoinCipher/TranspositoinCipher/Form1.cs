using System.Drawing.Printing;
using System.Text;

namespace TranspositoinCipher
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string input = "";
        private string key = "";
        private string key2 = "";
        private string decrypted;
        string encrypted;
        string doubleEncrypted;

        int labelCounters = 0;
        List<Label> labels = new List<Label>();

        public static string generateKey(int length)
        {
            StringBuilder key = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                key.Append((char)Random.Shared.Next(65, 91));
            }
            return key.ToString();
        }

        private static string Encrypt(string message, string key)
        {
            StringBuilder output = new StringBuilder();
            KeyHolder[] tempKey = new KeyHolder[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                tempKey[i] = new KeyHolder(key[i], i);
            }
            Array.Sort(tempKey);
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = tempKey[i].index; j < message.Length; j += key.Length)
                {
                    output.Append(message[j]);
                }
            }
            return output.ToString();
        }

        private static string Decrypt(string cipherText, string key)
        {

            int kL = key.Length;
            int tL = cipherText.Length;

            // Build Key array and sort
            KeyHolder[] tempKey = new KeyHolder[kL];
            for (int i = 0; i < kL; i++)
            {
                tempKey[i] = new KeyHolder(key[i], i);
            }

            Array.Sort(tempKey);

            int rows = (int)Math.Ceiling((float)tL / kL); // How many rows there are
            int shortCols = kL * rows - tL; // number of columns missing last row

            // Fill columns(from cipphertext)
            string[] columns = new string[kL];
            int curr = 0;

            for (int i = 0; i < kL; i++)
            {
                int colLength;

                if (tempKey[i].index >= kL - shortCols)
                {
                    colLength = rows - 1;// Short column
                }
                else
                {
                    colLength = rows;
                }
                columns[tempKey[i].index] = cipherText.Substring(curr, colLength);
                curr += colLength;
            }

            // Read message by row
            StringBuilder output = new StringBuilder();

            // Basically my old i & j method
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < kL; c++)
                {
                    if (r < columns[c].Length)
                    {
                        output.Append(columns[c][r]);
                    }
                }
            }

            return output.ToString();

            //// Old method
            //int columnMaxLength = (int)Math.Ceiling((double)cipherText.Length / key.Length);

            //StringBuilder output = new StringBuilder();
            //for (int i = 0; i < columnMaxLength; i++)
            //{
            //    for (int j = 0; j < key.Length; j++)
            //    {
            //        int indexToAppend = j * columnMaxLength + i;
            //        if (indexToAppend >= cipherText.Length) continue;
            //        output.Append(cipherText[indexToAppend]);
            //    }
            //}

            //return output.ToString();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            keyText.Clear();
            input = messageText.Text.Trim();
            if (input.Length > 30)
            {
                key = generateKey(Random.Shared.Next(3, (int)Math.Sqrt(input.Length)));
            }
            else
            {
                key = generateKey(Random.Shared.Next(3, (int)input.Length / 3));
            }
            keyText.Text = key;
            keyLengthLabel.Text = $"{keyText.Text.Length}";
        }

        private void generateButton2_Click(object sender, EventArgs e)
        {
            keyText2.Clear();
            if (input.Length > 30)
            {
                key2 = generateKey(Random.Shared.Next(3, (int)Math.Sqrt(input.Length)));
            }
            else
            {
                key2 = generateKey(Random.Shared.Next(3, (int)input.Length / 3));
            }
            keyText2.Text = key2;
            keyLengthLabel2.Text = $"{keyText.Text.Length}";
        }

        private void encryptButton_ButtonClick(object sender, EventArgs e)
        {
            key = keyText.Text.ToUpper();

            keyLengthLabel.Text = $"{keyText.Text.Length}";

            input = messageText.Text.Trim();

            encrypted = Encrypt(input, key);


            // Below is visualization

            ciphertextLengthLabel.Text = $"{encrypted.Length}";

            flowPanel.Controls.Clear();

            encryptedLabel.Text = encrypted;

            messageLengthLabel.Text = $"{messageText.Text.Length}";

            for (int i = 0; i < key.Length + input.Length; i++)
            {
                int usableWidth = flowPanel.Width - flowPanel.Padding.Left - flowPanel.Padding.Right;
                var label = new Label()
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = $"label {++labelCounters}",
                    Width = (usableWidth - key.Length * (Margin.Left + Margin.Right)) / key.Length - 1,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                if (i < key.Length)
                {
                    label.Text = key[i] + "";
                    label.BackColor = Color.Red;
                }
                else
                {
                    label.Text = input[i - key.Length] + "";
                }
                flowPanel.Controls.Add(label);
                labels.Add(label);
            }
        }

        private void encryptButton2_ButtonClick(object sender, EventArgs e)
        {
            key2 = keyText2.Text.ToUpper();

            keyLengthLabel2.Text = $"{keyText2.Text.Length}";

            doubleEncrypted = Encrypt(encrypted, key2);

            // Below is visualization

            flowPanel.Controls.Clear();

            encryptedLabel2.Text = doubleEncrypted;

            ciphertextLengthLabel.Text = $"{encrypted.Length}";

            for (int i = 0; i < key2.Length + encrypted.Length; i++)
            {
                int usableWidth = flowPanel.Width - flowPanel.Padding.Left - flowPanel.Padding.Right;
                var label = new Label()
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = $"label {++labelCounters}",
                    Width = (usableWidth - key2.Length * (Margin.Left + Margin.Right)) / key2.Length - 1,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                if (i < key.Length)
                {
                    label.Text = key2[i] + "";
                    label.BackColor = Color.Red;
                }
                else
                {
                    label.Text = encrypted[i - key2.Length] + "";
                }
                flowPanel.Controls.Add(label);
                labels.Add(label);
            }
        }

        private void decryptButton_ButtonClick(object sender, EventArgs e)
        {
            decrypted = Decrypt(encrypted, key);

            decryptedLabel.Text = decrypted;
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var button = new Button()
        //    {
        //        Text = $"button {++buttonCounter}",
        //        Tag = buttonCounter
        //    };

        //    button.Click += Button_Click;

        //    flowLayoutPanel1.Controls.Add(button);
        //    buttons.Add(button);
        //}

        //private void Button_Click(object? sender, EventArgs e)
        //{
        //    if (sender is not Button button) return;

        //    if (button.Tag is null) return;

        //    MessageBox.Show(button.Tag.ToString());
        //}
    }
}
