using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace MyImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
           

            if (pictureBox1.Image == null)
            {
                scaleToFitToolStripMenuItem.Enabled = false;
                stretchToFitToolStripMenuItem.Enabled = false;
                actualSizeToolStripMenuItem.Enabled = false;
            } 
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG File | *.jpg;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripLabel1.Text = openFileDialog.FileName;
                var image = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                scaleToFitToolStripMenuItem.Enabled = true;
                stretchToFitToolStripMenuItem.Enabled = true;
                actualSizeToolStripMenuItem.Enabled = true;
                var imgWidth = image.Width;
                var imgHeight = image.Height;
                toolStripTextBox1.Text = $"{imgWidth}X{imgHeight}";
            }
        }

        private void stretchToFitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stretchToFitToolStripMenuItem.Checked = true;
            scaleToFitToolStripMenuItem.Checked = false;
            actualSizeToolStripMenuItem.Checked = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.Image = ScaleImages((Bitmap)pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
        }

        private void actualSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stretchToFitToolStripMenuItem.Checked = false;
            scaleToFitToolStripMenuItem.Checked = false;
            actualSizeToolStripMenuItem.Checked = true;
            var image = new Bitmap(toolStripLabel1.Text);
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Image = image;
            //pictureBox1.Image = ScaleImages((Bitmap)pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
        }
        private Bitmap ScaleImages(Bitmap originalImage, int maxWidth, int maxHeight)
        {
            int originalWidth = originalImage.Width;
            int originalHeight = originalImage.Height;

            float widthScale = (float)maxWidth / originalWidth;
            float heightScale = (float)maxHeight / originalHeight;

            float scale = Math.Min(widthScale, heightScale);

            int newWidth = (int)(originalWidth * scale);
            int newHeight = (int)(originalHeight * scale);

            Bitmap scaledImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(scaledImage))
            {
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return scaledImage;
        }
        private void scaleToFitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stretchToFitToolStripMenuItem.Checked = false;
            scaleToFitToolStripMenuItem.Checked = true;
            actualSizeToolStripMenuItem.Checked = false;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //pictureBox1.Image = ScaleImages((Bitmap)pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
            /*

            pictureBox1.Image = ScaleImage((Bitmap)pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);*/

            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

           
            // = ScaleImage((Bitmap)pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);

        }


        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you sure you want to exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                MessageBox.Show("Please continue to use the program!", "notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
