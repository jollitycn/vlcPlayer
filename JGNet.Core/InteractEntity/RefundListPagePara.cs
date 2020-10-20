using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class RefundListPagePara : BasePagePara
    {
        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 开始日期日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }

        /// <summary>
        /// 退货单id（精确查询）
        /// </summary>
        public string RefundOrderID { get; set; }

        /// <summary>
        /// 款号（精确查询）
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 会员id(精确查询)
        /// </summary>
        public string MemberID { get; set; }
        
    }

    public class RefundListPage : BasePage
    {
        public List<RetailOrder> ResultList { get; set; }
         
        public RetailOrder RetailOrderSum { get; set; }
    }
}
