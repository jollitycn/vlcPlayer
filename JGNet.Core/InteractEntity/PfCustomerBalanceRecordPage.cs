using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class PfCustomerBalanceRecordPage : BasePage
    {
        public List<PfCustomerBalanceRecord> PfCustomerBalanceRecords { get; set; }

        public PfCustomerBalanceRecord PfCustomerBalanceRecordSum { set; get; }
    }

    public class GetPfCustomerBalanceRecordPagePara : BasePagePara
    {
        public string PfCustomerID { get; set; }

        public PfCustomerBalanceType PfCustomerBalanceType { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }
}
