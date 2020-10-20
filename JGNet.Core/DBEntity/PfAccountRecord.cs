using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PfAccountRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "PfAccountRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _PfCustomerID = "PfCustomerID" ;
		public const string _AccountType = "AccountType" ;
		public const string _PayType = "PayType" ;
		public const string _AccountMoney = "AccountMoney" ;
		public const string _PaymentBalanceOld = "PaymentBalanceOld" ;
		public const string _PaymentBalance = "PaymentBalance" ;
		public const string _SourceOrderID = "SourceOrderID" ;
		public const string _AdminUserID = "AdminUserID" ;
		public const string _Remarks = "Remarks" ;
		public const string _CreateTime = "CreateTime" ;
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
	
		#region PfCustomerID
		private System.String m_PfCustomerID = "" ; 
		/// <summary>
		/// PfCustomerID 批发客户编号
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
	
		#region AccountType
		private System.Byte m_AccountType = 0 ; 
		/// <summary>
		/// AccountType 记账类型。0-收款，1-退款，2-发货，3-退货。
		/// </summary>
		public System.Byte AccountType
		{
			get
			{
				return this.m_AccountType ;
			}
			set
			{
				this.m_AccountType = value ;
			}
		}
		#endregion
	
		#region PayType
		private System.Byte m_PayType = 0 ; 
		/// <summary>
		/// PayType 收款方式（0：微信，1：支付宝，2：银联卡，3：现金，4：其他，5：余额）

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
	
		#region AccountMoney
		private System.Decimal m_AccountMoney = 0 ; 
		/// <summary>
		/// AccountMoney 记账金额。正数：批发客户欠我的。收款-负，退款-正，发货-正，退货-负。
		/// </summary>
		public System.Decimal AccountMoney
		{
			get
			{
				return this.m_AccountMoney ;
			}
			set
			{
				this.m_AccountMoney = value ;
			}
		}
		#endregion
	
		#region PaymentBalanceOld
		private System.Decimal m_PaymentBalanceOld = 0 ; 
		/// <summary>
		/// PaymentBalanceOld 之前应收款结余（正数：批发客户欠我的）
		/// </summary>
		public System.Decimal PaymentBalanceOld
		{
			get
			{
				return this.m_PaymentBalanceOld ;
			}
			set
			{
				this.m_PaymentBalanceOld = value ;
			}
		}
		#endregion
	
		#region PaymentBalance
		private System.Decimal m_PaymentBalance = 0 ; 
		/// <summary>
		/// PaymentBalance 现在应收款结余 = PaymentBalanceOld + AccountMoney
		/// </summary>
		public System.Decimal PaymentBalance
		{
			get
			{
				return this.m_PaymentBalance ;
			}
			set
			{
				this.m_PaymentBalance = value ;
			}
		}
		#endregion
	
		#region SourceOrderID
		private System.String m_SourceOrderID = "" ; 
		/// <summary>
		/// SourceOrderID 来源单据编号（批发单）
		/// </summary>
		public System.String SourceOrderID
		{
			get
			{
				return this.m_SourceOrderID ;
			}
			set
			{
				this.m_SourceOrderID = value ;
			}
		}
		#endregion
	
		#region AdminUserID
		private System.String m_AdminUserID = "" ; 
		/// <summary>
		/// AdminUserID 操作人ID
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
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 日期
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
