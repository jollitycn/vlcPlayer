using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet
{
    public class MemberListPagePara : BasePagePara
    {
        /// <summary>
        /// 手机号码或者名称
        /// </summary>
        public string PhoneNumberOrName { get; set; }

        /// <summary>
        /// 所属导购ID
        /// </summary>
        public string GuideID { get; set; }

        public TimeRange TimeRange { get; set; }

        public string ShopID { get; set; }

        /// <summary>
        /// 是否仅显示本店的数据
        /// </summary>
        public bool OnlyShowOwnShop { get; set; }

        /// <summary>
        /// 未消费天数 (-1：所有，-2：从未消费)
        /// </summary>
        public int NoRetailDay { get; set; }
    }

    [Serializable]
    public class MemberListPage : BasePage
    {
        public List<Member> MemberArray { get; set; }

        public Member MemberSum { get; set; }
    }

    public enum TimeRange
    {
        [Description("所有")]
        All = 0,

        [Description("今日")]
        Today,

        [Description("本周")]
        ThisWeek,

        [Description("本月")]
        ThisMonth
    }
}