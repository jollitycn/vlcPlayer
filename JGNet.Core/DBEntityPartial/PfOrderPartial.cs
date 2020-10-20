using JGNet.Core.InteractEntity;
using JGNet.Core.MyEnum;
using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class PfOrder
    {
        public String AdminUserName { get; set; }
        public String PfCustomerName { get; set; }

        /// <summary>
        /// 冲单用户名称
        /// </summary>
        public string CancelUserName { get; set; }

        public String StateName
        {
            get
            {
                if (IsCancel)
                {
                    return EnumHelper.GetDescription(PfOrderStateEnum.Cancel);
                }
                else
                {
                    return EnumHelper.GetDescription((PfOrderStateEnum)State);
                }
            }
        }

        /// <summary>
        /// 是否支付
        /// </summary>
        public bool IsPay { get; set; }

        private string stateStr = "已发货";
        public string StateStr
        {
            get
            {
                return this.stateStr;
            }
            set
            {
                this.stateStr = value;
            }
        }
        
        public StateStrInt StateStrInt { get; set; }

        public String PayTypeName
        {
            get
            {

                String typeName = string.Empty;
                switch (PayType)
                {
                    case 0:
                        typeName = "记账";
                        break;
                    case 1:
                        typeName = "余额";
                        break;
                    case 2:
                        typeName = "现金";
                        break;
                    default:
                        break;
                }
                return typeName;
            }
        }
      
        public bool IsRetail { get; set; }

        public string OrderType { get; set; }
    }
}
