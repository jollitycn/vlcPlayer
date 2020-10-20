using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    
    [Serializable]
    public class DayBenefitReportPage : BasePage
    {
        public List<DayBenefitReport> DayBenefitReports { get; set; }
         
        public DayBenefitReport DayBenefitReportSum { get; set; }
    }
}
