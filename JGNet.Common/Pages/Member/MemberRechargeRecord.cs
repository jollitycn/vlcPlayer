using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms; 
using CJBasic.Widget;
using CJBasic;
using CJBasic.Loggers;
using JGNet.Common.Core;  
using JGNet.Common.Components;
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Core.Tools;
using JGNet.Common.Core.Util;

namespace JGNet.Common
{
    public partial class MemberRechargeRecord : BaseModifyUserControl
    {


        private GetMemberBalanceChangePara pagePara;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;


        private Member member;

        public MemberRechargeRecord()
        {
            InitializeComponent();
            InitializeConstruct();
            MenuPermission = RolePermissionMenuEnum.会员余额变化;
        }
        private void InitializeConstruct()
        {
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new String[] {
            this.rechargeMoneyDataGridViewTextBoxColumn.DataPropertyName,
            this.DonateMoney.DataPropertyName,
            this.reatilMoneyDataGridViewTextBoxColumn.DataPropertyName,
            this.balanceDataGridViewTextBoxColumn.DataPropertyName
            });
           // dataGridViewPagingSumCtrl.ColumnSorting =  
            dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.AutoSizeRowsMode =DataGridViewAutoSizeRowsMode.
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(rechargeMoneyDataGridViewTextBoxColumn, reatilMoneyDataGridViewTextBoxColumn);
            dataGridViewPagingSumCtrl.Initialize();
            //  SetState();
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
        }

        private void Search(object sender, EventArgs args)
        {

        }
        private void BindingSource(List<ReatilSumInfo> listPage)
        {
            this.dataGridViewPagingSumCtrl.BindingDataSource(listPage);
        }

        //点击搜索按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            string memberId = skinTextBoxMemberId.Text;
            if (string.IsNullOrEmpty(memberId))
            {
                GlobalMessageBox.Show("请先输入会员信息，再进行查询！");
                return;
            }

            this.pagePara = new GetMemberBalanceChangePara()
            {
                StartDate = new Date(this.dateTimePicker_Start.Value),
                EndDate = new Date(this.dateTimePicker_End.Value),
                MemberID = memberId,
            };

            InteractResult<List<MemberBalanceChange>> memberList = CommonGlobalCache.ServerProxy.GetMemberBalanceChange(this.pagePara);          
            dataGridViewPagingSumCtrl.BindingDataSource< MemberBalanceChange>( DataGridViewUtil.ToDataTable( memberList.Data));


        }
        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (this.pagePara == null)
                {
                    return;
                }
                InteractResult<List<MemberBalanceChange>> memberList = CommonGlobalCache.ServerProxy.GetMemberBalanceChange(this.pagePara);
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }
        }


        private void MemberconsumptionSearch_Load(object sender, EventArgs e)
        {
            
            if (member != null)
            {
                BaseButton_Search_Click(null, null);
            }
        }

       

        private void skinTextBoxMemberId_MemberSelected(Member obj)
        {
            if (obj != null)
            {
                member = obj;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //  MemberBalanceChange item = dataGridView1.Rows[e.RowIndex].DataBoundItem as MemberBalanceChange;
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            DataGridView view = (DataGridView)sender;

            if (view.Rows.Count > 0 && e.RowIndex>-1 )
            {
                DataRowView item = (DataRowView)view.Rows[e.RowIndex].DataBoundItem;
                if (item != null)
                {
                    MemberBalanceChange Memberitem = new MemberBalanceChange();
                    Memberitem.DateInt = Convert.ToInt32(item["DateInt"].ToString());
                    Memberitem.Balance = Convert.ToDecimal(item["Balance"].ToString());
                    Memberitem.ReatilMoney = Convert.ToDecimal(item["ReatilMoney"].ToString());
                    Memberitem.RechargeMoney = Convert.ToDecimal(item["RechargeMoney"].ToString());
                    Memberitem.DonateMoney = Convert.ToDecimal(item["DonateMoney"].ToString());
                    string memberId = "";
                    if (this.skinTextBoxMemberId?.Text != "")
                    {
                        memberId = this.skinTextBoxMemberId.Text;
                    }
                    if (e.ColumnIndex == rechargeMoneyDataGridViewTextBoxColumn.Index)
                    {
                        MemberRechargeRecordForm form = new MemberRechargeRecordForm();
                        form.ShowDialog(Memberitem, memberId);
                    }
                    else if (e.ColumnIndex == reatilMoneyDataGridViewTextBoxColumn.Index)
                    {
                        MemberRetailOrderListCtrl form = new MemberRetailOrderListCtrl();
                        Size size = new Size(1000, 500);
                        form.Size = size;
                        form.ShowDialog(memberId, Memberitem.DateInt);

                    }
                }
            }
        }
    }
}
