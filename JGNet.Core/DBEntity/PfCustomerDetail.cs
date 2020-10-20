using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PfCustomerDetail : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "PfCustomerDetail" ;
		public const string _AutoID = "AutoID" ;
		public const string _PfCustomerOrderID = "PfCustomerOrderID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _ColorName = "ColorName" ;
		public const string _SizeName = "SizeName" ;
		public const string _Price = "Price" ;
		public const string _PfOnlinePrice = "PfOnlinePrice" ;
		public const string _PfDiscount = "PfDiscount" ;
		public const string _PfPrice = "PfPrice" ;
		public const string _Count = "Count" ;
		public const string _DeliveryCount = "DeliveryCount" ;
		public const string _IsAllDelivery = "IsAllDelivery" ;
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
	
		#region PfCustomerOrderID
		private System.String m_PfCustomerOrderID = "" ; 
		/// <summary>
		/// PfCustomerOrderID 批发订货单号
		/// </summary>
		public System.String PfCustomerOrderID
		{
			get
			{
				return this.m_PfCustomerOrderID ;
			}
			set
			{
				this.m_PfCustomerOrderID = value ;
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
	
		#region PfOnlinePrice
		private System.Decimal m_PfOnlinePrice = 0 ; 
		/// <summary>
		/// PfOnlinePrice 线上批发价
		/// </summary>
		public System.Decimal PfOnlinePrice
		{
			get
			{
				return this.m_PfOnlinePrice ;
			}
			set
			{
				this.m_PfOnlinePrice = value ;
			}
		}
		#endregion
	
		#region PfDiscount
		private System.Decimal m_PfDiscount = 0 ; 
		/// <summary>
		/// PfDiscount 批发折扣
		/// </summary>
		public System.Decimal PfDiscount
		{
			get
			{
				return this.m_PfDiscount ;
			}
			set
			{
				this.m_PfDiscount = value ;
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
	
		#region Count
		private System.Int32 m_Count = 0 ; 
		/// <summary>
		/// Count 件数
		/// </summary>
		public System.Int32 Count
		{
			get
			{
				return this.m_Count ;
			}
			set
			{
				this.m_Count = value ;
			}
		}
		#endregion
	
		#region DeliveryCount
		private System.Int32 m_DeliveryCount = 0 ; 
		/// <summary>
		/// DeliveryCount 已发货件数
		/// </summary>
		public System.Int32 DeliveryCount
		{
			get
			{
				return this.m_DeliveryCount ;
			}
			set
			{
				this.m_DeliveryCount = value ;
			}
		}
		#endregion
	
		#region IsAllDelivery
		private System.Boolean m_IsAllDelivery = false ; 
		/// <summary>
		/// IsAllDelivery 是否已全部发货
		/// </summary>
		public System.Boolean IsAllDelivery
		{
			get
			{
				return this.m_IsAllDelivery ;
			}
			set
			{
				this.m_IsAllDelivery = value ;
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
