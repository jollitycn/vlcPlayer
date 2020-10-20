using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class CostumeStore : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "CostumeStore" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _ColorName = "ColorName" ;
		public const string _XS = "XS" ;
		public const string _S = "S" ;
		public const string _M = "M" ;
		public const string _L = "L" ;
		public const string _XL = "XL" ;
		public const string _XL2 = "XL2" ;
		public const string _XL3 = "XL3" ;
		public const string _XL4 = "XL4" ;
		public const string _XL5 = "XL5" ;
		public const string _XL6 = "XL6" ;
		public const string _F = "F" ;
		public const string _Price = "Price" ;
		public const string _SalePrice = "SalePrice" ;
		public const string _AllowReviseDiscount = "AllowReviseDiscount" ;
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
	
		#region CostumeID
		private System.String m_CostumeID = "" ; 
		/// <summary>
		/// CostumeID 服装id
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
	
		#region XS
		private System.Int16 m_XS = 0 ; 
		/// <summary>
		/// XS XS尺码件数
		/// </summary>
		public System.Int16 XS
		{
			get
			{
				return this.m_XS ;
			}
			set
			{
				this.m_XS = value ;
			}
		}
		#endregion
	
		#region S
		private System.Int16 m_S = 0 ; 
		/// <summary>
		/// S S尺码件数
		/// </summary>
		public System.Int16 S
		{
			get
			{
				return this.m_S ;
			}
			set
			{
				this.m_S = value ;
			}
		}
		#endregion
	
		#region M
		private System.Int16 m_M = 0 ; 
		/// <summary>
		/// M M尺码件数
		/// </summary>
		public System.Int16 M
		{
			get
			{
				return this.m_M ;
			}
			set
			{
				this.m_M = value ;
			}
		}
		#endregion
	
		#region L
		private System.Int16 m_L = 0 ; 
		/// <summary>
		/// L L尺码件数
		/// </summary>
		public System.Int16 L
		{
			get
			{
				return this.m_L ;
			}
			set
			{
				this.m_L = value ;
			}
		}
		#endregion
	
		#region XL
		private System.Int16 m_XL = 0 ; 
		/// <summary>
		/// XL XL尺码件数
		/// </summary>
		public System.Int16 XL
		{
			get
			{
				return this.m_XL ;
			}
			set
			{
				this.m_XL = value ;
			}
		}
		#endregion
	
		#region XL2
		private System.Int16 m_XL2 = 0 ; 
		/// <summary>
		/// XL2 2XL尺码件数
		/// </summary>
		public System.Int16 XL2
		{
			get
			{
				return this.m_XL2 ;
			}
			set
			{
				this.m_XL2 = value ;
			}
		}
		#endregion
	
		#region XL3
		private System.Int16 m_XL3 = 0 ; 
		/// <summary>
		/// XL3 3XL尺码件数
		/// </summary>
		public System.Int16 XL3
		{
			get
			{
				return this.m_XL3 ;
			}
			set
			{
				this.m_XL3 = value ;
			}
		}
		#endregion
	
		#region XL4
		private System.Int16 m_XL4 = 0 ; 
		/// <summary>
		/// XL4 4XL尺码件数
		/// </summary>
		public System.Int16 XL4
		{
			get
			{
				return this.m_XL4 ;
			}
			set
			{
				this.m_XL4 = value ;
			}
		}
		#endregion
	
		#region XL5
		private System.Int16 m_XL5 = 0 ; 
		/// <summary>
		/// XL5 5XL尺码件数
		/// </summary>
		public System.Int16 XL5
		{
			get
			{
				return this.m_XL5 ;
			}
			set
			{
				this.m_XL5 = value ;
			}
		}
		#endregion
	
		#region XL6
		private System.Int16 m_XL6 = 0 ; 
		/// <summary>
		/// XL6 6XL尺码件数
		/// </summary>
		public System.Int16 XL6
		{
			get
			{
				return this.m_XL6 ;
			}
			set
			{
				this.m_XL6 = value ;
			}
		}
		#endregion
	
		#region F
		private System.Int16 m_F = 0 ; 
		/// <summary>
		/// F F尺码件数
		/// </summary>
		public System.Int16 F
		{
			get
			{
				return this.m_F ;
			}
			set
			{
				this.m_F = value ;
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
	
		#region AllowReviseDiscount
		private System.Boolean m_AllowReviseDiscount = false ; 
		/// <summary>
		/// AllowReviseDiscount 是否允许在销售时修改折扣
		/// </summary>
		public System.Boolean AllowReviseDiscount
		{
			get
			{
				return this.m_AllowReviseDiscount ;
			}
			set
			{
				this.m_AllowReviseDiscount = value ;
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
