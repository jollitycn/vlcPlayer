using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms; 
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Core;
using JGNet.Common;
using JGNet.Common.Core.Util;
using JGNet.Common.Components;

namespace JGNet.Common
{
    /// <summary>
    /// 调拨入库，调拨单查询，补货申请单查询
    /// </summary>
    public partial class InboundConfirmCtrl : Common.Core.BaseModifyUserControl
    {
        private Outbound curOutbound;
         
        private string shopID;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        private List<BoundDetail> outboundDetailListCounterpart=new List<BoundDetail>();//绑定源的副本
        public InboundConfirmCtrl(string sourceOrderID)
        {
            InitializeComponent();
            this.shopID = CommonGlobalCache.CurrentShopID;
            this.curOutbound = CommonGlobalCache.ServerProxy.GetOneOutbound(sourceOrderID);

            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1,new string[] {
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
                SumCount.DataPropertyName,
                SumMoney.DataPropertyName
            });
            dataGridViewPagingSumCtrl.Initialize();
            this.Initialize();
            
            this.CostumeCurrentShopTextBox1.CostumeSelected += CostumeCurrentShopTextBox1_CostumeSelected;
        }

        #region 款号被选中
        private void CostumeCurrentShopTextBox1_CostumeSelected(Costume costumeItem, bool isEnter)
        {
            if (isEnter)
            {
                if (this.curOutbound == null || this.curOutbound.OutboundDetails == null || this.curOutbound.OutboundDetails.Count == 0)
                {
                    return;
                }
                //if (costumeItem.ID==this.lastSelectedCostumeID)
                //{
                //    return;
                //}
                int firstColorRowIndex = -1;
                for (int i = 0; i < this.curOutbound.OutboundDetails.Count; i++)
                {
                    // if (this.curOutbound.OutboundDetails[i].CostumeID==this.lastSelectedCostumeID)
                    //  {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    if (costumeItem != null)
                    {
                        if (this.curOutbound.OutboundDetails[i].CostumeID == costumeItem.ID)
                        {
                            this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            if (firstColorRowIndex == -1)
                            {
                                firstColorRowIndex = i;
                                this.dataGridView1.FirstDisplayedScrollingRowIndex = firstColorRowIndex;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        private void Initialize()
        {
            if (this.curOutbound == null)
            {
                return;
            }
            if (IsPos)
            {
                this.guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, shopID);
            }
            else
            {
                this.guideComboBox1.Visible = false;
                this.skinLabel2.Visible = false;
            }
            this.skinLabel_OutboundOrderID.Text = this.curOutbound.OutboundOrder.ID;
            this.BindingOutboundSource();
        }

        private void BindingOutboundSource()
        {
            this.outboundDetailListCounterpart.Clear();
            this.dataGridView1.DataSource = null;
            if (this.curOutbound != null && this.curOutbound.OutboundDetails != null && this.curOutbound.OutboundDetails.Count > 0)
            {
                foreach (BoundDetail detail in this.curOutbound.OutboundDetails)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                    BoundDetail item = new BoundDetail();
                    detail.IsConfirmed = true;
                    CJBasic.Helpers.ReflectionHelper.CopyProperty(detail, item);
                    
                    this.outboundDetailListCounterpart.Add(item);
                }
                // this.dataGridView1.DataSource = this.curOutbound.OutboundDetails;

                dataGridViewPagingSumCtrl.BindingDataSource<BoundDetail>(this.curOutbound.OutboundDetails);
            }
            this.dataGridView1.Refresh();
        }

        //点击入库按钮
        private void BaseButton_Inbound_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) {
                    return;
                }
                
             /*   if (this.guideComboBox1.SelectedIndex == 0 && IsPos)
                {
                    GlobalMessageBox.Show("操作人不能为空");
                    return;
                }
                */
               /*  foreach (BoundDetail detail in this.curOutbound.OutboundDetails)
                {
                   // detail.IsConfirmed = true;
                   if (!detail.IsConfirmed)
                    {
                        DialogResult dialogResult= GlobalMessageBox.Show("您有商品未确认完全，是否确认收货？", "提示", MessageBoxButtons.OKCancel);
                        if (dialogResult != DialogResult.OK)
                        {
                            return;
                        }
                        break;
                    }
                    
                }*/
                InboundPara inboundPara = this.BuildInboundPara();
                if (inboundPara == null || inboundPara.InboundOrder.TotalCount == 0)
                {
                    GlobalMessageBox.Show("入库单为空,不能入库！");
                    return;
                }

                InboundResult result = CommonGlobalCache.ServerProxy.Inbound(inboundPara);

                if (result == InboundResult.Error)
                {
                    GlobalMessageBox.Show("内部错误！");
                    return;
                }
                else if (result == InboundResult.StateIsNotDelivery)
                {
                    GlobalMessageBox.Show("款号已存在！");
                    return;
                }
                GlobalMessageBox.Show("收货成功！");

                // pos端确认后结束，在调拨入库时候
                this.BaseButton_Save.Visible = false;
                this.guideComboBox1.Visible = false;
                this.skinLabel2.Visible = false;
             
                //pos使用
                this.SaveSuccess();
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


        public static bool LockAutoInbound {get;set; }
       
        /// <summary>
        /// 自动入库
        /// </summary>
        public static bool AutoInbound(AllocateOrder allocateOrder)
        {
            bool success = true;
            if (!LockAutoInbound)
            {
                LockAutoInbound = true;
                //if (CommonGlobalCache.IsCheckStoreState)
                //{
                //    GlobalMessageBox.Show("当前库存处于盘点状态，不能进行此操作！");
                //    return false;
                //}
                //AllocateOrderPagePara pagePara = new AllocateOrderPagePara()
                //{ AllocateOrderID = allocateOrderID,
                //    AllocateOrderState = AllocateOrderState.Delivery,
                //    IsOpenDate = false,
                //  //  DestShopID = CommonGlobalCache.CurrentShopID,
                //    PageIndex = 0,
                //    PageSize = int.MaxValue
                //};
                //AllocateOrderPage listPage = CommonGlobalCache.ServerProxy.GetAllocateInboundOrderPage(pagePara);
                //if (listPage != null)
                //{
                //    foreach (var item in listPage.AllocateOrderList)
                //    {
                        Outbound outbound = CommonGlobalCache.ServerProxy.GetOneOutbound(allocateOrder.ID);
                        InboundPara inboundPara = BuildInboundPara(outbound, allocateOrder);
                        InboundResult result = CommonGlobalCache.ServerProxy.Inbound(inboundPara);

                        switch (result)
                        {
                            case InboundResult.Success:
                                break;
                            case InboundResult.StateIsNotDelivery:
                                success = false;
                                break;
                            case InboundResult.Error:
                                success = false;
                                break;
                            default:
                                break;
                        }
                        if (!success)
                        {
                            GlobalMessageBox.Show("自动入库错误！" + inboundPara.InboundOrder.ID);
                           // break;
                        }
                      
                //    }
                    LockAutoInbound = false;
              //  }
            } 
            return success;
        }

        private static InboundPara BuildInboundPara(Outbound curOutbound,AllocateOrder allocateOrder)
        {
            if (curOutbound == null || curOutbound.OutboundOrder == null || curOutbound.OutboundDetails == null || curOutbound.OutboundDetails.Count == 0)
            {
                return null;
            }

            int totalCount = 0;
            decimal totalCost = 0;
            decimal totalPrice = 0;
            List<BoundDetail> inboundDetails = new List<BoundDetail>();
            string id = IDHelper.GetID(OrderPrefix.InboundOrder, CommonGlobalCache.CurrentShop.AutoCode);
            foreach (BoundDetail detail in curOutbound.OutboundDetails)
            {
                //if (detail.SumCount <= 0)
                //{
                //    continue;
                //}
                totalCost += detail.SumCost;
                totalCount += detail.SumCount;
                totalPrice += detail.SumMoney;
                inboundDetails.Add(OutboundDetailConvertToInboundDetail(detail, id));
            }

            InboundOrder inboundOrder = new InboundOrder()
            {
                SourceOrderID = curOutbound.OutboundOrder.SourceOrderID,
                ShopID = allocateOrder.DestShopID,
                ID = id,
                OperatorUserID =string.Empty,
                CreateTime = allocateOrder.CreateTime,
                EntryTime = DateTime.Now,
                TotalCost = totalCost,
                TotalCount = totalCount,
                TotalPrice = totalPrice,
                Remarks = "自动入库",
            };

            return new InboundPara()
            {
                InboundOrder = inboundOrder,
                InboundDetails = inboundDetails
            };
        }
        private InboundPara BuildInboundPara()
        {
            if (this.curOutbound == null || this.curOutbound.OutboundOrder == null || this.curOutbound.OutboundDetails == null || this.curOutbound.OutboundDetails.Count == 0)
            {
                return null;
            }

            int totalCount = 0;
            decimal totalPrice = 0;
            decimal totalCost = 0;
            List<BoundDetail> inboundDetails = new List<BoundDetail>();
            string id = IDHelper.GetID(OrderPrefix.InboundOrder, CommonGlobalCache.CurrentShop.AutoCode);
            foreach (BoundDetail detail in this.curOutbound.OutboundDetails)
            {
                //if (detail.SumCount <= 0)
                //{
                //    continue;

                //}
                totalCost += detail.SumCost;
                totalCount += detail.SumCount;
                totalPrice += detail.SumMoney;
                inboundDetails.Add(OutboundDetailConvertToInboundDetail(detail, id));
            }
            if (CommonGlobalCache.CurrentUser.Type == UserInfoType.Admin)
            {
               AllocateOrder allocateOrder=CommonGlobalCache.ServerProxy.GetAllocateOrder(this.curOutbound.OutboundOrder.SourceOrderID);
                shopID = allocateOrder.DestShopID;
                
            }
            InboundOrder inboundOrder = new InboundOrder()
            {
                SourceOrderID = this.curOutbound.OutboundOrder.SourceOrderID,
                ShopID = shopID,
                ID = id,
                OperatorUserID = //IsPos ? (string)this.guideComboBox1.SelectedValue :
                CommonGlobalCache.CurrentUserID,
                CreateTime = DateTime.Now,
                EntryTime = DateTime.Now,
                TotalCost = totalCost,
                TotalCount = totalCount,
                
                TotalPrice = totalPrice,
                Remarks = this.skinTextBox_Remarks.SkinTxt.Text,
            };

            return new InboundPara()
            {
                InboundOrder = inboundOrder,
                InboundDetails = inboundDetails
            };
        }

        #region 转换与对象生成
        private static BoundDetail OutboundDetailConvertToInboundDetail(BoundDetail outboundDetail, string inboundID)
        {

            BoundDetail b = new BoundDetail();
            CJBasic.Helpers.ReflectionHelper.CopyProperty(outboundDetail, b);
            //370 调拨单查询：入库明细为空，不能根据款号查询调拨单
            b.BoundOrderID = inboundID;
            return b;
        }


        private BoundDetail CostumeStoreConvertToOutboundDetail(CostumeStore costumeStore)
        {
            return new BoundDetail()
            {
                CostumeID = costumeStore.CostumeID,
                ColorName = costumeStore.ColorName,
                CostumeName = costumeStore.CostumeName,
                Price = costumeStore.Price
            };
        } 
        #endregion

        #region 验证单元格中的值
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            { 

                if (CommonGlobalUtil.NotStoreColumnIndex(e.ColumnIndex, fDataGridViewTextBoxColumn.Index, xL6DataGridViewTextBoxColumn.Index))
                {
                    return;
                }

                int newCount = 0;
                if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    newCount = Convert.ToInt32(e.FormattedValue);
                }
                if (newCount < 0)
                {
                    GlobalMessageBox.Show("入库数不能小于0！");
                    this.dataGridView1.CancelEdit();
                    return;
                }
            }
            catch
            {
                GlobalMessageBox.Show("输入格式错误！");
                this.dataGridView1.CancelEdit();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                int newvalue =Convert.ToInt32( this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                string propertyName = this.dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
                int oldvalue = Convert.ToInt32(CJBasic.Helpers.ReflectionHelper.GetProperty(this.outboundDetailListCounterpart[e.RowIndex], propertyName));

                if (newvalue != oldvalue)
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                }
                else
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                }
                this.dataGridView1.Refresh();
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.WriteLog(ee);
            }

        }


        #endregion

        #region 点击单元格
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                switch (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    case "删除":
                        DialogResult dialogResult = GlobalMessageBox.Show("确定删除该条数据？", "提示", MessageBoxButtons.OKCancel);
                        if (dialogResult != DialogResult.OK)
                        {
                            return;
                        }
                        //this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                        this.curOutbound.OutboundDetails.RemoveAt(e.RowIndex);
                        this.BindingOutboundSource();
                        break;
                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.WriteLog(ee);
            }
        }

        #endregion

        private void skinCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.curOutbound == null || this.curOutbound.OutboundDetails == null|| this.curOutbound.OutboundDetails.Count==0)
            {
                return;
            }
            if (this.skinCheckBox1.Checked)
            {
                foreach (BoundDetail detail in this.curOutbound.OutboundDetails)
                {
                    detail.IsConfirmed = true;
                }
            }
            else
            {
                foreach (BoundDetail detail in this.curOutbound.OutboundDetails)
                {
                    detail.IsConfirmed = false;
                }
            }
            this.dataGridView1.Refresh();
        }
 
    }
}
