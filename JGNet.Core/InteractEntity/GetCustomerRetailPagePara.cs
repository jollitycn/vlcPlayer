using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetCustomerRetailPagePara : BasePagePara
    {
        public string PfCustomerID { get; set; }

        public string CostumeID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Comment { get; set; }
    }

    public class CustomerRetailPage : BasePage
    {
        public List<PfCustomerRetailOrder> PfCustomerRetailOrders { get; set; }
    }
}
