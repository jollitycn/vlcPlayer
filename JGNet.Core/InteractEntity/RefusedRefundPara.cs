using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class RefusedRefundPara
    {
        public string EmRefundOrderID { get; set; }

        public string OperateID { get; set; }

        /// <summary>
        /// 拒绝退款的原因
        /// </summary>
        public string RejectCauese { get; set; }
    }
}
