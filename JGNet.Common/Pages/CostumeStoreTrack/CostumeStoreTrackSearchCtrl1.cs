using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Common.Core;
using JGNet.Common;
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using JGNet.Core;
using JGNet.Core.Const;
using CCWin.SkinControl;
using System.Reflection;
using CJBasic.Helpers;

namespace JGNet.Common
{
    public partial class CostumeStoreTrackSearchCtrl1 : BaseUserControl
    {
        private string shopID;
        private GetCostumeStoreChangePara pagePara;
        public CJBasic.Action<int,CostumeStoreChangeInfo, BaseUserControl> DetailClick;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        ///// <summary>
        ///// 点击查询入库差异单明细
        ///// </summary>
        //public event CJBasic.Action<CostumeStoreChangeInfo,Type> CostumeStoreTrackDetailClick;
        public CostumeStoreTrackSearchCtrl1()
        {
            InitializeComponent();
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1
                , new string[] {
        inDataGridViewTextBoxColumn.DataPropertyName,
         intoDataGridViewTextBoxColumn.DataPropertyName,
         returnDataGridViewTextBoxColumn.DataPropertyName,
        turnOutDataGridViewTextBoxColumn.DataPropertyName,
         retailDataGridViewTextBoxColumn.DataPropertyName,
        scrapDataGridViewTextBoxColumn.DataPropertyName,
         profitDataGridViewTextBoxColumn.DataPropertyName
    });
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(
            inDataGridViewTextBoxColumn,
            intoDataGridViewTextBoxColumn,
            returnDataGridViewTextBoxColumn,
            turnOutDataGridViewTextBoxColumn,
            retailDataGridViewTextBoxColumn,
            scrapDataGridViewTextBoxColumn,
            profitDataGridViewTextBoxColumn);
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.ColumnSorting += dataGridViewPagingSumCtrl_ColumnSorting;
            dataGridView1.ColumnHeadersHeight = 40;
            SetSpanInfo();
            MenuPermission = RolePermissionMenuEnum.库存变化查询;
        }

        private void SetSpanInfo()
        { 
            dataGridView1.ClearSpanInfo();
            this.dataGridView1.AddSpanHeader(1, 2, "入库");
            this.dataGridView1.AddSpanHeader(3, 4, "出库");
            //this.dataGridView1.MergeColumnNames.Add("Column" + (++i));
            //this.dataGridView1.MergeColumnNames.Add("Column" + (++i));
            //this.dataGridView1.MergeColumnNames.Add("Column" + (++i));
            //this.dataGridView1.MergeColumnNames.Add("Column" + (++i));
            //this.dataGridView1.AddSpanHeader((i), 4, "出库"); 
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void Initialize()
        {
            this.pagePara = new GetCostumeStoreChangePara();
            this.costumeTextBox1.SkinTxt.Text = string.Empty;
            this.dataGridView1.DataSource = null;
            this.dateTimePicker_Start.Value = DateTime.Now.AddMonths(-1);
            this.dateTimePicker_End.Value = DateTime.Now;
            //店铺

            CommonGlobalUtil.SetCostumeColor(this.skinComboBox_Color, false, null, false);
            CommonGlobalUtil.SetCostumeSize(this.skinComboBox_Size,null, CommonGlobalCache.DefaultSizeGroup, true, false);
           skinComboBox_DestShop.Initialize(true);
            if (HasPermission(RolePermissionEnum.查看_只看本店))
            {
                this.skinComboBox_DestShop.Enabled = false;
                shopID = CommonGlobalCache.CurrentShopID;
                skinComboBox_DestShop.SelectedValue = shopID;
            }

            this.skinSplitContainer1.Panel2Collapsed = true;
        } 

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                string costumeID = string.IsNullOrEmpty(this.costumeTextBox1.SkinTxt.Text) ? null : this.costumeTextBox1.SkinTxt.Text;

                String color = ((CostumeColor)skinComboBox_Color.SelectedItem).Name;// ValidateUtil.CheckEmptyValue();
                String size = ValidateUtil.CheckEmptyValue(skinComboBox_Size.SelectedValue);
                if (color == CommonGlobalUtil.COMBOBOX_ALL) { color = String.Empty; }
                // this.dataGridViewPagingSumCtrl.PageSize = int.MaxValue;
                this.pagePara = new GetCostumeStoreChangePara()
                {
                    // CostumeStoreChangeType = ValidateUtil.CheckEmptyValue(this.skinComboBoxChangeType.SelectedValue),
                    CostumeID = costumeID,
                    StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                    EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                    ColorName = color,
                    SizeName = size,     
                    ShopID = shopID,
                };
                CostumeStoreChange listPage = CommonGlobalCache.ServerProxy.GetCostumeStoreChange(this.pagePara);
                // dataGridViewPagingSumCtrl.Initialize(listPage);
              //  SetSpanInfo();
                this.BindingSource(listPage);

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

        private void BindingSource(CostumeStoreChange listPage)
        { 
            dataGridViewPagingSumCtrl.BindingDataSource<CostumeStoreChangeInfo>(DataGridViewUtil.ListToBindingList(listPage?.CostumeStoreChangeInfos));
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

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
                List<CostumeStoreChangeInfo> list = DataGridViewUtil.BindingListToList<CostumeStoreChangeInfo>(dataGridView1.DataSource);
                CostumeStoreChangeInfo item = (CostumeStoreChangeInfo)list[e.RowIndex];
                
                
                if (e.ColumnIndex == inDataGridViewTextBoxColumn.Index 
                    || e.ColumnIndex == intoDataGridViewTextBoxColumn.Index 
                    || e.ColumnIndex == returnDataGridViewTextBoxColumn.Index 
                    || e.ColumnIndex == turnOutDataGridViewTextBoxColumn.Index 
                    || e.ColumnIndex == retailDataGridViewTextBoxColumn.Index  
                    || e.ColumnIndex == scrapDataGridViewTextBoxColumn.Index
                    || e.ColumnIndex == profitDataGridViewTextBoxColumn.Index)
                {
                    int type = 0;
                    if (e.ColumnIndex == inDataGridViewTextBoxColumn.Index)
                    {
                        type = CommonInformationTypes.GetCostumeStoreChange4In;
                    }
                    else if (e.ColumnIndex == intoDataGridViewTextBoxColumn.Index)
                    {
                        type = CommonInformationTypes.GetCostumeStoreChange4Into;
                    }
                    else if (e.ColumnIndex == returnDataGridViewTextBoxColumn.Index)
                    {
                        type = CommonInformationTypes.GetCostumeStoreChange4Return;
                    }
                    else if (e.ColumnIndex == turnOutDataGridViewTextBoxColumn.Index)
                    {
                        type = CommonInformationTypes.GetCostumeStoreChange4TurnOut;
                    }
                    else if (e.ColumnIndex == retailDataGridViewTextBoxColumn.Index)
                    {
                        type = CommonInformationTypes.GetCostumeStoreChange4Retail;
                    }
                    else if (e.ColumnIndex == scrapDataGridViewTextBoxColumn.Index)
                    {
                        type = CommonInformationTypes.GetCostumeStoreChange4Scrap;
                    }
                    else if (e.ColumnIndex == profitDataGridViewTextBoxColumn.Index)
                    {
                        type = CommonInformationTypes.GetCostumeStoreChange4Profit;
                    }
                    ShowForm(type,item);
                    //this.DetailClick?.Invoke(type, item, this);
                }

            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        private void ShowForm(int type, CostumeStoreChangeInfo item)
        {
            if (type == CommonInformationTypes.GetCostumeStoreChange4In)
            {
                //采购进货明细
                CostumeStoreTrackSearchInForm form = new CostumeStoreTrackSearchInForm();


                //   this.InboundDetailClick?.Invoke(item.In, this, this.skinSplitContainer1.Panel2);
                GetCostumeStoreChangePara changePara = new GetCostumeStoreChangePara();
                ReflectionHelper.CopyProperty(pagePara, changePara);
                changePara.StartDate = JGNet.Core.Tools.TimeHelper.GetReportDate(item.Date.ToString());
                changePara.EndDate = changePara.StartDate;
                form.ShowDialog(changePara);
            }
            else
            if (type == CommonInformationTypes.GetCostumeStoreChange4Into)
            { //调拨单明细
                CostumeStoreTrackSearchIntoForm form
                     = new CostumeStoreTrackSearchIntoForm();

                GetCostumeStoreChangePara changePara = new GetCostumeStoreChangePara();
                ReflectionHelper.CopyProperty(pagePara, changePara);
                changePara.StartDate = JGNet.Core.Tools.TimeHelper.GetReportDate(item.Date.ToString());
                changePara.EndDate = changePara.StartDate;
                form.ShowDialog(changePara);
            }
            else
            if (type == CommonInformationTypes.GetCostumeStoreChange4Return)
            {
                CostumeStoreTrackSearchReturnForm form = new CostumeStoreTrackSearchReturnForm();
                GetCostumeStoreChangePara changePara = new GetCostumeStoreChangePara();
                ReflectionHelper.CopyProperty(pagePara, changePara);
                changePara.StartDate = JGNet.Core.Tools.TimeHelper.GetReportDate(item.Date.ToString());
                changePara.EndDate = changePara.StartDate;
                form.ShowDialog(changePara);
            }
            else if (type == CommonInformationTypes.GetCostumeStoreChange4TurnOut)
            {
                CostumeStoreTrackSearchTurnOutForm form
                       = new CostumeStoreTrackSearchTurnOutForm();

                GetCostumeStoreChangePara changePara = new GetCostumeStoreChangePara();
                ReflectionHelper.CopyProperty(pagePara, changePara);
                changePara.StartDate = JGNet.Core.Tools.TimeHelper.GetReportDate(item.Date.ToString());
                changePara.EndDate = changePara.StartDate;
                form.ShowDialog(changePara);
            }
            else if (type == CommonInformationTypes.GetCostumeStoreChange4Retail)
            {
                CostumeStoreTrackSearchRetailForm form
                        = new CostumeStoreTrackSearchRetailForm();

                GetCostumeStoreChangePara changePara = new GetCostumeStoreChangePara();
                ReflectionHelper.CopyProperty(pagePara, changePara);
                changePara.StartDate = JGNet.Core.Tools.TimeHelper.GetReportDate(item.Date.ToString());
                changePara.EndDate = changePara.StartDate;
                form.ShowDialog(changePara);
            }
            else
            if (type == CommonInformationTypes.GetCostumeStoreChange4Scrap)
            {
                CostumeStoreTrackSearchScrapForm form
                        = new CostumeStoreTrackSearchScrapForm();

                GetCostumeStoreChangePara changePara = new GetCostumeStoreChangePara();
                ReflectionHelper.CopyProperty(pagePara, changePara);
                changePara.StartDate = JGNet.Core.Tools.TimeHelper.GetReportDate(item.Date.ToString());
                changePara.EndDate = changePara.StartDate;
                form.ShowDialog(changePara);
            }
            else
            if (type == CommonInformationTypes.GetCostumeStoreChange4Profit)
            {
                CostumeStoreTrackSearchProfitForm form = new CostumeStoreTrackSearchProfitForm();
                GetCostumeStoreChangePara changePara = new GetCostumeStoreChangePara();
                ReflectionHelper.CopyProperty(pagePara, changePara);
                changePara.StartDate = JGNet.Core.Tools.TimeHelper.GetReportDate(item.Date.ToString());
                changePara.EndDate = changePara.StartDate;
                form.ShowDialog(changePara);
            }
        }



        #endregion

        public override void RefreshPage()
        {
            if (pagePara != null)
            {
                BaseButton_Search_Click(null, null);
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
                CommonGlobalUtil.SetCostumeColor(this.skinComboBox_Color, false, null, false);
            }
        }


        private void costumeTextBox1_CostumeSelected(Costume costume, bool isEnter)
        {
            if (isEnter && costume != null)
            {
                FilterColor(costume);
                CommonGlobalUtil.SetCostumeSize(this.skinComboBox_Size, costume, null, true);
                BaseButton_Search_Click(null, null);
            }
        }

        private void CostumeStoreTrackSearchCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void skinComboBox_DestShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.shopID = ValidateUtil.CheckEmptyValue(skinComboBox_DestShop.SelectedValue);
            //SetChangeType();
        }

        List<ListItem<String>> sizes = null;
        private void skinComboBox_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            sizes = skinComboBox_Size.DataSource as List<ListItem<String>>;
            skinComboBox_Size.DataSource = null;
            skinComboBox_Size.DataSource = sizes;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        }

        private void skinComboBox_Color_DropDown(object sender, EventArgs e)
        {
           // 730 库存变化查询页面：颜色、尺码根据是否有输入款号来显示选择项。
            if (!String.IsNullOrEmpty(this.costumeTextBox1.Text))
            {
                Costume costume = CommonGlobalCache.GetCostume(this.costumeTextBox1.Text);
                FilterColor(costume);
            }
            else {
                FilterColor(null);
            }
           
        }

        private void skinComboBox_Size_DropDown(object sender, EventArgs e)
        {
            // 730 库存变化查询页面：颜色、尺码根据是否有输入款号来显示选择项。
            SizeGroup sizeGroup = CommonGlobalCache.DefaultSizeGroup;
            if (!String.IsNullOrEmpty(this.costumeTextBox1.Text))
            {
                Costume costume = CommonGlobalCache.GetCostume(this.costumeTextBox1.Text);
                sizeGroup = CommonGlobalCache.GetSizeGroup(costume?.SizeGroupName);
                CommonGlobalUtil.SetCostumeSize(this.skinComboBox_Size, costume, sizeGroup, true);
            }
            else
            {
                CommonGlobalUtil.SetCostumeSize(this.skinComboBox_Size,null, sizeGroup, true, false);
            }
        }
    }
}

