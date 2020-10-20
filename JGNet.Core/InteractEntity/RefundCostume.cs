using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class RefundCostume
    {
        public RetailOrder RefundOrder { get; set; }

        public List<RetailDetail> RefundDetailList { get; set; }

        /// <summary>
        /// 是否含有销售单
        /// </summary>
        public bool IsNotHaveRetailOrder { get; set; }
    }

    /// <summary>
    /// 退货结果
    /// </summary>
    public enum RefundCostumeResult
    {
        Success = 0,

        /// <summary>
        /// 会员不存在
        /// </summary>
        MemberIsNotExist,

        /// <summary>
        /// 已经退货过
        /// </summary>
        IsRefundCostume,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }
}
