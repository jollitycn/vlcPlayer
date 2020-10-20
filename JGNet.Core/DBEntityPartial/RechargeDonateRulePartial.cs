using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class RechargeDonateRule
    {
        private List<Rule> rules = null;
        public List<Rule> Rules
        {
            get
            {
                if (this.rules == null)
                {
                    string[] ruleExpressions = this.RuleExpression.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    this.rules = new List<Rule>();
                    foreach (string str in ruleExpressions)
                    {
                        string[] strs = str.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        Rule rule = new Rule
                        {
                            RechargeMoney = int.Parse(strs[0]),
                            DonateMoney = int.Parse(strs[1])
                        };
                        this.rules.Add(rule);
                    }
                }
                return this.rules;
            }
        }
        public void ClearRules() {
            rules = null;
        }
        
    }

    public class Rule
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 充值金额
        /// </summary>
        public int RechargeMoney { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 赠送金额
        /// </summary>
        public int DonateMoney { get; set; }

        public override string ToString()
        {
            return string.Format("充值：{0}, 赠送：{1}", this.RechargeMoney, this.DonateMoney);
        }
    }
}
