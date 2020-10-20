using System;
using System.Collections.Generic;
using System.Text;
using JGNet.Core;
using JGNet.Core.Const;
using DataRabbit;
using CJBasic.Helpers;

namespace JGNet
{ 
	public partial class PfCustomerStore  : IStatisticabled
	{ 
        public String PfCustomerName { get; set; }
        public String CostumeName { get; set; }
        public String Remarks { get; set; } 
        private int sumCount = 0;

        public decimal CostPrice { get; set; }
        
        private decimal costPriceSum { get; set; }
        /// <summary>
        /// 成本总额
        /// </summary>
        public decimal CostPriceSum
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.SumCount * this.CostPrice;
                }
                return this.costPriceSum;
            }
            set
            {
                this.costPriceSum = value;
            }
        }

        private decimal sumMoney = 0;
        /// <summary>
        /// 同款号同颜色所有尺码衣服的金额总和（总金额）
        /// </summary>
        public decimal SumPfMoney
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.SumCount * this.PfPrice;
                }
                return this.sumMoney;
            }
            set
            {
                this.sumMoney = value;
            }

        }
        /// <summary>
        /// 同款号同颜色所有尺码衣服的数量总和
        /// </summary>
        public int SumCount
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.XS + this.S + this.M + this.L + this.XL + this.XL2 + this.XL3 + this.XL4 + this.XL5 + this.XL6 + this.F;
                }
                return this.sumCount;
            }
            set
            {
                this.sumCount = value;
            }
        }

        public bool IsStatistics { get; set; }
        
        public string CostumeColorID { get; set; }
        
        public string SizeGroupName { get; set; }

        public string SizeGroupShowName { get; set; }

        public decimal SalePrice { get; set; }

        public decimal EmOnlinePrice { get; set; }

        public decimal PfOnlinePrice { get; set; }

        public int BrandID { get; set; }

        public string BrandName { get; set; }

        public string SupplierID { get; set; }

        public string SupplierName { get; set; }

        public int Year { get; set; }

        public string Season { get; set; }

        public string BigClass { get; set; }

        public string SmallClass { get; set; }

        public string SubSmallClass { get; set; }

        public int ClassID { get; set; }

        public string ClassName { get; set; }

        public string ClassCode { get; set; }

        public SizeGroup SizeGroup { get; set; }

        public string EmThumbnail { get; set; }

        public List<CostumeStoreInfo> CostumeStoreInfos { get; set; }

        private string coutString;
        /// <summary>
        /// 库存情况
        /// </summary>
        public string CoutString
        {
            get
            {
                if (!this.IsStatistics)
                {
                    StringBuilder sb = new StringBuilder();
                    if (this.XS != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.XS, this.SizeGroup), this.XS));
                    }
                    if (this.S != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.S, this.SizeGroup), this.S));
                    }
                    if (this.M != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.M, this.SizeGroup), this.M));
                    }
                    if (this.L != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.L, this.SizeGroup), this.L));
                    }
                    if (this.XL != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.XL, this.SizeGroup), this.XL));
                    }
                    if (this.XL2 != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.XL2, this.SizeGroup), this.XL2));
                    }
                    if (this.XL3 != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.XL3, this.SizeGroup), this.XL3));
                    }
                    if (this.XL4 != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.XL4, this.SizeGroup), this.XL4));
                    }
                    if (this.XL5 != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.XL5, this.SizeGroup), this.XL5));
                    }
                    if (this.XL6 != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.XL6, this.SizeGroup), this.XL6));
                    }
                    if (this.F != 0)
                    {
                        sb.Append(string.Format("{0}:{1}   ", CostumeStoreHelper.GetCostumeSizeName(CostumeSize.F, this.SizeGroup), this.F));
                    }
                    string str = sb.ToString();
                    if (string.IsNullOrEmpty(str))
                    {
                        return str;
                    }
                    return "库存 (" + str.Substring(0, str.Length - 1) + ")";
                }
                return this.coutString;
            }
            set
            {
                this.coutString = value;
            }
        }
    }
}
