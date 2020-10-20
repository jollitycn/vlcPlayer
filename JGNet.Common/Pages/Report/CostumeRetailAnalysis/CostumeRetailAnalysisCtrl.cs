using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CJBasic.Widget;
using CJBasic;
using CJBasic.Loggers;
using JGNet.Core.InteractEntity;

using CCWin.SkinControl;
using JGNet.Core.Tools;
using CCWin;
using JGNet.Core;
using System.Reflection;
using JGNet.Common.Core;
using JGNet.Common.Components;
using JGNet.Core.Dev.MyEnum;
using JGNet.Common.Core.Util;
using JGNet.Manage.Pages;
using JieXi.Common;

namespace JGNet.Common

{
    public partial class CostumeRetailAnalysisCtrl : BaseUserControl
    {
        public static String CONFIG_PATH = CommonGlobalUtil.AgileConfiguration("Manage.CostumeRetailAnalysisConfiguration");
        private GetSalesAnalysisPara pagePara;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private Costume curCostume;
        CostumeRetailAnalysisConfiguration config;
        

        public CostumeRetailAnalysisCtrl()
        {
            InitializeComponent();
            MenuPermission = RolePermissionMenuEnum.销售分析;
            //  this.Controls.Add(imageCtrl);
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1,
                new string[] {  Column1.DataPropertyName,  Column2.DataPropertyName, Column3.DataPropertyName, Column4.DataPropertyName, Column5.DataPropertyName,
                Column6.DataPropertyName,  Column7.DataPropertyName,
        quantityOfSaleDataGridViewTextBoxColumn.DataPropertyName,
          salesTotalMoneyDataGridViewTextBoxColumn.DataPropertyName,
        salesTotalCostDataGridViewTextBoxColumn.DataPropertyName,
         salesBenefitDataGridViewTextBoxColumn.DataPropertyName,
         benefitRateDataGridViewTextBoxColumn.DataPropertyName

    }
        );
            //
            dataGridViewPagingSumCtrl.Initialize();
            DateTimeUtil.DateTimePicker_ThisMonth(dateTimePicker_Start, dateTimePicker_End);
            List<String> list = new List<string>();
            list.Add("店铺");
            list.Add("供应商");
            list.Add("品牌");
            list.Add("大类");
            list.Add("小类");
            list.Add("供应商+店铺");
            list.Add("品牌+店铺");
            list.Add("店铺+供应商");
            list.Add("店铺+品牌");
            config = CostumeRetailAnalysisConfiguration.Load(CONFIG_PATH) as CostumeRetailAnalysisConfiguration;
            if (config != null)
            {
                foreach (var item in config.Types)
                {
                    if (list.Find(t => t == item) == null)
                    {
                        list.Add(item);
                    }
                }
                config.Types = list;
            }
            else
            {
                config = new CostumeRetailAnalysisConfiguration() { Types = new List<String>() };
                config.Types.AddRange(list);
            }
            SetUnconsumedDays();
            CommonGlobalUtil.SetBrand(this.skinComboBox_Brand);

        }
        private void SetVisible(List<DataGridViewTextBoxColumn> listColumn)
        {
            foreach (DataGridViewTextBoxColumn cItem in listColumn)
            {
                if (cItem.Visible)
                {
                    cItem.Visible = false;
                }

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
                int brand = Convert.ToInt32(ValidateUtil.CheckEmptyValue(this.skinComboBox_Brand.SelectedValue));
                string typeStr = ValidateUtil.CheckEmptyValue(skinComboBoxGroup.SelectedValue);
                pagePara = new GetSalesAnalysisPara()
                {
                    ShopID = ValidateUtil.CheckEmptyValue(this.skinComboBoxShopID.SelectedValue),
                    CostumeID = this.skinTextBoxID.SkinTxt.Text,
                    StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                    EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                    BrandID = brand,
                    SupplierID = ValidateUtil.CheckEmptyValue(skinComboBoxSupplier.SelectedValue),
                    Type = typeStr,
                    ClassID = (int)skinComboBoxBigClass.SelectedValue.ClassID,

                    //GroupType = (GroupType)skinComboBoxGroup.SelectedValue, 
                    // IsGetGeneralStore = CommonGlobalCache.IsGeneralStoreRetail=="1"
                };

                //if (pagePara.GroupType == GroupType.Shop)
                //{
                //    ColumnDetail.Visible = true;
                //}
                //else
                //{
                //    ColumnDetail.Visible = false;
                //}
                DateTime STime = DateTime.Now;
                InteractResult<SalesAnalysisInfo> list = CommonGlobalCache.ServerProxy.GetSalesAnalysis(this.pagePara);

                DateTime ETime = DateTime.Now;
                TimeSpan spanA = (TimeSpan)(ETime - STime);

                WriteLog("销售分析零售数据加载开始时间：" + STime + " 结束时间：" + ETime + " 总耗时数：" + spanA.TotalSeconds + "秒");
                //GlobalMessageBox.Show("数据加载完成！");


                /*   if (String.IsNullOrEmpty(pagePara.CostumeID))
                   {
                       groupTypeNameDataGridViewTextBoxColumn.HeaderText = "分组";
                   }
                   else
                   {
                       if (pagePara.ShopID == null)
                       {
                           groupTypeNameDataGridViewTextBoxColumn.HeaderText = "店鋪";
                       }
                       else
                       {
                           groupTypeNameDataGridViewTextBoxColumn.HeaderText = "款号";
                       }
                   }*/
                DateTime startTime = DateTime.Now;
                String[] strs = typeStr.Split('+');
                if (strs.Length == 1)
                {//款号 
                    TypeValue1.Visible = true;
                    TypeValue1.HeaderText = strs[0];
                    TypeValue2.Visible = false;
                    TypeValue3.Visible = false;
                    List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                    listColumn.Add(TypeValue4);
                    listColumn.Add(TypeValue5);
                    listColumn.Add(TypeValue6);
                    listColumn.Add(TypeValue7);
                    listColumn.Add(TypeValue8);
                    SetVisible(listColumn);
                }
                else
               if (strs.Length == 2)
                {//供应商+款号、品牌 + 款号、日期 + 款号
                    TypeValue1.Visible = true;
                    TypeValue1.HeaderText = strs[0];
                    TypeValue2.Visible = true;
                    TypeValue2.HeaderText = strs[1];
                    TypeValue3.Visible = false;
                    List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                    listColumn.Add(TypeValue4);
                    listColumn.Add(TypeValue5);
                    listColumn.Add(TypeValue6);
                    listColumn.Add(TypeValue7);
                    listColumn.Add(TypeValue8);
                    SetVisible(listColumn);

                }
                else
               if (strs.Length == 3)
                {//日期 + 单号 + 供应商
                    TypeValue1.Visible = true;
                    TypeValue1.HeaderText = strs[0];
                    TypeValue2.Visible = true;
                    TypeValue2.HeaderText = strs[1];
                    TypeValue3.Visible = true;
                    TypeValue3.HeaderText = strs[2];
                    List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                    listColumn.Add(TypeValue4);
                    listColumn.Add(TypeValue5);
                    listColumn.Add(TypeValue6);
                    listColumn.Add(TypeValue7);
                    listColumn.Add(TypeValue8);
                    SetVisible(listColumn);
                }
                else
               if (strs.Length == 4)
                {//日期 + 单号 + 供应商
                    TypeValue1.Visible = true;
                    TypeValue1.HeaderText = strs[0];
                    TypeValue2.Visible = true;
                    TypeValue2.HeaderText = strs[1];
                    TypeValue3.Visible = true;
                    TypeValue3.HeaderText = strs[2];
                    TypeValue4.Visible = true;
                    TypeValue4.HeaderText = strs[3];
                    List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                    listColumn.Add(TypeValue5);
                    listColumn.Add(TypeValue6);
                    listColumn.Add(TypeValue7);
                    listColumn.Add(TypeValue8);
                    SetVisible(listColumn);
                }
                else
               if (strs.Length == 5)
                {//日期 + 单号 + 供应商
                    TypeValue1.Visible = true;
                    TypeValue1.HeaderText = strs[0];
                    TypeValue2.Visible = true;
                    TypeValue2.HeaderText = strs[1];
                    TypeValue3.Visible = true;
                    TypeValue3.HeaderText = strs[2];
                    TypeValue4.Visible = true;
                    TypeValue4.HeaderText = strs[3];
                    TypeValue5.Visible = true;
                    TypeValue5.HeaderText = strs[4];

                    List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();

                    listColumn.Add(TypeValue6);
                    listColumn.Add(TypeValue7);
                    listColumn.Add(TypeValue8);
                    SetVisible(listColumn);
                }
                else
               if (strs.Length == 6)
                {//日期 + 单号 + 供应商
                    TypeValue1.Visible = true;
                    TypeValue1.HeaderText = strs[0];
                    TypeValue2.Visible = true;
                    TypeValue2.HeaderText = strs[1];
                    TypeValue3.Visible = true;
                    TypeValue3.HeaderText = strs[2];
                    TypeValue4.Visible = true;
                    TypeValue4.HeaderText = strs[3];
                    TypeValue5.Visible = true;
                    TypeValue5.HeaderText = strs[4];
                    TypeValue6.Visible = true;
                    TypeValue6.HeaderText = strs[5];

                    List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();

                    listColumn.Add(TypeValue7);
                    listColumn.Add(TypeValue8);
                    SetVisible(listColumn);
                }
                else
               if (strs.Length == 7)
                {//日期 + 单号 + 供应商
                    TypeValue1.Visible = true;
                    TypeValue1.HeaderText = strs[0];
                    TypeValue2.Visible = true;
                    TypeValue2.HeaderText = strs[1];
                    TypeValue3.Visible = true;
                    TypeValue3.HeaderText = strs[2];
                    TypeValue4.Visible = true;
                    TypeValue4.HeaderText = strs[3];
                    TypeValue5.Visible = true;
                    TypeValue5.HeaderText = strs[4];
                    TypeValue6.Visible = true;
                    TypeValue6.HeaderText = strs[5];
                    TypeValue7.Visible = true;
                    TypeValue7.HeaderText = strs[6];

                    List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                    listColumn.Add(TypeValue8);
                    SetVisible(listColumn);
                }
                else
               if (strs.Length == 8)
                {//日期 + 单号 + 供应商
                    TypeValue1.Visible = true;
                    TypeValue1.HeaderText = strs[0];
                    TypeValue2.Visible = true;
                    TypeValue2.HeaderText = strs[1];
                    TypeValue3.Visible = true;
                    TypeValue3.HeaderText = strs[2];
                    TypeValue4.Visible = true;
                    TypeValue4.HeaderText = strs[3];
                    TypeValue5.Visible = true;
                    TypeValue5.HeaderText = strs[4];
                    TypeValue6.Visible = true;
                    TypeValue6.HeaderText = strs[5];
                    TypeValue7.Visible = true;
                    TypeValue7.HeaderText = strs[6];
                    TypeValue8.Visible = true;
                    TypeValue8.HeaderText = strs[7];
                }





                if (!String.IsNullOrEmpty(pagePara.CostumeID))
                {

                    if (strs.Length == 1)
                    {//款号 
                        TypeValue1.Visible = true;
                        TypeValue1.HeaderText = strs[0];
                        TypeValue2.Visible = false;
                        TypeValue3.Visible = false;
                        List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                        listColumn.Add(TypeValue4);
                        listColumn.Add(TypeValue5);
                        listColumn.Add(TypeValue6);
                        listColumn.Add(TypeValue7);
                        listColumn.Add(TypeValue8);
                        SetVisible(listColumn);
                    }
                    else
                if (strs.Length == 2)
                    {//供应商+款号、品牌 + 款号、日期 + 款号
                        TypeValue1.Visible = true;
                        TypeValue1.HeaderText = strs[0];
                        TypeValue2.Visible = true;
                        TypeValue2.HeaderText = strs[1];
                        TypeValue3.Visible = false;
                        List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                        listColumn.Add(TypeValue4);
                        listColumn.Add(TypeValue5);
                        listColumn.Add(TypeValue6);
                        listColumn.Add(TypeValue7);
                        listColumn.Add(TypeValue8);
                        SetVisible(listColumn);
                    }
                    else
                if (strs.Length == 3)
                    {//日期 + 单号 + 供应商
                        TypeValue1.Visible = true;
                        TypeValue1.HeaderText = strs[0];
                        TypeValue2.Visible = true;
                        TypeValue2.HeaderText = strs[1];
                        TypeValue3.Visible = true;
                        TypeValue3.HeaderText = strs[2];
                        List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                        listColumn.Add(TypeValue4);
                        listColumn.Add(TypeValue5);
                        listColumn.Add(TypeValue6);
                        listColumn.Add(TypeValue7);
                        listColumn.Add(TypeValue8);
                        SetVisible(listColumn);
                    }
                    else
               if (strs.Length == 4)
                    {//日期 + 单号 + 供应商
                        TypeValue1.Visible = true;
                        TypeValue1.HeaderText = strs[0];
                        TypeValue2.Visible = true;
                        TypeValue2.HeaderText = strs[1];
                        TypeValue3.Visible = true;
                        TypeValue3.HeaderText = strs[2];
                        TypeValue4.Visible = true;
                        TypeValue4.HeaderText = strs[3];
                        List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                        listColumn.Add(TypeValue5);
                        listColumn.Add(TypeValue6);
                        listColumn.Add(TypeValue7);
                        listColumn.Add(TypeValue8);
                        SetVisible(listColumn);
                    }
                    else
               if (strs.Length == 5)
                    {//日期 + 单号 + 供应商
                        TypeValue1.Visible = true;
                        TypeValue1.HeaderText = strs[0];
                        TypeValue2.Visible = true;
                        TypeValue2.HeaderText = strs[1];
                        TypeValue3.Visible = true;
                        TypeValue3.HeaderText = strs[2];
                        TypeValue4.Visible = true;
                        TypeValue4.HeaderText = strs[3];
                        TypeValue5.Visible = true;
                        TypeValue5.HeaderText = strs[4];
                        List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                        listColumn.Add(TypeValue6);
                        listColumn.Add(TypeValue7);
                        listColumn.Add(TypeValue8);
                        SetVisible(listColumn);
                    }
                    else
               if (strs.Length == 6)
                    {//日期 + 单号 + 供应商
                        TypeValue1.Visible = true;
                        TypeValue1.HeaderText = strs[0];
                        TypeValue2.Visible = true;
                        TypeValue2.HeaderText = strs[1];
                        TypeValue3.Visible = true;
                        TypeValue3.HeaderText = strs[2];
                        TypeValue4.Visible = true;
                        TypeValue4.HeaderText = strs[3];
                        TypeValue5.Visible = true;
                        TypeValue5.HeaderText = strs[4];
                        TypeValue6.Visible = true;
                        TypeValue6.HeaderText = strs[5];
                        List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                        listColumn.Add(TypeValue7);
                        listColumn.Add(TypeValue8);
                        SetVisible(listColumn);
                    }
                    else
               if (strs.Length == 7)
                    {//日期 + 单号 + 供应商
                        TypeValue1.Visible = true;
                        TypeValue1.HeaderText = strs[0];
                        TypeValue2.Visible = true;
                        TypeValue2.HeaderText = strs[1];
                        TypeValue3.Visible = true;
                        TypeValue3.HeaderText = strs[2];
                        TypeValue4.Visible = true;
                        TypeValue4.HeaderText = strs[3];
                        TypeValue5.Visible = true;
                        TypeValue5.HeaderText = strs[4];
                        TypeValue6.Visible = true;
                        TypeValue6.HeaderText = strs[5];
                        TypeValue7.Visible = true;
                        TypeValue7.HeaderText = strs[6];
                        List<DataGridViewTextBoxColumn> listColumn = new List<DataGridViewTextBoxColumn>();
                        listColumn.Add(TypeValue8);
                        SetVisible(listColumn);
                    }
                    else
               if (strs.Length == 8)
                    {//日期 + 单号 + 供应商
                        TypeValue1.Visible = true;
                        TypeValue1.HeaderText = strs[0];
                        TypeValue2.Visible = true;
                        TypeValue2.HeaderText = strs[1];
                        TypeValue3.Visible = true;
                        TypeValue3.HeaderText = strs[2];
                        TypeValue4.Visible = true;
                        TypeValue4.HeaderText = strs[3];
                        TypeValue5.Visible = true;
                        TypeValue5.HeaderText = strs[4];
                        TypeValue6.Visible = true;
                        TypeValue6.HeaderText = strs[5];
                        TypeValue7.Visible = true;
                        TypeValue7.HeaderText = strs[6];
                        TypeValue8.Visible = true;
                        TypeValue8.HeaderText = strs[7];
                    }





                }
                DateTime endTime = DateTime.Now;
                TimeSpan span = (TimeSpan)(endTime - startTime);
                WriteLog("销售分析零售数据设置加载开始时间：" + startTime + " 结束时间：" + endTime + " 总耗时数：" + span.TotalSeconds + "秒");
                this.BindingDataSource(list.Data);

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

        private void BindingDataSource(SalesAnalysisInfo listPage)
        {
            // dataGridViewPagingSumCtrl.BindingDataSource(listPage?.RetailAnalysisList, listPage?.RetailAnalysisSum, false);
            /*  if (!HasPermission(RolePermissionEnum.查看_毛利))
              {
                  dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(benefitRateDataGridViewTextBoxColumn,BenefitRate);
              }*/
            //GlobalMessageBox.Show("界面加载开始！");
            dataGridViewPagingSumCtrl.BindingDataSource(DataGridViewUtil.ListToBindingList(listPage?.RetailAnalysisList), false, listPage?.RetailAnalysisSum);
            //GlobalMessageBox.Show("界面加载完成！");
            //if (!HasPermission(RolePermissionEnum.查看_毛利))
            //{
            //    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(BenefitRate);
            //}
        }

        private void CostumeManageCtrl_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewPagingSumCtrl.SetDataSource<SalesAnalysis>(null);
                pagePara = new GetSalesAnalysisPara();
                this.skinComboBoxShopID.Initialize(false, CommonGlobalCache.IsGeneralStoreRetail != "1", CommonGlobalCache.BusinessAccount.OnlineEnabled);
                if (TypeValue1.HeaderText == "TypeValue1")
                {
                    TypeValue1.HeaderText = "款号";
                    this.TypeValue1.Visible = false;

                }
                if (TypeValue2.HeaderText == "TypeValue2")
                {
                    TypeValue2.HeaderText = "品牌";
                    this.TypeValue2.Visible = false;

                }
                if (TypeValue3.HeaderText == "TypeValue3")
                {
                    TypeValue3.HeaderText = "供应商";
                    this.TypeValue3.Visible = false;
                }
                if (TypeValue4.HeaderText == "TypeValue4")
                {
                    TypeValue4.HeaderText = "大类";
                    this.TypeValue4.Visible = false;
                }
                if (TypeValue5.HeaderText == "TypeValue5")
                {
                    TypeValue5.HeaderText = "小类";
                    this.TypeValue5.Visible = false;
                }
                if (TypeValue6.HeaderText == "TypeValue6")
                {
                    TypeValue6.HeaderText = "款号";
                    this.TypeValue6.Visible = false;
                }
                if (TypeValue7.HeaderText == "TypeValue7")
                {
                    TypeValue7.HeaderText = "名称";
                    this.TypeValue7.Visible = false;
                }
                if (TypeValue8.HeaderText == "TypeValue8")
                {
                    TypeValue8.HeaderText = "年份";
                    this.TypeValue8.Visible = false;
                }
                if (!HasPermission(RolePermissionEnum.查看_毛利))
                {
                    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(benefitRateDataGridViewTextBoxColumn);
                    //  this.benefitRateDataGridViewTextBoxColumn.Visible = false;
                    this.benefitRateDataGridViewTextBoxColumn.HeaderText = " ";
                }
                else
                {
                    dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(benefitRateDataGridViewTextBoxColumn);
                }

            }
            catch (Exception ex)
            {

                ShowError(ex);
            }
        }
        List<ListItem<GroupType>> stateList = new List<ListItem<GroupType>>();



        private void DetailClick(SalesAnalysis item)
        {
            CostumeRetailAnalysisDetailForm form = new CostumeRetailAnalysisDetailForm();
            if (this.skinTextBoxID.SkinTxt.Text != null && this.skinTextBoxID.SkinTxt.Text != "")
            {
                item.CostumeID = this.skinTextBoxID.SkinTxt.Text;
            }
            if (!String.IsNullOrEmpty(pagePara.ShopID))
            {
                item.ShopID = pagePara.ShopID;
            }
            form.ShowDialog(item, dateTimePicker_Start, dateTimePicker_End, pagePara, this);
        }

        private void DetailClick(SalesAnalysis item, int brand, string supplier, int ClassId)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                CostumeRetailAnalysisDetailForm form = new CostumeRetailAnalysisDetailForm();

                //GetSalesAnalysisDeatilInfoPara 传该对象过去
                if (this.skinTextBoxID.SkinTxt.Text != null && this.skinTextBoxID.SkinTxt.Text != "")
                {

                    item.CostumeID = this.skinTextBoxID.SkinTxt.Text;
                }
                if (!String.IsNullOrEmpty(pagePara.ShopID))
                {
                    item.ShopID = pagePara.ShopID;
                }
                form.ShowDialog(item, dateTimePicker_Start, dateTimePicker_End, brand, supplier, ClassId, this);
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

        private void skinTextBoxID_CostumeSelected(Costume costume, bool isEnter)
        {
            if (costume != null && isEnter)
            {
                BaseButton_Search_Click(null, null);
            }
        }

        private void SetUnconsumedDays()
        {
            List<ListItem<String>> list = new List<ListItem<string>>();
            foreach (var item in config.Types)
            {
                list.Add(new ListItem<string>(item, item));
            }

            this.skinComboBoxGroup.DisplayMember = "Key";
            this.skinComboBoxGroup.ValueMember = "Value";
            this.skinComboBoxGroup.DataSource = list;
        }

        private void baseButton2_Click(object sender, EventArgs e)
        {
            SaleAnalysisCollectTypeForm1 multiselectForm = new SaleAnalysisCollectTypeForm1();
            //  multiselectForm.MemberMultiSelected += MemberMultiSelected;
            // multiselectForm.ShowDialog();
            //    SalesPromotionCostumeSelectForm form = new SalesPromotionCostumeSelectForm(tempItem, curType, isSalesPromotionUse, filterValid);

            List<ListItem<String>> costumeResult = null;
            if (multiselectForm.ShowDialog(this) == DialogResult.OK)
            {
                costumeResult = multiselectForm.Result;
            }

            if (costumeResult == null)
            {
                return;
            }

            String value = String.Empty;
            foreach (var item in costumeResult)
            {
                value += item.Key + "+";
            }
            if (!String.IsNullOrEmpty(value)) { value = value.Remove(value.LastIndexOf("+")); }

            List<ListItem<string>> list = this.skinComboBoxGroup.DataSource as List<ListItem<string>>;
            if (list.Find(t => t.Key == value) == null)
            {
                list.Add(new ListItem<string>(value, value));
            }
            config.Types.Clear();
            foreach (var item in list)
            {
                config.Types.Add(item.Key);
            }

            config.Save(CONFIG_PATH);
            SetUnconsumedDays();
            skinComboBoxGroup.SelectedValue = value;
        }

        private String path;
        private void baseButton1_Click(object sender, EventArgs e)
        {

            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "零售销售分析" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
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
                    List<SalesAnalysis> list = DataGridViewUtil.BindingListToList<SalesAnalysis>(dataGridView1.DataSource);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             /* if (e.RowIndex < 0 || e.ColumnIndex < 0)
              {
                  return;
              }
              try
              {
                  //if (CommonGlobalUtil.EngineUnconnectioned(this))
                  //{
                  //    return;
                  //}
                  DataGridView view = (DataGridView)sender;
                  if (e.ColumnIndex == quantityOfSaleDataGridViewTextBoxColumn.Index)
                  {
                      List<SalesAnalysis> curDayReportListSource = DataGridViewUtil.BindingListToList<SalesAnalysis>(dataGridView1.DataSource);
                      //  List<RetailAnalysisInfo> curDayReportListSource = (List<RetailAnalysisInfo>)view.DataSource;
                      // curDayReportListSource.
                      SalesAnalysis item = curDayReportListSource[e.RowIndex];
                      //  DetailClick(item, pagePara.BrandID, pagePara.SupplierID, pagePara.ClassID); 
                      CostumeRetailAnalysisDetailForm form = new CostumeRetailAnalysisDetailForm();
                      form.getData();
                      //form.ShowDialog(item, dateTimePicker_Start, dateTimePicker_End, pagePara, this);
                      // DetailClick(item);
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
              */
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                if (e.ColumnIndex == quantityOfSaleDataGridViewTextBoxColumn.Index)
                {

                    try
                    {
                        if (CommonGlobalUtil.EngineUnconnectioned(this))
                        {
                            return;
                        }
                        //CostumeRetailAnalysisDetailForm form = new CostumeRetailAnalysisDetailForm();
                        //form.getData();
                        List<SalesAnalysis> curDayReportListSource = DataGridViewUtil.BindingListToList<SalesAnalysis>(dataGridView1.DataSource); 
                        SalesAnalysis item = curDayReportListSource[e.RowIndex];
                        DetailClick(item);

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
