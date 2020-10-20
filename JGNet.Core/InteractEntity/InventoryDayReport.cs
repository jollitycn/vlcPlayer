using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class InventoryDayReport : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "InventoryDayReport" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _ReportDate = "ReportDate" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _StartCount = "StartCount" ;
		public const string _StartMoney = "StartMoney" ;
		public const string _InCount = "InCount" ;
		public const string _InMoney = "InMoney" ;
		public const string _OutCount = "OutCount" ;
		public const string _OutMoney = "OutMoney" ;
		public const string _CheckStoreWinCount = "CheckStoreWinCount" ;
		public const string _CheckStoreWinMoney = "CheckStoreWinMoney" ;
		public const string _CheckStoreLostCount = "CheckStoreLostCount" ;
		public const string _CheckStoreLostMoney = "CheckStoreLostMoney" ;
		public const string _SalesCount = "SalesCount" ;
		public const string _SalesMoney = "SalesMoney" ;
		public const string _ScrapCount = "ScrapCount" ;
		public const string _ScrapMoney = "ScrapMoney" ;
		public const string _PfCount = "PfCount" ;
		public const string _PfMoney = "PfMoney" ;
		public const string _EndCount = "EndCount" ;
		public const string _EndMoney = "EndMoney" ;
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
	
		#region ReportDate
		private System.Int32 m_ReportDate = 0 ; 
		/// <summary>
		/// ReportDate 哪一天的统计，固定8位数字，如20180302
		/// </summary>
		public System.Int32 ReportDate
		{
			get
			{
				return this.m_ReportDate ;
			}
			set
			{
				this.m_ReportDate = value ;
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
	
		#region StartCount
		private System.Int32 m_StartCount = 0 ; 
		/// <summary>
		/// StartCount 这一天开始时的库存数
		/// </summary>
		public System.Int32 StartCount
		{
			get
			{
				return this.m_StartCount ;
			}
			set
			{
				this.m_StartCount = value ;
			}
		}
		#endregion
	
		#region StartMoney
		private System.Decimal m_StartMoney = 0 ; 
		/// <summary>
		/// StartMoney 这一天开始时的金额
		/// </summary>
		public System.Decimal StartMoney
		{
			get
			{
				return this.m_StartMoney ;
			}
			set
			{
				this.m_StartMoney = value ;
			}
		}
		#endregion
	
		#region InCount
		private System.Int32 m_InCount = 0 ; 
		/// <summary>
		/// InCount 进货入库数量（包括采购进货、调拨入库）
		/// </summary>
		public System.Int32 InCount
		{
			get
			{
				return this.m_InCount ;
			}
			set
			{
				this.m_InCount = value ;
			}
		}
		#endregion
	
		#region InMoney
		private System.Decimal m_InMoney = 0 ; 
		/// <summary>
		/// InMoney 进货入库金额
		/// </summary>
		public System.Decimal InMoney
		{
			get
			{
				return this.m_InMoney ;
			}
			set
			{
				this.m_InMoney = value ;
			}
		}
		#endregion
	
		#region OutCount
		private System.Int32 m_OutCount = 0 ; 
		/// <summary>
		/// OutCount 退货出库数量（包括采购退货、调拨）
		/// </summary>
		public System.Int32 OutCount
		{
			get
			{
				return this.m_OutCount ;
			}
			set
			{
				this.m_OutCount = value ;
			}
		}
		#endregion
	
		#region OutMoney
		private System.Decimal m_OutMoney = 0 ; 
		/// <summary>
		/// OutMoney 退货出库金额
		/// </summary>
		public System.Decimal OutMoney
		{
			get
			{
				return this.m_OutMoney ;
			}
			set
			{
				this.m_OutMoney = value ;
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
	
		#region CheckStoreWinMoney
		private System.Decimal m_CheckStoreWinMoney = 0 ; 
		/// <summary>
		/// CheckStoreWinMoney 盘盈金额
		/// </summary>
		public System.Decimal CheckStoreWinMoney
		{
			get
			{
				return this.m_CheckStoreWinMoney ;
			}
			set
			{
				this.m_CheckStoreWinMoney = value ;
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
	
		#region CheckStoreLostMoney
		private System.Decimal m_CheckStoreLostMoney = 0 ; 
		/// <summary>
		/// CheckStoreLostMoney 盘亏金额
		/// </summary>
		public System.Decimal CheckStoreLostMoney
		{
			get
			{
				return this.m_CheckStoreLostMoney ;
			}
			set
			{
				this.m_CheckStoreLostMoney = value ;
			}
		}
		#endregion
	
		#region SalesCount
		private System.Int32 m_SalesCount = 0 ; 
		/// <summary>
		/// SalesCount 店铺零售数量（扣除退货）
		/// </summary>
		public System.Int32 SalesCount
		{
			get
			{
				return this.m_SalesCount ;
			}
			set
			{
				this.m_SalesCount = value ;
			}
		}
		#endregion
	
		#region SalesMoney
		private System.Decimal m_SalesMoney = 0 ; 
		/// <summary>
		/// SalesMoney 店铺零售金额（扣除退货）
		/// </summary>
		public System.Decimal SalesMoney
		{
			get
			{
				return this.m_SalesMoney ;
			}
			set
			{
				this.m_SalesMoney = value ;
			}
		}
		#endregion
	
		#region ScrapCount
		private System.Int32 m_ScrapCount = 0 ; 
		/// <summary>
		/// ScrapCount 报损数
		/// </summary>
		public System.Int32 ScrapCount
		{
			get
			{
				return this.m_ScrapCount ;
			}
			set
			{
				this.m_ScrapCount = value ;
			}
		}
		#endregion
	
		#region ScrapMoney
		private System.Decimal m_ScrapMoney = 0 ; 
		/// <summary>
		/// ScrapMoney 报损金额
		/// </summary>
		public System.Decimal ScrapMoney
		{
			get
			{
				return this.m_ScrapMoney ;
			}
			set
			{
				this.m_ScrapMoney = value ;
			}
		}
		#endregion
	
		#region PfCount
		private System.Int32 m_PfCount = 0 ; 
		/// <summary>
		/// PfCount 批发数量
		/// </summary>
		public System.Int32 PfCount
		{
			get
			{
				return this.m_PfCount ;
			}
			set
			{
				this.m_PfCount = value ;
			}
		}
		#endregion
	
		#region PfMoney
		private System.Decimal m_PfMoney = 0 ; 
		/// <summary>
		/// PfMoney 批发金额
		/// </summary>
		public System.Decimal PfMoney
		{
			get
			{
				return this.m_PfMoney ;
			}
			set
			{
				this.m_PfMoney = value ;
			}
		}
		#endregion
	
		#region EndCount
		private System.Int32 m_EndCount = 0 ; 
		/// <summary>
		/// EndCount 这一天结束时的库存数
		/// </summary>
		public System.Int32 EndCount
		{
			get
			{
				return this.m_EndCount ;
			}
			set
			{
				this.m_EndCount = value ;
			}
		}
		#endregion
	
		#region EndMoney
		private System.Decimal m_EndMoney = 0 ; 
		/// <summary>
		/// EndMoney 这一天结束时的金额
		/// </summary>
		public System.Decimal EndMoney
		{
			get
			{
				return this.m_EndMoney ;
			}
			set
			{
				this.m_EndMoney = value ;
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
