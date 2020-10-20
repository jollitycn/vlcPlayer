
using JGNet.Common.Components;
using CJBasic.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class ImageHelpForm :  Form
    {
          

        public ImageHelpForm(Image image)
        {
            InitializeComponent();
            this.pictureBox2.Image = image;
        }

        private void ImageHelpForm_MouseLeave(object sender, EventArgs e)
        {
            this.Close();
        }
        private Point mousePoint = new Point();

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }
        }

        private void ImageHelpForm_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.Show();
        }
    }
}
