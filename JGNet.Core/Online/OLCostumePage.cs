using JGNet.Core.InteractEntity;
using JGNet.Server.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Online
{
    public class OLCostumePage : BasePage
    {
        public List<OLCostume> OLCostumes { get; set; }
    }

    public class OLCostume
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal EmPrice { get; set; }

        public decimal PfOnlinePrice { get; set; }

        public string EmThumbnail { get; set; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        public bool IsFavorite { get; set; }

        public decimal PfDiscount { get; set; }

        public decimal PfPrice
        {
            get
            {
                return MathHelper.Rounded(this.PfOnlinePrice * this.PfDiscount, 0);
            }
        }

        /// <summary>
        /// 颜色图片
        /// </summary>
        public List<EmCostumePhoto> EmCostumePhotos { get; set; }

        public List<string> SizeNames { get; set; }

        /// <summary>
        /// 第一个string：原尺码名称XL，S 第二个string： 尺码别名 如28，29
        /// </summary>
        public Dictionary<string, string> SizeNameDIC { get; set; }
        public List<string> SizeNameList4Show
        {
            get
            {
                if (this.SizeNameDIC == null)
                {
                    return new List<string>();
                }
                List<string> sizeNames = new List<string>();
                foreach (KeyValuePair<string, string> item in this.SizeNameDIC)
                {
                    if (!sizeNames.Contains(item.Value))
                    {
                        sizeNames.Add(item.Value);
                    }
                }
                return sizeNames;
            }
        }

        public int EmSalesIncremental { get; set; }

        #region 扩展零售属性

        public decimal SalePrice { get; set; }
        /// <summary>
        /// 库存数
        /// </summary>
        public int StoreCount { get; set; }

        /// <summary>
        /// 销量
        /// </summary>
        public int QuantityOfSale { get; set; }

        /// <summary>
        /// 运费模版。如果为0，表示包邮。
        /// </summary>
        public int CarriageCostTemplateID { get; set; }

        /// <summary>
        /// 是否在线上商城中作为店主推荐？
        /// </summary>
        public bool EmIsRecommand { get; set; }

        /// <summary>
        /// 线上价
        /// </summary>
        public decimal EmOnlinePrice { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public string EmDetails { get; set; }

        /// <summary>
        /// 商品图片链接
        /// </summary>
        public List<string> LinkAddressList
        {
            //get
            //{
            //    if (this.EmCostumePhotos == null)
            //    {
            //        return new List<string>();
            //    }
            //    this.EmCostumePhotos.Sort((x, y) => { return x.DisplayIndex.CompareTo(y.DisplayIndex); });
            //    List<string> linkAddressList = new List<string>();
            //    foreach (EmCostumePhoto emCostumePhoto in this.EmCostumePhotos)
            //    {
            //        if (!string.IsNullOrEmpty(emCostumePhoto.ColorName))
            //        {
            //            linkAddressList.Add(emCostumePhoto.LinkAddress);
            //        }
            //    }
            //    return linkAddressList;
            //}
            get;set;
        }

        public string VideoUrl { get; set; }
        #endregion
    }
}
