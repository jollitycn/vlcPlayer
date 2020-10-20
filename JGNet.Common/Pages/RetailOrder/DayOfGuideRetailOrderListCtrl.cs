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
using CCWin.SkinControl;
using CJBasic;
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using CJBasic.Helpers;
using JGNet.Core.Tools;
using JGNet.Core.Const;

namespace JGNet.Common
{
    public partial class DayOfGuideRetailOrderListCtrl : BaseModifyUserControl
    {
         
        private GetGuideAchievementDetailsPara pagePara; 
        public DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl; 


        public DayOfGuideRetailOrderListCtrl()
        {
            InitializeComponent();  
                dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView_RetailDetail);
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 Remarks });
            dataGridViewPagingSumCtrl.Initialize();
                this.Initialize(); 
        }
        private string curShopid;
        private string curGuid;
        private int curDay;
        public void Search(string shopid,string guid,int day)
        {
            curDay = day;
            curShopid = shopid;
            curGuid = guid;
            this.BaseButton_Search_Click(null, null);
        }
         

        public void Initialize()
        {  
            dataGridViewPagingSumCtrl.Clear();
            this.dataGridView_RetailDetail.DataSource = null;
            this.pagePara = new GetGuideAchievementDetailsPara();

        } 

        /// <summary>
        /// 绑定RetailOrder数据源
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingRetailOrderDataSource(List<RetailDetail> list)
        {
            if (list != null && list.Count > 0) {
             
                foreach (var item in list)
                { 
                    item.SizeDisplayName = CommonGlobalUtil.GetCostumeSizeName(item.CostumeID, item.SizeName);
                   // item.SupplierName = item.MemberID;
                }
            }
            
            this.dataGridViewPagingSumCtrl.BindingDataSource(list);
        }

        //点击查询按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            { 
              InteractResult<List<RetailDetail>> list = CommonGlobalCache.ServerProxy.GetGuideReatil4Days(this.curShopid,this.curGuid,this.curDay);

                this.BindingRetailOrderDataSource(list.Data);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        } 

        public override void RefreshPage()
        {
        } 

        private void RetailOrderListCtrl_Load(object sender, EventArgs e)
        {
            //if (this.pagePara != null)
            //{
            //    Search(pagePara);
            //}
        }
         
    }
}
