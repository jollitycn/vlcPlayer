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
    public partial class ConfusedStoreAdjustRecordDetailCtrl : BaseModifyCostumeIDUserControl
    {


        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
         

        public ConfusedStoreAdjustRecordDetailCtrl(ConfusedStoreAdjustRecord record)
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1);
            dataGridViewPagingSumCtrl.Initialize();
            List<ConfusedStoreAdjustRecord> data = new List<ConfusedStoreAdjustRecord>();
            data.Add(record);
            BindingConfusedStoreAdjustRecordDateSource(data);
        }
        public override void HighlightCostume()
        {
            if (dataGridView1.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        ConfusedStoreAdjustRecord detail = row.DataBoundItem as ConfusedStoreAdjustRecord;
                        HighlightCostume(row, detail?.CostumeID);
                    }

                }
            }
        }
         
         

        /// <summary>
        /// 绑定ConfusedStoreAdjustRecordList源到dataGridView 中
        /// </summary>
        /// <param name="ConfusedStoreAdjustRecordListPage"></param>
        private void BindingConfusedStoreAdjustRecordDateSource(List<ConfusedStoreAdjustRecord> list)
        {
            this.dataGridView1.DataSource = null;
            if (list != null && list.Count > 0)
            {
                this.SetConfusedStoreAdjustRecordOtherValue(list);
                foreach (var item in list)
                {
                    item.SizeDisplayName1 = CommonGlobalUtil.GetCostumeSizeName(item.CostumeID, item.SizeName1);
                    item.SizeDisplayName2 = CommonGlobalUtil.GetCostumeSizeName(item.CostumeID, item.SizeName2);
                }

                this.dataGridView1.DataSource = list;
               
            }

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
         
         
    }
}
