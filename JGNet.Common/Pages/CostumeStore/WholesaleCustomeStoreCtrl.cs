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
using JGNet.Manage;
using JGNet.Common.cache.Wholesale;

namespace JGNet.Common
{
    public partial class WholesaleCustomeStoreCtrl : BaseModifyUserControl
    {

        private string shopID;
        //当前dataGridView_RetailOrder一页显示多少条数据
        private GetPfCustomerStorePagePara pagePara;
        private List<PfCustomerStore> costumeStoreList = new List<PfCustomerStore>();
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public WholesaleCustomeStoreCtrl()
        {
            InitializeComponent();

            MenuPermission = RolePermissionMenuEnum.库存查询;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1,
                new string[] {
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
        CostPriceSum.DataPropertyName,
        SumCount.DataPropertyName,
        SumPfMoney.DataPropertyName
          });
            dataGridViewPagingSumCtrl.Initialize();
            // dataGridViewPagingSumCtrl.SpecAutoSizeMode(new TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode>(Remarks, DataGridViewAutoSizeColumnMode.ColumnHeader));
             
        }  
        private void Initialize()
        {
            CommonGlobalUtil.SetBrand(skinComboBox_Brand);
            skinComboBoxSupplier.Initialize(false, true,1);
            this.CostumeCurrentShopTextBox1.Text = string.Empty;

            CommonGlobalUtil.SetCostumeColor(this.skinComboBox_Color);
            SetDisplay();
            SetYear();
            CommonGlobalUtil.SetParameterConfig(skinComboBox_Season, ParameterConfigKey.Season);
            BindingCostumeStoreDataSource(null);
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
        private void ImageCtrl_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.skinCheckBoxShowImage.Checked = false;
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
        /// <summary>
        ///  根据平台内容显示
        /// </summary>
        private void SetDisplay()
        {

            SetColumnDisplay();
        }


        private void Search()
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {

                    return;
                }

                                            //CommonGlobalCache.ServerProxy.GetOnePfCustomerStore
                PfCustomerStorePage listPage = CommonGlobalCache.ServerProxy.GetPfCustomerStorePage(this.pagePara);
                SetColumnDisplay();
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                this.dataGridViewPagingSumCtrl.Initialize(listPage);
                this.BindingCostumeStoreDataSource(listPage);

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

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            this.skinCheckBoxShowImage.Checked = false;
            BuildPara();
            Search();
        }


        /// <summary>
        /// 绑定CostumeStore数据源
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingCostumeStoreDataSource(PfCustomerStorePage listPage)
        {
            this.dataGridView1.DataSource = null;
            this.costumeStoreList.Clear();
            if (listPage != null && listPage.PfCustomerStores != null)
            {
                foreach (PfCustomerStore store in listPage.PfCustomerStores)
                {
                    Costume costume = CommonGlobalCache.GetCostume(store.CostumeID);
                    if (costume != null)

                    {
                        store.PfCustomerName = PfCustomerCache.GetPfCustomerName(store.PfCustomerID);
                        store.CostumeName = costume.Name;
                        store.ClassName = costume.ClassName;
                        store.Remarks = costume.Remarks;
                    }
                    this.costumeStoreList.Add(store);

                }
                if (this.costumeStoreList != null && this.costumeStoreList.Count > 0)
                {
                    this.dataGridViewPagingSumCtrl.BindingDataSource<PfCustomerStore>(DataGridViewUtil.ToDataTable<PfCustomerStore>(costumeStoreList));
                }
            }
            this.dataGridView1.Refresh();
        }

        private void skinComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pagePara = new GetPfCustomerStorePagePara();
           this.dataGridViewPagingSumCtrl.Initialize(1);
        }

        private void CostumeStoreSearchCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void CostumeCurrentShopTextBox1_CostumeSelected(Costume costume, bool isEnter)
        {
            if (isEnter)
            {
                FilterColor(costume);
                if (costume != null)
                {
                    this.BaseButton_Search_Click(null, null);
                }
            }
        }


        private void skinCheckBox_ShowPrice_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SetColumnDisplay()
        {
            this.CostPrice.Visible = skinCheckBox_ShowPrice.Checked;
            this.SumPfMoney.Visible = skinCheckBox_ShowPrice.Checked;
             this.CostPrice1.Visible= skinckbCostPrice.Checked;
            this.CostPriceSum.Visible= skinckbCostPrice.Checked;
            this.colorNameDataGridViewTextBoxColumn.Visible= skinCheckBoxShowColor.Checked;
        }


        public void WorkDeskCtrlSearch()
        {
            this.skinckbNoZeroStore.Checked = true;
            BuildPara();
            Search();
        }

        private void BuildPara()
        {
            string costumeID = string.IsNullOrEmpty(this.CostumeCurrentShopTextBox1.SkinTxt.Text.Trim()) ? null : this.CostumeCurrentShopTextBox1.SkinTxt.Text.Trim();
            bool isOnlyShowHaveNegative = this.skinckbNoZeroStore.Checked;
            string curBrandStr = ValidateUtil.CheckEmptyValue(this.skinComboBox_Brand.SelectedValue);
            int curBrandID = 0;
            if (curBrandStr == null)
            {
                curBrandID = 0;
            }
              curBrandID = Convert.ToInt32(curBrandStr);
            string curPfCustomerID = "";
            if (skinComboBoxSupplier.SelectedValue != null)
            {
                curPfCustomerID = ValidateUtil.CheckEmptyValue(skinComboBoxSupplier.SelectedValue);
            }
            else
            {
                if (skinComboBoxSupplier.Text != ""&& skinComboBoxSupplier.Text != "所有")
                {
                    GlobalMessageBox.Show("请输入正确的客户信息后再进行查询！");
                    this.skinComboBoxSupplier.Focus();
                    return;
                }
            }

            CostumeColor color = this.skinComboBox_Color.SelectedItem as CostumeColor;
            int year = (int)(this.skinComboBox_Year.SelectedValue);
            this.pagePara = new GetPfCustomerStorePagePara()
            {
                CostumeID = costumeID,
                BrandID = curBrandID,
                PfCustomerID = curPfCustomerID,
                PageIndex = 0,
                PageSize = int.MaxValue,// this.dataGridViewPagingSumCtrl.PageSize,
                ClassID = skinComboBoxBigClass.SelectedValue.ClassID, 
                ColorName = color?.Name == CommonGlobalUtil.COMBOBOX_ALL ? null : color?.Name, 
                Season = ValidateUtil.CheckEmptyValue(this.skinComboBox_Season.SelectedValue),
                SupplierID = ValidateUtil.CheckEmptyValue(supllierComboBox1.SelectedValue),
                Year = year,
                IsShowColor = skinCheckBoxShowColor.Checked,
                IsOnlyShowNotZero = isOnlyShowHaveNegative,
            };
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            String headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            if (headerText == "批发总额" || headerText == "批发价" || headerText == "总成本" || headerText == "成本价" || headerText == "总价值" || headerText == "吊牌价")
            {
                return;
            }
            if (e.Value != null && e.Value.ToString() == "0")
            {
                e.Value = string.Empty;
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

        DataRowView curCostume;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    if (CommonGlobalUtil.EngineUnconnectioned(this))
                    {
                        return;
                    }

                    DataRowView item = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                    if (curCostume != item && skinCheckBoxShowImage.Checked)
                    {
                        if (imageCtrl != null) {
                            imageCtrl?.Close();
                            imageCtrl = null;
                        }
                        imageCtrl = new SingleImageForm();
                        imageCtrl.FormClosing += ImageCtrl_FormClosing; 
                        imageCtrl.Text = "款号：" + item["CostumeID"];
                        imageCtrl.OnLoadingState();
                        skinCheckBoxShowImage.CheckedChanged -= skinCheckBoxShowImage_CheckedChanged;
                        skinCheckBoxShowImage.Checked = true;
                        skinCheckBoxShowImage.CheckedChanged += skinCheckBoxShowImage_CheckedChanged;

                        Costume cItem = CommonGlobalCache.GetCostume(item["CostumeID"].ToString());

                        if (cItem.EmThumbnail != "")
                        {
                            String url = cItem.EmThumbnail;
                            System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
                            System.Net.WebResponse webres = webreq.GetResponse();
                            using (System.IO.Stream stream = webres.GetResponseStream())
                            {
                                imageCtrl.Image = Image.FromStream(stream);
                            }
                          
                        }
                        else
                        {
                            imageCtrl.Image = null;
                        }

                       /* byte[] bytes = CommonGlobalCache.ServerProxy.GetCostumePhoto(item["CostumeID"].ToString());
                        if (bytes != null)
                        {
                            imageCtrl.Image = CCWin.SkinControl.ImageHelper.Convert(bytes);
                        }
                        else
                        {
                            imageCtrl.Image = null;
                        }*/
                        imageCtrl?.BringToFront();
                        imageCtrl?.Show();
                        curCostume = item;
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
        private String path;
        private void DoExport()
        {
            try
            {
            //    List<PfCustomerStore> unableStore = new List<PfCustomerStore>();
              //  List<PfCustomerStore> stores = new List<PfCustomerStore>();
               DataTable dt =   (DataTable)dataGridView1.DataSource;

              //  System.Collections.SortedList columns = new System.Collections.SortedList();
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                foreach (DataGridViewColumn item in dataGridView1.Columns)
                {
                    //if (IsPos)
                    //{
                    //    if (item.Index == CostPrice.Index || item.Index == SumCostMoney.Index)
                    //    {
                    //        continue;
                    //    }
                    //}
                    if (item.Visible)
                    {
                        keys.Add(item.DataPropertyName);
                        values.Add(item.HeaderText);
                    }
                }

                NPOIHelper.Keys = keys.ToArray();
                NPOIHelper.Values = values.ToArray();
                NPOIHelper.ExportExcel(dt, path);
                GlobalMessageBox.Show("导出完毕！");
            }
            catch (Exception ex)
            { ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }
        private void baseButtonExport_Click(object sender, EventArgs e)
        {

            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "客户库存查询" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
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
    }
}
