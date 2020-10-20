using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class CheckStoreOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "CheckStoreOrder" ;
		public const string _ID = "ID" ;
		public const string _OperatorUserID = "OperatorUserID" ;
		public const string _CheckUserID = "CheckUserID" ;
		public const string _CancelUserID = "CancelUserID" ;
		public const string _ShopID = "ShopID" ;
		public const string _CheckStoreSum = "CheckStoreSum" ;
		public const string _CheckStoreWinCount = "CheckStoreWinCount" ;
		public const string _CheckStoreLostCount = "CheckStoreLostCount" ;
		public const string _Remarks = "Remarks" ;
		public const string _State = "State" ;
		public const string _ExpiredTime = "ExpiredTime" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EntryTime = "EntryTime" ;
		public const string _LastUpdateTime = "LastUpdateTime" ;
		public const string _CheckTime = "CheckTime" ;
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
	
		#region OperatorUserID
		private System.String m_OperatorUserID = "" ; 
		/// <summary>
		/// OperatorUserID 盘点用户ID
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
	
		#region CheckUserID
		private System.String m_CheckUserID = "" ; 
		/// <summary>
		/// CheckUserID 审核用户ID
		/// </summary>
		public System.String CheckUserID
		{
			get
			{
				return this.m_CheckUserID ;
			}
			set
			{
				this.m_CheckUserID = value ;
			}
		}
		#endregion
	
		#region CancelUserID
		private System.String m_CancelUserID = "" ; 
		/// <summary>
		/// CancelUserID 冲单用户ID
		/// </summary>
		public System.String CancelUserID
		{
			get
			{
				return this.m_CancelUserID ;
			}
			set
			{
				this.m_CancelUserID = value ;
			}
		}
		#endregion
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 盘点店铺ID
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
	
		#region CheckStoreSum
		private System.Int32 m_CheckStoreSum = 0 ; 
		/// <summary>
		/// CheckStoreSum 盘点总数
		/// </summary>
		public System.Int32 CheckStoreSum
		{
			get
			{
				return this.m_CheckStoreSum ;
			}
			set
			{
				this.m_CheckStoreSum = value ;
			}
		}
		#endregion
	
		#region CheckStoreWinCount
		private System.Int32 m_CheckStoreWinCount = 0 ; 
		/// <summary>
		/// CheckStoreWinCount 盘盈数
		/// </summary>
		public System.Int32 CheckStoreWinCount
		{
			get
			{
				return this.m_CheckStoreWinCount ;
			}
			set
			{
				this.m_CheckStoreWinCount = value ;
			}
		}
		#endregion
	
		#region CheckStoreLostCount
		private System.Int32 m_CheckStoreLostCount = 0 ; 
		/// <summary>
		/// CheckStoreLostCount 盘亏数
		/// </summary>
		public System.Int32 CheckStoreLostCount
		{
			get
			{
				return this.m_CheckStoreLostCount ;
			}
			set
			{
				this.m_CheckStoreLostCount = value ;
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
	
		#region State
		private System.Int32 m_State = 0 ; 
		/// <summary>
		/// State 待审核，已审核，已退回，已失效，挂起
		/// </summary>
		public System.Int32 State
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
	
		#region ExpiredTime
		private System.DateTime m_ExpiredTime = DateTime.Now ; 
		/// <summary>
		/// ExpiredTime 审核的最后期限，超过这个期限盘点单将失效
		/// </summary>
		public System.DateTime ExpiredTime
		{
			get
			{
				return this.m_ExpiredTime ;
			}
			set
			{
				this.m_ExpiredTime = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 单据日期
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
	
		#region EntryTime
		private System.DateTime m_EntryTime = DateTime.Now ; 
		/// <summary>
		/// EntryTime 制单时间
		/// </summary>
		public System.DateTime EntryTime
		{
			get
			{
				return this.m_EntryTime ;
			}
			set
			{
				this.m_EntryTime = value ;
			}
		}
		#endregion
	
		#region LastUpdateTime
		private System.DateTime m_LastUpdateTime = DateTime.Now ; 
		/// <summary>
		/// LastUpdateTime 最后修改时间
		/// </summary>
		public System.DateTime LastUpdateTime
		{
			get
			{
				return this.m_LastUpdateTime ;
			}
			set
			{
				this.m_LastUpdateTime = value ;
			}
		}
		#endregion
	
		#region CheckTime
		private System.DateTime m_CheckTime = DateTime.Now ; 
		/// <summary>
		/// CheckTime 审核时间
		/// </summary>
		public System.DateTime CheckTime
		{
			get
			{
				return this.m_CheckTime ;
			}
			set
			{
				this.m_CheckTime = value ;
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
