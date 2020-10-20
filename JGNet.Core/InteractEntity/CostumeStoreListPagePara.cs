using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class CostumeStoreListPagePara : BasePagePara
    {
        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public int BrandID { get; set; }

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

        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 季节
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 仅显示含有负数库存
        /// </summary>
        public bool IsOnlyShowHaveNegative { get; set; }

        /// <summary>
        /// 仅显示非零库存
        /// </summary>
        public bool IsOnlyShowNotZero { get; set; }

        /// <summary>
        /// 是否展示所有店铺
        /// </summary>
        public bool IsShowAllShop { get; set; }

        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 供应商id
        /// </summary>
        public string SupplierID { get; set; }

        public CostumeStoreType CostumeStoreType { get; set; }
        
        /// <summary>
        /// 是否单款库存查询
        /// </summary>
        public bool IsSingleModel { get; set; }

        /// <summary>
        /// 是否勾选颜色
        /// </summary>
        public bool IsChooseColor { get; set; }

        /// <summary>
        /// 查看其他店
        /// </summary>
        public bool GetOtherShop { get; set; }

        /// <summary>
        /// 库存日期
        /// </summary>
        public Date Date { get; set; }
    }

    public class CostumeStoreListPage : BasePage
    {
        public List<CostumeItem> CostumeItemList { get; set; } 

        public CostumeStore CostumeStoreSum { get; set; }
    }

    public enum CostumeStoreType
    {
        /// <summary>
        /// 实际
        /// </summary>
        Actual = 0,

        /// <summary>
        /// 在途
        /// </summary>
        Transit
    }
}
