namespace CJBasic.Widget
{
    using CJBasic;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class AgileProgressBar : UserControl
    {
        private IContainer components = null;
        private Label label1;
        private ProgressBar progressBar1;
        private int total = 10;

        public AgileProgressBar()
        {
            this.InitializeComponent();
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
            this.progressBar1 = new ProgressBar();
            this.label1 = new Label();
            base.SuspendLayout();
            this.progressBar1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.progressBar1.BackColor = SystemColors.Window;
            this.progressBar1.ForeColor = Color.Green;
            this.progressBar1.Location = new Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(0x7a, 0x16);
            this.progressBar1.TabIndex = 0;
            this.label1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label1.Location = new Point(0x83, 3);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x24, 0x16);
            this.label1.TabIndex = 1;
            this.label1.Text = "0%";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.label1);
            base.Controls.Add(this.progressBar1);
            base.Name = "AgileProgressBar";
            base.Size = new Size(170, 0x1d);
            base.ResumeLayout(false);
        }

        public void MessageBoxShow(string msg)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new CbSimpleStr(this.MessageBoxShow), new object[] { msg });
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        public void SetProgress(int val)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new CbSimpleInt(this.SetProgress), new object[] { val });
            }
            else
            {
                this.progressBar1.Maximum = this.total;
                this.progressBar1.Value = val;
                int num = (val * 0x3e8) / this.total;
                this.label1.Text = ((((double) num) / 10.0)).ToString() + "%";
            }
        }

        public int Total
        {
            get
            {
                return this.total;
            }
            set
            {
                this.total = value;
            }
        }
    }
}

