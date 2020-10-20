using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class ReturnVisitRecord
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public string MemberHeadImgUrl { get; set; }
    }

    public partial class ReturnVisitMemo
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public string MemberHeadImgUrl { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public bool HaveAudio { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public bool HaveImage { get; set; }
    }
}
