namespace CJBasic.Widget
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public class CaptureScreenForm : Form
    {
        private Image backImage;
        private IContainer components;
        private Point? end;
        private Pen pen;
        private SolidBrush solidBrush;
        private Point? start;
        private Point? tempEnd;
        private string theTip;
        private ToolTip toolTip1;

        public CaptureScreenForm() : this(null)
        {
        }

        public CaptureScreenForm(string tip)
        {
            this.start = null;
            this.end = null;
            this.tempEnd = null;
            this.pen = new Pen(Color.LightSkyBlue, 2f);
            this.solidBrush = new SolidBrush(Color.FromArgb(90, Color.FromArgb(0xe5, 0xf3, 0xfb)));
            this.components = null;
            this.InitializeComponent();
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.theTip = tip;
            this.BackgroundImage = this.GetDesktopImage();
            this.ShowTip();
        }

        private void CaptureScreenForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                base.DialogResult = DialogResult.Cancel;
            }
        }

        private void CaptureScreenForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                base.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.start = new Point?(e.Location);
            }
        }

        private void CaptureScreenForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.start.HasValue)
            {
                this.ShowTip();
            }
            else
            {
                this.tempEnd = new Point?(e.Location);
                this.Refresh();
            }
        }

        private void CaptureScreenForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.end = new Point?(e.Location);
                if ((this.CaptureRegion.Width < 8) || (this.CaptureRegion.Height < 8))
                {
                    base.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    base.DialogResult = DialogResult.OK;
                }
            }
        }

        private void CaptureScreenForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.start.HasValue && this.tempEnd.HasValue)
            {
                e.Graphics.DrawRectangle(this.pen, this.TempCaptureRegion);
                e.Graphics.FillRectangle(this.solidBrush, this.TempCaptureRegion);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Image GetDesktopImage()
        {
            Rectangle bounds = Screen.GetBounds(this);
            Bitmap image = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics.FromImage(image).CopyFromScreen(bounds.Location, new Point(0, 0), bounds.Size);
            return image;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.toolTip1 = new ToolTip(this.components);
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2b9, 0x22f);
            base.ControlBox = false;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "CaptureScreenForm";
            base.ShowInTaskbar = false;
            base.TopMost = true;
            base.WindowState = FormWindowState.Maximized;
            base.Paint += new PaintEventHandler(this.CaptureScreenForm_Paint);
            base.KeyDown += new KeyEventHandler(this.CaptureScreenForm_KeyDown);
            base.MouseDown += new MouseEventHandler(this.CaptureScreenForm_MouseDown);
            base.MouseMove += new MouseEventHandler(this.CaptureScreenForm_MouseMove);
            base.MouseUp += new MouseEventHandler(this.CaptureScreenForm_MouseUp);
            base.ResumeLayout(false);
        }

        private void ShowTip()
        {
            if (!string.IsNullOrEmpty(this.theTip))
            {
                this.toolTip1.SetToolTip(this, this.theTip);
            }
        }

        public Rectangle CaptureRegion
        {
            get
            {
                int x = this.start.Value.X;
                int y = this.start.Value.Y;
                if (x > this.end.Value.X)
                {
                    x = this.end.Value.X;
                }
                if (y > this.end.Value.Y)
                {
                    y = this.end.Value.Y;
                }
                int width = Math.Abs((int) (this.start.Value.X - this.end.Value.X));
                return new Rectangle(new Point(x, y), new Size(width, Math.Abs((int) (this.start.Value.Y - this.end.Value.Y))));
            }
        }

        private Rectangle TempCaptureRegion
        {
            get
            {
                int x = this.start.Value.X;
                int y = this.start.Value.Y;
                if (x > this.tempEnd.Value.X)
                {
                    x = this.tempEnd.Value.X;
                }
                if (y > this.tempEnd.Value.Y)
                {
                    y = this.tempEnd.Value.Y;
                }
                int width = Math.Abs((int) (this.start.Value.X - this.tempEnd.Value.X));
                return new Rectangle(new Point(x, y), new Size(width, Math.Abs((int) (this.start.Value.Y - this.tempEnd.Value.Y))));
            }
        }
    }
}

