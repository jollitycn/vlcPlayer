
using JGNet.Common.Components;
using JGNet.Core;
using JGNet.Core.Tools;
using CJBasic.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class CostumeForm : BaseForm
    {
         
        public Costume Result { get; set; }
        private List<Costume> currentCostumes;
        private List<Costume> currentSource=new List<Costume>();
   //     public event CJBasic.Action<Costume, EventArgs> CostumeSelected;

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private bool filterValid { get; set; }
        public CostumeForm(List<Costume> items,string costumeID,bool filterValid)
        {
            InitializeComponent();
            this.filterValid = filterValid;
            this.skinTextBox1.SkinTxt.KeyDown += skinTextBox1_KeyDown;
            this.skinTextBox1.SkinTxt.Text = costumeID;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this. dataGridView1);
            dataGridViewPagingSumCtrl.Initialize();


            //if (HasPermission(Core.RolePermissionEnum.查看_品牌) ) {
            //    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(BrandName);
            //}


            this.SetDataSource(items);
        }

        private void skinTextBox1_KeyDown(object sender, KeyEventArgs e)
        { 
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        BaseButton1_Click(null, null);
                        break;
                    case Keys.Up:
                    case Keys.Down:
                        this.dataGridView1.Focus();
                        break;
 
            }
        }

        private void SetDataSource(List<Costume> items)
        {
            this.currentCostumes = items;
            this.currentSource.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                items[i].BrandName = CommonGlobalCache.GetBrandName(items[i].BrandID);
                items[i].SupplierName = CommonGlobalCache.GetSupplierName(items[i].SupplierID);
                this.currentSource.Add(items[i]);
            }
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.currentSource;
            this.dataGridView1.Refresh();
        }

        private void BaseButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string costumeID = this.skinTextBox1.SkinTxt.Text.Trim();
                if (string.IsNullOrEmpty(costumeID))
                {
                    return;
                }
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                //条形码，先根据条形码获取款号
                //List<BarCode> barCodes = CommonGlobalCache.BarCodeList?.FindAll(t => t.BarCodeValue.ToUpper().Equals(costumeID.ToUpper()));

                ////，条形码为一条，找到这个款号
                //if (barCodes != null && barCodes.Count == 1)
                //{
                //    costumeID = barCodes[0].CostumeID;
                //    this.skinTextBox1.SkinTxt.Text = barCodes[0].BarCodeValue;

                //}
                if (costumeID.Length == 15)
                {
                    BarCode4Costume costume = CommonGlobalUtil.GetBarCode(costumeID);
                    if (costume != null)
                    {
                        costumeID = costume.CostumeID;
                        skinTextBox1.SkinTxt.Text = costume.BarCode;
                        //   isBarCode = true;
                    }
                }
                List<Costume> resultList = CommonGlobalCache.CostumeList.FindAll(t => t.ID.ToUpper().Contains(costumeID.ToUpper()) );
                if (filterValid)
                {
                    resultList = resultList.FindAll(t => t.IsValid);
                }
                this.SetDataSource(resultList);
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

        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                if (this.dataGridView1.Rows.Count > 0)
                {
                    int index = this.dataGridView1.SelectedCells[0].RowIndex;
                    this.ConfirmSelectCell(this.currentCostumes[index]);
                }
            }
            catch (Exception ee)
            {

                ShowError(ee);
            }
            finally {
               UnLockPage();
            }

        }

        private void ConfirmSelectCell(Costume item)
        {
            //if (this.CostumeSelected!=null)
            //{
            //    this.CostumeSelected(item,null);
            //}
            Result = item;
            this.DialogResult = DialogResult.OK;
        }
        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.ColumnIndex < 0)
        //    {
        //        return;
        //    }
        //    this.ConfirmSelectCell(this.currentCostumes[e.RowIndex]);
        //}

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmSelectCell((Costume)dataGridView1.CurrentRow.DataBoundItem);
            }
            else {
                //this.skinTextBox1.Focus();
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // BaseButton_OK_Click(null,null);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            this.ConfirmSelectCell(this.currentCostumes[e.RowIndex]);
            
        }
    }
}
