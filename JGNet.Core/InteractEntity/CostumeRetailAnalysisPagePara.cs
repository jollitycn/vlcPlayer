using JGNet.Core.Tools;
using JGNet.Server.Tools;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class CostumeRetailAnalysisPagePara : BasePagePara
    {
        public bool IsManage { get; set; }

        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 服装id
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public int BrandID { get; set; }

        private int classId = -1;
        /// <summary>
        /// 类别id（-1：不过滤）
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
        /// 季节
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 到店天数大于多少天（没限制：-1）
        /// </summary>
        public int InboundTimeGreaterDay { get; set; }

        /// <summary>
        /// 未动天数大于多少天（没限制：-1）
        /// </summary>
        public int SaleTimeGreaterDay { get; set; }

        /// <summary>
        /// 过滤库存为0
        /// </summary>
        public bool FilterSummaryCountEqualsZero { get; set; }

        /// <summary>
        /// 过滤有销售的数据
        /// </summary>
        public bool FilterRetail { get; set; }

        /// <summary>
        /// 根据哪个排序（CostumeStoreSummary 表字段）
        /// </summary>
       

        /// <summary>
        /// 是否升序
        /// </summary>
       
        
    }

    public class CostumeRetailAnalysisPage : BasePage
    {
        public List<CostumeRetailAnalysis> CostumeRetailAnalysisList { get; set; }
         
    }

    public class CostumeRetailAnalysis : CostumeStoreSummary
    { 


        public String CostumeName { get; set; }
        public String BrandName { get; set; }

        /// <summary>
        /// 到点天数
        /// </summary>
        public int InboundDays
        {
            get
            {
                return (TimeHelper.GetDateTimeWithEmptyTime(DateTime.Now) - TimeHelper.GetDateTimeWithEmptyTime(FirstInboundTime)).Days;
            }
        }
        /// <summary>
        ///  未动天数
        /// </summary>
        public int UnmovedDays
        {
            get
            {
                return (TimeHelper.GetDateTimeWithEmptyTime(DateTime.Now) - TimeHelper.GetDateTimeWithEmptyTime(LastSaleTime)).Days;
            }
        }
        public decimal Price { get; set; }
        public String BigClass { get; set; }
        public String SmallClass { get; set; }
        public int Year { get; set; }
        public String Season { get; set; }
        /// <summary>
        /// 平均折扣(总销售额 / 吊牌价* 销量)
        /// </summary>
        public decimal AvgDiscount { get; set; }
         
        public string ShopName { get; set; }
    }
}
