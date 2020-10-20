using JGNet.Core;
using JGNet.Core.InteractEntity;
using CJBasic.Helpers;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class CostumeStore: CheckBaseDataPara, IStatisticabled
    {
       
        public int Index { get; set; }
        public bool Selected { get; set; }
        public bool ShowSelected { get; set; }
        private bool isShow = true;
        public bool IsShow { get { return isShow; } set { isShow = value; } }
       
        /// <summary>
        /// 店铺名称
        /// </summary>

        public string ShopName { get; set; } 

        public string YearStr { get; set; }

        public string BigClass { get; set; }

        public string SmallClass { get; set; }

        private int sumCount = 0;
         
        /// <summary>
        /// 同款号同颜色所有尺码衣服的数量总和
        /// </summary>
        public bool HasNoDiff
        {
            get
            {
                return this.XS == 0 && this.S == 0
               && this.M == 0 && this.L == 0 && this.XL == 0 &&
                this.XL2 == 0 && this.XL3 == 0 && this.XL4 == 0 &&
                this.XL5 == 0 && this.XL6 == 0 && this.F == 0;
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

        private decimal sumCostMoney = 0;
        /// <summary>
        /// 同款号同颜色所有尺码衣服的成本金额总和（总金额）
        /// </summary>
        public decimal SumCostMoney
        {
            get
            {
                if (!this.IsStatistics)
                {
                    if (this.SumCount == 0) {
                        return 0;
                    }
                    else
                    {
                        return this.SumCount * this.CostPrice;
                      //  return 0;
                    }
                }
                return this.sumCostMoney;
            }
            set
            {
                this.sumCostMoney = value;
            }

        }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 每个行的说明 （提供给补货显示用）
        /// </summary>
        public string Title
        {
            get; set;
        }

        /// <summary>
        /// 删除按钮名称 （标题为“库存”可删除 反之为string.Empty）
        /// </summary>
        public string DeleteName
        {
            get
            {
                if (this.Title == "库存")
                {
                    return "删除";
                }
                return string.Empty;
            }
        }

        public bool IsStatistics { get; set; }

        
        public List<CostumeStoreInfo> CostumeStoreInfos
        {
            get;set;
        }

        public String Remarks { get; set; } 

        public string ClassName { get; set; }

        public int ClassID { get; set; }

        public string ClassCode { get; set; }
    }
}
