﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JGNet.Core.InteractEntity;
using JGNet.Core;
using CCWin;
using JGNet.Common.Core;
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Common.Core.Util;
using JGNet.Core.Const;
using CJBasic.Helpers;
using JGNet.Common;
using JieXi.Common;
using CJBasic;
using JGNet.Core.Dev.InteractEntity;

namespace JGNet.Common
{
    public partial class CheckStoreChildrenCtrl : BaseModifyUserControl
    {
        private String guideID;
        private String shopID;
        private Shop shop;
        private List<CheckStoreDetail> costumeStoreListSource = new List<CheckStoreDetail>();//当前被绑定的数据源
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl2; 
        private CheckStoreOrder curUpdatedCheckStoreOrder = null;//当前被修改的盘点单
        public CheckStoreChildrenCtrl(CheckStoreOrder checkStoreOrder)
        {
            //这个是每次NEW的
            InitializeComponent();
            Init();
            MenuPermission = RolePermissionMenuEnum.添加子盘点单;
            
            curUpdatedCheckStoreOrder = checkStoreOrder;
          /*  if (!HasPermission(RolePermissionMenuEnum.盘点单查询, RolePermissionEnum.重做_单据时间))
            {
                dateTimePicker_Start.Enabled = false;
            }*/
            IsShowOnePage = true;
        }

        public CheckStoreChildrenCtrl()
        {
            //这是菜单绑定的
            InitializeComponent();
            Init();
            MenuPermission = RolePermissionMenuEnum.添加子盘点单;
            IsShowOnePage = true;
          //  Init();
        }

        private void Init()
        {
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1,
                new string[] {
       fDataGridViewTextBoxColumn.DataPropertyName,
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
        sumCountDataGridViewTextBoxColumn.DataPropertyName,
       
       
     //   SumMoneyWinLost.DataPropertyName,
     //   sumCountWinLostDataGridViewTextBoxColumn.DataPropertyName
                }
                );
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl2 = new DataGridViewPagingSumCtrl(this.dataGridView2);
            dataGridViewPagingSumCtrl2.Initialize(); 
            dataGridViewPagingSumCtrl2.SendToBack();
            this.dateTimePicker_Start.ValueChanged += this.dateTimePicker_Start_ValueChanged;

            if (!HasPermission(RolePermissionMenuEnum.添加子盘点单, RolePermissionEnum.单据时间))
            {
                dateTimePicker_Start.Enabled = false;
            }
        }

        public Boolean IsEmptyList()
        {
            return dataGridView1.Rows.Count == 0;
        }

        private void Initialize()
        {
            this.costumeStoreListSource.Clear();
            this.dataGridView1.DataSource = null;
            SetDisplay();
        }

        private void Search()
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoSearch);
                cb.BeginInvoke(null, null);
                ShowProgressForm();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();

            }
        }
        private void DoSearch()
        {
            try
            {
                WebResponseObj<List<CostumeStoreHistory>> result =
                    CommonGlobalCache.ServerProxy.GetCostumeStoreHistory4CheckStore(
                    ValidateUtil.CheckEmptyValue(skinComboBoxShop.SelectedValue),
                    CostumeCurrentShopTextBox1.Text,
                    new Date(dateTimePicker_Start.Value),true);
                List<CheckStoreDetail> details = null;
                if (result != null)
                {
                    details = new List<CheckStoreDetail>();

                    List<CostumeStoreHistory> history = result.Data as List<CostumeStoreHistory>;

                    for (int i = 0; i < history.Count; i++)
                    {
                        CostumeStoreHistory item = history[i];
                        details.Add(ToCheckStoreDetail(item));
                        if (i % 10 == 0)
                        {
                            UpdateProgress(history.Count, i + 1);
                        }
                        else if (i + 1 == history.Count)
                        {
                            UpdateProgress(history.Count, i + 1);
                        }
                    }
                }
                costumeStoreListSource = details;

                DoBindingCostumeStoreSource();
            }
            catch (Exception ex)
            {
                FailedProgress(ex);
                ShowError(ex);
            }
            finally {
                CompleteProgressForm(); UnLockPage();
            }
        }

        protected void DoBindingCostumeStoreSource()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.DoBindingCostumeStoreSource));
            }
            else
            {
                BindingCostumeStoreSource();
            }
        }

        private void ToCheckStoreDetail(CheckStoreDetail source, CheckStoreDetail dest)
        {
            dest.F = source.F;
            dest.S = source.S;
            dest.M = source.M;
            dest.L = source.L;
            dest.XS = source.XS;
            dest.XL = source.XL;
            dest.XL2 = source.XL2;
            dest.XL3 = source.XL3;
            dest.XL4 = source.XL4;
            dest.XL5 = source.XL5;
            dest.XL6 = source.XL6;
            dest.Comment = source.Comment;
        }

        private CheckStoreDetail ToCheckStoreDetail(CostumeStoreHistory item)
        {
            CheckStoreDetail detail = new CheckStoreDetail();
            Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
            detail.CostumeID = item.CostumeID;
            detail.CostumeName = costume.Name;
            detail.ColorName = item.ColorName;
            detail.BrandID = item.BrandID.ToString();
            detail.BrandName = item.BrandName;
            detail.Price = costume.Price;
            detail.FAtm = item.F;
            detail.SAtm = item.S;
            detail.MAtm = item.M;
            detail.LAtm = item.L;
            detail.XSAtm = item.XS;
            detail.XLAtm = item.XL;
            detail.XL2Atm = item.XL2;
            detail.XL3Atm = item.XL3;
            detail.XL4Atm = item.XL4;
            detail.XL5Atm = item.XL5;
            detail.XL6Atm = item.XL6;
            return detail;
        }

        private void ToCheckStoreDetail(CheckStoreDetail detail, CostumeStoreHistory item)
        {
            Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
            detail.CostumeID = item.CostumeID;
            detail.CostumeName = costume.Name;
            detail.ColorName = item.ColorName;
            detail.Price = costume.Price;
            detail.BrandID = costume.BrandID.ToString();
            detail.BrandName = costume.BrandName;
            detail.FAtm = item.F;
            detail.SAtm = item.S;
            detail.MAtm = item.M;
            detail.LAtm = item.L;
            detail.XSAtm = item.XS;
            detail.XLAtm = item.XL;
            detail.XL2Atm = item.XL2;
            detail.XL3Atm = item.XL3;
            detail.XL4Atm = item.XL4;
            detail.XL5Atm = item.XL5;
            detail.XL6Atm = item.XL6;
        } 

        private CheckStoreDetail ToCheckStoreDetail(CostumeStore item)
        {
            CheckStoreDetail detail = new CheckStoreDetail();
            detail.CostumeID = item.CostumeID;
            detail.CostumeName = CommonGlobalCache.GetCostumeName(item.CostumeID);
            detail.ColorName = item.ColorName;
            detail.Price = item.Price;
            detail.FAtm = item.F;
            detail.SAtm = item.S;
            detail.MAtm = item.M;
            detail.LAtm = item.L;
            detail.XSAtm = item.XS;
            detail.XLAtm = item.XL;
            detail.XL2Atm = item.XL2;
            detail.XL3Atm = item.XL3;
            detail.XL4Atm = item.XL4;
            detail.XL5Atm = item.XL5;
            detail.XL6Atm = item.XL6;
            return detail;
        }

        private void SetDisplay()
        {
            //if (IsPos)
            //{
            //    skinComboBoxShop.Enabled = false;
            //}

            guideID =  CommonGlobalCache.CurrentUserID;
            //shopID = CommonGlobalCache.CurrentShopID;
           skinComboBoxShop.Initialize( true);
            if (curUpdatedCheckStoreOrder == null)
            {
                skinComboBoxShop.SelectedValue = CommonGlobalCache.CurrentShopID;
               
            }
            else
            {
                skinComboBoxShop.SelectedValue = curUpdatedCheckStoreOrder.ShopID;
                skinComboBoxShop.Enabled = false;
                dateTimePicker_Start.ValueChanged -= dateTimePicker_Start_ValueChanged;
                dateTimePicker_Start.Value = curUpdatedCheckStoreOrder.CreateTime;
                dateTimePicker_Start.ValueChanged += dateTimePicker_Start_ValueChanged;
                if (String.IsNullOrEmpty(curUpdatedCheckStoreOrder.ID))
                {
                    curUpdatedCheckStoreOrder = null;
                }
            }

            if (IsPos)
            {
                guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, shopID);
            }
            else
            {
                guideComboBox1.Visible = false;
                skinLabel_operator.Visible = false;
            }
            LoadEdit();
        }

        private void DoLoadEdit()
        {
            try
            {
                //库存信息
                List<CheckStoreDetail> list = new List<CheckStoreDetail>();
                List<CheckStoreDetail> checkStoreDetails = CommonGlobalCache.ServerProxy.GetCheckStoreDetail(this.curUpdatedCheckStoreOrder.ID);
                this.skinTextBox_Remarks.Text = this.curUpdatedCheckStoreOrder.Remarks;
                if (checkStoreDetails != null)
                {
                    foreach (CheckStoreDetail detail in checkStoreDetails)
                    {
                        WebResponseObj<List<CostumeStoreHistory>> result =
                          CommonGlobalCache.ServerProxy.GetCostumeStoreHistory4CheckStore(
                          shopID,
                          detail.CostumeID,
                          new Date(dateTimePicker_Start.Value), true);

                        if (result?.Data != null)
                        {
                            List<CostumeStoreHistory> history = result.Data as List<CostumeStoreHistory>;
                            foreach (var item in history)
                            {
                                if (item.ColorName == detail.ColorName)
                                {
                                    CheckStoreDetail displayDetail = ToCheckStoreDetail(item);
                                    ToCheckStoreDetail(detail, displayDetail);
                                    displayDetail.CostumeName = CommonGlobalCache.GetCostumeName(displayDetail.CostumeID);
                                    list.Add(displayDetail);
                                }
                            }
                        }
                    }
                }
                costumeStoreListSource = list;
                DoBindingCostumeStoreSource();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();

            }
        }

        /// <summary>
        /// 数据源中添加新的数据 （若有重复添加则提示）
        /// </summary>
        /// <param name="store"></param>
        private void CurSostumeStoreListSourceAddItem(CheckStoreDetail store)
        {
            foreach (CheckStoreDetail item in this.costumeStoreListSource)
            {
                if (item.CostumeID.ToUpper() == store.CostumeID.ToUpper() && item.ColorName == store.ColorName)
                {
                    item.CostumeName = store.CostumeName;
                    item.CostPrice = store.CostPrice;
                    item.Price = store.Price;
                   /* item.BrandName = store.BrandName;
                    item.BrandID = store.BrandID;*/
                    return;
                }
            }
            this.AddItem4Display(store);
        }

        #region 绑定数据源
        //绑定库存数据源
        private void BindingCostumeStoreSource()
        {
            dataGridViewPagingSumCtrl.DisableStyle();
            this.dataGridView1.CellValidating -= this.dataGridView1_CellValidating;
            List<CheckStoreDetail> isShowInDataGridView = costumeStoreListSource.FindAll(t => t.IsShow);
            //this.dataGridView1.DataSource = null;
            //this.dataGridViewPagingSumCtrl.Clear();
            this.dataGridViewPagingSumCtrl.BindingDataSource(DataGridViewUtil.ListToBindingList(isShowInDataGridView));
            //  bool hasChange = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.ReadOnly = false;
                //  row.HeaderCell.Value = String.Empty;// "实盘";
                row.DefaultCellStyle.ApplyStyle(new DataGridViewCellStyle()
                {
                    BackColor = Color.White
                });
            }

            dataGridViewPagingSumCtrl.EnableStyle();
            dataGridViewPagingSumCtrl.ScrollToEnd();

            //if (hasChange)
            //{
            //    GlobalMessageBox.Show("库存发生变化！");
            //}

            //如果列表有信息，则店铺不能选择切换，清空后可以操作

            if (isShowInDataGridView != null && isShowInDataGridView.Count > 0)
            {
                skinComboBoxShop.Enabled = false;
            }
            else
            {
                skinComboBoxShop.Enabled = true;
            }
            this.dataGridView1.CellValidating += this.dataGridView1_CellValidating;
        }

        private void SetAlertCellStyle(DataGridViewCell cell)
        {
            cell.Style.ForeColor = Color.Red;
            cell.Style.Font = new Font(
            dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
        }
        #endregion 

        /// <summary>
        /// 添加库存到绑定源中用于显示
        /// </summary>
        /// <param name="store"></param>
        /// <param name="isUpdate">是否是修改盘点单(新增时为false，修改时为true) </param>
        private void AddItem4Display(CheckStoreDetail store)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<CheckStoreDetail>(this.AddItem4Display), store);
            }
            else
            {
                CheckStoreDetail real = ReSetCostumeStoreCount(store, "实盘");
                this.costumeStoreListSource.Add(real);
            }
        }

        private CheckStoreDetail SetCostumeStore(CheckStoreDetail store, string title)
        {
            if (store == null)
            {
                return null;
            }
            CheckStoreDetail costumeStore = new CheckStoreDetail();
            CJBasic.Helpers.ReflectionHelper.CopyProperty(store, costumeStore);
            costumeStore.F = store.FAtm;
            costumeStore.XS = store.XSAtm;
            costumeStore.S = store.SAtm;
            costumeStore.M = store.MAtm;
            costumeStore.L = store.LAtm;
            costumeStore.XL = store.XLAtm;
            costumeStore.XL2= store.XL2Atm;
            costumeStore.XL3 = store.XL3Atm;
            costumeStore.XL4 = store.XL4Atm;
            costumeStore.XL5 = store.XL5Atm;
            costumeStore.XL6 = store.XL6Atm;
            return costumeStore;
        }

        /// <summary>
        /// 根据条件 将库存数是否重置为0，便于盘点修改
        /// </summary>
        /// <param name="store"></param>
        /// <param name="isUpdate">是否是修改盘点单(新增时为false，修改时为true) </param>
        private CheckStoreDetail ReSetCostumeStoreCount(CheckStoreDetail store, String title)
        {

            if (store == null)
            {
                return null;
            }
            CheckStoreDetail costumeStore = new CheckStoreDetail();
            CJBasic.Helpers.ReflectionHelper.CopyProperty(store, costumeStore);
            costumeStore.XS = 0;
            costumeStore.L = 0;
            costumeStore.M = 0;
            costumeStore.S = 0;
            costumeStore.XL = 0;
            costumeStore.XL2 = 0;
            costumeStore.XL3 = 0;
            costumeStore.XL4 = 0;
            costumeStore.XL5 = 0;
            costumeStore.XL6 = 0;
            costumeStore.F = 0;
            //  }
            return costumeStore;
        }

        private bool isHangFromTab = false;
        public void Hang()
        {
            try
            {

                isHangFromTab = true;
                if (IsPos)
                {
                    /* GuideSelectForm form = new GuideSelectForm(GuideComboBoxInitializeType.Normal, shopID);
                     form.ConfirmClick += form_ConfirmClick;
                     if (form.ShowDialog() == DialogResult.OK)
                     {
                         //BaseButton3.PerformClick();
                     }*/
                  //  BaseButton3.PerformClick();
                }
                else
                {
                   // BaseButton3.PerformClick();
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

        private void form_ConfirmClick(String guideID)
        {
          //  this.guideComboBox1.SelectedValue = guideID;
            form.DialogResult = DialogResult.OK;
        }

        //提交挂单\盘点
        private void BaseButton_Save_Click(object sender, EventArgs e)
        {
            try
            {
               /* if (this.guideComboBox1.SelectedIndex == 0)
                {
                    GlobalMessageBox.Show("操作人不能为空");
                    return;
                }*/
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                CheckStore checkStore = this.BuildCheckStore();
                Button button = (Button)sender;
                bool isHanged = false;
              /*  if (button.Text == JGNet.Core.Tools.EnumHelper.GetDescription(RolePermissionEnum.挂单))
                {
                    checkStore.CheckStoreOrder.State = (int)CheckStoreOrderState.Suspend;
                    //在盘点单查询显示时过滤
                    isHanged = true;
                }
                else
                {
                    if (this.costumeStoreListSource.Count == 0 && GlobalMessageBox.Show("盘点列表为空，视为零差异盘点，确定提交审核？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                    else if (GlobalMessageBox.Show("确定提交审核？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                }*/

                if (this.curUpdatedCheckStoreOrder != null && (CheckStoreOrderState)curUpdatedCheckStoreOrder.State == CheckStoreOrderState.ChildOrder)
                {
                    InteractResult updateResult = CommonGlobalCache.ServerProxy.UpdateCheckStore(checkStore);
                    if (updateResult.ExeResult == ExeResult.Error)
                    {
                        GlobalMessageBox.Show(updateResult.Msg);
                        return;
                    }
                }
                else
                {
                    InteractResult result = CommonGlobalCache.ServerProxy.InsertCheckStore(checkStore);
                    if (result.ExeResult == ExeResult.Error)
                    {
                        GlobalMessageBox.Show(result.Msg);
                        return;
                    }
                }

                if (isHanged)
                {
                    GlobalMessageBox.Show(this.FindForm(), "挂单成功！");
                }
                else
                {
                    GlobalMessageBox.Show(this.FindForm(), "保存成功！");
                    if (skinCheckBoxPrint.Checked)
                    {
                        dataGridViewPagingSumCtrl2.BindingDataSource(DataGridViewUtil.ListToBindingList(checkStore.CheckStoreDetailList)); 
                        DataGridView dgv=deepCopyDataGridView(checkStore.CheckStoreDetailList);
                        CheckStoreOrderPrinter.Print(checkStore.CheckStoreOrder, dgv, 2);
                    }
                }

                this.costumeStoreListSource.Clear();
                this.BindingCostumeStoreSource();
                if (!isHangFromTab)
                {
                    this.TabPageClose(this.CurrentTabPage,this.SourceCtrlType);
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
        private DataGridView deepCopyDataGridView(List<CheckStoreDetail> list)
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




            List<CheckStoreDetail> tb2 = new List<CheckStoreDetail>();
            foreach (CheckStoreDetail idetail in list)
            {
                CheckStoreDetail tDetail = new CheckStoreDetail();
                ReflectionHelper.CopyProperty(idetail, tDetail);
                tb2.Add(tDetail);

            }

            dgvTmp.DataSource = tb2;



            return dgvTmp;
        }
        private void LoadStores()
        {
            resultList = CommonGlobalCache.ServerProxy.GetCostumeStoreList(new CostumeStoreListPara() { CostumeID = null, ShopID = shopID });
        }

        #region 对象生成与转换
        /// <summary>
        /// 生成盘点需要的参数CheckStore
        /// </summary>
        /// <returns></returns>
        private CheckStore BuildCheckStore()
        {
            string id = IDHelper.GetID(OrderPrefix.CheckStoreOrder, shop.AutoCode);
            if (this.curUpdatedCheckStoreOrder != null && (CheckStoreOrderState)curUpdatedCheckStoreOrder.State == CheckStoreOrderState.ChildOrder)
            {
                id = this.curUpdatedCheckStoreOrder.ID;
            }

            int totalCount = 0;
            decimal totalPrice = 0;
            int checkStoreLostCount = 0;
            int checkStoreWinCount = 0;
            List<CheckStoreDetail> checkStoreDetailList = new List<CheckStoreDetail>();
            List<CheckStoreDetail> showInDataGridView = costumeStoreListSource.FindAll(t => t.IsShow);
            for (int i = 0; i < showInDataGridView.Count; i++)
            {
                CheckStoreDetail store = showInDataGridView[i];
                //if (store.Title == "账面")
                //{
                //    continue;
                //}
                totalCount += store.SumCount;
                checkStoreWinCount += Math.Abs(store.SumCountWin);
                checkStoreLostCount += Math.Abs( store.SumCountLost);
                totalPrice += store.SumMoney;
                //  CheckStoreDetail detail = CostumeStoreConvertToCheckStoreDetail(store, id);
                store.CheckStoreOrderID = id;
                checkStoreDetailList.Add(store);
            }

            CheckStoreOrder checkStoreOrder = new CheckStoreOrder()
            {
                ID = id,
                OperatorUserID = CommonGlobalCache.CurrentUserID,
                ShopID = shopID,
                Remarks = this.skinTextBox_Remarks.Text.Trim(),
                CreateTime = DateTime.Now,
                CheckUserID = string.Empty,
                CheckStoreLostCount = checkStoreLostCount,
                CheckStoreWinCount = checkStoreWinCount,
                LastUpdateTime = DateTime.Now,
                CheckTime = SystemDefault.DateTimeNull,
                State = (int)CheckStoreOrderState.ChildOrder
            };
            return new CheckStore()
            {
                CheckStoreOrder = checkStoreOrder,
                CheckStoreDetailList = checkStoreDetailList,
                Date = new Date(dateTimePicker_Start.Value)
            };
        }

        /// <summary>
        /// 将CostumeStore对象转换为CheckStoreDetail
        /// </summary>
        /// <param name="store">CostumeStore对象</param>
        /// <param name="checkStoreOrderID">盘点单号</param>
        /// <returns></returns>
        private CostumeStore CheckStoreDetailConvertToCostumeStore(CheckStoreDetail detail)
        {
            return new CostumeStore()
            {
                CostumeID = detail.CostumeID,
                ColorName = detail.ColorName,
                CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID),
                Price = detail.Price,
                S = detail.S,
                M = detail.M,
                L = detail.L,
                XS = detail.XS,
                XL = detail.XL,
                XL2 = detail.XL2,
                XL3 = detail.XL3,
                XL4 = detail.XL4,
                XL5 = detail.XL5,
                XL6 = detail.XL6,
                F = detail.F
            };
        }
        #endregion

        #region 验证单元格
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
                    GlobalMessageBox.Show("盘点数不能小于0！");
                    this.dataGridView1.CancelEdit();
                    return;
                }
                //  }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex, "输入格式错误");
                this.dataGridView1.CancelEdit();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewUtil.CellPainting_SetCellFont(dataGridView1, cell, 3, 14, Color.Green, FontStyle.Bold);
            dataGridView1.Refresh();
        }

        List<CostumeItem> resultList = null;// CommonGlobalCache.ServerProxy.GetCostumeStoreList(new CostumeStoreListPara() { CostumeID = null, ShopID = CommonGlobalCache.CurrentShopID });

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                if (e.ColumnIndex == OperationColumn.Index)
                {
                    this.costumeStoreListSource.RemoveAt(e.RowIndex);
                    this.BindingCostumeStoreSource();
                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        #endregion


        private void BaseButton3_Click(object sender, EventArgs e)
        {
            costumeStoreListSource.Clear();
            BindingCostumeStoreSource();
            //  skinLabelWinLostCount.Text = "0";
        }

        private void CheckStoreCtrl_Load(object sender, EventArgs e)
        {
           // Init();
            this.Initialize();
          /*  if (CommonGlobalCache.CurrentUser.Type == UserInfoType.Guide)
            {
               // this.guideComboBox1.SelectedValue = CommonGlobalCache.CurrentUserID;
            }*/
        }


        private void guideComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // guideID = ValidateUtil.CheckEmptyValue(guideComboBox1.SelectedValue);
        }

        private void baseButtonCompare_Click(object sender, EventArgs e)
        {

            form = new CheckStoreCompareForm(shopID, this.dateTimePicker_Start.Value, costumeStoreListSource);
            form.SameWithStoreClick += Form_SameWithStoreClick;
            form.ZeroClick += Form_ZeroClick;
            form.Show();
        }

        CheckStoreCompareForm form = null;

        private void Form_ZeroClick(List<CheckStoreDetail> list, EventArgs args)
        {
           
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                sameWithStoreList = list;
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoZeroClick);
                cb.BeginInvoke(null, null);
                ShowProgressForm();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }

            finally
            {
                CompleteProgressForm();
                UnLockPage();

            }
            //if (list != null && list.Count > 0)
            //{
            //    foreach (CheckStoreDetail item in list)
            //    {
            //        AddItem4Display(item);
            //    }

            //    this.BindingCostumeStoreSource();
            //    //绑定完成，数据也自动同步到FORM，那么FORM需要自己重新加载
            //    // form.Reload();
            //}
        }

        private void DoZeroClick()
        {
            try
            {
                List<CheckStoreDetail> newList = new List<CheckStoreDetail>();
                if (sameWithStoreList != null && sameWithStoreList.Count > 0)
                {
                    InitProgress(sameWithStoreList.Count);
                    for (int i = 0; i < sameWithStoreList.Count; i++)
                    {
                        CheckStoreDetail item = sameWithStoreList[i];
                        newList.Add(ReSetCostumeStoreCount(item, "实盘"));

                        if (i % 10 == 0)
                        {
                            UpdateProgress("正在加载");
                        }
                        else if (i + 1 == sameWithStoreList.Count)
                        {
                            UpdateProgress("正在加载");
                        }
                    }
                    costumeStoreListSource.AddRange(newList);
                    DoBindingCostumeStoreSource();
                }
            }
            catch (Exception ex)
            {
                FailedProgress(ex);
                ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();

            }
        }


        private void AddItemSameWithStore(CheckStoreDetail store)
        {
            //store.Title = "账面";
            CheckStoreDetail real = this.SetCostumeStore(store, "实盘");
            costumeStoreListSource.Add(real);
        }



        List<CheckStoreDetail> sameWithStoreList = null;
        private void Form_SameWithStoreClick(List<CheckStoreDetail> list, EventArgs args)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                sameWithStoreList = list;
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoCheckStoreCompareForm);
                cb.BeginInvoke(null, null);
                ShowProgressForm();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }

            finally
            {
                CompleteProgressForm();
                UnLockPage();

            }
        }


        private void DoCheckStoreCompareForm()
        {
            try
            {


                List<CheckStoreDetail> newList = new List<CheckStoreDetail>();
                if (sameWithStoreList != null && sameWithStoreList.Count > 0)
                {
                    InitProgress(sameWithStoreList.Count);
                    for (int i = 0; i < sameWithStoreList.Count; i++)
                    {
                        CheckStoreDetail item = sameWithStoreList[i];
                        newList.Add(this.SetCostumeStore(item, "实盘"));

                        if (i % 10 == 0)
                        {
                            UpdateProgress("正在加载");
                        }
                        else if (i + 1 == sameWithStoreList.Count)
                        {
                            UpdateProgress("正在加载");
                        }
                    }
                    costumeStoreListSource.AddRange(newList);
                    DoBindingCostumeStoreSource();
                }
            }
            catch (Exception ex)
            { 
                FailedProgress(ex);
                ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();

            }
        }

        String path;

        private void baseButtonImport_Click(object sender, EventArgs e)
        {
            path = CJBasic.Helpers.FileHelper.GetFileToOpen("请选择导入文件");
            if (String.IsNullOrEmpty(path))
            {
            }
            else
            {

                List<CheckStoreDetail> isShowInDataGridView = this.costumeStoreListSource?.FindAll(t => t.IsShow);
                if (isShowInDataGridView != null && isShowInDataGridView.Count > 0)
                { 
                    if (String.IsNullOrEmpty(path))
                    {
                        GlobalMessageBox.Show("请选择文件！");
                        return;
                    }
                }

                try
                {
                    if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                    //BaseButton3_Click(null, null);
                    CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoImport);
                    cb.BeginInvoke(null, null);
                }
                catch (Exception ex)
                {
                    CommonGlobalUtil.ShowError(ex);
                }
            }
        }


        private void DoImport()
        {
            try
            {
                List<CheckStoreDetail> items = new List<CheckStoreDetail>();
                List<CheckStoreDetail> incorrectItems = new List<CheckStoreDetail>();
                List<CheckStoreDetail> repeatItems = new List<CheckStoreDetail>();
                List<CheckStoreDetail> emptyStore = new List<CheckStoreDetail>();
                List<CheckStoreDetail> incorrectColorItems = new List<CheckStoreDetail>();
                DataTable dt = NPOIHelper.FormatToDatatable(path, 0);
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    CheckStoreDetail item = new CheckStoreDetail();
                    try
                    {
                        if (!ImportValidate(row))
                        {
                            item.Index = i + 2;
                            item.CostumeID = CommonGlobalUtil.ConvertToString(row[0]);
                            item.CostumeName = CommonGlobalUtil.ConvertToString(row[1]);
                            // item.CostumeColorName = CommonGlobalUtil.ConvertToString(row[2]);
                            item.ColorName = CommonGlobalUtil.ConvertToString(row[2]);
                            try
                            {
                                item.Price = Convert.ToDecimal(row[3]);
                            }
                            catch (Exception ex)
                            {
                                //获取不到吊牌价，直接从缓存中获取
                                Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
                                if (costume != null)
                                {
                                    item.Price = costume.Price;
                                }
                            }

                            item.F = CommonGlobalUtil.ConvertToInt16(row[4]);
                            item.XS = CommonGlobalUtil.ConvertToInt16(row[5]);
                            item.S = CommonGlobalUtil.ConvertToInt16(row[6]);
                            item.M = CommonGlobalUtil.ConvertToInt16(row[7]);
                            item.L = CommonGlobalUtil.ConvertToInt16(row[8]);
                            item.XL = CommonGlobalUtil.ConvertToInt16(row[9]);
                            item.XL2 = CommonGlobalUtil.ConvertToInt16(row[10]);
                            item.XL3 = CommonGlobalUtil.ConvertToInt16(row[11]);
                            item.XL4 = CommonGlobalUtil.ConvertToInt16(row[12]);
                            item.XL5 = CommonGlobalUtil.ConvertToInt16(row[13]);
                            item.XL6 = CommonGlobalUtil.ConvertToInt16(row[14]);

                            if (String.IsNullOrEmpty(item.CostumeID) || String.IsNullOrEmpty(item.ColorName))
                            {
                                //必填项为空
                                emptyStore.Add(item);
                                continue;
                            }

                            //判断是否重复款号/颜色
                            //CheckStoreDetail existedDetail = items.Find(t => t.CostumeID.ToUpper() == item.CostumeID.ToUpper() && t.ColorName == item.ColorName);
                            //if (existedDetail != null)
                            //{
                            //    item.add

                            //   // AppendStore(existedDetail, item); 
                            //    // repeatItems.Add(item);
                            //    continue;
                            //}

                            if (!(String.IsNullOrEmpty(item.CostumeID)))
                            {
                                Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
                                if (costume != null)
                                {
                                    if (!(String.IsNullOrEmpty(item.ColorName) || costume.ColorList.Contains(item.ColorName)))
                                    {
                                        incorrectColorItems.Add(item);
                                    }
                                    else
                                    {
                                      //  item.CostumeID = costume.ID;
                                        items.Add(item);
                                    }
                                }
                                else
                                {
                                    incorrectItems.Add(item);
                                }
                            }
                            else
                            {
                                incorrectItems.Add(item);
                            }
                        }
                    }
                    catch { }
                }
                if (emptyStore.Count > 0)
                {
                    String str = string.Empty;
                    foreach (var item in emptyStore)
                    {
                        str += "第" + item.Index + "行" + "\r\n";
                    }
                    ShowError("必填项没有填写，请补充完整！\r\n" + str);
                    return;
                }
                if (incorrectItems.Count > 0)
                {
                    String str = string.Empty;
                    foreach (var item in incorrectItems)
                    {
                        str += "第" + item.Index + "行" + "\r\n";
                    }
                    //  str = str.Substring(0, str.LastIndexOf(","));
                    ShowError("以下行中，款号不存在，不能导入。\r\n" + str);
                    return;
                }

                if (incorrectColorItems.Count > 0)
                {
                    String str = string.Empty;
                    foreach (var item in incorrectColorItems)
                    {
                        str += "第" + item.Index + "行" + "\r\n";
                    }
                    //  str = str.Substring(0, str.LastIndexOf(","));
                    ShowError("以下行中，颜色不存在，请补充完整。\r\n" + str);
                    return;
                }
                //if (repeatItems.Count > 0)
                //{
                //    String str = string.Empty;
                //    foreach (var item in repeatItems)
                //    {
                //        str += "第" + item.Index + "行" + "\r\n";
                //    }
                //    ShowError("重复的款号与颜色，系统已过滤，详见错误报告！\r\n" + str);
                //    //  return;
                //}
                if (items != null && items.Count > 0)
                {
                    foreach (var detail in items)
                    {
                        WebResponseObj<List<CostumeStoreHistory>> result =
                             CommonGlobalCache.ServerProxy.GetCostumeStoreHistory4CheckStore(
                             ValidateUtil.CheckEmptyValue(skinComboBoxShop.SelectedValue),
                             detail.CostumeID,
                             new Date(dateTimePicker_Start.Value), true);

                        if (result?.Data != null)
                        {
                            List<CostumeStoreHistory> history = result.Data as List<CostumeStoreHistory>;
                            foreach (var item in history)
                            {
                                if (item.ColorName == detail.ColorName)
                                {
                                    ToCheckStoreDetail(detail, item);
                                }
                            }
                        }
                    }
                }
                else
                {
                    ShowMessage("没有数据可以导入，请检查盘点信息！");
                    return;
                }
                AddItems4Display(items);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                UnLockPage();
            }
        }

        private void AppendStore(CheckStoreDetail existedDetail, CheckStoreDetail item)
        {
            existedDetail.S += item.S;
            existedDetail.M += item.M;
            existedDetail.L += item.L;
            existedDetail.XS += item.XS;
            existedDetail.XL += item.XL;
            existedDetail.XL2 += item.XL2;
            existedDetail.XL3 += item.XL3;
            existedDetail.XL4 += item.XL4;
            existedDetail.XL5 += item.XL5;
            existedDetail.XL6 += item.XL6;
            existedDetail.F += item.F;
        }

        private bool ImportValidate(DataRow row)
        {  //
            bool unValidate = true;
            for (int i = 0; i < 15; i++)
            {
                String value = CommonGlobalUtil.ConvertToString(row[i]);
                if (!String.IsNullOrEmpty(value))
                {
                    //有值
                    unValidate = false;
                    break;
                }
            }
            return unValidate;
        }

        private void AddItems4Display(List<CheckStoreDetail> items)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<List<CheckStoreDetail>>(this.AddItems4Display), items);
            }
            else
            {
                foreach (var item in items)
                {
                    CheckStoreDetail detail = costumeStoreListSource.Find(t => t.CostumeID.ToUpper() == item.CostumeID.ToUpper() && t.ColorName == item.ColorName);
                    if (detail == null)
                    {
                        this.costumeStoreListSource.Add(item);
                    }
                    else
                    {
                        AppendStore(detail, item);
                        // ReflectionHelper.CopyProperty(item, detail);
                    }
                }
                this.BindingCostumeStoreSource();
            }
        }


        private void baseButtonDownTemp_Click(object sender, EventArgs e)
        {
            //找到EXCEL模板文件
            String sourceFile = System.Environment.CurrentDirectory + "\\Templates\\importCheckStore.xls";
            String path = "";
            path = FileUtil.BrowseFolder("请选择保存模板的位置");
            if (String.IsNullOrEmpty(path))
            {
                return;
            }

            String toPath = path + "\\盘点单模板.xls";
            System.IO.File.Copy(sourceFile, toPath, true);
            GlobalMessageBox.Show("模板保存" + toPath + "！");
        }

        private void skinComboBoxShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shop selectedShop = skinComboBoxShop.SelectedItem as Shop;
            //当前店铺需要切换的话，判断列表内容是否为空，不为空，提示手工清空后才操作
            if (selectedShop != shop && (costumeStoreListSource != null && costumeStoreListSource.Count > 0))
            {
                if (GlobalMessageBox.Show("请清空列表后重新选择店铺！") == DialogResult.OK)
                {
                    return;
                }
            }
            shop = selectedShop;
            //CostumeCurrentShopTextBox1.ShopID = shop.ID;
            shopID = shop.ID;
        }

        private void CostumeCurrentShopTextBox1_CostumeSelected(Costume costumeItem, bool isEnter)
        {
            if (costumeItem == null)
            {
                return;
            }
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                if (isEnter)
                {
                    WebResponseObj<List<CostumeStoreHistory>> result = null;
                    if (costumeItem != null)
                    {
                        result =
                      CommonGlobalCache.ServerProxy.GetCostumeStoreHistory4CheckStore(
                      ValidateUtil.CheckEmptyValue(skinComboBoxShop.SelectedValue),
                      costumeItem.ID,
                      new Date(dateTimePicker_Start.Value), true);
                    }
                    CheckStoreDetail firstCostume = null;
                    
                    if (result?.Data != null)
                    {
                        List<CostumeStoreHistory> history = result.Data as List<CostumeStoreHistory>;
                        
                        foreach (var item in history)
                        {
                            CheckStoreDetail detail = ToCheckStoreDetail(item);
                            CurSostumeStoreListSourceAddItem(detail);
                            if (firstCostume == null)
                            {
                                firstCostume = detail;
                            }
                        }
                    }
                    BindingCostumeStoreSource();

                    //激活当前选择的款对应的输入单元格。
                    AutoFocusToWritableCell(dataGridView1, firstCostume);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                UnLockPage();
            }
        }

        /// <summary>
        /// 自动定焦点到指定的可写单元格内
        /// </summary>
        private void AutoFocusToWritableCell(DataGridView dataGridView, CheckStoreDetail firstCostume)
        {

            DataGridViewCell writableCell = null;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                CheckStoreDetail detail = row.DataBoundItem as CheckStoreDetail;
                if (detail.ColorName == firstCostume.ColorName && detail.CostumeID == firstCostume.CostumeID)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (!cell.ReadOnly && cell.Visible)
                        {

                            writableCell = cell;
                            break;
                        }

                    }
                    if (writableCell != null)
                    {
                        break;
                    }
                }
            }

            if (writableCell != null)
            {
                // dataGridView.BeginEdit(true); //设置可编辑状态
                dataGridView.Focus();
                dataGridView.CurrentCell = writableCell; //设置当前单元格
                dataGridView.BeginEdit(true);
            }
        }


        private void CostumeMultiselectForm_CostumeMultiSelected(List<CostumeItem> costumeItems)
        {
            if (costumeItems == null)
            {
                return;
            }

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                foreach (CostumeItem costumeItem in costumeItems)
                {
                    WebResponseObj<List<CostumeStoreHistory>> result = null;
                    if (costumeItem != null && costumeItem.Costume != null)
                    {
                        result = CommonGlobalCache.ServerProxy.GetCostumeStoreHistory4CheckStore(
                        ValidateUtil.CheckEmptyValue(skinComboBoxShop.SelectedValue),
                        costumeItem.Costume.ID,
                        new Date(dateTimePicker_Start.Value), true);
                    }

                    if (result?.Data != null)
                    {
                        List<CostumeStoreHistory> history = result.Data as List<CostumeStoreHistory>;
                        foreach (var item in history)
                        {
                            CurSostumeStoreListSourceAddItem(ToCheckStoreDetail(item));
                        }
                    }
                }

                this.BindingCostumeStoreSource();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                UnLockPage();
            }
        }

        //点击弹出选择多款服装的对话框
        private void button_MultiselectCostume_Click(object sender, EventArgs e)
        {
            CostumeMultiselectForm costumeMultiselectForm = new CostumeMultiselectForm();
             costumeMultiselectForm.ShopID = shopID;
            costumeMultiselectForm.CostumeMultiSelected += CostumeMultiselectForm_CostumeMultiSelected;
            costumeMultiselectForm.ShowDialog();
        }

        private void dateTimePicker_Start_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoSwitchDate);
                cb.BeginInvoke(null, null);
                ShowProgressForm();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();

            }
        }



        private void DoSwitchDate()
        {
            //切换到对应日期
            List<CheckStoreDetail> details = dataGridView1.DataSource as List<CheckStoreDetail>;
            try
            { 
                if (details == null)
                {
                    DoBindingCostumeStoreSource();
                    return;
                }
                InitProgress(details.Count);
                for (int i = 0; i < details.Count; i++)
                {
                    UpdateProgress();
                    CheckStoreDetail costumeItem = details[i];
                    //    foreach (CheckStoreDetail costumeItem in details)
                    //{
                    WebResponseObj<List<CostumeStoreHistory>> result = null;
                    if (costumeItem != null)
                    {
                        result = CommonGlobalCache.ServerProxy.GetCostumeStoreHistory4CheckStore(
                       shopID,
                         costumeItem.CostumeID,
                        new Date(dateTimePicker_Start.Value), true);
                    }

                    if (result?.Data != null)
                    {
                        List<CostumeStoreHistory> history = result.Data as List<CostumeStoreHistory>;
                        //历史库存
                        foreach (var item in history)
                        {
                            //匹配现有列表的数据并添加到列表中绑定

                            if (costumeItem.CostumeID.ToUpper() == item.CostumeID.ToUpper() && costumeItem.ColorName == item.ColorName)
                            {
                                ToCheckStoreDetail(costumeItem, item);
                                break;
                            }
                            //CurSostumeStoreListSourceAddItem();
                        }
                    }
                    //else {
                    //    //没有对应历史库存

                    //}
                }

                DoBindingCostumeStoreSource();
            }
            catch (Exception ex)
            {
                FailedProgress(ex);
                ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();

            }
        }

        public void LoadEdit()
        {
            if (curUpdatedCheckStoreOrder != null)
            {
                try
                {
                    if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                    CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoLoadEdit);
                    cb.BeginInvoke(null, null);
                    ShowProgressForm();
                }
                catch (Exception ex)
                {
                    CommonGlobalUtil.ShowError(ex);
                }
                finally
                {
                    CompleteProgressForm();
                    UnLockPage();

                }
            }
        }
         
    }
}
