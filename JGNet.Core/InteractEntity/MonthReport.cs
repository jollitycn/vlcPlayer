using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class MonthReport : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "MonthReport" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _ReportMonth = "ReportMonth" ;
		public const string _AdminUserID = "AdminUserID" ;
		public const string _PreTotalCount = "PreTotalCount" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _AllocateInCount = "AllocateInCount" ;
		public const string _PurchaseInCount = "PurchaseInCount" ;
		public const string _ReturnCount = "ReturnCount" ;
		public const string _AllocateOutCount = "AllocateOutCount" ;
		public const string _ScrapOutCount = "ScrapOutCount" ;
		public const string _DiffAdjustCount = "DiffAdjustCount" ;
		public const string _CheckStoreWinCount = "CheckStoreWinCount" ;
		public const string _CheckStoreLostCount = "CheckStoreLostCount" ;
		public const string _NotConfirmedCount = "NotConfirmedCount" ;
		public const string _PreCash = "PreCash" ;
		public const string _CashInOthers = "CashInOthers" ;
		public const string _CashOut = "CashOut" ;
		public const string _CashDeliverUp = "CashDeliverUp" ;
		public const string _CashCurrent = "CashCurrent" ;
		public const string _TotalRecharge = "TotalRecharge" ;
		public const string _RechargeInCash = "RechargeInCash" ;
		public const string _RechargeInBankCard = "RechargeInBankCard" ;
		public const string _RechargeInWeiXin = "RechargeInWeiXin" ;
		public const string _RechargeInAlipay = "RechargeInAlipay" ;
		public const string _Donate4Recharge = "Donate4Recharge" ;
		public const string _SalesTotalMoney = "SalesTotalMoney" ;
		public const string _SalesInCash = "SalesInCash" ;
		public const string _SalesInBankCard = "SalesInBankCard" ;
		public const string _SalesInWeiXin = "SalesInWeiXin" ;
		public const string _SalesInAlipay = "SalesInAlipay" ;
		public const string _SalesInVipBalance = "SalesInVipBalance" ;
		public const string _SalesInVipIntegration = "SalesInVipIntegration" ;
		public const string _QuantityOfSale = "QuantityOfSale" ;
		public const string _SalesCount = "SalesCount" ;
		public const string _RefundTotalMoney = "RefundTotalMoney" ;
		public const string _RefundInCash = "RefundInCash" ;
		public const string _RefundInVipBalance = "RefundInVipBalance" ;
		public const string _RefundInVipIntegration = "RefundInVipIntegration" ;
		public const string _QuantityOfRefund = "QuantityOfRefund" ;
		public const string _RefundCount = "RefundCount" ;
		public const string _CarriageCost = "CarriageCost" ;
		public const string _EmQuantityOfSale = "EmQuantityOfSale" ;
		public const string _EmQuantityOfRefund = "EmQuantityOfRefund" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _Remarks = "Remarks" ;
		public const string _ManualConfirm = "ManualConfirm" ;
		public const string _TotalPriceInStore = "TotalPriceInStore" ;
		public const string _TotalCostInStore = "TotalCostInStore" ;
		public const string _TotalMemberBalance = "TotalMemberBalance" ;
		public const string _TotalMemberBalance2 = "TotalMemberBalance2" ;
		public const string _SalesInGiftTicket = "SalesInGiftTicket" ;
		public const string _PfDeliveryCount = "PfDeliveryCount" ;
		public const string _PfReturnCount = "PfReturnCount" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自增ID（主键）
		/// </summary>
		public System.Int32 AutoID
		{
			get
			{
				return this.m_AutoID ;
			}
			set
			{
				this.m_AutoID = value ;
			}
		}
		#endregion
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 店铺ID
		/// </summary>
		public System.String ShopID
		{
			get
			{
				return this.m_ShopID ;
			}
			set
			{
				this.m_ShopID = value ;
			}
		}
		#endregion
	
		#region ReportMonth
		private System.Int32 m_ReportMonth = 0 ; 
		/// <summary>
		/// ReportMonth 哪一天的月报，固定8位数字，如20180302
		/// </summary>
		public System.Int32 ReportMonth
		{
			get
			{
				return this.m_ReportMonth ;
			}
			set
			{
				this.m_ReportMonth = value ;
			}
		}
		#endregion
	
		#region AdminUserID
		private System.String m_AdminUserID = "" ; 
		/// <summary>
		/// AdminUserID 操作人的ID
		/// </summary>
		public System.String AdminUserID
		{
			get
			{
				return this.m_AdminUserID ;
			}
			set
			{
				this.m_AdminUserID = value ;
			}
		}
		#endregion
	
		#region PreTotalCount
		private System.Int32 m_PreTotalCount = 0 ; 
		/// <summary>
		/// PreTotalCount 上月结存数量
		/// </summary>
		public System.Int32 PreTotalCount
		{
			get
			{
				return this.m_PreTotalCount ;
			}
			set
			{
				this.m_PreTotalCount = value ;
			}
		}
		#endregion
	
		#region TotalCount
		private System.Int32 m_TotalCount = 0 ; 
		/// <summary>
		/// TotalCount 当月结存数量
		/// </summary>
		public System.Int32 TotalCount
		{
			get
			{
				return this.m_TotalCount ;
			}
			set
			{
				this.m_TotalCount = value ;
			}
		}
		#endregion
	
		#region AllocateInCount
		private System.Int32 m_AllocateInCount = 0 ; 
		/// <summary>
		/// AllocateInCount 当月调拨入库数量（从其它店铺或总仓）
		/// </summary>
		public System.Int32 AllocateInCount
		{
			get
			{
				return this.m_AllocateInCount ;
			}
			set
			{
				this.m_AllocateInCount = value ;
			}
		}
		#endregion
	
		#region PurchaseInCount
		private System.Int32 m_PurchaseInCount = 0 ; 
		/// <summary>
		/// PurchaseInCount 当月进货入库数量（供应商）
		/// </summary>
		public System.Int32 PurchaseInCount
		{
			get
			{
				return this.m_PurchaseInCount ;
			}
			set
			{
				this.m_PurchaseInCount = value ;
			}
		}
		#endregion
	
		#region ReturnCount
		private System.Int32 m_ReturnCount = 0 ; 
		/// <summary>
		/// ReturnCount 当月采购退货出库数量（给供应商）
		/// </summary>
		public System.Int32 ReturnCount
		{
			get
			{
				return this.m_ReturnCount ;
			}
			set
			{
				this.m_ReturnCount = value ;
			}
		}
		#endregion
	
		#region AllocateOutCount
		private System.Int32 m_AllocateOutCount = 0 ; 
		/// <summary>
		/// AllocateOutCount 当月调拨数量（给其它店铺或总仓）
		/// </summary>
		public System.Int32 AllocateOutCount
		{
			get
			{
				return this.m_AllocateOutCount ;
			}
			set
			{
				this.m_AllocateOutCount = value ;
			}
		}
		#endregion
	
		#region ScrapOutCount
		private System.Int32 m_ScrapOutCount = 0 ; 
		/// <summary>
		/// ScrapOutCount 当月报损出库数量
		/// </summary>
		public System.Int32 ScrapOutCount
		{
			get
			{
				return this.m_ScrapOutCount ;
			}
			set
			{
				this.m_ScrapOutCount = value ;
			}
		}
		#endregion
	
		#region DiffAdjustCount
		private System.Int32 m_DiffAdjustCount = 0 ; 
		/// <summary>
		/// DiffAdjustCount 调拨差异调整数量
		/// </summary>
		public System.Int32 DiffAdjustCount
		{
			get
			{
				return this.m_DiffAdjustCount ;
			}
			set
			{
				this.m_DiffAdjustCount = value ;
			}
		}
		#endregion
	
		#region CheckStoreWinCount
		private System.Int32 m_CheckStoreWinCount = 0 ; 
		/// <summary>
		/// CheckStoreWinCount 盘盈数
		/// </summary>
		public System.Int32 CheckStoreWinCount
		{
			get
			{
				return this.m_CheckStoreWinCount ;
			}
			set
			{
				this.m_CheckStoreWinCount = value ;
			}
		}
		#endregion
	
		#region CheckStoreLostCount
		private System.Int32 m_CheckStoreLostCount = 0 ; 
		/// <summary>
		/// CheckStoreLostCount 盘亏数
		/// </summary>
		public System.Int32 CheckStoreLostCount
		{
			get
			{
				return this.m_CheckStoreLostCount ;
			}
			set
			{
				this.m_CheckStoreLostCount = value ;
			}
		}
		#endregion
	
		#region NotConfirmedCount
		private System.Int32 m_NotConfirmedCount = 0 ; 
		/// <summary>
		/// NotConfirmedCount 未确认的单据总数
		/// </summary>
		public System.Int32 NotConfirmedCount
		{
			get
			{
				return this.m_NotConfirmedCount ;
			}
			set
			{
				this.m_NotConfirmedCount = value ;
			}
		}
		#endregion
	
		#region PreCash
		private System.Decimal m_PreCash = 0 ; 
		/// <summary>
		/// PreCash 上月现金剩余总金额（不包括银行汇款）
		/// </summary>
		public System.Decimal PreCash
		{
			get
			{
				return this.m_PreCash ;
			}
			set
			{
				this.m_PreCash = value ;
			}
		}
		#endregion
	
		#region CashInOthers
		private System.Decimal m_CashInOthers = 0 ; 
		/// <summary>
		/// CashInOthers 其他现金收入
		/// </summary>
		public System.Decimal CashInOthers
		{
			get
			{
				return this.m_CashInOthers ;
			}
			set
			{
				this.m_CashInOthers = value ;
			}
		}
		#endregion
	
		#region CashOut
		private System.Decimal m_CashOut = 0 ; 
		/// <summary>
		/// CashOut 现金支出，如物业费、交通费
		/// </summary>
		public System.Decimal CashOut
		{
			get
			{
				return this.m_CashOut ;
			}
			set
			{
				this.m_CashOut = value ;
			}
		}
		#endregion
	
		#region CashDeliverUp
		private System.Decimal m_CashDeliverUp = 0 ; 
		/// <summary>
		/// CashDeliverUp 上缴给老板的现金
		/// </summary>
		public System.Decimal CashDeliverUp
		{
			get
			{
				return this.m_CashDeliverUp ;
			}
			set
			{
				this.m_CashDeliverUp = value ;
			}
		}
		#endregion
	
		#region CashCurrent
		private System.Decimal m_CashCurrent = 0 ; 
		/// <summary>
		/// CashCurrent 当月现金结余
		/// </summary>
		public System.Decimal CashCurrent
		{
			get
			{
				return this.m_CashCurrent ;
			}
			set
			{
				this.m_CashCurrent = value ;
			}
		}
		#endregion
	
		#region TotalRecharge
		private System.Decimal m_TotalRecharge = 0 ; 
		/// <summary>
		/// TotalRecharge 会员充值中总金额
		/// </summary>
		public System.Decimal TotalRecharge
		{
			get
			{
				return this.m_TotalRecharge ;
			}
			set
			{
				this.m_TotalRecharge = value ;
			}
		}
		#endregion
	
		#region RechargeInCash
		private System.Decimal m_RechargeInCash = 0 ; 
		/// <summary>
		/// RechargeInCash 充值时现金收入总金额
		/// </summary>
		public System.Decimal RechargeInCash
		{
			get
			{
				return this.m_RechargeInCash ;
			}
			set
			{
				this.m_RechargeInCash = value ;
			}
		}
		#endregion
	
		#region RechargeInBankCard
		private System.Decimal m_RechargeInBankCard = 0 ; 
		/// <summary>
		/// RechargeInBankCard 充值时收到的银联卡总金额
		/// </summary>
		public System.Decimal RechargeInBankCard
		{
			get
			{
				return this.m_RechargeInBankCard ;
			}
			set
			{
				this.m_RechargeInBankCard = value ;
			}
		}
		#endregion
	
		#region RechargeInWeiXin
		private System.Decimal m_RechargeInWeiXin = 0 ; 
		/// <summary>
		/// RechargeInWeiXin 充值时收到的微信总金额
		/// </summary>
		public System.Decimal RechargeInWeiXin
		{
			get
			{
				return this.m_RechargeInWeiXin ;
			}
			set
			{
				this.m_RechargeInWeiXin = value ;
			}
		}
		#endregion
	
		#region RechargeInAlipay
		private System.Decimal m_RechargeInAlipay = 0 ; 
		/// <summary>
		/// RechargeInAlipay 充值时收到的支付宝总金额
		/// </summary>
		public System.Decimal RechargeInAlipay
		{
			get
			{
				return this.m_RechargeInAlipay ;
			}
			set
			{
				this.m_RechargeInAlipay = value ;
			}
		}
		#endregion
	
		#region Donate4Recharge
		private System.Decimal m_Donate4Recharge = 0 ; 
		/// <summary>
		/// Donate4Recharge 会员充值时赠送的总金额
		/// </summary>
		public System.Decimal Donate4Recharge
		{
			get
			{
				return this.m_Donate4Recharge ;
			}
			set
			{
				this.m_Donate4Recharge = value ;
			}
		}
		#endregion
	
		#region SalesTotalMoney
		private System.Decimal m_SalesTotalMoney = 0 ; 
		/// <summary>
		/// SalesTotalMoney 销售收入总金额
		/// </summary>
		public System.Decimal SalesTotalMoney
		{
			get
			{
				return this.m_SalesTotalMoney ;
			}
			set
			{
				this.m_SalesTotalMoney = value ;
			}
		}
		#endregion
	
		#region SalesInCash
		private System.Decimal m_SalesInCash = 0 ; 
		/// <summary>
		/// SalesInCash 销售时现金收入总金额
		/// </summary>
		public System.Decimal SalesInCash
		{
			get
			{
				return this.m_SalesInCash ;
			}
			set
			{
				this.m_SalesInCash = value ;
			}
		}
		#endregion
	
		#region SalesInBankCard
		private System.Decimal m_SalesInBankCard = 0 ; 
		/// <summary>
		/// SalesInBankCard 销售时收到的银联卡总金额
		/// </summary>
		public System.Decimal SalesInBankCard
		{
			get
			{
				return this.m_SalesInBankCard ;
			}
			set
			{
				this.m_SalesInBankCard = value ;
			}
		}
		#endregion
	
		#region SalesInWeiXin
		private System.Decimal m_SalesInWeiXin = 0 ; 
		/// <summary>
		/// SalesInWeiXin 销售时收到的微信总金额
		/// </summary>
		public System.Decimal SalesInWeiXin
		{
			get
			{
				return this.m_SalesInWeiXin ;
			}
			set
			{
				this.m_SalesInWeiXin = value ;
			}
		}
		#endregion
	
		#region SalesInAlipay
		private System.Decimal m_SalesInAlipay = 0 ; 
		/// <summary>
		/// SalesInAlipay 销售时收到的支付宝总金额
		/// </summary>
		public System.Decimal SalesInAlipay
		{
			get
			{
				return this.m_SalesInAlipay ;
			}
			set
			{
				this.m_SalesInAlipay = value ;
			}
		}
		#endregion
	
		#region SalesInVipBalance
		private System.Decimal m_SalesInVipBalance = 0 ; 
		/// <summary>
		/// SalesInVipBalance 销售时会员使用卡余额的总金额
		/// </summary>
		public System.Decimal SalesInVipBalance
		{
			get
			{
				return this.m_SalesInVipBalance ;
			}
			set
			{
				this.m_SalesInVipBalance = value ;
			}
		}
		#endregion
	
		#region SalesInVipIntegration
		private System.Decimal m_SalesInVipIntegration = 0 ; 
		/// <summary>
		/// SalesInVipIntegration 销售时会员使用卡积分返现的总金额
		/// </summary>
		public System.Decimal SalesInVipIntegration
		{
			get
			{
				return this.m_SalesInVipIntegration ;
			}
			set
			{
				this.m_SalesInVipIntegration = value ;
			}
		}
		#endregion
	
		#region QuantityOfSale
		private System.Int32 m_QuantityOfSale = 0 ; 
		/// <summary>
		/// QuantityOfSale 销售的商品总数量
		/// </summary>
		public System.Int32 QuantityOfSale
		{
			get
			{
				return this.m_QuantityOfSale ;
			}
			set
			{
				this.m_QuantityOfSale = value ;
			}
		}
		#endregion
	
		#region SalesCount
		private System.Int32 m_SalesCount = 0 ; 
		/// <summary>
		/// SalesCount 成交笔数（销售单数）
		/// </summary>
		public System.Int32 SalesCount
		{
			get
			{
				return this.m_SalesCount ;
			}
			set
			{
				this.m_SalesCount = value ;
			}
		}
		#endregion
	
		#region RefundTotalMoney
		private System.Decimal m_RefundTotalMoney = 0 ; 
		/// <summary>
		/// RefundTotalMoney 顾客退货总金额
		/// </summary>
		public System.Decimal RefundTotalMoney
		{
			get
			{
				return this.m_RefundTotalMoney ;
			}
			set
			{
				this.m_RefundTotalMoney = value ;
			}
		}
		#endregion
	
		#region RefundInCash
		private System.Decimal m_RefundInCash = 0 ; 
		/// <summary>
		/// RefundInCash 顾客退货时返还的现金总金额
		/// </summary>
		public System.Decimal RefundInCash
		{
			get
			{
				return this.m_RefundInCash ;
			}
			set
			{
				this.m_RefundInCash = value ;
			}
		}
		#endregion
	
		#region RefundInVipBalance
		private System.Decimal m_RefundInVipBalance = 0 ; 
		/// <summary>
		/// RefundInVipBalance 顾客退货时返还的VIP卡总金额
		/// </summary>
		public System.Decimal RefundInVipBalance
		{
			get
			{
				return this.m_RefundInVipBalance ;
			}
			set
			{
				this.m_RefundInVipBalance = value ;
			}
		}
		#endregion
	
		#region RefundInVipIntegration
		private System.Decimal m_RefundInVipIntegration = 0 ; 
		/// <summary>
		/// RefundInVipIntegration 顾客退货时返还的积分返现的总金额
		/// </summary>
		public System.Decimal RefundInVipIntegration
		{
			get
			{
				return this.m_RefundInVipIntegration ;
			}
			set
			{
				this.m_RefundInVipIntegration = value ;
			}
		}
		#endregion
	
		#region QuantityOfRefund
		private System.Int32 m_QuantityOfRefund = 0 ; 
		/// <summary>
		/// QuantityOfRefund 顾客退货的商品总数量
		/// </summary>
		public System.Int32 QuantityOfRefund
		{
			get
			{
				return this.m_QuantityOfRefund ;
			}
			set
			{
				this.m_QuantityOfRefund = value ;
			}
		}
		#endregion
	
		#region RefundCount
		private System.Int32 m_RefundCount = 0 ; 
		/// <summary>
		/// RefundCount 退货笔数（退货单数）
		/// </summary>
		public System.Int32 RefundCount
		{
			get
			{
				return this.m_RefundCount ;
			}
			set
			{
				this.m_RefundCount = value ;
			}
		}
		#endregion
	
		#region CarriageCost
		private System.Decimal m_CarriageCost = 0 ; 
		/// <summary>
		/// CarriageCost 运费（买家出的）
		/// </summary>
		public System.Decimal CarriageCost
		{
			get
			{
				return this.m_CarriageCost ;
			}
			set
			{
				this.m_CarriageCost = value ;
			}
		}
		#endregion
	
		#region EmQuantityOfSale
		private System.Int32 m_EmQuantityOfSale = 0 ; 
		/// <summary>
		/// EmQuantityOfSale 销售的商品总数量（不扣除退货），线上
		/// </summary>
		public System.Int32 EmQuantityOfSale
		{
			get
			{
				return this.m_EmQuantityOfSale ;
			}
			set
			{
				this.m_EmQuantityOfSale = value ;
			}
		}
		#endregion
	
		#region EmQuantityOfRefund
		private System.Int32 m_EmQuantityOfRefund = 0 ; 
		/// <summary>
		/// EmQuantityOfRefund 顾客退货的商品总数量，线上
		/// </summary>
		public System.Int32 EmQuantityOfRefund
		{
			get
			{
				return this.m_EmQuantityOfRefund ;
			}
			set
			{
				this.m_EmQuantityOfRefund = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 开单日期
		/// </summary>
		public System.DateTime CreateTime
		{
			get
			{
				return this.m_CreateTime ;
			}
			set
			{
				this.m_CreateTime = value ;
			}
		}
		#endregion
	
		#region Remarks
		private System.String m_Remarks = "" ; 
		/// <summary>
		/// Remarks 备注
		/// </summary>
		public System.String Remarks
		{
			get
			{
				return this.m_Remarks ;
			}
			set
			{
				this.m_Remarks = value ;
			}
		}
		#endregion
	
		#region ManualConfirm
		private System.Boolean m_ManualConfirm = false ; 
		/// <summary>
		/// ManualConfirm 是否手动结存
		/// </summary>
		public System.Boolean ManualConfirm
		{
			get
			{
				return this.m_ManualConfirm ;
			}
			set
			{
				this.m_ManualConfirm = value ;
			}
		}
		#endregion
	
		#region TotalPriceInStore
		private System.Decimal m_TotalPriceInStore = 0 ; 
		/// <summary>
		/// TotalPriceInStore 库存货物总价值（店铺时取值0）
		/// </summary>
		public System.Decimal TotalPriceInStore
		{
			get
			{
				return this.m_TotalPriceInStore ;
			}
			set
			{
				this.m_TotalPriceInStore = value ;
			}
		}
		#endregion
	
		#region TotalCostInStore
		private System.Decimal m_TotalCostInStore = 0 ; 
		/// <summary>
		/// TotalCostInStore 库存货物总成本（店铺时取值0）
		/// </summary>
		public System.Decimal TotalCostInStore
		{
			get
			{
				return this.m_TotalCostInStore ;
			}
			set
			{
				this.m_TotalCostInStore = value ;
			}
		}
		#endregion
	
		#region TotalMemberBalance
		private System.Decimal m_TotalMemberBalance = 0 ; 
		/// <summary>
		/// TotalMemberBalance 会员余额总和。（店铺时取值0）
		/// </summary>
		public System.Decimal TotalMemberBalance
		{
			get
			{
				return this.m_TotalMemberBalance ;
			}
			set
			{
				this.m_TotalMemberBalance = value ;
			}
		}
		#endregion
	
		#region TotalMemberBalance2
		private System.Decimal m_TotalMemberBalance2 = 0 ; 
		/// <summary>
		/// TotalMemberBalance2 扣除赠送部分后的会员余额总和。（店铺时取值0）
		/// </summary>
		public System.Decimal TotalMemberBalance2
		{
			get
			{
				return this.m_TotalMemberBalance2 ;
			}
			set
			{
				this.m_TotalMemberBalance2 = value ;
			}
		}
		#endregion
	
		#region SalesInGiftTicket
		private System.Decimal m_SalesInGiftTicket = 0 ; 
		/// <summary>
		/// SalesInGiftTicket 销售时会员使用电子优惠券的总金额
		/// </summary>
		public System.Decimal SalesInGiftTicket
		{
			get
			{
				return this.m_SalesInGiftTicket ;
			}
			set
			{
				this.m_SalesInGiftTicket = value ;
			}
		}
		#endregion
	
		#region PfDeliveryCount
		private System.Int32 m_PfDeliveryCount = 0 ; 
		/// <summary>
		/// PfDeliveryCount 批发发货数量
		/// </summary>
		public System.Int32 PfDeliveryCount
		{
			get
			{
				return this.m_PfDeliveryCount ;
			}
			set
			{
				this.m_PfDeliveryCount = value ;
			}
		}
		#endregion
	
		#region PfReturnCount
		private System.Int32 m_PfReturnCount = 0 ; 
		/// <summary>
		/// PfReturnCount 批发退货数量
		/// </summary>
		public System.Int32 PfReturnCount
		{
			get
			{
				return this.m_PfReturnCount ;
			}
			set
			{
				this.m_PfReturnCount = value ;
			}
		}
		#endregion
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
