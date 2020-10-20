using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class VipContribution
    {
        public string ShopID { get; set; }

        public string ShopName { get; set; }

        /// <summary>
        /// 销售贡献率
        /// </summary>
        public double SalesVipContribution { get; set; }
        /// <summary>
        /// 销售贡献率（带%字符串）
        /// </summary>
        public string SalesVipContributionName { get { return StringHelper.RateToWithPercent(this.SalesVipContribution); } }


        public int NewVipCount { get; set; }


        /// <summary>
        /// 会员数量
        /// </summary>
        public int VipMemberCount { get; set; }

        /// <summary>
        /// 充值总和
        /// </summary>
        public decimal RechargeRecordSum { get; set; }

        /// <summary>
        /// 活跃率
        /// </summary>
        public double ActivityRate { get; set; }

        /// <summary>
        /// 流失率
        /// </summary>
        public double LossRate { get; set; }

        /// <summary>
        /// 回访完成率
        /// </summary>
        public double ReturnVisitCompletionRate { get; set; }

        /// <summary>
        /// 活跃率
        /// </summary>
        public string ActivityRateName { get { return StringHelper.RateToWithPercent(this.ActivityRate); } }

        /// <summary>
        /// 流失率
        /// </summary>
        public string LossRateName { get { return StringHelper.RateToWithPercent(this.LossRate); } }

        /// <summary>
        /// 回访完成率
        /// </summary>
        public string ReturnVisitCompletionRateName { get { return StringHelper.RateToWithPercent(this.ReturnVisitCompletionRate); } }

    }

    [Serializable]
    public class VipContributionPage
    {
        public VipContribution VipContributionSum { get; set; }

        public List<VipContribution> VipContributionList { get; set; }
    }
}
