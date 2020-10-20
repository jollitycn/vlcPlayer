using JGNet.Core.InteractEntity;
using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.RemotingEntity
{
    [Serializable]
    public class ReturnVisitRecordPage : BasePage
    {
        public List<ReturnVisitRecord> ReturnVisitRecords { get; set; }
    }

    [Serializable]
    public class ReturnVisitRecordPagePara : BasePagePara
    {
        public string ShopID { get; set; }
        public string GuideID { get; set; }

        public string VisitType { get; set; }

        public string Subject { get; set; }

        public string MemberID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }
}
