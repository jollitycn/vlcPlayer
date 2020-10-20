using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class AgreeRefundPara
    {
        public string EmRefundOrderID { get; set; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string RefundReceiverName { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string RefundReceiverTelphone { get; set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        public string RefundReceiverCityZone { get; set; }

        /// <summary>
        /// 收货详细地址
        /// </summary>
        public string RefundReceiverDetailAddress { get; set; }

        public string OperateID { get; set; }
    }
}
