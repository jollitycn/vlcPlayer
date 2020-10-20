using JGNet.Core.Dev.MyEnum;
using JGNet.Server.Tools;
using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.RemotingEntity
{
    [Serializable]
    public class GoodMaori
    {
        public string Title { get; set; }

        public decimal CostPrice { get; set; }

        public decimal TotalMoneyReceivedActual { get; set; }

        public int Count { get; set; }

        public decimal Maori { get => this.TotalMoneyReceivedActual - this.CostPrice; }

        public double MaoriRates
        {
            get
            {
                if (this.TotalMoneyReceivedActual == 0)
                {
                    return 1;
                }

                return (double)MathHelper.Rounded(this.Maori / this.TotalMoneyReceivedActual, 2);
            }
        }
    }

    [Serializable]
    public class GetGoodMaorisPara
    {
        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public GroupType Type { get; set; }

        public string ShopID { get; set; }
    }
    
}
