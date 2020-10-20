using JGNet.Core.InteractEntity;
using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.RemotingEntity
{
    [Serializable]
    public class RetailReturnVisitInfoPage : BasePage
    {
        public List<RetailReturnVisitInfo> RetailReturnVisitInfos { get; set; }
    }

    [Serializable]
    public class RetailReturnVisitInfo
    {
        public string ID { get; set; }

        public string MemberID { get; set; }

        public string MemberName { get; set; }

        public string MemberHeadImgUrl { get; set; }

        public string ShopID { get; set; }

        public string ShopName { get; set; }

        public string DateString { get; set; }

        public int TotalCount { get; set; }

        public decimal TotalMoneyReceived { get; set; }

        public List<RetailReturnVisitDetail> RetailReturnVisitDetails { get; set; }

        public int NotReturnVisitDayCount { get; set; }
    }

    [Serializable]
    public class RetailReturnVisitDetail
    {
        public string GuideName { get; set; }

        public string CostumeID { get; set; }

        public string CostumeName { get; set; }
    }

    [Serializable]
    public class RetailReturnVisitInfoPagePara : BasePagePara
    {
        public string GuideID { get; set; }

        public string ShopID { get; set; }
    }
}
