using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class EmRefundOrder
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ReceiverName { get; set; }

        //[CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public EmRetailOrderState EmRetailOrderState { get; set; }
        public String EmRetailOrderStateName
        {
            get
            {
                return EnumHelper.GetDescription(EmRetailOrderState);
            }
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        public String RefundStateName
        {
            get
            {
                return EnumHelper.GetDescription((RefundStateEnum)RefundState);
            } 
        }

        public DateTime TimeRefundAgree { get; set; }

        public string RejectCauese { get; set; }

        public string CancelOrRefund { get; set; }
    }
}
