using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class GuideDayAchievement
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 导购名称
        /// </summary>
        public string GuideName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public string ShopName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 连带率（带%字符串）
        /// </summary>
        public string JointRateName { get; set; }
    }

}
