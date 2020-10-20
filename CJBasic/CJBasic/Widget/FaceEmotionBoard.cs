namespace CJBasic.Widget
{
    using CJBasic;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class FaceEmotionBoard : UserControl
    {
        private IContainer components = null;
        private int countPerLine = 15;
        private int imageLength = 0x18;
        private IList<Image> imageList = new List<Image>();
        private int span = 4;
        private ToolTip toolTip1;
        private Rectangle validRegion;

        public event CbSimpleInt EmotionClicked;

        public FaceEmotionBoard()
        {
            this.InitializeComponent();
            this.EmotionClicked += delegate {
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

        private void FaceEmotionBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int emotionIndex = this.GetEmotionIndex(e.Location);
            if (emotionIndex >= 0)
            {
                this.EmotionClicked(emotionIndex);
            }
        }

        private void FaceEmotionBoard_MouseHover(object sender, EventArgs e)
        {
        }

        private int GetEmotionIndex(Point pt)
        {
            if (!this.validRegion.Contains(pt))
            {
                return -1;
            }
            int num = (pt.X - this.span) / (this.imageLength + this.span);
            int num2 = (pt.Y - this.span) / (this.imageLength + this.span);
            return ((num2 * this.countPerLine) + num);
        }

        public void Initialize(IList<Image> _imageList)
        {
            this.imageList = _imageList;
            int num = this.imageList.Count / this.countPerLine;
            num += ((this.imageList.Count % this.countPerLine) == 0) ? 0 : 1;
            this.validRegion = new Rectangle(new Point(0, 0), new Size(this.countPerLine * (this.span + this.imageLength), num * (this.span + this.imageLength)));
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.toolTip1 = new ToolTip(this.components);
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.Name = "FaceEmotionBoard";
            base.Size = new Size(0x18d, 0x10b);
            base.MouseClick += new MouseEventHandler(this.FaceEmotionBoard_MouseClick);
            base.MouseHover += new EventHandler(this.FaceEmotionBoard_MouseHover);
            base.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int num2;
            base.OnPaint(e);
            int num = this.imageList.Count / this.countPerLine;
            num += ((this.imageList.Count % this.countPerLine) == 0) ? 0 : 1;
            Pen pen = new Pen(Color.LightSkyBlue);
            for (num2 = 0; num2 <= this.countPerLine; num2++)
            {
                e.Graphics.DrawLine(pen, new Point(num2 * (this.imageLength + this.span), 0), new Point(num2 * (this.imageLength + this.span), num * (this.imageLength + this.span)));
            }
            for (num2 = 0; num2 <= num; num2++)
            {
                e.Graphics.DrawLine(pen, new Point(0, num2 * (this.imageLength + this.span)), new Point((this.imageLength + this.span) * this.countPerLine, num2 * (this.imageLength + this.span)));
            }
            for (num2 = 0; num2 < this.imageList.Count; num2++)
            {
                int num3 = num2 / this.countPerLine;
                int num4 = num2 % this.countPerLine;
                e.Graphics.DrawImage(this.imageList[num2], new Point((num4 * (this.imageLength + this.span)) + this.span, (num3 * (this.imageLength + this.span)) + this.span));
            }
        }

        public int CountPerLine
        {
            get
            {
                return this.countPerLine;
            }
            set
            {
                this.countPerLine = value;
            }
        }

        public int ImageLength
        {
            get
            {
                return this.imageLength;
            }
            set
            {
                this.imageLength = value;
            }
        }

        public int Span
        {
            get
            {
                return this.span;
            }
            set
            {
                this.span = value;
            }
        }
    }
}

