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
        private string decrypted;
        string encrypted;

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
            for (int j = 0; j < key.Length; j++)
            {
                for (int i = j; i < message.Length; i += key.Length)
                {
                    if (i < message.Length)
                    {
                        output.Append(message[i]);
                    }
                }
            }
            return output.ToString();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            keyText.Clear();
            input = messageText.Text.Trim();
            if (input.Length > 30)
            {
                key = generateKey(Random.Shared.Next(3, 10));
            }
            else
            {
                key = generateKey(Random.Shared.Next(3, (int)input.Length / 3));
            }
            keyText.Text = key;
            keyLengthLabel.Text = $"{keyText.Text.Length}";
        }

        private void encryptButton_ButtonClick(object sender, EventArgs e)
        {
            input = messageText.Text.Trim();

            encrypted = Encrypt(input, key);


            // Below is visualization

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
                    Width = (usableWidth - key.Length * (Margin.Left + Margin.Right))/ key.Length - 1,
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
