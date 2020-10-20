using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class CheckStoreSummary : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "CheckStoreSummary" ;
		public const string _AutoID = "AutoID" ;
		public const string _CheckStoreTaskID = "CheckStoreTaskID" ;
		public const string _ShopID = "ShopID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _CountInSnapshot = "CountInSnapshot" ;
		public const string _CountInCheck = "CountInCheck" ;
		public const string _WinLostCount = "WinLostCount" ;
		public const string _AveragePrice = "AveragePrice" ;
		public const string _AveragePrice2 = "AveragePrice2" ;
		public const string _WinLostMoney = "WinLostMoney" ;
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
	
		#region CheckStoreTaskID
		private System.String m_CheckStoreTaskID = "" ; 
		/// <summary>
		/// CheckStoreTaskID 盘点任务编号
		/// </summary>
		public System.String CheckStoreTaskID
		{
			get
			{
				return this.m_CheckStoreTaskID ;
			}
			set
			{
				this.m_CheckStoreTaskID = value ;
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
	
		#region CostumeID
		private System.String m_CostumeID = "" ; 
		/// <summary>
		/// CostumeID 服装ID
		/// </summary>
		public System.String CostumeID
		{
			get
			{
				return this.m_CostumeID ;
			}
			set
			{
				this.m_CostumeID = value ;
			}
		}
		#endregion
	
		#region CountInSnapshot
		private System.Int32 m_CountInSnapshot = 0 ; 
		/// <summary>
		/// CountInSnapshot 账面数
		/// </summary>
		public System.Int32 CountInSnapshot
		{
			get
			{
				return this.m_CountInSnapshot ;
			}
			set
			{
				this.m_CountInSnapshot = value ;
			}
		}
		#endregion
	
		#region CountInCheck
		private System.Int32 m_CountInCheck = 0 ; 
		/// <summary>
		/// CountInCheck 盘点数（即变化数）
		/// </summary>
		public System.Int32 CountInCheck
		{
			get
			{
				return this.m_CountInCheck ;
			}
			set
			{
				this.m_CountInCheck = value ;
			}
		}
		#endregion
	
		#region WinLostCount
		private System.Int32 m_WinLostCount = 0 ; 
		/// <summary>
		/// WinLostCount 盈亏数
		/// </summary>
		public System.Int32 WinLostCount
		{
			get
			{
				return this.m_WinLostCount ;
			}
			set
			{
				this.m_WinLostCount = value ;
			}
		}
		#endregion
	
		#region AveragePrice
		private System.Decimal m_AveragePrice = 0 ; 
		/// <summary>
		/// AveragePrice 平均售价
		/// </summary>
		public System.Decimal AveragePrice
		{
			get
			{
				return this.m_AveragePrice ;
			}
			set
			{
				this.m_AveragePrice = value ;
			}
		}
		#endregion
	
		#region AveragePrice2
		private System.Decimal m_AveragePrice2 = 0 ; 
		/// <summary>
		/// AveragePrice2 平均售价（手动调整后），初始取值AveragePrice
		/// </summary>
		public System.Decimal AveragePrice2
		{
			get
			{
				return this.m_AveragePrice2 ;
			}
			set
			{
				this.m_AveragePrice2 = value ;
			}
		}
		#endregion
	
		#region WinLostMoney
		private System.Decimal m_WinLostMoney = 0 ; 
		/// <summary>
		/// WinLostMoney 盈亏金额 = WinLostCount * AveragePrice2
		/// </summary>
		public System.Decimal WinLostMoney
		{
			get
			{
				return this.m_WinLostMoney ;
			}
			set
			{
				this.m_WinLostMoney = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 时间
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
