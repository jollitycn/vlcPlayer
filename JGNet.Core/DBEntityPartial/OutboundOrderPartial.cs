using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class OutboundOrder
    {
        public OutboundOrder()
        {
            this.IsValid = true;
        }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 操作员
        /// </summary>
        public string GuideName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 发货店名
        /// </summary>
        public string SourceShopName { get; set; }

    }
}
