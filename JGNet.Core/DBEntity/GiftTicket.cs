using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class GiftTicket : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "GiftTicket" ;
		public const string _ID = "ID" ;
		public const string _Denomination = "Denomination" ;
		public const string _MinMoney = "MinMoney" ;
		public const string _MinDiscount = "MinDiscount" ;
		public const string _TicketDescription = "TicketDescription" ;
		public const string _MemberID = "MemberID" ;
		public const string _OperatorUserID = "OperatorUserID" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EffectDate = "EffectDate" ;
		public const string _ExpiredDate = "ExpiredDate" ;
		public const string _Enabled = "Enabled" ;
		public const string _RetailOrderID = "RetailOrderID" ;
		public const string _ShopID = "ShopID" ;
		public const string _UseTime = "UseTime" ;
		public const string _Remarks = "Remarks" ;
		public const string _IsAnd = "IsAnd" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 优惠券编号
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
	
		#region Denomination
		private System.Int32 m_Denomination = 0 ; 
		/// <summary>
		/// Denomination 优惠券面额
		/// </summary>
		public System.Int32 Denomination
		{
			get
			{
				return this.m_Denomination ;
			}
			set
			{
				this.m_Denomination = value ;
			}
		}
		#endregion
	
		#region MinMoney
		private System.Int32 m_MinMoney = 0 ; 
		/// <summary>
		/// MinMoney 最低达到多少金额，才能使用该优惠券
		/// </summary>
		public System.Int32 MinMoney
		{
			get
			{
				return this.m_MinMoney ;
			}
			set
			{
				this.m_MinMoney = value ;
			}
		}
		#endregion
	
		#region MinDiscount
		private System.Decimal m_MinDiscount = 0 ; 
		/// <summary>
		/// MinDiscount 最低达到多少折扣，才能使用该优惠券
		/// </summary>
		public System.Decimal MinDiscount
		{
			get
			{
				return this.m_MinDiscount ;
			}
			set
			{
				this.m_MinDiscount = value ;
			}
		}
		#endregion
	
		#region TicketDescription
		private System.String m_TicketDescription = "" ; 
		/// <summary>
		/// TicketDescription 描述
		/// </summary>
		public System.String TicketDescription
		{
			get
			{
				return this.m_TicketDescription ;
			}
			set
			{
				this.m_TicketDescription = value ;
			}
		}
		#endregion
	
		#region MemberID
		private System.String m_MemberID = "" ; 
		/// <summary>
		/// MemberID 会员ID（手机号）
		/// </summary>
		public System.String MemberID
		{
			get
			{
				return this.m_MemberID ;
			}
			set
			{
				this.m_MemberID = value ;
			}
		}
		#endregion
	
		#region OperatorUserID
		private System.String m_OperatorUserID = "" ; 
		/// <summary>
		/// OperatorUserID 发放优惠券的操作用户ID
		/// </summary>
		public System.String OperatorUserID
		{
			get
			{
				return this.m_OperatorUserID ;
			}
			set
			{
				this.m_OperatorUserID = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 发放时间
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
	
		#region EffectDate
		private System.DateTime m_EffectDate = DateTime.Now ; 
		/// <summary>
		/// EffectDate 生效日期
		/// </summary>
		public System.DateTime EffectDate
		{
			get
			{
				return this.m_EffectDate ;
			}
			set
			{
				this.m_EffectDate = value ;
			}
		}
		#endregion
	
		#region ExpiredDate
		private System.DateTime m_ExpiredDate = DateTime.Now ; 
		/// <summary>
		/// ExpiredDate 过期日期（能使用的最后一天）
		/// </summary>
		public System.DateTime ExpiredDate
		{
			get
			{
				return this.m_ExpiredDate ;
			}
			set
			{
				this.m_ExpiredDate = value ;
			}
		}
		#endregion
	
		#region Enabled
		private System.Boolean m_Enabled = false ; 
		/// <summary>
		/// Enabled 是否禁用？（如果禁用，即使没有过期，也不可用）
		/// </summary>
		public System.Boolean Enabled
		{
			get
			{
				return this.m_Enabled ;
			}
			set
			{
				this.m_Enabled = value ;
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
	
		#region UseTime
		private System.DateTime m_UseTime = DateTime.Now ; 
		/// <summary>
		/// UseTime 使用时间
		/// </summary>
		public System.DateTime UseTime
		{
			get
			{
				return this.m_UseTime ;
			}
			set
			{
				this.m_UseTime = value ;
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
	
		#region IsAnd
		private System.Boolean m_IsAnd = false ; 
		/// <summary>
		/// IsAnd 上述两个条件是“与”还是“或”？默认0（或）。
		/// </summary>
		public System.Boolean IsAnd
		{
			get
			{
				return this.m_IsAnd ;
			}
			set
			{
				this.m_IsAnd = value ;
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
