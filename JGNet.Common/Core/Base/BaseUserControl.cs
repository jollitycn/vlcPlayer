using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using System.Threading;
using JGNet.Common.Components;
using JGNet.Core.Tools;
using CCWin.SkinControl;

namespace JGNet.Common.Core
{
    public partial class BaseUserControl : UserControl
    {
        private RolePermissionEnum permission = RolePermissionEnum.不限;
        public RolePermissionEnum Permission
        {
            get
            {
                return permission;
            }
            set
            {
                permission = value;
            }
        }

        private RolePermissionMenuEnum menuPermission = RolePermissionMenuEnum.不限;
        public RolePermissionMenuEnum MenuPermission
        {
            get
            {
                return menuPermission;
            }
            set
            {
                menuPermission = value;
            }
        }

        public bool HasPermission(RolePermissionMenuEnum MenuPermission, RolePermissionEnum permission)
        {
            return PermissonUtil.HasPermission(MenuPermission, permission);
        }

        public bool HasPermission(RolePermissionEnum permission)
        {
            return PermissonUtil.HasPermission(this, permission);
        }

        protected Boolean ReportShowZero { get; set; }

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

        public String Action { get; set; }
        /// <summary>
        /// 判定是否需要刷新原页面信息
        /// </summary>
        public bool RefreshPageDisable { get; set; }
        /// <summary>
        /// 获取缓存中设置项目启动的方向
        /// </summary>
        public static Boolean IsPos { get { return CommonGlobalCache.IsPos; } }
        private OpaqueCommand cmd;
        public BaseUserControl()
        {
            InitializeComponent();
            cmd = new OpaqueCommand();
            this.SaveSuccessEvent += delegate {};
            ReportShowZero = CommonGlobalUtil.OptionIsReportShowZero();
           // this.
        }

        private void BaseUserControl_Load(object sender, EventArgs e)
        {
           
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        /// <summary>
        /// 源Type   （从哪里跳转过来的）
        /// </summary>
        public BaseUserControl SourceCtrlType { get; set; }

        /// <summary>
        /// 当前TabPageAction
        /// </summary>
        public TabPage CurrentTabPage { get; set; }

        /// <summary>
        /// 保存或提交成功后触发 参数TabPage：当前操作的TabPage界面
        /// </summary>
        public event CJBasic.Action<TabPage, BaseUserControl> SaveSuccessEvent;
        public CJBasic.Action<TabPage, BaseUserControl> RefreshPageAction;

        /// <summary>
        /// 保存或提交成功后调用
        /// </summary>
        protected void SaveSuccess()
        { 
            RefreshPageAction?.Invoke(this.CurrentTabPage, this.SourceCtrlType);
            SaveSuccessEvent?.Invoke(this.CurrentTabPage, this);
        }

        public void UnWaiting()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.UnWaiting));
            }
            else
            {
                cmd.HideOpaqueLayer();
            }
        }

        public void CompleteProgressForm()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric(this.CompleteProgressForm));
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
                BeginInvoke(new CJBasic.CbGeneric(this.ShowProgressForm));
            }
            else
            {
                progressStop = false;
                progressForm = new ProgressForm();
                progressForm.ClosedClick -= ProgressForm_ClosedClick;
                progressForm.ClosedClick += ProgressForm_ClosedClick;
                //progressForm.ShowDialog(this.FindForm());
                progressForm.TopMost = true;
                progressForm.Show();
            }
        }

        protected ProgressForm progressForm = null;
        protected void CompleteProgress()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric(this.CompleteProgress));
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
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<string>(this.UpdateProgress), msg);
            }
            else
            { 
                progressForm.UpdateProgress(msg);
            }
        }

        protected void UpdateProgress(int total, int cur)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<int, int>(this.UpdateProgress), total, cur);
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
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<int, String>(this.InitProgress), total, title);
            }
            else
            {
                progressForm.IniProgress(total, title);
            }
        }

        protected void FailedProgress(Exception ex)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<Exception>(this.FailedProgress), ex);
            }
            else
            {
                progressForm.IniFailed(ex);
                progressStop = true;
            }
        }

        protected Boolean progressStop = false;

        public void Waiting()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric(this.Waiting));
            }
            else
            {
                cmd.ShowOpaqueLayer(this.ParentForm, 0, true);
            }
        }


        protected void WriteLog(String content)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new  CJBasic. CbGeneric<String>(this.WriteLog), content);
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

        protected void ShowError(Exception ex, bool content)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<Exception, bool>(this.ShowError), ex, content);
            }
            else
            {
                CommonGlobalUtil.ShowError(ex, content);
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
        protected void ShowError(String content)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<String>(this.ShowError), content);
            }
            else
            {
                GlobalMessageBox.ShowError(this.FindForm(), content);
            }
        }
        //protected void ShowError(Exception ex)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke(new CJBasic.CbGeneric<Exception>(this.ShowError), ex);
        //    }
        //    else
        //    {
        //        CommonGlobalUtil.ShowError(this.FindForm(), ex);
        //    }
        //}

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

        /// <summary>
        /// 刷新界面
        /// </summary>
        public virtual void RefreshPage() { }

        // protected readonly int pageSize = 15;
        /// <summary>
        /// 指定数值，超出范围不展示，否则列表展示
        /// </summary>
        ///  protected readonly int displayListCount = 50;
        public virtual void ReLoad()
        {
            this.OnLoad(null);
        }

        public virtual void HandleShortKey(ref Message msg, Keys keyData)

        {
           // this.HandleShortKey(ref msg,keyData);
        }
    }
}
