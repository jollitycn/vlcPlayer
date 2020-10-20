using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms; 
using CJBasic;
using CCWin;
using JGNet.Common.Core;  
using JGNet.Core.InteractEntity;
using JGNet.Common.Components;
using JGNet.Common.Core.Util;

namespace JGNet.Common
{
    public partial class RechargeRecordCtrl : BaseModifyUserControl
    {
        private List<RechargeRecord> rechargeRecordList;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private Member member;
        public RechargeRecordCtrl()
        {
            InitializeComponent();
         
            this.createTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new String[] {
                balanceOldDataGridViewTextBoxColumn.DataPropertyName,
                balanceNewDataGridViewTextBoxColumn.DataPropertyName,
                donateMoneyDataGridViewTextBoxColumn.DataPropertyName,
                rechargeMoneyDataGridViewTextBoxColumn.DataPropertyName
            });            //dataGridViewPagingSumCtrl.SpecAutoSizeMode(new TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode>(remarksDataGridViewTextBoxColumn, DataGridViewAutoSizeColumnMode.ColumnHeader));
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn });
            dataGridViewPagingSumCtrl.Initialize();

        }

        public RechargeRecordCtrl(Member member = null)
        {
            InitializeComponent();
            this.member = member;
            this.createTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new String[] {
                balanceOldDataGridViewTextBoxColumn.DataPropertyName,
                balanceNewDataGridViewTextBoxColumn.DataPropertyName,
                donateMoneyDataGridViewTextBoxColumn.DataPropertyName,
                rechargeMoneyDataGridViewTextBoxColumn.DataPropertyName
            });  //dataGridViewPagingSumCtrl.SpecAutoSizeMode(new TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode>(remarksDataGridViewTextBoxColumn, DataGridViewAutoSizeColumnMode.ColumnHeader));

            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn });
            dataGridViewPagingSumCtrl.Initialize();
          

        }

        private void Search()
        {
            try
            {

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                RechargeRecordListPara para = new RechargeRecordListPara()
                {
                    IsPos = IsPos,
                    ShopID = HasPermission( RolePermissionMenuEnum.会员管理, RolePermissionEnum.查看_只看本店) ? CommonGlobalCache.CurrentShopID : null,
                    PhoneNumber = this.skinTextBox_MemberID.Text.Trim(),
                    StartDate =  new Date(this.dateTimePicker_Start.Value) ,
                    EndDate = new Date(this.dateTimePicker_End.Value)  
                };
                //if (IsPos)
                //{
                //    para.IsPos = true;
                //    para.ShopID = CommonGlobalCache.CurrentShopID;
                //}
                //else {
                //    para.IsPos = false;
                //}
                if (string.IsNullOrEmpty(para.PhoneNumber))
                {
                    para.PhoneNumber = null;
                }
                this.rechargeRecordList = CommonGlobalCache.ServerProxy.GetRechargeRecordList(para);
                this.BindingDataSource();
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.WriteLog(ee);//CommonGlobalUtil.Logger.Log(ee, "RechargeRecordCtrl.BaseButton1_Click", CJBasic.Loggers.ErrorLevel.Standard);
                GlobalMessageBox.Show("查询失败！");
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }
   



        private void BaseButton1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void SetGuideName()
        { 
            foreach (RechargeRecord record in this.rechargeRecordList)
            {
                record.GuideName = CommonGlobalCache.GetUserName(record.GuideID);
            }
        }

        private void BindingDataSource()
        {
            
            if (this.rechargeRecordList != null && this.rechargeRecordList.Count > 0)
            {
                this.SetGuideName();//绑定源前先将GuideName字段赋值，用于显示
            }
            dataGridViewPagingSumCtrl.BindingDataSource<RechargeRecord>(DataGridViewUtil.ListToBindingList(this.rechargeRecordList));
        }

        private void RechargeRecordCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            skinTextBox_MemberID.Text = String.Empty;
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            if (member != null)
            {
                skinTextBox_MemberID.Text = member?.PhoneNumber;
                DateTimeUtil.DateTimePicker_All(dateTimePicker_Start, dateTimePicker_End);
                Search();
            }
            else
            {
                this.rechargeRecordList = null;
                this.BindingDataSource();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Column1
            //DataGridView view = (DataGridView)sender;
            //DataRowView itemRow = (DataRowView)view.Rows[e.RowIndex].DataBoundItem;

            if (dataGridView1.DataSource != null && dataGridView1.Rows.Count > 0)
            {
                List<RechargeRecord> list = DataGridViewUtil.BindingListToList<RechargeRecord>(dataGridView1.DataSource);
                if (e.RowIndex > -1 && e.ColumnIndex== Column1.Index)
                {
                    RechargeRecord item = (RechargeRecord)list[e.RowIndex];
                    InteractResult<RechargeRecord> interResultList = CommonGlobalCache.ServerProxy.GetOneRechargeRecord(item.ID);
                    RechargeRecord curRecord = interResultList.Data;
                    EditRechargeFrom form = new EditRechargeFrom(curRecord);
                    // form.Costume_Newed += Form_Costume_Newed;
                    /* if (form.ShowDialog() == DialogResult.OK)
                     {
                         this.RefreshPage();
                     }*/
                    if (form.ShowDialog(this.FindForm()) == DialogResult.OK)
                    {
                        Search();
                        this.RefreshPage();
                    }
                }
            }
            // form.Show();
        }
    }
}
