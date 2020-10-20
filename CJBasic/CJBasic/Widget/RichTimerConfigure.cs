namespace CJBasic.Widget
{
    using CJBasic;
    using CJBasic.Threading.Timers.RichTimer;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class RichTimerConfigure : UserControl, ITimerConfigure
    {
        private string activityName = "活动";
        private ComboBox comboBox_week;
        private IContainer components = null;
        private EnumComboBox enumComboBox_timerType;
        private Label label_span;
        private Label label_time;
        private Label label_timerType;
        private Label label1;
        private Label label10;
        private Label label2;
        private Label label3;
        private Label label8;
        private Label label9;
        private NumericUpDown numericUpDown_day;
        private NumericUpDown numericUpDown_hours;
        private NumericUpDown numericUpDown_mins;
        private NumericUpDown numericUpDown_spanhour;
        private NumericUpDown numericUpDown_spanmins;

        public RichTimerConfigure()
        {
            this.InitializeComponent();
            this.enumComboBox_timerType.DataSource = typeof(RichTimerType);
            this.enumComboBox_timerType.SelectedValue = RichTimerType.None;
            this.comboBox_week.SelectedIndex = 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void enumComboBox_timerType_SelectedIndexChanged()
        {
            switch (((RichTimerType) this.enumComboBox_timerType.SelectedValue))
            {
                case RichTimerType.None:
                    this.numericUpDown_day.Enabled = false;
                    this.comboBox_week.Enabled = false;
                    this.numericUpDown_hours.Enabled = false;
                    this.numericUpDown_mins.Enabled = false;
                    this.numericUpDown_spanhour.Enabled = false;
                    this.numericUpDown_spanmins.Enabled = false;
                    this.numericUpDown_day.Value = 1M;
                    this.comboBox_week.Text = "天";
                    this.numericUpDown_hours.Value = 0M;
                    this.numericUpDown_mins.Value = 0M;
                    this.numericUpDown_spanhour.Value = 0M;
                    this.numericUpDown_spanmins.Value = 0M;
                    break;

                case RichTimerType.PerHour:
                    this.numericUpDown_day.Enabled = false;
                    this.comboBox_week.Enabled = false;
                    this.numericUpDown_hours.Enabled = false;
                    this.numericUpDown_mins.Enabled = true;
                    this.numericUpDown_spanhour.Enabled = false;
                    this.numericUpDown_spanmins.Enabled = false;
                    this.numericUpDown_day.Value = 1M;
                    this.comboBox_week.Text = "天";
                    this.numericUpDown_hours.Value = 0M;
                    this.numericUpDown_mins.Value = 0M;
                    this.numericUpDown_spanhour.Value = 0M;
                    this.numericUpDown_spanmins.Value = 0M;
                    break;

                case RichTimerType.PerDay:
                    this.numericUpDown_day.Enabled = false;
                    this.comboBox_week.Enabled = false;
                    this.numericUpDown_hours.Enabled = true;
                    this.numericUpDown_mins.Enabled = true;
                    this.numericUpDown_spanhour.Enabled = false;
                    this.numericUpDown_spanmins.Enabled = false;
                    this.numericUpDown_day.Value = 1M;
                    this.comboBox_week.Text = "天";
                    this.numericUpDown_hours.Value = 0M;
                    this.numericUpDown_mins.Value = 0M;
                    this.numericUpDown_spanhour.Value = 0M;
                    this.numericUpDown_spanmins.Value = 0M;
                    break;

                case RichTimerType.PerWeek:
                    this.numericUpDown_day.Enabled = false;
                    this.comboBox_week.Enabled = true;
                    this.numericUpDown_hours.Enabled = true;
                    this.numericUpDown_mins.Enabled = true;
                    this.numericUpDown_spanhour.Enabled = false;
                    this.numericUpDown_spanmins.Enabled = false;
                    this.numericUpDown_day.Value = 1M;
                    this.comboBox_week.Text = "天";
                    this.numericUpDown_hours.Value = 0M;
                    this.numericUpDown_mins.Value = 0M;
                    this.numericUpDown_spanhour.Value = 0M;
                    this.numericUpDown_spanmins.Value = 0M;
                    break;

                case RichTimerType.PerMonth:
                    this.numericUpDown_day.Enabled = true;
                    this.comboBox_week.Enabled = false;
                    this.numericUpDown_hours.Enabled = true;
                    this.numericUpDown_mins.Enabled = true;
                    this.numericUpDown_spanhour.Enabled = false;
                    this.numericUpDown_spanmins.Enabled = false;
                    this.numericUpDown_day.Value = 1M;
                    this.comboBox_week.Text = "天";
                    this.numericUpDown_hours.Value = 0M;
                    this.numericUpDown_mins.Value = 0M;
                    this.numericUpDown_spanhour.Value = 0M;
                    this.numericUpDown_spanmins.Value = 0M;
                    break;

                case RichTimerType.EverySpan:
                    this.numericUpDown_day.Enabled = false;
                    this.comboBox_week.Enabled = false;
                    this.numericUpDown_hours.Enabled = false;
                    this.numericUpDown_mins.Enabled = false;
                    this.numericUpDown_spanhour.Enabled = true;
                    this.numericUpDown_spanmins.Enabled = true;
                    this.numericUpDown_day.Value = 1M;
                    this.comboBox_week.Text = "天";
                    this.numericUpDown_hours.Value = 0M;
                    this.numericUpDown_mins.Value = 0M;
                    this.numericUpDown_spanhour.Value = 0M;
                    this.numericUpDown_spanmins.Value = 0M;
                    break;
            }
        }

        private CJBasic.Threading.Timers.RichTimer.TimerConfiguration GetTimerConfiguration()
        {
            CJBasic.Threading.Timers.RichTimer.TimerConfiguration configuration = null;
            switch (((RichTimerType) this.enumComboBox_timerType.SelectedValue))
            {
                case RichTimerType.None:
                    return null;

                case RichTimerType.PerHour:
                    configuration = new CJBasic.Threading.Timers.RichTimer.TimerConfiguration();
                    configuration.RichTimerType = RichTimerType.PerHour;
                    configuration.Hour = (int) this.numericUpDown_hours.Value;
                    configuration.Minute = (int) this.numericUpDown_mins.Value;
                    return configuration;

                case RichTimerType.PerDay:
                    configuration = new CJBasic.Threading.Timers.RichTimer.TimerConfiguration();
                    configuration.RichTimerType = RichTimerType.PerDay;
                    configuration.Hour = (int) this.numericUpDown_hours.Value;
                    configuration.Minute = (int) this.numericUpDown_mins.Value;
                    return configuration;

                case RichTimerType.PerWeek:
                    configuration = new CJBasic.Threading.Timers.RichTimer.TimerConfiguration();
                    configuration.RichTimerType = RichTimerType.PerWeek;
                    configuration.DayOfWeek = this.comboBox_week.SelectedIndex;
                    configuration.Hour = (int) this.numericUpDown_hours.Value;
                    configuration.Minute = (int) this.numericUpDown_mins.Value;
                    return configuration;

                case RichTimerType.PerMonth:
                    configuration = new CJBasic.Threading.Timers.RichTimer.TimerConfiguration();
                    configuration.RichTimerType = RichTimerType.PerMonth;
                    configuration.Day = (int) this.numericUpDown_day.Value;
                    configuration.Hour = (int) this.numericUpDown_hours.Value;
                    configuration.Minute = (int) this.numericUpDown_mins.Value;
                    return configuration;

                case RichTimerType.EverySpan:
                    configuration = new CJBasic.Threading.Timers.RichTimer.TimerConfiguration();
                    configuration.RichTimerType = RichTimerType.EverySpan;
                    configuration.Hour = (int) this.numericUpDown_spanhour.Value;
                    configuration.Minute = (int) this.numericUpDown_spanmins.Value;
                    return configuration;
            }
            return null;
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label_timerType = new Label();
            this.numericUpDown_hours = new NumericUpDown();
            this.numericUpDown_mins = new NumericUpDown();
            this.label_time = new Label();
            this.numericUpDown_spanmins = new NumericUpDown();
            this.numericUpDown_day = new NumericUpDown();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.numericUpDown_spanhour = new NumericUpDown();
            this.label_span = new Label();
            this.comboBox_week = new ComboBox();
            this.enumComboBox_timerType = new EnumComboBox();
            this.numericUpDown_hours.BeginInit();
            this.numericUpDown_mins.BeginInit();
            this.numericUpDown_spanmins.BeginInit();
            this.numericUpDown_day.BeginInit();
            this.numericUpDown_spanhour.BeginInit();
            base.SuspendLayout();
            this.label1.Location = new Point(0x21, 0x36);
            this.label1.Name = "label1";
            this.label1.Size = new Size(40, 0x15);
            this.label1.TabIndex = 10;
            this.label1.Text = "小时";
            this.label1.TextAlign = ContentAlignment.MiddleRight;
            this.label2.Location = new Point(0xaf, 0x36);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x27, 0x15);
            this.label2.TabIndex = 11;
            this.label2.Text = "分钟";
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            this.label3.Location = new Point(0xaf, 0x51);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x27, 0x15);
            this.label3.TabIndex = 12;
            this.label3.Text = "星期";
            this.label3.TextAlign = ContentAlignment.MiddleRight;
            this.label_timerType.Location = new Point(3, 8);
            this.label_timerType.Name = "label_timerType";
            this.label_timerType.Size = new Size(70, 20);
            this.label_timerType.TabIndex = 14;
            this.label_timerType.Text = "活动频率：";
            this.label_timerType.TextAlign = ContentAlignment.MiddleRight;
            this.numericUpDown_hours.Location = new Point(0x4f, 0x36);
            int[] bits = new int[4];
            bits[0] = 0x17;
            this.numericUpDown_hours.Maximum = new decimal(bits);
            this.numericUpDown_hours.Name = "numericUpDown_hours";
            this.numericUpDown_hours.Size = new Size(0x63, 0x15);
            this.numericUpDown_hours.TabIndex = 0x11;
            this.numericUpDown_mins.Location = new Point(220, 0x36);
            bits = new int[4];
            bits[0] = 0x3b;
            this.numericUpDown_mins.Maximum = new decimal(bits);
            this.numericUpDown_mins.Name = "numericUpDown_mins";
            this.numericUpDown_mins.Size = new Size(0x63, 0x15);
            this.numericUpDown_mins.TabIndex = 0x12;
            this.label_time.Location = new Point(3, 0x20);
            this.label_time.Name = "label_time";
            this.label_time.Size = new Size(70, 20);
            this.label_time.TabIndex = 0x13;
            this.label_time.Text = "活动时刻：";
            this.label_time.TextAlign = ContentAlignment.MiddleRight;
            this.numericUpDown_spanmins.Location = new Point(220, 0x84);
            bits = new int[4];
            bits[0] = 0x3b;
            this.numericUpDown_spanmins.Maximum = new decimal(bits);
            this.numericUpDown_spanmins.Name = "numericUpDown_spanmins";
            this.numericUpDown_spanmins.Size = new Size(0x63, 0x15);
            this.numericUpDown_spanmins.TabIndex = 0x15;
            this.numericUpDown_day.Location = new Point(0x4f, 0x51);
            bits = new int[4];
            bits[0] = 0x1f;
            this.numericUpDown_day.Maximum = new decimal(bits);
            bits = new int[4];
            bits[0] = 1;
            this.numericUpDown_day.Minimum = new decimal(bits);
            this.numericUpDown_day.Name = "numericUpDown_day";
            this.numericUpDown_day.Size = new Size(0x63, 0x15);
            this.numericUpDown_day.TabIndex = 0x17;
            bits = new int[4];
            bits[0] = 1;
            this.numericUpDown_day.Value = new decimal(bits);
            this.label8.Location = new Point(0x22, 0x51);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x27, 0x15);
            this.label8.TabIndex = 0x16;
            this.label8.Text = "日期";
            this.label8.TextAlign = ContentAlignment.MiddleRight;
            this.label9.Location = new Point(0x22, 0x84);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x27, 0x15);
            this.label9.TabIndex = 0x18;
            this.label9.Text = "小时";
            this.label9.TextAlign = ContentAlignment.MiddleRight;
            this.label10.Location = new Point(0xaf, 0x84);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x27, 0x15);
            this.label10.TabIndex = 0x19;
            this.label10.Text = "分钟";
            this.label10.TextAlign = ContentAlignment.MiddleRight;
            this.numericUpDown_spanhour.Location = new Point(0x4f, 0x84);
            bits = new int[4];
            bits[0] = 0x17;
            this.numericUpDown_spanhour.Maximum = new decimal(bits);
            this.numericUpDown_spanhour.Name = "numericUpDown_spanhour";
            this.numericUpDown_spanhour.Size = new Size(0x63, 0x15);
            this.numericUpDown_spanhour.TabIndex = 0x1b;
            this.label_span.Location = new Point(2, 0x6a);
            this.label_span.Name = "label_span";
            this.label_span.Size = new Size(70, 20);
            this.label_span.TabIndex = 0x1d;
            this.label_span.Text = "活动周期：";
            this.label_span.TextAlign = ContentAlignment.MiddleRight;
            this.comboBox_week.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox_week.FormattingEnabled = true;
            this.comboBox_week.Items.AddRange(new object[] { "天", "一", "二", "三", "四", "五", "六" });
            this.comboBox_week.Location = new Point(220, 0x52);
            this.comboBox_week.Name = "comboBox_week";
            this.comboBox_week.Size = new Size(0x63, 20);
            this.comboBox_week.TabIndex = 30;
            this.enumComboBox_timerType.DataSource = null;
            this.enumComboBox_timerType.Location = new Point(0x4f, 9);
            this.enumComboBox_timerType.Name = "enumComboBox_timerType";
            this.enumComboBox_timerType.SelectedValue = null;
            this.enumComboBox_timerType.Size = new Size(0x63, 0x13);
            this.enumComboBox_timerType.TabIndex = 0x1f;
            this.enumComboBox_timerType.SelectedIndexChanged += new CbSimple(this.enumComboBox_timerType_SelectedIndexChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.enumComboBox_timerType);
            base.Controls.Add(this.comboBox_week);
            base.Controls.Add(this.label_span);
            base.Controls.Add(this.numericUpDown_spanhour);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.numericUpDown_day);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.numericUpDown_spanmins);
            base.Controls.Add(this.label_time);
            base.Controls.Add(this.numericUpDown_mins);
            base.Controls.Add(this.numericUpDown_hours);
            base.Controls.Add(this.label_timerType);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Name = "TimerConfigure";
            base.Size = new Size(0x147, 0xa1);
            this.numericUpDown_hours.EndInit();
            this.numericUpDown_mins.EndInit();
            this.numericUpDown_spanmins.EndInit();
            this.numericUpDown_day.EndInit();
            this.numericUpDown_spanhour.EndInit();
            base.ResumeLayout(false);
        }

        private void LoadConfig(CJBasic.Threading.Timers.RichTimer.TimerConfiguration config)
        {
            if (config == null)
            {
                this.enumComboBox_timerType.SelectedValue = RichTimerType.None;
                this.numericUpDown_day.Value = 1M;
                this.comboBox_week.Text = "天";
                this.numericUpDown_hours.Value = 0M;
                this.numericUpDown_mins.Value = 0M;
                this.numericUpDown_spanhour.Value = 0M;
                this.numericUpDown_spanmins.Value = 0M;
                this.numericUpDown_day.Enabled = false;
                this.comboBox_week.Enabled = false;
                this.numericUpDown_hours.Enabled = false;
                this.numericUpDown_mins.Enabled = false;
                this.numericUpDown_spanhour.Enabled = false;
                this.numericUpDown_spanmins.Enabled = false;
            }
            else
            {
                this.enumComboBox_timerType.SelectedValue = config.RichTimerType;
                switch (config.RichTimerType)
                {
                    case RichTimerType.PerHour:
                        this.numericUpDown_day.Enabled = false;
                        this.comboBox_week.Enabled = false;
                        this.numericUpDown_hours.Enabled = false;
                        this.numericUpDown_mins.Enabled = true;
                        this.numericUpDown_spanhour.Enabled = false;
                        this.numericUpDown_spanmins.Enabled = false;
                        this.numericUpDown_day.Value = 1M;
                        this.comboBox_week.Text = "天";
                        this.numericUpDown_hours.Value = 0M;
                        this.numericUpDown_mins.Value = config.Minute;
                        this.numericUpDown_spanhour.Value = 0M;
                        this.numericUpDown_spanmins.Value = 0M;
                        break;

                    case RichTimerType.PerDay:
                        this.numericUpDown_day.Enabled = false;
                        this.comboBox_week.Enabled = false;
                        this.numericUpDown_hours.Enabled = true;
                        this.numericUpDown_mins.Enabled = true;
                        this.numericUpDown_spanhour.Enabled = false;
                        this.numericUpDown_spanmins.Enabled = false;
                        this.numericUpDown_day.Value = 1M;
                        this.comboBox_week.Text = "天";
                        this.numericUpDown_hours.Value = config.Hour;
                        this.numericUpDown_mins.Value = config.Minute;
                        this.numericUpDown_spanhour.Value = 0M;
                        this.numericUpDown_spanmins.Value = 0M;
                        break;

                    case RichTimerType.PerWeek:
                        this.numericUpDown_day.Enabled = false;
                        this.comboBox_week.Enabled = true;
                        this.numericUpDown_hours.Enabled = true;
                        this.numericUpDown_mins.Enabled = true;
                        this.numericUpDown_spanhour.Enabled = false;
                        this.numericUpDown_spanmins.Enabled = false;
                        this.numericUpDown_day.Value = 1M;
                        this.comboBox_week.SelectedItem = config.DayOfWeek;
                        this.numericUpDown_hours.Value = config.Hour;
                        this.numericUpDown_mins.Value = config.Minute;
                        this.numericUpDown_spanhour.Value = 0M;
                        this.numericUpDown_spanmins.Value = 0M;
                        break;

                    case RichTimerType.PerMonth:
                        this.numericUpDown_day.Enabled = true;
                        this.comboBox_week.Enabled = false;
                        this.numericUpDown_hours.Enabled = true;
                        this.numericUpDown_mins.Enabled = true;
                        this.numericUpDown_spanhour.Enabled = false;
                        this.numericUpDown_spanmins.Enabled = false;
                        this.numericUpDown_day.Value = config.Day;
                        this.comboBox_week.Text = "天";
                        this.numericUpDown_hours.Value = config.Hour;
                        this.numericUpDown_mins.Value = config.Minute;
                        this.numericUpDown_spanhour.Value = 0M;
                        this.numericUpDown_spanmins.Value = 0M;
                        break;

                    case RichTimerType.EverySpan:
                        this.numericUpDown_day.Value = 1M;
                        this.comboBox_week.Text = "天";
                        this.numericUpDown_hours.Value = 0M;
                        this.numericUpDown_mins.Value = 0M;
                        this.numericUpDown_spanhour.Value = config.Hour;
                        this.numericUpDown_spanmins.Value = config.Minute;
                        this.numericUpDown_day.Enabled = false;
                        this.comboBox_week.Enabled = false;
                        this.numericUpDown_hours.Enabled = false;
                        this.numericUpDown_mins.Enabled = false;
                        this.numericUpDown_spanhour.Enabled = true;
                        this.numericUpDown_spanmins.Enabled = true;
                        break;
                }
            }
        }

        [Description("定时任务的简称"), DefaultValue("活动")]
        public string ActivityName
        {
            get
            {
                return this.activityName;
            }
            set
            {
                this.activityName = value;
                this.label_span.Text = value + "周期：";
                this.label_time.Text = value + "时刻：";
                this.label_timerType.Text = value + "频率：";
            }
        }

        [Browsable(false)]
        public CJBasic.Threading.Timers.RichTimer.TimerConfiguration TimerConfiguration
        {
            get
            {
                return this.GetTimerConfiguration();
            }
            set
            {
                this.LoadConfig(value);
            }
        }
    }
}

