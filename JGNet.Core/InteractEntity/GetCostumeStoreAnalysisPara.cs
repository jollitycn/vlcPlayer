using JGNet.Core.Dev.MyEnum;
using JGNet.Server.Tools;
using CJBasic.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetCostumeStoreAnalysisPara
    {
        public GroupType GroupType { get; set; }

        public string ShopID { get; set; }

        public int BrandID { get; set; }

        public string Season { get; set; }
    }

    public class CostumeStoreSum
    {
        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal CostPrice { get; set; }
    }

    public class CostumeStoreAnalysisData : IStatisticabled
    {
        public CostumeStoreSum CostumeStoreSum { get; set; }

        public string GroupTyopeName { get; set; }

        /// <summary>
        /// 库存总量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 吊牌总额
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 成本总额
        /// </summary>
        public decimal CostPrice { get; set; }



        private decimal countPercentage = 0;

        public bool IsStatistics { get; set; }
        /// <summary>
        /// 数量占比 
        /// </summary>
        public decimal CountPercentage
        {
            get
            {
                if (!this.IsStatistics)
                {
                    if (this.CostumeStoreSum?.Count == 0)
                    {
                        return 0;
                    }
                    return MathHelper.Rounded((decimal)this.Count / this.CostumeStoreSum.Count, 2);
                    
                }
                return this.countPercentage;
            }
            set
            {
                this.countPercentage = value;
            }
        }
        private decimal pricePercentage = 0;

        /// <summary>
        /// 金额占比
        /// </summary>
        public decimal PricePercentage
        {
            get
            {
                if (!this.IsStatistics)
                {
                    if (this.CostumeStoreSum?.Price == 0)
                    {
                        return 0;
                    }
                    return MathHelper.Rounded((decimal)this.Price / this.CostumeStoreSum.Price, 2);
                }
                return pricePercentage;
            }
            set { this.pricePercentage = value; }
        }

        private decimal costPricePercentage = 0;
        /// <summary>
        /// 成本占比
        /// </summary>
        public decimal CostPricePercentage
        {
            get
            {
                if (!this.IsStatistics)
                {
                    if (this.CostumeStoreSum?.CostPrice == 0)
                    {
                        return 0;
                    }
                    return MathHelper.Rounded((decimal)this.CostPrice / this.CostumeStoreSum.CostPrice, 2);
                }
                return costPricePercentage;
            }
            set { this.costPricePercentage = value; }
        }
    }
}
