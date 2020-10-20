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
    public partial class PfCostumeRetailAnalysisCtrl : BaseUserControl
    {
        public static String CONFIG_PATH = CommonGlobalUtil.AgileConfiguration("Manage.CostumePfAnalysisConfiguration");
        private GetPfRetailAnalysisPara pagePara;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private Costume curCostume;
        CostumePfAnalysisConfiguration config;
        public override void RefreshPage()
        {
        }

        public PfCostumeRetailAnalysisCtrl()
        {
            InitializeComponent();
            MenuPermission = RolePermissionMenuEnum.销售分析;
            //  this.Controls.Add(imageCtrl);
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1,
                new string[] {    Column2.DataPropertyName, Column3.DataPropertyName, Column4.DataPropertyName,
                    //Column5.DataPropertyName,
              //  Column6.DataPropertyName,  Column7.DataPropertyName,
        retailBenefitDataGridViewTextBoxColumn.DataPropertyName,
        retailBenefitRateDataGridViewTextBoxColumn.DataPropertyName,
          retailCountDataGridViewTextBoxColumn.DataPropertyName,
         retailCostPriceDataGridViewTextBoxColumn.DataPropertyName,

    }
        );
            dataGridViewPagingSumCtrl.Initialize();
            DateTimeUtil.DateTimePicker_ThisMonth(dateTimePicker_Start, dateTimePicker_End);
            List<String> list = new List<string>();
            list.Add("客户");
            list.Add("供应商");
            list.Add("品牌");
            list.Add("大类");
            list.Add("小类");
            list.Add("供应商+客户");
            list.Add("品牌+客户");
            list.Add("客户+供应商");
            list.Add("客户+品牌");
            config = CostumePfAnalysisConfiguration.Load(CONFIG_PATH) as CostumePfAnalysisConfiguration;
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
                config = new CostumePfAnalysisConfiguration() { Types = new List<String>() };
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
                string StrType = ValidateUtil.CheckEmptyValue(skinComboBoxGroup.SelectedValue);
                pagePara = new GetPfRetailAnalysisPara()
                {
                    PfCustomerID = ValidateUtil.CheckEmptyValue(this.pfCustomerComboBox1.SelectedValue),
                    CostumeID = this.skinTextBoxID.SkinTxt.Text,
                    StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                    EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                    BrandID = brand,
                    SupplierID = ValidateUtil.CheckEmptyValue(skinComboBoxSupplier.SelectedValue),
                    Type = StrType,
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

                InteractResult<PfRetailAnalysis> list = CommonGlobalCache.ServerProxy.GetPfRetailAnalysis(this.pagePara);

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
                String[] strs = StrType.Split('+');
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

        private void BindingDataSource(PfRetailAnalysis listPage)
        {
            // dataGridViewPagingSumCtrl.BindingDataSource(listPage?.RetailAnalysisList, listPage?.RetailAnalysisSum, false);
            //  dataGridViewPagingSumCtrl.BindingDataSource(DataGridViewUtil.ListToBindingList(listPage?.PfRetailAnalysisInfos),false, listPage?.RetailAnalysisSum);
            dataGridViewPagingSumCtrl.BindingDataSource(DataGridViewUtil.ListToBindingList(listPage?.PfRetailAnalysisInfos), false, listPage?.Sum);
        }

        private void CostumeManageCtrl_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewPagingSumCtrl.SetDataSource<SalesAnalysis>(null);
                pagePara = new GetPfRetailAnalysisPara();
                // this.skinComboBoxShopID.Initialize(false, CommonGlobalCache.IsGeneralStoreRetail != "1", CommonGlobalCache.BusinessAccount.OnlineEnabled);

                pfCustomerComboBox1.Initialize(false, true, -1);
                if (TypeValue1.HeaderText == "TypeValue1")
                {
                    TypeValue1.HeaderText = "客户";
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
                    TypeValue4.HeaderText = "品牌";
                    this.TypeValue4.Visible = false;
                }
                if (TypeValue5.HeaderText == "TypeValue5")
                {
                    TypeValue5.HeaderText = "大类";
                    this.TypeValue5.Visible = false;
                }
                if (TypeValue6.HeaderText == "TypeValue6")
                {
                    TypeValue6.HeaderText = "小类";
                    this.TypeValue6.Visible = false;
                }
                if (TypeValue7.HeaderText == "TypeValue7")
                {
                    TypeValue7.HeaderText = "款号";
                    this.TypeValue7.Visible = false;
                }
                if (TypeValue8.HeaderText == "TypeValue8")
                {
                    TypeValue8.HeaderText = "商品名称";
                    this.TypeValue8.Visible = false;
                }

                if (!HasPermission(RolePermissionEnum.查看_毛利))
                {
                    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(retailBenefitRateDataGridViewTextBoxColumn);
                }
            }
            catch (Exception ex)
            {

                ShowError(ex);
            }
        }
        List<ListItem<GroupType>> stateList = new List<ListItem<GroupType>>();

        private void SetGroup()
        {
            /*
                        stateList = new List<ListItem<GroupType>>();
                        stateList.Add(new ListItem<GroupType>(EnumHelper.GetDescription(GroupType.Shop), GroupType.Shop));
                        stateList.Add(new ListItem<GroupType>(EnumHelper.GetDescription(GroupType.Supplier), GroupType.Supplier));
                        stateList.Add(new ListItem<GroupType>(EnumHelper.GetDescription(GroupType.Brand), GroupType.Brand));
                        stateList.Add(new ListItem<GroupType>(EnumHelper.GetDescription(GroupType.BigClass), GroupType.BigClass));
                        stateList.Add(new ListItem<GroupType>(EnumHelper.GetDescription(GroupType.SmallClass), GroupType.SmallClass));


                        //stateList.Add(new ListItem<GroupType>(EnumHelper.GetDescription(GroupType.Supplier), GroupType.SupplierAndShop));
                        //stateList.Add(new ListItem<GroupType>(EnumHelper.GetDescription(GroupType.Brand), GroupType.BrandAndShop));
                        //stateList.Add(new ListItem<GroupType>(EnumHelper.GetDescription(GroupType.BigClass), GroupType.ShopAndSupplier));
                        //stateList.Add(new ListItem<GroupType>(EnumHelper.GetDescription(GroupType.SmallClass), GroupType.ShopAndBrand));
                        //// stateList.Add(new ListItem<GroupType>(EnumHelper.GetDescription(GroupType.SubSmallClass), GroupType.SubSmallClass));

                        this.skinComboBoxGroup.DisplayMember = "Key";
                        this.skinComboBoxGroup.ValueMember = "Value";
                        this.skinComboBoxGroup.DataSource = stateList;
                        */
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                DataGridView view = (DataGridView)sender;
                /* if (e.ColumnIndex == quantityOfSaleDataGridViewTextBoxColumn.Index)
                 {
                   List<SalesAnalysis> curDayReportListSource = DataGridViewUtil.BindingListToList<SalesAnalysis>(dataGridView1.DataSource);
                     //  List<RetailAnalysisInfo> curDayReportListSource = (List<RetailAnalysisInfo>)view.DataSource;
                     // curDayReportListSource.
                     SalesAnalysis item = curDayReportListSource[e.RowIndex];
                     DetailClick(item, pagePara.BrandID, pagePara.SupplierID, pagePara.ClassID);
                 }*/
            }
            catch (Exception ee)
            {

                ShowError(ee);
            }
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
                if (!String.IsNullOrEmpty(pagePara.PfCustomerID))
                {
                    item.ShopID = pagePara.PfCustomerID;
                }
                form.ShowDialog(item, dateTimePicker_Start, dateTimePicker_End, brand, supplier, ClassId,this);
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
            PfSaleAnalysisCollectTypeForm1 multiselectForm = new PfSaleAnalysisCollectTypeForm1();
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

            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "批发销售分析" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
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
                    List<PfRetailAnalysisInfo> list = DataGridViewUtil.BindingListToList<PfRetailAnalysisInfo>(dataGridView1.DataSource);
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
            // RetailCount

            //if(e.ColumnIndex == RetailCount.Index)
            //     {
            //    /*  List<SalesAnalysis> curDayReportListSource = DataGridViewUtil.BindingListToList<SalesAnalysis>(dataGridView1.DataSource);
            //      //  List<RetailAnalysisInfo> curDayReportListSource = (List<RetailAnalysisInfo>)view.DataSource;
            //      // curDayReportListSource.
            //      SalesAnalysis item = curDayReportListSource[e.RowIndex];
            //      DetailClick(item, pagePara.BrandID, pagePara.SupplierID, pagePara.ClassID);*/
            //    CostumeRetailAnalysisDetailForm form = new CostumeRetailAnalysisDetailForm();
            //    form.getData();
            //}
        }
    }
}