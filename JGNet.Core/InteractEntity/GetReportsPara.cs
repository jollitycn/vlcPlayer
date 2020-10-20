using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class GetReportsPara: BaseOrderPara
    {
        public int ReportDate { get; set; }

        public int ReportMonth { get; set; }

        /// <summary>
        /// 要进行排序的列，如果传入null，表示不进行排序
        /// </summary>
       

        /// <summary>
        /// 排序规则：升序，降序
        /// </summary>
       
    }
    
}
