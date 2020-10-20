using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]    
    public class PaymentDetailSummary
    {

        #region 充值收款
        /// <summary>
        /// 会员充值总金额 总和
        /// </summary>
        public decimal TotalRechargeSum { get; set; }

        /// <summary>
        /// 充值时现金收入总金额 总和
        /// </summary>
        public decimal RechargeInCashSum { get; set; }

        /// <summary>
        /// 充值时收到的银联卡总金额 总和
        /// </summary>
        public decimal RechargeInBankCardSum { get; set; }

        /// <summary>
        /// 充值时收到的微信总金额 总和
        /// </summary>
        public decimal RechargeInWeiXinSum { get; set; }

        /// <summary>
        /// 充值时收到的支付宝总金额 总和
        /// </summary>
        public decimal RechargeInAlipaySum { get; set; }

        /// <summary>
        /// 会员充值时赠送的总金额 总和
        /// </summary>
        public decimal Donate4RechargeSum { get; set; }

        #endregion

        #region 销售收款
        /// <summary>
        /// 销售收入总金额（扣除退货） 总和
        /// </summary>
        public decimal SalesTotalMoneySum { get; set; }

        /// <summary>
        /// 销售时现金收入总金额（扣除退货） 总和
        /// </summary>
        public decimal SalesInCashSum { get; set; }

        /// <summary>
        /// 销售时收到的银联卡总金额（扣除退货） 总和
        /// </summary>
        public decimal SalesInBankCardSum { get; set; }

        /// <summary>
        /// 销售时收到的微信总金额（扣除退货） 总和
        /// </summary>
        public decimal SalesInWeiXinSum { get; set; }

        /// <summary>
        /// 销售时收到的支付宝总金额（扣除退货） 总和
        /// </summary>
        public decimal SalesInAlipaySum { get; set; }

        /// <summary>
        /// 销售时会员使用VIP卡付款的总金额（扣除退货） 总和
        /// </summary>
        public decimal SalesInVipBalanceSum { get; set; }

        /// <summary>
        /// 销售时会员使用卡积分返现的总金额（扣除退货） 总和
        /// </summary>
        public decimal SalesInVipIntegrationSum { get; set; }

        /// <summary>
        /// 销售时会员使用电子优惠券的总金额(退货不返还)
        /// </summary>
        public decimal SalesInGiftTicketSum { get; set; }

        /// <summary>
        /// 销售的商品总数量（扣除退货） 总和
        /// </summary>
        public int QuantityOfSaleSum { get; set; }

        /// <summary>
        /// 销售单数（扣除退货） 总和
        /// </summary>
        public int SalesCountSum { get; set; } 
        #endregion

    }
}
