using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class PfInfo
    {
        public PfOrder PfOrder { get; set; }

        public List<PfOrderDetail> PfOrderDetails { get; set; }
    }

    public enum PfOrderPayType
    {
        /// <summary>
        /// 记账
        /// </summary>
        Account = 0,

        /// <summary>
        /// 余额
        /// </summary>
        Balance,

        /// <summary>
        /// 现金
        /// </summary>
        Cash
    }
}
