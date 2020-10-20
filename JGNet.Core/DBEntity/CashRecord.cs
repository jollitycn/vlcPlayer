using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class CashRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "CashRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _OperatorUserID = "OperatorUserID" ;
		public const string _MoneyCash = "MoneyCash" ;
		public const string _FeeType = "FeeType" ;
		public const string _FeeDetailType = "FeeDetailType" ;
		public const string _Remarks = "Remarks" ;
		public const string _CreateTime = "CreateTime" ;
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
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 店铺ID
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
	
		#region OperatorUserID
		private System.String m_OperatorUserID = "" ; 
		/// <summary>
		/// OperatorUserID 操作用户的ID
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
	
		#region MoneyCash
		private System.Decimal m_MoneyCash = 0 ; 
		/// <summary>
		/// MoneyCash 金额
		/// </summary>
		public System.Decimal MoneyCash
		{
			get
			{
				return this.m_MoneyCash ;
			}
			set
			{
				this.m_MoneyCash = value ;
			}
		}
		#endregion
	
		#region FeeType
		private System.Byte m_FeeType = 0 ; 
		/// <summary>
		/// FeeType 费用类型。0-上缴销售款，1-收入，2-支出。
		/// </summary>
		public System.Byte FeeType
		{
			get
			{
				return this.m_FeeType ;
			}
			set
			{
				this.m_FeeType = value ;
			}
		}
		#endregion
	
		#region FeeDetailType
		private System.String m_FeeDetailType = "" ; 
		/// <summary>
		/// FeeDetailType 费用具体类型。比如 水电费、门店物业管理费
		/// </summary>
		public System.String FeeDetailType
		{
			get
			{
				return this.m_FeeDetailType ;
			}
			set
			{
				this.m_FeeDetailType = value ;
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
