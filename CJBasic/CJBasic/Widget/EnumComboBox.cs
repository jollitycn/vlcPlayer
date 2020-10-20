namespace CJBasic.Widget
{
    using CJBasic;
    using CJBasic.Helpers;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class EnumComboBox : UserControl
    {
        private ComboBox comboBox1;
        private IContainer components = null;
        private System.Type dataSource;
        private bool useEnumDescription = false;

        public event CbSimple SelectedIndexChanged;

        public EnumComboBox()
        {
            this.InitializeComponent();
            this.SelectedIndexChanged += delegate {
            };
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIndexChanged();
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
            this.comboBox1 = new ComboBox();
            base.SuspendLayout();
            this.comboBox1.Dock = DockStyle.Fill;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0x6c, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.comboBox1);
            base.Name = "EnumComboBox";
            base.Size = new Size(0x6c, 0x13);
            base.ResumeLayout(false);
        }

        public System.Type DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                if (value == null)
                {
                    this.dataSource = null;
                    this.comboBox1.DataSource = null;
                }
                else
                {
                    if (!value.IsEnum)
                    {
                        throw new Exception("DataSource Must be Enum Type !");
                    }
                    this.dataSource = value;
                    this.comboBox1.DataSource = this.useEnumDescription ? ((object) EnumHelper.ConvertEnumToFieldDescriptionList(this.dataSource)) : ((object) Enum.GetValues(value));
                    this.comboBox1.SelectedIndex = 0;
                }
            }
        }

        public object SelectedValue
        {
            get
            {
                if (this.comboBox1.SelectedItem == null)
                {
                    return null;
                }
                return (this.useEnumDescription ? EnumHelper.ParseEnumValue(this.dataSource, this.comboBox1.SelectedItem.ToString()) : Enum.Parse(this.dataSource, this.comboBox1.SelectedItem.ToString()));
            }
            set
            {
                if ((value != null) && (value.GetType() == this.dataSource))
                {
                    if (this.useEnumDescription)
                    {
                        string fieldText = EnumDescription.GetFieldText(value);
                        if (fieldText == null)
                        {
                            this.comboBox1.Text = value.ToString();
                        }
                        else
                        {
                            this.comboBox1.Text = fieldText;
                        }
                    }
                    else
                    {
                        this.comboBox1.Text = value.ToString();
                    }
                }
            }
        }

        public bool UseEnumDescription
        {
            get
            {
                return this.useEnumDescription;
            }
            set
            {
                this.useEnumDescription = value;
            }
        }
    }
}

