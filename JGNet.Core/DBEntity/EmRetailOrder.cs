using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmRetailOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "EmRetailOrder" ;
		public const string _ID = "ID" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _MemeberID = "MemeberID" ;
		public const string _RetailOrderID = "RetailOrderID" ;
		public const string _EmRefundOrderID = "EmRefundOrderID" ;
		public const string _SalesPromotionID = "SalesPromotionID" ;
		public const string _PromotionText = "PromotionText" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _TotalPrice = "TotalPrice" ;
		public const string _MoneyDiscounted = "MoneyDiscounted" ;
		public const string _MoneyDeductedByTicket = "MoneyDeductedByTicket" ;
		public const string _CarriageCost = "CarriageCost" ;
		public const string _TotalMoneyReceived = "TotalMoneyReceived" ;
		public const string _MoneyWeiXin = "MoneyWeiXin" ;
		public const string _MoneyVipCard = "MoneyVipCard" ;
		public const string _MoneyVipCardMain = "MoneyVipCardMain" ;
		public const string _MoneyVipCardDonate = "MoneyVipCardDonate" ;
		public const string _MoneyIntegration = "MoneyIntegration" ;
		public const string _TotalCost = "TotalCost" ;
		public const string _Benefit = "Benefit" ;
		public const string _BuyerMessage = "BuyerMessage" ;
		public const string _State = "State" ;
		public const string _CancelOrRefund = "CancelOrRefund" ;
		public const string _ReceiverName = "ReceiverName" ;
		public const string _ReceiverTelphone = "ReceiverTelphone" ;
		public const string _ReceiverCityZone = "ReceiverCityZone" ;
		public const string _ReceiverDetailAddress = "ReceiverDetailAddress" ;
		public const string _TimePay = "TimePay" ;
		public const string _TimeExpressDelivery = "TimeExpressDelivery" ;
		public const string _TimeConfirmReceive = "TimeConfirmReceive" ;
		public const string _TimeCancelOrRefundReq = "TimeCancelOrRefundReq" ;
		public const string _TimeRemark = "TimeRemark" ;
		public const string _ExpressCompany = "ExpressCompany" ;
		public const string _ExpressOrderID = "ExpressOrderID" ;
		public const string _PayType = "PayType" ;
		public const string _IsClosed = "IsClosed" ;
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
	
		#region RetailOrderID
		private System.String m_RetailOrderID = "" ; 
		/// <summary>
		/// RetailOrderID 销售单号
		/// </summary>
		public System.String RetailOrderID
		{
			get
			{
				return this.m_RetailOrderID ;
			}
			set
			{
				this.m_RetailOrderID = value ;
			}
		}
		#endregion
	
		#region EmRefundOrderID
		private System.String m_EmRefundOrderID = "" ; 
		/// <summary>
		/// EmRefundOrderID 线上退货单号
		/// </summary>
		public System.String EmRefundOrderID
		{
			get
			{
				return this.m_EmRefundOrderID ;
			}
			set
			{
				this.m_EmRefundOrderID = value ;
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
	
		#region BuyerMessage
		private System.String m_BuyerMessage = "" ; 
		/// <summary>
		/// BuyerMessage 买家留言
		/// </summary>
		public System.String BuyerMessage
		{
			get
			{
				return this.m_BuyerMessage ;
			}
			set
			{
				this.m_BuyerMessage = value ;
			}
		}
		#endregion
	
		#region State
		private System.Byte m_State = 0 ; 
		/// <summary>
		/// State 0：待付款，1：待发货  2：待收货，3：待评价，4：已完成
		/// </summary>
		public System.Byte State
		{
			get
			{
				return this.m_State ;
			}
			set
			{
				this.m_State = value ;
			}
		}
		#endregion
	
		#region CancelOrRefund
		private System.Byte m_CancelOrRefund = 0 ; 
		/// <summary>
		/// CancelOrRefund 0：正常，1：取消，2：退货退款，3：仅退款
		/// </summary>
		public System.Byte CancelOrRefund
		{
			get
			{
				return this.m_CancelOrRefund ;
			}
			set
			{
				this.m_CancelOrRefund = value ;
			}
		}
		#endregion
	
		#region ReceiverName
		private System.String m_ReceiverName = "" ; 
		/// <summary>
		/// ReceiverName 收货人姓名
		/// </summary>
		public System.String ReceiverName
		{
			get
			{
				return this.m_ReceiverName ;
			}
			set
			{
				this.m_ReceiverName = value ;
			}
		}
		#endregion
	
		#region ReceiverTelphone
		private System.String m_ReceiverTelphone = "" ; 
		/// <summary>
		/// ReceiverTelphone 收货人电话
		/// </summary>
		public System.String ReceiverTelphone
		{
			get
			{
				return this.m_ReceiverTelphone ;
			}
			set
			{
				this.m_ReceiverTelphone = value ;
			}
		}
		#endregion
	
		#region ReceiverCityZone
		private System.String m_ReceiverCityZone = "" ; 
		/// <summary>
		/// ReceiverCityZone 所在城市，格式：xx省xx市xx区
		/// </summary>
		public System.String ReceiverCityZone
		{
			get
			{
				return this.m_ReceiverCityZone ;
			}
			set
			{
				this.m_ReceiverCityZone = value ;
			}
		}
		#endregion
	
		#region ReceiverDetailAddress
		private System.String m_ReceiverDetailAddress = "" ; 
		/// <summary>
		/// ReceiverDetailAddress 收货详细地址：xx街道xx小区xx栋xx号
		/// </summary>
		public System.String ReceiverDetailAddress
		{
			get
			{
				return this.m_ReceiverDetailAddress ;
			}
			set
			{
				this.m_ReceiverDetailAddress = value ;
			}
		}
		#endregion
	
		#region TimePay
		private System.DateTime m_TimePay = DateTime.Now ; 
		/// <summary>
		/// TimePay 支付时间
		/// </summary>
		public System.DateTime TimePay
		{
			get
			{
				return this.m_TimePay ;
			}
			set
			{
				this.m_TimePay = value ;
			}
		}
		#endregion
	
		#region TimeExpressDelivery
		private System.DateTime m_TimeExpressDelivery = DateTime.Now ; 
		/// <summary>
		/// TimeExpressDelivery 卖家发货的时间
		/// </summary>
		public System.DateTime TimeExpressDelivery
		{
			get
			{
				return this.m_TimeExpressDelivery ;
			}
			set
			{
				this.m_TimeExpressDelivery = value ;
			}
		}
		#endregion
	
		#region TimeConfirmReceive
		private System.DateTime m_TimeConfirmReceive = DateTime.Now ; 
		/// <summary>
		/// TimeConfirmReceive 买家确认收货的时间
		/// </summary>
		public System.DateTime TimeConfirmReceive
		{
			get
			{
				return this.m_TimeConfirmReceive ;
			}
			set
			{
				this.m_TimeConfirmReceive = value ;
			}
		}
		#endregion
	
		#region TimeCancelOrRefundReq
		private System.DateTime m_TimeCancelOrRefundReq = DateTime.Now ; 
		/// <summary>
		/// TimeCancelOrRefundReq 取消时间或申请退货时间
		/// </summary>
		public System.DateTime TimeCancelOrRefundReq
		{
			get
			{
				return this.m_TimeCancelOrRefundReq ;
			}
			set
			{
				this.m_TimeCancelOrRefundReq = value ;
			}
		}
		#endregion
	
		#region TimeRemark
		private System.DateTime m_TimeRemark = DateTime.Now ; 
		/// <summary>
		/// TimeRemark 买家评价时间
		/// </summary>
		public System.DateTime TimeRemark
		{
			get
			{
				return this.m_TimeRemark ;
			}
			set
			{
				this.m_TimeRemark = value ;
			}
		}
		#endregion
	
		#region ExpressCompany
		private System.String m_ExpressCompany = "" ; 
		/// <summary>
		/// ExpressCompany 快递公司名称（卖家发货）
		/// </summary>
		public System.String ExpressCompany
		{
			get
			{
				return this.m_ExpressCompany ;
			}
			set
			{
				this.m_ExpressCompany = value ;
			}
		}
		#endregion
	
		#region ExpressOrderID
		private System.String m_ExpressOrderID = "" ; 
		/// <summary>
		/// ExpressOrderID 快递单号（卖家发货）
		/// </summary>
		public System.String ExpressOrderID
		{
			get
			{
				return this.m_ExpressOrderID ;
			}
			set
			{
				this.m_ExpressOrderID = value ;
			}
		}
		#endregion
	
		#region PayType
		private System.Byte m_PayType = 0 ; 
		/// <summary>
		/// PayType 付款方式。微信支付0，VIP卡支付1。
		/// </summary>
		public System.Byte PayType
		{
			get
			{
				return this.m_PayType ;
			}
			set
			{
				this.m_PayType = value ;
			}
		}
		#endregion
	
		#region IsClosed
		private System.Boolean m_IsClosed = false ; 
		/// <summary>
		/// IsClosed 是否已经关闭？
		/// </summary>
		public System.Boolean IsClosed
		{
			get
			{
				return this.m_IsClosed ;
			}
			set
			{
				this.m_IsClosed = value ;
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
