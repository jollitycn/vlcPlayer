using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{ 
	public partial class SignRecord  
	{
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String ShopName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String GuideName { get; set; } 
        public String SignTypeName {
        get {
                String value = "";
                switch (this.SignType) {
                    case 0:
                        value = "早班上班";
                        break;
                    case 1:
                        value = "早班下班";
                        break;
                    case 2:
                        value = "晚班上班";
                        break;
                    case 3:
                        value = "晚班下班";
                        break;
                    default:
                        break;
                }
                return value;
            }
        }
	}
}
