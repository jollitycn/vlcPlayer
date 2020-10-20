using JGNet.Server.Tools;
using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class PfRetailAnalysis
    {
        public List<PfRetailAnalysisInfo> PfRetailAnalysisInfos { get; set; }

        public PfRetailAnalysisInfo Sum { get; set; }
    }

    public static class PfRetailAnalysisType
    {
        public const string PfCustomerName = "客户";

        public const string SupplierName = "供应商";

        public const string BrandName = "品牌";

        public const string BigClass = "大类";

        public const string SmallClass = "小类";

        public const string CostumeID = "款号";

        public const string CostumeName = "商品名称";

        public const string Year = "年份";
    }

    public class PfRetailAnalysisInfo
    {
        public string ParaValue { get; set; }

        /// <summary>
        /// 例如：客户、客户+供应商、客户+品牌、供应商+客户、品牌+客户
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

        /// <summary>
        /// 销量
        /// </summary>
        public int RetailCount { get; set; }

        /// <summary>
        /// 销量占比
        /// </summary>
        public decimal RetailRate { get; set; }

        /// <summary>
        /// 销售额
        /// </summary>
        public decimal RetailMoney { get; set; }

        /// <summary>
        /// 销售占比
        /// </summary>
        public decimal RetailMoneyRate { get; set; }

        /// <summary>
        /// 销售成本
        /// </summary>
        public decimal RetailCostPrice { get; set; }
        private decimal curRetailBendfit;
        /// <summary>
        /// 毛利
        /// </summary>
        public decimal RetailBenefit
        {
            get
            {
                curRetailBendfit= this.RetailMoney - this.RetailCostPrice;
                return curRetailBendfit;
            }
            set
            {
                this.curRetailBendfit = value;
            }
        }

        private decimal curRetailBenfitRate;
        /// <summary>
        /// 毛利率
        /// </summary>
        public decimal RetailBenefitRate
        {
            get
            {
                if (this.RetailMoney == 0)
                {
                    return 0;
                }
                curRetailBenfitRate = MathHelper.Rounded(this.RetailBenefit / this.RetailMoney, 2);
                return curRetailBenfitRate;
            }
            set
            {
                this.curRetailBenfitRate = value;
            }
        }
    }

    public class GetPfRetailAnalysisPara
    {
        /// <summary>
        /// 例如：客户、客户+供应商、客户+品牌、供应商+客户、品牌+客户
        /// </summary>
        public string Type { get; set; }

        public string PfCustomerID { get; set; }

        public string SupplierID { get; set; }

        /// <summary>
        /// -1:所有
        /// </summary>
        public int ClassID { get; set; }

        /// <summary>
        /// -1:所有
        /// </summary>
        public int BrandID { get; set; }

        public string CostumeID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }
}
