using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Core;
using CCWin;
using System.Reflection;
using JGNet.Common.Core;
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Common.Core.Util;
using CCWin.SkinControl;
using CJBasic.Helpers;
using JGNet.Core.Const;
using JGNet.Core.InteractEntity;

namespace JGNet.Common
{
    public partial class NewConfusedStoreAdjustRecordCtrl : BaseModifyUserControl
    {
        private CostumeItem currentSelectedItem;
        private string userID;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl1;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl2;
        public NewConfusedStoreAdjustRecordCtrl()
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl1 = new DataGridViewPagingSumCtrl(dataGridView1) { ShowRowCounts = false, AutoIndexMode = DataGridViewAutoIndexMode.None };
            dataGridViewPagingSumCtrl1.Initialize();
            dataGridViewPagingSumCtrl2 = new DataGridViewPagingSumCtrl(dataGridView2) { ShowRowCounts = false, AutoIndexMode = DataGridViewAutoIndexMode.None };
            dataGridViewPagingSumCtrl2.Initialize();

            skinLabel_CostumeName.Text = string.Empty;
            userID = CommonGlobalCache.CurrentUserID;
            IsShowOnePage = true;
            MenuPermission = RolePermissionMenuEnum.串码调整;
        }


        private void BaseButtonAdd_Click(object sender, EventArgs e)
        {
            try
            { 
                if (GlobalMessageBox.Show("是否确认操作？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;

                }
                if (CommonGlobalUtil.EngineUnconnectioned(this)) {
                    return;
                }
                string id = IDHelper.GetID(OrderPrefix.ConfusedStoreAdjustRecord, shop.AutoCode);
                
                ConfusedStoreAdjustRecord para = new ConfusedStoreAdjustRecord()
                {
                    OrderID = id,
                    CostumeID = currentSelectedItem?.Costume?.ID,
                    ColorName1 = ValidateUtil.CheckEmptyValue(skinComboBox_Color.SelectedValue),
                    ColorName2 = ValidateUtil.CheckEmptyValue(skinComboBox_Color1.SelectedValue),
                    SizeName1 = CostumeStoreHelper.GetCostumeSize(ValidateUtil.CheckEmptyValue(skinComboBox_Size.SelectedValue), CommonGlobalCache.DefaultSizeGroup),
                    SizeName2 = CostumeStoreHelper.GetCostumeSize(ValidateUtil.CheckEmptyValue(skinComboBox_Size1.SelectedValue), CommonGlobalCache.DefaultSizeGroup),
                    Remarks = skinTextBox_Remark.Text,
                    CountPre1 = skinLabelStore,
                    CountPre2 = skinLabelStore1,
                    CountNow1 = skinLabelStore - int.Parse(skinTextBox_MoneyCash.Text),
                    CountNow2 = skinLabelStore1 + int.Parse(skinTextBox_MoneyCash1.Text),
                    ShopID = ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue),
                    OperatorUserID = userID,
                };

                if (String.IsNullOrEmpty(para.CostumeID)) {
                    GlobalMessageBox.Show("请选择款号！");
                    return;
                }
                if (para.ColorName1 == para.ColorName2 && para.SizeName1 == para.SizeName2)
                {
                    GlobalMessageBox.Show("请选择不同颜色或者尺码！");
                    return;
                }
                if (para.CountPre1 == 0)
                {
                    GlobalMessageBox.Show("库存为0，不能向下调整！");
                    return;
                }
                InteractResult result = CommonGlobalCache.ServerProxy.AddConfusedStoreAdjustRecord(para);
                switch (result.ExeResult)
                {
                    case ExeResult.Success:
                        GlobalMessageBox.Show("调整成功！");
                        //重新获取该款库存信息
                        this.skinTextBox_costumeID.Reload();
                        //this.TabPageClose(CurrentTabPage, SourceCtrlType);
                        break;
                    case ExeResult.Error:
                        GlobalMessageBox.Show("内部错误！");
                        break;
                    default:
                        break;
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



        private void NewConfusedStoreAdjustRecordCtrl_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
           this.skinComboBoxShopID.Initialize(true);
            skinComboBoxShopID.SelectedValue = CommonGlobalCache.CurrentShopID;
            CommonGlobalUtil.SetCostumeSize(this.skinComboBox_Size, null,CommonGlobalCache.DefaultSizeGroup);
            CommonGlobalUtil.SetCostumeSize(this.skinComboBox_Size1, null, CommonGlobalCache.DefaultSizeGroup);
        }




        private void SetCostumeDetails(CostumeItem costumeItem)
        {
         
            if (costumeItem == null)
            {
                return;
            }
            this.currentSelectedItem = costumeItem;
            this.skinLabel_CostumeName.Text = costumeItem.Costume.Name; 

            // String[] colors = costumeItem.Costume.Colors.Split(',');
            //没有库存信息的直接去掉可选颜色。
            //   this.skinComboBox_Color.DataSource = colors;

            if (currentSelectedItem.Costume != null && currentSelectedItem.Costume.ColorList.Count > 0)
            {
                List<String> colors = new List<string>();
                foreach (var item in currentSelectedItem.Costume.ColorList)
                {
                    colors.Add(item);
                }
                this.skinComboBox_Color.DataSource = colors.ToArray();
                this.skinComboBox_Color.SelectedItem = currentSelectedItem.Costume.ColorList[0];
            }

            //   this.skinComboBox_Color.SelectedIndex = 0;
           // skinComboBox_Color_SelectedIndexChanged(null,null);
           // this.skinComboBox_Color1.DataSource = costumeItem.Costume.Colors.Split(',');
            // this.skinComboBox_Color1.SelectedIndex = 0;
            if (currentSelectedItem.Costume != null && currentSelectedItem.Costume.ColorList.Count > 0)
            {
                List<String> colors = new List<string>();
                foreach (var item in currentSelectedItem.Costume.ColorList)
                {
                    colors.Add(item);
                }
                this.skinComboBox_Color1.DataSource = colors.ToArray();
                this.skinComboBox_Color1.SelectedItem = currentSelectedItem.Costume.ColorList[0];
            }
            //skinComboBox_Color1_SelectedIndexChanged(null, null);
            this.skinTextBox_MoneyCash.Value = 1;
            this.skinTextBox_MoneyCash1.Value = 1;


            //  SetStoreCountText();
            

            ///放到最后才更新datagridview
        //    dataGridViewPagingSumCtrl1.ChangeSizeGroup(CommonGlobalCache.GetSizeGroup(costumeItem.Costume.SizeGroupName));
          //  dataGridViewPagingSumCtrl2.ChangeSizeGroup(CommonGlobalCache.GetSizeGroup(costumeItem.Costume.SizeGroupName));
            //CommonGlobalUtil.ChangeSizeGroup(dataGridView1, CommonGlobalCache.GetSizeGroup(costumeItem.Costume.SizeGroupName));
            // CommonGlobalUtil.ChangeSizeGroup(dataGridView2, CommonGlobalCache.GetSizeGroup(costumeItem.Costume.SizeGroupName));

            //还原所有颜色
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                SetNormalCellStyle(item);
            }
            //还原所有颜色
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                SetNormalCellStyle(item);
            }
            
        }
         

        int skinLabelStore = 0;
        int skinLabelStore1 = 0;
        private void CheckStore(int i)
        {
            if (i == 0)
            {
                String color = ValidateUtil.CheckEmptyValue(skinComboBox_Color.SelectedValue);
                String size = ValidateUtil.CheckEmptyValue(skinComboBox_Size.SelectedValue);
                this.skinLabelStore = GetStore(color, size);
            }
            else
            {
                String color = ValidateUtil.CheckEmptyValue(skinComboBox_Color1.SelectedValue);
                String size = ValidateUtil.CheckEmptyValue(skinComboBox_Size1.SelectedValue);
                this.skinLabelStore1 = GetStore(color, size);
            }
        }

        private int GetStore(string color, string size)
        {
            CostumeStore store = this.currentSelectedItem?.CostumeStoreList?.Find(t => t.ColorName == color);
            return CostumeStoreHelper.GetStoreCountBySize(store, CostumeStoreHelper.GetCostumeSize(size, CommonGlobalCache.DefaultSizeGroup));
        } 

        private void skinTextBox_MoneyCash1_ValueChanged(object obj)
        {
            skinTextBox_MoneyCash.Value = skinTextBox_MoneyCash1.Value;
          //  UpdateNewStore();
        }

        private void SetAlertCellStyle(DataGridViewCell cell)
        {
            cell.Style.ForeColor = Color.Red;
            cell.Style.Font = new Font(
            dataGridView2.DefaultCellStyle.Font, FontStyle.Bold);
        }

        private void SetNormalCellStyle(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {

                cell.Style.ForeColor = Color.Black;
                cell.Style.Font = new Font(
                dataGridView2.DefaultCellStyle.Font, FontStyle.Regular);
            }
        }

        private void UpdateNewStore()
        {
            //还原所有颜色
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                SetNormalCellStyle(item);
            }

            //如果是同颜色同尺码，则不变
            bool isTheSame= skinComboBox_Color.SelectedValue.ToString().Equals( skinComboBox_Color1.SelectedValue.ToString()) && skinComboBox_Size.SelectedValue.ToString().Equals(skinComboBox_Size1.SelectedValue.ToString());
            //CommonGlobalUtil.Debug("isTheSame" + isTheSame);
            if (isTheSame)
            {
                return;
            }
            //获取下调信息
            CostumeStore orgStore = orgStores.Find(t => t.ColorName == ValidateUtil.CheckEmptyValue(skinComboBox_Color.SelectedValue));
            CostumeStore store = newStores.Find(t => t.ColorName == ValidateUtil.CheckEmptyValue(skinComboBox_Color.SelectedValue));
            DataGridViewColumn col = null;
            switch (CostumeStoreHelper.GetCostumeSize(skinComboBox_Size.SelectedValue.ToString(), CommonGlobalCache.DefaultSizeGroup))
            {
                case CostumeSize.XS:
                    col = xSDataGridViewTextBoxColumn;
                    break;
                case CostumeSize.S:
                    col = sDataGridViewTextBoxColumn;
                    break;
                case CostumeSize.M:
                    col = mDataGridViewTextBoxColumn;
                    break;
                case CostumeSize.L:
                    col = lDataGridViewTextBoxColumn;
                    break;
                case CostumeSize.XL:
                    col = xLDataGridViewTextBoxColumn;
                    break;
                case CostumeSize.XL2:
                    col = xL2DataGridViewTextBoxColumn;
                    break;
                case CostumeSize.XL3:
                    col = xL3DataGridViewTextBoxColumn;
                    break;
                case CostumeSize.XL4:
                    col = xL4DataGridViewTextBoxColumn;
                    break;
                case CostumeSize.XL5:
                    col = xL5DataGridViewTextBoxColumn;
                    break;
                case CostumeSize.XL6:
                    col = xL6DataGridViewTextBoxColumn;
                    break;
                case CostumeSize.F:
                    col = fDataGridViewTextBoxColumn;
                    break;
                default:
                    break;
            }
            //直接改界面值
            DataGridViewColumn col2 = null;
            switch (CostumeStoreHelper.GetCostumeSize( skinComboBox_Size1.SelectedValue.ToString(), CommonGlobalCache.DefaultSizeGroup))
            {
                case CostumeSize.XS:
                    col2 = xSDataGridViewTextBoxColumn2;
                    break;
                case CostumeSize.S:
                    col2 = sDataGridViewTextBoxColumn2;
                    break;
                case CostumeSize.M:
                    col2 = mDataGridViewTextBoxColumn2;
                    break;
                case CostumeSize.L:
                    col2 = lDataGridViewTextBoxColumn2;
                    break;
                case CostumeSize.XL:
                    col2 = xLDataGridViewTextBoxColumn2;
                    break;
                case CostumeSize.XL2:
                    col2 = xL2DataGridViewTextBoxColumn2;
                    break;
                case CostumeSize.XL3:
                    col2 = xL3DataGridViewTextBoxColumn2;
                    break;
                case CostumeSize.XL4:
                    col2 = xL4DataGridViewTextBoxColumn2;
                    break;
                case CostumeSize.XL5:
                    col2 = xL5DataGridViewTextBoxColumn2;
                    break;
                case CostumeSize.XL6:
                    col2 = xL6DataGridViewTextBoxColumn2;
                    break;
                case CostumeSize.F:
                    col2 = fDataGridViewTextBoxColumn2;
                    break;
                default:
                    break;
            }
            //one row
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
             //   CommonGlobalUtil.Debug(""+dataGridView1.Rows.Count);
                DataGridViewRow orgRow = dataGridView1.Rows[i];
                DataGridViewRow row = dataGridView2.Rows[i];
                CostumeStore newStore = (CostumeStore)row.DataBoundItem;
               // CommonGlobalUtil.Debug("skinComboBox_Color.SelectedValue" + skinComboBox_Color.SelectedValue);
                if (newStore.ColorName != ValidateUtil.CheckEmptyValue(skinComboBox_Color.SelectedValue))
                {
                    continue;
                }

             //   CommonGlobalUtil.Debug("col.Index:" + col.Index);
                row.Cells[col.Index].Value = (int.Parse(orgRow.Cells[col.Index].Value.ToString()) - int.Parse(skinTextBox_MoneyCash.Text)).ToString();
                SetAlertCellStyle(row.Cells[col.Index]);
            }


            //value  必须是通string类型

            //获取上调信息

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow orgRow = dataGridView1.Rows[i];
                DataGridViewRow row = dataGridView2.Rows[i];
                CostumeStore newStore = (CostumeStore)row.DataBoundItem;
             //   CommonGlobalUtil.Debug("skinComboBox_Color1.SelectedValue" + skinComboBox_Color1.SelectedValue);
                if (newStore.ColorName != ValidateUtil.CheckEmptyValue(skinComboBox_Color1.SelectedValue))
                {
                    continue;
                }
             //   CommonGlobalUtil.Debug("col.Index1:" + col2.Index);
                row.Cells[col2.Index].Value = (int.Parse(orgRow.Cells[col2.Index].Value.ToString()) + int.Parse(skinTextBox_MoneyCash1.Text)).ToString();
                    SetAlertCellStyle(row.Cells[col2.Index]);
                }
        }

    

        Shop shop;
        private void skinComboBoxShopID_SelectedIndexChanged(object sender, EventArgs e)
        {
            skinTextBox_costumeID.ShopID = ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue);
            shop = (Shop)skinComboBoxShopID.SelectedItem;
        }

        private void skinTextBox_costumeID_CostumeSelected(CostumeItem costumeItem, bool isEnter)
        {
            if (isEnter)
            {
                SetCostume(costumeItem);
            }
        }

        private void SetCostume(CostumeItem costumeItem)
        {
            orgStores = null;
            newStores = null;
            this.CostumeItem = costumeItem;
            this.SetCostumeDetails(costumeItem);
        }

        private CostumeItem CostumeItem { get; set; }
        private void skinComboBox_Color1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataView();

            CommonGlobalUtil.SetCostumeSize(this.skinComboBox_Size1, CostumeItem?.Costume);
            //SetSize(skinComboBox_Size1, skinComboBox_Color1);
            skinComboBox_Size1_SelectedIndexChanged(null, null);
            // CheckStore(1);
        }




        private void skinComboBox_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataView();
            CommonGlobalUtil.SetCostumeSize(this.skinComboBox_Size, CostumeItem?.Costume);
            //SetSize(skinComboBox_Size, skinComboBox_Color);
            skinComboBox_Size_SelectedIndexChanged(null, null);

            // CheckStore(0);
        }

        List<CostumeStore> orgStores = new List<CostumeStore>();
        List<CostumeStore> newStores = new List<CostumeStore>();

        /// <summary>
        /// 下调变？有数据？添加一条，没有数据
        /// </summary>
        /// <param name="skinComboBoxColor"></param>
        private void SetDataView()
        {
            if (currentSelectedItem != null)
            {
                String color = ValidateUtil.CheckEmptyValue(skinComboBox_Color.SelectedValue);
                String color1 = ValidateUtil.CheckEmptyValue(skinComboBox_Color1.SelectedValue);

                if (!(String.IsNullOrEmpty(color) || String.IsNullOrEmpty(color1)))
                {

                    CostumeStore store = currentSelectedItem?.CostumeStoreList?.Find(t => t.ColorName == color);
                     
                    CostumeStore newStore = new CostumeStore();
                    if (store != null)
                    {
                        ReflectionHelper.CopyProperty(store, newStore);
                    }
                          else
                          {
                        store = new CostumeStore();
                        store.ColorName = color;
                        store.CostumeColorName = color;
                              //newStore.CostumeID = currentSelectedItem.Costume.ID;
                              // newStore.ShopID= skinComboBoxShopID
                        newStore.CostumeColorName = color;
                              newStore.ColorName = color;
                          }
                        CostumeStore store1 = currentSelectedItem?.CostumeStoreList?.Find(t => t.ColorName == color1);
                   
                    CostumeStore newStore1 = new CostumeStore();
                    if (store1 != null)
                    {
                        ReflectionHelper.CopyProperty(store1, newStore1);
                    }
                    else
                    {
                        store1 = new CostumeStore();
                        store1.CostumeColorName = color1;
                        store1.ColorName = color1;
                        newStore1.CostumeColorName = color1;
                        newStore1.ColorName = color1;
                         

                    }
                      if (orgStores == null || orgStores.Count == 0)
                    {
                        //first time默认颜色相同，只显示一条
                        orgStores = new List<CostumeStore>();

                        newStores = new List<CostumeStore>();

                    }

                    orgStores.Clear();
                    newStores.Clear();
                   
                    orgStores.Add(store);
                    newStores.Add(newStore);
                    
                    if (store1 != store)
                    {
                        orgStores.Add(store1);
                        newStores.Add(newStore1);
                    }
                    // this.dataGridView1.DataSource = null;
                    dataGridViewPagingSumCtrl1.BindingDataSource(DataGridViewUtil.ListToBindingList(orgStores));
                    dataGridView1.Rows[0].HeaderCell.Value = "调整前";
                    dataGridViewPagingSumCtrl2.BindingDataSource(DataGridViewUtil.ListToBindingList(newStores));
                    dataGridView2.Rows[0].HeaderCell.Value = "调整后";
                }
            }
        }

        private void skinComboBox_Size1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckStore(1);
           // SetDataView();
        }



        private void skinComboBox_Size_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckStore(0);
          //  SetDataView(); 
        }

      
         

        private void baseButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(skinTextBox_costumeID.Text))
            {
                GlobalMessageBox.Show("请输入款号！");
                return;
            }
            UpdateNewStore();

        }

        private void skinTextBox_MoneyCash_ValueChanged(object sender, EventArgs e)
        {
            skinTextBox_MoneyCash1.Value = skinTextBox_MoneyCash.Value;
        }

        private void skinTextBox_MoneyCash1_ValueChanged(object sender, EventArgs e)
        {
            skinTextBox_MoneyCash.Value = skinTextBox_MoneyCash1.Value;
        }
    }
}
