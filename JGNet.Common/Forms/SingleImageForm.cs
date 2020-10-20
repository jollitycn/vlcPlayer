
using JGNet.Common.Components;
using CJBasic.Helpers;
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
    public partial class SingleImageForm : BaseForm
    {

        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="title"></param>
        /// <param name="image"></param>
        public void LoadImage(String title, Image image)
        {
            this.Text = title;
            OnLoadingState();
            this.Image = image;
        }


        public void OnLoadingState()
        {
            this.skinLabel3.Text= "加载中……";
            this.pictureBox2.Image = null;
        }

        public Image Image
        {
            get { return this.pictureBox2.Image; }
            set
            {
                this.pictureBox2.Image = value;
                this.skinLabel3.Visible = value == null; 
                this.skinLabel3.Text = " 该商品没有图片";
                DisplaySize(value);
            }
        }
        public SingleImageForm(Image image = null)
        {
            InitializeComponent();
            skinLabel1.Text = string.Empty;

            DisplaySize(image);
            this.pictureBox2.Image = image;
        }

        private void DisplaySize(Image image)
        {
            if (image != null)
            {
                byte[] bytes = ImageHelper.Convert(image);
                skinLabel1.Text = image.Size.Width + "*" + image.Size.Height + " " + CJBasic.Helpers.PublicHelper.GetSizeString((ulong)bytes.Length);
            }
        }
         
        private Point mousePoint = new Point();
        private Point originLocation = new Point();

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mousePoint = e.Location;          
            this.originLocation = this.Location;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                int deltX = e.Location.X - this.mousePoint.X;
                int deltY = e.Location.Y - this.mousePoint.Y;
                if(Math.Abs(deltX) + Math.Abs(deltY) > 5)
                {
                    this.Location = new Point(this.originLocation.X + deltX, this.originLocation.Y + deltY);
                    //this.mousePoint = e.Location;
                }
                //this.Top = Control.MousePosition.Y - mousePoint.Y;
                //this.Left = Control.MousePosition.X - mousePoint.X;
            }
        }
         
     

        private void SingleImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.Hide();
           // e.Cancel = true;
        }
    }
}
