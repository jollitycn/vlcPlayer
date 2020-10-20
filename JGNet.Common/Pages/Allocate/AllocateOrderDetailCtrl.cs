using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

using JGNet.Common.Core;  
using JGNet.Common.Components; 
using CJBasic.Helpers;

namespace JGNet.Common
{
    public partial class AllocateOrderDetailCtrl : BaseModifyCostumeIDUserControl
    { 

        private AllocateOrder curAllocateOrder;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        public AllocateOrderDetailCtrl(AllocateOrder order )
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new String[] {
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
            SumMoney4Price.DataPropertyName,
            sumCountDataGridViewTextBoxColumn.DataPropertyName});
            dataGridViewPagingSumCtrl.Initialize();
            this.curAllocateOrder = order;
            Initialize();
        }

        private void Initialize()
        {
            if (this.curAllocateOrder == null)
            {
                return;
            }
            try
            {
                this.skinTextBox_OrderID.Text = "调拨单号：" + this.curAllocateOrder.ID;
                this.skinLabelReceive.Text = "收货方：" + CommonGlobalCache.GetShopName(this.curAllocateOrder.DestShopID);
                this.skinLabelSend.Text = "发货方：" + CommonGlobalCache.GetShopName(this.curAllocateOrder.SourceShopID);
                skinLabelRemarks.Text = "备注：" + curAllocateOrder.Remarks;
                List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetInboundDetail(this.curAllocateOrder.InboundOrderID);
                if (curAllocateOrder.State == 1)
                {
                    //this.curDateTime = curAllocateOrder.FinishedTime.ToString();
                    this.skinLabel1.Text = curAllocateOrder.FinishedTime.ToString();
                }
                else
                {
                    this.skinLabel1.Text = "";
                    this.skinLabel4.Text = ""; 
                } 
                this.BindingReplenishDetailSource(list);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }

        }

        private void BindingReplenishDetailSource(List<BoundDetail> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (BoundDetail detail in list)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                    detail.Comment = curAllocateOrder.Remarks;
                }
                 
            }
            this.dataGridViewPagingSumCtrl.BindingDataSource<BoundDetail>(list);

           
        }

        public override void HighlightCostume()
        {
            if (dataGridView1.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        BoundDetail detail = row.DataBoundItem as BoundDetail;
                        HighlightCostume(row, detail?.CostumeID);
                    }
                }
            }
        }
    }
}
