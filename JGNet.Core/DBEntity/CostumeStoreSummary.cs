using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class CostumeStoreSummary : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "CostumeStoreSummary" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _ColorName = "ColorName" ;
		public const string _QuantityOfSale = "QuantityOfSale" ;
		public const string _MoneyOfSale = "MoneyOfSale" ;
		public const string _EmQuantityOfSale = "EmQuantityOfSale" ;
		public const string _EmMoneyOfSale = "EmMoneyOfSale" ;
		public const string _EmPfOfSale = "EmPfOfSale" ;
		public const string _EmMoneyOfPfSale = "EmMoneyOfPfSale" ;
		public const string _SummaryCount = "SummaryCount" ;
		public const string _FirstInboundTime = "FirstInboundTime" ;
		public const string _FirstSaleTime = "FirstSaleTime" ;
		public const string _LastSaleTime = "LastSaleTime" ;
		public const string _SellThroughRate = "SellThroughRate" ;
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
	
		#region ColorName
		private System.String m_ColorName = "" ; 
		/// <summary>
		/// ColorName 颜色
		/// </summary>
		public System.String ColorName
		{
			get
			{
				return this.m_ColorName ;
			}
			set
			{
				this.m_ColorName = value ;
			}
		}
		#endregion
	
		#region QuantityOfSale
		private System.Int32 m_QuantityOfSale = 0 ; 
		/// <summary>
		/// QuantityOfSale 总的销售数量（线下）
		/// </summary>
		public System.Int32 QuantityOfSale
		{
			get
			{
				return this.m_QuantityOfSale ;
			}
			set
			{
				this.m_QuantityOfSale = value ;
			}
		}
		#endregion
	
		#region MoneyOfSale
		private System.Decimal m_MoneyOfSale = 0 ; 
		/// <summary>
		/// MoneyOfSale 总的销售金额（线下）
		/// </summary>
		public System.Decimal MoneyOfSale
		{
			get
			{
				return this.m_MoneyOfSale ;
			}
			set
			{
				this.m_MoneyOfSale = value ;
			}
		}
		#endregion
	
		#region EmQuantityOfSale
		private System.Int32 m_EmQuantityOfSale = 0 ; 
		/// <summary>
		/// EmQuantityOfSale 总的销售数量（线上）
		/// </summary>
		public System.Int32 EmQuantityOfSale
		{
			get
			{
				return this.m_EmQuantityOfSale ;
			}
			set
			{
				this.m_EmQuantityOfSale = value ;
			}
		}
		#endregion
	
		#region EmMoneyOfSale
		private System.Decimal m_EmMoneyOfSale = 0 ; 
		/// <summary>
		/// EmMoneyOfSale 总的销售金额（线上）
		/// </summary>
		public System.Decimal EmMoneyOfSale
		{
			get
			{
				return this.m_EmMoneyOfSale ;
			}
			set
			{
				this.m_EmMoneyOfSale = value ;
			}
		}
		#endregion
	
		#region EmPfOfSale
		private System.Int32 m_EmPfOfSale = 0 ; 
		/// <summary>
		/// EmPfOfSale 总的批发销售数量（线上）
		/// </summary>
		public System.Int32 EmPfOfSale
		{
			get
			{
				return this.m_EmPfOfSale ;
			}
			set
			{
				this.m_EmPfOfSale = value ;
			}
		}
		#endregion
	
		#region EmMoneyOfPfSale
		private System.Decimal m_EmMoneyOfPfSale = 0 ; 
		/// <summary>
		/// EmMoneyOfPfSale 总的批发销售金额（线上）
		/// </summary>
		public System.Decimal EmMoneyOfPfSale
		{
			get
			{
				return this.m_EmMoneyOfPfSale ;
			}
			set
			{
				this.m_EmMoneyOfPfSale = value ;
			}
		}
		#endregion
	
		#region SummaryCount
		private System.Int32 m_SummaryCount = 0 ; 
		/// <summary>
		/// SummaryCount 库存总数
		/// </summary>
		public System.Int32 SummaryCount
		{
			get
			{
				return this.m_SummaryCount ;
			}
			set
			{
				this.m_SummaryCount = value ;
			}
		}
		#endregion
	
		#region FirstInboundTime
		private System.DateTime m_FirstInboundTime = DateTime.Now ; 
		/// <summary>
		/// FirstInboundTime 第一次入库时间
		/// </summary>
		public System.DateTime FirstInboundTime
		{
			get
			{
				return this.m_FirstInboundTime ;
			}
			set
			{
				this.m_FirstInboundTime = value ;
			}
		}
		#endregion
	
		#region FirstSaleTime
		private System.DateTime m_FirstSaleTime = DateTime.Now ; 
		/// <summary>
		/// FirstSaleTime 第一次销售时间
		/// </summary>
		public System.DateTime FirstSaleTime
		{
			get
			{
				return this.m_FirstSaleTime ;
			}
			set
			{
				this.m_FirstSaleTime = value ;
			}
		}
		#endregion
	
		#region LastSaleTime
		private System.DateTime m_LastSaleTime = DateTime.Now ; 
		/// <summary>
		/// LastSaleTime 最后销售时间
		/// </summary>
		public System.DateTime LastSaleTime
		{
			get
			{
				return this.m_LastSaleTime ;
			}
			set
			{
				this.m_LastSaleTime = value ;
			}
		}
		#endregion
	
		#region SellThroughRate
		private System.Double m_SellThroughRate = 0 ; 
		/// <summary>
		/// SellThroughRate 销罄率：销售量 / (销售量+库存数)
		/// </summary>
		public System.Double SellThroughRate
		{
			get
			{
				return this.m_SellThroughRate ;
			}
			set
			{
				this.m_SellThroughRate = value ;
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
