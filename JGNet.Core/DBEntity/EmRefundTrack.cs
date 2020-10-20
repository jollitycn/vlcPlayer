using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmRefundTrack : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "EmRefundTrack" ;
		public const string _AutoID = "AutoID" ;
		public const string _EmRefundOrderID = "EmRefundOrderID" ;
		public const string _OperatorUserID = "OperatorUserID" ;
		public const string _OperateCause = "OperateCause" ;
		public const string _OperateNote = "OperateNote" ;
		public const string _OperateType = "OperateType" ;
		public const string _OnlyRefundMoney = "OnlyRefundMoney" ;
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
	
		#region EmRefundOrderID
		private System.String m_EmRefundOrderID = "" ; 
		/// <summary>
		/// EmRefundOrderID 线上销售单号
		/// </summary>
		public System.String EmRefundOrderID
		{
			get
			{
				return this.m_EmRefundOrderID ;
			}
			set
			{
				this.m_EmRefundOrderID = value ;
			}
		}
		#endregion
	
		#region OperatorUserID
		private System.String m_OperatorUserID = "" ; 
		/// <summary>
		/// OperatorUserID 操作人id
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
	
		#region OperateCause
		private System.String m_OperateCause = "" ; 
		/// <summary>
		/// OperateCause 退货原因
		/// </summary>
		public System.String OperateCause
		{
			get
			{
				return this.m_OperateCause ;
			}
			set
			{
				this.m_OperateCause = value ;
			}
		}
		#endregion
	
		#region OperateNote
		private System.String m_OperateNote = "" ; 
		/// <summary>
		/// OperateNote 说明
		/// </summary>
		public System.String OperateNote
		{
			get
			{
				return this.m_OperateNote ;
			}
			set
			{
				this.m_OperateNote = value ;
			}
		}
		#endregion
	
		#region OperateType
		private System.Byte m_OperateType = 0 ; 
		/// <summary>
		/// OperateType 操作类型  0：申请退款，1：拒绝退款， 2：同意退款，3：确认退款
		/// </summary>
		public System.Byte OperateType
		{
			get
			{
				return this.m_OperateType ;
			}
			set
			{
				this.m_OperateType = value ;
			}
		}
		#endregion
	
		#region OnlyRefundMoney
		private System.Boolean m_OnlyRefundMoney = false ; 
		/// <summary>
		/// OnlyRefundMoney 仅退款？
		/// </summary>
		public System.Boolean OnlyRefundMoney
		{
			get
			{
				return this.m_OnlyRefundMoney ;
			}
			set
			{
				this.m_OnlyRefundMoney = value ;
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
