using JGNet.Core.Tools;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class Member
    {
        public int Index { get; set; }

        public string SexName
        {
            get
            {
                return this.Sex ? "男" : "女";
            }
        }

        public string StateName
        {
            get
            {
                return this.State == 1 ? "启用" : "禁用";
            }
        }
        public string ShopName
        {
            get;set;
        }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 导购员
        /// </summary>
        public string GuideName
        {
            get;set;
        }

        /// <summary>
        /// 客单价 = 实收额 / 单数
        /// </summary>
        public decimal SalesPerMemberPay
        {
            get
            {
                if (BuyCount == 0)
                {
                    return 0;
                }
                return Server.Tools.MathHelper.Rounded(AccruedSpend / BuyCount,2);
            }
        }

        /// <summary>
        /// 物单价 = 实收额 / 销售量
        /// </summary>
        public decimal SalesPerCostumePay
        {
            get
            {
                if (QuantityOfBuy == 0)
                {
                    return 0;
                }
                return Server.Tools.MathHelper.Rounded(AccruedSpend / QuantityOfBuy,2);
            }
        }

        /// <summary>
        /// 连带率 =  销售量 / 单数
        /// </summary>
        public decimal SalesJointRate
        {
            get
            {
                if (BuyCount == 0)
                {
                    return 0;
                }
                return Server.Tools.MathHelper.Rounded((decimal)QuantityOfBuy / BuyCount,2);
            }
        }

        /// <summary>
        /// 未消费天数
        /// </summary>
        public int NoSpendDay
        {
            get
            {
                return  (DateTime.Now - this.LastSpendTime).Days;
            }
        }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public decimal BalanceSum { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public int CurrentIntegrationSum { get; set; }

        /// <summary>
        /// 推荐人姓名
        /// </summary>
        public string IntroducerName { get; set; }

        /// <summary>
        /// 推荐人数
        /// </summary>
        public int IntroducerMemberCount { get; set; }

        /// <summary>
        /// 消费密度
        /// </summary>
        public double Frequency
        {
            get
            {
                if (this.BuyCount == 0)
                {
                    return 0;
                }
                return Server.Tools.MathHelper.Rounded((double)(DateTime.Now - this.CreatedTime).Days / this.BuyCount,2);
            }
        }

        /// <summary>
        /// 消费宽度 （每个大类购买的件数）
        /// </summary>
        public List<BuyCount4BigClass> BuyCount4BigClassList
        {
            get; set;
        }
        private decimal _remaining=0;
        /// <summary>
        /// 剩余的佣金
        /// </summary>
        public decimal RemainingCommission
        {
            get
            {
                return this.AccruedCommission - this.ApplicationMoney;
            }
            set
            {
                _remaining = value;
            }
        }

        /// <summary>
        /// 待打款佣金
        /// </summary>
        public decimal WaitPayMoney { get; set; }

        /// <summary>
        /// 已申请佣金
        /// </summary>
        public decimal ApplicationMoney
        {
            get
            {
                return this.WaitPayMoney + this.WithdrawCommission;
            }
        }
    }

    [Serializable]
    public class BuyCount4BigClass
    {
        public string BigClassName { get; set; }

        public int BuyCount { get; set; }
    }
}
