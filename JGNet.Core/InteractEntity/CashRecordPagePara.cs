using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class CashRecordPagePara : BasePagePara
    {
        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 费用类型
        /// </summary>
        public CashRecordFeeType CashRecordFeeType { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }
        
    }

    public class CashRecordPage : BasePage
    {
        public List<CashRecord> CashRecordList { get; set; }
         
        public CashRecord CashRecordSum { get; set; }
    }
}
