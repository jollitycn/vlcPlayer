using CJBasic.Helpers;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class DifferenceOrder : IStatisticabled
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 入库店名
        /// </summary>
        public String InboundShopName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 出库店名
        /// </summary>
        public string OutboundShopName { get; set; }

        public string ConfirmedName
        {
            get
            {
                if (this.Confirmed)
                {
                    return "已确认";
                }
                return "未确认";
            }
        }


        public bool Print { get; set; }
        private Decimal diffCountWin = 0;
        private Decimal diffCountLost= 0;

        public bool IsStatistics { get; set; }
        public Decimal DiffCountWin
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return (Decimal)Math.Round((TotalDiffCount + SumDiffCount) / 2.0);
                }
                return this.diffCountWin;
            }
            set
            {
                this.diffCountWin = value;
            }

        }
        public Decimal DiffCountLost
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return (Decimal)Math.Round((  SumDiffCount- TotalDiffCount) / 2.0);
                }
                return this.diffCountLost;
            }
            set
            {
                this.diffCountLost = value;
            }

        }

    }
}
