using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GiftTicketPage : BasePage
    {
        public List<GiftTicket> GiftTickets { get; set; }

        public GiftTicket GiftTicketSum { get; set; }
    }

    public class GiftTicketPagePara : BasePagePara
    {
        public bool IsPos { get; set; }

        public string ShopID { get; set; }

        public string MemberID { get; set; }

        public string GiftTicketID { get; set; }

        public GiftTicketState GiftTicketState { get; set; }

        /// <summary>
        /// 开始发放时间
        /// </summary>
        public Date StartDate { get; set; }
        /// <summary>
        /// 结束发放时间
        /// </summary>
        public Date EndDate { get; set; }
    }

    public enum GiftTicketState
    {
        [Description("所有")]
        All = 0,

        [Description("使用")]
        IsUse,

        [Description("未使用")]
        IsNotUse
    }
}
