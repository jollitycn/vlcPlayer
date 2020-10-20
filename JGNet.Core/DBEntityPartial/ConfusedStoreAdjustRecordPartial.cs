using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
    public partial class ConfusedStoreAdjustRecord
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String OperatorUserName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String ShopName { get; set; }


        /// <summary>
        /// 下调数量
        /// </summary>
        public int CountChange1 { get { return Math.Abs(CountNow1 - CountPre1); } }
        /// <summary>
        ///  上调数量
        /// </summary>
        public int CountChange2 { get { return Math.Abs(CountPre2 - CountNow2); } }

        public String SizeDisplayName1 { get; set; }
        public String SizeDisplayName2 { get; set; }
    }
}
