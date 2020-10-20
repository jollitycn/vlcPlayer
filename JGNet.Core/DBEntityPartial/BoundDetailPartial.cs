using CJBasic;
using CJBasic.Helpers;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class BoundDetail:IStatisticabled
    {
        public String SupplierName { get; set; }

        public String SupplierID { get; set; }

        public String BrandName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public int BrandID { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 折扣
        /// </summary>

        public Decimal Discount { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute] 

        /// <summary>
        /// 服装名称
        /// </summary>
        public string CostumeName { get; set; }

        /// <summary>
        /// 尺码组名称
        /// </summary>
        public string SizeGroupName { get; set; }

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
        /// <summary>
        /// 是否确认过（入库时调用）
        /// </summary>
        public bool IsConfirmed { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public bool IsStatistics { get ; set ; }

        public string Date { get; set; }

        public string PurchaseOrderID { get; set; }
        
        public string Barcode { get; set; }

        public int Year { get; set; }

        public string Season { get; set; }

        public string YearStr { get; set; }

        public string DestShopID { get; set; }

        public int TotalCount { get; set; }

        public int OrderCount { get; set; }

        public string OrderID { get; set; }

        public DateTime CreateTime { get; set; }

        public string EntryUserID { get; set; }

        public string Remarks { get; set; }
    }
}
