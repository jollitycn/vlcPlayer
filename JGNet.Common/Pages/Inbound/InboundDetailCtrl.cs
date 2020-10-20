using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Core;
using JGNet.Core.InteractEntity;
using JGNet.Common.Core;  
using JGNet.Common.Components;
using CJBasic.Helpers;

namespace JGNet.Common
{
    public partial class InboundDetailCtrl : BaseModifyCostumeIDUserControl
    { 
        private InboundOrder curInboundOrder;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private string curDateTime="";
        public InboundDetailCtrl(InboundOrder inboundOrder)
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
            });
                dataGridViewPagingSumCtrl.Initialize();
             this.curInboundOrder = inboundOrder; Initialize();
        }
        public InboundDetailCtrl(InboundOrder inboundOrder, AllocateOrder order)
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
            });
            dataGridViewPagingSumCtrl.Initialize();
            this.curInboundOrder = inboundOrder; Initialize();
            if (order.State == 1)
            {
                this.curDateTime = order.FinishedTime.ToString();
            }
            else
            {
                this.curDateTime = "";
            }
        }

        private void Initialize()
        {
            if (this.curInboundOrder == null)
            {
                return;
            }
            try
            {
                
                SourceOrderPartialDetail sourceOrderPartialDetail= CommonGlobalUtil.GetSourceOrderPartialDetail(this.curInboundOrder.SourceOrderID);
                 
                string operatorName= CommonGlobalCache.GetUserName(this.curInboundOrder.OperatorUserID);
               
                this.skinLabel3.Text = this.curInboundOrder.ID;
                this.skinLabel1.Text = this.curInboundOrder.Remarks.ToString();
                if (this.curDateTime != "")
                {
                    this.skinLabel6.Text = this.curDateTime.ToString();
                }
                else
                {
                    this.skinLabel6.Text = "";
                    this.skinLabel4.Text = "";
                }

                List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetInboundDetail(this.curInboundOrder.ID);
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
    }
}
