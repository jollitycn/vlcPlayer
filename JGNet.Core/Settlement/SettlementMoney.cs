using JGNet.Core.InteractEntity;
using JGNet.Core.Settlement;
using JGNet.Server.Tools;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core
{
    public class RefundMoney
    {
        public decimal RefundIntegration { get; set; }

        public decimal RefundStoredCard { get; set; }

        public decimal RefundCash { get; set; }
    }

    internal class RetailCostumeInfo
    {
        public decimal Price { get; set; }

        public int BuyCount { get; set; }
    }

    internal class InSalesPromotionCostumeInfo
    {
        public decimal Price { get; set; }

        public int BuyCount { get; set; }
    }

    public class SettlementMoney
    {
        private bool balanceRound;

        public SettlementMoney(bool balanceRound)
        {
            this.balanceRound = balanceRound;
        }

        /// <summary>
        /// 结算销售单的应收金额
        /// </summary>
        /// <param name="retailCostume"></param>
        /// <returns></returns>
        public decimal GetTotalMoneySupposed(RetailCostume retailCostume, SalesPromotion salesPromotion, decimal minDiscount)
        {
            Dictionary<string, RetailCostumeInfo> retailDictionary = new Dictionary<string, RetailCostumeInfo>();
            Dictionary<string, InSalesPromotionCostumeInfo> inSalesPromotionDict = new Dictionary<string, InSalesPromotionCostumeInfo>();
            this.GetRetailStatus(retailCostume, retailDictionary, inSalesPromotionDict);

            return this.GetTotalMoneySupposed(retailDictionary, inSalesPromotionDict, salesPromotion, minDiscount);
        }

        /// <summary>
        /// 获取退货后退款情况
        /// </summary>
        /// <param name="retailCostume"></param>
        /// <param name="refundCostume"></param>
        /// <param name="salesPromotion"></param>
        /// <returns></returns>
        public RefundMoney GetRefundMoney(RetailCostume retailCostume, RefundCostume refundCostume, decimal moneyBuyByTicket, SalesPromotion salesPromotion, decimal minDiscount)
        {
            if (retailCostume.RetailOrder.ID != refundCostume.RefundOrder.OriginOrderID)
            {
                throw new Exception("销售单的id与退货单id不一致");
            }
            else
            {

               /* foreach (RetailDetail rDetailSource in retailCostume.RetailDetailList)
                {
                    foreach (RetailDetail rDetailRe in refundCostume.RefundDetailList)
                    {
                        if (rDetailSource.RetailOrderID == refundCostume.RefundOrder.OriginOrderID  && rDetailSource.CostumeID == rDetailRe.CostumeID 
                            && rDetailSource.ColorName==rDetailRe.ColorName && rDetailSource.BrandName==rDetailRe.BrandName && rDetailSource.SizeName==rDetailRe.SizeName)
                        {
                            rDetailSource.SalePrice = rDetailRe.SalePrice;
                        }
                    }
                }*/
            }
            if (retailCostume.RetailOrder.IsNotPay)
            {
                return new RefundMoney();
            }

            Dictionary<string, RetailCostumeInfo> retailDictionary = new Dictionary<string, RetailCostumeInfo>();
            Dictionary<string, InSalesPromotionCostumeInfo> inSalesPromotionDict = new Dictionary<string, InSalesPromotionCostumeInfo>();
            //有活动的时候没有打折
            this.GetRetailStatus(retailCostume, retailDictionary, inSalesPromotionDict);

            Dictionary<string, int> refundDict = this.GetRefundStatus(refundCostume);
            foreach (KeyValuePair<string, int> kvp in refundDict)
            {
                if (retailDictionary.ContainsKey(kvp.Key))
                {
                    retailDictionary[kvp.Key].BuyCount += kvp.Value;
                }
                else if (inSalesPromotionDict.ContainsKey(kvp.Key))
                {
                    inSalesPromotionDict[kvp.Key].BuyCount += kvp.Value;
                }
            }
            
            decimal supporedMoney = this.GetTotalMoneySupposed(retailDictionary, inSalesPromotionDict, salesPromotion, minDiscount);
            // 应收金额（因为要退积分，不能去掉）+要买的那件衣服的优惠券-总的优惠金额-结算销售单的应收金额-运费
            decimal refundMoney = retailCostume.RetailOrder.TotalMoneyReceived + moneyBuyByTicket - retailCostume.RetailOrder.MoneyDeductedByTicket
                - supporedMoney - retailCostume.RetailOrder.CarriageCost;
            if (refundMoney <= 0)
            {
                return new RefundMoney();
            }

            if (refundMoney <= retailCostume.RetailOrder.MoneyIntegration)
            {
                return new RefundMoney()
                {
                    RefundIntegration = refundMoney,
                    RefundStoredCard = 0,
                    RefundCash = 0
                };
            }
            else
            {
                refundMoney -= retailCostume.RetailOrder.MoneyIntegration;
                if (refundMoney <= retailCostume.RetailOrder.MoneyVipCard)
                {
                    return new RefundMoney()
                    {
                        RefundIntegration = retailCostume.RetailOrder.MoneyIntegration,
                        RefundStoredCard = refundMoney,
                        RefundCash = 0
                    };
                }
                else
                {
                    refundMoney -= retailCostume.RetailOrder.MoneyVipCard;
                    return new RefundMoney()
                    {
                        RefundIntegration = retailCostume.RetailOrder.MoneyIntegration,
                        RefundStoredCard = retailCostume.RetailOrder.MoneyVipCard,
                        RefundCash = refundMoney
                    };
                }
            }
        }
         
        /// <summary>
        /// 结算销售单的应收金额
        /// </summary>
        /// <param name="retailDictionary">不参与促销的订单</param>
        /// <param name="inSalesPromotionDict">参与促销活动的订单</param>
        /// <param name="salesPromotion">促销活动</param>
        /// <param name="minDiscount">最低折扣</param>
        /// <returns>应收的金额</returns>
        private decimal GetTotalMoneySupposed(Dictionary<string, RetailCostumeInfo> retailDictionary, Dictionary<string, InSalesPromotionCostumeInfo> inSalesPromotionDict, SalesPromotion salesPromotion, decimal minDiscount)
        {
            decimal totalMoney = 0;
            foreach (KeyValuePair<string, RetailCostumeInfo> kvp in retailDictionary)
            {
                if (balanceRound)
                {
                    totalMoney += MathHelper.Rounded(kvp.Value.Price, 0) * kvp.Value.BuyCount;
                }
                else
                {
                    totalMoney += kvp.Value.Price  * kvp.Value.BuyCount;
                }
            }
            if (inSalesPromotionDict.Count == 0)
            {
                return totalMoney;
            }
            if (salesPromotion == null)
            {
                return totalMoney;
            }
            ISalesPromotion promotion = SalesPromotionFactory.CreatePromotion((PromotionTypeEnum)salesPromotion.PromotionType);
            if (promotion == null)
            {
                return totalMoney;
            }
            if (salesPromotion.Rules.Count == 0)
            {
                return totalMoney;
            }

            List<InSalesPromotionCostumeInfo> list = new List<InSalesPromotionCostumeInfo>(inSalesPromotionDict.Values); //inSalesPromotionDict.Values.ToList();
            totalMoney += promotion.SettlementMoney(list, salesPromotion, minDiscount,balanceRound);

            return totalMoney;
        }

        /// <summary>
        /// 获取每件款号颜色的销售件数
        /// </summary>
        /// <param name="retailCostume"></param>
        /// <param name="dictionary">key:"ShopID_CostumeID_ColorName_SizeName", value:销售件数</param>
        /// <param name="inSalesPromotionDict">key:"ShopID_CostumeID_ColorName_SizeName", value:销售件数</param>
        private void GetRetailStatus(RetailCostume retailCostume, Dictionary<string, RetailCostumeInfo> dictionary, Dictionary<string, InSalesPromotionCostumeInfo> inSalesPromotionDict)
        {
            List<RetailDetail> list = retailCostume.RetailDetailList;
            foreach (RetailDetail detail in list)
            {
                string key = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", retailCostume.RetailOrder.ShopID, detail.CostumeID, detail.ColorName, detail.SizeName, detail.Discount, detail.InSalesPromotion, detail.GiftTickets);
                if (!detail.InSalesPromotion)
                {
                    if (!dictionary.ContainsKey(key))
                    {
                        //按折扣算，存在小数点，误差问题，直接用小计金额得出每件衣服价格
                        dictionary.Add(key, new RetailCostumeInfo() { BuyCount = detail.BuyCount, Price = detail.SumMoney / detail.BuyCount });
                    }
                    else
                    {
                        dictionary[key].BuyCount += detail.BuyCount;
                    }
                }
                else
                {
                    if (!inSalesPromotionDict.ContainsKey(key))
                    {
                        //促销活动的衣服没有折扣
                        inSalesPromotionDict.Add(key, new InSalesPromotionCostumeInfo() { BuyCount = detail.BuyCount, Price = detail.SalePrice });
                    }
                    else
                    {
                        inSalesPromotionDict[key].BuyCount += detail.BuyCount;
                    }
                }
            }
        }

        /// <summary>
        /// 获取每件款号颜色的退货件数
        /// </summary>
        /// <param name="refundCostume"></param>
        /// <returns>key:"ShopID_CostumeID_ColorName_SizeName", value:退货件数</returns>
        private Dictionary<string, int> GetRefundStatus(RefundCostume refundCostume)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            List<RetailDetail> list = refundCostume.RefundDetailList;
            foreach (RetailDetail detail in list)
            {
                string key = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", refundCostume.RefundOrder.ShopID, detail.CostumeID, detail.ColorName, detail.SizeName, detail.Discount, detail.InSalesPromotion, detail.GiftTickets);
                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, 0);
                }
                dictionary[key] = dictionary[key] + detail.BuyCount;
            }
            return dictionary;
        }
    }
}
