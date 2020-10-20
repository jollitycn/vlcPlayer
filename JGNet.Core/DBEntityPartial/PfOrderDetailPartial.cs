using System;
using System.Collections.Generic;
using JGNet.Core;
using DataRabbit;
using CJBasic.Helpers;

namespace JGNet
{

    public partial class PfOrderDetail : IStatisticabled
    {
        public String CostumeName { get; set; }
        public int BrandID { get; set; }
        public String BrandName { get; set; }
        public Decimal Discount { get; set; }

        private int sumCount = 0;

        public string PfCustomerID { get; set; }

        public string PfCustomerName { get; set; }

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
        private decimal sumCost = 0;
        /// <summary>
        /// 同款号同颜色所有尺码衣服的金额总和（总成本）
        /// </summary>
        public decimal SumCost
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.SumCount * this.PfPrice;
                }
                return this.sumCost;
            }
            set
            {
                this.sumCost = value;
            }
        }
         
        public String CustomerID { get; set; }
        public String CustomerName { get; set; } 


        private decimal sumPfMoney = 0;
        /// <summary>
        /// 同款号同颜色所有尺码衣服的批发金额总和（总金额）
        /// </summary>
        public decimal SumPfMoney
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.SumCount * this.PfPrice;
                }
                return this.sumPfMoney;
            }
            set
            {
                this.sumPfMoney = value;
            }

        }
        private decimal sumMoney = 0;
        /// <summary>
        /// 同款号同颜色所有尺码衣服的金额总和（总金额）
        /// </summary>
        public decimal SumMoney
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.SumCount * this.Price;
                }
                return this.sumMoney;
            }
            set
            {
                this.sumMoney = value;
            }

        }

        public bool IsStatistics { get; set; }

        public DateTime OrderCreateTime { get; set; }

        public bool IsDelivery { get; set; }

        public int TotalCount { get; set; }

        public List<CostumeStoreInfo> CostumeStoreInfos { get; set; }

        public string EmThumbnail { get; set; }

        public int OrderCount { get; set; }

        public string OrderID { get; set; }

        public DateTime CreateTime { get; set; }

        public string EntryUserID { get; set; }

        public string Remarks { get; set; }
    }
}
