using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class RechargeRecord
    {
        public string GuideName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]

        public string ShopName { get; set; }
    }
}
