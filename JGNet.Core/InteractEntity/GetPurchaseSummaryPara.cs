using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public static class PurchaseSummaryType
    {
        public const string CostumeID = "款号";
        public const string CostumeName = "商品名称";
        public const string Date = "日期";
        public const string SupplierName = "供应商";
        public const string BrandName = "品牌";
        public const string PurchaseOrderID = "单号";
        public const string Color = "颜色";
        public const string Year = "年份";
        public const string Season = "季节";
    }


    public class GetPurchaseSummaryPara
    {
        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public string SupplierID { get; set; }

        /// <summary>
        /// -1:所有
        /// </summary>
        public int BrandID { get; set; }

        public string OrderId { get; set; }

        public string CostumeID { get; set; }

        /// <summary>
        /// 例如：款号，供应商+款号、品牌+款号、日期+款号、日期+单号+供应商
        /// </summary>
        public string Type { get; set; }
    }

    public class PurchaseSummary
    {
        public List<PurchaseSummaryInfo> PurchaseSummaryInfos { get; set; }

        public PurchaseSummaryInfo Sum { get; set; }
    }

    public class PurchaseSummaryInfo
    {
        /// <summary>
        /// 例如：款号，供应商+款号、品牌+款号、日期+款号、日期+单号+供应商
        /// </summary>
        public string Type { get; set; }
        public string TypeValue1 { get; set; }
        public string TypeValue2 { get; set; }
        public string TypeValue3 { get; set; }
        public string TypeValue4 { get; set; }
        public string TypeValue5 { get; set; }
        public string TypeValue6 { get; set; }
        public string TypeValue7 { get; set; }
        public string TypeValue8 { get; set; }
        public string TypeValue9 { get; set; }
        public string TypeValue10 { get; set; }
        public int Count { get; set; }

        public List<String> TypeValues { get;set;}
       

        /// <summary>
        /// 进价
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// 进价额
        /// </summary>
        public decimal CostPriceSum { get; set; }
    }
}
