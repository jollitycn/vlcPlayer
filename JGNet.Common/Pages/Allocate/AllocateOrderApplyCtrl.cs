using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Common;
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Core;
using JGNet.Common.Components;
using JGNet.Common.Core.Util;
using JGNet.Common.Core;
using CJBasic.Helpers;
using JGNet.Manage;

namespace JGNet.Common
{
    /// <summary>
    /// 调拨
    /// </summary>
    public partial class AllocateOrderApplyCtrl : BaseModifyUserControl
    {
        public override void HandleShortKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F3:
                    BaseButton3.PerformClick();
                    break;
                case Keys.F4:
                    BaseButtonConfirm.PerformClick();
                    break;
                default:
                    break;
            }
        }

     //   private Shop shop;
        private string operatorId;
        private AllocateType curAllocateType;
        private AllocateOrder order; 
        private List<CostumeStore> curSelectedCostumeStoreList;//当前被选中的CostumeStore集合
        private List<BoundDetail> curDetailList = new List<BoundDetail>();//当前要出库的CostumeStore

        private List<CostumeStore> orderStoreCache = new List<CostumeStore>();//临时缓存信息
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl2;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl1;
        private OperationEnum action;
        private void Init()
        {
            MenuPermission =RolePermissionMenuEnum.调拨;
            skinComboBoxShopID.Tag = RolePermissionMenuEnum.不限;
            if (IsPos) {
                PriceColumn.ReadOnly = true;
                SalePriceColumn.ReadOnly = true;
                priceDataGridViewTextBoxColumn.ReadOnly = true;
                SalePrice.ReadOnly = true;
                skinLabelNotice.Text = "下表的数量可以修改";
            }

            if (!HasPermission(RolePermissionMenuEnum.调拨, RolePermissionEnum.单据时间))
            {
                dateTimePicker_Start.Enabled = false;
            }
            dataGridViewPagingSumCtrl1 = new DataGridViewPagingSumCtrl(this.dataGridView1);
            dataGridViewPagingSumCtrl1.Initialize();
            dataGridViewPagingSumCtrl1.ShowRowCounts = false;
            if (order != null)
            {
                dateTimePicker_Start.Value = order.CreateTime;
                this.curAllocateType = (AllocateType)Enum.Parse(typeof(AllocateType), order?.AllocateType.ToString());
            }

            dataGridViewPagingSumCtrl2 = new DataGridViewPagingSumCtrl(this.dataGridView2, new String[] {
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
             SumMoney.DataPropertyName});

            dataGridViewPagingSumCtrl2.SpecAutoSizeModeColumns(new DataGridViewColumn[] { costumeIDDataGridViewTextBoxColumn });
            dataGridViewPagingSumCtrl2.ShowRowCounts = false;
            dataGridViewPagingSumCtrl2.Initialize();

            dataGridView2.AutoGenerateColumns = false;
        }

        public AllocateOrderApplyCtrl(AllocateOrder order, OperationEnum action = OperationEnum.Add)
        {
            InitializeComponent();
             
            this.order = order;
            this.action = action;
            if (action == OperationEnum.Redo)
            {
                if (!HasPermission(RolePermissionMenuEnum.调拨单查询, RolePermissionEnum.重做_单据时间))
                {
                    dateTimePicker_Start.Enabled = false;
                }
            }
            Init();
            LoadConfig();
        }

        public AllocateOrderApplyCtrl()
        {
            InitializeComponent();

            IsShowOnePage = true;
            Init();
            LoadConfig();
        }

        public AllocateOrderApplyCtrl(AllocateType type)
        {
            InitializeComponent();
            IsShowOnePage = true;
            Init();
            curAllocateType = type;
            LoadConfig();
        }
     
        private void Initialize()
        {
            orderStoreCache = new List<CostumeStore>();
            curDetailList = new List<BoundDetail>();
            //SetDisplay();

            operatorId = CommonGlobalCache.CurrentUserID;
            DataGridViewUtil.SetAlternatingColor(dataGridView1, Color.Gainsboro, Color.White);
            this.CostumeCurrentShopTextBox1.SkinTxt.Text = string.Empty;
            this.skinTextBox_Remarks.SkinTxt.Text = string.Empty;
            SetShop();

            this.BindingSelectedCostumeStoreSource(null);
            this.BindingInboundDetailSource();

        }

      /*  private void SetDisplay()
        {
            if (this.action == OperationEnum.Send)
            {
                shopComboBox1.SelectedValue = CommonGlobalCache.GeneralStoreShopID;

                this.skinComboBoxShopID.SelectedValue = order.DestShopID;
            }
            else
            {
                shopComboBox1.SelectedValue = CommonGlobalCache.CurrentShopID;
            }
            
           // this.skinLabel3.Visible = BaseUserControl.IsPos;
           // this.guideComboBox1.Visible = BaseUserControl.IsPos;
           
            operatorId = CommonGlobalCache.CurrentUserID;
        }
        */

        private DataGridView deepCopyDataGridView()
        {
            DataGridView dgvTmp = new DataGridView();

            dgvTmp.Name = "dgvTmp";
            this.Controls.Add(dgvTmp); 
            dgvTmp.AutoGenerateColumns = false;
            //  dgvTmp.AllowUserToAddRows = false; //不允许用户生成行，否则导出后会多出最后一行
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dgvTmp.Columns.Add(dataGridView2.Columns[i].Name, dataGridView2.Columns[i].HeaderText);
                if (dataGridView2.Columns[i].DefaultCellStyle.Format.Contains("N")) //使导出Excel文档金额列可做SUM运算
                {
                    dgvTmp.Columns[i].DefaultCellStyle.Format = dataGridView2.Columns[i].DefaultCellStyle.Format;

                }
                if (!dataGridView2.Columns[i].Visible)
                {
                    dgvTmp.Columns[i].Visible = false;
                }
                dgvTmp.Columns[i].DataPropertyName = dataGridView2.Columns[i].DataPropertyName;
                dgvTmp.Columns[i].HeaderText = dataGridView2.Columns[i].HeaderText;
                dgvTmp.Columns[i].Tag = dataGridView2.Columns[i].Tag;
                dgvTmp.Columns[i].Name = dataGridView2.Columns[i].Name;
            }



            List<BoundDetail> listtb1 = DataGridViewUtil.BindingListToList<BoundDetail>(dataGridView2.DataSource);

            List<BoundDetail> tb2 = new List<BoundDetail>();
            foreach (BoundDetail idetail in listtb1)
            {
                BoundDetail tDetail = new BoundDetail();
                ReflectionHelper.CopyProperty(idetail, tDetail);
                tb2.Add(tDetail);

            }

            dgvTmp.DataSource = tb2;



            return dgvTmp;
        }

        //点击出库按钮
        private void Save(bool isHang) { 
            try
            {
               
                if (skinComboBoxShopID.DataSource == null || (skinComboBoxShopID.DataSource as List<Shop>).Count == 0)
                {
                    GlobalMessageBox.Show("没有店铺可以调拨");
                    return;
                }
                /*  if (this.guideComboBox1.SelectedIndex == 0 && IsPos)
                  {
                      GlobalMessageBox.Show("操作人不能为空!");
                      return;
                  }*/
                bool isSuperLen = false; 
                foreach (BoundDetail detail in this.curDetailList)
                {
                    if ((detail.Price > 0 && detail.Price > Convert.ToDecimal(99999999.99) )||(detail.SalePrice > 0 && detail.SalePrice > Convert.ToDecimal(99999999.99))
                        || (detail.SumMoney > 0 && detail.SumMoney > Convert.ToDecimal(99999999.99)))
                    {
                        isSuperLen = true;
                        break;
                    } 
                }
                if (isSuperLen)
                {
                    GlobalMessageBox.Show("列表中吊牌价、售价或每款总金额不能大于99999999.99");
                    return;
                }
                    AllocateOutboundPara item = this.Build();
                if (item == null || item.OutboundOrder.TotalCount == 0)
                {
                    GlobalMessageBox.Show("调拨单为空,不能出库！");
                    return;
                }

                if (action == OperationEnum.Send )
                {
                    item.ReplenishOrderID = order.ID;
                } 
                else
                {
                    item.ReplenishOrderID = null;
                }

                if (GlobalMessageBox.Show("是否确认操作？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;

                }
                //检查库存信息

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                InteractResult result = null;
                if (isHang)
                { 
                    result = CommonGlobalCache.ServerProxy.HangUpAllocateOrder(item);
                }
                else {
                    result = CommonGlobalCache.ServerProxy.AllocateOutbound(item);
                }
                

                switch (result.ExeResult)
                {
                    case ExeResult.Success:
                        if (isHang)
                        {
                            GlobalMessageBox.Show("挂单成功！");
                        }
                        else
                        {
                            GlobalMessageBox.Show("调拨成功！");
                            //增加打印功能,先给后台使用
                            if (this.skinCheckBoxPrint.Checked)
                            {
                                //   AllocateOrderPrinter.ExcelTemplatePrint(item, curDetailList);
                                //Column2.Visible = false;
                                //SumMoney.Visible = false;
                                //Column2.Tag = AllocateOrderPrintUtil.PrinterNoCount;
                                //SumMoney.Tag = AllocateOrderPrintUtil.PrinterNoCount;
                                DataGridView dgv = deepCopyDataGridView();
                                AllocateOrderPrintUtil.Print(item.AllocateOrder, dgv);
                                //SumMoney.Visible = true;
                                //Column2.Visible = true;
                            }

                            //if (CommonGlobalCache.GetParameter(ParameterConfigKey.AllocateInDirectly)?.ParaValue == "1")
                            //{
                            //    if (InboundConfirmCtrl.AutoInbound(item.AllocateOrder))
                            //    {
                                   
                            //    }
                            //} 
                        }
                        ResetAll(true);

                        if (!IsShowOnePage)
                        {
                            TabPageClose(this.CurrentTabPage, this.SourceCtrlType);
                        }
                        break;
                    case ExeResult.Error:
                        GlobalMessageBox.Show(result.Msg);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }

        private AllocateOutboundPara Build()
        {
            if (this.curDetailList == null || this.curDetailList.Count == 0)
            {
                return null;
            }
            int totalCount = 0;
            decimal totalCost = 0;
            decimal totalPrice = 0;
            List<BoundDetail> details = new List<BoundDetail>();
         
            string id = IDHelper.GetID(OrderPrefix.OutboundOrder, shop.AutoCode);
            String pOrderID = IDHelper.GetID(OrderPrefix.AllocateOrder, shop.AutoCode);
            if (action == OperationEnum.Pick)
            {
                pOrderID = this.order.ID;
            }

            foreach (BoundDetail detail in this.curDetailList)
            {
                if (detail.SumCount <= 0)
                {
                    continue;
                }
                totalCost += detail.SumCost;
                totalCount += detail.SumCount;
                totalPrice += detail.SumMoney;
                detail.BoundOrderID = id; 

                details.Add(detail);
                //  details.Add(this.InboundDetailConvertToOutboundDetail(detail, id));
            }

            OutboundOrder order = new OutboundOrder()
            {
                SourceOrderID = pOrderID, 
                ID = id,
                OperatorUserID = operatorId,
                ShopID = shop.ID,
                CreateTime = dateTimePicker_Start.Value,
                 EntryTime = DateTime.Now,
                TotalCount = totalCount,
                TotalPrice = totalPrice, 
                TotalCost = totalCost,
               
                Remarks = this.skinTextBox_Remarks.SkinTxt.Text
                
                 
            };


            AllocateOrder pOrder = new AllocateOrder()
            { 
                AllocateType = (byte)this.curAllocateType,
                ID = pOrderID,
                SourceUserID = order.OperatorUserID,
                OutboundOrderID = order.ID,
                InboundOrderID = String.Empty,
                DestShopID = ValidateUtil.CheckEmptyValue(this.skinComboBoxShopID.SelectedValue),
                CreateTime = dateTimePicker_Start.Value,
                EntryTime = DateTime.Now,
                TotalCount = totalCount,
                TotalPrice = totalPrice,  
                State = 0,
                SourceShopID = order.ShopID,
                Remarks = this.skinTextBox_Remarks.SkinTxt.Text
                 
                // InboundOrderID=  
            };

            return new AllocateOutboundPara()
            {  
                AllocateOrder = pOrder,
                OutboundOrder = order,
                OutboundDetailList = details
            };


        }



        #region 验证单元格中的值




        #endregion

        private void CostumeCurrentShopTextBox1_CostumeSelected(CostumeItem costumeItem, bool isEnter)
        {

            if (isEnter)
            {
                if (costumeItem == null)
                {
                    //  this.CostumeCurrentShopTextBox1.SkinTxt.Text = "";
                    this.curSelectedCostumeStoreList = null;
                }
                else
                {
                    //    this.CostumeCurrentShopTextBox1.SkinTxt.Text = costumeItem.Costume.ID;
                    this.curSelectedCostumeStoreList = costumeItem.CostumeStoreList;
                }
               // SetCostumeColors(costumeItem);
                this.BindingSelectedCostumeStoreSource(null);
            }

        }

        private CostumeItem CostumeItem { get; set; }
        private void SetCostumeColors(CostumeItem costumeItem)
        {
            // orgStores = null;
            // newStores = null;
            this.skinComboBox_Color.DataSource = null;
            if (costumeItem != null)
            {
                this.CostumeItem = costumeItem;
                this.SetCostumeDetailsColors(costumeItem);
            }
        }
        private void SetCostumeDetailsColors(CostumeItem costumeItem)
        {
            if (costumeItem == null)
            {
                return;
            }
            this.CostumeItem = costumeItem;
            if (CostumeItem.Costume != null && CostumeItem.Costume.ColorList.Count > 0)
            {
                List<String> colors = new List<string>();
                foreach (var item in CostumeItem.Costume.ColorList)
                {
                    colors.Add(item);
                }
                this.skinComboBox_Color.DataSource = colors.ToArray();
                this.skinComboBox_Color.SelectedItem = CostumeItem.Costume.ColorList[0];
            }
        }

            /// <summary>
            /// 绑定要补货的集合源
            /// </summary>
            private void BindingInboundDetailSource()
        {
            if (this.curDetailList != null && this.curDetailList.Count > 0)
            {
                foreach (BoundDetail detail in this.curDetailList)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                    Costume cItem=CommonGlobalCache.GetCostume(detail.CostumeID);
                    detail.Year = cItem.Year;
                    detail.Season = cItem.Season;
                    if (detail.Comment == null)
                    {
                        detail.Comment = "";
                    }


                }

                
            /*    CostumeStore destShopStore = item?.CostumeStoreList?.Find(t => t.CostumeID == store.CostumeID && t.ColorName == store.ColorName );
                if (destShopStore != null)
                {
                    //取收货方的吊牌价售价
                    store.Price = destShopStore.Price;
                    store.SalePrice = destShopStore.SalePrice;
                }
                */
            //  this.dataGridView2.DataSource = this.curDetailList;

            }

             
            dataGridViewPagingSumCtrl2.BindingDataSource<BoundDetail>(DataGridViewUtil.ListToBindingList(this.curDetailList));
            dataGridViewPagingSumCtrl2.ScrollToEnd();
        }

        /// <summary>
        /// 绑定选定款号对应的CostumeStore集合
        /// </summary>
        private void BindingSelectedCostumeStoreSource(BoundDetail detail)
        {
            try
            {
                if (this.curSelectedCostumeStoreList != null && this.curSelectedCostumeStoreList.Count > 0)
                {
                    List<CostumeStore> tempList = new List<CostumeStore>();
                    foreach (CostumeStore store in this.curSelectedCostumeStoreList)
                    {

                        store.Title = "库存";
                        // store.Price = 0;
                        // store.CostumeName = CommonGlobalCache.GetCostumeName(store.CostumeID);
                        //CJBasic.Helpers.ReflectionHelper.CopyProperty(store, obj);

                        //  this.ReadOnly = true;
                        List<CostumeItem> resultList = CommonGlobalCache.ServerProxy.GetCostumeStoreList(
                            new CostumeStoreListPara()
                            {
                                CostumeID = store.CostumeID,
                                ShopID = ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue),
                                IsOnlyShowValid = false
                            });


                        CostumeItem item = resultList?.Find(t => t.Costume.ID == store.CostumeID);
                        CostumeStore destShopStore = item?.CostumeStoreList?.Find(t => t.CostumeID == store.CostumeID && t.ColorName == store.ColorName);
                        if (destShopStore != null)
                        {
                            //取收货方的吊牌价售价
                            store.Price = destShopStore.Price;
                            store.SalePrice = destShopStore.SalePrice;
                        } 
                        CostumeStore tempStore = this.BuildCostumeStore4NeedReplenish(store, detail);
                        tempList.Add(store);
                        tempList.Add(tempStore); 
                    }
                    this.curSelectedCostumeStoreList = tempList;
                } 
                List<CostumeStore> selectResultList=new List<CostumeStore>();

             /*   if (this.skinComboBox_Color.DataSource!= null && this.curSelectedCostumeStoreList != null &&  this.skinComboBox_Color.SelectedValue != null)
                {
                     selectResultList = this.curSelectedCostumeStoreList.FindAll(t => t.ColorName == ValidateUtil.CheckEmptyValue(this.skinComboBox_Color.SelectedValue));
                } */

                 dataGridViewPagingSumCtrl1.BindingDataSource(DataGridViewUtil.ListToBindingList(curSelectedCostumeStoreList)); 
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index % 2 == 0)
                    {
                        row.ReadOnly = true;
                        row.HeaderCell.Value = "库存";

                    }
                    else
                    {
                        row.ReadOnly = false;
                        row.HeaderCell.Value = "调拨";
                    }
                }

                // curSelectedCostumeStoreList = null;
                dataGridViewPagingSumCtrl1.AutoFocusToWritableCell();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            finally
            {
                //  this.ReadOnly = false;
            }
        }

        /// <summary>
        /// 根据现在库存对象生成需补货的库存对象
        /// </summary>
        /// <param name="oldCostumeStore"></param>
        /// <returns></returns>
        private CostumeStore BuildCostumeStore4NeedReplenish(CostumeStore oldCostumeStore, BoundDetail detail)
        {
            CostumeStore store = null;

            if (oldCostumeStore != null)
            {
                store = new CostumeStore();
                ReflectionHelper.CopyProperty(oldCostumeStore, store);
                store.Title = "调拨";
                store.F = 0;
                store.L = 0;
                store.XS = 0;
                store.M = 0;
                store.S = 0;
                store.XL = 0;
                store.XL2 = 0;
                store.XL3 = 0;
                store.XL4 = 0;
                store.XL5 = 0;
                store.XL6 = 0;
            };
            if (detail != null)
            {
                store.F = detail.F;
                store.L = detail.L;
                store.XS = detail.XS;
                store.M = detail.M;
                store.S = detail.S;
                store.XL = detail.XL;
                store.XL2 = detail.XL2;
                store.XL3 = detail.XL3;
                store.XL4 = detail.XL4;
                store.XL5 = detail.XL5;
                store.XL6 = detail.XL6;
            }
            return store;
        }

        /// <summary>
        /// 设置界面上服装的明细
        /// </summary>
        /// <param name="costumeItem"></param>
        private void SetCostumeDetails(CostumeItem costumeItem)
        {
            if (costumeItem == null)
            {
                this.CostumeCurrentShopTextBox1.SkinTxt.Text = "";
                this.curSelectedCostumeStoreList = null;
                CommonGlobalUtil.WriteLog("SetCostumeDetails：curSelectedCostumeStoreList" + curSelectedCostumeStoreList);
                this.BindingSelectedCostumeStoreSource(null);
            }
            else
            {
                this.CostumeCurrentShopTextBox1.SkinTxt.Text = costumeItem.Costume.ID;
                this.curSelectedCostumeStoreList = costumeItem.CostumeStoreList;
                CommonGlobalUtil.WriteLog("SetCostumeDetails：" + curSelectedCostumeStoreList?.Count);
              //  this.BindingSelectedCostumeStoreSource(null);
            }

            this.skinTextBox_Remarks.SkinTxt.Text = "";

        }

        private void BaseButton_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                if (this.curSelectedCostumeStoreList == null || this.curSelectedCostumeStoreList.Count == 0)
                {
                    return;
                }
                 
                //ValidateUtil.CheckEmptyValue(this.skinComboBoxShopID.SelectedValue),
                if (shopComboBox1.SelectedValue!=null && skinComboBoxShopID.SelectedValue != null && ValidateUtil.CheckEmptyValue(shopComboBox1.SelectedValue)== ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue))
                {
                    GlobalMessageBox.Show("发货方与收货方不能相同！");
                    return;
                }

                CommonGlobalUtil.WriteLog("添加调拨信息前：" + curSelectedCostumeStoreList?.Count);
                List<CostumeStore> costumeStoreList = this.curSelectedCostumeStoreList.FindAll((x) => x.Title == "调拨");
                CommonGlobalUtil.WriteLog("添加调拨信息后：" + costumeStoreList?.Count);
                AddStoreCache(this.curSelectedCostumeStoreList.FindAll((x) => x.Title == "库存"));
                foreach (CostumeStore store in costumeStoreList)
                {
                    if (store.SumCount == 0)
                    {
                        CommonGlobalUtil.WriteLog("跳过总数为0：" + store.CostumeID + " " + store.ColorName);
                        continue;
                    }
                    //GlobalMessageBox.Show("修改后吊牌价："+store.Price+"   "+ "修改后售价：" + store.SalePrice);

                    BoundDetail detail = this.CostumeStoreConvertToInboundDetail(store, "");
                    
                    CommonGlobalUtil.WriteLog("添加纪录：" + store.CostumeID + " " + store.ColorName);
                    this.InboundDetailListAddItem(detail);
                }
                //清空dataGirdView1的绑定源
                this.SetCostumeDetails(null);

                this.BindingInboundDetailSource();
                dataGridView1.DataSource = null;
                this.skinComboBox_Color.DataSource = null;
                this.CostumeCurrentShopTextBox1.Focus();
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }

        private void AddStoreCache(List<CostumeStore> list)
        {
            foreach (var item in list)
            {
                CostumeStore c = orderStoreCache.Find(t => t.CostumeID.ToUpper() == item.CostumeID.ToUpper() && t.ColorName == item.ColorName);
                if (c != null)
                {
                    orderStoreCache.Remove(c);
                }
                orderStoreCache.Add(item);
            }
        }

        /// <summary>
        /// 将CostumeStore转化为InboundDetail  
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        private BoundDetail CostumeStoreConvertToInboundDetail(CostumeStore store, string replenishOrderID)
        {
            if (store == null)
            {
                return null;
            }
            BoundDetail b = new BoundDetail();
            CJBasic.Helpers.ReflectionHelper.CopyProperty(store, b); 
            b.Comment = store.Remarks;
            b.Price = store.Price;
            b.SalePrice = store.SalePrice;
      
            return b;
        }

        private void InboundDetailListAddItem(BoundDetail detail)
        {
            bool existed = false;
            DialogResult result = DialogResult.No;
            BoundDetail repeatItem = null;
            foreach (BoundDetail item in this.curDetailList)
            {
                if (item.CostumeID == detail.CostumeID && item.ColorName == detail.ColorName)
                {
                    repeatItem = item;
                    existed = true;
                    result = GlobalMessageBox.Show(string.Format("款号：{0}  颜色：{1} 的服装已经存在待补货列表中，是否覆盖", item.CostumeID, item.ColorName), "", MessageBoxButtons.YesNo);

                    break;
                }

            }

            if (!existed || result == DialogResult.Yes)
            {
                //不存在或者重复时直接覆盖
                if (repeatItem != null)
                {
                    this.curDetailList.Remove(repeatItem);
                }
                this.curDetailList.Add(detail);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                switch (this.dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    case "删除":
                        this.curDetailList.RemoveAt(e.RowIndex);
                        this.BindingInboundDetailSource();
                        break;
                }
            }
            catch (Exception ee)
            {


                CommonGlobalUtil.ShowError(ee);
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            DataGridView dataGridView = (DataGridView)sender;
            bool isCostumeStoreList = dataGridView.DataSource is List<CostumeStore>;
            try
            {

                if (CommonGlobalUtil.NotStoreColumnIndex(e.ColumnIndex, PriceColumn.Index, dataGridViewTextBoxColumn12.Index))
                {
                    return;
                }

                decimal newCount = 0;
                if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    newCount = decimal.Parse(e.FormattedValue.ToString());
                }
                if (isCostumeStoreList && this.curSelectedCostumeStoreList != null && this.curSelectedCostumeStoreList.Count > e.RowIndex && this.curSelectedCostumeStoreList[e.RowIndex].Title == "库存")
                {
                    decimal oldCount = 0;
                    if (!String.IsNullOrEmpty(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString()))
                    {
                        oldCount = decimal.Parse(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString());
                    }
                    if (newCount == oldCount)
                    {
                        return;
                    }
                    GlobalMessageBox.Show("库存不能修改！");
                    dataGridView.CancelEdit();
                    return;
                }
               /* if (newCount < 0)
                {
                    GlobalMessageBox.Show("调拨数不能小于0！");
                    dataGridView.CancelEdit();
                    return;
                }*/
            }
            catch (Exception)
            {
                GlobalMessageBox.Show("输入格式错误！");
                dataGridView.CancelEdit();
            }
        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            DataGridView dataGridView = (DataGridView)sender;
            bool isCostumeStoreList = dataGridView.DataSource is List<CostumeStore>;
            try
            {

                if (CommonGlobalUtil.NotStoreColumnIndex(e.ColumnIndex, priceDataGridViewTextBoxColumn.Index, xL6DataGridViewTextBoxColumn.Index))
                {
                    return;
                }

                decimal newCount = 0;
                if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {

                        newCount = decimal.Parse(e.FormattedValue.ToString());
                }
                if (isCostumeStoreList && this.curSelectedCostumeStoreList != null && this.curSelectedCostumeStoreList.Count > e.RowIndex && this.curSelectedCostumeStoreList[e.RowIndex].Title == "库存")
                {
                    decimal oldCount = 0;
                    if (!String.IsNullOrEmpty(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString()))
                    {
                        oldCount = decimal.Parse(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString());
                    }
                    if (newCount == oldCount)
                    {
                        return;
                    }
                    GlobalMessageBox.Show("库存不能修改！");
                    dataGridView.CancelEdit();
                    return;
                }
                    if (newCount < 0)
                {
                    GlobalMessageBox.Show("调拨数不能小于0！");
                    dataGridView.CancelEdit();
                    return;
                }
            }
            catch (Exception)
            {
                GlobalMessageBox.Show("输入格式错误！");
                dataGridView.CancelEdit();
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            DataGridView dataGridView = (DataGridView)sender;
            bool isCostumeStoreList = dataGridView.DataSource is List<CostumeStore>;
            if (isCostumeStoreList)
            {
                List<CostumeStore> stores= DataGridViewUtil.BindingListToList<CostumeStore>(dataGridView1.DataSource) ;
                CostumeStore store= dataGridView.Rows[e.RowIndex].DataBoundItem as CostumeStore;
                //联动吊牌价和售价
                foreach (var item in stores)
                {
                    if (item.Title == "调拨")
                    {
                        if (e.ColumnIndex == SalePriceColumn.Index)
                        {
                            item.SalePrice = store.SalePrice;
                        }
                        else if (e.ColumnIndex == PriceColumn.Index)
                        {
                            item.Price = store.Price;
                        }
                    }
                }

                this.dataGridView1.Refresh();
                return;
            }
            this.dataGridView2.Refresh();
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex <0 || e.ColumnIndex <0) { return; }
            try
            {
                //加载库存信息
                BoundDetail detail = (BoundDetail)this.dataGridView2.CurrentRow.DataBoundItem;
                List<CostumeStore> stores = orderStoreCache.FindAll(t => t.CostumeID == detail.CostumeID && detail.ColorName == t.ColorName);
                this.curSelectedCostumeStoreList = stores;
                this.BindingSelectedCostumeStoreSource(detail);
            }
            catch {}
        }

        private void AllocateOrderCtrlDistribution_Load(object sender, EventArgs e)
        {
            Initialize();
            LoadOrder(order);
           
           /* if (this.shopComboBox1 != null && this.shopComboBox1.Items.Count > 0)
            {
                if (CommonGlobalCache.CurrentUser.Type == UserInfoType.Guide  )
                {
                    if (this.action == OperationEnum.Send)
                    {
                        shopComboBox1.SelectedValue = CommonGlobalCache.GeneralStoreShopID;

                        this.skinComboBoxShopID.SelectedValue = order.DestShopID;
                    }
                    else
                    {
                        shopComboBox1.SelectedValue = CommonGlobalCache.CurrentShop.ID;
                    }
                }
            }*/
            if (CommonGlobalCache.CurrentUser.Type == UserInfoType.Guide )
            {
                // shopComboBox1.SelectedValue = CommonGlobalCache.CurrentShop;
                
                //    this.guideComboBox1.SelectedValue = CommonGlobalCache.CurrentUserID;
                
            }
        }

        private void SetShop()
        {
            shopComboBox1.Initialize(true);
          //  skinComboBoxShopID.Initialize(true);

            switch (this.curAllocateType)
            {
                case AllocateType.Return:
                    skinComboBoxShopID.SelectedValue = CommonGlobalCache.GeneralStoreShopID;
                    skinComboBoxShopID.Enabled = false;
                    break;
                case AllocateType.Distribution:
                    if (!IsPos)
                    {
                        shopComboBox1.SelectedValue = CommonGlobalCache.GeneralStoreShopID;
                        shopComboBox1.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void ResetAll(bool resetAction)
        {
            curDetailList = new List<BoundDetail>();
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            orderStoreCache = new List<CostumeStore>();
            if (resetAction)
            {
                action = OperationEnum.Add;
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //库存 也不用变色
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.RowIndex % 2 == 0 || dataGridView1.Rows.Count < 0) { return; }

            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            DataGridViewUtil.CellPainting_SetCellFont(dataGridView1, cell, 3, 14, Color.Green, FontStyle.Bold);
        }

        private void dataGridView2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //库存 也不用变色
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dataGridView2.Rows.Count < 0) { return; }

            DataGridViewCell cell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
            DataGridViewUtil.CellPainting_SetCellFont(dataGridView2, cell, 4, 15, Color.Green, FontStyle.Bold);
        }

        private void guideComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            operatorId = CommonGlobalCache.CurrentUserID;
        }
      
        private void LoadConfig()
        {
            try
            {
                config = AllocateOrderApplyConfiguration.Load(CONFIG_PATH) as AllocateOrderApplyConfiguration;
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.WriteLog(ex);
            }

            if (config != null)
            {
                this.skinCheckBoxPrint.Checked = config.Print;
            }
            else
            {
                config = new AllocateOrderApplyConfiguration() { };
            }
        }

        AllocateOrderApplyConfiguration config = null; 
        public static String CONFIG_PATH = CommonGlobalUtil.AgileConfiguration("Manage//" + "AllocateOrderApplyConfiguration");
        private void skinCheckBoxPrint_CheckedChanged(object sender, EventArgs e)
        {
            config.Print = skinCheckBoxPrint.Checked;
            config.Save(CONFIG_PATH);
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell cell = dataGridView.CurrentCell;
            List<BoundDetail> stores = DataGridViewUtil.BindingListToList<BoundDetail>(dataGridView2.DataSource);
            BoundDetail store = dataGridView.Rows[e.RowIndex].DataBoundItem as BoundDetail;
            //联动吊牌价和售价
            foreach (var item in stores)
            {
                if (store.CostumeID == item.CostumeID)
                {
                    if (e.ColumnIndex == SalePrice.Index)
                    {
                        item.SalePrice = store.SalePrice;
                    }
                    else if (e.ColumnIndex == priceDataGridViewTextBoxColumn.Index)
                    {
                        item.Price = store.Price;
                    }
                }
            }
            if (cell != null)
            { 
               if (cell.OwningColumn.DataPropertyName == priceDataGridViewTextBoxColumn.DataPropertyName)
                {
                    BoundDetail change = (BoundDetail)cell.OwningRow.DataBoundItem;
                    //735 管理端增加售价管理功能 03-19 myy 实时更新总销售额
                    change.SumMoney = change.Price * change.SumCount;
                }
            }
            dataGridView.Refresh();
        }

        //private void skinComboBoxShopID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CostumeCurrentShopTextBox1.ShopID = ValidateUtil.CheckEmptyValue(this.skinComboBoxShopID.SelectedValue);
        //}

        private void baseButton1_Click(object sender, EventArgs e)
        {
            if (GlobalMessageBox.Show("确定清空下表数据吗？", "友情提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridView2.DataSource = null;
                curDetailList?.Clear();
                dataGridView2.Refresh();
                if (action == OperationEnum.Pick)
                {
                    order = null;
                    action = OperationEnum.Add;
                }
            }
        }
         
        private void baseButtonPick_Click(object sender, EventArgs e)
        {
            try
            {
                AllocateOrderPickForm tiDanForm = new AllocateOrderPickForm();
                tiDanForm.HangedOrderSelected += TiDanForm_HangedOrderSelected;//提单被选择后触发
                tiDanForm.ShowDialog();
            }
            catch (Exception ee)
            {
               CommonGlobalUtil.WriteLog(ee);
            }
        }
         
        private void TiDanForm_HangedOrderSelected(AllocateOrder hangedOrder)
        {
            action = OperationEnum.Pick;
            LoadOrder(hangedOrder);
        }

        private void GetData()
        {
            List<ReplenishDetail> curReplenishDetailList = CommonGlobalCache.ServerProxy.GetReplenishDetail(this.order.ID);
            List<BoundDetail> detailList = new List<BoundDetail>();
            foreach (var item in curReplenishDetailList)
            {
                BoundDetail detail = new BoundDetail();

                ReflectionHelper.CopyProperty(item, detail);

                List<CostumeItem> costumesItemList = CommonGlobalCache.ServerProxy.GetCostumeStoreList(new CostumeStoreListPara()
                {
                    CostumeID = item.CostumeID,
                    IsOnlyShowValid = false,
                    ShopID = ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue),

                });
                CostumeItem curCostumeItem = costumesItemList.Find(t => t.Costume.ID == item.CostumeID);

                //  CostumePrice destShopStore = CommonGlobalCache.ServerProxy.GetCostumeStorePrice(ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue),item.CostumeID);
                //  GlobalMessageBox.Show(CommonGlobalCache.GetShopName(ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue)));
                CostumeStore destShopStore = curCostumeItem?.CostumeStoreList?.Find(t => t.CostumeID == item.CostumeID && t.ColorName == item.ColorName);
                if (destShopStore != null)
                {
                    //取收货方的吊牌价售价
                    detail.Price = destShopStore.Price;
                    detail.SalePrice = destShopStore.SalePrice;
                }





                detailList.Add(detail);
            }

            curDetailList = detailList;
        }

        private void LoadOrder(AllocateOrder order)
        {

            this.order = order;

            if (order != null)
            {
                if (action == OperationEnum.Redo || action == OperationEnum.Pick)
                {
                    shopComboBox1.SelectedValue = this.order.SourceShopID;
                    //冲单重做
                    curDetailList = CommonGlobalCache.ServerProxy.GetOutboundDetail(order.OutboundOrderID);

                    //  this.skinComboBoxShopID.SelectedValue = order.DestShopID;
                }
                else
                {

                    if (CommonGlobalCache.CurrentUser.Type == UserInfoType.Guide)
                    {
                        if (this.action == OperationEnum.Send)
                        {
                            if (this.shopComboBox1 != null && this.shopComboBox1.Items.Count > 0)
                            {
                                shopComboBox1.SelectedValue = CommonGlobalCache.GeneralStoreShopID;


                            }
                            /*  else
                              {
                                  shopComboBox1.SelectedValue = CommonGlobalCache.CurrentShop.ID;
                              }*/
                        }
                    }
                    //else {

                    //    this.skinComboBoxShopID.SelectedValue = order.DestShopID;
                    //}


                    GetData();
                }
                this.skinComboBoxShopID.SelectedValue = order.DestShopID;

                BindingInboundDetailSource();
                //如果操作人是admin，POS端显示导购员时默认选择无。
                if (!CommonGlobalUtil.IsAdminUser(order.SourceUserID))
                {
                    this.guideComboBox1.SelectedValue = order.SourceUserID;
                }
                this.operatorId = order.SourceUserID;
                this.skinTextBox_Remarks.Text = order.Remarks;

            }
            else
            {
                if (this.action == OperationEnum.Send)
                {
                    shopComboBox1.SelectedValue = CommonGlobalCache.GeneralStoreShopID;
                    this.skinComboBoxShopID.SelectedValue = order.DestShopID;
                }
                else
                {
                    shopComboBox1.SelectedValue = CommonGlobalCache.CurrentShopID;
                }
            }
        }

        private void baseButtonHang_Click(object sender, EventArgs e)
        {
         Save(true);
        }
         

        //点击出库按钮
        private void BaseButton_Inbound_Click(object sender, EventArgs e)
        {
            Save(false);
        }

       Shop shop;
        private void shopComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop = shopComboBox1.SelectedItem as Shop;
          /*  if (BaseUserControl.IsPos)
            {
                guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, shop.ID);
            }*/
            /*skinComboBoxShopID.Initialize(true);
            shopComboBox1.Initialize(true);*/
            skinComboBoxShopID.Initialize(true,false,false,false, ValidateUtil.CheckEmptyValue(shopComboBox1.SelectedValue));
           

            this.CostumeCurrentShopTextBox1.ShopID = ValidateUtil.CheckEmptyValue(shopComboBox1.SelectedValue);
            //guideComboBox1.Initialize(, ,);
        }

        private void skinComboBoxShopID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.action == OperationEnum.Send)
            {
                // LoadOrder(this.order);
                GetData(); 
            BindingInboundDetailSource();
        }
        }

        private void skinComboBox_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            // ShowMessage(this.CostumeItem.Costume.ID);

            /*  List<CostumeStore> selectResultList = new List<CostumeStore>();

              if (this.skinComboBox_Color.SelectedValue != null)
              {
                  selectResultList = this.curSelectedCostumeStoreList.FindAll(t => t.ColorName == ValidateUtil.CheckEmptyValue(this.skinComboBox_Color.SelectedValue));
              }

              dataGridViewPagingSumCtrl1.BindingDataSource(DataGridViewUtil.ListToBindingList(selectResultList)); 
              foreach (DataGridViewRow row in dataGridView1.Rows)
              {
                  if (row.Index % 2 == 0)
                  {
                      row.ReadOnly = true;
                      row.HeaderCell.Value = "库存";

                  }
                  else
                  {
                      row.ReadOnly = false;
                      row.HeaderCell.Value = "调拨";
                  }
              }*/
            curSelectedCostumeStoreList = CostumeItem.CostumeStoreList;
            BindingSelectedCostumeStoreSource(null);
        }
    }
}
