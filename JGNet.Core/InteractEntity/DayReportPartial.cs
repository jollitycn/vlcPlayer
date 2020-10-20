using System;
using System.Collections.Generic;
using DataRabbit;
using CJBasic.Helpers;

namespace JGNet
{
    public partial class DayReport : IStatisticabled
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public string ShopName { get; set; }

        private Decimal salesTotal = 0;

        public bool IsStatistics { get; set; }
        public Decimal SalesTotal
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return SalesTotalMoney + RefundTotalMoney - this.CarriageCost;
                }
                return this.salesTotal;
            }
            set
            {
                this.salesTotal = value;
            }

        }

        /// <summary>
        /// 顾客退货时返还的银联卡总金额
        /// </summary>
        public decimal RefundInBankCard { get; set; }

        /// <summary>
        /// 顾客退货时返还的微信总金额
        /// </summary>
        public decimal RefundInWeiXin { get; set; }

        /// <summary>
        /// 顾客退货时返还的支付宝总金额
        /// </summary>
        public decimal RefundInAlipay { get; set; }

        /// <summary>
        /// 销售时收到的其他金额
        /// </summary>
        public decimal SalesInMoneyOther { get; set; }

        /// <summary>
        /// 顾客退货时返还的其他金额
        /// </summary>
        public decimal RefundInMoneyOther { get; set; }
    }
}
