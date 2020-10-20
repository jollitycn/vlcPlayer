using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class OutboundOrderPagePara : BasePagePara
    {
        /// <summary>
        /// 单据编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 是否开启限制日期查询
        /// </summary>
        public bool IsOpenDate { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }
        
    }

    public class OutboundOrderPage : BasePage
    {
        public List<OutboundOrder> OutboundOrderList { get; set; }
         

        public OutboundOrder OutboundOrderSum { get; set; }
    }
}
