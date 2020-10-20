using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmRefundOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "EmRefundOrder" ;
		public const string _ID = "ID" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _MemeberID = "MemeberID" ;
		public const string _EmRetailOrderID = "EmRetailOrderID" ;
		public const string _RefundOrderID = "RefundOrderID" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _TotalPrice = "TotalPrice" ;
		public const string _TotalMoneyRefund = "TotalMoneyRefund" ;
		public const string _RefundState = "RefundState" ;
		public const string _RefundReceiverName = "RefundReceiverName" ;
		public const string _RefundReceiverTelphone = "RefundReceiverTelphone" ;
		public const string _RefundReceiverCityZone = "RefundReceiverCityZone" ;
		public const string _RefundReceiverDetailAddress = "RefundReceiverDetailAddress" ;
		public const string _TimeExpressStart = "TimeExpressStart" ;
		public const string _ExpressCompany4Refund = "ExpressCompany4Refund" ;
		public const string _ExpressOrderID4Refund = "ExpressOrderID4Refund" ;
		public const string _RefundRequestCount = "RefundRequestCount" ;
		public const string _LastUpdateTime = "LastUpdateTime" ;
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
	
		#region EmRetailOrderID
		private System.String m_EmRetailOrderID = "" ; 
		/// <summary>
		/// EmRetailOrderID 线上销售单号
		/// </summary>
		public System.String EmRetailOrderID
		{
			get
			{
				return this.m_EmRetailOrderID ;
			}
			set
			{
				this.m_EmRetailOrderID = value ;
			}
		}
		#endregion
	
		#region RefundOrderID
		private System.String m_RefundOrderID = "" ; 
		/// <summary>
		/// RefundOrderID 退货单号（RetailOrder表）
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
	
		#region TotalCount
		private System.Int32 m_TotalCount = 0 ; 
		/// <summary>
		/// TotalCount 退货商品总件数
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
		/// TotalPrice 退货货品金额（按吊牌价计算）
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
	
		#region TotalMoneyRefund
		private System.Decimal m_TotalMoneyRefund = 0 ; 
		/// <summary>
		/// TotalMoneyRefund 应退金额
		/// </summary>
		public System.Decimal TotalMoneyRefund
		{
			get
			{
				return this.m_TotalMoneyRefund ;
			}
			set
			{
				this.m_TotalMoneyRefund = value ;
			}
		}
		#endregion
	
		#region RefundState
		private System.Byte m_RefundState = 0 ; 
		/// <summary>
		/// RefundState 0：退款申请中，1：已拒绝， 2：待填写物流，3：退款中，4：已退款
		/// </summary>
		public System.Byte RefundState
		{
			get
			{
				return this.m_RefundState ;
			}
			set
			{
				this.m_RefundState = value ;
			}
		}
		#endregion
	
		#region RefundReceiverName
		private System.String m_RefundReceiverName = "" ; 
		/// <summary>
		/// RefundReceiverName 收货人姓名（退货）
		/// </summary>
		public System.String RefundReceiverName
		{
			get
			{
				return this.m_RefundReceiverName ;
			}
			set
			{
				this.m_RefundReceiverName = value ;
			}
		}
		#endregion
	
		#region RefundReceiverTelphone
		private System.String m_RefundReceiverTelphone = "" ; 
		/// <summary>
		/// RefundReceiverTelphone 收货人电话
		/// </summary>
		public System.String RefundReceiverTelphone
		{
			get
			{
				return this.m_RefundReceiverTelphone ;
			}
			set
			{
				this.m_RefundReceiverTelphone = value ;
			}
		}
		#endregion
	
		#region RefundReceiverCityZone
		private System.String m_RefundReceiverCityZone = "" ; 
		/// <summary>
		/// RefundReceiverCityZone 所在城市，格式：xx省xx市xx区
		/// </summary>
		public System.String RefundReceiverCityZone
		{
			get
			{
				return this.m_RefundReceiverCityZone ;
			}
			set
			{
				this.m_RefundReceiverCityZone = value ;
			}
		}
		#endregion
	
		#region RefundReceiverDetailAddress
		private System.String m_RefundReceiverDetailAddress = "" ; 
		/// <summary>
		/// RefundReceiverDetailAddress 收货详细地址：xx街道xx小区xx栋xx号
		/// </summary>
		public System.String RefundReceiverDetailAddress
		{
			get
			{
				return this.m_RefundReceiverDetailAddress ;
			}
			set
			{
				this.m_RefundReceiverDetailAddress = value ;
			}
		}
		#endregion
	
		#region TimeExpressStart
		private System.DateTime m_TimeExpressStart = DateTime.Now ; 
		/// <summary>
		/// TimeExpressStart 买家填写快递单号的时间
		/// </summary>
		public System.DateTime TimeExpressStart
		{
			get
			{
				return this.m_TimeExpressStart ;
			}
			set
			{
				this.m_TimeExpressStart = value ;
			}
		}
		#endregion
	
		#region ExpressCompany4Refund
		private System.String m_ExpressCompany4Refund = "" ; 
		/// <summary>
		/// ExpressCompany4Refund 快递公司名称（买家退货）
		/// </summary>
		public System.String ExpressCompany4Refund
		{
			get
			{
				return this.m_ExpressCompany4Refund ;
			}
			set
			{
				this.m_ExpressCompany4Refund = value ;
			}
		}
		#endregion
	
		#region ExpressOrderID4Refund
		private System.String m_ExpressOrderID4Refund = "" ; 
		/// <summary>
		/// ExpressOrderID4Refund 快递单号（买家退货）
		/// </summary>
		public System.String ExpressOrderID4Refund
		{
			get
			{
				return this.m_ExpressOrderID4Refund ;
			}
			set
			{
				this.m_ExpressOrderID4Refund = value ;
			}
		}
		#endregion
	
		#region RefundRequestCount
		private System.Int32 m_RefundRequestCount = 0 ; 
		/// <summary>
		/// RefundRequestCount 退款申请次数（最多允许2次申请）
		/// </summary>
		public System.Int32 RefundRequestCount
		{
			get
			{
				return this.m_RefundRequestCount ;
			}
			set
			{
				this.m_RefundRequestCount = value ;
			}
		}
		#endregion
	
		#region LastUpdateTime
		private System.DateTime m_LastUpdateTime = DateTime.Now ; 
		/// <summary>
		/// LastUpdateTime 最后修改时间
		/// </summary>
		public System.DateTime LastUpdateTime
		{
			get
			{
				return this.m_LastUpdateTime ;
			}
			set
			{
				this.m_LastUpdateTime = value ;
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
