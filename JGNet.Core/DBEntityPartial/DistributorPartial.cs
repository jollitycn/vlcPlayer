using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class Distributor
    {
        public int MemberLevel { get; set; }

        public string SequenceCode { get; set; }

        /// <summary>
        /// 待收货佣金
        /// </summary>
        public decimal WaitReceiptMoney { get; set; }

        /// <summary>
        /// 剩余的佣金
        /// </summary>
        public decimal RemainingCommission
        {
            get
            {
                return this.AccruedCommission - this.ApplicationMoney;
            }
        }

        /// <summary>
        /// 待打款佣金
        /// </summary>
        public decimal WaitPayMoney { get; set; }

        /// <summary>
        /// 已申请佣金
        /// </summary>
        public decimal ApplicationMoney
        {
            get
            {
                return this.WaitPayMoney + this.WithdrawCommission;
            }
        }

        /// <summary>
        /// 一段时间的累计佣金
        /// </summary>
        public decimal AccruedCommission4Day { get; set; }

        /// <summary>
        /// 推荐人id
        /// </summary>
        public string IntroducerID { get; set; }

        /// <summary>
        /// 推荐人名称
        /// </summary>
        public string IntroducerName { get; set; }

        /// <summary>
        /// 分销佣金
        /// </summary>
        public decimal DistributorCommission
        {
            get
            {
                return this.AccruedCommission;
            }
        }

        /// <summary>
        /// 佣金明细笔数
        /// </summary>
        public int CommissionDetailCount { get; set; }

        /// <summary>
        /// 提现明细笔数
        /// </summary>
        public int WithdrawDetailCount { get; set; }

        /// <summary>
        /// 我的下线人数
        /// </summary>
        public int LineCount { get; set; }
    }
}
