using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class ReturnOrderPagePara : BasePagePara
    {
        /// <summary>
        /// 单据编号
        /// </summary>
        public string ReturnOrderID { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 供应商id
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 是否开启限制日期查询
        /// </summary>
        public bool IsOpenDate { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }

        public PurchaseOrderState PurchaseOrderState { get; set; }

        public PurchaseOrderStateEnum PurchaseOrderStateEnum { get; set; }

        public string DestShopID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }

    public enum PurchaseOrderStateEnum
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,

        /// <summary>
        /// 挂单
        /// </summary>
        [Description("挂单")]
        HangUp,

        /// <summary>
        /// 冲单
        /// </summary>
        [Description("冲单")]
        Cancel
    }

    public enum PurchaseOrderState
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 采购进货
        /// </summary>
        [Description("采购进货")]
        Purchase,

        /// <summary>
        /// 采购退货
        /// </summary>
        [Description("采购退货")]
        Return
    }

    public class ReturnOrderPage : BasePage
    {
        public List<PurchaseOrder> ReturnOrderList { get; set; }
         
        public PurchaseOrder ReturnOrderSum { get; set; }
    }
}
