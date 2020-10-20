using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmRetailDetail : IEntity<System.Int32>
	{
        public String SizeDisplayName { get; set; }
	    #region Force Static Check
		public const string TableName = "EmRetailDetail" ;
		public const string _AutoID = "AutoID" ;
		public const string _EmRetailOrderID = "EmRetailOrderID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _BrandName = "BrandName" ;
		public const string _ColorName = "ColorName" ;
		public const string _SizeName = "SizeName" ;
		public const string _InSalesPromotion = "InSalesPromotion" ;
		public const string _Price = "Price" ;
		public const string _EmOnlinePrice = "EmOnlinePrice" ;
		public const string _CostPrice = "CostPrice" ;
		public const string _DiscountOrigin = "DiscountOrigin" ;
		public const string _Discount = "Discount" ;
		public const string _BuyCount = "BuyCount" ;
		public const string _SumMoney = "SumMoney" ;
		public const string _SumCost = "SumCost" ;
		public const string _RefundCount = "RefundCount" ;
		public const string _GiftTickets = "GiftTickets" ;
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
	
		#region EmRetailOrderID
		private System.String m_EmRetailOrderID = "" ; 
		/// <summary>
		/// EmRetailOrderID 线上销售单号
		/// </summary>
		public System.String EmRetailOrderID
		{
			get
			{
				return this.m_EmRetailOrderID ;
			}
			set
			{
				this.m_EmRetailOrderID = value ;
			}
		}
		#endregion
	
		#region CostumeID
		private System.String m_CostumeID = "" ; 
		/// <summary>
		/// CostumeID 款号
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
	
		#region BrandName
		private System.String m_BrandName = "" ; 
		/// <summary>
		/// BrandName 品牌名称
		/// </summary>
		public System.String BrandName
		{
			get
			{
				return this.m_BrandName ;
			}
			set
			{
				this.m_BrandName = value ;
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
	
		#region SizeName
		private System.String m_SizeName = "" ; 
		/// <summary>
		/// SizeName 尺码
		/// </summary>
		public System.String SizeName
		{
			get
			{
				return this.m_SizeName ;
			}
			set
			{
				this.m_SizeName = value ;
			}
		}
		#endregion
	
		#region InSalesPromotion
		private System.Boolean m_InSalesPromotion = false ; 
		/// <summary>
		/// InSalesPromotion 是否参与了活动
		/// </summary>
		public System.Boolean InSalesPromotion
		{
			get
			{
				return this.m_InSalesPromotion ;
			}
			set
			{
				this.m_InSalesPromotion = value ;
			}
		}
		#endregion
	
		#region Price
		private System.Decimal m_Price = 0 ; 
		/// <summary>
		/// Price 吊牌价
		/// </summary>
		public System.Decimal Price
		{
			get
			{
				return this.m_Price ;
			}
			set
			{
				this.m_Price = value ;
			}
		}
		#endregion
	
		#region EmOnlinePrice
		private System.Decimal m_EmOnlinePrice = 0 ; 
		/// <summary>
		/// EmOnlinePrice 线上价
		/// </summary>
		public System.Decimal EmOnlinePrice
		{
			get
			{
				return this.m_EmOnlinePrice ;
			}
			set
			{
				this.m_EmOnlinePrice = value ;
			}
		}
		#endregion
	
		#region CostPrice
		private System.Decimal m_CostPrice = 0 ; 
		/// <summary>
		/// CostPrice 成本价
		/// </summary>
		public System.Decimal CostPrice
		{
			get
			{
				return this.m_CostPrice ;
			}
			set
			{
				this.m_CostPrice = value ;
			}
		}
		#endregion
	
		#region DiscountOrigin
		private System.Decimal m_DiscountOrigin = 0 ; 
		/// <summary>
		/// DiscountOrigin 原始销售折扣
		/// </summary>
		public System.Decimal DiscountOrigin
		{
			get
			{
				return this.m_DiscountOrigin ;
			}
			set
			{
				this.m_DiscountOrigin = value ;
			}
		}
		#endregion
	
		#region Discount
		private System.Decimal m_Discount = 0 ; 
		/// <summary>
		/// Discount 实际销售折扣
		/// </summary>
		public System.Decimal Discount
		{
			get
			{
				return this.m_Discount ;
			}
			set
			{
				this.m_Discount = value ;
			}
		}
		#endregion
	
		#region BuyCount
		private System.Int32 m_BuyCount = 0 ; 
		/// <summary>
		/// BuyCount 件数
		/// </summary>
		public System.Int32 BuyCount
		{
			get
			{
				return this.m_BuyCount ;
			}
			set
			{
				this.m_BuyCount = value ;
			}
		}
		#endregion
	
		#region SumMoney
		private System.Decimal m_SumMoney = 0 ; 
		/// <summary>
		/// SumMoney 小计金额
		/// </summary>
		public System.Decimal SumMoney
		{
			get
			{
				return this.m_SumMoney ;
			}
			set
			{
				this.m_SumMoney = value ;
			}
		}
		#endregion
	
		#region SumCost
		private System.Decimal m_SumCost = 0 ; 
		/// <summary>
		/// SumCost 小计成本
		/// </summary>
		public System.Decimal SumCost
		{
			get
			{
				return this.m_SumCost ;
			}
			set
			{
				this.m_SumCost = value ;
			}
		}
		#endregion
	
		#region RefundCount
		private System.Int32 m_RefundCount = 0 ; 
		/// <summary>
		/// RefundCount 退货件数
		/// </summary>
		public System.Int32 RefundCount
		{
			get
			{
				return this.m_RefundCount ;
			}
			set
			{
				this.m_RefundCount = value ;
			}
		}
		#endregion
	
		#region GiftTickets
		private System.String m_GiftTickets = "" ; 
		/// <summary>
		/// GiftTickets 所使用的电子优惠券的ID，使用英文逗号连接
		/// </summary>
		public System.String GiftTickets
		{
			get
			{
				return this.m_GiftTickets ;
			}
			set
			{
				this.m_GiftTickets = value ;
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
