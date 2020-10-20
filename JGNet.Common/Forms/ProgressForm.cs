using CCWin;
using JGNet.Common; 
using CJPlus.Rapid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class ProgressForm : BaseForm
    {
        public Action<ProgressForm> ClosedClick;
        public ProgressForm()
        {
            InitializeComponent();
        }

        public void IniFailed(Exception ex = null)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<Exception>(this.IniFailed),ex);
            }
            else
            {
                if (ex != null)
                {
                    CommonGlobalUtil.WriteLog(ex);
                    GlobalMessageBox.Show(ex.Message, "失败");
                }
                this.UseWaitCursor = false;
                //this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        public void IniCompleted()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.IniCompleted));
            }
            else
            {
                this.progressBar1.Value = this.progressBar1.Maximum;
             //   this.DialogResult = DialogResult.OK;
                this.UseWaitCursor = false;
                this.Close();
            }
        }

        public new void UpdateProgress( string task)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<string>(this.UpdateProgress), task);
            }
            else
            {
                this.skinLabel_TaskName.Text = task + this.progressBar1.Value + "/" + this.progressBar1.Maximum;
                progressBar1.PerformStep();                
            }
        }

        public void IniProgress(int total, string task)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<int,  string>(this.IniProgress), total,  task);
            }
            else
            {
                this.UseWaitCursor = true;
                //if (cur > total) {
                //    cur = total;
                //}
                this.skinLabel_TaskName.Text = task;
                this.progressBar1.Maximum = total;
                this.progressBar1.Value = 0;
                progressBar1.Step = 1;
                
               // System.Threading.Thread.Sleep(10);
            }
        } 

        private void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosedClick?.Invoke(this);
        }


    }
}
