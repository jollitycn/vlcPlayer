
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
    public partial class pfCustomerSelectForm1 : BaseForm
    {


        private List<PfCustomer> memberList;//当前被绑定的源

        /// <summary>
        /// 会员被选择时触发
        /// </summary>
        public event CJBasic.Action<PfCustomer, EventArgs> MemberSelected;

        public pfCustomerSelectForm1(string memberID, List<PfCustomer> members)
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
                this.memberList = null;
                JGNet.Core.InteractEntity.InteractResult<List<PfCustomer>> result = CommonGlobalCache.ServerProxy.GetPfCustomers(memberID);
                if (result.ExeResult == JGNet.Core.InteractEntity.ExeResult.Success)
                {
                    if (result.Data != null)
                    {
                        memberList = result.Data;
                    }

                }
                //if (memberList != null && HasPermission(RolePermissionMenuEnum.会员管理, RolePermissionEnum.查看_只看本店))
                //{
                //    memberList = memberList.FindAll(t => t.ShopID == CommonGlobalCache.CurrentShopID);
                //}
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
                //foreach (PfCustomer member in this.memberList)
                //{
                //    member.Name = CommonGlobalCache.GetUserName(member.ID);
                //}
            }
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.memberList;
        }


        //提交选择的会员
        private void ConfirmSelectCell(PfCustomer member)
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
