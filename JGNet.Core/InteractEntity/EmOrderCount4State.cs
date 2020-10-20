using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class EmOrderCount4State
    {
        /// <summary>
        /// 待付款
        /// </summary>
        public int WaitPay { get; set; }

        /// <summary>
        /// 待发货
        /// </summary>
        public int WaitDelivery { get; set; }

        /// <summary>
        /// 待收货
        /// </summary>
        public int WaitSign { get; set; }

        /// <summary>
        /// 退款售后
        /// </summary>
        public int Refunding { get; set; }
    }
}
