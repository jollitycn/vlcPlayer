using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Settlement
{
    internal static class SalesPromotionFactory
    {
        public static ISalesPromotion CreatePromotion(PromotionTypeEnum promotionType)
        {
            if (PromotionTypeEnum.MJ == promotionType)
            {
                return new MJSalesPromotion();
            }

            if (PromotionTypeEnum.Discount == promotionType)
            {
                return new DiscountSalesPromotion();
            }

            return null;
        }
    }
}
