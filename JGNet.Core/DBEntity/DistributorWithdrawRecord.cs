using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class DistributorWithdrawRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "DistributorWithdrawRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _DistributorID = "DistributorID" ;
		public const string _OldMoney = "OldMoney" ;
		public const string _Money = "Money" ;
		public const string _State = "State" ;
		public const string _ConfirmTime = "ConfirmTime" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _DistributorType = "DistributorType" ;
		public const string _PaymentCdeUrl = "PaymentCdeUrl" ;
		public const string _Remarks = "Remarks" ;
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
	
		#region DistributorID
		private System.String m_DistributorID = "" ; 
		/// <summary>
		/// DistributorID 申请人id
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
	
		#region OldMoney
		private System.Decimal m_OldMoney = 0 ; 
		/// <summary>
		/// OldMoney 提款前金额
		/// </summary>
		public System.Decimal OldMoney
		{
			get
			{
				return this.m_OldMoney ;
			}
			set
			{
				this.m_OldMoney = value ;
			}
		}
		#endregion
	
		#region Money
		private System.Decimal m_Money = 0 ; 
		/// <summary>
		/// Money 申请金额
		/// </summary>
		public System.Decimal Money
		{
			get
			{
				return this.m_Money ;
			}
			set
			{
				this.m_Money = value ;
			}
		}
		#endregion
	
		#region State
		private System.Byte m_State = 0 ; 
		/// <summary>
		/// State 申请状态（0：待打款，1：已打款，2：无效）
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
	
		#region ConfirmTime
		private System.DateTime m_ConfirmTime = DateTime.Now ; 
		/// <summary>
		/// ConfirmTime 处理日期
		/// </summary>
		public System.DateTime ConfirmTime
		{
			get
			{
				return this.m_ConfirmTime ;
			}
			set
			{
				this.m_ConfirmTime = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 申请日期
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
	
		#region DistributorType
		private System.Byte m_DistributorType = 0 ; 
		/// <summary>
		/// DistributorType 申请人类型（0：批发，1：会员）
		/// </summary>
		public System.Byte DistributorType
		{
			get
			{
				return this.m_DistributorType ;
			}
			set
			{
				this.m_DistributorType = value ;
			}
		}
		#endregion
	
		#region PaymentCdeUrl
		private System.String m_PaymentCdeUrl = "" ; 
		/// <summary>
		/// PaymentCdeUrl 付款码链接地址
		/// </summary>
		public System.String PaymentCdeUrl
		{
			get
			{
				return this.m_PaymentCdeUrl ;
			}
			set
			{
				this.m_PaymentCdeUrl = value ;
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
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
