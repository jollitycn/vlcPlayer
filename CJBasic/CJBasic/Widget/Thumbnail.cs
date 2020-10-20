namespace CJBasic.Widget
{
    using CJBasic;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class Thumbnail : UserControl
    {
        private IContainer components = null;
        private string imageName = "";
        private Label label1;
        private PictureBox pictureBox1;

        public event CbGeneric<string> ThumbnailClicked;

        public Thumbnail()
        {
            this.InitializeComponent();
            this.ThumbnailClicked += delegate {
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Initialize(string name, Image image, float thumbnailCoef)
        {
            this.imageName = name;
            this.label1.Text = name;
            this.UpdateImage(image, thumbnailCoef);
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new PictureBox();
            this.label1 = new Label();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.pictureBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.Location = new Point(15, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x66, 130);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
            this.label1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.label1.Location = new Point(4, 0x88);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x7d, 0x17);
            this.label1.TabIndex = 1;
            this.label1.Text = "001图";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Transparent;
            base.Controls.Add(this.label1);
            base.Controls.Add(this.pictureBox1);
            base.Name = "Thumbnail";
            base.Size = new Size(0x83, 0xa6);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Selected = true;
        }

        private bool ThumbnailCallBack()
        {
            return false;
        }

        public void UpdateImage(Image image, float thumbnailCoef)
        {
            int num = base.Height - this.pictureBox1.Height;
            int num2 = base.Width - this.pictureBox1.Width;
            Size size = new Size((int) (image.Width * thumbnailCoef), (int) (image.Height * thumbnailCoef));
            base.Size = new Size(size.Width + num2, size.Height + num);
            Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(this.ThumbnailCallBack);
            Image image2 = image.GetThumbnailImage(size.Width, size.Height, callback, IntPtr.Zero);
            this.pictureBox1.Image = image2;
        }

        public string ImageName
        {
            get
            {
                return this.imageName;
            }
        }

        public bool Selected
        {
            get
            {
                return (this.BackColor == Color.WhiteSmoke);
            }
            set
            {
                if (this.Selected != value)
                {
                    this.BackColor = value ? Color.WhiteSmoke : Color.Transparent;
                    base.BorderStyle = value ? BorderStyle.FixedSingle : BorderStyle.None;
                    if (value)
                    {
                        this.ThumbnailClicked(this.label1.Text);
                    }
                }
            }
        }
    }
}

