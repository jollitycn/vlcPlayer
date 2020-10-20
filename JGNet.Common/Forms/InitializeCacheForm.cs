using CCWin;
using JGNet.Common; 
using CJPlus.Rapid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class InitializeCacheForm : BaseForm
    {  
        public InitializeCacheForm( )
        {
            InitializeComponent(); 


        }

        private void GlobalCache_IniFailed(Exception ex)
        {
           
                CommonGlobalUtil.ShowError(ex);
          
            this.DialogResult = DialogResult.Abort;
        }

        private void GlobalCache_IniCompleted()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.GlobalCache_IniCompleted));
            }
            else
            {
                this.progressBar1.Value = this.progressBar1.Maximum;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void GlobalCache_IniProgress(int total,  string task)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<int,  string>(this.GlobalCache_IniProgress), total,  task);
            }
            else
            {
                this.progressBar1.Maximum = total;
                this.progressBar1.Value = 0;
                this.progressBar1.Step = 1;
                this.skinLabel_TaskName.Text = task;
            }
        }
        private void GlobalCache_UpdateProgress(string task)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<string>(this.GlobalCache_UpdateProgress),task);
            }
            else
            {
                this.progressBar1.PerformStep();
                this.skinLabel_TaskName.Text = task;
            }
        }

        private void InitializeCacheForm_Load(object sender, EventArgs e)
        {

            CommonGlobalCache.IniProgress += GlobalCache_IniProgress;
            CommonGlobalCache.UpdateProgress += GlobalCache_UpdateProgress;
            CommonGlobalCache.IniCompleted += GlobalCache_IniCompleted;
            CommonGlobalCache.IniFailed += GlobalCache_IniFailed; 
        }
         
    }
}
