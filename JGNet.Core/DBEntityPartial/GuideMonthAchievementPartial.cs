using JGNet.Core.Tools;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class GuideMonthAchievement
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 导购姓名
        /// </summary>
        public string GuideName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String ShopName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 导购头像
        /// </summary>
        public string GuideHeadImageUrl { get; set; }

        /// <summary>
        /// 连带率（带%字符串）
        /// </summary>
        public string JointRateName {
            get
            {
                return StringHelper.RateToWithPercentAndPlusSign(this.m_JointRate);
            }
        }

        /// <summary>
        /// 完成率（带%字符串）
        /// </summary>
        public string CompletionRateName
        {
            get
            {
                return StringHelper.RateToWithPercent(this.m_CompletionRate);
            }
        }
        /// <summary>
        /// 导购实收额同比率（带%字符串）
        /// </summary>
        public string YearOnYearRate_MoneyOfSaleName
        {
            get
            {
                return StringHelper.RateToWithPercentAndPlusSign(this.yearOnYearRate_MoneyOfSale);
            }
        }

        /// <summary>
        /// 导购实收额环比率（带%字符串）
        /// </summary>
        public string QuarterOnQuarterRate_MoneyOfSaleName
        {
            get
            {
                return StringHelper.RateToWithPercentAndPlusSign(this.quarterOnQuarterRate_MoneyOfSale);
            }
        }

        private double yearOnYearRate_MoneyOfSale = 0;
        /// <summary>
        ///  导购实收额同比率
        /// </summary>
        public double YearOnYearRate_MoneyOfSale
        {
            get { return this.yearOnYearRate_MoneyOfSale; }
            set { this.yearOnYearRate_MoneyOfSale = value; }
        }

        private double quarterOnQuarterRate_MoneyOfSale = 0;
        /// <summary>
        /// 导购实收额环比率
        /// </summary>        
        public double QuarterOnQuarterRate_MoneyOfSale
        {
            get { return this.quarterOnQuarterRate_MoneyOfSale; }
            set { this.quarterOnQuarterRate_MoneyOfSale = value; }
        }



    }
}
