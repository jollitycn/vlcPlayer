using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class MemberBalanceChange
    {
        /// <summary>
        /// 日期
        /// </summary>
        public int DateInt { get; set; }

        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal RechargeMoney { get; set; }

        /// <summary>
        /// 赠送金额
        /// </summary>
        public decimal DonateMoney { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal ReatilMoney { get; set; }

        /// <summary>
        /// 结余
        /// </summary>
        public decimal Balance { get; set; }
    }

    [Serializable]
    public class GetMemberBalanceChangePara
    {
        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public string MemberID { get; set; }
    }
}
