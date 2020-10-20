using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class GuideMonthAchievementsPara
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
    }
}
