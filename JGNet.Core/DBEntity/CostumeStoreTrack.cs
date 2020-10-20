using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class CostumeStoreTrack : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "CostumeStoreTrack" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _ColorName = "ColorName" ;
		public const string _SizeName = "SizeName" ;
		public const string _ChangeCount = "ChangeCount" ;
		public const string _ResultStore = "ResultStore" ;
		public const string _ChangeType = "ChangeType" ;
		public const string _OrderID = "OrderID" ;
		public const string _OccureTime = "OccureTime" ;
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
		/// ShopID 商品ID
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
	
		#region ChangeCount
		private System.Int32 m_ChangeCount = 0 ; 
		/// <summary>
		/// ChangeCount 变化数量
		/// </summary>
		public System.Int32 ChangeCount
		{
			get
			{
				return this.m_ChangeCount ;
			}
			set
			{
				this.m_ChangeCount = value ;
			}
		}
		#endregion
	
		#region ResultStore
		private System.Int32 m_ResultStore = 0 ; 
		/// <summary>
		/// ResultStore 变化后的库存数值
		/// </summary>
		public System.Int32 ResultStore
		{
			get
			{
				return this.m_ResultStore ;
			}
			set
			{
				this.m_ResultStore = value ;
			}
		}
		#endregion
	
		#region ChangeType
		private System.String m_ChangeType = "" ; 
		/// <summary>
		/// ChangeType 变化类型：销售、退货、调拨 ......
		/// </summary>
		public System.String ChangeType
		{
			get
			{
				return this.m_ChangeType ;
			}
			set
			{
				this.m_ChangeType = value ;
			}
		}
		#endregion
	
		#region OrderID
		private System.String m_OrderID = "" ; 
		/// <summary>
		/// OrderID 相关单据编号
		/// </summary>
		public System.String OrderID
		{
			get
			{
				return this.m_OrderID ;
			}
			set
			{
				this.m_OrderID = value ;
			}
		}
		#endregion
	
		#region OccureTime
		private System.DateTime m_OccureTime = DateTime.Now ; 
		/// <summary>
		/// OccureTime 变化发生的时间
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
