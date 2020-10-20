using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmRefundDetail : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "EmRefundDetail" ;
		public const string _AutoID = "AutoID" ;
		public const string _EmRefundOrderID = "EmRefundOrderID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _BrandName = "BrandName" ;
		public const string _ColorName = "ColorName" ;
		public const string _SizeName = "SizeName" ;
		public const string _Price = "Price" ;
		public const string _EmOnlinePrice = "EmOnlinePrice" ;
		public const string _RefundCount = "RefundCount" ;
		public const string _SumMoney = "SumMoney" ;
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
	
        public String SizeDisplayName { get; set; }
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
