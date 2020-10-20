namespace CJBasic.Widget
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ColorChooseForm : Form
    {
        private Button button1;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Color colorChoosed = Color.White;
        private string colorName = "白";
        private IContainer components = null;
        private ToolTip toolTip1;

        public ColorChooseForm()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button control = (Button) sender;
            this.colorChoosed = control.BackColor;
            this.colorName = this.toolTip1.GetToolTip(control);
            base.DialogResult = DialogResult.OK;
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
            this.components = new Container();
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.button4 = new Button();
            this.button5 = new Button();
            this.button6 = new Button();
            this.button7 = new Button();
            this.button8 = new Button();
            this.button9 = new Button();
            this.button10 = new Button();
            this.button11 = new Button();
            this.button12 = new Button();
            this.button13 = new Button();
            this.button14 = new Button();
            this.button15 = new Button();
            this.button16 = new Button();
            this.toolTip1 = new ToolTip(this.components);
            base.SuspendLayout();
            this.button1.BackColor = Color.Black;
            this.button1.Location = new Point(0x2a, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x18, 0x18);
            this.button1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button1, "黑");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.BackColor = Color.White;
            this.button2.Location = new Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x18, 0x18);
            this.button2.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button2, "白");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new EventHandler(this.button1_Click);
            this.button3.BackColor = Color.Gray;
            this.button3.Location = new Point(0x48, 12);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x18, 0x18);
            this.button3.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button3, "灰");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new EventHandler(this.button1_Click);
            this.button4.BackColor = Color.Transparent;
            this.button4.Location = new Point(0x66, 12);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x18, 0x18);
            this.button4.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button4, "透明");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new EventHandler(this.button1_Click);
            this.button5.BackColor = Color.Orange;
            this.button5.Location = new Point(0x66, 0x48);
            this.button5.Name = "button5";
            this.button5.Size = new Size(0x18, 0x18);
            this.button5.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button5, "橙");
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new EventHandler(this.button1_Click);
            this.button6.BackColor = Color.Yellow;
            this.button6.Location = new Point(0x66, 0x2a);
            this.button6.Name = "button6";
            this.button6.Size = new Size(0x18, 0x18);
            this.button6.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button6, "黄");
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new EventHandler(this.button1_Click);
            this.button7.BackColor = Color.Blue;
            this.button7.Location = new Point(0x2a, 0x2a);
            this.button7.Name = "button7";
            this.button7.Size = new Size(0x18, 0x18);
            this.button7.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button7, "蓝");
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new EventHandler(this.button1_Click);
            this.button8.BackColor = Color.Purple;
            this.button8.Location = new Point(12, 0x48);
            this.button8.Name = "button8";
            this.button8.Size = new Size(0x18, 0x18);
            this.button8.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button8, "紫");
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new EventHandler(this.button1_Click);
            this.button9.BackColor = Color.Green;
            this.button9.Location = new Point(0x48, 0x2a);
            this.button9.Name = "button9";
            this.button9.Size = new Size(0x18, 0x18);
            this.button9.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button9, "绿");
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new EventHandler(this.button1_Click);
            this.button10.BackColor = Color.Brown;
            this.button10.Location = new Point(0x2a, 0x48);
            this.button10.Name = "button10";
            this.button10.Size = new Size(0x18, 0x18);
            this.button10.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button10, "棕");
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new EventHandler(this.button1_Click);
            this.button11.BackColor = Color.SkyBlue;
            this.button11.Location = new Point(0x48, 0x48);
            this.button11.Name = "button11";
            this.button11.Size = new Size(0x18, 0x18);
            this.button11.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button11, "浅蓝");
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new EventHandler(this.button1_Click);
            this.button12.BackColor = Color.DeepSkyBlue;
            this.button12.Location = new Point(0x66, 0x66);
            this.button12.Name = "button12";
            this.button12.Size = new Size(0x18, 0x18);
            this.button12.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button12, "天蓝");
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new EventHandler(this.button1_Click);
            this.button13.BackColor = Color.LightGreen;
            this.button13.Location = new Point(12, 0x66);
            this.button13.Name = "button13";
            this.button13.Size = new Size(0x18, 0x18);
            this.button13.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button13, "浅绿");
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new EventHandler(this.button1_Click);
            this.button14.BackColor = Color.Pink;
            this.button14.Location = new Point(0x2a, 0x66);
            this.button14.Name = "button14";
            this.button14.Size = new Size(0x18, 0x18);
            this.button14.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button14, "粉红");
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new EventHandler(this.button1_Click);
            this.button15.BackColor = Color.Turquoise;
            this.button15.Location = new Point(0x47, 0x66);
            this.button15.Name = "button15";
            this.button15.Size = new Size(0x18, 0x18);
            this.button15.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button15, "青绿");
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new EventHandler(this.button1_Click);
            this.button16.BackColor = Color.Red;
            this.button16.Location = new Point(12, 0x2a);
            this.button16.Name = "button16";
            this.button16.Size = new Size(0x18, 0x18);
            this.button16.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button16, "红");
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Control;
            base.ClientSize = new Size(0x8d, 0x8d);
            base.Controls.Add(this.button16);
            base.Controls.Add(this.button15);
            base.Controls.Add(this.button14);
            base.Controls.Add(this.button13);
            base.Controls.Add(this.button12);
            base.Controls.Add(this.button11);
            base.Controls.Add(this.button10);
            base.Controls.Add(this.button9);
            base.Controls.Add(this.button8);
            base.Controls.Add(this.button7);
            base.Controls.Add(this.button6);
            base.Controls.Add(this.button5);
            base.Controls.Add(this.button4);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ColorChooseForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "选择颜色";
            base.ResumeLayout(false);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                base.DialogResult = DialogResult.Cancel;
            }
            return base.ProcessDialogKey(keyData);
        }

        public Color ColorChoosed
        {
            get
            {
                return this.colorChoosed;
            }
        }

        public string ColorName
        {
            get
            {
                return this.colorName;
            }
        }
    }
}

