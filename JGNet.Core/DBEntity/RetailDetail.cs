using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class RetailDetail : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "RetailDetail" ;
		public const string _AutoID = "AutoID" ;
		public const string _RetailOrderID = "RetailOrderID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _BrandName = "BrandName" ;
		public const string _ColorName = "ColorName" ;
		public const string _SizeName = "SizeName" ;
		public const string _InSalesPromotion = "InSalesPromotion" ;
		public const string _Price = "Price" ;
		public const string _SinglePrice = "SinglePrice" ;
		public const string _SalePrice = "SalePrice" ;
		public const string _CostPrice = "CostPrice" ;
		public const string _DiscountOrigin = "DiscountOrigin" ;
		public const string _Discount = "Discount" ;
		public const string _BuyCount = "BuyCount" ;
		public const string _SumMoneyActual = "SumMoneyActual" ;
		public const string _SumMoney = "SumMoney" ;
		public const string _SumCost = "SumCost" ;
		public const string _Refunded = "Refunded" ;
		public const string _OccureTime = "OccureTime" ;
		public const string _Remarks = "Remarks" ;
		public const string _GiftTickets = "GiftTickets" ;
		public const string _GiftTicketMoney = "GiftTicketMoney" ;
		public const string _IsBuyout = "IsBuyout" ;
		public const string _GuideID = "GuideID" ;
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
	
		#region RetailOrderID
		private System.String m_RetailOrderID = "" ; 
		/// <summary>
		/// RetailOrderID 销售单号
		/// </summary>
		public System.String RetailOrderID
		{
			get
			{
				return this.m_RetailOrderID ;
			}
			set
			{
				this.m_RetailOrderID = value ;
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
	
		#region SinglePrice
		private System.Decimal m_SinglePrice = 0 ; 
		public System.Decimal SinglePrice
		{
			get
			{
				return this.m_SinglePrice ;
			}
			set
			{
				this.m_SinglePrice = value ;
			}
		}
		#endregion
	
		#region SalePrice
		private System.Decimal m_SalePrice = 0 ; 
		/// <summary>
		/// SalePrice 售价
		/// </summary>
		public System.Decimal SalePrice
		{
			get
			{
				return this.m_SalePrice ;
			}
			set
			{
				this.m_SalePrice = value ;
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
		/// DiscountOrigin 原始折扣
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
		/// Discount 实际折扣
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
	
		#region SumMoneyActual
		private System.Decimal m_SumMoneyActual = 0 ; 
		/// <summary>
		/// SumMoneyActual 实收额（扣除各种均摊之后）
		/// </summary>
		public System.Decimal SumMoneyActual
		{
			get
			{
				return this.m_SumMoneyActual ;
			}
			set
			{
				this.m_SumMoneyActual = value ;
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
	
		#region Refunded
		private System.Boolean m_Refunded = false ; 
		/// <summary>
		/// Refunded 是否退货了？（仅对销售单有效）
		/// </summary>
		public System.Boolean Refunded
		{
			get
			{
				return this.m_Refunded ;
			}
			set
			{
				this.m_Refunded = value ;
			}
		}
		#endregion
	
		#region OccureTime
		private System.DateTime m_OccureTime = DateTime.Now ; 
		/// <summary>
		/// OccureTime 时间
		/// </summary>
		public System.DateTime OccureTime
		{
			get
			{
				return this.m_OccureTime ;
			}
			set
			{
				this.m_OccureTime = value ;
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
	
		#region GiftTicketMoney
		private System.Decimal m_GiftTicketMoney = 0 ; 
		/// <summary>
		/// GiftTicketMoney 电子优惠券分摊后的金额
		/// </summary>
		public System.Decimal GiftTicketMoney
		{
			get
			{
				return this.m_GiftTicketMoney ;
			}
			set
			{
				this.m_GiftTicketMoney = value ;
			}
		}
		#endregion
	
		#region IsBuyout
		private System.Boolean m_IsBuyout = false ; 
		/// <summary>
		/// IsBuyout 是否是一口价
		/// </summary>
		public System.Boolean IsBuyout
		{
			get
			{
				return this.m_IsBuyout ;
			}
			set
			{
				this.m_IsBuyout = value ;
			}
		}
		#endregion
	
		#region GuideID
		private System.String m_GuideID = "" ; 
		/// <summary>
		/// GuideID 导购ID
		/// </summary>
		public System.String GuideID
		{
			get
			{
				return this.m_GuideID ;
			}
			set
			{
				this.m_GuideID = value ;
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
