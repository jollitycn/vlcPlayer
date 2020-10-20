using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet
{
    [Serializable]
    public class RetailCostumePage : BasePage
    {
       public List<RetailCostume> RetailCostumeList { get; set; }

        /// <summary>
        /// 总应收金额
        /// </summary>
       public decimal TotalMoneyReceivedSum { get; set; }

        /// <summary>
        /// 商品总件数
        /// </summary>
       public int TotalCountSum { get; set; }
    }


    [Serializable]
    public class RetailCostume
    {
        public RetailOrder RetailOrder { get; set; }

        public List<RetailDetail> RetailDetailList{ get; set; }
    }

    /// <summary>
    /// 销售结果
    /// </summary>
    public enum RetailCostumeResult
    {
        [Description("成功")]
        Success = 0,

        /// <summary>
        /// 余额不足
        /// </summary>
        [Description("余额不足")]
        BalanceIsNotEnough,

        /// <summary>
        /// 积分不足
        /// </summary>
        [Description("积分不足")]
        IntegrationIsNotEnough,

        /// <summary>
        /// 库存不足
        /// </summary>
        [Description("库存不足")]
        CostumeStoreIsNotEnough,

        /// <summary>
        /// 会员不存在
        /// </summary
        [Description("会员不存在")]
        MemberIsNotExist,

        /// <summary>
        /// 电子优惠券使用有误
        /// </summary
        [Description("电子优惠券使用有误")]
        GiftTicketIsError,

        /// <summary>
        /// 内部错误。
        /// </summary>
        [Description("内部错误。")]
        Error
    }
}
