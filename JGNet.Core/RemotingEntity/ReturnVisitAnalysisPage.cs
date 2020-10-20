using JGNet.Core.InteractEntity;
using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.RemotingEntity
{
    [Serializable]
    public class ReturnVisitAnalysis
    {
        public string ShopID { get; set; }
        public string ShopName { get; set; }

        public Date Date { get; set; }

        public string DateString
        {
            get
            {
                if (Date == null)
                {
                    return string.Empty;
                }
                return string.Format("{0}-{1}-{2}", this.Date.Year, this.Date.Month.ToString().PadLeft(2, '0'), this.Date.Day.ToString().PadLeft(2, '0'));
            }
        }
        
        public List<AnalysisInfo> AnalysisInfos { get; set; }

        public AnalysisInfo Retail { get; set; }

        public AnalysisInfo Birthday { get; set; }
    }
    
    [Serializable]
    public class AnalysisInfo
    {
        public string Subject { get; set; }

        public int TotalCount { get; set; }

        public int Finish { get; set; }

        public int NotFinish { get => this.TotalCount - this.Finish; }
    }
    
    [Serializable]
    public class ReturnVisitAnalysisPara
    {
        public string ShopID { get; set; }


        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    [Serializable]
    public class ReturnVisitAnalysis4Guide
    {

        public string GuideName { get; set; }

        public AnalysisInfo Retail { get; set; }

        public AnalysisInfo Birthday { get; set; }
    }

    [Serializable]
    public class ReturnVisitAnalysis4GuidePara
    {
        public string ShopID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public bool IsNeedAddDay { get; set; }
    }
}
