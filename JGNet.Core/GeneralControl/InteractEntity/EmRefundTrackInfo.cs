using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.InteractEntity
{
    [Serializable]
    public class EmRefundTrackInfo
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 仅退款
        /// </summary>
        public bool OnlyRefundMoney { get; set; }

        /// <summary>
        /// 操作类型(RefundTrackType)
        /// </summary>
        public int OperateType { get; set; }

        /// <summary>
        /// 系统自动退款剩余时间
        /// </summary>
        public string AutoRefundTime { get; set; }
    }
}
