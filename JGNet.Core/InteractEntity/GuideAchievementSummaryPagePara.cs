using JGNet.Core.Tools;
using JGNet.Server.Tools;
using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class GuideAchievementSummarysPara
    {
        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 导购员id
        /// </summary>
        public string GuideID { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public int StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public int EndDate { get; set; }

        /// <summary>
        /// 仅显示不为零的业绩
        /// </summary>
        public bool IsOnlyShowNoZero { get; set; }

        /// <summary>
        /// 是否是月报
        /// </summary>
        public bool IsMonth { get; set; }

        public bool IsGetGeneralStore { get; set; }
    }

    [Serializable]
    public class GuideAchievementSummary
    {
        public string ShopID { get; set; }

        public string GuideID { get; set; }

        public string GuideHeadImageUrl { get; set; }
        /// <summary>
        /// 导购名称
        /// </summary>
        public string GuideName { get; set; }
        public string ShopName { get; set; }
        
        /// <summary>
        /// 销售量
        /// </summary>
        public int QuantityOfSaleSum { get; set; }

        /// <summary>
        /// 个人销售额
        /// </summary>
        public decimal MoneyOfSaleSum { get; set; }

        /// <summary>
        /// 个人实收额 = 销售额 - 积分抵扣 - vip赠送金额
        /// </summary>
        public decimal SalesActualRecvSum { get; set; }

        /// <summary>
        /// 店铺实收总额
        /// </summary>
        public decimal SalesActualRecvShopSum { get; set; }

        /// <summary>
        /// 个人业绩占比 = 个人实收额 / 店铺实收总额
        /// </summary>
        public double AchievementPercentSum { get; set; }

        /// <summary>
        /// 吊牌额
        /// </summary>
        public decimal MoneyOfPriceSum { get; set; }

        /// <summary>
        /// 成交笔数（销售单数）
        /// </summary>
        public int SalesCountSum { get; set; }

        /// <summary>
        /// 连带率 = 件数 / 单数
        /// </summary>
        public double JointRateSum { get; set; }

        /// <summary>
        /// 客单价 = 实收额 / 单数
        /// </summary>
        public double PerMemberPaySum { get; set; }

        /// <summary>
        /// 物单价 = 实收额 / 销售量
        /// </summary>
        public double PerCostumePaySum { get; set; }

        /// <summary>
        /// 平均折扣 = 销售额 / 吊牌额
        /// </summary>
        public decimal AverageDiscountSum { get; set; }

        /// <summary>
        /// 一段时间的目标额
        /// </summary>
        public int SalesMonthTaskSum { get; set; }

        /// <summary>
        /// 一段时间内的完成率
        /// </summary>
        public double CompletionRateSum
        {
            get
            {
                if (this.SalesMonthTaskSum != 0)
                {
                    return (double)MathHelper.Rounded(this.MoneyOfSaleSum / this.SalesMonthTaskSum, 2);
                }
                return 1;
            }
        }

        #region TaskTarget
        private System.Int32 m_TaskTarget = 0;
        /// <summary>
        /// TaskTarget 目标销售额
        /// </summary>
        public System.Int32 TaskTarget
        {
            get
            {
                return this.m_TaskTarget;
            }
            set
            {
                this.m_TaskTarget = value;
            }
        }
        #endregion

        #region CompletionRate
        private System.Double m_CompletionRate = 0;
        /// <summary>
        /// CompletionRate 目标完成率 = 个人销售额 / 目标销售额
        /// </summary>
        public System.Double CompletionRate
        {
            get
            {
                return this.m_CompletionRate;
            }
            set
            {
                this.m_CompletionRate = value;
            }
        }
        #endregion

        #region 实收额同比、环比
        /// <summary>
        /// 实收额同比率（带%字符串）
        /// </summary>
        public string YearOnYearRate_MoneyOfSaleName
        {
            get
            {
                return StringHelper.RateToWithPercentAndPlusSign(this.yearOnYearRate_MoneyOfSale); 
            }
        }

        /// <summary>
        /// 实收额环比率（带%字符串）
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
        ///  实收额同比率
        /// </summary>
        public double YearOnYearRate_MoneyOfSale
        {
            get { return this.yearOnYearRate_MoneyOfSale; }
            set { this.yearOnYearRate_MoneyOfSale = value; }
        }

        private double quarterOnQuarterRate_MoneyOfSale = 0;
        /// <summary>
        /// 实收额环比率
        /// </summary>        
        public double QuarterOnQuarterRate_MoneyOfSale
        {
            get { return this.quarterOnQuarterRate_MoneyOfSale; }
            set { this.quarterOnQuarterRate_MoneyOfSale = value; }
        } 
        #endregion
    }

    
}
