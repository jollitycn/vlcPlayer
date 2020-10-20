using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common.Components
{
    public partial class TitleImageOfCostume : UserControl
    {
        //public Boolean ShowDeleteBtn
        //{
        //    set
        //    {
        //        if (value)
        //        {
        //            this.pictureBox2.Show();
        //        }
        //        else
        //        {
        //            this.pictureBox2.Hide();
        //        }
        //    }
        //}

        private String title = string.Empty;
        public String Title
        {
            get { return title; }
            set
            {
                this.linkLabel1.Text = value;
                this.title = value;
                this.skinToolTip1.SetToolTip(this.linkLabel1, value);
                this.skinToolTip1.SetToolTip(this.pictureBox1, value);
                if (String.IsNullOrEmpty(value) )
                {
                    linkLabel1.Hide();
                    this.panel1.Hide();
                }
                else
                {
                    linkLabel1.Show();
                    panel1.Show();
                    ReAlign();
                }

            }
        }

        private void ReAlign()
        {
            this.linkLabel1.Location = new Point(
                (this.Width - this.linkLabel1.Width) / 2, this.linkLabel1.Location.Y);


        }

        public Image Image {
            get { return this.pictureBox1.Image; } set {
                this.pictureBox1.Image = value; } }

        public CJBasic.Action<TitleImageOfCostume, EventArgs> OnSelected;
        public CJBasic.Action<TitleImageOfCostume, EventArgs> OnRemoved;
        private bool selected = false;

        /// <summary>
        /// 选中和对应事件
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if (value)
                {
                    this.BackColor = Color.DarkGray;
                    this.BorderStyle = BorderStyle.FixedSingle;
                    OnSelected ?.Invoke(this,null);
                }
                else
                {
                    this.BackColor = Color.Transparent;
                    this.BorderStyle = BorderStyle.None;
                }
            }
        }

        public bool CannotRemove { get; internal set; }
        public bool Selectable { get; internal set; }
        
        public TitleImageOfCostume(String title,Image image, EventHandler MenuItem_Click)
        {
            InitializeComponent();
            this.linkLabel1.Text = title;
            this.pictureBox1.Image = image; 
            this.Click += MenuItem_Click;
        }

        public TitleImageOfCostume()
        {
            //不能修改autosize
            InitializeComponent();
            Selectable = true;



        }

        private void MenuItem_Load(object sender, EventArgs e)
        {
           

          

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        } 

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            this.OnMouseClick(e);
        }

        private void TitleImage_Click(object sender, EventArgs e)
        {
            if (Selectable)
            {
                this.Selected = !this.selected;
                OnSelected?.Invoke(this,null);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !CannotRemove)
            {
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }



        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnRemoved?.Invoke(this, e);
            this.Dispose();
        }
    }
}
