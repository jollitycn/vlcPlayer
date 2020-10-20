using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetShopBenefitReportsPara
    {
        public bool IsPos { get; set; }

        public string ShopID { get; set; }

        public int StartDate { get; set; }

        public int EndDate { get; set; }

        public bool IsGetGeneralStore { get; set; }
    }

    public class GetBenefitReportsPara
    {
        public bool IsMonth { get; set; }
        public string ShopID { get; set; }

        public int StartDate { get; set; }

        public int EndDate { get; set; }

        /// <summary>
        /// 显示不为0的业绩
        /// </summary>
        public bool IsShowNotZero { get; set; }

        public bool IsGetGeneralStore { get; set; }
    }
}
