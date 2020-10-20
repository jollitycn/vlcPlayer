using JGNet.Server.Tools;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Settlement
{
    internal class DiscountSalesPromotion : ISalesPromotion
    {
        public decimal SettlementMoney(List<InSalesPromotionCostumeInfo> infoList, SalesPromotion salesPromotion, decimal minDiscount, Boolean round)
        {
            List<IPromotionRule> rules = salesPromotion.Rules;
            Dictionary<int, decimal> dict = new Dictionary<int, decimal>();
            foreach (IPromotionRule item in rules)
            {
                DiscountPromotionRule rule = (DiscountPromotionRule)item;
                if (!dict.ContainsKey(rule.HitBuyCout))
                {
                    dict.Add(rule.HitBuyCout, (decimal)rule.Discount / 100);
                }
            }
            int buyAllCount = 0;
            decimal allPrice = 0;
            foreach (InSalesPromotionCostumeInfo info in infoList)
            {
                buyAllCount += info.BuyCount;
                allPrice += (info.Price * info.BuyCount);
            }


            List<int> keyList = new List<int>();// dict.Keys.ToList();
            foreach (var item in dict.Keys)
            {
                keyList.Add(item);
            }
            keyList.Sort();
            for (int i = (keyList.Count - 1); i >= 0; i--)
            {
                int buyCountKey = keyList[i];
                if (buyAllCount >= buyCountKey)
                {
                    decimal value = dict[buyCountKey];
                    decimal min = minDiscount / 100;
                    decimal result = 0;
                    if (value < min)
                    {
                        if (round)
                        {
                            foreach (InSalesPromotionCostumeInfo info in infoList)
                            {
                                result += MathHelper.Rounded(info.Price * min, 0) * info.BuyCount;;
                            }
                            return result;
                        }
                        else
                        {
                            foreach (InSalesPromotionCostumeInfo info in infoList)
                            {
                                result += (info.Price * info.BuyCount) * min;
                            }
                            return result;
                        }
                    }
                    else
                    {
                        if (round)
                        {

                            foreach (InSalesPromotionCostumeInfo info in infoList)
                            {
                                result += MathHelper.Rounded(info.Price * value, 0) * info.BuyCount;
                            }
                            return result;
                        }
                        else
                        {
                            foreach (InSalesPromotionCostumeInfo info in infoList)
                            {
                                result += (info.Price * info.BuyCount) * value;
                            }
                            return result;
                        }
                    }
                }
            }

            return allPrice;
        }
    }
}
