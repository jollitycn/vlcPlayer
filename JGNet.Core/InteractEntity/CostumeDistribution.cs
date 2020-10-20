using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class CostumeDistribution
    {
        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 服装名称
        /// </summary>
        public string CostumeName { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 季节
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// 吊牌价
        /// </summary>
        public decimal Price { get; set; }

        public bool IsStatistics { get; set; }

        private decimal costPriceSum;
        /// <summary>
        /// 成本总额
        /// </summary>
        public decimal CostPriceSum
        {
            get;set;
          /*  get
            {
                if (!this.IsStatistics)
                {
                    return this.CostumeStore * this.CostPrice;
                }
                return this.costPriceSum;
            }
            set
            {
                this.costPriceSum = value;
            }*/
        }

        /// <summary>
        /// 当前库存
        /// </summary>
        public int CostumeStore { get; set; }
    }

    public class CostumeDistributionDetail
    {
        /// <summary>
        /// 类型
        /// </summary>
        public CostumeDistributionType Type { get; set; }

        /// <summary>
        /// 店铺/客户 ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 店铺/客户
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 累计进货
        /// </summary>
        public int InCount { get; set; }

        /// <summary>
        /// 首次到货日期
        /// </summary>
        public DateTime CreateTime { get; set; }

        public bool IsStatistics { get; set; }

        private int retailCount;
        /// <summary>
        /// 本期销售
        /// </summary>
        public int RetailCount
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.RetailXS + this.RetailS + this.RetailM + this.RetailL + this.RetailXL + this.RetailXL2 + this.RetailXL3 + this.RetailXL4 + this.RetailXL5 + this.RetailXL6 + this.RetailF;
                }
                return this.retailCount;
            }
            set
            {
                this.retailCount = value;
            }
        }

        #region 销售尺码列
        public int RetailXS { get; set; }

        public int RetailS { get; set; }

        public int RetailM { get; set; }

        public int RetailL { get; set; }

        public int RetailXL { get; set; }

        public int RetailXL2 { get; set; }

        public int RetailXL3 { get; set; }

        public int RetailXL4 { get; set; }

        public int RetailXL5 { get; set; }

        public int RetailXL6 { get; set; }

        public int RetailF { get; set; }
        #endregion

        private int costumeStore;
        /// <summary>
        /// 当前库存
        /// </summary>
        public int CostumeStore
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.CostumeStoreXS + this.CostumeStoreS + this.CostumeStoreM + this.CostumeStoreL + this.CostumeStoreXL + this.CostumeStoreXL2 + this.CostumeStoreXL3 + 
                        this.CostumeStoreXL4 + this.CostumeStoreXL5 + this.CostumeStoreXL6 + this.CostumeStoreF;
                }
                return this.costumeStore;
            }
            set
            {
                this.costumeStore = value;
            }
        }

        #region 库存尺码列
        public int CostumeStoreXS { get; set; }

        public int CostumeStoreS { get; set; }

        public int CostumeStoreM { get; set; }

        public int CostumeStoreL { get; set; }

        public int CostumeStoreXL { get; set; }

        public int CostumeStoreXL2 { get; set; }

        public int CostumeStoreXL3 { get; set; }

        public int CostumeStoreXL4 { get; set; }

        public int CostumeStoreXL5 { get; set; }

        public int CostumeStoreXL6 { get; set; }

        public int CostumeStoreF { get; set; }
        #endregion
    }

    public class GetCostumeDistributionsPara
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
        /// 进货开始时间
        /// </summary>
        public Date InStartDate { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 是否勾选颜色
        /// </summary>
        public bool IsChooseColor { get; set; }

        /// <summary>
        /// 品牌（-1：所有）
        /// </summary>
        public int BrandID { get; set; }

        /// <summary>
        /// 类别（-1：所有）
        /// </summary>
        public int ClassID { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 季节
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// 查询方式
        /// </summary>
        public CostumeDistributionType QueryType { get; set; }

        /// <summary>
        /// 仅显示非零库存商品
        /// </summary>
        public bool OnlyShowStoreNotZero { get; set; }
    }
    
    public enum CostumeDistributionType
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 店铺
        /// </summary>
        [Description("店铺")]
        Shop = 0,

        /// <summary>
        /// 客户
        /// </summary>
        [Description("客户")]
        PfCustomer = 1
    }

    public class GetCostumeDistributionDetailsPara : GetCostumeDistributionsPara
    {
        /// <summary>
        /// /// <summary>
        /// 店铺/客户 ID
        /// </summary>
        /// </summary>
        public string ID { get; set; }

        public string ColorName { get; set; }
    }

    public class OrderInfo
    {
        /// <summary>
        /// 单号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 单据时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
        public string EntryUserName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        public int TotalCount { get; set; }
    }
}
