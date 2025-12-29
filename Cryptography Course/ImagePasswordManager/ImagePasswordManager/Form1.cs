using System.Text;

namespace ImagePasswordManager
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        Bitmap encryptedImage;
        Random rng;
        private string input = "";
        private string key = "";
        private string decrypted = "";
        private List<string> labels = new List<string>();
        List<Random> randoms = new List<Random>();

        Dictionary<string, PasswordEntry> entries = new Dictionary<string, PasswordEntry>();
        List<Point> pixelOrder;
        int nextFreeIndex = 0;


        // ASCII values go from 0 to 127 inclusive, so we need 7 digits

        public Form1()
        {
            InitializeComponent();
        }

        // Key function: key is seed for random, random selects which pixels to change
        // General idea: ASCII values go up to 255, so I can store 4 in and 4 in b

        private void Form1_Load(object sender, EventArgs e)
        {
            // This step requires to set the property of the image "copy to output directory" to "copy always"
            originalImage = new Bitmap("dog_imresizer.jpg");

            originalPictureBox.Image = originalImage;
            originalPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            encryptedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            encryptedImage = new Bitmap(originalImage);
        }

        void InitializePixelOrder(Bitmap image, string masterKey)
        {
            pixelOrder = new List<Point>();

            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                    pixelOrder.Add(new Point(x, y));

            Random rng = new Random(masterKey.GetHashCode());

            Point[] pixelOrderInArray = pixelOrder.ToArray();
            rng.Shuffle(pixelOrderInArray);
            pixelOrder = new List<Point>(pixelOrderInArray);
        }


        private Point[] GeneratePosition(int messageLength, Random rng, int width, int height, string key)
        {
            Point[] output = new Point[messageLength];
            for (int i = 0; i < output.Length; i++)
            {
                int x = rng.Next(0, width);
                int y = rng.Next(0, height);
                if (output.Contains(new Point(x, y)))
                {
                    i--;
                    continue;
                }
                output[i] = new Point(x, y);
            }
            return output;
        }

        private void StorePassword(string label, string password)
        {
            if (entries.ContainsKey(label))
            {
                throw new Exception("Label already exists");
            }

            if (nextFreeIndex + password.Length > pixelOrder.Count)
            {
                throw new Exception("Image is full");
            }

            entries[label] = new PasswordEntry
            {
                StartIndex = nextFreeIndex,
                Length = password.Length
            };

            for (int i = 0; i < password.Length; i++)
            {
                Point p = pixelOrder[nextFreeIndex + i];
                Color pixel = encryptedImage.GetPixel(p.X, p.Y);

                byte value = (byte)password[i];

                byte high = (byte)((value & 0b_1111_0000) >> 4);
                byte low = (byte)(value & 0b_0000_1111);

                byte r = (byte)((pixel.R & 0b_1111_0000) | high);
                byte g = (byte)((pixel.G & 0b_1111_0000) | low);

                encryptedImage.SetPixel(p.X, p.Y, Color.FromArgb(r, g, pixel.B));
            }

            nextFreeIndex += password.Length;
        }


        private Bitmap Encrypt(string input, string key, Bitmap host)
        {
            rng = new Random(key.GetHashCode());
            Point[] pixels = GeneratePosition(input.Length, rng, host.Width, host.Height, key);
            Bitmap output;
            if (encryptedPictureBox.Image == null)
            {
                output = new Bitmap(host);
            }
            else
            {
                output = new Bitmap(encryptedImage);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Color pixel = output.GetPixel(pixels[i].X, pixels[i].Y);

                int intMessage = input[i];

                byte messageTop = (byte)(intMessage & 0b_1111_0000); //Remove bottom half
                messageTop >>= 4; // Shift it to the last 4 digits

                byte messageBottom = (byte)(intMessage & 0b_0000_1111);// Remove top half, no need to shift

                byte hiddenR = HideChannel(pixel.R, messageTop);
                byte hiddenG = HideChannel(pixel.G, messageBottom);
                // Nothing left for b

                output.SetPixel(pixels[i].X, pixels[i].Y, Color.FromArgb(hiddenR, hiddenG, pixel.B));
            }

            return output;
        }

        private static byte HideChannel(byte host, byte hide)
        {
            // In this case we have the hide values all in the smallest 4 digits
            byte output = (byte)(host & 0b_1111_0000);
            output |= hide;
            return output;
        }

        public static string GenerateRandomKey(int length)
        {
            StringBuilder key = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                key.Append((char)Random.Shared.Next(65, 91));
            }
            return key.ToString();
        }

        private void CheckDifference(Bitmap host, Bitmap hide)
        {
            for (int x = 0; x < host.Width; x++)
            {
                for (int y = 0; y < host.Height; y++)
                {
                    Color hoP = host.GetPixel(x, y);
                    Color hiP = hide.GetPixel(x, y);
                    if (hoP != hiP)
                    {
                        continue;
                    }
                }
            }
            return;
        }

        string GetPassword(string label)
        {
            if (!entries.TryGetValue(label, out var entry))
                throw new Exception("Label not found");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < entry.Length; i++)
            {
                Point p = pixelOrder[entry.StartIndex + i];
                Color pixel = encryptedImage.GetPixel(p.X, p.Y);

                byte high = (byte)((pixel.R & 0b_0000_1111) << 4);
                byte low = (byte)(pixel.G & 0b_0000_1111);

                sb.Append((char)(high | low));
            }

            return sb.ToString();
        }

        private string Decrypt(Bitmap hide, string key)
        {
            rng = new Random(key.GetHashCode());
            Point[] pixels = GeneratePosition(input.Length, rng, hide.Width, hide.Height, key);
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < pixels.Length; i++)
            {
                Color pixel = hide.GetPixel(pixels[i].X, pixels[i].Y);

                byte messageTop = (byte)(pixel.R & 0b_0000_1111);
                messageTop <<= 4;

                byte messageBottom = (byte)(pixel.G & 0b_0000_1111);

                int message = (messageTop | messageBottom);

                output.Append((char)message);
            }
            return output.ToString();
        }

        private void storeButton_Click(object sender, EventArgs e)
        {
            encryptedPictureBox.Image = null;
            input = passwordTextbox.Text.Trim();
            key = keyTextbox.Text.Trim();

            string label = labelTextbox.Text.Trim();
            labels.Add(label);
            Random rng = new Random(label.GetHashCode());
            randoms.Add(rng);

            char[] tempKey = key.ToCharArray();
            rng.Shuffle(tempKey);
            string shuffledKey = new string(tempKey);
            //encryptedImage = Encrypt(input, shuffledKey, originalImage);
            StorePassword(label, input);

            encryptedPictureBox.Image = encryptedImage;
            //CheckDifference(originalImage, encryptedImage);
        }

        private void generateKeyButton_Click(object sender, EventArgs e)
        {
            key = GenerateRandomKey(Random.Shared.Next(3, 16));
            keyTextbox.Text = key;
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            string label = labelTextbox2.Text.Trim();
            if (!labels.Contains(label))
            {
                passwordTextbox2.Text = "Label not found";
                return;
            }

            char[] tempKey = key.ToCharArray();
            Random rng = new Random(label.GetHashCode());
            rng.Shuffle(tempKey);
            string shuffledKey = new string(tempKey);
            //decrypted = Decrypt(encryptedImage, shuffledKey);
            decrypted = GetPassword(label);
            passwordTextbox2.Text = decrypted;
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            key = keyTextbox.Text;
            InitializePixelOrder(originalImage, key);

            keyTextbox.ReadOnly = true;

            // Make everything visible
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            passwordTextbox.Visible = true;
            passwordTextbox2.Visible = true;
            labelTextbox.Visible = true;
            labelTextbox2.Visible = true;
            storeButton.Visible = true;
            getButton.Visible = true;
            originalPictureBox.Visible = true;

            // Make btn invisible and disabled
            initButton.Visible = false;
            initButton.Enabled = false;
        }
    }
}
