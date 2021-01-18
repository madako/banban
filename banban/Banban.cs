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

        private const string ImageFolder = "./Resources/Images/";
        private const string SoundFolder = "./Resources/Sounds/";

        private string[] ImageList { get;  set; }

        private List<PictureBox> PictureBoxList = new List<PictureBox>();

        private Timer timer = new Timer();

        public Banban()
        {
            InitializeComponent();

            ImageList = Directory.GetFiles(ImageFolder);

        }

        private void Banban_Load(object sender, EventArgs e)
        {


        }

        private void Banban_KeyDown(object sender, KeyEventArgs e)
        {
            DeleteEventHandler(Banban_KeyDown);


            label1.Text = DateTime.Now.ToLongTimeString();


            // Checking process for required variables, etc.

            // If there are no images to display in the image array, the process ends.
            if (ImageList.Length == 0)
            {
                return;
            }

            // Random number generation
            Random r1 = new System.Random();
            int showImageIndex = r1.Next(0, ImageList.Length);

            // Generate the path of the image to be displayed
            string showImagePath = Path.Combine(ImageList[showImageIndex]);

            // Set the display position of the image by a random number.
            int x = r1.Next(0, this.Width);
            int y = r1.Next(0, this.Height);

            // Get the last picturebox in Picture Box List
            PictureBox lastPictureBox = null;
            if (PictureBoxList.Count == 0)
            {
                lastPictureBox = picbox_backGroundPictureBox;
            }
            else
            {
                lastPictureBox = PictureBoxList.Last();
            }

            // Show Image
            Bitmap bmp = new Bitmap(showImagePath);
            bmp.MakeTransparent(bmp.GetPixel(0, 0));
            PictureBox imageControl = new PictureBox();
            Controls.Add(imageControl);            
            imageControl.Name = PictureBoxList.Count.ToString();
            imageControl.Padding = new Padding(x, y, 0, 0);
            imageControl.SizeMode = PictureBoxSizeMode.AutoSize;
            imageControl.BackColor = Color.Transparent;
            imageControl.Image = bmp;
            imageControl.Parent = lastPictureBox;
            imageControl.Dock = DockStyle.Fill;
            imageControl.BringToFront();
            imageControl.MouseClick += MakeSound;
            PictureBoxList.Add(imageControl);

            //Animator.Animate(150, (frame, frequency) =>
            //{
            //    if (!Visible || IsDisposed) return false;
            //    Opacity = (double)frame / frequency;
            //    return true;
            //});

            if (PictureBoxList.Count == 50)
            {
                PictureBoxList.Clear();
            }

            //Thread.Sleep(1000);


            AddEventHandler(Banban_KeyDown);

        }

        private Boolean DeleteEventHandler(KeyEventHandler eventHandler)
        {

            if(eventHandler == Banban_KeyDown)
            {
                this.KeyDown -= eventHandler;
            }

            return true;
        }

        private Boolean AddEventHandler(KeyEventHandler eventHandler)
        {
            DeleteEventHandler(eventHandler);

            if (eventHandler == Banban_KeyDown)
            {
                this.KeyDown += eventHandler;
            }

            return true;
        }

        private void MakeSound(object sender, EventArgs e)
        {
            //再生するファイル名
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Sounds", "se1.wav");
            
            SoundPlayer player = null;
            player = new System.Media.SoundPlayer(fileName);
            player.Play();
        }
    }
}
