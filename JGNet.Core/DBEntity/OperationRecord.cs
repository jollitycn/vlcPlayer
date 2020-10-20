using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class OperationRecord
	{
	    #region Force Static Check
		public const string TableName = "OperationRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _OperationUserID = "OperationUserID" ;
		public const string _OperationType = "OperationType" ;
		public const string _ShopID = "ShopID" ;
		public const string _OperationDescribe = "OperationDescribe" ;
		public const string _OperationTime = "OperationTime" ;
		public const string _OrderID = "OrderID" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自增ID(主键)，从1开始
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
	
		#region OperationUserID
		private System.String m_OperationUserID = "" ; 
		/// <summary>
		/// OperationUserID 操作人编号
		/// </summary>
		public System.String OperationUserID
		{
			get
			{
				return this.m_OperationUserID ;
			}
			set
			{
				this.m_OperationUserID = value ;
			}
		}
		#endregion
	
		#region OperationType
		private System.Byte m_OperationType = 0 ; 
		/// <summary>
		/// OperationType 操作人类型
		/// </summary>
		public System.Byte OperationType
		{
			get
			{
				return this.m_OperationType ;
			}
			set
			{
				this.m_OperationType = value ;
			}
		}
		#endregion
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 店铺id
		/// </summary>
		public System.String ShopID
		{
			get
			{
				return this.m_ShopID ;
			}
			set
			{
				this.m_ShopID = value ;
			}
		}
		#endregion
	
		#region OperationDescribe
		private System.String m_OperationDescribe = "" ; 
		/// <summary>
		/// OperationDescribe 操作描述
		/// </summary>
		public System.String OperationDescribe
		{
			get
			{
				return this.m_OperationDescribe ;
			}
			set
			{
				this.m_OperationDescribe = value ;
			}
		}
		#endregion
	
		#region OperationTime
		private System.DateTime m_OperationTime = DateTime.Now ; 
		/// <summary>
		/// OperationTime 操作时间
		/// </summary>
		public System.DateTime OperationTime
		{
			get
			{
				return this.m_OperationTime ;
			}
			set
			{
				this.m_OperationTime = value ;
			}
		}
		#endregion
	
		#region OrderID
		private System.String m_OrderID = "" ; 
		/// <summary>
		/// OrderID 单据编号
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
	    #endregion
	}
}
