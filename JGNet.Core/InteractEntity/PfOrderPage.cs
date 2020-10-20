using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class PfOrderPage : BasePage
    {
        public List<PfOrder> PfOrders { get; set; }

        public PfOrder PfOrderSum { get; set; }
    }

    [Serializable]
    public class GetPfOrderPagePara : BasePagePara
    {
        public string PfOrderID { get; set; }

        public string CostumeID { get; set; }

        public string PfCustomerID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public PfOrderState PfOrderState { get; set; }

        public PfOrderStateEnum PfOrderStateEnum { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
    
    public enum PfOrderStateEnum
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,

        /// <summary>
        /// 挂单
        /// </summary>
        [Description("挂单")]
        HangUp,

        /// <summary>
        /// 冲单
        /// </summary>
        [Description("冲单")]
        Cancel
    }

    public enum PfOrderState
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 批发发货
        /// </summary>
        [Description("批发发货")]
        Delivery,

        /// <summary>
        /// 批发退货
        /// </summary>
        [Description("批发退货")]
        Return
    }
}
