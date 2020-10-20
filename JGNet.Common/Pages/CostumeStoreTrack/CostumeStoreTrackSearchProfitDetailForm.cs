
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Common.Core;
using JGNet.Common.Core.Util;
using JGNet.Core.Dev.MyEnum;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using JieXi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;
using static CCWin.SkinControl.SkinChatRichTextBox;

namespace JGNet.Common
{
    public partial class CostumeStoreTrackSearchProfitDetailForm : BaseDialogCostumeIDForm
    {

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public CostumeStoreTrackSearchProfitDetailForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(
                this.dataGridView1, new string[] {
                     fAtmDataGridViewTextBoxColumn.DataPropertyName,
       xSAtmDataGridViewTextBoxColumn.DataPropertyName,
       sAtmDataGridViewTextBoxColumn.DataPropertyName,
       mAtmDataGridViewTextBoxColumn.DataPropertyName,
       lAtmDataGridViewTextBoxColumn.DataPropertyName,
       xLAtmDataGridViewTextBoxColumn.DataPropertyName,
       xL2AtmDataGridViewTextBoxColumn.DataPropertyName,
       xL3AtmDataGridViewTextBoxColumn.DataPropertyName,
       xL4AtmDataGridViewTextBoxColumn.DataPropertyName,
       xL5AtmDataGridViewTextBoxColumn.DataPropertyName,
       xL6AtmDataGridViewTextBoxColumn.DataPropertyName,
       sumCountAtmDataGridViewTextBoxColumn.DataPropertyName,
        xSDataGridViewTextBoxColumn.DataPropertyName,
       sDataGridViewTextBoxColumn.DataPropertyName,
       mDataGridViewTextBoxColumn.DataPropertyName,
       lDataGridViewTextBoxColumn.DataPropertyName,
       xLDataGridViewTextBoxColumn.DataPropertyName,
       xL2DataGridViewTextBoxColumn.DataPropertyName,
       xL3DataGridViewTextBoxColumn.DataPropertyName,
       xL4DataGridViewTextBoxColumn.DataPropertyName,
       xL5DataGridViewTextBoxColumn.DataPropertyName,
       xL6DataGridViewTextBoxColumn.DataPropertyName,
       fDataGridViewTextBoxColumn.DataPropertyName,
        sumCountDataGridViewTextBoxColumn.DataPropertyName,
        SumMoneyWinLost.DataPropertyName,
        sumCountWinLostDataGridViewTextBoxColumn.DataPropertyName
    })
          ;
            dataGridViewPagingSumCtrl.Initialize();
            
        }
        

        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        GetCostumeStoreChangePara para;
        DateTime datastarttime;
        internal void ShowDialog(CheckStoreOrder order)
        {

            datastarttime = DateTime.Now;
            this.Initialize(order);
            DateTime endtime = DateTime.Now;
            TimeSpan span = (TimeSpan)(endtime - starTime);
            CommonGlobalUtil.WriteLog("盘点汇总数盈亏明细界面加载开始时间：" + starTime + " 结束时间：" + endtime + " 总耗时数：" + span.TotalSeconds + "秒");
            
            this.ShowDialog();

        }

        DateTime starTime;
    private void Initialize(CheckStoreOrder order)
    {
        if (order == null || String.IsNullOrEmpty(order.ID))
        {
            return;
        }
        try
        {
            this.Text += "-"+ order.ID;
            List<CheckStoreDetail> list = CommonGlobalCache.ServerProxy.GetCheckStoreDetail(order.ID);

                DateTime endtime = DateTime.Now;
                TimeSpan span = (TimeSpan)(endtime - datastarttime);
                CommonGlobalUtil.WriteLog("盘点汇总数盈亏明细数据加载开始时间：" + datastarttime + " 结束时间：" + endtime + " 总耗时数：" + span.TotalSeconds + "秒");
                starTime = DateTime.Now;
                this.BindingOutboundDetailSource(list);
            }
        catch (Exception ee)
        {
            CommonGlobalUtil.ShowError(ee);
        }

    }
        private void BindingOutboundDetailSource(List<CheckStoreDetail> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (CheckStoreDetail detail in list)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                }
            }

            dataGridViewPagingSumCtrl.BindingDataSource<CheckStoreDetail>(list);
          
        }

        public override void HighlightCostume()
        {
            if (dataGridView1.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        CheckStoreDetail detail = row.DataBoundItem as CheckStoreDetail;
                        HighlightCostume(row, detail?.CostumeID);
                    }
                }
                dataGridView1.Refresh();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        }

        private void CostumeStoreTrackSearchProfitDetailForm_Load(object sender, EventArgs e)
        {
            HighlightCostume();
        }
    }
}
