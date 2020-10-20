using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PfCustomerRetailDetail : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "PfCustomerRetailDetail" ;
		public const string _AutoID = "AutoID" ;
		public const string _PfCustomerRetailOrderID = "PfCustomerRetailOrderID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _ColorName = "ColorName" ;
		public const string _SizeName = "SizeName" ;
		public const string _BuyCount = "BuyCount" ;
		public const string _PfPrice = "PfPrice" ;
		public const string _Comment = "Comment" ;
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
	
		#region PfCustomerRetailOrderID
		private System.String m_PfCustomerRetailOrderID = "" ; 
		/// <summary>
		/// PfCustomerRetailOrderID 销售单号
		/// </summary>
		public System.String PfCustomerRetailOrderID
		{
			get
			{
				return this.m_PfCustomerRetailOrderID ;
			}
			set
			{
				this.m_PfCustomerRetailOrderID = value ;
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
	
		#region PfPrice
		private System.Decimal m_PfPrice = 0 ; 
		/// <summary>
		/// PfPrice 批发价
		/// </summary>
		public System.Decimal PfPrice
		{
			get
			{
				return this.m_PfPrice ;
			}
			set
			{
				this.m_PfPrice = value ;
			}
		}
		#endregion
	
		#region Comment
		private System.String m_Comment = "" ; 
		/// <summary>
		/// Comment 备注
		/// </summary>
		public System.String Comment
		{
			get
			{
				return this.m_Comment ;
			}
			set
			{
				this.m_Comment = value ;
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
