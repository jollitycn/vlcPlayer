using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class CostumeInvoicing
    {
        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CostumeName { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 季节
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 尺码
        /// </summary>
        public string SizeName { get; set; }

        /// <summary>
        /// 进货量
        /// </summary>
        public int InCount { get; set; }

        /// <summary>
        /// 进货额
        /// </summary>
        public decimal InMoney { get; set; }

        /// <summary>
        /// 批发销量
        /// </summary>
        public int PfSalesCount { get; set; }

        /// <summary>
        /// 批发销售额
        /// </summary>
        public decimal PfSalesMoney { get; set; }

        #region 各尺码销售
        public int XSRetailCount { get; set; }

        public int SRetailCount { get; set; }

        public int MRetailCount { get; set; }

        public int LRetailCount { get; set; }

        public int XLRetailCount { get; set; }

        public int XL2RetailCount { get; set; }

        public int XL3RetailCount { get; set; }

        public int XL4RetailCount { get; set; }

        public int XL5RetailCount { get; set; }

        public int XL6RetailCount { get; set; }

        public int FRetailCount { get; set; }
        #endregion

        /// <summary>
        /// 零售销量
        /// </summary>
        public int RetailCount { get; set; }

        /// <summary>
        /// 零售销售额
        /// </summary>
        public decimal RetailMoney { get; set; }

        public bool IsStatistics { get; set; }
        private int retailSumCount = 0;
        /// <summary>
        /// 销售合计数量
        /// </summary>
        public int RetailSumCount
        {
            get;set;
            //get
            //{
            //    if (!this.IsStatistics)
            //    {
            //        return this.PfSalesCount + this.RetailCount;
            //    }
            //    return this.retailSumCount;
            //}
            //set
            //{
            //    this.retailSumCount = value;
            //}
        }

        private decimal retailSumMoney = 0;
        /// <summary>
        /// 销售合计金额
        /// </summary>
        public decimal RetailSumMoney
        {
            get;set;
            //get
            //{
            //    if (!this.IsStatistics)
            //    {
            //        return this.PfSalesMoney + this.RetailMoney;
            //    }
            //    return this.retailSumMoney;
            //}
            //set
            //{
            //    this.retailSumMoney = value;
            //}
        }

        #region 各尺码库存
        public int XSCostumeStoreCount { get; set; }

        public int SCostumeStoreCount { get; set; }

        public int MCostumeStoreCount { get; set; }

        public int LCostumeStoreCount { get; set; }

        public int XLCostumeStoreCount { get; set; }

        public int XL2CostumeStoreCount { get; set; }

        public int XL3CostumeStoreCount { get; set; }

        public int XL4CostumeStoreCount { get; set; }

        public int XL5CostumeStoreCount { get; set; }

        public int XL6CostumeStoreCount { get; set; }

        public int FCostumeStoreCount { get; set; }
        #endregion

        /// <summary>
        /// 总库存
        /// </summary>
        public int CostumeStoreCount { get; set; }

        /// <summary>
        /// 库存额
        /// </summary>
        public decimal CostumeStoreMoney { get; set; }
    }

    [Serializable]
    public class GetCostumeInvoicingPara
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public Date EndDate { get; set; }

        /// <summary>
        /// 品牌（所有：-1）
        /// </summary>
        public int BrandID { get; set; }

        /// <summary>
        /// 季节
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// 类型（所有：-1）
        /// </summary>
        public int ClassID { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 是否勾选颜色
        /// </summary>
        public bool ChooseColor { get; set; }

        /// <summary>
        /// 是否勾选尺码
        /// </summary>
        public bool ChooseSize { get; set; }
    }

    [Serializable]
    public class GetCostumeInvoicingDetailPara
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public Date EndDate { get; set; }
        
        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 尺码
        /// </summary>
        public string SizeName { get; set; }
    }
    
    public enum CostumeInvoicingDetailInType
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 进货
        /// </summary>
        [Description("进货")]
        In = 1,

        /// <summary>
        /// 退货
        /// </summary>
        [Description("退货")]
        Return = 2
    }

    public enum CostumeInvoicingDetailPfType
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 批发发货
        /// </summary>
        [Description("批发发货")]
        Delivery = 1,

        /// <summary>
        /// 批发退货
        /// </summary>
        [Description("批发退货")]
        Return = 2,

        /// <summary>
        /// 客户销售
        /// </summary>
        [Description("客户销售")]
        Retail = 3
    }

    public enum CostumeInvoicingDetailRetailType
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 销售
        /// </summary>
        [Description("销售")]
        Retail = 1,

        /// <summary>
        /// 退货
        /// </summary>
        [Description("退货")]
        Return = 2
    }
}
