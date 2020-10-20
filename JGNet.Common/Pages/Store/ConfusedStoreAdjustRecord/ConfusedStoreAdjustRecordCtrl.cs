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
using JGNet.Common.Core;  
using JGNet.Common.Components;
using JGNet.Core.InteractEntity;
using JGNet.Common.Core.Util;

namespace JGNet.Common
{
    public partial class ConfusedStoreAdjustRecordCtrl : BaseUserControl
    {


        private GetConfusedStoreAdjustRecordPagePara pagePara;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        public event System.Action< BaseUserControl> AddClick; 


        public ConfusedStoreAdjustRecordCtrl()
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, this.BaseButton_Search_Click);
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 Remarks });
            dataGridViewPagingSumCtrl.Initialize();
           this.skinComboBoxShopID.Initialize();
            MenuPermission = RolePermissionMenuEnum.串码调整查询;
        }
         

        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (this.pagePara == null)
                {
                    return;
                }
                this.pagePara.PageIndex = index;
                ConfusedStoreAdjustRecordPage listPage = CommonGlobalCache.ServerProxy.GetConfusedStoreAdjustRecordPage(this.pagePara);
                this.BindingConfusedStoreAdjustRecordDateSource(listPage);
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }
        }

        public override void RefreshPage()
        {
            //  BaseButton_Search_Click(null, null);

            if (this.pagePara != null)
            {
                dataGridViewPagingSumCtrl_CurrentPageIndexChanged(this.pagePara.PageIndex);
            }
        }

        //点击搜索按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }


                this.pagePara = new GetConfusedStoreAdjustRecordPagePara()
                {
                    CostumeID = skinTextBox_costumeID.Text,
                    ShopID = ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue),
                    PageIndex = 0,
                    PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                };
                ConfusedStoreAdjustRecordPage listPage = CommonGlobalCache.ServerProxy.GetConfusedStoreAdjustRecordPage(this.pagePara);
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                this.dataGridViewPagingSumCtrl.Initialize(listPage);
                this.BindingConfusedStoreAdjustRecordDateSource(listPage);
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

        /// <summary>
        /// 绑定ConfusedStoreAdjustRecordList源到dataGridView 中
        /// </summary>
        /// <param name="ConfusedStoreAdjustRecordListPage"></param>
        private void BindingConfusedStoreAdjustRecordDateSource(ConfusedStoreAdjustRecordPage listPage)
        {
            this.dataGridView1.DataSource = null;
            if (listPage != null && listPage.ConfusedStoreAdjustRecords != null && listPage.ConfusedStoreAdjustRecords.Count > 0)
            {
                this.SetConfusedStoreAdjustRecordOtherValue(listPage.ConfusedStoreAdjustRecords);


                foreach (var item in listPage.ConfusedStoreAdjustRecords)
                {
                    item.SizeDisplayName1 = CommonGlobalUtil.GetCostumeSizeName(item.CostumeID, item.SizeName1);
                    item.SizeDisplayName2 = CommonGlobalUtil.GetCostumeSizeName(item.CostumeID, item.SizeName2);
                }


     // this.dataGridView1.DataSource = listPage.ConfusedStoreAdjustRecords;
                  dataGridViewPagingSumCtrl.BindingDataSource(listPage?.ConfusedStoreAdjustRecords,null, listPage?.TotalEntityCount);
            }
            this.dataGridView1.Refresh();
        }

        /// <summary>
        /// 将集合中GuideName赋值
        /// </summary>
        /// <param name="ConfusedStoreAdjustRecordList"></param>
        private void SetConfusedStoreAdjustRecordOtherValue(List<ConfusedStoreAdjustRecord> ConfusedStoreAdjustRecordList)
        {
            foreach (ConfusedStoreAdjustRecord ConfusedStoreAdjustRecord in ConfusedStoreAdjustRecordList)
            {
                ConfusedStoreAdjustRecord.OperatorUserName = CommonGlobalCache.GetUserName(ConfusedStoreAdjustRecord.OperatorUserID);
                Shop shop = CommonGlobalCache.GetShop(ConfusedStoreAdjustRecord.ShopID);
                ConfusedStoreAdjustRecord.ShopName = shop == null ? "" : shop.Name;
            }
        }
         

        private void ConfusedStoreAdjustRecordCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.pagePara = new GetConfusedStoreAdjustRecordPagePara();
            this.dataGridViewPagingSumCtrl.Initialize(1);
            this.dataGridView1.DataSource = null;
        }

        private void BaseButtonAdd_Click(object sender, EventArgs e)
        {
            this.AddClick?.Invoke(this);
        }
         
        private void skinTextBox_costumeID_CostumeSelected(Costume costume, bool isEnter)
        {
            if (costume != null && isEnter)
            {
                BaseButton_Search_Click(null, null);
            }
        }
    }
}
