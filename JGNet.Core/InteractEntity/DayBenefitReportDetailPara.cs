using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class DayBenefitReportDetailPara
    { 
        public string ShopID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    public class DayBenefitReportDetail : RetailDetail
    {
        public string MemberID { get; set; }

        public string OrderRemarks { get; set; }
        
        /// <summary>
        /// 制单人名称
        /// </summary>
        public string EntryUserName { get; set; }
    }
}
