using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class ReplenishOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "ReplenishOrder" ;
		public const string _ID = "ID" ;
		public const string _RequestGuideID = "RequestGuideID" ;
		public const string _ShopID = "ShopID" ;
		public const string _AllocateOrderID = "AllocateOrderID" ;
		public const string _State = "State" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _TotalPrice = "TotalPrice" ;
		public const string _Remarks = "Remarks" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _FinishedTime = "FinishedTime" ;
		public const string _CancelTime = "CancelTime" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 单据编号（主键）
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
	
		#region RequestGuideID
		private System.String m_RequestGuideID = "" ; 
		/// <summary>
		/// RequestGuideID 补货申请的导购
		/// </summary>
		public System.String RequestGuideID
		{
			get
			{
				return this.m_RequestGuideID ;
			}
			set
			{
				this.m_RequestGuideID = value ;
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
	
		#region AllocateOrderID
		private System.String m_AllocateOrderID = "" ; 
		/// <summary>
		/// AllocateOrderID 调拨单ID
		/// </summary>
		public System.String AllocateOrderID
		{
			get
			{
				return this.m_AllocateOrderID ;
			}
			set
			{
				this.m_AllocateOrderID = value ;
			}
		}
		#endregion
	
		#region State
		private System.Byte m_State = 0 ;
        /// <summary>
        /// State 状态：0（未处理），1（已处理），2（已拒绝），3（取消），4（冲单）
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
	
		#region TotalCount
		private System.Int32 m_TotalCount = 0 ; 
		/// <summary>
		/// TotalCount 总件数
		/// </summary>
		public System.Int32 TotalCount
		{
			get
			{
				return this.m_TotalCount ;
			}
			set
			{
				this.m_TotalCount = value ;
			}
		}
		#endregion
	
		#region TotalPrice
		private System.Decimal m_TotalPrice = 0 ; 
		/// <summary>
		/// TotalPrice 货品吊牌额
		/// </summary>
		public System.Decimal TotalPrice
		{
			get
			{
				return this.m_TotalPrice ;
			}
			set
			{
				this.m_TotalPrice = value ;
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
		/// CreateTime 开单日期
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
	
		#region FinishedTime
		private System.DateTime m_FinishedTime = DateTime.Now ; 
		/// <summary>
		/// FinishedTime 完成/取消日期
		/// </summary>
		public System.DateTime FinishedTime
		{
			get
			{
				return this.m_FinishedTime ;
			}
			set
			{
				this.m_FinishedTime = value ;
			}
		}
		#endregion
	
		#region CancelTime
		private System.DateTime m_CancelTime = DateTime.Now ; 
		/// <summary>
		/// CancelTime 冲单时间
		/// </summary>
		public System.DateTime CancelTime
		{
			get
			{
				return this.m_CancelTime ;
			}
			set
			{
				this.m_CancelTime = value ;
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
