using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetConfusedStoreAdjustRecordPagePara : BasePagePara
    {
        public string ShopID { get; set; }

        public string CostumeID { get; set; }

        public string OrderID { get; set; }
    }

    public class ConfusedStoreAdjustRecordPage : BasePage
    {
        public List<ConfusedStoreAdjustRecord> ConfusedStoreAdjustRecords { get; set; }
    }
}
