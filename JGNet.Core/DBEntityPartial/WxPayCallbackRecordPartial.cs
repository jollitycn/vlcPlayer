using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class WxPayCallbackRecord
    {
        /// <summary>
        /// 使用的会员卡余额
        /// </summary>
        public decimal BalanceUsed { get; set; }

        /// <summary>
        /// 使用的积分兑换后的金额（RMB）
        /// </summary>
        public decimal IntegrationUsed { get; set; }
    }
}
