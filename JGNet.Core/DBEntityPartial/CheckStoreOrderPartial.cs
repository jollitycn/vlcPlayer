using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class CheckStoreOrder
    { 
        /// <summary>
        /// 盘点操作人姓名
        /// </summary>
        public string OperatorUserName { get; set; } 
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; } 
        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string CheckUserName { get; set; }

        /// <summary>
        /// 冲单用户名称
        /// </summary>
        public string CancelUserName { get; set; }

        public string StateName
        {
            get
            {
                return GetStateName((CheckStoreOrderState)this.State);
            }
        }

        public static string GetStateName(CheckStoreOrderState state)
        {
            string stateName = "";
            switch (state)
            {
                case CheckStoreOrderState.PendingReview:
                    stateName = "待审核";
                    break;
                case CheckStoreOrderState.Approved:
                    stateName = "已审核";
                    break;
                case CheckStoreOrderState.Canceled:
                    stateName = "已退回";
                    break;
                case CheckStoreOrderState.Expired:
                    stateName = "已失效";
                    break;
                case CheckStoreOrderState.Suspend:
                    stateName = "已挂单";
                    break;
                case CheckStoreOrderState.Checking:
                    stateName = "盘点中";
                    break;
                case CheckStoreOrderState.TaskIsCancel:
                    stateName = "已取消";
                    break;
                case CheckStoreOrderState.OverrideOrder:
                    stateName = "已冲单";
                    break;
                case CheckStoreOrderState.ChildOrder:
                    stateName = "子盘点";
                    break;

            }
            return stateName;
        }

        /// <summary>
        /// 修改标签  （盘点单状态为“已审核”或“待审核”时返回string.Empty，反之为“修改”）
        /// </summary>
        public string UpdateDetailName
        {
            get
            {
                if (this.State == (int)CheckStoreOrderState.Approved || this.State == (int)CheckStoreOrderState.PendingReview)
                {
                    return string.Empty;
                }
                return "编辑";
            }
        }


        /// <summary>
        /// 差异单标签  （盘点单状态为“已审核”返回“差异单”，反之为string.Empty）
        /// </summary>
        public string DifferenceDetailName
        {
            get
            {
                if (this.State == (int)CheckStoreOrderState.Approved)
                {
                    if (this.CheckStoreLostCount == 0 && this.CheckStoreWinCount == 0)
                    {
                        return string.Empty;
                    }
                    return "差异单明细";
                }
                return string.Empty;                
            }
        }

        public int DateInt { get { return new Date(this.CreateTime).ToDateInteger(); } }
        
    }
}
