using JGNet.Core.Const;
using JGNet.Core.Tools;
using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class AllocateOrder
    {

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        //界面操作的设置
        public String Operation { get; set; }
        /// <summary>
        /// 调拨状态名称
        /// </summary>
        public string StateName
        {
            get
            {
                switch ((AllocateOrderState)this.State)
                {
                    case AllocateOrderState.Delivery:
                    case AllocateOrderState.Receipt:
                    case AllocateOrderState.Normal:
                        return EnumHelper.GetDescription(AllocateOrderState.Normal);
                    case AllocateOrderState.OverrideOrder:
                        return EnumHelper.GetDescription(AllocateOrderState.OverrideOrder);
                    case AllocateOrderState.HangUp:
                        return EnumHelper.GetDescription(AllocateOrderState.HangUp);
                }
                return string.Empty ;
            }
        }

        /// <summary>
        /// 冲单用户名称
        /// </summary>
        public string CancelUserName { get; set; }

        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 收货方店名
        /// </summary>
        public string DestShopName { get; set; }

        /// <summary>
        /// 发货店名
        /// </summary>
        public string SourceShopName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 能否收货名称  （不能收货为空，可以收货为“收货”）
        /// </summary>
        public string ReceiptDetailName
        {
            get;set;              
        }

        /// <summary>
        /// 入库明细标签  （入库单号为空返回string.Empty，反之为“入库明细”）
        /// </summary>
        public string InboundDetailName
        {
            get
            {
                if (string.IsNullOrEmpty(this.m_InboundOrderID))
                {
                    return string.Empty;
                }
                return "收货明细";
            }
        }
        
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        public int DateInt { get { return new Date(this.CreateTime).ToDateInteger(); } }

        /// <summary>
        /// 差异单是否已确认
        /// </summary>
        public bool DifferenceOrderConfirmed { get; set; }

        public bool IsPf { get; set; }
    }
}
