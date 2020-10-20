using JGNet.Core;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class CostumeStoreTrack
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CostumeName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public string ShopName { get; set; }

        public String SizeDisplayName { get; set; }
    }
}
