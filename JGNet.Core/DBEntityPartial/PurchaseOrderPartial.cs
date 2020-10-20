using System;
using System.Collections.Generic;
using JGNet.Core;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using DataRabbit;
using CJBasic;

namespace JGNet
{
    public partial class PurchaseOrder
    {
        /// <summary>
        /// 冲单用户名称
        /// </summary>
        public string CancelUserName { get; set; }
        
        public String DestShopName { get; set; }
        public String ShopName { get; set; }
        public String UserName { get; set; }
        public String SupplierName { get; set; }
        public String StateName
        {
            get
            {
                if (IsCancel)
                {
                    return EnumHelper.GetDescription(PurchaseOrderStateEnum.Cancel);
                }
                else
                {
                    return EnumHelper.GetDescription((PurchaseOrderStateEnum)State);
                }
            }
        }

        /// <summary>
        /// 日期
        /// </summary>
        public int DateInt { get { return new Date(this.CreateTime).ToDateInteger(); } }

        public string Type { get; set; }

        public string OrderType
        {
            get
            {
                return this.TotalCount < 0 ? "退货" : "进货";
            }
        }

        public bool IsReturnType
        {
            get
            {
                if (string.IsNullOrEmpty(this.ID))
                {
                    return false;
                }
                return this.ID.StartsWith(OrderPrefix.ReturnOrder);
            }
        }
    }
}
