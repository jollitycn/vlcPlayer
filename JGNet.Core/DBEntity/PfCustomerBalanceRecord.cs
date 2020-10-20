using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PfCustomerBalanceRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "PfCustomerBalanceRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _PfCustomerID = "PfCustomerID" ;
		public const string _ChangeType = "ChangeType" ;
		public const string _ChangeMoney = "ChangeMoney" ;
		public const string _BalanceNew = "BalanceNew" ;
		public const string _SourceOrderID = "SourceOrderID" ;
		public const string _CreateTime = "CreateTime" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自增主键
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
	
		#region ChangeType
		private System.Byte m_ChangeType = 0 ; 
		/// <summary>
		/// ChangeType 变化类型。0-充值，1-订货单付款，2-发货付款，3-退货退款，4-后台记账收款，5-后台记账退款
		/// </summary>
		public System.Byte ChangeType
		{
			get
			{
				return this.m_ChangeType ;
			}
			set
			{
				this.m_ChangeType = value ;
			}
		}
		#endregion
	
		#region ChangeMoney
		private System.Decimal m_ChangeMoney = 0 ; 
		/// <summary>
		/// ChangeMoney 变化金额(充值：+，订货单付款：-，发货付款：-，退货退款：+，后台记账收款：-，后台记账退款：+)
		/// </summary>
		public System.Decimal ChangeMoney
		{
			get
			{
				return this.m_ChangeMoney ;
			}
			set
			{
				this.m_ChangeMoney = value ;
			}
		}
		#endregion
	
		#region BalanceNew
		private System.Decimal m_BalanceNew = 0 ; 
		/// <summary>
		/// BalanceNew 变化后金额
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
	
		#region SourceOrderID
		private System.String m_SourceOrderID = "" ; 
		/// <summary>
		/// SourceOrderID 来源单据编号
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
