using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class RetailOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "RetailOrder" ;
		public const string _ID = "ID" ;
		public const string _IsRefundOrder = "IsRefundOrder" ;
		public const string _OriginOrderID = "OriginOrderID" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EntryUserID = "EntryUserID" ;
		public const string _EntryTime = "EntryTime" ;
		public const string _MemeberID = "MemeberID" ;
		public const string _GuideID = "GuideID" ;
		public const string _OperateGuideID = "OperateGuideID" ;
		public const string _ShopID = "ShopID" ;
		public const string _SalesPromotionID = "SalesPromotionID" ;
		public const string _PromotionText = "PromotionText" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _TotalPrice = "TotalPrice" ;
		public const string _MoneyDiscounted = "MoneyDiscounted" ;
		public const string _SmallMoneyRemoved = "SmallMoneyRemoved" ;
		public const string _CarriageCost = "CarriageCost" ;
		public const string _TotalMoneyReceived = "TotalMoneyReceived" ;
		public const string _TotalMoneyReceivedActual = "TotalMoneyReceivedActual" ;
		public const string _MoneyCash = "MoneyCash" ;
		public const string _MoneyCash2 = "MoneyCash2" ;
		public const string _MoneyBankCard = "MoneyBankCard" ;
		public const string _MoneyVipCard = "MoneyVipCard" ;
		public const string _MoneyVipCardMain = "MoneyVipCardMain" ;
		public const string _MoneyVipCardDonate = "MoneyVipCardDonate" ;
		public const string _MoneyIntegration = "MoneyIntegration" ;
		public const string _MoneyWeiXin = "MoneyWeiXin" ;
		public const string _MoneyAlipay = "MoneyAlipay" ;
		public const string _MoneyOther = "MoneyOther" ;
		public const string _MoneyChange = "MoneyChange" ;
		public const string _TotalCost = "TotalCost" ;
		public const string _Benefit = "Benefit" ;
		public const string _Remarks = "Remarks" ;
		public const string _RefundOrderID = "RefundOrderID" ;
		public const string _EmOnline = "EmOnline" ;
		public const string _IsCancel = "IsCancel" ;
		public const string _CancelTime = "CancelTime" ;
		public const string _CancelGuideID = "CancelGuideID" ;
		public const string _ReturnVisitRecordID = "ReturnVisitRecordID" ;
		public const string _MoneyDeductedByTicket = "MoneyDeductedByTicket" ;
		public const string _Visiable4Supervisor = "Visiable4Supervisor" ;
		public const string _IsNotPay = "IsNotPay" ;
		public const string _GiftTicket = "GiftTicket" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 单据编号（主键）
		/// </summary>
		public System.String ID
		{
			get
			{
				return this.m_ID ;
			}
			set
			{
				this.m_ID = value ;
			}
		}
		#endregion
	
		#region IsRefundOrder
		private System.Boolean m_IsRefundOrder = false ; 
		/// <summary>
		/// IsRefundOrder 是否为退货单？
		/// </summary>
		public System.Boolean IsRefundOrder
		{
			get
			{
				return this.m_IsRefundOrder ;
			}
			set
			{
				this.m_IsRefundOrder = value ;
			}
		}
		#endregion
	
		#region OriginOrderID
		private System.String m_OriginOrderID = "" ; 
		/// <summary>
		/// OriginOrderID 如果为退货单，原始销售单
		/// </summary>
		public System.String OriginOrderID
		{
			get
			{
				return this.m_OriginOrderID ;
			}
			set
			{
				this.m_OriginOrderID = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 单据日期
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
	
		#region EntryUserID
		private System.String m_EntryUserID = "" ; 
		/// <summary>
		/// EntryUserID 制单人ID
		/// </summary>
		public System.String EntryUserID
		{
			get
			{
				return this.m_EntryUserID ;
			}
			set
			{
				this.m_EntryUserID = value ;
			}
		}
		#endregion
	
		#region EntryTime
		private System.DateTime m_EntryTime = DateTime.Now ; 
		/// <summary>
		/// EntryTime 制单时间
		/// </summary>
		public System.DateTime EntryTime
		{
			get
			{
				return this.m_EntryTime ;
			}
			set
			{
				this.m_EntryTime = value ;
			}
		}
		#endregion
	
		#region MemeberID
		private System.String m_MemeberID = "" ; 
		/// <summary>
		/// MemeberID 会员卡号（手机号）
		/// </summary>
		public System.String MemeberID
		{
			get
			{
				return this.m_MemeberID ;
			}
			set
			{
				this.m_MemeberID = value ;
			}
		}
		#endregion
	
		#region GuideID
		private System.String m_GuideID = "" ; 
		/// <summary>
		/// GuideID 导购
		/// </summary>
		public System.String GuideID
		{
			get
			{
				return this.m_GuideID ;
			}
			set
			{
				this.m_GuideID = value ;
			}
		}
		#endregion
	
		#region OperateGuideID
		private System.String m_OperateGuideID = "" ; 
		/// <summary>
		/// OperateGuideID 操作的导购
		/// </summary>
		public System.String OperateGuideID
		{
			get
			{
				return this.m_OperateGuideID ;
			}
			set
			{
				this.m_OperateGuideID = value ;
			}
		}
		#endregion
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 店铺id
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
	
		#region SalesPromotionID
		private System.String m_SalesPromotionID = "" ; 
		/// <summary>
		/// SalesPromotionID 促销活动ID
		/// </summary>
		public System.String SalesPromotionID
		{
			get
			{
				return this.m_SalesPromotionID ;
			}
			set
			{
				this.m_SalesPromotionID = value ;
			}
		}
		#endregion
	
		#region PromotionText
		private System.String m_PromotionText = "" ; 
		/// <summary>
		/// PromotionText 达到的促销优惠说明
		/// </summary>
		public System.String PromotionText
		{
			get
			{
				return this.m_PromotionText ;
			}
			set
			{
				this.m_PromotionText = value ;
			}
		}
		#endregion
	
		#region TotalCount
		private System.Int32 m_TotalCount = 0 ; 
		/// <summary>
		/// TotalCount 商品总件数
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
	
		#region TotalPrice
		private System.Decimal m_TotalPrice = 0 ; 
		/// <summary>
		/// TotalPrice 货品金额（按吊牌价计算）
		/// </summary>
		public System.Decimal TotalPrice
		{
			get
			{
				return this.m_TotalPrice ;
			}
			set
			{
				this.m_TotalPrice = value ;
			}
		}
		#endregion
	
		#region MoneyDiscounted
		private System.Decimal m_MoneyDiscounted = 0 ; 
		/// <summary>
		/// MoneyDiscounted 折扣优惠金额
		/// </summary>
		public System.Decimal MoneyDiscounted
		{
			get
			{
				return this.m_MoneyDiscounted ;
			}
			set
			{
				this.m_MoneyDiscounted = value ;
			}
		}
		#endregion
	
		#region SmallMoneyRemoved
		private System.Decimal m_SmallMoneyRemoved = 0 ; 
		/// <summary>
		/// SmallMoneyRemoved 抹零金额
		/// </summary>
		public System.Decimal SmallMoneyRemoved
		{
			get
			{
				return this.m_SmallMoneyRemoved ;
			}
			set
			{
				this.m_SmallMoneyRemoved = value ;
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
	
		#region TotalMoneyReceived
		private System.Decimal m_TotalMoneyReceived = 0 ; 
		/// <summary>
		/// TotalMoneyReceived 应收金额
		/// </summary>
		public System.Decimal TotalMoneyReceived
		{
			get
			{
				return this.m_TotalMoneyReceived ;
			}
			set
			{
				this.m_TotalMoneyReceived = value ;
			}
		}
		#endregion
	
		#region TotalMoneyReceivedActual
		private System.Decimal m_TotalMoneyReceivedActual = 0 ; 
		/// <summary>
		/// TotalMoneyReceivedActual 实收额 = TotalMoneyReceived - MoneyIntegration - MoneyVipCardDonate - MoneyDeductedByTicket
		/// </summary>
		public System.Decimal TotalMoneyReceivedActual
		{
			get
			{
				return this.m_TotalMoneyReceivedActual ;
			}
			set
			{
				this.m_TotalMoneyReceivedActual = value ;
			}
		}
		#endregion
	
		#region MoneyCash
		private System.Decimal m_MoneyCash = 0 ; 
		/// <summary>
		/// MoneyCash 现金付款金额
		/// </summary>
		public System.Decimal MoneyCash
		{
			get
			{
				return this.m_MoneyCash ;
			}
			set
			{
				this.m_MoneyCash = value ;
			}
		}
		#endregion
	
		#region MoneyCash2
		private System.Decimal m_MoneyCash2 = 0 ; 
		/// <summary>
		/// MoneyCash2 现金付款金额（扣除找零后）
		/// </summary>
		public System.Decimal MoneyCash2
		{
			get
			{
				return this.m_MoneyCash2 ;
			}
			set
			{
				this.m_MoneyCash2 = value ;
			}
		}
		#endregion
	
		#region MoneyBankCard
		private System.Decimal m_MoneyBankCard = 0 ; 
		/// <summary>
		/// MoneyBankCard 银联卡付款金额
		/// </summary>
		public System.Decimal MoneyBankCard
		{
			get
			{
				return this.m_MoneyBankCard ;
			}
			set
			{
				this.m_MoneyBankCard = value ;
			}
		}
		#endregion
	
		#region MoneyVipCard
		private System.Decimal m_MoneyVipCard = 0 ; 
		/// <summary>
		/// MoneyVipCard VIP卡付款金额
		/// </summary>
		public System.Decimal MoneyVipCard
		{
			get
			{
				return this.m_MoneyVipCard ;
			}
			set
			{
				this.m_MoneyVipCard = value ;
			}
		}
		#endregion
	
		#region MoneyVipCardMain
		private System.Decimal m_MoneyVipCardMain = 0 ; 
		/// <summary>
		/// MoneyVipCardMain VIP卡付款金额的充值部分
		/// </summary>
		public System.Decimal MoneyVipCardMain
		{
			get
			{
				return this.m_MoneyVipCardMain ;
			}
			set
			{
				this.m_MoneyVipCardMain = value ;
			}
		}
		#endregion
	
		#region MoneyVipCardDonate
		private System.Decimal m_MoneyVipCardDonate = 0 ; 
		/// <summary>
		/// MoneyVipCardDonate VIP卡付款金额的赠送部分
		/// </summary>
		public System.Decimal MoneyVipCardDonate
		{
			get
			{
				return this.m_MoneyVipCardDonate ;
			}
			set
			{
				this.m_MoneyVipCardDonate = value ;
			}
		}
		#endregion
	
		#region MoneyIntegration
		private System.Decimal m_MoneyIntegration = 0 ; 
		/// <summary>
		/// MoneyIntegration VIP卡积分返现付款金额
		/// </summary>
		public System.Decimal MoneyIntegration
		{
			get
			{
				return this.m_MoneyIntegration ;
			}
			set
			{
				this.m_MoneyIntegration = value ;
			}
		}
		#endregion
	
		#region MoneyWeiXin
		private System.Decimal m_MoneyWeiXin = 0 ; 
		/// <summary>
		/// MoneyWeiXin 微信付款金额
		/// </summary>
		public System.Decimal MoneyWeiXin
		{
			get
			{
				return this.m_MoneyWeiXin ;
			}
			set
			{
				this.m_MoneyWeiXin = value ;
			}
		}
		#endregion
	
		#region MoneyAlipay
		private System.Decimal m_MoneyAlipay = 0 ; 
		/// <summary>
		/// MoneyAlipay 支付宝付款金额
		/// </summary>
		public System.Decimal MoneyAlipay
		{
			get
			{
				return this.m_MoneyAlipay ;
			}
			set
			{
				this.m_MoneyAlipay = value ;
			}
		}
		#endregion
	
		#region MoneyOther
		private System.Decimal m_MoneyOther = 0 ; 
		/// <summary>
		/// MoneyOther 其他付款金额
		/// </summary>
		public System.Decimal MoneyOther
		{
			get
			{
				return this.m_MoneyOther ;
			}
			set
			{
				this.m_MoneyOther = value ;
			}
		}
		#endregion
	
		#region MoneyChange
		private System.Decimal m_MoneyChange = 0 ; 
		/// <summary>
		/// MoneyChange 找零金额
		/// </summary>
		public System.Decimal MoneyChange
		{
			get
			{
				return this.m_MoneyChange ;
			}
			set
			{
				this.m_MoneyChange = value ;
			}
		}
		#endregion
	
		#region TotalCost
		private System.Decimal m_TotalCost = 0 ; 
		/// <summary>
		/// TotalCost 总进货成本
		/// </summary>
		public System.Decimal TotalCost
		{
			get
			{
				return this.m_TotalCost ;
			}
			set
			{
				this.m_TotalCost = value ;
			}
		}
		#endregion
	
		#region Benefit
		private System.Decimal m_Benefit = 0 ; 
		/// <summary>
		/// Benefit 利润
		/// </summary>
		public System.Decimal Benefit
		{
			get
			{
				return this.m_Benefit ;
			}
			set
			{
				this.m_Benefit = value ;
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
	
		#region RefundOrderID
		private System.String m_RefundOrderID = "" ; 
		/// <summary>
		/// RefundOrderID 退货单号
		/// </summary>
		public System.String RefundOrderID
		{
			get
			{
				return this.m_RefundOrderID ;
			}
			set
			{
				this.m_RefundOrderID = value ;
			}
		}
		#endregion
	
		#region EmOnline
		private System.Boolean m_EmOnline = false ; 
		/// <summary>
		/// EmOnline 是否为线上销售单？
		/// </summary>
		public System.Boolean EmOnline
		{
			get
			{
				return this.m_EmOnline ;
			}
			set
			{
				this.m_EmOnline = value ;
			}
		}
		#endregion
	
		#region IsCancel
		private System.Boolean m_IsCancel = false ; 
		/// <summary>
		/// IsCancel 销售单是否冲单？
		/// </summary>
		public System.Boolean IsCancel
		{
			get
			{
				return this.m_IsCancel ;
			}
			set
			{
				this.m_IsCancel = value ;
			}
		}
		#endregion
	
		#region CancelTime
		private System.DateTime m_CancelTime = DateTime.Now ; 
		/// <summary>
		/// CancelTime 冲单时间
		/// </summary>
		public System.DateTime CancelTime
		{
			get
			{
				return this.m_CancelTime ;
			}
			set
			{
				this.m_CancelTime = value ;
			}
		}
		#endregion
	
		#region CancelGuideID
		private System.String m_CancelGuideID = "" ; 
		/// <summary>
		/// CancelGuideID 操作冲单的导购
		/// </summary>
		public System.String CancelGuideID
		{
			get
			{
				return this.m_CancelGuideID ;
			}
			set
			{
				this.m_CancelGuideID = value ;
			}
		}
		#endregion
	
		#region ReturnVisitRecordID
		private System.Int32 m_ReturnVisitRecordID = 0 ; 
		/// <summary>
		/// ReturnVisitRecordID 回访记录编号。如果为0，表示尚未回访。
		/// </summary>
		public System.Int32 ReturnVisitRecordID
		{
			get
			{
				return this.m_ReturnVisitRecordID ;
			}
			set
			{
				this.m_ReturnVisitRecordID = value ;
			}
		}
		#endregion
	
		#region MoneyDeductedByTicket
		private System.Decimal m_MoneyDeductedByTicket = 0 ; 
		/// <summary>
		/// MoneyDeductedByTicket 电子优惠券抵扣掉的金额
		/// </summary>
		public System.Decimal MoneyDeductedByTicket
		{
			get
			{
				return this.m_MoneyDeductedByTicket ;
			}
			set
			{
				this.m_MoneyDeductedByTicket = value ;
			}
		}
		#endregion
	
		#region Visiable4Supervisor
		private System.Boolean m_Visiable4Supervisor = false ; 
		/// <summary>
		/// Visiable4Supervisor 是否对监管人员可见？
		/// </summary>
		public System.Boolean Visiable4Supervisor
		{
			get
			{
				return this.m_Visiable4Supervisor ;
			}
			set
			{
				this.m_Visiable4Supervisor = value ;
			}
		}
		#endregion
	
		#region IsNotPay
		private System.Boolean m_IsNotPay = false ; 
		/// <summary>
		/// IsNotPay 是否是未付款
		/// </summary>
		public System.Boolean IsNotPay
		{
			get
			{
				return this.m_IsNotPay ;
			}
			set
			{
				this.m_IsNotPay = value ;
			}
		}
		#endregion
	
		#region GiftTicket
		private System.String m_GiftTicket = "" ; 
		/// <summary>
		/// GiftTicket 所使用的电子优惠券的ID
		/// </summary>
		public System.String GiftTicket
		{
			get
			{
				return this.m_GiftTicket ;
			}
			set
			{
				this.m_GiftTicket = value ;
			}
		}
		#endregion
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.ID;
	    }
	    #endregion
	}
}
