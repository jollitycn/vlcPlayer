using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class RetailOrderAdvancePara
    {
        public string ShopID { get; set; }

        public string CostumeID { get; set; }

        /// <summary>
        /// 提前几天
        /// </summary>
        public int Advance { get; set; }
    }

    public class RetailPageAdvancePara : BasePagePara
    {
        public string OrderID { get; set; }

        public string ShopID { get; set; }

        public string CostumeID { get; set; }

        /// <summary>
        /// 提前几天
        /// </summary>
        public int Advance { get; set; }
    }
}
