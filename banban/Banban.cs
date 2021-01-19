using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using System.Media;

namespace banban
{
    public partial class Banban : Form
    {

        [System.Runtime.InteropServices.DllImport("winmm.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int mciSendString(string command, System.Text.StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        private static string ImageFolder = Path.Combine(path1: Directory.GetCurrentDirectory(), "Resources", "Images");
        private static string SoundFolder = Path.Combine(path1: Directory.GetCurrentDirectory(), "Resources", "Sounds");

        private string[] ImageList { get; set; }
        private string[] SoundList { get; set; }

        private List<PictureBox> PictureBoxList = new List<PictureBox>();

        public Banban()
        {
            InitializeComponent();

            ImageList = Directory.GetFiles(ImageFolder);
            SoundList = Directory.GetFiles(SoundFolder);

        }

        private void Banban_Load(object sender, EventArgs e)
        {


        }

        private void Banban_KeyDown(object sender, KeyEventArgs e)
        {



            // Checking process for required variables, etc.

            // If there are no images and sounds to display in the image/sound array, the process ends.
            if (ImageList.Length == 0 || SoundList.Length ==0)
            {
                return;
            }

            // Random number generation
            // set show image number and make sound.
            Random r1 = new System.Random();
            int makeSoundIndex = r1.Next(0, SoundList.Length);
            int showImageIndex = r1.Next(0, ImageList.Length);

            // Set the display position of the image by a random number.
            int x = r1.Next(0, this.Width);
            int y = r1.Next(0, this.Height);

            // Make Sound
            MakeSound(makeSoundIndex);

            // Show Image
            ShowImage(showImageIndex, x, y);


            if (PictureBoxList.Count == 50)
            {
                PictureBoxList.Clear();
            }


        }


        private Boolean MakeSound(int makeSoundIndex)
        {
            //再生するファイル名
            string fileName = Path.Combine(SoundFolder, "se_" + makeSoundIndex.ToString());
            
            SoundPlayer player = null;
            player = new System.Media.SoundPlayer(SoundList[makeSoundIndex]);
            player.Play();

            return true;
        }

        private Boolean ShowImage(int showImageIndex, int showX, int showY)
        {

            // Generate the path of the image/sound to be displayed
            string showImagePath = Path.Combine(ImageList[showImageIndex]);

            // Show Image
            Bitmap bmp = new Bitmap(showImagePath);
            bmp.MakeTransparent(bmp.GetPixel(0, 0));
            PictureBox imageControl = new PictureBox();
            Controls.Add(imageControl);
            imageControl.Name = PictureBoxList.Count.ToString();
            imageControl.Padding = new Padding(showX, showY, 0, 0);
            imageControl.SizeMode = PictureBoxSizeMode.AutoSize;
            imageControl.BackColor = Color.Transparent;
            imageControl.Image = bmp;
            imageControl.Dock = DockStyle.Fill;
            imageControl.BringToFront();
            // Get the last picturebox in Picture Box List
            if (PictureBoxList.Count == 0)
            {
                imageControl.Parent = this;
            }
            else
            {
                imageControl.Parent = PictureBoxList.Last();
            }
            PictureBoxList.Add(imageControl);

            return true;
        }

    }
}
