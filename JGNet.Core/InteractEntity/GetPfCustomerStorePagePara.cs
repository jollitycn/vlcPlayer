using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetPfCustomerStorePagePara : BasePagePara
    {
        public string CostumeID { get; set; }

        /// <summary>
        /// 品牌（-1：所有）
        /// </summary>
        public int BrandID { get; set; }

        /// <summary>
        /// 年份（-1：所有）
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 季节
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public string PfCustomerID { get; set; }
        
        /// <summary>
        /// 供应商
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 类别（-1：所有）
        /// </summary>
        public int ClassID { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 显示颜色
        /// </summary>
        public bool IsShowColor { get; set; }

        /// <summary>
        /// 仅显示非零库存
        /// </summary>
        public bool IsOnlyShowNotZero { get; set; }
    }

    public class PfCustomerStorePage : BasePage
    {
        public List<PfCustomerStore> PfCustomerStores { get; set; }
    }
}
