using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class RechargeRecordListPara : BaseOrderPara
    {
        public bool IsPos { get; set; }

        public string ShopID { get; set; }

        public string PhoneNumber { get; set; }
        
        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
        
    }

    [Serializable]
    public class GetRechargeRecordsPara
    {
        public string PhoneNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
