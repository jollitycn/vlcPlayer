using JGNet.Server.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public enum PrintTemplateType
    {
        /// <summary>
        /// 销售/退货单(小票)
        /// </summary>
        [Description("销售/退货单")]
        Retail = 0,

        /// <summary>
        /// 采购进货单
        /// </summary>
        [Description("采购进货单")]
        PurchaseIn = 1,

        /// <summary>
        /// 采购退货单
        /// </summary>
        [Description("采购退货单")]
        PurchaseOut = 2,

        /// <summary>
        /// 调拨单
        /// </summary>
        [Description("调拨单")]
        AllocateOrder = 3,

        /// <summary>
        /// 盘点单
        /// </summary>
        [Description("盘点单")]
        CheckStoreOrder = 4,

        /// <summary>
        /// 批发发货单
        /// </summary>
        [Description("批发发货单")]
        PfOrder = 5,

        /// <summary>
        /// 店铺补货申请单
        /// </summary>
        [Description("店铺补货申请单")]
        ReplenishOrder = 6,

        /// <summary>
        /// 日结存
        /// </summary>
        [Description("日结存")]
        DayReport = 7,

        /// <summary>
        /// 批发退货单
        /// </summary>
        [Description("批发退货单")]
        PfTOrder = 8,

        /// <summary>
        /// 销售/退货单(销售单)
        /// </summary>
        [Description("销售/退货单")]
        RetailOrder = 9
    }

    public class PrintTemplateInfo
    {
        public PrintTemplateType Type { get; set; }

        /// <summary>
        /// 打印份数
        /// </summary>
        public int PrintCount { get; set; }

        /// <summary>
        /// 单据名称
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// 系统变量
        /// </summary>
        public List<string> SystemVariables { get; set; }

        public string SystemVariable
        {
            get
            {
                return DataHelper.ListToString(this.SystemVariables);
            }
        }

        /// <summary>
        /// 表格列名
        /// </summary>
        public List<PrintColumnInfo> PrintColumnInfos { get; set; }

        public string ColumnName
        {
            get
            {
                List<string> list = new List<string>();
                foreach (PrintColumnInfo info in this.PrintColumnInfos)
                {
                    list.Add(info.ToString());
                }
                return DataHelper.ListToString(list);
            }
        }

        /// <summary>
        /// 结尾附加文字
        /// </summary>
        public string AdditionalText { get; set; }

        /// <summary>
        /// 是否打印商城二维码
        /// </summary>
        public bool IsPrintQRCode { get; set; }

        /// <summary>
        /// 一页行数
        /// </summary>
        public byte Rows { get; set; }
    }

    public class PrintColumnInfo
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 百分比
        /// </summary>
        public decimal Rate { get; set; }

        public override string ToString()
        {
            return string.Format("{0}#{1}", this.Name, this.Rate);
        }
    }
}
