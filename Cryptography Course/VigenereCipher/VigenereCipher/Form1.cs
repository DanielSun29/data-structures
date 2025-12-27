using System.Text;

namespace VigenereCipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Key is col, text is row
        // output letter position is original position - difference of a and key value

        private string input = "";
        public string cipherText = "";
        private string decrypted = "";
        private string key = "";
        private string strengthenedKey = "";

        int labelCounters = 0;
        List<Label> labels = new List<Label>();

        private static char[,] BuildVigenereSquare() // Create 2d aray
        {
            char[,] output = new char[26, 26];
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    int letterNumber = (i + j) % 26;
                    output[i, j] = (char)(letterNumber + 65);
                }
            }
            return output;
        }

        private static string StrengthenKey(string key, int length)
        {
            key = key.ToUpper();
            StringBuilder strengthenedKey = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                strengthenedKey.Append(key[i % key.Length]);
            }
            return strengthenedKey.ToString();
        }

        private static string Encrypt(string input, string key, char[,] vigenereSquare)
        {
            string strengthenedKey = StrengthenKey(key, input.Length);
            input = input.ToUpper();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (32 <= input[i] && input[i] <= 64)
                {
                    output.Append(input[i]);
                    continue;
                }
                Point location = new Point();
                location.X = strengthenedKey[i] - 65;
                location.Y = input[i] - 65;
                output.Append(vigenereSquare[location.X, location.Y]);
            }

            return output.ToString();
        }

        private static string Decrypt(string cipherText, string key, char[,] vigenereSquare)
        {
            string strengthenedKey = StrengthenKey(key, cipherText.Length);
            cipherText = cipherText.ToUpper();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < cipherText.Length; i++)
            {
                if (32 <= cipherText[i] && cipherText[i] <= 64)
                {
                    output.Append(cipherText[i]);
                    continue;
                }
                int row = 0;
                for (int j = 0; j < 26; j++)
                {
                    if (vigenereSquare[strengthenedKey[i] - 65, j] == cipherText[i])
                    {
                        row = j; break;
                    }
                }
                output.Append((char)(row + 65));
            }
            return output.ToString();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            char[,] vigenereSquare = BuildVigenereSquare();
            input = inputTextbox.Text.Trim().ToUpper();
            key = keyTextbox.Text.Trim().ToUpper();
            cipherText = Encrypt(input, key, vigenereSquare);
            strengthenedKey = StrengthenKey(key, cipherText.Length);
            ciphertextTextbox.Text = cipherText;
        }

        private async void visualizeButton_Click(object sender, EventArgs e)
        {
            labels.Clear();

            flowLayoutPanel1.Controls.Clear();

            flowLayoutPanel1.BorderStyle = BorderStyle.None;

            char[,] vigenereSquare = BuildVigenereSquare();

            // Create vigenere square

            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    int usableWidth = flowLayoutPanel1.Width - flowLayoutPanel1.Padding.Left - flowLayoutPanel1.Padding.Right;
                    int usableHeight = flowLayoutPanel1.Height - flowLayoutPanel1.Padding.Top - flowLayoutPanel1.Padding.Bottom;
                    var label = new Label()
                    {
                        Margin = new Padding(0),
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = $"label {++labelCounters}",
                        Width = usableWidth / 27,
                        Height = usableHeight / 27,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            label.Text = " ";
                        }
                        else
                        {
                            label.Text = $"{(char)(j - 1 + 'A')}"; // -1 to shift by 1
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            label.Text = $"{(char)(i - 1 + 'A')}";
                        }
                        else
                        {
                            Point locationInSquare = new Point();
                            locationInSquare.X = j - 1;
                            locationInSquare.Y = i - 1;
                            label.Text = vigenereSquare[locationInSquare.X, locationInSquare.Y].ToString();
                        }
                    }


                    flowLayoutPanel1.Controls.Add(label);
                    labels.Add(label);
                }
            }

            // Start the animation part

            for (int i = 0; i < cipherText.Length; i++)
            {
                if (32 <= input[i] && input[i] <= 64) continue;
                for (int j = 0; j < labels.Count; j++)
                {
                    labels[j].BackColor = Color.White;
                }

                int colToHighlight = strengthenedKey[i] - 'A' + 1;
                int rowToHighlight = input[i] - 'A' + 1;

                for (int j = 0; j < 27; j++)
                {
                    labels[colToHighlight].BackColor = Color.Yellow;
                    colToHighlight += 27;
                }
                for (int j = 0; j < 27; j++)
                {
                    labels[rowToHighlight * 27 + j].BackColor = Color.Yellow;
                }
                colToHighlight = strengthenedKey[i] - 'A' + 1;// reset to do intersection
                labels[rowToHighlight * 27 + colToHighlight].BackColor = Color.Red;// intersection

                await Task.Delay(1500);
            }
            for (int j = 0; j < labels.Count; j++)
            {
                labels[j].BackColor = Color.White;
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            char[,] vigenereSquare = BuildVigenereSquare();
            decrypted = Decrypt(cipherText, key, vigenereSquare);
            decryptedTextbox.Text = decrypted.ToString();
        }

        private async void visualizeButton2_Click(object sender, EventArgs e)
        {
            labels.Clear();

            flowLayoutPanel1.Controls.Clear();

            flowLayoutPanel1.BorderStyle = BorderStyle.None;

            char[,] vigenereSquare = BuildVigenereSquare();

            // Create vigenere square

            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    int usableWidth = flowLayoutPanel1.Width - flowLayoutPanel1.Padding.Left - flowLayoutPanel1.Padding.Right;
                    int usableHeight = flowLayoutPanel1.Height - flowLayoutPanel1.Padding.Top - flowLayoutPanel1.Padding.Bottom;
                    var label = new Label()
                    {
                        Margin = new Padding(0),
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = $"label {++labelCounters}",
                        Width = usableWidth / 27,
                        Height = usableHeight / 27,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            label.Text = " ";
                        }
                        else
                        {
                            label.Text = $"{(char)(j - 1 + 'A')}"; // -1 to shift by 1
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            label.Text = $"{(char)(i - 1 + 'A')}";
                        }
                        else
                        {
                            Point locationInSquare = new Point();
                            locationInSquare.X = j - 1;
                            locationInSquare.Y = i - 1;
                            label.Text = vigenereSquare[locationInSquare.X, locationInSquare.Y].ToString();
                        }
                    }


                    flowLayoutPanel1.Controls.Add(label);
                    labels.Add(label);
                }
            }

            // Start the animation part

            for (int i = 0; i < cipherText.Length; i++)
            {
                if (32 <= input[i] && input[i] <= 64) continue;
                for (int j = 0; j < labels.Count; j++)
                {
                    labels[j].BackColor = Color.White;
                }

                int colToHighlight = strengthenedKey[i] - 'A' + 1;

                for (int j = 0; j < 27; j++)
                {
                    labels[colToHighlight].BackColor = Color.CornflowerBlue;
                    colToHighlight += 27;
                }

                colToHighlight = strengthenedKey[i] - 'A' + 1; // reset
                int rowToHighlight;
                for (rowToHighlight = 1; rowToHighlight < 27; rowToHighlight++)
                {
                    await Task.Delay(200);
                    if (labels[rowToHighlight * 27 + colToHighlight].Text == cipherText[i].ToString())
                    {
                        labels[rowToHighlight * 27 + colToHighlight].BackColor = Color.Blue;
                        break;
                    }
                    labels[rowToHighlight * 27 + colToHighlight].BackColor = Color.Yellow;
                }
                for (int j = 0; j < 27; j++)
                {
                    labels[rowToHighlight * 27 + j].BackColor = Color.Yellow;
                }
                labels[rowToHighlight * 27].BackColor = Color.Red;

                await Task.Delay(1500);
            }
            for (int j = 0; j < labels.Count; j++)
            {
                labels[j].BackColor = Color.White;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
