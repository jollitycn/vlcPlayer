using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    /// <summary>
    /// 查询商品分页参数
    /// </summary>
   [Serializable]
    public class SearchCostumePagePara
    {
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页最大数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 查询范围是否包含存在库存记录 （false 为全部商品商品范围， true为有库存记录的商品范围）
        /// </summary>
        public bool IsExistRecord { get; set; }

        /// <summary>
        /// 是否显示库存不为0的商品
        /// </summary>
        public bool IsOnlyShowNoZero { get; set; }

        /// <summary>
        /// 款号或名称
        /// </summary>
        public string CostumeIDOrName { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 是否为查询可销售的商品
        /// </summary>
        public bool IsRetail { get; set; }

        /// <summary>
        /// 供应商ID  （注：空字符串表示查询所有供应商）
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 品牌集合 （注：集合数量空表示查询所有品牌）
        /// </summary>
        public List<int> BrandIDList { get; set; }

        /// <summary>
        /// 大类集合 （注：集合数量空表示查询所有大类）
        /// </summary>
        public List<int> ClassIDs { get; set; }

        /// <summary>
        /// 季节集合 （注：集合数量空表示查询所有季节）
        /// </summary>
        public List<string> SeasonList { get; set; }

        /// <summary>
        /// 年份  （注：空字符串表示查询所有年份）
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 批发客户ID
        /// </summary>
        public string PfCustomerID { get; set; }

        /// <summary>
        /// 0: 店铺库存，1：客户库存，2，店铺和客户库存总和
        /// </summary>
        public SearchCostumeCountType CountType { get; set; }
    }

    public enum SearchCostumeCountType
    {
        Shop = 0,

        PfCustomer = 1,

        All = 2
    }

    [Serializable]
    public class SearchPfCostumePagePara : BasePagePara
    {
        /// <summary>
        /// 款号或名称
        /// </summary>
        public string CostumeIDOrName { get; set; }

        /// <summary>
        /// 批发客户ID
        /// </summary>
        public string PfCustomerID { get; set; }
        
        /// <summary>
        /// 供应商ID  （注：空字符串表示查询所有供应商）
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 品牌集合 （注：集合数量空表示查询所有品牌）
        /// </summary>
        public List<int> BrandIDList { get; set; }

        /// <summary>
        /// 大类集合 （注：集合数量空表示查询所有大类）
        /// </summary>
        public List<int> ClassIDs { get; set; }

        /// <summary>
        /// 季节集合 （注：集合数量空表示查询所有季节）
        /// </summary>
        public List<string> SeasonList { get; set; }

        /// <summary>
        /// 年份  （注：0表示查询所有年份）
        /// </summary>
        public int Year { get; set; }
    }
}
