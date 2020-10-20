using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using CCWin;
using JGNet.Common.Core;

namespace JGNet.Common
{
    public partial class PfCustomerIDTextBox :  JGNet.Common.TextBox
    {
        /// <summary>
        /// 款号被选中时触发
        /// </summary>
        public event System.Action<PfCustomer> MemberSelected;
        /// <summary>
        /// 判断是否需要作会员检查
        /// </summary> 
        public bool CheckMember { get; set; }
        public PfCustomerIDTextBox()
        {
            InitializeComponent();
            base.SkinTxt.PreviewKeyDown += SkinTxt_PreviewKeyDown;
            base.SkinTxt.TextChanged += SkinTxt_TextChanged;
            base.Leave += SkinTxt_Leave;
            base.SkinTxt.Text =" ";
            base.Text = " ";
            
            base.WaterText = "输入编号/名称并回车";
            base.SkinTxt.WaterText = "输入编号/名称并回车";

        }

        private void SkinTxt_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.SkinTxt.Text))
            {
                MemberSelected?.Invoke(null);
            }
        }

        private void SkinTxt_Leave(object sender, EventArgs e)
        {
            if (CheckMember)
            {
                String value = this.SkinTxt.Text.Trim();
                if (!String.IsNullOrEmpty(value))
                {
                    if (resultList == null)
                    {
                        Search();
                    }
                    if (resultList == null  )
                    {
                        GlobalMessageBox.Show("分销人员不存在，请重新输入！");
                        this.Focus();
                    }
                    else if
                        (!resultList.Exists(t => t.Name == value || t.ID == value))
                    {
                        this.SkinTxt.Text = "";
                        GlobalMessageBox.Show("分销人员不存在，请重新输入！");
                        this.Focus();
                    }
                }
            }
        }

        List<PfCustomer> resultList = null;
        #region 回车后选择款号
        private void SkinTxt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            Search();
        }

        public void Search()
        {

            try
            {
                string memberID = this.SkinTxt.Text.Trim();
                if (string.IsNullOrEmpty(memberID))
                {
                    MemberSelected?.Invoke(null);
                    return;
                }

                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                 JGNet.Core.InteractEntity.InteractResult<List<PfCustomer>> result = CommonGlobalCache.ServerProxy.GetPfCustomers(memberID);
                if (result.ExeResult == JGNet.Core.InteractEntity.ExeResult.Success)
                {
                    if (result.Data != null)
                    {
                        resultList = result.Data;
                    }

                }
                if (resultList != null
                //    &&  PermissonUtil.HasPermission(RolePermissionMenuEnum.会员管理, RolePermissionEnum.查看_只看本店)
                    )
                {
                   // resultList = resultList.FindAll(t => t.ShopID == CommonGlobalCache.CurrentShopID);
                }

                if (resultList == null || resultList.Count == 0)
                {
                    MemberSelected?.Invoke(null); 
                    return;
                }
                if (resultList.Count == 1)
                {
                    this.SkinTxt.Text = resultList[0].ID;
                    MemberSelected?.Invoke(resultList[0]);
                }
                else
                {
                    pfCustomerSelectForm1 memberForm = new pfCustomerSelectForm1(memberID, resultList);
                    memberForm.MemberSelected += MemberForm_MemberSelected;
                    memberForm.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                ShowError(ee);
            }
            finally
            {
                UnLockPage();
            }
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
        private void MemberForm_MemberSelected(PfCustomer customer, EventArgs args)
        {
            this.SkinTxt.Text = customer.ID;
            MemberSelected?.Invoke(customer);
        }

        #endregion
    }
}
