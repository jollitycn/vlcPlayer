namespace CJBasic.Widget
{
    using CJBasic;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class ThumbnailListBox : UserControl
    {
        private IContainer components = null;
        private FlowLayoutPanel flowLayoutPanel1;
        private float thumbnailCoef = 0.1f;

        public event CbGeneric<int> ThumbnailClicked;

        public ThumbnailListBox()
        {
            this.InitializeComponent();
            this.ThumbnailClicked += delegate {
            };
        }

        public void AppendThumbnail(ThumbnailData data)
        {
            Thumbnail thumbnail = new Thumbnail();
            thumbnail.Initialize(data.Name, data.Image, this.thumbnailCoef);
            thumbnail.ThumbnailClicked += new CbGeneric<string>(this.thumbnail_ThumbnailClicked);
            this.flowLayoutPanel1.Controls.Add(thumbnail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            base.SuspendLayout();
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = Color.White;
            this.flowLayoutPanel1.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.Location = new Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(150, 150);
            this.flowLayoutPanel1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.flowLayoutPanel1);
            base.Name = "ThumbnailListBox";
            base.ResumeLayout(false);
        }

        public void Load(IList<ThumbnailData> images)
        {
            this.flowLayoutPanel1.Controls.Clear();
            foreach (ThumbnailData data in images)
            {
                Thumbnail thumbnail = new Thumbnail();
                thumbnail.Initialize(data.Name, data.Image, this.thumbnailCoef);
                thumbnail.ThumbnailClicked += new CbGeneric<string>(this.thumbnail_ThumbnailClicked);
                this.flowLayoutPanel1.Controls.Add(thumbnail);
            }
        }

        public void RemoveThumbnail(int index)
        {
            this.flowLayoutPanel1.Controls.RemoveAt(index);
        }

        public void RemoveThumbnail(string imageName)
        {
            Thumbnail thumbnail = null;
            foreach (Thumbnail thumbnail2 in this.flowLayoutPanel1.Controls)
            {
                if (thumbnail2.ImageName == imageName)
                {
                    thumbnail = thumbnail2;
                    break;
                }
            }
            if (thumbnail != null)
            {
                this.flowLayoutPanel1.Controls.Remove(thumbnail);
            }
        }

        public void SelectThumbnail(int index)
        {
            for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)
            {
                Thumbnail thumbnail = (Thumbnail) this.flowLayoutPanel1.Controls[i];
                if (i == index)
                {
                    thumbnail.Selected = true;
                }
                else
                {
                    thumbnail.Selected = false;
                }
            }
        }

        public void SelectThumbnail(string imageName)
        {
            for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)
            {
                Thumbnail thumbnail = (Thumbnail) this.flowLayoutPanel1.Controls[i];
                if (thumbnail.ImageName == imageName)
                {
                    thumbnail.Selected = true;
                }
                else
                {
                    thumbnail.Selected = false;
                }
            }
        }

        private void thumbnail_ThumbnailClicked(string imageName)
        {
            int num = -1;
            for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)
            {
                Thumbnail thumbnail = (Thumbnail) this.flowLayoutPanel1.Controls[i];
                if (thumbnail.ImageName == imageName)
                {
                    thumbnail.Selected = true;
                    num = i;
                }
                else
                {
                    thumbnail.Selected = false;
                }
            }
            this.ThumbnailClicked(num);
        }

        public void UpdateThumbnail(int index, Image image)
        {
            for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)
            {
                if (i == index)
                {
                    ((Thumbnail) this.flowLayoutPanel1.Controls[i]).UpdateImage(image, this.thumbnailCoef);
                    break;
                }
            }
        }

        public void UpdateThumbnail(string imageName, Image image)
        {
            for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)
            {
                Thumbnail thumbnail = (Thumbnail) this.flowLayoutPanel1.Controls[i];
                if (thumbnail.ImageName == imageName)
                {
                    thumbnail.UpdateImage(image, this.thumbnailCoef);
                    break;
                }
            }
        }

        public float ThumbnailCoef
        {
            get
            {
                return this.thumbnailCoef;
            }
            set
            {
                this.thumbnailCoef = value;
            }
        }
    }
}

