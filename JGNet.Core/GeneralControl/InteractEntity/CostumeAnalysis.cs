using JGNet.Server.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.InteractEntity
{
    [Serializable]
    public class CostumeAnalysis
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 销售量
        /// </summary>
        public int QuantityOfSale { get; set; }

        /// <summary>
        /// 现有库存量
        /// </summary>
        public int SummaryCount { get; set; }

        /// <summary>
        /// 进货数
        /// </summary>
        public int PurchaseCount { get { return this.SummaryCount + this.QuantityOfSale; } }

        /// <summary>
        /// 售罄率
        /// </summary>
        public double SellThroughRate
        {
            get
            {
                int count = this.SummaryCount + this.QuantityOfSale;
                if (count == 0)
                {
                    return 0;
                }
                return (double)MathHelper.Rounded((decimal)QuantityOfSale / count, 2);
            }
        }
        
        
    }
}
