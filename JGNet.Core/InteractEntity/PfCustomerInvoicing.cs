using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class PfCustomerInvoicing
    {
        public string PfCustomerID { set; get; }

        /// <summary>
        /// 客户
        /// </summary>
        public string PfCustomerName { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CostumeName { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 尺码
        /// </summary>
        public string SizeName { get; set; }

        public string DBSizeName { get; set; }

        /// <summary>
        /// 发货
        /// </summary>
        public int Delivery { get; set; }

        /// <summary>
        /// 销售
        /// </summary>
        public int Retail { get; set; }

        public int StartCount
        {
            get
            {
                return this.PfCustomerStore + this.Retail - this.Delivery;
            }
        }

        /// <summary>
        /// 库存
        /// </summary>
        public int PfCustomerStore { get; set; }

        public List<PfInvoicingItem> PfInvoicingItems { get; set; }

        public Dictionary<string, PfInvoicingItem> PfInvoicingItemDict { get; set; }

        public decimal CostPrice { get; set; }
    }

    [Serializable]
    public class PfInvoicingItem
    {
        public string PfCustomerID { get; set; }

        public string PfCustomerName { get; set; }

        /// <summary>
        /// 发货
        /// </summary>
        public int Delivery { get; set; }

        /// <summary>
        /// 销售
        /// </summary>
        public int Retail { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int PfCustomerStore { get; set; }
    }

    [Serializable]
    public class GetPfCustomerInvoicingPara
    {
        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public string PfCustomerID { get; set; }

        public string CostumeID { get; set; }
    }

    public class GetPfInvoicingPara : GetPfCustomerInvoicingPara
    {
        public string ColorName { get; set; }

        public string SizeName { get; set; }
    }
}
