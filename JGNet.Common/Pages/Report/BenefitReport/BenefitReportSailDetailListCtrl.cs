using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Common.Core.Util;
using JGNet.Common.Core; 
using JGNet.Core.Const;
using JGNet.Common.Components;
using JGNet.Core.Tools;

namespace JGNet.Common
{/// <summary>
/// 营业日报
/// </summary>
    public partial class BenefitReportSailDetailListCtrl : BaseModifyUserControl
    {
        private DataGridViewRow currRow;
        private GetShopBenefitReportsPara pagePara1;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl1; 

        /// <summary>
        /// 点击收货按钮触发
        /// </summary>
        // public event CJBasic.Action<DayBenefitReport> InboundClick;

        public BenefitReportSailDetailListCtrl()
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView_RetailDetail);
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 Remarks,OrderRemarks });
            dataGridViewPagingSumCtrl.Initialize();

            this.dataGridView_RetailDetail.AutoGenerateColumns = false;
            dataGridViewPagingSumCtrl1 = new DataGridViewPagingSumCtrl(dataGridViewRechargeRecord);
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn });
            
            dataGridViewPagingSumCtrl1.Initialize();
        }
         

        private void Initialize()
        {
            List<ListItem<int>> stateList = new List<ListItem<int>>();
            this.pagePara1 = new GetShopBenefitReportsPara();
            dataGridViewPagingSumCtrl.SetDataSource<DayBenefitReportDetail>(null);
            dataGridViewPagingSumCtrl1.SetDataSource<RechargeRecord>(null);
        } 
         

        public void SearchDetailList(DayBenefitReportDetailPara para)
        {
            SearchRetail(para);
            SearchRechargeRecord(para);
        }

        private void SearchRetail(DayBenefitReportDetailPara para)
        {
            List<DayBenefitReportDetail> listPage = null;
            try
            {

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                listPage = CommonGlobalCache.ServerProxy.GetDayBenefitReportDetail(para);
            }
            catch (Exception ee)
            {
                ShowError(ee);
            }
            finally
            {
                this.BindingDataSource(listPage);
                UnLockPage();
            }
        }


        /// <summary>
        /// 绑定RetailDetail数据源并设置下方的Label值
        /// </summary>
        private void BindingDataSource(List<DayBenefitReportDetail> retailDetailList)
        {
            if (retailDetailList != null && retailDetailList.Count > 0)
            {
                foreach (DayBenefitReportDetail detail in retailDetailList)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                    detail.SizeDisplayName = CommonGlobalUtil.GetCostumeSizeName(detail.CostumeID, detail.SizeName);
                 //   detail.GuideName = CommonGlobalCache.GetUserName(detail.gu)
                }
            }
            dataGridViewPagingSumCtrl.BindingDataSource< DayBenefitReportDetail>(DataGridViewUtil.ToDataTable(retailDetailList));
        }


        private void DayBenefitReportManageCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void SearchRechargeRecord(DayBenefitReportDetailPara para)
        {

            try
            {

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                RechargeRecordListPara rechargePara = new RechargeRecordListPara()
                {
                    ShopID = para.ShopID,
                    PhoneNumber = String.Empty,
                    StartDate = para.StartDate,
                    EndDate = para.EndDate,
                };

                List<RechargeRecord>
               rechargeRecordList = CommonGlobalCache.ServerProxy.GetRechargeRecordList(rechargePara);
                BindingDataSource(rechargeRecordList);
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

        private void BindingDataSource(List<RechargeRecord> rechargeRecordList)
        {

            if (rechargeRecordList != null && rechargeRecordList.Count > 0)
            {
                foreach (RechargeRecord record in rechargeRecordList)
                {
                    record.GuideName = CommonGlobalCache.GetUserName(record.GuideID);
                }
            }
            dataGridViewPagingSumCtrl1.BindingDataSource< RechargeRecord>(DataGridViewUtil.ToDataTable(rechargeRecordList));
        }
         
    }
}
