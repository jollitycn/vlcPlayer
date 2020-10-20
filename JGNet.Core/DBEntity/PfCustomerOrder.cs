using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PfCustomerOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "PfCustomerOrder" ;
		public const string _ID = "ID" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EntryTime = "EntryTime" ;
		public const string _PfCustomerID = "PfCustomerID" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _DeliveryCount = "DeliveryCount" ;
		public const string _TotalPrice = "TotalPrice" ;
		public const string _TotalPfPrice = "TotalPfPrice" ;
		public const string _Remarks = "Remarks" ;
		public const string _State = "State" ;
		public const string _ReceiverName = "ReceiverName" ;
		public const string _ReceiverTelphone = "ReceiverTelphone" ;
		public const string _ReceiverCityZone = "ReceiverCityZone" ;
		public const string _ReceiverDetailAddress = "ReceiverDetailAddress" ;
		public const string _TimePay = "TimePay" ;
		public const string _IsPay = "IsPay" ;
		public const string _MoneyWeiXin = "MoneyWeiXin" ;
		public const string _MoneyVipCard = "MoneyVipCard" ;
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
	
		#region PfCustomerID
		private System.String m_PfCustomerID = "" ; 
		/// <summary>
		/// PfCustomerID 批发客户
		/// </summary>
		public System.String PfCustomerID
		{
			get
			{
				return this.m_PfCustomerID ;
			}
			set
			{
				this.m_PfCustomerID = value ;
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
	
		#region DeliveryCount
		private System.Int32 m_DeliveryCount = 0 ; 
		/// <summary>
		/// DeliveryCount 已发货件数
		/// </summary>
		public System.Int32 DeliveryCount
		{
			get
			{
				return this.m_DeliveryCount ;
			}
			set
			{
				this.m_DeliveryCount = value ;
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
	
		#region TotalPfPrice
		private System.Decimal m_TotalPfPrice = 0 ; 
		/// <summary>
		/// TotalPfPrice 总批发金额
		/// </summary>
		public System.Decimal TotalPfPrice
		{
			get
			{
				return this.m_TotalPfPrice ;
			}
			set
			{
				this.m_TotalPfPrice = value ;
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
	
		#region State
		private System.Byte m_State = 0 ; 
		/// <summary>
		/// State 0:待发货、1:部分发货、2:已完成、3:已作废
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
	
		#region IsPay
		private System.Boolean m_IsPay = false ; 
		/// <summary>
		/// IsPay 是否支付
		/// </summary>
		public System.Boolean IsPay
		{
			get
			{
				return this.m_IsPay ;
			}
			set
			{
				this.m_IsPay = value ;
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
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.ID;
	    }
	    #endregion
	}
}
