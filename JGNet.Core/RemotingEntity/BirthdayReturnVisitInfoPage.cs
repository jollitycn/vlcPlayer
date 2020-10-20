using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.RemotingEntity
{
    [Serializable]
    public class BirthdayReturnVisitInfoPage : BasePage
    {
        public List<BirthdayReturnVisitInfo> BirthdayReturnVisitInfos { get; set; }
    }

    [Serializable]
    public class BirthdayReturnVisitInfo
    {
        public string MemberID { get; set; }

        public string MemberName { get; set; }
        public string MemberHeadImgUrl { get; set; }
        public string CalendarType { get => "公历"; }

        public string BirthdayStr { get; set; }

        public int BuyCount { get; set; }

        public decimal AccruedSpend { get; set; }

        public int NotRetailDay { get; set; }
        /// <summary>
        /// 距离生日天数
        /// </summary>
        public int NextBirthdayDay { get; set; }
    }

    [Serializable]
    public class BirthdayReturnVisitInfoPagePara : BasePagePara
    {
        public string GuideID { get; set; }

        public bool IsToday { get; set; }

        public string ShopID { get; set; }
    }
}
