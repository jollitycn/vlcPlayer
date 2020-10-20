
using CCWin;
using JGNet.Common.Components;
using JGNet.Common.Core;
using CJBasic.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class MemberSelectForm : BaseForm
    {


        private List<Member> memberList;//当前被绑定的源

        /// <summary>
        /// 会员被选择时触发
        /// </summary>
        public event CJBasic.Action<Member, EventArgs> MemberSelected;

        public MemberSelectForm(string memberID, List<Member> members)
        {
            InitializeComponent();
            new DataGridViewPagingSumCtrl(dataGridView1).Initialize();
            this.skinTextBox1.SkinTxt.Text = memberID;
            this.memberList = members;
            this.BindingDataSource();
        }

        //点击按钮查询
        private void BaseButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string memberID = this.skinTextBox1.SkinTxt.Text.Trim();
                if (string.IsNullOrEmpty(memberID))
                {
                    return;
                }
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                this.memberList = CommonGlobalCache.ServerProxy.GetMembersLike4IDOrName(memberID);
                if (memberList != null && HasPermission(RolePermissionMenuEnum.会员管理, RolePermissionEnum.查看_只看本店))
                {
                    memberList = memberList.FindAll(t => t.ShopID == CommonGlobalCache.CurrentShopID);
                }
                this.BindingDataSource();
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

        //绑定数据源
        private void BindingDataSource()
        {
            if (this.memberList != null && this.memberList.Count != 0)
            {
                foreach (Member member in this.memberList)
                {
                    member.GuideName = CommonGlobalCache.GetUserName(member.GuideID);
                }
            }
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.memberList;
        }


        //提交选择的会员
        private void ConfirmSelectCell(Member member)
        {
            this.MemberSelected?.Invoke(member, null);
            this.DialogResult = DialogResult.OK;
        }

        //点击确认按钮
        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.DataSource == null)
                {
                    return;
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    int index = this.dataGridView1.SelectedCells[0].RowIndex;
                    this.ConfirmSelectCell(this.memberList[index]);
                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        //点击取消按钮
        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
         
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            this.ConfirmSelectCell(this.memberList[e.RowIndex]);
             
        }
    }
}
