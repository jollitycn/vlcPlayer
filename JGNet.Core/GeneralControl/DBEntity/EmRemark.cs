using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmRemark : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "EmRemark" ;
		public const string _AutoID = "AutoID" ;
		public const string _MemeberID = "MemeberID" ;
		public const string _EmRetailOrderID = "EmRetailOrderID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _BrandName = "BrandName" ;
		public const string _ColorName = "ColorName" ;
		public const string _SizeName = "SizeName" ;
		public const string _RemarkScore = "RemarkScore" ;
		public const string _RemarkContent = "RemarkContent" ;
		public const string _PhotoAddress1 = "PhotoAddress1" ;
		public const string _PhotoAddress2 = "PhotoAddress2" ;
		public const string _PhotoAddress3 = "PhotoAddress3" ;
		public const string _Anonymous = "Anonymous" ;
		public const string _RemarkTime = "RemarkTime" ;
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
	
		#region MemeberID
		private System.String m_MemeberID = "" ; 
		/// <summary>
		/// MemeberID 会员卡号（手机号）
		/// </summary>
		public System.String MemeberID
		{
			get
			{
				return this.m_MemeberID ;
			}
			set
			{
				this.m_MemeberID = value ;
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
	
		#region RemarkScore
		private System.Byte m_RemarkScore = 0 ; 
		/// <summary>
		/// RemarkScore 0：好，1：中，2：差
		/// </summary>
		public System.Byte RemarkScore
		{
			get
			{
				return this.m_RemarkScore ;
			}
			set
			{
				this.m_RemarkScore = value ;
			}
		}
		#endregion
	
		#region RemarkContent
		private System.String m_RemarkContent = "" ; 
		/// <summary>
		/// RemarkContent 评价内容
		/// </summary>
		public System.String RemarkContent
		{
			get
			{
				return this.m_RemarkContent ;
			}
			set
			{
				this.m_RemarkContent = value ;
			}
		}
		#endregion
	
		#region PhotoAddress1
		private System.String m_PhotoAddress1 = "" ; 
		/// <summary>
		/// PhotoAddress1 卖家晒图，图片1的地址
		/// </summary>
		public System.String PhotoAddress1
		{
			get
			{
				return this.m_PhotoAddress1 ;
			}
			set
			{
				this.m_PhotoAddress1 = value ;
			}
		}
		#endregion
	
		#region PhotoAddress2
		private System.String m_PhotoAddress2 = "" ; 
		/// <summary>
		/// PhotoAddress2 卖家晒图，图片2的地址
		/// </summary>
		public System.String PhotoAddress2
		{
			get
			{
				return this.m_PhotoAddress2 ;
			}
			set
			{
				this.m_PhotoAddress2 = value ;
			}
		}
		#endregion
	
		#region PhotoAddress3
		private System.String m_PhotoAddress3 = "" ; 
		/// <summary>
		/// PhotoAddress3 卖家晒图，图片3的地址
		/// </summary>
		public System.String PhotoAddress3
		{
			get
			{
				return this.m_PhotoAddress3 ;
			}
			set
			{
				this.m_PhotoAddress3 = value ;
			}
		}
		#endregion
	
		#region Anonymous
		private System.Boolean m_Anonymous = false ; 
		/// <summary>
		/// Anonymous 是否匿名评价
		/// </summary>
		public System.Boolean Anonymous
		{
			get
			{
				return this.m_Anonymous ;
			}
			set
			{
				this.m_Anonymous = value ;
			}
		}
		#endregion
	
		#region RemarkTime
		private System.DateTime m_RemarkTime = DateTime.Now ; 
		/// <summary>
		/// RemarkTime 评价时间
		/// </summary>
		public System.DateTime RemarkTime
		{
			get
			{
				return this.m_RemarkTime ;
			}
			set
			{
				this.m_RemarkTime = value ;
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
