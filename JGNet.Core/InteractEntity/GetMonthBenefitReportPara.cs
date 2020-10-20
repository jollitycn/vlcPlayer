using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class GetMonthBenefitReportPara: BaseOrderPara
    {
        public bool IsPos { get; set; }

        public string ShopID { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public int StartReportMonth { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public int EndReportMonth { get; set; }

        /// <summary>
        /// 要进行排序的列，如果传入null，表示不进行排序
        /// </summary>
       

        /// <summary>
        /// 排序规则：升序，降序
        /// </summary>
       
    }
    
}
