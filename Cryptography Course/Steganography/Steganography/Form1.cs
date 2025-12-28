using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.Logging;
using System.Windows.Forms;

namespace Steganography
{
    public partial class Form1 : Form
    {
        Bitmap image1;
        Bitmap image2;
        Bitmap hiddenImage;
        Bitmap unhiddenImage;
        int borderWidth;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This step requires to set the property of the image "copy to output directory" to "copy always"
            image1 = new Bitmap("dog_imresizer.jpg");
            image2 = new Bitmap("dog2_imresizer.jpg");

            hostPicture.Image = image1;
            hostPicture.SizeMode = PictureBoxSizeMode.Zoom;
            hidePicture.Image = image2;
            hidePicture.SizeMode = PictureBoxSizeMode.Zoom;
            hiddenPicture.SizeMode = PictureBoxSizeMode.Zoom;
            unhiddenPicture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private Bitmap HideImage(Bitmap Host, Bitmap Hide)
        {
            Bitmap result = new Bitmap(Host.Width, Host.Height);

            for (int y = 0; y < Host.Height; y++)
            {
                for (int x = 0; x < Host.Width; x++)
                {
                    Color p1 = Host.GetPixel(x, y);
                    Color p2 = Hide.GetPixel(x, y);

                    byte hiddenR = HideChannel(p1.R, p2.R);
                    byte hiddenG = HideChannel(p1.G, p2.G);
                    byte hiddenB = HideChannel(p1.B, p2.B);

                    result.SetPixel(x, y, Color.FromArgb(hiddenR, hiddenG, hiddenB));
                }
            }
            return result;
        }

        static byte HideChannel(byte host, byte hide)
        {
            byte hideMSB = (byte)(hide >> 4);

            byte hostMSB = (byte)(host >> 4); // To delete the last 4 digits
            hostMSB = (byte)(hostMSB << 4);

            byte result = (byte)(hideMSB | hostMSB);
            return result;
        }

        private Bitmap UnhideImage(Bitmap Host, Bitmap Hidden)
        {
            Bitmap result = new Bitmap(Host.Width, Host.Height);

            for (int y = 0; y < Host.Height; y++)
            {
                for (int x = 0; x < Host.Width; x++)
                {
                    Color hiddenP = Hidden.GetPixel(x, y);

                    byte unhiddenR = UnhideChannel(hiddenP.R);
                    byte unhiddenG = UnhideChannel(hiddenP.G);
                    byte unhiddenB = UnhideChannel(hiddenP.B);

                    result.SetPixel(x, y, Color.FromArgb(unhiddenR, unhiddenG, unhiddenB));
                }
            }
            return result;
        }

        static byte UnhideChannel(byte hidden)
        {
            byte hiddenLSB = (byte)(hidden & 0b_0000_1111);
            byte originalMSB = (byte)(hiddenLSB << 4);
            return originalMSB;
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            hiddenImage = HideImage(image1, image2);
            hiddenPicture.Image = hiddenImage;
        }

        private void unhideButton_Click(object sender, EventArgs e)
        {
            unhiddenImage = UnhideImage(image1, hiddenImage);
            unhiddenPicture.Image = unhiddenImage;
        }

        //private void button1_Click(object sender, EventArgs e) // This one is border
        //{
        //    pictureBox1.Image = image1;
        //    image1 = new Bitmap("dog_imresizer.jpg");
        //    for (int x = 0; x < image1.Width; x++)
        //    {
        //        for (int y = 0; y < borderWidth; y++)
        //        {
        //            image1.SetPixel(x, y, Color.Blue);
        //            image1.SetPixel(x, y + image1.Height - borderWidth, Color.Blue);
        //        }

        //    }
        //    for (int y = 0; y < image1.Height; y++)
        //    {
        //        for (int x = 0; x < borderWidth; x++)
        //        {
        //            image1.SetPixel(x, y, Color.Blue);
        //            image1.SetPixel(x + image1.Width - borderWidth, y, Color.Blue);
        //        }
        //    }
        //}

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //var result = SaveFileDialog.ShowDialog();
            //if (result != DialogResult.OK) return;

            //pictureBox3.Image.Save(saveFileDialog.FileName);
        }

        public void BitShiftingDemo()
        {
            int a = 1;

            // << and >> indicates shift of bits
            int doubledA = a << 1;
            int quadrupledA = a << 2;

            int someVal = 0b_0010_1010; // someVal = 42
            int mask = 0b_0001_1000; // mask = 24

            int result = someVal & mask; // 8 = 0000_1000
            result = result >> 3; // 1 = 0000_0001

            int pixelVal = 0b_1011_1000; // Let's say the last 2 bits have been cleared; pixelVal = 184
            pixelVal = pixelVal | result; // 185 = 1011_1001
        }
    }
}
