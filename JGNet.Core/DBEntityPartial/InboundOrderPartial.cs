using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class InboundOrder
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 操作员
        /// </summary>
        public string GuideName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 入库店铺名称
        /// </summary>
        public string DeskShopName { get; set; }
    }
}
