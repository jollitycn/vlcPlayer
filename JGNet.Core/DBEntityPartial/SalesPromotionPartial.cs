using JGNet.Core.Tools;
using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class SalesPromotion
    {

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String ShopNames { get; set;
        }

        public List<String> ShopIDList { get {
                List<String> shopIDList = new List<string>();
                if (!String.IsNullOrEmpty(ShopIDStr))
                {
                    String[] shopId = this.ShopIDStr.Split(',');
                    shopIDList = new List<string>(shopId);// shopId.ToList<String>();
                }
                return shopIDList;

            } }

        public String SalesPromotionTypeName {
            get {

              return  EnumHelper.GetDescription((PromotionTypeEnum)this.PromotionType);
                //String value = "";
                //switch (this.PromotionType) {
                //    case 0:
                //        value = "满减";
                //        break;
                //    case 1:
                //        value = "折扣";
                //        break;
                //    case 2:
                //        value = "一口价";
                //        break;
                //    default:
                //        value = "无";
                //        break;
                //}
                //return value;
            } }

        /// <summary>
        /// 促销状态
        /// </summary>
        public SalesPromotionState SalesPromotionState
        {
            get
            {
                if (!this.IsValid)
                {
                    return SalesPromotionState.Invalid;
                }
                DateTime startTime = new Date().DayStartTime;
                if (this.StartDate < startTime && this.EndDate < startTime)
                {
                    return SalesPromotionState.End;
                }
                else if (this.StartDate >= startTime && this.EndDate >= startTime)
                {
                    return SalesPromotionState.NotStart;
                }
                else if ((this.StartDate < startTime && this.EndDate > startTime))
                {
                    return SalesPromotionState.Start;
                }
                return SalesPromotionState.All;
            }
        }

        public String SalesPromotionStateName
        {
            get
            {
                return EnumHelper.GetDescription(this.SalesPromotionState);
            }
        }

        private List<IPromotionRule> rules = null;
        public List<IPromotionRule> Rules
        {
            get
            {
                if (this.rules == null)
                {
                    string[] ruleExpressions = this.RuleExpression.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    this.rules = new List<IPromotionRule>();
                    if (this.PromotionType == (int)PromotionTypeEnum.MJ)
                    {
                        foreach (string str in ruleExpressions)
                        {
                            string[] strs = str.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            MJPromotionRule mjPromotionRule = new MJPromotionRule();
                            mjPromotionRule.HitMoney = decimal.Parse(strs[0]);
                            mjPromotionRule.MinusMoney = decimal.Parse(strs[1]);
                            this.rules.Add(mjPromotionRule);
                        }
                    }
                    else if (this.PromotionType == (int)PromotionTypeEnum.Discount)
                    {
                        foreach (string str in ruleExpressions)
                        {
                            string[] strs = str.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            DiscountPromotionRule discountPromotionRule = new DiscountPromotionRule();
                            discountPromotionRule.HitBuyCout = int.Parse(strs[0]);
                            discountPromotionRule.Discount = int.Parse(strs[1]);
                            this.rules.Add(discountPromotionRule);
                        }
                    }
                }
                return this.rules;
            }           
        }
    }

    public interface IPromotionRule
    { 

        string ToString();
    }

    [Serializable]
    public class MJPromotionRule : IPromotionRule
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 达到多少元
        /// </summary>
        public decimal HitMoney { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 减多少元
        /// </summary>
        public decimal MinusMoney { get; set; }
        
        public override string ToString()
        {
            return string.Format("满{0}减{1}", this.HitMoney, this.MinusMoney);
        }
    }

    [Serializable]
    public class DiscountPromotionRule : IPromotionRule
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 达到多少件
        /// </summary>
        public int HitBuyCout { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 折扣
        /// </summary>
        public int Discount { get; set; }

        public override string ToString()
        {
            return string.Format("{0}件{1}折", this.HitBuyCout, (decimal)this.Discount / 10);
        }
    }
}