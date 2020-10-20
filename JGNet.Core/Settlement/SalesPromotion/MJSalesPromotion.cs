using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Settlement
{
    internal class MJSalesPromotion : ISalesPromotion
    {
        public decimal SettlementMoney(List<InSalesPromotionCostumeInfo> infoList, SalesPromotion salesPromotion, decimal minDiscount,bool round)
        {
            List<IPromotionRule> rules = salesPromotion.Rules;
            Dictionary<decimal, decimal> dict = new Dictionary<decimal, decimal>();
            foreach (IPromotionRule item in rules)
            {
                MJPromotionRule rule = (MJPromotionRule)item;
                if (!dict.ContainsKey(rule.HitMoney))
                {
                    dict.Add(rule.HitMoney, rule.MinusMoney);
                }
            }
            decimal allPrice = 0;
            foreach (InSalesPromotionCostumeInfo info in infoList)
            {
                allPrice += (info.Price * info.BuyCount);
            }
            List<decimal> keyList = new List<decimal>();//dict.Keys.ToList();
            foreach (var item in dict.Keys)
            {
                keyList.Add(item);
            }
            keyList.Sort();
            for (int i = (keyList.Count - 1); i >= 0; i--)
            {
                decimal allPriceKey = keyList[i];
                if (allPrice >= allPriceKey)
                {
                    return allPrice - dict[allPriceKey];
                }
            }

            
            return allPrice;
        }
    }
}
