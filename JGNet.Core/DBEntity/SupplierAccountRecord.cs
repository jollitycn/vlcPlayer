using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class SupplierAccountRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "SupplierAccountRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _SupplierID = "SupplierID" ;
		public const string _AccountType = "AccountType" ;
		public const string _PayType = "PayType" ;
		public const string _AccountMoney = "AccountMoney" ;
		public const string _PaymentBalanceOld = "PaymentBalanceOld" ;
		public const string _PaymentBalance = "PaymentBalance" ;
		public const string _SourceOrderID = "SourceOrderID" ;
		public const string _AdminUserID = "AdminUserID" ;
		public const string _Remarks = "Remarks" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EntryTime = "EntryTime" ;
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
	
		#region SupplierID
		private System.String m_SupplierID = "" ; 
		/// <summary>
		/// SupplierID 供应商编号
		/// </summary>
		public System.String SupplierID
		{
			get
			{
				return this.m_SupplierID ;
			}
			set
			{
				this.m_SupplierID = value ;
			}
		}
		#endregion
	
		#region AccountType
		private System.Byte m_AccountType = 0 ; 
		/// <summary>
		/// AccountType 记账类型。0-进货，1-退货，2-还款，3-收款。
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
		/// PayType 付款方式（0：微信，1：支付宝，2：银联卡，3：现金，4：其他）

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
		/// AccountMoney 记账金额。负数表示欠供应商。进货-负，退货-正，还款-正，收款-负。
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
		/// PaymentBalanceOld 之前应付款结余（负数表示欠供应商的金额）
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
		/// PaymentBalance 现在应付款结余 = PaymentBalanceOld + AccountMoney
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
		/// SourceOrderID 来源单据编号（采购进货单、采购退货单）
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
