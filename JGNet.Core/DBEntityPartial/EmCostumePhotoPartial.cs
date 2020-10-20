using System;
using System.Collections.Generic;
using System.Drawing;
using DataRabbit;

namespace JGNet
{
    public partial class EmCostumePhoto
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public string Thumb { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String SavePath
        { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public Image Image { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public byte[] Bytes { get; set; }
    }
}
