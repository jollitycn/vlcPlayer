using JGNet.Core.MyEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class PfCustomerOrder
    {

        public String PfCustomerName
        {
            get; set;
        }

        public string StateName {

            get
            {
                try
                {
                    switch ((PfCustomerOrderState)this.State)
                    {
                        case PfCustomerOrderState.WaitDelivery:
                            return "待发货";
                        case PfCustomerOrderState.PartDelivery:
                            return "部分发货";
                        case PfCustomerOrderState.Invalid:
                            return "已作废";
                        case PfCustomerOrderState.Finish:
                            return "已完成";
                        case PfCustomerOrderState.All:
                            return "全部";
                        default:
                            return "";
                    }
                }
                catch
                {
                    return "";
                }
            }
        }

        public string PfCustomerDetailInfo
        {
            get
            {
                return string.Format("共{0}款{1}件", this.CostumeIDs.Count, this.Count4Costume);
            }
        }
        
        public List<string> CostumeIDs { get; set; }

        /// <summary>
        /// 款号件数
        /// </summary>
        public int Count4Costume { get; set; }
    }
}
