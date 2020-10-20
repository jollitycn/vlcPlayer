namespace CJBasic.Widget
{
    using CJBasic;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class ColorChooser : UserControl
    {
        private Button button_color;
        private Button button_currentColor;
        private ColorDialog colorDialog1;
        private IContainer components = null;

        public event CbGeneric<Color> ColorSelected;

        public event CbGeneric<Color> CurrentColorClicked;

        public ColorChooser()
        {
            this.InitializeComponent();
            this.ColorSelected += delegate {
            };
            this.CurrentColorClicked += delegate {
            };
        }

        private void button_color_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = this.CurrentColor;
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.button_currentColor.BackColor = this.colorDialog1.Color;
                this.ColorSelected(this.colorDialog1.Color);
            }
        }

        private void button_currentColor_Click(object sender, EventArgs e)
        {
            this.CurrentColorClicked(this.button_currentColor.BackColor);
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ColorChooser));
            this.button_color = new Button();
            this.colorDialog1 = new ColorDialog();
            this.button_currentColor = new Button();
            base.SuspendLayout();
            this.button_color.BackgroundImage = (Image) manager.GetObject("button_color.BackgroundImage");
            this.button_color.BackgroundImageLayout = ImageLayout.None;
            this.button_color.FlatAppearance.BorderSize = 0;
            this.button_color.FlatStyle = FlatStyle.Flat;
            this.button_color.Location = new Point(12, 1);
            this.button_color.Name = "button_color";
            this.button_color.Size = new Size(0x16, 0x15);
            this.button_color.TabIndex = 1;
            this.button_color.UseVisualStyleBackColor = true;
            this.button_color.Click += new EventHandler(this.button_color_Click);
            this.colorDialog1.AnyColor = true;
            this.button_currentColor.BackColor = Color.Black;
            this.button_currentColor.FlatAppearance.BorderSize = 0;
            this.button_currentColor.FlatStyle = FlatStyle.Flat;
            this.button_currentColor.Location = new Point(0, 4);
            this.button_currentColor.Name = "button_currentColor";
            this.button_currentColor.Size = new Size(13, 13);
            this.button_currentColor.TabIndex = 2;
            this.button_currentColor.UseVisualStyleBackColor = false;
            this.button_currentColor.Click += new EventHandler(this.button_currentColor_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Transparent;
            base.Controls.Add(this.button_currentColor);
            base.Controls.Add(this.button_color);
            base.Name = "ColorChooser";
            base.Size = new Size(0x20, 20);
            base.ResumeLayout(false);
        }

        public Color CurrentColor
        {
            get
            {
                return this.button_currentColor.BackColor;
            }
            set
            {
                this.button_currentColor.BackColor = value;
            }
        }
    }
}

