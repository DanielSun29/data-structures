namespace ImagePasswordManager
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        Bitmap encryptedImage;
        Random rng;
        private string input = "";
        private string key = "";

        // ASCII values go from 0 to 127 inclusive, so we need 7 digits

        public Form1()
        {
            InitializeComponent();
        }

        // Key function: key is seed for random, random selects which pixels to change

        private void Form1_Load(object sender, EventArgs e)
        {
            // This step requires to set the property of the image "copy to output directory" to "copy always"
            originalImage = new Bitmap("dog_imresizer.jpg");

            originalPictureBox.Image = originalImage;
            originalPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            encryptedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private Point[] GeneratePosition(int messageLength, Random rng, int width, int height, string key)
        {
            Point[] output = new Point[messageLength];
            for (int i = 0; i < output.Length; i++)
            {
                int x = rng.Next(0, width);
                int y = rng.Next(0, height);
                output[i] = new Point(x, y);
            }
            return output;
        }

        private Bitmap Encrypt(string input, string key, Bitmap host)
        {
            rng = new Random(key.GetHashCode());
            Point[] pixels = GeneratePosition(input.Length, rng, originalPictureBox.Width, originalPictureBox.Height, key);

        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            encryptedPictureBox.Image = Encrypt(input, key, originalImage);
        }
    }
}
