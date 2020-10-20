using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.InteractEntity
{
    [Serializable]
    public class MyEmOrderDetail
    {
        public int AutoID { get; set; }

        public string CostumeID { get; set; }

        public string EmThumbnail { get; set; }

        public string EmTitle { get; set; }

        public int BuyCount { get; set; }

        public decimal SumMoney { get; set; }

        public string ColorName { get; set; }

        public string SizeName { get; set; }

        public string BrandName { get; set; }

        public decimal EmOnlinePrice { get; set; }

        public List<int> GiftTicketDenominations { get; set; }
    }
}
