using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public class CostumeStoreListPara
    {
        public string ShopID { get; set; }

        public string CostumeID { get; set; }

        /// <summary>
        /// 是否仅显示有效服装
        /// </summary>
        public bool IsOnlyShowValid { get; set; }

        /// <summary>
        /// 是否精确查询
        /// </summary>
        public bool IsAccurateQuery { get; set; }
    }

    [Serializable]
    public class CostumeItem
    {
        public CostumeItem() { }

        public CostumeItem(Costume costume, List<CostumeStore> costumeStoreList)
        {
            this.Costume = costume;
            this.CostumeStoreList = costumeStoreList;
        }

        public Costume Costume { get; set; }

        public List<CostumeStore> CostumeStoreList { get; set; }
    }

    /// <summary>
    /// 单店单款衣服单颜色库存
    /// </summary>
    [Serializable]
    public class ShopCostumeColorStore
    {
        public string ShopName { get; set; }

        public CostumeStore CostumeStore { get; set; }
    }

    /// <summary>
    /// 单店单款库存信息
    /// </summary>
    [Serializable]
    public class ShopCostumeItem
    {
        public string ShopID { get; set; }

        public CostumeItem CostumeItem { get; set; }
    }

    /// <summary>
    /// 单款销售明细集合
    /// </summary>
    [Serializable]
    public class CostumeSalesItem
    {


        public Costume Costume { get; set; }

        public List<CostumeSalesDetail> CostumeSalesDetailList { get;set; }
    }

    [Serializable]
    /// <summary>
    /// 单款销售明细
    /// </summary>
    public class CostumeSalesDetail
    {
        /// <summary>
        /// 款号
        /// </summary>
       public string CostumeID { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyCount { get; set; }
        /// <summary>
        /// 金额小计
        /// </summary>
        public decimal SumMoney { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
