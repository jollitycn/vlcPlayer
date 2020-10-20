using CJBasic.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class PfCustomerDetail : IStatisticabled
    {
        public int OrgCount { get; set; }
        public bool IsSelected { get; set; }
        public string SizeDisplayName { get; set; }
        public string CostumeName { get; set; }

        public string EmThumbnail { get; set; }

        /// <summary>
        /// 总仓库存
        /// </summary>
        public int CostumeStoreCount { get; set; }

        public int WaitDeliveryCount
        {
            get
            {
                return this.Count - this.DeliveryCount;
            }
        }



        public bool IsStatistics { get; set; }

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
                    return this.Count * this.PfPrice;
                }
                return this.sumMoney;
            }
            set
            {
                this.sumMoney = value;
            }
        }

        private decimal sumDeliveryMoney = 0;
        /// <summary>
        /// 同款号同颜色所有尺码衣服的金额总和（总金额）
        /// </summary>
        public decimal SumDeliveryMoney
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.DeliveryCount * this.PfPrice;
                }
                return this.sumDeliveryMoney;
            }
            set
            {
                this.sumDeliveryMoney = value;
            }

        }
    }
}
