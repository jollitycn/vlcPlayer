using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class InventoryDayReportPage : BasePage
    {
        public List<InventoryDayReport> InventoryDayReports { get; set; }
    }

    public class InventoryDayReportPagePara : BasePagePara
    {
        public string ShopID { get; set; }

        public int StartReportDate { get; set; }

        public int EndReportDate { get; set; }
    }

    public class InventoryDayReportsPara
    {
        public string ShopID { get; set; }

        public string CostumeID { get; set; }

        private int classId = -1;
        /// <summary>
        /// 类别id：（不过滤：-1）
        /// </summary>
        public int ClassID
        {
            get
            {
                return this.classId;
            }
            set
            {
                this.classId = value;
            }
        }

        public InventoryDayReportQueryType QueryType { get; set; }

        public int StartReportDate { get; set; }

        public int EndReportDate { get; set; }

        public bool MergeSameShopID { get; set; }

        public bool MergeSameCostumeID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    public enum InventoryDayReportQueryType
    {
        BigClass = 0,

        CostumeID
    }

    /// <summary>
    /// 进销存简报 （用于导购小程序显示）  数据来自日报表
    /// </summary>
    [Serializable]    
    public class InventoryDayReport4GuideSmallProgram
    {
        public int DateInt { get; set; }

        public string ReportDate { get; set; }

        public int OrderBy { get; set; }

        /// <summary>
        /// 采购进货数
        /// </summary>
        public int PurchaseInCount { get; set; }

        /// <summary>
        /// 转入= 调拨入库数 + 补货入库数 + 差异单为正值
        /// </summary>
        public int AllocateInCount { get; set; }

        /// <summary>
        /// 采购退货数
        /// </summary>
        public int ReturnCount { get; set; }

        /// <summary>
        /// 转出= 调拨数 + 补货出库数 + 差异单为负值
        /// </summary>
        public int AllocateOutCount { get; set; }

        /// <summary>
        /// 销售数量= 销售总数-退货总数（线上线下总和）
        /// </summary>
        public int SalesInCount { get; set; }

        /// <summary>
        /// 报损数
        /// </summary>
        public int ScrapOutCount { get; set; }

        /// <summary>
        /// 盈亏数 = 盘赢数-盘亏数
        /// </summary>
        public int CheckStoreInCount { get; set; }

        /// <summary>
        /// 上日结存数
        /// </summary>
        public int PreTotalCount
        {
            get
            {
                return this.TotalCount - this.CheckStoreInCount + this.ScrapOutCount + this.SalesInCount + this.AllocateOutCount + this.ReturnCount - this.AllocateInCount - this.PurchaseInCount;
            }
        }

        /// <summary>
        /// 当然结存数
        /// </summary>
        public int TotalCount { get; set; }

    }
}
