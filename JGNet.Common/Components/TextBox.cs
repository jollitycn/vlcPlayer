using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using CCWin;

namespace JGNet.Common
{
    public partial class TextBox : SkinTextBox
    {
        private Boolean toogleTextSlection;
        public TextBox()
        {
            InitializeComponent();
            base.SkinTxt.KeyPress += SkinTxt_KeyPress; 
        }
         
        private void SkinTxt_MouseClick(object sender, MouseEventArgs e)
        {
            //725 输入框内，自动全选后，再点击取消全选状态，自动定位在光标处
            if (toogleTextSlection)
            {
                toogleTextSlection = false;
            }
            else
            {
                this.SkinTxt.SelectAll();
                toogleTextSlection = true;
            }
        }

        private void SkinTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //取消登登登
            if (e.KeyChar == Convert.ToChar(13))
            {
                e.Handled = true;
            }
        }
    }
}
