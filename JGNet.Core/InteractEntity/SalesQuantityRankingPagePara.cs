using JGNet.Server.Tools;
using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public enum QueryType
    {
        /// <summary>
        /// 按款
        /// </summary>
        CostumeID = 0,

        /// <summary>
        /// 按款号颜色
        /// </summary>
        ColorName,

        /// <summary>
        /// 按款号颜色尺码
        /// </summary>
        CostumeIDColorNameSize
    }

    public enum SalesQuantityType
    {
        /// <summary>
        /// 畅销
        /// </summary>
        Selling = 0,

        /// <summary>
        /// 滞销
        /// </summary>
        Unsalable
    }

    public class SalesQuantityRankingsPara : BaseOrderPara
    {
        public bool IsPos { get; set; }

        public string CostumeID { get; set; }

        public string ColorName { get; set; }

        public string SizeName { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public int BrandID { get; set; }

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

        /// <summary>
        /// 按哪种方式查询
        /// </summary>
        public QueryType QueryType { get; set; }

        /// <summary>
        /// 滞销
        /// </summary>
        public SalesQuantityType SalesQuantityType { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }

        public string ShopID { get; set; }

        public bool IsGetGeneralStore { get; set; }
    }

    public class SalesQuantityRankingPagePara : SalesQuantityRankingsPara
    {
        // <summary>
        /// 分页的大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 要查询目标页的索引
        /// </summary>
        public int PageIndex { get; set; }
        
        /// <summary>
        /// 入库开始日期
        /// </summary>
        public Date InStartDate { get; set; }

        /// <summary>
        /// 入库结束日期
        /// </summary>
        public Date InEndDate { get; set; }
        
    }

    [Serializable]
    public class SalesQuantityRankingPage:BasePage
    {
        public List<SalesQuantityRanking> SalesQuantityRankings { get; set; }

        public SalesQuantityRanking SalesQuantityRankingSum { get; set; }
    }
    [Serializable]
    public class SalesQuantityDayReportPage : BasePage
    {
        public SalesQuantityDayReport SalesQuantityDayReportSum { get; set; }
       public List<SalesQuantityDayReport> SalesQuantityDayReports { get; set; }
    }
    [Serializable]
    public class SalesQuantityRanking : SalesQuantityDayReport
    {
        public string Remarks { get; set; }

        public string SizeName { get; set; }

        public string DBSizeName { get; set; }

        /// <summary>
        /// 首次销售时间
        /// </summary>
        public DateTime FirstSaleTime { get; set; }

        /// <summary>
        /// 首次到货时间
        /// </summary>
        public DateTime FirstInboundTime { get; set; }

        /// <summary>
        /// 最后销售时间
        /// </summary>
        public DateTime LastSaleTime { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int CostumeStoreCount { get; set; }
        
        /// <summary>
        /// 滞销率。（销量 / (库存 + 销量)）
        /// </summary>
        public float UnsalableRate
        {
            get
            {
                int count = this.CostumeStoreCount + this.QuantityOfSale;
                if (count == 0)
                {
                    return 0;
                }
                return (float)this.QuantityOfSale / count;
            }

        }

        /// <summary>
        /// 缩略图地址
        /// </summary>
        public string PhotoThumbnailUrl { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CostumeName { get; set; }
        /// <summary>
        /// 排名
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// 均售价
        /// </summary>
        public decimal AvgPrice
        {
            get
            {
                if (this.QuantityOfSale == 0)
                {
                    return 0;
                }
                return MathHelper.Rounded(this.SumMoney / this.QuantityOfSale, 2);
            }
        }
        /// <summary>
        /// 吊牌价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public decimal CostPrice { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 平均折扣
        /// </summary>
        public decimal AvgDiscount
        {
            get
            {
                if (this.Price == 0)
                {
                    return 0;
                }
                return MathHelper.Rounded(this.AvgPrice / this.Price, 2);
            }

        }

        public string ShopName { get; set; }

        /// <summary>
        /// 期初库存
        /// </summary>
        public int StartCostumeStoreCount { get; set; }

        /// <summary>
        /// 售罄率
        /// </summary>
        public decimal QuantityOfSaleRate
        {
            get
            {
                if (this.StartCostumeStoreCount == 0)
                {
                    return 0;
                }
                return MathHelper.Rounded((decimal)this.QuantityOfSale / this.StartCostumeStoreCount, 2);
            }
        }

        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 季节
        /// </summary>
        public string Season { get; set; }
    }
}
