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
    public partial class OutboundDetailCtrl : BaseModifyCostumeIDUserControl
    { 
        private OutboundOrder curOutboundOrder;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public OutboundDetailCtrl(OutboundOrder outboundOrder)
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
            sumMoneyDataGridViewTextBoxColumn.DataPropertyName,
            sumCountDataGridViewTextBoxColumn.DataPropertyName});
                dataGridViewPagingSumCtrl.Initialize();
            this.curOutboundOrder = outboundOrder;
            Initialize();


        }

        private void Initialize()
        {
            if (this.curOutboundOrder == null)
            {
                return;
            }
            try
            {
                this.skinLabel_OrderID.Text = this.curOutboundOrder.ID;
                this.skinLabel_Remarks.Text = this.curOutboundOrder.Remarks.ToString();

                //this.skinLabel_TotalCount.Text = this.curOutboundOrder.TotalCount.ToString();
                //this.skinLabel_TotalPrice.Text = this.curOutboundOrder.TotalPrice.ToString();

                //string operatorName = CommonGlobalCache.GetUserName(this.curOutboundOrder.OperatorUserID);
                //if (string.IsNullOrEmpty(operatorName))
                //{
                //    this.skinLabel_OperatorLabel.Visible = false;
                //}
                //this.skinLabel_Operator.Text = operatorName;
                //this.skinLabel_OperateTime.Text = this.curOutboundOrder.CreateTime.ToString();
                //this.skinLabel_SenderShopName.Text= CommonGlobalCache.GetShopName(this.curOutboundOrder.ShopID);
                SourceOrderPartialDetail sourceOrderPartialDetail = CommonGlobalUtil.GetSourceOrderPartialDetail(this.curOutboundOrder.SourceOrderID);
                if (sourceOrderPartialDetail!=null)
                {
                    //this.skinLabel_ReceiverName.Text= CommonGlobalCache.GetShopName(sourceOrderPartialDetail.DestShopID);
                }
                List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(this.curOutboundOrder.ID);
                this.BindingOutboundDetailSource(list);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        private void BindingOutboundDetailSource(List<BoundDetail> list)
        { 
            if (list != null && list.Count > 0)
            {
                foreach (BoundDetail detail in list)
                {
                    detail.CostumeName= CommonGlobalCache.GetCostumeName(detail.CostumeID);
                    
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

        private void skinLabel10_Click(object sender, EventArgs e)
        {

        }

        private void skinPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
