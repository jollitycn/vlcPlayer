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

namespace JGNet.Common
{
    public partial class RechargeRecordListCtrl : BaseModifyUserControl
    {
        private List<RechargeRecord> rechargeRecordList;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private Member member;
        RechargeRecordListPara pagePara; 
        public RechargeRecordListCtrl(RechargeRecordListPara para)
        {
            InitializeComponent();
            this.pagePara = para;
            this.createTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1);

            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn });
            dataGridViewPagingSumCtrl.Initialize(); 


        }
        private void Search(Boolean isOpenDate = false)
        {
            try
            {

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                this.rechargeRecordList = CommonGlobalCache.ServerProxy.GetRechargeRecordList(pagePara);
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

        private void SetGuideName()
        { 
            foreach (RechargeRecord record in this.rechargeRecordList)
            {
                record.GuideName = CommonGlobalCache.GetUserName(record.GuideID);
            }
        }

        private void BindingDataSource()
        {
           
            this.dataGridView1.DataSource = null;
            if (this.rechargeRecordList != null && this.rechargeRecordList.Count > 0)
            {
                this.SetGuideName();//绑定源前先将GuideName字段赋值，用于显示
                this.dataGridView1.DataSource = this.rechargeRecordList;
            }
            this.dataGridView1.Refresh();
        }

        private void RechargeRecordCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        { 
            this.rechargeRecordList = null;
            this.BindingDataSource(); 
                Search();
        } 
    }
}
