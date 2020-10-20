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
using JGNet.Core;
using CCWin.SkinControl;
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using JGNet.Server.Tools;
using CJBasic;
using JieXi.Common;

namespace JGNet.Common
{
    public partial class SalesQuantityRankingSearchCtrl : BaseUserControl
    {

        //当前dataGridView_RetailOrder一页显示多少条数据
        private SalesQuantityRankingPagePara pagePara;
        private List<CostumeStore> costumeStoreList = new List<CostumeStore>();
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public CJBasic.Action<SalesQuantityRanking, SalesQuantityRankingPagePara,  Panel> RowSelected;
        private DataGridViewRow currRow;

        public SalesQuantityRankingSearchCtrl()
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, BaseButton_Search_Click, new string[] {
            quantityOfSaleDataGridViewTextBoxColumn.DataPropertyName,
            sumMoneyDataGridViewTextBoxColumn.DataPropertyName
                });
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 Remarks });
            dataGridViewPagingSumCtrl.Initialize(); 
       
            dataGridViewPagingSumCtrl.ColumnSorting = dataGridViewPagingSumCtrl_ColumnSorting;
            dataGridViewPagingSumCtrl.SelectionChanged = dataGridView1_SelectionChanged;
            dataGridViewPagingSumCtrl.AutoIndex = false;
            this.skinSplitContainer1.Panel2Collapsed = true;
            firstInboundTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATE_FORMAT;
            firstSaleTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATE_FORMAT;
            LastSaleTime.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATE_FORMAT;

            CommonGlobalUtil.SetBrand(skinComboBox_Brand);
            this.skinComboBoxShopID.Initialize(false, CommonGlobalCache.IsGeneralStoreRetail != "1", CommonGlobalCache.BusinessAccount.OnlineEnabled);
            this.skinRadioButtonCostume.Checked = true;
            this.skinRadioButton1.Checked = true;
            List<ListItem<int>> stateList = new List<ListItem<int>>();
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            DateTimeUtil.DateTimePicker_ThisWeek(dateTimePickerStartInbound, dateTimePickerEndInbound);
            MenuPermission = RolePermissionMenuEnum.畅滞排行榜;
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }


        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            if (this.pagePara != null)
            {
                pagePara.PageIndex = index;
                SalesQuantityRankingPage listPage = CommonGlobalCache.ServerProxy.GetSalesQuantityRankingPage(this.pagePara);
                this.BindingCostumeStoreDataSource(listPage);
            }
        }

        private void Initialize()
        {

            BindingCostumeStoreDataSource(null);

            SetDisplay();
            
           
        }

        private void ImageCtrl_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.skinCheckBoxShowImage.Checked = false;
        }
         
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        }

        private void SetDisplay()
        {  
            this.skinSplitContainer1.Panel2Collapsed = true;
            dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(Column7, colorNameDataGridViewTextBoxColumn);
            dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(firstInboundTimeDataGridViewTextBoxColumn, firstSaleTimeDataGridViewTextBoxColumn, LastSaleTime);
            if (skinRadioButtonCostumeColor.Checked)
            {
                dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(colorNameDataGridViewTextBoxColumn);
            }
            else if (skinRadioButtonCostumeColorSize.Checked)
            {
                dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(Column7, colorNameDataGridViewTextBoxColumn);
                dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(LastSaleTime, firstInboundTimeDataGridViewTextBoxColumn, firstSaleTimeDataGridViewTextBoxColumn);
            }
             if (skinRadioButton2.Checked) {
                dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(UnsalableRate); 
            }
            else
            {
                dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(UnsalableRate);
            }
            if (skinRadioButton1.Checked)
            {
                dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(StartCostumeStoreCount, dataGridViewTextBoxColumn1);
            }
            else
            {
                dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(StartCostumeStoreCount, dataGridViewTextBoxColumn1);
            }
        }
          
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {

                    return;
                }


                this.skinCheckBoxShowImage.Checked = false;
                string BrandStr =ValidateUtil.CheckEmptyValue(this.skinComboBox_Brand.SelectedValue);
                int curBrandId = 0;
                if (BrandStr == null)
                {
                    curBrandId = 0;
                }
                curBrandId = Convert.ToInt32(BrandStr);

                this.pagePara = new SalesQuantityRankingPagePara()
                {
                    IsPos = BaseUserControl.IsPos,
                    StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                    EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                    ClassID = skinComboBoxBigClass.SelectedValue.ClassID, 
                    //SubSmallClass = skinComboBoxBigClass.SelectedValue?.SubSmallClass,
                    BrandID = curBrandId,
                    PageIndex = 0,
                    PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                    QueryType = this.skinRadioButtonCostume.Checked ? QueryType.CostumeID : QueryType.ColorName,
                    SalesQuantityType = this.skinRadioButton1.Checked ? SalesQuantityType.Selling : SalesQuantityType.Unsalable,
                    ShopID = ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue),
                    CostumeID = skinTextBoxID.Text, 
                    IsGetGeneralStore = CommonGlobalCache.IsGeneralStoreRetail  =="1",
                     InStartDate = new CJBasic.Date(this.dateTimePickerStartInbound.Value),
                     InEndDate = new CJBasic.Date(this.dateTimePickerEndInbound.Value)
                       
                      
                };
                pagePara.QueryType = QueryType.CostumeID;
                if (this.skinRadioButtonCostumeColor.Checked)
                {
                    pagePara.QueryType = QueryType.ColorName;
                }
                else if (skinRadioButtonCostumeColorSize.Checked)
                {
                    pagePara.QueryType = QueryType.CostumeIDColorNameSize;
                }
                SalesQuantityRankingPage listPage = CommonGlobalCache.ServerProxy.GetSalesQuantityRankingPage(this.pagePara);
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                this.dataGridViewPagingSumCtrl.Initialize(listPage);
                    showSelection= ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue) == null;
                    SetDisplay();
                this.BindingCostumeStoreDataSource(listPage);
                skinCheckBoxShowImage_CheckedChanged(null, null);
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

        private bool showSelection = false;

        /// <summary>
        /// 绑定CostumeStore数据源
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingCostumeStoreDataSource(SalesQuantityRankingPage listPage)
        {
            this.skinSplitContainer1.Panel2Collapsed = true; 
            if (listPage != null && listPage.SalesQuantityRankings != null)
            {
                //int i = 0;
                //foreach (SalesQuantityRanking item in listPage.SalesQuantityRankings)
                //{
                //    i++;
                //    item.Rank = i + ((this.pagePara.PageIndex) * this.pagePara.PageSize);
                //}

                //this.dataGridViewPagingSumCtrl.DataSource = listPage.SalesQuantityRankings;
            }
            dataGridViewPagingSumCtrl.BindingDataSource<SalesQuantityRanking>(listPage?.SalesQuantityRankings, null, listPage?.TotalEntityCount,listPage?.SalesQuantityRankingSum);
        }
         
        private void SalesQuantityRankingSearchCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        } 

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.CurrentRow;
            if (row != null && row.Index != -1 && row != currRow)
            {

                currRow = row;
                SalesQuantityRanking ranking = (SalesQuantityRanking)dataGridView1.CurrentRow.DataBoundItem;
                if (showSelection)
                {
                    if (RowSelected != null)
                    {
                        this.skinSplitContainer1.Panel2Collapsed = false;
                        RowSelected.Invoke(ranking, this.pagePara, this.skinSplitContainer1.Panel2);
                    }
                }
                try
                {
                    if (CommonGlobalUtil.EngineUnconnectioned(this))
                    {
                        return;
                    }
                    if (skinCheckBoxShowImage.Checked)
                    {
                        if (imageCtrl != null)
                        {
                            imageCtrl?.Close();
                            imageCtrl = null;
                        }
                        imageCtrl = new SingleImageForm();
                        imageCtrl.FormClosing += ImageCtrl_FormClosing;
                        imageCtrl.Text = "款号：" + ranking.CostumeID;
                        imageCtrl.OnLoadingState();
                        skinCheckBoxShowImage.CheckedChanged -= skinCheckBoxShowImage_CheckedChanged;
                        skinCheckBoxShowImage.Checked = true;
                        skinCheckBoxShowImage.CheckedChanged += skinCheckBoxShowImage_CheckedChanged;

                        Costume Curitem = CommonGlobalCache.GetCostume(ranking.CostumeID);
                       // byte[] bytes = CommonGlobalCache.ServerProxy.GetCostumePhoto(ranking.CostumeID);
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
                    }
                }
                catch (Exception ex)
                {
                  //  ShowError(ex);
                }
                finally
                {
                    UnLockPage();
                }
            }
        }

        SingleImageForm imageCtrl;
        private void skinCheckBoxShowImage_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBoxShowImage.Checked)
            {
                ShowImage(); 
            }
            else
            {
                imageCtrl?.Close();
            }
        }

        private void ShowImage()
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    if (CommonGlobalUtil.EngineUnconnectioned(this))
                    {
                        return;
                    }
                   
                   
                    SalesQuantityRanking item = (SalesQuantityRanking)dataGridView1.CurrentRow.DataBoundItem;
                    if (skinCheckBoxShowImage.Checked)
                    {
                        if (imageCtrl != null)
                        {
                            imageCtrl?.Close();
                            imageCtrl = null;
                        }
                        imageCtrl = new SingleImageForm();
                        imageCtrl.FormClosing += ImageCtrl_FormClosing;
                        imageCtrl.Text = "款号：" + item.CostumeID;
                        skinCheckBoxShowImage.CheckedChanged -= skinCheckBoxShowImage_CheckedChanged;
                        skinCheckBoxShowImage.Checked = true;
                        skinCheckBoxShowImage.CheckedChanged += skinCheckBoxShowImage_CheckedChanged;

                        imageCtrl.OnLoadingState();
                        Costume Curitem = CommonGlobalCache.GetCostume(item.CostumeID);
                       // byte[] bytes = CommonGlobalCache.ServerProxy.GetCostumePhoto(item.CostumeID);
                        if (Curitem.EmThumbnail != null)
                        {
                            //  imageCtrl.Image = CCWin.SkinControl.ImageHelper.Convert(bytes);
                            System.Net.WebRequest webreq = System.Net.WebRequest.Create(Curitem.EmThumbnail);
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
                        imageCtrl?.BringToFront();
                        imageCtrl?.Show();
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
        }

        private void skinTextBoxID_CursorChanged(object sender, EventArgs e)
        {

        }

        private void skinTextBoxID_CostumeSelected(Costume costume, bool isEnter)
        {
            if (costume != null && isEnter) {
                BaseButton_Search_Click(null, null);
            }
        }


        private String path;
        private void baseButton1_Click(object sender, EventArgs e)
        {
            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "畅滞排行榜" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
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

        private void DoExport()
        {
            try
            {
                if (dataGridView1.DataSource != null && dataGridView1.Rows.Count > 0)
                {
                    List<SalesQuantityRanking> list = (dataGridView1.DataSource) as List<SalesQuantityRanking>;
                    System.Collections.SortedList columns = new System.Collections.SortedList();
                    List<String> keys = new List<string>();
                    List<String> values = new List<string>();
                    foreach (DataGridViewColumn item in dataGridView1.Columns)
                    {
                        if (item.Visible)
                        {

                            keys.Add(item.DataPropertyName);
                            values.Add(item.HeaderText);

                        }
                    }


                    NPOIHelper.Keys = keys.ToArray();
                    NPOIHelper.Values = values.ToArray();
                    NPOIHelper.ExportExcel(DataGridViewUtil.ToDataTable(list), path);

                    GlobalMessageBox.Show("导出完毕！");
                }
            }
            catch (Exception ex)
            { ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }
    }
}
