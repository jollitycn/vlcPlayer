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
    public partial class MemberIDTextBox :  JGNet.Common.TextBox
    {
        /// <summary>
        /// 款号被选中时触发
        /// </summary>
        public event System.Action<Member> MemberSelected;
        /// <summary>
        /// 判断是否需要作会员检查
        /// </summary> 
        public bool CheckMember { get; set; }
        public MemberIDTextBox()
        {
            InitializeComponent();
            base.SkinTxt.PreviewKeyDown += SkinTxt_PreviewKeyDown;
            base.SkinTxt.TextChanged += SkinTxt_TextChanged;
            base.Leave += SkinTxt_Leave;
            base.SkinTxt.Text = string.Empty;
            base.Text = string.Empty;
            base.WaterText = "输入卡号/姓名并回车";
            base.SkinTxt.WaterText = "输入卡号/姓名并回车";
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
                        GlobalMessageBox.Show("会员不存在，请重新输入！");
                        this.Focus();
                    }
                    else if
                        (!resultList.Exists(t => t.Name == value || t.PhoneNumber == value))
                    {
                        this.SkinTxt.Text = "";
                        GlobalMessageBox.Show("会员不存在，请重新输入！");
                        this.Focus();
                    }
                }
            }
        }

        List<Member> resultList = null;
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
                resultList = CommonGlobalCache.ServerProxy.GetMembersLike4IDOrName(memberID);
                if (resultList != null &&  PermissonUtil.HasPermission(RolePermissionMenuEnum.会员管理, RolePermissionEnum.查看_只看本店))
                {
                    resultList = resultList.FindAll(t => t.ShopID == CommonGlobalCache.CurrentShopID);
                }

                if (resultList == null || resultList.Count == 0)
                {
                    MemberSelected?.Invoke(null); 
                    return;
                }
                if (resultList.Count == 1)
                {
                    this.SkinTxt.Text = resultList[0].PhoneNumber;
                    MemberSelected?.Invoke(resultList[0]);
                }
                else
                {
                    MemberSelectForm memberForm = new MemberSelectForm(memberID, resultList);
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
        private void MemberForm_MemberSelected(Member member, EventArgs args)
        {
            this.SkinTxt.Text = member.PhoneNumber;
            MemberSelected?.Invoke(member);
        }

        #endregion
    }
}
