using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class DifferenceOrderPagePara : BasePagePara
    {
        /// <summary>
        /// 仅获取出库方的差异单
        /// </summary>
        public bool IsOnlyGetOut { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string OrderID { get; set; }
        
        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 发货方是否已经确认
        /// </summary>
        public DifferenceOrderConfirmed DifferenceOrderConfirmed { get; set; }

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

        /// <summary>
        /// 单据类型
        /// </summary>
        public string OrderPrefixType { get; set; }
        
    }

    public class DifferenceOrderPage : BasePage
    {
        public List<DifferenceOrder> DifferenceOrderList { get; set; }
         
        public DifferenceOrder DifferenceOrderSum { get; set; }
    }
}
