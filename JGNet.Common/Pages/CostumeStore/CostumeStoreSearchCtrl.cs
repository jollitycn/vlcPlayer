using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

using JGNet.Core.Tools;
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Common.Core;
using JGNet.Common;
using JGNet.Core;
using CCWin.SkinControl;
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using CJPlus;
using JieXi.Common;
using CJBasic;
using System.Threading;
using System.Reflection;

namespace JGNet.Common
{
    public partial class CostumeStoreSearchCtrl : BaseModifyUserControl
    {

        private string shopID;
        //当前dataGridView_RetailOrder一页显示多少条数据
        private CostumeStoreListPagePara pagePara;
        private List<CostumeStore> costumeStoreList = new List<CostumeStore>();
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public CostumeStoreSearchCtrl()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = false;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new string[] {
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
                        SumCostMoney.DataPropertyName,
                        SumMoney.DataPropertyName });
            //if (IsPos)
            //{
            //    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(BrandName, ClassName, CostPrice, SumCostMoney, SumMoney, Remarks);
            //}
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                         Remarks });
            dataGridViewPagingSumCtrl.Debug = true;
            dataGridViewPagingSumCtrl.Initialize();
            CommonGlobalUtil.SetCostumeColor(this.skinComboBox_Color);

            CostumeCurrentShopTextBox1.SkinTxt.TextChanged += SkinTxt_TextChanged;
            Initialize();
            MenuPermission = RolePermissionMenuEnum.库存查询;
            //if (!HasPermission(RolePermissionEnum.查看_品牌))
            //{
            //    skinComboBox_Brand.Visible = false;
            //    skinLabel11.Visible = false;
            //}
        }

        private void SkinTxt_TextChanged(object sender, EventArgs e)
        {

            if (this.CostumeCurrentShopTextBox1.SkinTxt.Text.Trim() == "")
            {
                this.skinCheckBoxOtherShop.Enabled = false;
                this.skinCheckBoxOtherShop.Checked = false;
            }
            else
            { 
                this.skinCheckBoxOtherShop.Enabled = true;
            }
        }

        private void Initialize()
        {   
            skinComboBoxShopID.Initialize();
            CommonGlobalUtil.SetBrand(skinComboBox_Brand);
            SetYear();
            CommonGlobalUtil.SetParameterConfig(skinComboBox_Season, ParameterConfigKey.Season);
            this.CostumeCurrentShopTextBox1.Text = string.Empty;

            SetStoreType();
            SetDisplay();
          
        }

        private void ImageCtrl_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.skinCheckBoxShowImage.Checked = false;
        }

        private void SetYear()
        {
            List<ListItem<int>> list = new List<ListItem<int>>();

            list.Add(new ListItem<int>(CommonGlobalUtil.COMBOBOX_ALL, -1));
            list.Add(new ListItem<int>(CommonGlobalUtil.COMBOBOX_HALF_YEAR, 0));
            List<int> years = YearHelper.GetYearList(DateTime.Now);
            foreach (int item in years)
            {
                list.Add(new ListItem<int>(item.ToString(), item));

            }
            skinComboBox_Year.DisplayMember = "key";
            skinComboBox_Year.ValueMember = "value";
            skinComboBox_Year.DataSource = list;
        }

        /// <summary>
        ///  根据平台内容显示
        /// </summary>
        private void SetDisplay()
        {
            SetColumnDisplay();
        }

        private void SetStoreType()
        {
            List<ListItem<CostumeStoreType>> list = new List<ListItem<CostumeStoreType>>();
            list.Add(new ListItem<CostumeStoreType>("实际库存", CostumeStoreType.Actual));
            list.Add(new ListItem<CostumeStoreType>("在途库存", CostumeStoreType.Transit));
            this.skinComboBox_storeType.DisplayMember = "Key";
            this.skinComboBox_storeType.ValueMember = "Value";
            this.skinComboBox_storeType.DataSource = list;
        }

        private void DoUpdate()
        {
            try
            {
                List<CostumeItem> costumeList = new List<CostumeItem>();
                pagePara.PageSize = 500;
                CostumeStoreListPage listPage = CommonGlobalCache.ServerProxy.GetCostumeStoreListPage(this.pagePara);
               // DataInitPage(listPage);
                DateTime starttime = DateTime.Now;
                if (listPage != null)
                {
                 InitProgress(listPage.TotalEntityCount,"加载中……");
                  
                    foreach (CostumeItem costume in listPage.CostumeItemList)
                    {
                        Thread.Sleep(1);
                        foreach (var item in costume.CostumeStoreList)
                        {
                            UpdateProgress();
                        }
                        
                        costumeList.Add(costume);
                       
                    }
                    int pageCount = (int)Math.Ceiling((double)listPage.TotalEntityCount / pagePara.PageSize);
                   
                    for (int i = 1; i < pageCount; i++)
                    {
                          if (progressStop)
                          {
                              FailedProgress(null);  
                              return;
                          }
                          pagePara.PageIndex = i;
                          listPage = CommonGlobalCache.ServerProxy.GetCostumeStoreListPage(this.pagePara);
                          
                          foreach (CostumeItem costume in listPage.CostumeItemList)
                          {
                            Thread.Sleep(1);
                            foreach (var item in costume.CostumeStoreList)
                            {
                                UpdateProgress();
                            }
                            costumeList.Add(costume);
                          }
                    }
                  listPage.CostumeItemList = costumeList;
                }

                DateTime endtime = DateTime.Now;
                TimeSpan span = (TimeSpan)(endtime - starttime);

                WriteLog("数据加载开始时间：" + starttime + " 结束时间：" + endtime + " 总耗时数：" + span.TotalSeconds + "秒");
                CompleteEdit(listPage);
               
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {

                this.BaseButton1.Enabled = true;
                UnLockPage();
            }
        }

        private void CompleteEdit()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.CompleteEdit));
            }
            else
            {
                CompleteProgressForm();
            }
        }

        private void CompleteEdit(CostumeStoreListPage listPage)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<CostumeStoreListPage>(this.CompleteEdit), listPage);
            }
            else
            { 
                DateTime startTime = DateTime.Now;
                SetColumnDisplay();
                
                this.BindingCostumeStoreDataSource(listPage);
                DateTime endTime = DateTime.Now;
                TimeSpan span = (TimeSpan)(endTime - startTime);
                WriteLog("界面加载开始时间：" + startTime + " 结束时间：" + endTime + " 总耗时数：" + span.TotalSeconds +"秒");
                CompleteEdit();
            }
        }

        private void Search()
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoUpdate);
                cb.BeginInvoke(null, null);
                ShowProgressForm();
            }
            catch (Exception ee)
            {
                ShowError(ee);
            }
            finally
            {
              //  CompleteProgressForm();
                UnLockPage();
            }
        }

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            this.skinCheckBoxShowImage.Checked = false;
            BaseButton1.Enabled = false;
            BuildPara();
            Search();
        }


        /// <summary>
        /// 绑定CostumeStore数据源
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingCostumeStoreDataSource(CostumeStoreListPage listPage)
        {
            this.costumeStoreList?.Clear();
            if (listPage != null && listPage.CostumeItemList != null)
            {
                foreach (CostumeItem item in listPage.CostumeItemList)
                {
                    if (item.CostumeStoreList != null)
                    {
                        foreach (CostumeStore store in item.CostumeStoreList)
                        {
                            this.costumeStoreList.Add(store);
                        }
                    }
                }
            }

            this.dataGridViewPagingSumCtrl?.BindingDataSource<CostumeStore>(DataGridViewUtil.ListToBindingList<CostumeStore>(costumeStoreList));
            this.dataGridView1?.Refresh();
        }
         

        private void skinComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pagePara = new CostumeStoreListPagePara();
        }
         

        private void skinComboBoxShopID_SelectedIndexChanged(object sender, EventArgs e)
        {
            shopID = ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue);
        }

        private void CostumeCurrentShopTextBox1_CostumeSelected(Costume costume, bool isEnter)
        {
            if (isEnter)
            {
                FilterColor(costume);
                if (costume != null)
                {
                    this.BaseButton_Search_Click(null, null);
                    if (this.CostumeCurrentShopTextBox1.SkinTxt.Text != null && this.CostumeCurrentShopTextBox1.SkinTxt.Text.Trim() != "")
                    {
                        // ShowMessage(this.CostumeCurrentShopTextBox1.SkinTxt.Text.Trim());
                        this.skinCheckBoxOtherShop.Enabled = true;
                    }
                    else {
                        this.skinCheckBoxOtherShop.Enabled = false;
                    }
                }
                else
                {
                    this.skinCheckBoxOtherShop.Enabled = false;
                    this.skinCheckBoxOtherShop.Checked = false;
                }
            }
        }

        private void FilterColor(Costume costume)
        {
            if (costume != null)
            {
                String[] colors = costume.Colors.Split(',');

                CommonGlobalUtil.SetCostumeColor(this.skinComboBox_Color, false, colors);
            }
            else
            {
                CommonGlobalUtil.SetCostumeColor(this.skinComboBox_Color);
            }
        }

        private void SetColumnDisplay()
        {
            this.CostPrice.Visible = skinCheckBox_ShowPrice.Checked;
            this.SumCostMoney.Visible = skinCheckBox_ShowPrice.Checked;
            this.colorNameDataGridViewTextBoxColumn.Visible = skinCheckBoxShowColor.Checked;

           //this.skinCheckBoxOtherShop.Enabled = false;

        }

        public void WorkDeskCtrlSearch()
        {
            this.skinCheckBox1.Checked = true;
            BuildPara();
            Search();

           

        }

        private void BuildPara()
        {
            string costumeID = string.IsNullOrEmpty(this.CostumeCurrentShopTextBox1.SkinTxt.Text.Trim()) ? null : this.CostumeCurrentShopTextBox1.SkinTxt.Text.Trim();
            bool isOnlyShowHaveNegative = this.skinCheckBox1.Checked;
            int year = (int)(this.skinComboBox_Year.SelectedValue);
            CostumeColor color = this.skinComboBox_Color.SelectedItem as CostumeColor;
            string BrandStr =ValidateUtil.CheckEmptyValue(this.skinComboBox_Brand.SelectedValue);
            int curBrandID = 0;
            if (BrandStr == null)
            {
                curBrandID = 0; 
            }
            curBrandID = Convert.ToInt32(BrandStr);
            this.pagePara = new CostumeStoreListPagePara()
            {
                CostumeID = costumeID,
                ShopID = shopID,
                IsShowAllShop = (shopID == null),
                ClassID= skinComboBoxBigClass.SelectedValue.ClassID,
               // SubSmallClass= skinComboBoxBigClass.SelectedValue?.SubSmallClass,
                BrandID = curBrandID,
                Season = ValidateUtil.CheckEmptyValue(this.skinComboBox_Season.SelectedValue),
                SupplierID = ValidateUtil.CheckEmptyValue(skinComboBoxSupplier.SelectedValue),
                Year = year,
                PageIndex = 0,
                CostumeStoreType = (CostumeStoreType)this.skinComboBox_storeType.SelectedValue,
                PageSize = int.MaxValue,// this.dataGridViewPagingSumCtrl.PageSize,
                IsOnlyShowHaveNegative = isOnlyShowHaveNegative,
                IsOnlyShowNotZero = skinCheckBox2.Checked,
                IsSingleModel = false,
               IsChooseColor = skinCheckBoxShowColor.Checked,    
               GetOtherShop= skinCheckBoxOtherShop.Checked,
                ColorName = color?.Name == CommonGlobalUtil.COMBOBOX_ALL ? null : color?.Name,
                 Date=new Date(dateTimePicker_Start.Value),
            };
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            String headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            if (headerText == "总成本" || headerText == "成本价" || headerText == "总价值" || headerText == "吊牌价")
            {
                return;
            }
            if (e.Value != null && e.Value.ToString() == "0")
            {
                e.Value = string.Empty;
            } 
        }

        private void skinCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBox2.Checked)
            {
                skinCheckBox1.Checked = false;
            }
        }

        private void skinCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBox1.Checked)
            {
                skinCheckBox2.Checked = false;
            }
        }

        private void baseButtonExport_Click(object sender, EventArgs e)
        {


            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "库存查询" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            if (String.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }

                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoExport);
                cb.BeginInvoke(null, null);
            }
            catch (Exception ex) { CommonGlobalUtil.ShowError(ex); }

        }

        private String path;
        private void DoExport()
        {
            try
            {
                List<CostumeStore> unableStore = new List<CostumeStore>();
                List<CostumeStore> stores = new List<CostumeStore>();
                List<CostumeStore> dt = DataGridViewUtil.BindingListToList<CostumeStore>(dataGridView1.DataSource);

                System.Collections.SortedList columns = new System.Collections.SortedList();
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                foreach (DataGridViewColumn item in dataGridView1.Columns)
                {
                    if (IsPos)
                    {
                        if (item.Index == CostPrice.Index || item.Index == SumCostMoney.Index)
                        {
                            continue;
                        }
                    }
                    if (item.Visible)
                    {
                        keys.Add(item.DataPropertyName);
                        values.Add(item.HeaderText);
                    }
                }

                NPOIHelper.Keys = keys.ToArray();
                NPOIHelper.Values = values.ToArray();
                NPOIHelper.ExportExcel(DataGridViewUtil.ToDataTable(dt), path);
                GlobalMessageBox.Show("导出完毕！");
            }
            catch (Exception ex)
            { ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }

        SingleImageForm imageCtrl;
        private void skinCheckBoxShowImage_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBoxShowImage.Checked)
            {
                dataGridView1_SelectionChanged(sender, e);
            }
            else
            {
                imageCtrl?.Close();
            }
        }

        CostumeStore curCostume;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.Rows.Count>0)
            {
                try
                {
                    if (CommonGlobalUtil.EngineUnconnectioned(this))
                    {
                        return;
                    }

                    List<CostumeStore> dt = DataGridViewUtil.BindingListToList<CostumeStore>(dataGridView1.DataSource);
                    if (dt.Count > 0 && this.dataGridView1.CurrentRow.DataBoundItem != null)
                    {
                        CostumeStore item = (CostumeStore)dataGridView1.CurrentRow.DataBoundItem;
                        if (curCostume != item && skinCheckBoxShowImage.Checked)
                        {
                            if (imageCtrl != null)
                            {
                                imageCtrl?.Close();
                                imageCtrl = null;
                            }
                            skinCheckBoxShowImage.CheckedChanged -= skinCheckBoxShowImage_CheckedChanged;
                            skinCheckBoxShowImage.Checked = true;
                            skinCheckBoxShowImage.CheckedChanged += skinCheckBoxShowImage_CheckedChanged;

                            imageCtrl = new SingleImageForm();
                            imageCtrl.FormClosing += ImageCtrl_FormClosing;
                            imageCtrl.Text = "款号：" + item.CostumeID;
                            imageCtrl.OnLoadingState();
                            Costume Curitem = CommonGlobalCache.GetCostume(item.CostumeID);
                           // byte[] bytes = CommonGlobalCache.ServerProxy.GetCostumePhoto(item.CostumeID);
                            if (Curitem.EmThumbnail != null)
                            {
                                System.Net.WebRequest webreq = System.Net.WebRequest.Create(Curitem.EmThumbnail);
                                System.Net.WebResponse webres = webreq.GetResponse();
                                using (System.IO.Stream stream = webres.GetResponseStream())
                                {
                                    imageCtrl.Image = Image.FromStream(stream);
                                }
                                // imageCtrl.Image = CCWin.SkinControl.ImageHelper.Convert(bytes);
                            }
                            else
                            {
                                imageCtrl.Image = null;
                            }
                            imageCtrl?.BringToFront();
                            imageCtrl?.Show();
                            curCostume = item;
                        }
                      //  dataGridView1.CurrentRow.Index = -1;
                    }

                }
                catch (Exception ex)
                {
                  // ShowError(ex);
                }
                finally
                {
                    UnLockPage();
                }
            }
        }
    }
}
