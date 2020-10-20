using JGNet.Core.MyEnum;
using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetPfCustomerOrderPagePara : BasePagePara
    {
        public string CustomerOrderId { get; set; }

        public string CostumeID { get; set; }

        public string PfCustomerID { get; set; }

        public PfCustomerOrderState PfCustomerOrderState { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    public class PfCustomerOrderPage : BasePage
    {
        public List<PfCustomerOrder> PfCustomerOrders { get; set; }
    }
}
