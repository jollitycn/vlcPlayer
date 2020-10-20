using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class ShopSalesDetailPage : BasePage
    {
        public List<ShopSalesDetail> ShopSalesDetails { get; set; }

        public ShopSalesDetail Sum { get; set; }
    }

    [Serializable]
    public class ShopSalesDetail
    {
        public string CostumeID { get; set; }

        public string CostumeName { get; set; }

        public string PhotoThumbnailURL { get; set; }

        public string BrandName { get; set; }

        public decimal Price { get; set; }

        public decimal CostPrice { get; set; }

        public int QuantityOfSale { get; set; }

        public decimal SumMoney { get; set; }

        public string SizeCountString { get; set; }

        /// <summary>
        /// 平均折扣（用于界面显示 带%）
        /// </summary>
        public string AverageDiscountName
        {
            get
            {
                decimal value = this.QuantityOfSale * this.Price;
                if (value == 0)
                {
                    return string.Empty;
                }
                return ((int)(Server.Tools.MathHelper.Rounded(this.SumMoney / value, 2) * 100)).ToString();
            }
        }

        /// <summary>
        /// 平均售价
        /// </summary>
        public decimal AveragePirce
        {
            get
            {
                if (this.QuantityOfSale == 0)
                {
                    return 0;
                }
                return Server.Tools.MathHelper.Rounded(this.SumMoney / this.QuantityOfSale, 2);
            }
        }

        public Dictionary<string, Dictionary<string, int>> BuyDetailDict { get; set; }
    }
}
