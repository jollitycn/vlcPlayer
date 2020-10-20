using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class DistributorCommissionRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "DistributorCommissionRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _OrderID = "OrderID" ;
		public const string _OrderUserID = "OrderUserID" ;
		public const string _SequenceCode = "SequenceCode" ;
		public const string _DistributorID = "DistributorID" ;
		public const string _OrderMoney = "OrderMoney" ;
		public const string _Commission = "Commission" ;
		public const string _LevelGap = "LevelGap" ;
		public const string _OrderTime = "OrderTime" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _DistributorType = "DistributorType" ;
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
	
		#region OrderID
		private System.String m_OrderID = "" ; 
		/// <summary>
		/// OrderID 单据id
		/// </summary>
		public System.String OrderID
		{
			get
			{
				return this.m_OrderID ;
			}
			set
			{
				this.m_OrderID = value ;
			}
		}
		#endregion
	
		#region OrderUserID
		private System.String m_OrderUserID = "" ; 
		/// <summary>
		/// OrderUserID 产生佣金人员id
		/// </summary>
		public System.String OrderUserID
		{
			get
			{
				return this.m_OrderUserID ;
			}
			set
			{
				this.m_OrderUserID = value ;
			}
		}
		#endregion
	
		#region SequenceCode
		private System.String m_SequenceCode = "" ; 
		/// <summary>
		/// SequenceCode 产生佣金人员序列编码
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
	
		#region DistributorID
		private System.String m_DistributorID = "" ; 
		/// <summary>
		/// DistributorID 分销人员id
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
	
		#region OrderMoney
		private System.Decimal m_OrderMoney = 0 ; 
		/// <summary>
		/// OrderMoney 原始金额
		/// </summary>
		public System.Decimal OrderMoney
		{
			get
			{
				return this.m_OrderMoney ;
			}
			set
			{
				this.m_OrderMoney = value ;
			}
		}
		#endregion
	
		#region Commission
		private System.Decimal m_Commission = 0 ; 
		/// <summary>
		/// Commission 佣金
		/// </summary>
		public System.Decimal Commission
		{
			get
			{
				return this.m_Commission ;
			}
			set
			{
				this.m_Commission = value ;
			}
		}
		#endregion
	
		#region LevelGap
		private System.Byte m_LevelGap = 0 ; 
		/// <summary>
		/// LevelGap 级别差
		/// </summary>
		public System.Byte LevelGap
		{
			get
			{
				return this.m_LevelGap ;
			}
			set
			{
				this.m_LevelGap = value ;
			}
		}
		#endregion
	
		#region OrderTime
		private System.DateTime m_OrderTime = DateTime.Now ; 
		/// <summary>
		/// OrderTime 单据时间
		/// </summary>
		public System.DateTime OrderTime
		{
			get
			{
				return this.m_OrderTime ;
			}
			set
			{
				this.m_OrderTime = value ;
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
