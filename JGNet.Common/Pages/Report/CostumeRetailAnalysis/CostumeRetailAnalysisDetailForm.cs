
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Common.Core;
using JGNet.Common.Core.Util;
using JGNet.Core.Dev.MyEnum;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using CJBasic;
using CJBasic.Loggers;
using JieXi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;
using static CCWin.SkinControl.SkinChatRichTextBox;

namespace JGNet.Common
{
    public partial class CostumeRetailAnalysisDetailForm : BaseForm
    {

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public CostumeRetailAnalysisDetailForm()
        {
            MenuPermission = RolePermissionMenuEnum.销售分析;
            InitializeComponent();
            dataGridView_RetailDetail.AutoGenerateColumns = false;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(
                this.dataGridView_RetailDetail, new string[] {
            SalesCount.DataPropertyName,
            SalesMoney.DataPropertyName,
            ColumnsF.DataPropertyName,
            ColumnsXS.DataPropertyName,
            ColumnsS.DataPropertyName,
            ColumnsM.DataPropertyName,
            ColumnsL.DataPropertyName,
            ColumnsXL.DataPropertyName,
            ColumnsXL2.DataPropertyName,
            ColumnsXL3.DataPropertyName,
            ColumnsXL4.DataPropertyName,
            ColumnsXL5.DataPropertyName,
            ColumnsXL6.DataPropertyName,


                   // ColumnS.DataPropertyName,
                   //ColumnF.DataPropertyName,
                /*   DataGridViewTextBoxColumnXS.DataPropertyName,
                   DataGridViewTextBoxColumnF.DataPropertyName,
                   DataGridViewTextBoxColumnS.DataPropertyName,
                   DataGridViewTextBoxColumnM.DataPropertyName,*/

    }) ;

            this.dataGridViewPagingSumCtrl.ShowColumnSetting = false;
            //  dataGridViewPagingSumCtrl.ShowZeroFormatting = true;
            // dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(XS, S, M, L, XL, XL2, XL3, XL4, XL5, XL6, F);
            dataGridViewPagingSumCtrl.Initialize();
          
        }

        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        GetSalesAnalysisDeatilInfoPara para;
        internal void ShowDialog(SalesAnalysis salesAnalysis, DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End,int brandId,string SupplierId,int ClassId, BaseUserControl CurCtrl)
        {
            this.Show(CurCtrl);
            para = new GetSalesAnalysisDeatilInfoPara()
            {
                ShopID = salesAnalysis.ShopID,
                Type = salesAnalysis.Type,
                BrandID=brandId,
                SupplierID=SupplierId,
                ClassID=ClassId,
                ParaValue1 = salesAnalysis.TypeValue1,
                ParaValue2 = salesAnalysis.TypeValue2,
                ParaValue3 = salesAnalysis.TypeValue3,
                ParaValue4 = salesAnalysis.TypeValue4,
                ParaValue5 = salesAnalysis.TypeValue5,
                ParaValue6 = salesAnalysis.TypeValue6,
                ParaValue7 = salesAnalysis.TypeValue7,
                ParaValue8 = salesAnalysis.TypeValue8,
                StartDate = new CJBasic.Date(dateTimePicker_Start.Value),
                EndDate = new CJBasic.Date(dateTimePicker_End.Value),
                CostumeID = salesAnalysis.CostumeID,
                IsChooseSize= skinCheckBoxCostumeSize.Checked,
                IsChooseColor=skinCheckBoxColor.Checked
            };
             

            //if (salesAnalysis.ShopID != null)
            //{
            //    skinLabelShopName.Text = CommonGlobalCache.GetShopName(salesAnalysis.ShopID);
            //}
            //else
            //{
            //    skinLabelShopName.Text = "";
            //}
             
            String startDate = dateTimePicker_Start.Value.GetDateTimeFormats('D')[0].ToString();
            String endDate = dateTimePicker_End.Value.GetDateTimeFormats('D')[0].ToString();
            if (startDate.Equals(endDate))
            {
                skinLabelTime.Text = startDate;
            }
            else
            {
                skinLabelTime.Text = startDate + " 至 " + endDate;
            }
            Search();
           // this.ShowDialog(CurCtrl); 
        }
        internal void ShowDialog(SalesAnalysis salesAnalysis, DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End, GetSalesAnalysisPara curPara, BaseUserControl CurCtrl)
        {
           // this.Show(CurCtrl);
            para = new GetSalesAnalysisDeatilInfoPara()
            {
                ShopID = salesAnalysis.ShopID,
                Type = salesAnalysis.Type,
                BrandID = curPara.BrandID,
                SupplierID = curPara.SupplierID,
                ClassID = curPara.ClassID,
                ParaValue1 = salesAnalysis.TypeValue1,
                ParaValue2 = salesAnalysis.TypeValue2,
                ParaValue3 = salesAnalysis.TypeValue3,
                ParaValue4 = salesAnalysis.TypeValue4,
                ParaValue5 = salesAnalysis.TypeValue5,
                ParaValue6 = salesAnalysis.TypeValue6,
                ParaValue7 = salesAnalysis.TypeValue7,
                ParaValue8 = salesAnalysis.TypeValue8,
                StartDate = new CJBasic.Date(dateTimePicker_Start.Value),
                EndDate = new CJBasic.Date(dateTimePicker_End.Value),
                CostumeID = salesAnalysis.CostumeID,
                IsChooseSize = skinCheckBoxCostumeSize.Checked,
                IsChooseColor = skinCheckBoxColor.Checked
            }; 
            String startDate = dateTimePicker_Start.Value.GetDateTimeFormats('D')[0].ToString();
            String endDate = dateTimePicker_End.Value.GetDateTimeFormats('D')[0].ToString();
            if (startDate.Equals(endDate))
            {
                skinLabelTime.Text = startDate;
            }
            else
            {
                skinLabelTime.Text = startDate + " 至 " + endDate;
            }
           
             Search();
            this.ShowDialog(CurCtrl); 
           
        }
        public void getData() {
            CommonGlobalCache.ServerProxy.GetSalesAnalysisDeatilInfo(para);
            this.ShowDialog();
        }

        private void Search()
        {
          //  CommonGlobalCache.ServerProxy.GetAllAdminUser();
             try
            {
               if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
              
             
               InteractResult<SalesAnalysisDeatilInfo> saleResult = CommonGlobalCache.ServerProxy.GetSalesAnalysisDeatilInfo(para);
                skinLabelShopName.Text = saleResult.Data.ShopName;
               List<DataGridViewColumn> Displaycolumlist = new List<DataGridViewColumn>();
                List<DataGridViewColumn> NoDisplaycolumlist = new List<DataGridViewColumn>();

                   //if (para.IsChooseSize)
                   //{
                   //    dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(
                   // ColumnsS, ColumnsF, ColumnsXS, ColumnsM, ColumnsL, ColumnsXL, ColumnsXL2, ColumnsXL3, ColumnsXL4, ColumnsXL5, ColumnsXL6
                   //        );
                   //}
                   //else
                   //{
                   //  dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings( 
                   // ColumnsS, ColumnsF,ColumnsXS, ColumnsM, ColumnsL, ColumnsXL, ColumnsXL2, ColumnsXL3, ColumnsXL4, ColumnsXL5, ColumnsXL6
                   //        );

                   //}

                 if (para.IsChooseSize)
                {
                    Displaycolumlist.Add(ColumnsS);
                    Displaycolumlist.Add(ColumnsF);
                    Displaycolumlist.Add(ColumnsXS);
                    Displaycolumlist.Add(ColumnsM);
                    Displaycolumlist.Add(ColumnsL);
                    Displaycolumlist.Add(ColumnsXL);
                    Displaycolumlist.Add(ColumnsXL2);
                    Displaycolumlist.Add(ColumnsXL3);
                    Displaycolumlist.Add(ColumnsXL4);
                    Displaycolumlist.Add(ColumnsXL5);
                    Displaycolumlist.Add(ColumnsXL6);
                       
                }
                else
                {
                    NoDisplaycolumlist.Add(ColumnsS);
                    NoDisplaycolumlist.Add(ColumnsF);
                    NoDisplaycolumlist.Add(ColumnsXS);
                    NoDisplaycolumlist.Add(ColumnsM);
                    NoDisplaycolumlist.Add(ColumnsL);
                    NoDisplaycolumlist.Add(ColumnsXL);
                    NoDisplaycolumlist.Add(ColumnsXL2);
                    NoDisplaycolumlist.Add(ColumnsXL3);
                    NoDisplaycolumlist.Add(ColumnsXL4);
                    NoDisplaycolumlist.Add(ColumnsXL5);
                    NoDisplaycolumlist.Add(ColumnsXL6); 
                }


                if (para.IsChooseColor)
                {
                    Displaycolumlist.Add(ColorName);
                }
                else
                {
                    NoDisplaycolumlist.Add(ColorName);
                }

                if (Displaycolumlist.Count > 0)
                {
                    dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(Displaycolumlist.ToArray());
                }
                if (NoDisplaycolumlist.Count > 0)
                {
                    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(NoDisplaycolumlist.ToArray());

                }
              BindingDataSources(saleResult.Data);
        }
            catch (Exception ex) { CommonGlobalUtil.ShowError(ex); }
            finally
            {
                UnLockPage();
}
        }

        private void BindingDataSources(SalesAnalysisDeatilInfo listPage)
        {

            dataGridViewPagingSumCtrl.BindingDataSource(listPage.SalesAnalysisDeatils);
            dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(
                           DataGridViewTextBoxColumnF, DataGridViewTextBoxColumnXS, DataGridViewTextBoxColumnS,
                           DataGridViewTextBoxColumnM, DataGridViewTextBoxColumnL, DataGridViewTextBoxColumnXL, DataGridViewTextBoxColumnXL2, DataGridViewTextBoxColumnXL3,
                           DataGridViewTextBoxColumnXL4, DataGridViewTextBoxColumnXL5, DataGridViewTextBoxColumnXL6);

        }

        private void baseButtonExport_Click(object sender, EventArgs e)
        {
            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "销售分析_"  + skinLabelShopName.Text +"_"+ skinLabelTime.Text + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
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
                List<SalesAnalysisDeatil> list = dataGridView_RetailDetail.DataSource as List<SalesAnalysisDeatil>;
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                foreach (DataGridViewColumn item in dataGridView_RetailDetail.Columns)
                {
                    if (item.Visible)
                    {
                        keys.Add(item.DataPropertyName);
                        values.Add(item.HeaderText);
                    }
                }

                NPOIHelper.Keys = keys.ToArray();
                NPOIHelper.Values = values.ToArray();//new System.Collections.SortedList();
                NPOIHelper.ExportExcel(DataGridViewUtil.ToDataTable(list), path);
                ShowMessage("导出完毕！");
            }
            catch (Exception ex)
            { ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }



        private void skinCheckBoxColor_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSearch();
        }

        private void CheckBoxSearch()
        {
            para.IsChooseSize = this.skinCheckBoxCostumeSize.Checked;
            para.IsChooseColor = this.skinCheckBoxColor.Checked;

            List<DataGridViewColumn> Displaycolumlist = new List<DataGridViewColumn>();
            List<DataGridViewColumn> NoDisplaycolumlist = new List<DataGridViewColumn>();
           // dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(XS, S, M, L, XL, XL2, XL3, XL4, XL5, XL6, F,ColorName);
          //  dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(XS, S, M, L, XL, XL2, XL3, XL4, XL5, XL6, F, ColorName);
            /*  if (para.IsChooseSize)
             {
                 Displaycolumlist.Add(XS);
                 Displaycolumlist.Add(S);
                 Displaycolumlist.Add(M);
                 Displaycolumlist.Add(L);
                 Displaycolumlist.Add(XL);
                 Displaycolumlist.Add(XL2);
                 Displaycolumlist.Add(XL3);
                 Displaycolumlist.Add(XL4);
                 Displaycolumlist.Add(XL5);
                 Displaycolumlist.Add(XL6);
                 Displaycolumlist.Add(F);
                 // dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(XS, S, M, L, XL, XL2, XL3, XL4, XL5, XL6, F);
             }
             else
             {
                 NoDisplaycolumlist.Add(XS);
                 NoDisplaycolumlist.Add(S);
                 NoDisplaycolumlist.Add(M);
                 NoDisplaycolumlist.Add(L);
                 NoDisplaycolumlist.Add(XL);
                 NoDisplaycolumlist.Add(XL2);
                 NoDisplaycolumlist.Add(XL3);
                 NoDisplaycolumlist.Add(XL4);
                 NoDisplaycolumlist.Add(XL5);
                 NoDisplaycolumlist.Add(XL6);
                 NoDisplaycolumlist.Add(F);
                 //dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(XS, S, M, L, XL, XL2, XL3, XL4, XL5, XL6, F);
             }
             if (para.IsChooseColor)
             {
                 Displaycolumlist.Add(ColorName);
                 // dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(ColorName);
             }
             else
             {
                 NoDisplaycolumlist.Add(ColorName);
                 // dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(ColorName);
             }

             if (Displaycolumlist.Count > 0)
             {
                 dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(Displaycolumlist.ToArray());
             }
             if (NoDisplaycolumlist.Count > 0)
             {
                 dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(NoDisplaycolumlist.ToArray());

             }*/
            Search();
        }

        private void skinCheckBoxCostumeSize_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSearch();
        }
         
    }
}
