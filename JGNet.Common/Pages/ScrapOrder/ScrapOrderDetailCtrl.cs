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
using JGNet.Common.Core.Util;

namespace JGNet.Common
{
    public partial class ScrapOrderDetailCtrl : BaseModifyCostumeIDUserControl
    {

        private ScrapOrder curScrapOrder;

        public CJBasic.Action<string, BaseUserControl> OutboundDetailClick;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public ScrapOrderDetailCtrl(ScrapOrder order)
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1, new string[] {
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
            sumMoneyDataGridViewTextBoxColumn.DataPropertyName
            }); dataGridViewPagingSumCtrl.Initialize();
            this.curScrapOrder = order;
            Initialize();
        }

        public void Print() {
            ScrapOrderPrinter.Print(curScrapOrder, dataGridView1, 2);
        }

        private void Initialize()
        {
            if (this.curScrapOrder == null)
            {
                return;
            }
            try
            {
                this.skinTextBox_OrderID.Text = "报损单号：" + this.curScrapOrder.ID;
                this.skinLabel_ShopName.Text = "店铺名称：" + CommonGlobalCache.GetShopName(this.curScrapOrder.ShopID); 
                this.skinLabel_Remark.Text = this.curScrapOrder.Remarks;
                List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(this.curScrapOrder.OutboundOrderID);
                this.BindingInboundDetailSource(list);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }

        }

        private void BindingInboundDetailSource(List<BoundDetail> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (BoundDetail detail in list)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                }
            }
            dataGridViewPagingSumCtrl.BindingDataSource<BoundDetail>(list);
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
