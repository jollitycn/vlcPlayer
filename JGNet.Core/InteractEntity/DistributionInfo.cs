using JGNet.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class DistributionInfo
    {
        public int Level { get; set; }

        public decimal CommissionRate1 { get; set; }
        public decimal Rate1
        {
            get
            {
                return this.CommissionRate1 / 100;
            }
        }

        public decimal CommissionRate2 { get; set; }
        public decimal Rate2
        {
            get
            {
                return this.CommissionRate2 / 100;
            }
        }

        public decimal CommissionRate3 { get; set; }
        public decimal Rate3
        {
            get
            {
                return this.CommissionRate3 / 100;
            }
        }

        public decimal CommissionRate4 { get; set; }
        public decimal Rate4
        {
            get
            {
                return this.CommissionRate4 / 100;
            }
        }

        public decimal CommissionRate5 { get; set; }
        public decimal Rate5
        {
            get
            {
                return this.CommissionRate5 / 100;
            }
        }

        public decimal CommissionRate6 { get; set; }
        public decimal Rate6
        {
            get
            {
                return this.CommissionRate6 / 100;
            }
        }

        public decimal CommissionRate7 { get; set; }
        public decimal Rate7
        {
            get
            {
                return this.CommissionRate7 / 100;
            }
        }

        public decimal CommissionRate8 { get; set; }
        public decimal Rate8
        {
            get
            {
                return this.CommissionRate8 / 100;
            }
        }

        public decimal CommissionRate9 { get; set; }
        public decimal Rate9
        {
            get
            {
                return this.CommissionRate9 / 100;
            }
        }

        public decimal CommissionRate10 { get; set; }
        public decimal Rate10
        {
            get
            {
                return this.CommissionRate10 / 100;
            }
        }

        public decimal CommissionFirstRate { get; set; }
        public decimal FirstRate
        {
            get
            {
                return this.CommissionFirstRate / 100;
            }
        }

        public decimal GetRate(int level)
        {
            //level += 1;
            switch (level)
            {
                case 1:
                    return this.Rate1;
                case 2:
                    return this.Rate2;
                case 3:
                    return this.Rate3;
                case 4:
                    return this.Rate4;
                case 5:
                    return this.Rate5;
                case 6:
                    return this.Rate6;
                case 7:
                    return this.Rate7;
                case 8:
                    return this.Rate8;
                case 9:
                    return this.Rate9;
                case 10:
                    return this.Rate10;
                default:
                    throw new MyException(string.Format("等级：{0}，不存在", level));
            }
        }
        
        public override string ToString()
        {
            return string.Format("{0}#{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}#{11}", this.Level, this.CommissionRate1, this.CommissionRate2 , this.CommissionRate3, this.CommissionRate4, this.CommissionRate5,
                this.CommissionRate6, this.CommissionRate7, this.CommissionRate8, this.CommissionRate9, this.CommissionRate10, this.CommissionFirstRate);
        }

        public static DistributionInfo FromString(string value)
        {
            string[] strs = value.Split("#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] rates = strs[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            DistributionInfo distributionInfo = new DistributionInfo()
            {
                Level = int.Parse(strs[0]),
                CommissionRate1 = decimal.Parse(rates[0]),
                CommissionRate2 = decimal.Parse(rates[1]),
                CommissionRate3 = decimal.Parse(rates[2]),
                CommissionRate4 = decimal.Parse(rates[3]),
                CommissionRate5 = decimal.Parse(rates[4]),
                CommissionRate6 = decimal.Parse(rates[5]),
                CommissionRate7 = decimal.Parse(rates[6]),
                CommissionRate8 = decimal.Parse(rates[7]),
                CommissionRate9 = decimal.Parse(rates[8]),
                CommissionRate10 = decimal.Parse(rates[9]),
                CommissionFirstRate = decimal.Parse(strs[2])
            };
            return distributionInfo;
        }
    }
}
