using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class Distributor : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "Distributor" ;
		public const string _ID = "ID" ;
		public const string _Name = "Name" ;
		public const string _Password = "Password" ;
		public const string _AccruedCommission = "AccruedCommission" ;
		public const string _WithdrawCommission = "WithdrawCommission" ;
		public const string _PfCustomerCount = "PfCustomerCount" ;
		public const string _CreateTime = "CreateTime" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
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
