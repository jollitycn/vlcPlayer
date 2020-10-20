using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin;
using JGNet.Common.Core;
using JGNet.Common;
using JGNet.Core.InteractEntity;
using JGNet.Common.Components;
using JGNet.Core;
using CJBasic.Helpers;
using JGNet.Common.Core.Util;

namespace JGNet.Common
{
    /// <summary>
    /// 差异单：管理端查看所有店铺，POS是本店，工作台进入只查看总仓需要处理的单
    /// </summary>
    public partial class DifferenceOrderConfirmCtrl : BaseModifyCostumeIDUserControl
    {
        private DifferenceOrder curDifferenceOrder;
        private bool isCheckStoreOrder = false;//是盘点差异单？
        List<CheckStoreDetail> checkStoreDetails = null;
        List<BoundDetail> inboundDetails = null;
        public CJBasic.Action<bool, EventArgs> WorkDesk_Refresh;
        private List<DifferenceDetailConfirmModel> models = new List<DifferenceDetailConfirmModel>();//被绑定的差异确认明细

        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        public DifferenceOrderConfirmCtrl(DifferenceOrder differenceOrder)
        {
            InitializeComponent();
            InitDataGridView();
            this.curDifferenceOrder = differenceOrder;
            this.Initialize(differenceOrder);
        }

        private void InitDataGridView()
        {
            MenuPermission = RolePermissionMenuEnum.差异单查询;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1, new string[] {
                 outboundCountDataGridViewTextBoxColumn.DataPropertyName,
     inboundCountDataGridViewTextBoxColumn.DataPropertyName, 
        differenceCountDataGridViewTextBoxColumn.DataPropertyName,
    });
            dataGridViewPagingSumCtrl.Initialize();
        }

        public DifferenceOrderConfirmCtrl()
        {
            InitializeComponent();
            InitDataGridView();
        }

        public void Print()
        {
            DifferenceOrderPrinter.Print(curDifferenceOrder, dataGridView1, 2);
        }

        public void Search(DifferenceOrder differenceOrder)
        {
            this.curDifferenceOrder = differenceOrder;
            this.Initialize(differenceOrder);
        }

        public void Initialize(DifferenceOrder differenceOrder = null)
        {
            this.skinLabel_OrderID.Text = string.Empty;
            if (this.models != null)
            {

                this.models.Clear();
            }
            else
            {
                this.models = new List<DifferenceDetailConfirmModel>();
            }

            SetDisplay();
            //如果调拨单
            if (CommonGlobalUtil.OrderType(differenceOrder?.SourceOrderID).Equals("调拨"))
            {
                bool canEdit = HasPermission(RolePermissionEnum.编辑);
                baseButtonConfirm.Enabled = canEdit;
                BaseButtonCancel.Enabled = canEdit;
                if (differenceOrder.Confirmed)
                {
                    baseButtonConfirm.Visible = false;
                    BaseButtonCancel.Visible = false;
                }
            }
            else
            {
                baseButtonConfirm.Visible = false;
                BaseButtonCancel.Visible = false;
            }

            if (differenceOrder != null)
            {
                this.curDifferenceOrder = differenceOrder;
            }

            this.skinLabel_SendShop.Visible = false;
            this.skinLabel_ReceiveShop.Visible = false;
            this.skinLabel_operator.Visible = false;
            if (this.curDifferenceOrder != null)
            {
                //  盘点单店铺不是本店的  和  差异单发货方不是本店的  不可以确认差异 
                skinLabel_operator.Visible = false;
                this.guideComboBox1.Visible = false;
               
                this.skinLabel_OrderID.Text = "差异单号：" + this.curDifferenceOrder.ID;
                this.skinLabel_SendShop.Text = "发货方：" + CommonGlobalCache.GetShopName(this.curDifferenceOrder.OutboundShopID);
                this.skinLabel_ReceiveShop.Text = "收货方：" + CommonGlobalCache.GetShopName(this.curDifferenceOrder.InboundShopID);
                this.skinLabel_operator.Text = "操作人：" + CommonGlobalCache.GetUserName(this.curDifferenceOrder.ConfirmUserID);
                if (this.curDifferenceOrder.InboundShopID == this.curDifferenceOrder.OutboundShopID)
                {
                    this.isCheckStoreOrder = true;

                    if (!LoadSnagShot())
                    { return; }
                    outboundCountDataGridViewTextBoxColumn.HeaderText = "账面数";
                    inboundCountDataGridViewTextBoxColumn.HeaderText = "实盘数";
                    this.skinLabel_SendShop.Visible = false;
                    this.skinLabel_ReceiveShop.Visible = false; 
                    this.checkStoreDetails = CommonGlobalCache.ServerProxy.GetCheckStoreDetail(this.curDifferenceOrder.SourceOrderID);
                }
                else
                {
                    //this.BaseButtonCancel.Visible = !curDifferenceOrder.Confirmed;
                    //this.baseButtonConfirm.Visible = !curDifferenceOrder.Confirmed;
                   // this.guideComboBox1.Visible = !curDifferenceOrder.Confirmed && IsPos;
                    this.skinLabel_SendShop.Visible = true;
                    this.skinLabel_ReceiveShop.Visible = true;
                    //this.skinLabel_operator.Visible = true; 
                    this.inboundDetails = CommonGlobalCache.ServerProxy.GetInboundDetail(this.curDifferenceOrder.InboundOrderID);
                }

                if (curDifferenceOrder?.OutboundShopID != CommonGlobalCache.CurrentShopID)
                {
                    this.BaseButtonCancel.Visible = false;
                    this.baseButtonConfirm.Visible = false;
                    this.guideComboBox1.Visible = false;
                    this.skinLabel_operator.Visible = false;
                }

                List<DifferenceDetail> differenceDetails = CommonGlobalCache.ServerProxy.GetDifferenceDetail(this.curDifferenceOrder.ID);
                if (differenceDetails != null)
                {
                    foreach (DifferenceDetail detail in differenceDetails)
                    {
                        foreach (string sizeName in CostumeStoreHelper.CostumeSizeColumn)
                        {
                            String dbSize = sizeName; //CostumeStoreHelper.GetCostumeSize(sizeName, sizeGroup);
                            int differenceCount = Convert.ToInt32(CJBasic.Helpers.ReflectionHelper.GetProperty(detail, sizeName));

                            if (differenceCount != 0)
                            {
                                //实盘
                                int inboundCount = this.GetInboundCount(differenceCount, detail, dbSize);
                                int outboundCount = 0;
                                //变化数
                                int changeCount = 0;
                                if (isCheckStoreOrder)
                                {
                                    //盘点单，库存数=盘点数-差异数
                                    changeCount = this.GetChangeCount(detail, dbSize);
                                    outboundCount = this.GetOutboundCount(detail, dbSize); ;
                                }
                                else
                                {
                                    //调拨、补货
                                    outboundCount = inboundCount + differenceCount;
                                }

                                DifferenceDetailConfirmModel model = new DifferenceDetailConfirmModel()
                                {
                                    CostumeID = detail.CostumeID,
                                    CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID),
                                    ColorName = detail.ColorName,
                                    SizeName = dbSize,
                                    DifferenceCount = differenceCount,
                                    InboundCount = inboundCount,
                                    OutboundCount = outboundCount,
                                    ChangeCount = changeCount

                                };
                                this.models.Add(model);
                            }
                        }
                    }
                }
            }
            this.BindingSource();
        }

        private bool LoadSnagShot()
        {
            bool success = true;
           // InteractResult result = CommonGlobalCache.ServerProxy.GetCheckStoreTaskID4DifferenceOrder(this.curDifferenceOrder.SourceOrderID);
            String taskID = String.Empty;
            //switch (result.ExeResult)
            //{
            //    case ExeResult.Success:
            //        taskID = result.Msg;
            //        break;
            //    case ExeResult.Error:
            //        GlobalMessageBox.Show(result.Msg);
            //        break;
            //    default:
            //        break;
            //}

            if (String.IsNullOrEmpty(taskID))
            {
                GlobalMessageBox.Show("找不到盘点任务编号!");
                success = false;
                return success;
            }

           // shots = CommonGlobalCache.ServerProxy.GetCostumeStoreSnapshots(new CostumeStoreListPara() { ShopID = curDifferenceOrder.OutboundShopID, CheckStoreTaskID = taskID });
            return success;
        }

       // List<CostumeStoreSnapshotInfo> shots = null;

        private void SetDisplay()
        {
            if (IsPos)
            {
                this.guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, CommonGlobalCache.CurrentShopID);
            }
            else
            {
                this.guideComboBox1.Visible = false;
            }
        }

        private void BindingSource()
        {
            if (this.models != null && this.models.Count > 0)
            {
                foreach (var item in models)
                {
                    item.DisplaySizeName = CommonGlobalUtil.GetCostumeSizeName(item.CostumeID, item.SizeName);
                }
            }

            dataGridViewPagingSumCtrl.BindingDataSource<DifferenceDetailConfirmModel>(models);
        }


        private int GetChangeCount(DifferenceDetail detail, string size)
        {
            int count = 0;
            foreach (CheckStoreDetail checkStoreDetail in checkStoreDetails)
            {
                if (checkStoreDetail.CostumeID == detail.CostumeID && checkStoreDetail.ColorName == detail.ColorName)
                {
                    count = Convert.ToInt32(CJBasic.Helpers.ReflectionHelper.GetProperty(checkStoreDetail, size + "Atm"));
                    break;
                }
            }

            return count;
        }

        private int GetOutboundCount(DifferenceDetail detail, string size)
        {
            int count = 0;
            //if (shots != null)
            //{
            //    CostumeStoreSnapshotInfo shotInfo = shots.Find(t => t.Costume.ID == detail.CostumeID);
            //    if (shotInfo != null)
            //    {
            //        foreach (CostumeStoreSnapshot checkStoreDetail in shotInfo.CostumeStoreSnapshots)
            //        {
            //            if (checkStoreDetail.CostumeID == detail.CostumeID && checkStoreDetail.ColorName == detail.ColorName)
            //            {
            //                count = Convert.ToInt32(CJBasic.Helpers.ReflectionHelper.GetProperty(checkStoreDetail, size));
            //                break;
            //            }
            //        }
            //    }
            //}

            return count;
        }


        private int GetInboundCount(int differenceCount, DifferenceDetail detail, string size)
        {
            int inboundCount = 0;
            if (this.isCheckStoreOrder)
            {
                foreach (CheckStoreDetail checkStoreDetail in checkStoreDetails)
                {
                    if (checkStoreDetail.CostumeID == detail.CostumeID && checkStoreDetail.ColorName == detail.ColorName)
                    {
                        inboundCount = Convert.ToInt32(CJBasic.Helpers.ReflectionHelper.GetProperty(checkStoreDetail, size));
                        break;
                    }
                }
            }
            else
            {
                foreach (BoundDetail inboundDetail in inboundDetails)
                {
                    if (inboundDetail.CostumeID == detail.CostumeID && inboundDetail.ColorName == detail.ColorName)
                    {
                        inboundCount = Convert.ToInt32(CJBasic.Helpers.ReflectionHelper.GetProperty(inboundDetail, size));
                        break;
                    }
                }
            }
            return inboundCount;
        }


        private void BaseButton1_Click(object sender, EventArgs e)
        {
            try
            { 
                if (this.guideComboBox1.Visible && this.guideComboBox1.SelectedIndex == 0)
                {
                    GlobalMessageBox.Show("操作人不能为空");
                    return;
                }
                if (GlobalMessageBox.Show("是否确认操作？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;

                }
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                DifferenceOrderConfirmedResult result = CommonGlobalCache.ServerProxy.DifferenceOrderConfirmed(new DifferenceOrderConfirmedPara()
                {
                    DifferenceOrderID = this.curDifferenceOrder.ID,
                    ConfirmUserID = IsPos ? ValidateUtil.CheckEmptyValue(this.guideComboBox1.SelectedValue) : CommonGlobalCache.CurrentUserID
                });
                switch (result)
                {
                    case DifferenceOrderConfirmedResult.Success:
                        GlobalMessageBox.Show("确认成功!");
                        if (IsPos)
                        {

                            this.guideComboBox1.Visible = false;
                            this.skinLabel_operator.Text = "操作人：" + ((Guide)this.guideComboBox1.SelectedItem).Name;
                        }
                        else
                        {
                            this.skinLabel_operator.Text = "操作人：" + CommonGlobalCache.GetUserName( CommonGlobalCache.CurrentUser.ID);
                        }
                        this.BaseButtonCancel.Visible = false;
                        this.baseButtonConfirm.Visible = false;
                        WorkDesk_Refresh?.Invoke(false, null);
                        this.RefreshPageAction?.Invoke(this.CurrentTabPage, this.SourceCtrlType);
                        break;
                    case DifferenceOrderConfirmedResult.SourceOrderIDIsError:
                        GlobalMessageBox.Show("不是盘点，补货申请或者调拨!");
                        break;
                    case DifferenceOrderConfirmedResult.IsConfirmed:
                        GlobalMessageBox.Show("本单已被确认！");
                        break;
                    case DifferenceOrderConfirmedResult.Error:
                        GlobalMessageBox.Show("内部错误!");
                        break;
                    default:
                        break;
                }
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

        public override void HighlightCostume()
        {
            if (dataGridView1.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        DifferenceDetailConfirmModel detail = row.DataBoundItem as DifferenceDetailConfirmModel;
                        HighlightCostume(row, detail?.CostumeID);
                    }
                }
            }
        }

        private void BaseButtonCancel_Click(object sender, EventArgs e)
        {
            try
            {

               
                if (this.guideComboBox1.Visible && this.guideComboBox1.SelectedIndex == 0)
                {
                    GlobalMessageBox.Show("操作人不能为空");
                    return;
                }
                if (GlobalMessageBox.Show("是否确认操作？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;

                }
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                InteractResult result = CommonGlobalCache.ServerProxy.CancelDifferenceOrder(this.curDifferenceOrder.ID);
                switch (result.ExeResult)
                {
                    case ExeResult.Success:
                        GlobalMessageBox.Show("取消成功!");
                        if (IsPos)
                        {
                            this.guideComboBox1.Visible = false;
                            this.skinLabel_operator.Text = "操作人：" + ((Guide)this.guideComboBox1.SelectedItem).Name;
                        }
                        else
                        {
                            this.skinLabel_operator.Text = "操作人：" + CommonGlobalCache.GetUserName(CommonGlobalCache.CurrentUser.ID);
                        }
                        this.BaseButtonCancel.Visible = false;
                        this.baseButtonConfirm.Visible = false;
                        WorkDesk_Refresh?.Invoke(false, null);
                        this.RefreshPageAction?.Invoke(this.CurrentTabPage, this.SourceCtrlType);
                        break;
                    case ExeResult.Error:
                        GlobalMessageBox.Show(result.Msg);
                        break;
                    default:
                        break;
                }
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
    }
}