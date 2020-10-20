using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

using System.Text;


namespace JGNet.Common.Components
{
    public partial class BaseButton : SkinButton
    {
        public BaseButton()
        {
            InitializeComponent();
            this.Leave += BaseButton_Leave;
            this.KeyDown += BaseButton_KeyDown;
          this.KeyUp += BaseButton_KeyUp;
            this.MouseLeave += BaseButton_MouseLeave;
            this.MouseUp += BaseButton_MouseUp;

            this.DrawType = CCWin.SkinControl.DrawStyle.Img; 
            this.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
        }

        private void BaseButton_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.BackgroundImage = this.MouseBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BaseColor = this.MouseBaseColor;
        }

        private void BaseButton_MouseLeave(object sender, EventArgs e)
        {
            Narmal();
        }

        private void BaseButton_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            Focus();
        }

        private void BaseButton_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            this.BackgroundImage = this.DownBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BaseColor = this.DownBaseColor;
        }

        private void BaseButton_Leave(object sender, EventArgs e)
        {
            Narmal(); 
        }

        private void Narmal()
        {
            this.BackgroundImage = this.NormlBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BaseColor = Color.FromArgb(9, 163, 220);
        }

        protected void UnLockPage()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric(this.UnLockPage));
            }
            else
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }

        protected void ShowError(Exception ex)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<Exception>(this.ShowError), ex);
            }
            else
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        protected void ShowMessage(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<string>(this.ShowMessage), msg);
            }
            else
            {
                GlobalMessageBox.Show(this.FindForm(), msg);
            }
        }



    }
}
