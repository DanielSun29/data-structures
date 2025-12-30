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
        int nextFreeIndexBackwards;


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

            Random rng = new Random(StableHash(masterKey));

            Point[] pixelOrderInArray = pixelOrder.ToArray();
            rng.Shuffle(pixelOrderInArray);
            pixelOrder = new List<Point>(pixelOrderInArray);
        }

        //private Point[] GeneratePosition(int messageLength, Random rng, int width, int height, string key)
        //{
        //    Point[] output = new Point[messageLength];
        //    for (int i = 0; i < output.Length; i++)
        //    {
        //        int x = rng.Next(0, width);
        //        int y = rng.Next(0, height);
        //        if (output.Contains(new Point(x, y)))
        //        {
        //            i--;
        //            continue;
        //        }
        //        output[i] = new Point(x, y);
        //    }
        //    return output;
        //}

        private void StorePassword(string label, string password)
        {
            if (entries.ContainsKey(label))
            {
                passwordTextbox.Text = "Label already stored";
                return;
            }

            if (nextFreeIndex + password.Length > pixelOrder.Count - ComputeHeaderSizeBytes())
            {
                passwordTextbox.Text = "Image is full";
                return;
            }

            var entry = new PasswordEntry
            {
                StartIndex = nextFreeIndex,
                Length = password.Length,
                Password = password
            };

            entries[label] = entry;

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

        //private Bitmap Encrypt(string input, string key, Bitmap host)
        //{
        //    Random rng = new Random(StableHash(key));

        //    Point[] pixels = GeneratePosition(input.Length, rng, host.Width, host.Height, key);
        //    Bitmap output;
        //    if (encryptedPictureBox.Image == null)
        //    {
        //        output = new Bitmap(host);
        //    }
        //    else
        //    {
        //        output = new Bitmap(encryptedImage);
        //    }

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        Color pixel = output.GetPixel(pixels[i].X, pixels[i].Y);

        //        int intMessage = input[i];

        //        byte messageTop = (byte)(intMessage & 0b_1111_0000); //Remove bottom half
        //        messageTop >>= 4; // Shift it to the last 4 digits

        //        byte messageBottom = (byte)(intMessage & 0b_0000_1111);// Remove top half, no need to shift

        //        byte hiddenR = HideChannel(pixel.R, messageTop);
        //        byte hiddenG = HideChannel(pixel.G, messageBottom);
        //        // Nothing left for b

        //        output.SetPixel(pixels[i].X, pixels[i].Y, Color.FromArgb(hiddenR, hiddenG, pixel.B));
        //    }

        //    return output;
        //}

        //private static byte HideChannel(byte host, byte hide)
        //{
        //    // In this case we have the hide values all in the smallest 4 digits
        //    byte output = (byte)(host & 0b_1111_0000);
        //    output |= hide;
        //    return output;
        //}

        public static string GenerateRandomKey(int length)

        {
            StringBuilder key = new();
            for (int i = 0; i < length; i++)
            {
                key.Append((char)Random.Shared.Next(65, 91));
            }
            return key.ToString();
        }

        //private static void CheckDifference(Bitmap host, Bitmap hide)
        //{
        //    for (int x = 0; x < host.Width; x++)
        //    {
        //        for (int y = 0; y < host.Height; y++)
        //        {
        //            Color hoP = host.GetPixel(x, y);
        //            Color hiP = hide.GetPixel(x, y);
        //            if (hoP != hiP)
        //            {
        //                continue;
        //            }
        //        }
        //    }
        //    return;
        //}

        private string GetPassword(string label)
        {
            if (!entries.TryGetValue(label, out var entry))
            {
                passwordTextbox2.Text = "Label not found!";
                return null;
            }

            StringBuilder output = new();

            for (int i = 0; i < entry.Length; i++)
            {
                Point p = pixelOrder[entry.StartIndex + i];
                Color pixel = encryptedImage.GetPixel(p.X, p.Y);

                byte high = (byte)((pixel.R & 0b_0000_1111) << 4);
                byte low = (byte)(pixel.G & 0b_0000_1111);

                output.Append((char)(high | low));
            }

            return output.ToString();
        }

        //private string Decrypt(Bitmap hide, string key)
        //{
        //    Random rng = new Random(StableHash(key));

        //    Point[] pixels = GeneratePosition(input.Length, rng, hide.Width, hide.Height, key);
        //    StringBuilder output = new();

        //    for (int i = 0; i < pixels.Length; i++)
        //    {
        //        Color pixel = hide.GetPixel(pixels[i].X, pixels[i].Y);

        //        byte messageTop = (byte)(pixel.R & 0b_0000_1111);
        //        messageTop <<= 4;

        //        byte messageBottom = (byte)(pixel.G & 0b_0000_1111);

        //        int message = (messageTop | messageBottom);

        //        output.Append((char)message);
        //    }
        //    return output.ToString();
        //}

        // The next functions are built for making code work after restart
        private void WriteByte(byte value)
        {
            Point p = pixelOrder[nextFreeIndex++];
            Color pixel = encryptedImage.GetPixel(p.X, p.Y);

            byte high = (byte)(value >> 4);
            byte low = (byte)(value & 0b_0000_1111);

            byte r = (byte)((pixel.R & 0b_1111_0000) | high);
            byte g = (byte)((pixel.G & 0b_1111_0000) | low);

            encryptedImage.SetPixel(p.X, p.Y, Color.FromArgb(r, g, pixel.B));
        }
        private void WriteByteBackwards(byte value)
        {
            Point p = pixelOrder[nextFreeIndexBackwards--];
            Color pixel = encryptedImage.GetPixel(p.X, p.Y);

            byte high = (byte)(value >> 4);
            byte low = (byte)(value & 0b_0000_1111);

            byte r = (byte)((pixel.R & 0b_1111_0000) | high);
            byte g = (byte)((pixel.G & 0b_1111_0000) | low);

            encryptedImage.SetPixel(p.X, p.Y, Color.FromArgb(r, g, pixel.B));
        }

        private byte ReadByte()
        {
            Point p = pixelOrder[nextFreeIndex++];
            Color pixel = encryptedImage.GetPixel(p.X, p.Y);

            byte high = (byte)((pixel.R & 0b_0000_1111) << 4);
            byte low = (byte)(pixel.G & 0b_0000_1111);

            return (byte)(high | low);
        }
        private byte ReadByteBackwards()
        {
            Point p = pixelOrder[nextFreeIndexBackwards--];
            Color pixel = encryptedImage.GetPixel(p.X, p.Y);

            byte high = (byte)((pixel.R & 0b_0000_1111) << 4);
            byte low = (byte)(pixel.G & 0b_0000_1111);

            return (byte)(high | low);
        }

        private void WriteHeader()
        {
            nextFreeIndex = 0;

            WriteByte((byte)entries.Count);

            foreach (var pair in entries)
            {
                string label = pair.Key;
                PasswordEntry entry = pair.Value;

                WriteByte((byte)label.Length);

                foreach (char c in label)
                {
                    WriteByte((byte)c);
                }

                // password length (2 bytes)
                WriteByte((byte)(entry.Length >> 8));
                WriteByte((byte)(entry.Length & 0b_1111_1111));
            }
        }

        private void WriteHeaderBackwards()
        {
            int headerSize = ComputeHeaderSizeBytes();
            nextFreeIndexBackwards = pixelOrder.Count - 1; // start at last pixel

            WriteByteBackwards((byte)entries.Count);

            foreach (var pair in entries)
            {
                string label = pair.Key;
                PasswordEntry entry = pair.Value;

                WriteByteBackwards((byte)label.Length);

                foreach (char c in label)
                    WriteByteBackwards((byte)c);

                WriteByteBackwards((byte)(entry.Length >> 8));
                WriteByteBackwards((byte)(entry.Length & 0xFF));
            }
        }

        private void ReadHeaderBackwards()
        {
            entries.Clear();

            nextFreeIndexBackwards = pixelOrder.Count - 1;

            int count = ReadByteBackwards();

            int passwordStart = 0;

            for (int i = 0; i < count; i++)
            {
                int labelLen = ReadByteBackwards();
                StringBuilder label = new();

                for (int j = 0; j < labelLen; j++)
                    label.Append((char)ReadByteBackwards());

                int lenHigh = ReadByteBackwards();
                int lenLow = ReadByteBackwards();
                int passwordLen = (lenHigh << 8) | lenLow;

                entries[label.ToString()] = new PasswordEntry
                {
                    StartIndex = passwordStart,
                    Length = passwordLen
                };

                passwordStart += passwordLen;
            }
        }

        private void ReadHeader()
        {
            entries.Clear();
            nextFreeIndex = 0;

            int count = ReadByte();

            for (int i = 0; i < count; i++)
            {
                int labelLen = ReadByte();
                StringBuilder label = new();

                for (int j = 0; j < labelLen; j++)
                {
                    label.Append((char)ReadByte());
                }

                int lenHigh = ReadByte();
                int lenLow = ReadByte();
                int passwordLen = (lenHigh << 8) | lenLow;

                entries[label.ToString()] = new PasswordEntry
                {
                    StartIndex = nextFreeIndex,
                    Length = passwordLen
                };

                nextFreeIndex += passwordLen;
            }
        }

        private int ComputeHeaderSizeBytes()
        {
            int size = 1; // entry count

            foreach (var kv in entries)
            {
                string label = kv.Key;
                size += 1;              // label length
                size += label.Length;   // label chars
                size += 2;              // password length (2 bytes)
            }

            return size;
        }


        // Stop here


        private void storeButton_Click(object sender, EventArgs e)
        {
            encryptedPictureBox.Image = null;
            input = passwordTextbox.Text.Trim();
            key = keyTextbox.Text.Trim();

            string label = labelTextbox.Text.Trim();
            Random rng = new Random(StableHash(label));
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
            if (!entries.ContainsKey(label))
            {
                passwordTextbox2.Text = "Label not found";
                return;
            }

            char[] tempKey = key.ToCharArray();
            Random rng = new(StableHash(label));
            rng.Shuffle(tempKey);
            string shuffledKey = new(tempKey);
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
            uploadButton.Visible = true;
            downloadButton.Visible = true;

            // Make btn invisible and disabled
            initButton.Visible = false;
            initButton.Enabled = false;
        }

        public static int StableHash(string input)
        {
            unchecked
            {
                int hash = (int)2166136261;

                foreach (char c in input)
                {
                    hash ^= c;
                    hash *= 16777619;
                }

                return hash;
            }
        }


        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            encryptedImage.Save(saveFileDialog.FileName);
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            // Start from a clean copy of the original image
            encryptedImage = new Bitmap(originalImage);

            // Rebuild pixel order
            InitializePixelOrder(encryptedImage, key);

            nextFreeIndex = 0;

            // Now write all passwords sequentially
            foreach (var kv in entries)
            {
                var entry = kv.Value;

                entry.StartIndex = nextFreeIndex; // recompute

                for (int i = 0; i < entry.Password.Length; i++)
                {
                    Point p = pixelOrder[nextFreeIndex + i];
                    Color pixel = encryptedImage.GetPixel(p.X, p.Y);

                    byte value = (byte)entry.Password[i];

                    byte high = (byte)((value & 0b_1111_0000) >> 4);
                    byte low = (byte)(value & 0b_0000_1111);

                    byte r = (byte)((pixel.R & 0b_1111_0000) | high);
                    byte g = (byte)((pixel.G & 0b_1111_0000) | low);

                    encryptedImage.SetPixel(p.X, p.Y, Color.FromArgb(r, g, pixel.B));
                }

                nextFreeIndex += entry.Password.Length;
            }

            // Write header
            WriteHeaderBackwards();

            encryptedPictureBox.Image = encryptedImage;
            saveFileDialog.ShowDialog();
        }


        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            encryptedImage = new Bitmap(openFileDialog1.FileName);
            encryptedPictureBox.Image = encryptedImage;

            InitializePixelOrder(encryptedImage, key);

            nextFreeIndex = 0;
            ReadHeaderBackwards();
        }


        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
