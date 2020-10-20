using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class ReatilSumInfo
    {
        public string MemberID { get; set; }

        public string MemberName { get; set; }

        public string ShopName { get; set; }

        public decimal Money { get; set; }
    }

    [Serializable]
    public class GetReatilSumInfoPara
    {
        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public ReatilSumInfoType Type { get; set; }

        public string MemberID { get; set; }
    }

    public enum ReatilSumInfoType
    {
        /// <summary>
        /// 会员
        /// </summary>
        [Description("会员")]
        Member = 0,

        /// <summary>
        /// 会员+店铺
        /// </summary>
        [Description("会员+店铺")]
        MemberShop = 1
    }
}
