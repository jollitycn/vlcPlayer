using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Settlement
{
    internal interface ISalesPromotion
    {
        decimal SettlementMoney(List<InSalesPromotionCostumeInfo> infoList, SalesPromotion salesPromotion, decimal minDiscount,bool round);
    }
}
