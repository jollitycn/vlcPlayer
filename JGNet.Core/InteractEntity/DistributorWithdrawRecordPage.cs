using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class DistributorWithdrawRecordPage : BasePage
    {
        public List<DistributorWithdrawRecord> DistributorWithdrawRecords { get; set; }

        public DistributorWithdrawRecord DistributorWithdrawRecordSum { get; set; }
    }

    public class GetDistributorWithdrawRecordPagePara : BasePagePara
    {
        public DistributorWithdrawRecordState State { get; set; }

        public string DistributorID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    public enum DistributorWithdrawRecordState
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        All = -1,

        /// <summary>
        /// 待打款
        /// </summary>
        [Description("待打款")]
        WaitPay = 0,

        /// <summary>
        /// 已打款
        /// </summary>
        [Description("已打款")]
        Paid = 1,

        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        Cancel = 2
    }
}
