using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class EmShoppingCart: IShoppingCart
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public string EmThumbnail { get; set; }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public string EmTitle { get; set; }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public Boolean Selected { get; set; }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public int CarriageCostTemplateID { get; set; }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public decimal CarriageCost { get; set; }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public decimal EmOnlinePrice { get; set; } 

        public decimal Price { get; set; }

        public string UserID
        {
            get { return this.PhoneNumber; }
        }
    }

    public partial class PfShoppingCart : IShoppingCart
    {
        public string UserID
        {
            get { return this.CostumeID; }
        }

        public string EmThumbnail { get; set; }
    }

    public interface IShoppingCart
    {
        int AutoID { get; set; }

        string UserID { get; }
        string CostumeID { get; set; }

        string ColorName { get; set; }

        string SizeName { get; set; }

        int BuyCount { get; set; }

        /// <summary>
        /// 商品颜色对应的图片链接
        /// </summary>
        string EmThumbnail { get; set; }

        DateTime CreateTime { get; set; }
    }
}
