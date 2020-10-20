using JGNet.Core;
using CJBasic.Helpers;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class ReplenishDetail:IStatisticabled
    {
        public string BrandName { get; set; }

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
                    return this.SumCount * this.CostPrice;
                }
                return this.sumCost;
            }
            set
            {
                this.sumCost = value;
            }
        }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public decimal CostPrice { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CostumeName { get; set; }

        private int sumCount = 0;

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
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public bool IsStatistics { get ; set ; }
    }
}
