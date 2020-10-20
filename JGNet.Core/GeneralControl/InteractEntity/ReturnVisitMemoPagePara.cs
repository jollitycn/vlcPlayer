using JGNet.Core.Dev.MyEnum;
using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.InteractEntity
{
    [Serializable]
    public class ReturnVisitMemoPagePara : BasePagePara
    {
        public string GuideID { get; set; }

        public string FollowType { get; set; }

        private BoolSearchType isClosed = BoolSearchType.All;
        public BoolSearchType IsClosed { get { return this.isClosed; } set { this.isClosed = value; } }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }

    [Serializable]
    public class ReturnVisitMemoPage : BasePage
    {
        public List<ReturnVisitMemo> ReturnVisitMemos { get; set; }
    }
}
