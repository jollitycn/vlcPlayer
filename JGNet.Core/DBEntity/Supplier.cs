using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class Supplier : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "Supplier" ;
		public const string _ID = "ID" ;
		public const string _BusinessAccountID = "BusinessAccountID" ;
		public const string _Name = "Name" ;
		public const string _SupplyDiscount = "SupplyDiscount" ;
		public const string _Contact = "Contact" ;
		public const string _ContactPhone = "ContactPhone" ;
		public const string _BankInfo = "BankInfo" ;
		public const string _PaymentBalance = "PaymentBalance" ;
		public const string _LastAccountTime = "LastAccountTime" ;
		public const string _FirstCharSpell = "FirstCharSpell" ;
		public const string _OrderNo = "OrderNo" ;
		public const string _Remarks = "Remarks" ;
		public const string _Enabled = "Enabled" ;
		public const string _CreateTime = "CreateTime" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 供应商编号（主键）
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
	
		#region BusinessAccountID
		private System.String m_BusinessAccountID = "" ; 
		/// <summary>
		/// BusinessAccountID 帐套ID
		/// </summary>
		public System.String BusinessAccountID
		{
			get
			{
				return this.m_BusinessAccountID ;
			}
			set
			{
				this.m_BusinessAccountID = value ;
			}
		}
		#endregion
	
		#region Name
		private System.String m_Name = "" ; 
		/// <summary>
		/// Name 名称
		/// </summary>
		public System.String Name
		{
			get
			{
				return this.m_Name ;
			}
			set
			{
				this.m_Name = value ;
			}
		}
		#endregion
	
		#region SupplyDiscount
		private System.Decimal m_SupplyDiscount = 0 ; 
		/// <summary>
		/// SupplyDiscount 进货折扣
		/// </summary>
		public System.Decimal SupplyDiscount
		{
			get
			{
				return this.m_SupplyDiscount ;
			}
			set
			{
				this.m_SupplyDiscount = value ;
			}
		}
		#endregion
	
		#region Contact
		private System.String m_Contact = "" ; 
		/// <summary>
		/// Contact 联系人
		/// </summary>
		public System.String Contact
		{
			get
			{
				return this.m_Contact ;
			}
			set
			{
				this.m_Contact = value ;
			}
		}
		#endregion
	
		#region ContactPhone
		private System.String m_ContactPhone = "" ; 
		/// <summary>
		/// ContactPhone 联系电话
		/// </summary>
		public System.String ContactPhone
		{
			get
			{
				return this.m_ContactPhone ;
			}
			set
			{
				this.m_ContactPhone = value ;
			}
		}
		#endregion
	
		#region BankInfo
		private System.String m_BankInfo = "" ; 
		/// <summary>
		/// BankInfo 银行账户信息
		/// </summary>
		public System.String BankInfo
		{
			get
			{
				return this.m_BankInfo ;
			}
			set
			{
				this.m_BankInfo = value ;
			}
		}
		#endregion
	
		#region PaymentBalance
		private System.Decimal m_PaymentBalance = 0 ; 
		/// <summary>
		/// PaymentBalance 应付款结余（负数表示欠供应商的金额）
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
	
		#region LastAccountTime
		private System.DateTime m_LastAccountTime = DateTime.Now ; 
		/// <summary>
		/// LastAccountTime 最后一次记账时间
		/// </summary>
		public System.DateTime LastAccountTime
		{
			get
			{
				return this.m_LastAccountTime ;
			}
			set
			{
				this.m_LastAccountTime = value ;
			}
		}
		#endregion
	
		#region FirstCharSpell
		private System.String m_FirstCharSpell = "" ; 
		/// <summary>
		/// FirstCharSpell 首拼字母缩写（全小写）
		/// </summary>
		public System.String FirstCharSpell
		{
			get
			{
				return this.m_FirstCharSpell ;
			}
			set
			{
				this.m_FirstCharSpell = value ;
			}
		}
		#endregion
	
		#region OrderNo
		private System.Int32 m_OrderNo = 0 ; 
		/// <summary>
		/// OrderNo 用于排序的序号。
		/// </summary>
		public System.Int32 OrderNo
		{
			get
			{
				return this.m_OrderNo ;
			}
			set
			{
				this.m_OrderNo = value ;
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
	
		#region Enabled
		private System.Boolean m_Enabled = false ; 
		/// <summary>
		/// Enabled 是否启用
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
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 创建日期
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
	    public System.String GetPKeyValue()
	    {
	       return this.ID;
	    }
	    #endregion
	}
}
