using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PfCustomer : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "PfCustomer" ;
		public const string _ID = "ID" ;
		public const string _BusinessAccountID = "BusinessAccountID" ;
		public const string _Name = "Name" ;
		public const string _FirstCharSpell = "FirstCharSpell" ;
		public const string _Password = "Password" ;
		public const string _PfDiscount = "PfDiscount" ;
		public const string _Contact = "Contact" ;
		public const string _ContactPhone = "ContactPhone" ;
		public const string _BankInfo = "BankInfo" ;
		public const string _PaymentBalance = "PaymentBalance" ;
		public const string _LastAccountTime = "LastAccountTime" ;
		public const string _Balance = "Balance" ;
		public const string _DefaultAddressID = "DefaultAddressID" ;
		public const string _Remarks = "Remarks" ;
		public const string _Enabled = "Enabled" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _DistributorID = "DistributorID" ;
		public const string _PfCustomerOrderMoney = "PfCustomerOrderMoney" ;
		public const string _WithdrawMoney = "WithdrawMoney" ;
		public const string _LastBuyTime = "LastBuyTime" ;
		public const string _CustomerType = "CustomerType" ;
		public const string _AccruedCommission = "AccruedCommission" ;
		public const string _WithdrawCommission = "WithdrawCommission" ;
		public const string _MemberLevel = "MemberLevel" ;
		public const string _SequenceCode = "SequenceCode" ;
		public const string _IsIntroducer = "IsIntroducer" ;
		public const string _PfCustomerCount = "PfCustomerCount" ;
		public const string _SeeCommission = "SeeCommission" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 批发客户编号（主键）
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
	
		#region Password
		private System.String m_Password = "" ; 
		/// <summary>
		/// Password 密码
		/// </summary>
		public System.String Password
		{
			get
			{
				return this.m_Password ;
			}
			set
			{
				this.m_Password = value ;
			}
		}
		#endregion
	
		#region PfDiscount
		private System.Decimal m_PfDiscount = 0 ; 
		/// <summary>
		/// PfDiscount 批发折扣
		/// </summary>
		public System.Decimal PfDiscount
		{
			get
			{
				return this.m_PfDiscount ;
			}
			set
			{
				this.m_PfDiscount = value ;
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
		/// PaymentBalance 应付款结余（正数：批发客户欠我的）
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
	
		#region Balance
		private System.Decimal m_Balance = 0 ; 
		/// <summary>
		/// Balance 余额（手机批发商城使用）
		/// </summary>
		public System.Decimal Balance
		{
			get
			{
				return this.m_Balance ;
			}
			set
			{
				this.m_Balance = value ;
			}
		}
		#endregion
	
		#region DefaultAddressID
		private System.Int32 m_DefaultAddressID = 0 ; 
		/// <summary>
		/// DefaultAddressID 默认收货地址ID
		/// </summary>
		public System.Int32 DefaultAddressID
		{
			get
			{
				return this.m_DefaultAddressID ;
			}
			set
			{
				this.m_DefaultAddressID = value ;
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
	
		#region DistributorID
		private System.String m_DistributorID = "" ; 
		/// <summary>
		/// DistributorID 推荐人id
		/// </summary>
		public System.String DistributorID
		{
			get
			{
				return this.m_DistributorID ;
			}
			set
			{
				this.m_DistributorID = value ;
			}
		}
		#endregion
	
		#region PfCustomerOrderMoney
		private System.Decimal m_PfCustomerOrderMoney = 0 ; 
		/// <summary>
		/// PfCustomerOrderMoney 订货金额
		/// </summary>
		public System.Decimal PfCustomerOrderMoney
		{
			get
			{
				return this.m_PfCustomerOrderMoney ;
			}
			set
			{
				this.m_PfCustomerOrderMoney = value ;
			}
		}
		#endregion
	
		#region WithdrawMoney
		private System.Decimal m_WithdrawMoney = 0 ; 
		/// <summary>
		/// WithdrawMoney 回款金额
		/// </summary>
		public System.Decimal WithdrawMoney
		{
			get
			{
				return this.m_WithdrawMoney ;
			}
			set
			{
				this.m_WithdrawMoney = value ;
			}
		}
		#endregion
	
		#region LastBuyTime
		private System.DateTime m_LastBuyTime = DateTime.Now ; 
		/// <summary>
		/// LastBuyTime 最后一次购买时间
		/// </summary>
		public System.DateTime LastBuyTime
		{
			get
			{
				return this.m_LastBuyTime ;
			}
			set
			{
				this.m_LastBuyTime = value ;
			}
		}
		#endregion
	
		#region CustomerType
		private System.Byte m_CustomerType = 0 ; 
		/// <summary>
		/// CustomerType 客户类型（0：买断，1：代卖）
		/// </summary>
		public System.Byte CustomerType
		{
			get
			{
				return this.m_CustomerType ;
			}
			set
			{
				this.m_CustomerType = value ;
			}
		}
		#endregion
	
		#region AccruedCommission
		private System.Decimal m_AccruedCommission = 0 ; 
		/// <summary>
		/// AccruedCommission 累计佣金
		/// </summary>
		public System.Decimal AccruedCommission
		{
			get
			{
				return this.m_AccruedCommission ;
			}
			set
			{
				this.m_AccruedCommission = value ;
			}
		}
		#endregion
	
		#region WithdrawCommission
		private System.Decimal m_WithdrawCommission = 0 ; 
		/// <summary>
		/// WithdrawCommission 已提现佣金
		/// </summary>
		public System.Decimal WithdrawCommission
		{
			get
			{
				return this.m_WithdrawCommission ;
			}
			set
			{
				this.m_WithdrawCommission = value ;
			}
		}
		#endregion
	
		#region MemberLevel
		private System.Int32 m_MemberLevel = 0 ; 
		/// <summary>
		/// MemberLevel 等级0：1级，1：2级…
		/// </summary>
		public System.Int32 MemberLevel
		{
			get
			{
				return this.m_MemberLevel ;
			}
			set
			{
				this.m_MemberLevel = value ;
			}
		}
		#endregion
	
		#region SequenceCode
		private System.String m_SequenceCode = "" ; 
		/// <summary>
		/// SequenceCode 序列编码
		/// </summary>
		public System.String SequenceCode
		{
			get
			{
				return this.m_SequenceCode ;
			}
			set
			{
				this.m_SequenceCode = value ;
			}
		}
		#endregion
	
		#region IsIntroducer
		private System.Boolean m_IsIntroducer = false ; 
		/// <summary>
		/// IsIntroducer 是否是推荐人
		/// </summary>
		public System.Boolean IsIntroducer
		{
			get
			{
				return this.m_IsIntroducer ;
			}
			set
			{
				this.m_IsIntroducer = value ;
			}
		}
		#endregion
	
		#region PfCustomerCount
		private System.Int32 m_PfCustomerCount = 0 ; 
		/// <summary>
		/// PfCustomerCount 下线客户数量
		/// </summary>
		public System.Int32 PfCustomerCount
		{
			get
			{
				return this.m_PfCustomerCount ;
			}
			set
			{
				this.m_PfCustomerCount = value ;
			}
		}
		#endregion
	
		#region SeeCommission
		private System.Boolean m_SeeCommission = false ; 
		/// <summary>
		/// SeeCommission 能否看佣金（0：不能，1：能）
		/// </summary>
		public System.Boolean SeeCommission
		{
			get
			{
				return this.m_SeeCommission ;
			}
			set
			{
				this.m_SeeCommission = value ;
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
