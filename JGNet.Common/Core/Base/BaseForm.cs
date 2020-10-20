using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.Win32;
using CCWin.Win32.Const;
using System.Diagnostics;
using System.Configuration;
using Microsoft.Win32;
using CJBasic;
using JGNet.Common.Core;

namespace JGNet.Common
{
    /// <summary>
    /// JGNet.Common中所有Form的基类。使其拥有一致的皮肤和Icon。
    /// </summary>
    public partial class BaseForm : CCWin.CCSkinMain
    {
        public RolePermissionMenuEnum MenuPermission { get; set; }
         
        public bool HasPermission(RolePermissionMenuEnum MenuPermission, RolePermissionEnum permission)
        {
            return PermissonUtil.HasPermission(MenuPermission, permission);
        }

        public bool HasPermission(RolePermissionEnum permission)
        {
            return (PermissonUtil.HasPermission(MenuPermission, permission));
        }  
        private Boolean closeWhenEscape = true;

        public Boolean IsPos { get { return CommonGlobalCache.IsPos; } }

        protected void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.CloseForm));
            }
            else
            {
                this.Close();
            }
        }

        protected override void CreateHandle()
        {
            if (!IsHandleCreated)
            {
                try
                {
                    base.CreateHandle();
                }
                catch { }
                finally
                {
                    if (!IsHandleCreated)
                    {
                        base.RecreateHandle();
                    }
                }
            }
        }

        protected void ShowError(Exception ex)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<Exception>(this.ShowError), ex);
            }
            else
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        protected void ShowErrorMessage(String content)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<String>(this.ShowErrorMessage), content);
            }
            else
            {
                GlobalMessageBox.ShowError(this.FindForm(), content);
            }
        }

        protected void ShowMessage(String message)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<String>(this.ShowMessage), message);
            }
            else
            {
                GlobalMessageBox.Show(this.FindForm(), message);
                //GlobalUtil.UnLockPage(this);
            }
        }

        protected void UnLockPage()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new  CbGeneric(this.UnLockPage));
            }
            else
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }

        protected void WriteLog(String content)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<String>(this.WriteLog), content);
            }
            else
            {
                CommonGlobalUtil.WriteLog(content);
            }
        }

        protected void WriteLog(Exception ex)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<Exception>(this.WriteLog), ex);
            }
            else
            {
                CommonGlobalUtil.WriteLog(ex);
            }
        }

        protected Boolean ReportShowZero { get; set; }
        protected readonly int pageSize = 20;
        public BaseForm()
        {
            InitializeComponent();
            cmd = new OpaqueCommand();
            ReportShowZero = CommonGlobalUtil.OptionIsReportShowZero();
            MenuPermission = RolePermissionMenuEnum.不限;
            this.KeyDown += BaseForm_KeyDown;
            this.Load += BaseForm_Load;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            PermissonUtil.CheckPermissons(this);
        }

        /// <summary>
        /// 是否esc关闭窗口，默认为TRUE
        /// </summary>
        public Boolean CloseWhenEscape
        {
            get { return closeWhenEscape; }
            set { closeWhenEscape = value; }
        }
        protected void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (CloseWhenEscape)
                {
                    this.Close();
                }
            }
        }


        public void UnWaiting()
        {
            // pictureBox1.SendToBack();
            // this.skinRollingBar1.Dock = DockStyle.None;
            // skinRollingBar1.StopRolling();
            cmd.HideOpaqueLayer();
        }
        public void Waiting()
        {
        //    progressForm = new  
           // progressForm.ShowDialog(this.FindForm());
            cmd.ShowOpaqueLayer(this, 0, true);
            //   pictureBox1.BringToFront();
            //   this.pictureBox1.Show();
            //  skinRollingBar1.StartRolling();
            //    this.skinRollingBar1.Dock = DockStyle.Fill;
        }

        #region UseCustomIcon
        private bool useCustomIcon = false;
        /// <summary>
        /// 是否使用自己的图标。
        /// </summary>
        public bool UseCustomIcon
        {
            get { return useCustomIcon; }
            set { useCustomIcon = value; }
        } 
        #endregion

        #region UseCustomBackImage
        private bool useCustomBackImage = false;
        /// <summary>
        /// 是否使用自己的背景图片
        /// </summary>
        public bool UseCustomBackImage
        {
            get { return useCustomBackImage; }
            set { useCustomBackImage = value; }
        }
        #endregion

        private OpaqueCommand cmd;

        private void OrayForm_Load(object sender, EventArgs e)
        {
            PermissonUtil.CheckPermissons(this);
        }

        //不能加，否则无法最大化
        //}   /// <summary>
        //    /// 解决界面闪烁问题
        //    /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

             
        protected void ShowError(String content)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<String>(this.ShowError), content);
            }
            else
            {
                GlobalMessageBox.ShowError(this.FindForm(), content);
            }
        }

        public void CompleteProgressForm()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.CompleteProgressForm));
            }
            else
            {
                progressForm.IniCompleted();
            }
        }

        public void ShowProgressForm()
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.ShowProgressForm));
            }
            else
            {
                progressStop = false;
                progressForm = new ProgressForm();
                progressForm.ClosedClick -= ProgressForm_ClosedClick;
                progressForm.ClosedClick += ProgressForm_ClosedClick;
                progressForm.ShowDialog(this.FindForm());

            }
        }

        protected ProgressForm progressForm = null;
        protected void CompleteProgress()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.CompleteProgress));
            }
            else
            {
                progressForm.IniCompleted();
            }
        }

        private void ProgressForm_ClosedClick(ProgressForm form)
        {
            progressStop = true;
        }

        protected void UpdateProgress(String msg = null)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<string>(this.UpdateProgress), msg);
            }
            else
            {
                progressForm.UpdateProgress(msg);
            }
        }

        protected void UpdateProgress(int total, int cur)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<int, int>(this.UpdateProgress), total, cur);
            }
            else
            {
                if (cur > total)
                {
                    cur = total;
                }
                progressForm.UpdateProgress(cur + "/" + total);
            }
        }

        protected void InitProgress(int total, String title = "")
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<int, String>(this.InitProgress), total, title);
            }
            else
            {
                progressForm.IniProgress(total, title);
            }
        }

        protected void FailedProgress(Exception ex)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<Exception>(this.FailedProgress), ex);
            }
            else
            {
                progressForm.IniFailed(ex);
                progressStop = true;
            }
        }

        protected Boolean progressStop = false;




    }
}
