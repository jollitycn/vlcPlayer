using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class GetEmCostumePagePara : BasePagePara
    {
        /// <summary>
        /// 款号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 只列出推荐商品
        /// </summary>
        public bool IsOnlyShowRecommand { get; set; }

        /// <summary>
        /// 只列出新品
        /// </summary>
        public bool IsOnlyNew { get; set; }

        /// <summary>
        /// 只列出热卖
        /// </summary>
        public bool IsOnlyHot { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public EmCostumeInfoType Type { get; set; }

        /// <summary>
        /// 是否是线上商品
        /// </summary>
        public bool EmShowOnline { get; set; }

        private int classId = -1;
        /// <summary>
        /// 类别id：（不过滤：-1）
        /// </summary>
        public int ClassID
        {
            get
            {
                return this.classId;
            }
            set
            {
                this.classId = value;
            }
        }
    }

    public enum EmCostumeInfoType
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 零售
        /// </summary>
        [Description("零售")]
        Retail = 1,

        /// <summary>
        /// 批发
        /// </summary>
        [Description("批发")]
        Pf = 2
    }

    [Serializable]
    public class EmCostumePage : BasePage
    {
        public List<EmCostume> EmCostumes { get; set; }
    }

    [Serializable]
    public class EmCostume
    {
        /// <summary>
        /// 款号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 销量
        /// </summary>
        public int QuantityOfSale { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 在线上商城中显示的名称
        /// </summary>
        public string EmTitle { get; set; }

        /// <summary>
        /// 是否在线上商城中作为店主推荐？
        /// </summary>
        public bool EmIsRecommand { get; set; }

        /// <summary>
        /// 是否是新品
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// 是否是热卖
        /// </summary>
        public bool IsHot { get; set; }

        /// <summary>
        /// 缩略图的云存储地址
        /// </summary>
        public string EmThumbnail { get; set; }

        /// <summary>
        /// 缩略图的云存储下载后的数据，在前台使用
        /// </summary>
        public string EmThumbnailData { get; set; }

        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime EmOnlineTime { get; set; }

        /// <summary>
        /// 进货价
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// 吊牌价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 线上价
        /// </summary>
        public decimal EmOnlinePrice { get; set; }

        /// <summary>
        /// 批发价
        /// </summary>
        public decimal PfOnlinePrice { get; set; }
        
        /// <summary>
        /// 运费
        /// </summary>
        public decimal CarriageCost { get; set; }

        /// <summary>
        /// 会员收藏的商品id
        /// </summary>
        public int EmFavoriteCostumeID { get; set; }

        /// <summary>
        /// 运费模版。如果为0，表示包邮。
        /// </summary>
        public int CarriageCostTemplateID { get; set; }

        /// <summary>
        /// 品牌id
        /// </summary>
        public int BrandID { get; set; }
        public String BrandName { get; set; }

        /// <summary>
        /// 下架时间
        /// </summary>
        public DateTime EmOfflineTime { get; set; }

        /// <summary>
        /// 颜色（使用英文逗号分隔）
        /// </summary>
        public string Colors { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public string EmDetails { get; set; }

        /// <summary>
        /// 零售
        /// </summary>
        public bool EmShowOnline { get; set; }

        /// <summary>
        /// 批发
        /// </summary>
        public bool PfShowOnline { get; set; }

        public int EmSalesIncremental { get; set; }

        /// <summary>
        /// 线上吊牌价
        /// </summary>
        public decimal EmPrice { get; set; }
    }

}
