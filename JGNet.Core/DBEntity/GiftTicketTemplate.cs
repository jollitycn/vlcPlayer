using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class GiftTicketTemplate : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "GiftTicketTemplate" ;
		public const string _AutoID = "AutoID" ;
		public const string _Denomination = "Denomination" ;
		public const string _MinMoney = "MinMoney" ;
		public const string _MinDiscount = "MinDiscount" ;
		public const string _TicketDescription = "TicketDescription" ;
		public const string _OperatorUserID = "OperatorUserID" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _IsAnd = "IsAnd" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自动编号（主键）
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
		/// TicketDescription 描述（由系统自动生成）
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
	
		#region OperatorUserID
		private System.String m_OperatorUserID = "" ; 
		/// <summary>
		/// OperatorUserID 操作用户ID
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
		/// CreateTime 创建时间
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
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
