using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Common.Core;

namespace JGNet.Common.Components
{
    public partial class WorkDeskMenuItem : BaseUserControl
    {
         
        public new bool Enabled
        {
            set
            {
                pictureBox1.Enabled = value; 
                linkLabel1.Enabled = value;
            }
        }

        public String Title
        {
            get { return this.linkLabel1.Text; }
            set
            {
                this.linkLabel1.Text = value;
                this.skinToolTip1.SetToolTip(this.linkLabel1, value);
                this.skinToolTip1.SetToolTip(this.pictureBox1, value);
                 ReAlign();

            }
        }

        private void ReAlign()
        {
            this.linkLabel1.Location = new Point((this.Width - this.linkLabel1.Width) / 2, this.linkLabel1.Location.Y);
        }

        public Image Image { get { return this.pictureBox1.Image; } set { this.pictureBox1.Image = value; } }
        public WorkDeskMenuItem(String title,Image image, EventHandler MenuItem_Click)
        {
            InitializeComponent();
            this.linkLabel1.Text = title;
            this.pictureBox1.Image = image; 
            this.Click += MenuItem_Click;
        }

        public WorkDeskMenuItem()
        {
            InitializeComponent(); 

        } 

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.OnClick(e);
        }
    }
}
