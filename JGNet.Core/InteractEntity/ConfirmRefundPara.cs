using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class ConfirmRefundPara
    {
        public string EmRefundOrderID { get; set; }

        public string OperateID { get; set; }
        
        public string Remarks { get; set; }
    }

    public enum EmRetaiPayType
    {
        WeiXin = 0,

        VIP
    }
}
