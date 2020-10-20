using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common.Components
{
    public partial class AddCorssComboBoxForm : 
        BaseForm
    {
        private String result;
        public String Result { get { return result; } } 

        public AddCorssComboBoxForm(string labelName)
        {
            InitializeComponent();
            //this.DialogResult = DialogResult.No;
            //this.skinTextBoxValue.Focus(); 
            skinLabel.Text = labelName + "：";
            this.skinTextBoxValue.SkinTxt.KeyDown += SkinTxt_KeyDown;
        }

        private void SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BaseButton1_Click(null, null);
            }
        }

        private void BaseButton1_Click(object sender, EventArgs e)
        {
            this.result = this.skinTextBoxValue.SkinTxt.Text.Trim();
            if (String.IsNullOrEmpty(result))
            {
                this.skinTextBoxValue.Focus();
                return;
            }
                this.DialogResult = DialogResult.OK;

        }
         
         

        private void AddCorssComboBoxForm_Shown(object sender, EventArgs e)
        {
            //this.skinTextBoxValue.Text = "";
            //this.skinTextBoxValue.Select();
            //this.skinTextBoxValue.Focus();
        }
 
    }
}
