using JGNet.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class CommissionTemplate
    {
        public decimal FirstRateValue
        {
            get
            {
                return this.FirstRate / 100;
            }
        }

        public decimal GetRate(int level)
        {
            //level += 1;
            switch (level)
            {
                case 1:
                    return this.Rate1 / 100;
                case 2:
                    return this.Rate2 / 100;
                case 3:
                    return this.Rate3 / 100;
                case 4:
                    return this.Rate4 / 100;
                case 5:
                    return this.Rate5 / 100;
                case 6:
                    return this.Rate6 / 100;
                case 7:
                    return this.Rate7 / 100;
                case 8:
                    return this.Rate8 / 100;
                case 9:
                    return this.Rate9 / 100;
                case 10:
                    return this.Rate10 / 100;
                default:
                    throw new MyException(string.Format("等级：{0}，不存在", level));
            }
        }
    }
}
