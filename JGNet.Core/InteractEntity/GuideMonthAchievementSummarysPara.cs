using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class GuideMonthAchievementSummarysPara
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

        public bool IsGetGeneralStore { get; set; }
    }

    public class GuideMonthAchievementSummary
    { 
        public String ShopName { get; set; }
        public String GuideName { get; set; }
        public string ShopID { get; set; }

        public string GuideID { get; set; }

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
    }
}
