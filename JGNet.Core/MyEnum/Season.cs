using System;
using System.Collections.Generic;

namespace JGNet
{
    public enum Season
    {
        Spring = 0,

        Summer = 1,

        Autumn = 2,

        Winter = 3
    }
    public class SeasonClass
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 充值金额
        /// </summary>
        public string SeasonKey { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 赠送金额
        /// </summary>
        public string SeasonValue { get; set; }
    }
}
