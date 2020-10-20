using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class InboundPara
    {
        public InboundOrder InboundOrder { get; set; }

        public List<BoundDetail> InboundDetails { get; set; }
    }

    public enum InboundResult
    {
        Success = 0,

        /// <summary>
        /// 状态不是已发货
        /// </summary>
        StateIsNotDelivery,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }
}
