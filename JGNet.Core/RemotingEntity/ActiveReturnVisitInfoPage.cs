using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.RemotingEntity
{
    [Serializable]
    public class ActiveReturnVisitInfoPage : BasePage
    {
        public List<ActiveReturnVisitInfo> ActiveReturnVisitInfos { get; set; }
    }

    [Serializable]
    public class ActiveReturnVisitInfo
    {
        public string MemberID { get; set; }

        public string MemberName { get; set; }

        public string MemberHeadImgUrl { get; set; }
        public int BuyCount { get; set; }

        public decimal AccruedSpend { get; set; }

        public int NotRetailDay { get; set; }
    }
    [Serializable]
    public class ActiveReturnVisitInfoPagePara : BasePagePara
    {
        public string GuideID { get; set; }

        public string ShopID { get; set; }

        public bool IsGetAll { get; set; }
    }
}
