using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PfCustomerRechargeRecord : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "PfCustomerRechargeRecord" ;
		public const string _ID = "ID" ;
		public const string _PfCustomerID = "PfCustomerID" ;
		public const string _BalanceOld = "BalanceOld" ;
		public const string _RechargeMoney = "RechargeMoney" ;
		public const string _BalanceNew = "BalanceNew" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _Remarks = "Remarks" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 充值记录编号（主键）
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
	
		#region BalanceOld
		private System.Decimal m_BalanceOld = 0 ; 
		/// <summary>
		/// BalanceOld 充值前余额
		/// </summary>
		public System.Decimal BalanceOld
		{
			get
			{
				return this.m_BalanceOld ;
			}
			set
			{
				this.m_BalanceOld = value ;
			}
		}
		#endregion
	
		#region RechargeMoney
		private System.Int32 m_RechargeMoney = 0 ; 
		/// <summary>
		/// RechargeMoney 充值金额
		/// </summary>
		public System.Int32 RechargeMoney
		{
			get
			{
				return this.m_RechargeMoney ;
			}
			set
			{
				this.m_RechargeMoney = value ;
			}
		}
		#endregion
	
		#region BalanceNew
		private System.Decimal m_BalanceNew = 0 ; 
		/// <summary>
		/// BalanceNew 充值后余额
		/// </summary>
		public System.Decimal BalanceNew
		{
			get
			{
				return this.m_BalanceNew ;
			}
			set
			{
				this.m_BalanceNew = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 充值时间
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
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.ID;
	    }
	    #endregion
	}
}
