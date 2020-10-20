using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common.Components
{
    public partial class ImageCtrl : UserControl
    {
       
        public Image Image
        {
            get { return this.pictureBox2.Image; }
            set { this.pictureBox2.Image = value; }
        }
        public ImageCtrl()
        {
            InitializeComponent(); 
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
