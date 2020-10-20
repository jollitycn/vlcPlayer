namespace CJBasic.Widget
{
    using CJBasic;
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class TimerLabel : Label
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int totalSeconds = 0;

        public event CbGeneric SecondTick;

        public TimerLabel()
        {
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.UpdateStyles();
            this.BackColor = Color.Transparent;
            this.Text = "00:00";
            this.timer.Interval = 0x3e8;
            this.timer.Tick += new EventHandler(this.timer_Tick);
        }

        public void Reset()
        {
            this.timer.Stop();
            this.totalSeconds = 0;
            this.Text = "00:00";
        }

        public void Start()
        {
            this.Text = "00:00";
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.totalSeconds++;
            int num = this.totalSeconds / 60;
            num = this.totalSeconds % 60;
            string introduced2 = num.ToString("00");
            this.Text = string.Format("{0}:{1}", introduced2, num.ToString("00"));
            if (this.SecondTick != null)
            {
                this.SecondTick();
            }
        }

        public bool IsWorking
        {
            get
            {
                return this.timer.Enabled;
            }
        }

        public int TotalSeconds
        {
            get
            {
                return this.totalSeconds;
            }
        }
    }
}

