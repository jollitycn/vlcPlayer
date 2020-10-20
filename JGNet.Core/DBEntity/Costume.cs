using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class Costume : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "Costume" ;
		public const string _ID = "ID" ;
		public const string _Name = "Name" ;
		public const string _Price = "Price" ;
		public const string _EmPrice = "EmPrice" ;
		public const string _SalePrice = "SalePrice" ;
		public const string _CostPrice = "CostPrice" ;
		public const string _Property = "Property" ;
		public const string _Colors = "Colors" ;
		public const string _SizeGroupName = "SizeGroupName" ;
		public const string _SizeNames = "SizeNames" ;
		public const string _SupplierID = "SupplierID" ;
		public const string _BrandID = "BrandID" ;
		public const string _Year = "Year" ;
		public const string _Season = "Season" ;
		public const string _ClassID = "ClassID" ;
		public const string _BarCode = "BarCode" ;
		public const string _Remarks = "Remarks" ;
		public const string _IsValid = "IsValid" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EmDetails = "EmDetails" ;
		public const string _EmShowOnline = "EmShowOnline" ;
		public const string _EmTitle = "EmTitle" ;
		public const string _EmIsRecommand = "EmIsRecommand" ;
		public const string _EmOnlinePrice = "EmOnlinePrice" ;
		public const string _PfOnlinePrice = "PfOnlinePrice" ;
		public const string _EmThumbnail = "EmThumbnail" ;
		public const string _EmOnlineTime = "EmOnlineTime" ;
		public const string _CarriageCostTemplateID = "CarriageCostTemplateID" ;
		public const string _EmOfflineTime = "EmOfflineTime" ;
		public const string _EmEverOnline = "EmEverOnline" ;
		public const string _PfNew = "PfNew" ;
		public const string _PfHot = "PfHot" ;
		public const string _PfShowOnline = "PfShowOnline" ;
		public const string _PfOnlineTime = "PfOnlineTime" ;
		public const string _PfOfflineTime = "PfOfflineTime" ;
		public const string _PfEverOnline = "PfEverOnline" ;
		public const string _BigClass = "BigClass" ;
		public const string _SmallClass = "SmallClass" ;
		public const string _SubSmallClass = "SubSmallClass" ;
		public const string _EmSalesIncremental = "EmSalesIncremental" ;
		public const string _CommissionTemplateID = "CommissionTemplateID" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 款号（主键）
		/// </summary>
		public System.String ID
		{
			get
			{
				return this.m_ID ;
			}
			set
			{
				this.m_ID = value ;
			}
		}
		#endregion
	
		#region Name
		private System.String m_Name = "" ; 
		/// <summary>
		/// Name 名称
		/// </summary>
		public System.String Name
		{
			get
			{
				return this.m_Name ;
			}
			set
			{
				this.m_Name = value ;
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
	
		#region EmPrice
		private System.Decimal m_EmPrice = 0 ; 
		/// <summary>
		/// EmPrice 线上吊牌价
		/// </summary>
		public System.Decimal EmPrice
		{
			get
			{
				return this.m_EmPrice ;
			}
			set
			{
				this.m_EmPrice = value ;
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
	
		#region Property
		private System.Byte m_Property = 0 ; 
		/// <summary>
		/// Property 属性（0：首单、1：追单、2：买断、3：代卖）
		/// </summary>
		public System.Byte Property
		{
			get
			{
				return this.m_Property ;
			}
			set
			{
				this.m_Property = value ;
			}
		}
		#endregion
	
		#region Colors
		private System.String m_Colors = "" ; 
		/// <summary>
		/// Colors 颜色（使用英文逗号分隔）
		/// </summary>
		public System.String Colors
		{
			get
			{
				return this.m_Colors ;
			}
			set
			{
				this.m_Colors = value ;
			}
		}
		#endregion
	
		#region SizeGroupName
		private System.String m_SizeGroupName = "" ; 
		/// <summary>
		/// SizeGroupName 所使用的尺码组
		/// </summary>
		public System.String SizeGroupName
		{
			get
			{
				return this.m_SizeGroupName ;
			}
			set
			{
				this.m_SizeGroupName = value ;
			}
		}
		#endregion
	
		#region SizeNames
		private System.String m_SizeNames = "" ; 
		/// <summary>
		/// SizeNames 有哪些尺码（使用英文逗号分隔），如S，M，L，XL
		/// </summary>
		public System.String SizeNames
		{
			get
			{
				return this.m_SizeNames ;
			}
			set
			{
				this.m_SizeNames = value ;
			}
		}
		#endregion
	
		#region SupplierID
		private System.String m_SupplierID = "" ; 
		/// <summary>
		/// SupplierID 供应商编号
		/// </summary>
		public System.String SupplierID
		{
			get
			{
				return this.m_SupplierID ;
			}
			set
			{
				this.m_SupplierID = value ;
			}
		}
		#endregion
	
		#region BrandID
		private System.Int32 m_BrandID = 0 ; 
		/// <summary>
		/// BrandID 品牌id
		/// </summary>
		public System.Int32 BrandID
		{
			get
			{
				return this.m_BrandID ;
			}
			set
			{
				this.m_BrandID = value ;
			}
		}
		#endregion
	
		#region Year
		private System.Int32 m_Year = 0 ; 
		/// <summary>
		/// Year 年份
		/// </summary>
		public System.Int32 Year
		{
			get
			{
				return this.m_Year ;
			}
			set
			{
				this.m_Year = value ;
			}
		}
		#endregion
	
		#region Season
		private System.String m_Season = "" ; 
		/// <summary>
		/// Season 季节
		/// </summary>
		public System.String Season
		{
			get
			{
				return this.m_Season ;
			}
			set
			{
				this.m_Season = value ;
			}
		}
		#endregion
	
		#region ClassID
		private System.Int32 m_ClassID = 0 ; 
		/// <summary>
		/// ClassID 类别id
		/// </summary>
		public System.Int32 ClassID
		{
			get
			{
				return this.m_ClassID ;
			}
			set
			{
				this.m_ClassID = value ;
			}
		}
		#endregion
	
		#region BarCode
		private System.String m_BarCode = "" ; 
		/// <summary>
		/// BarCode 商品条形码（颜色、尺码部分为全0）
		/// </summary>
		public System.String BarCode
		{
			get
			{
				return this.m_BarCode ;
			}
			set
			{
				this.m_BarCode = value ;
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
	
		#region IsValid
		private System.Boolean m_IsValid = false ; 
		/// <summary>
		/// IsValid 是否有效
		/// </summary>
		public System.Boolean IsValid
		{
			get
			{
				return this.m_IsValid ;
			}
			set
			{
				this.m_IsValid = value ;
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
	
		#region EmDetails
		private System.String m_EmDetails = "" ; 
		/// <summary>
		/// EmDetails 商品详情
		/// </summary>
		public System.String EmDetails
		{
			get
			{
				return this.m_EmDetails ;
			}
			set
			{
				this.m_EmDetails = value ;
			}
		}
		#endregion
	
		#region EmShowOnline
		private System.Boolean m_EmShowOnline = false ; 
		/// <summary>
		/// EmShowOnline 是否在线上商城中展示？
		/// </summary>
		public System.Boolean EmShowOnline
		{
			get
			{
				return this.m_EmShowOnline ;
			}
			set
			{
				this.m_EmShowOnline = value ;
			}
		}
		#endregion
	
		#region EmTitle
		private System.String m_EmTitle = "" ; 
		/// <summary>
		/// EmTitle 在线上商城中显示的名称
		/// </summary>
		public System.String EmTitle
		{
			get
			{
				return this.m_EmTitle ;
			}
			set
			{
				this.m_EmTitle = value ;
			}
		}
		#endregion
	
		#region EmIsRecommand
		private System.Boolean m_EmIsRecommand = false ; 
		/// <summary>
		/// EmIsRecommand 是否在线上商城中作为店主推荐？
		/// </summary>
		public System.Boolean EmIsRecommand
		{
			get
			{
				return this.m_EmIsRecommand ;
			}
			set
			{
				this.m_EmIsRecommand = value ;
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
	
		#region EmThumbnail
		private System.String m_EmThumbnail = "" ; 
		/// <summary>
		/// EmThumbnail 缩略图的云存储地址
		/// </summary>
		public System.String EmThumbnail
		{
			get
			{
				return this.m_EmThumbnail ;
			}
			set
			{
				this.m_EmThumbnail = value ;
			}
		}
		#endregion
	
		#region EmOnlineTime
		private System.DateTime m_EmOnlineTime = DateTime.Now ; 
		/// <summary>
		/// EmOnlineTime 上架时间
		/// </summary>
		public System.DateTime EmOnlineTime
		{
			get
			{
				return this.m_EmOnlineTime ;
			}
			set
			{
				this.m_EmOnlineTime = value ;
			}
		}
		#endregion
	
		#region CarriageCostTemplateID
		private System.Int32 m_CarriageCostTemplateID = 0 ; 
		/// <summary>
		/// CarriageCostTemplateID 运费模版。如果为0，表示包邮。
		/// </summary>
		public System.Int32 CarriageCostTemplateID
		{
			get
			{
				return this.m_CarriageCostTemplateID ;
			}
			set
			{
				this.m_CarriageCostTemplateID = value ;
			}
		}
		#endregion
	
		#region EmOfflineTime
		private System.DateTime m_EmOfflineTime = DateTime.Now ; 
		/// <summary>
		/// EmOfflineTime 下架时间
		/// </summary>
		public System.DateTime EmOfflineTime
		{
			get
			{
				return this.m_EmOfflineTime ;
			}
			set
			{
				this.m_EmOfflineTime = value ;
			}
		}
		#endregion
	
		#region EmEverOnline
		private System.Boolean m_EmEverOnline = false ; 
		/// <summary>
		/// EmEverOnline 是否上架过？
		/// </summary>
		public System.Boolean EmEverOnline
		{
			get
			{
				return this.m_EmEverOnline ;
			}
			set
			{
				this.m_EmEverOnline = value ;
			}
		}
		#endregion
	
		#region PfNew
		private System.Boolean m_PfNew = false ; 
		/// <summary>
		/// PfNew 是否是新品
		/// </summary>
		public System.Boolean PfNew
		{
			get
			{
				return this.m_PfNew ;
			}
			set
			{
				this.m_PfNew = value ;
			}
		}
		#endregion
	
		#region PfHot
		private System.Boolean m_PfHot = false ; 
		/// <summary>
		/// PfHot 是否热卖
		/// </summary>
		public System.Boolean PfHot
		{
			get
			{
				return this.m_PfHot ;
			}
			set
			{
				this.m_PfHot = value ;
			}
		}
		#endregion
	
		#region PfShowOnline
		private System.Boolean m_PfShowOnline = false ; 
		/// <summary>
		/// PfShowOnline 是否上架批发
		/// </summary>
		public System.Boolean PfShowOnline
		{
			get
			{
				return this.m_PfShowOnline ;
			}
			set
			{
				this.m_PfShowOnline = value ;
			}
		}
		#endregion
	
		#region PfOnlineTime
		private System.DateTime m_PfOnlineTime = DateTime.Now ; 
		/// <summary>
		/// PfOnlineTime 上架批发时间
		/// </summary>
		public System.DateTime PfOnlineTime
		{
			get
			{
				return this.m_PfOnlineTime ;
			}
			set
			{
				this.m_PfOnlineTime = value ;
			}
		}
		#endregion
	
		#region PfOfflineTime
		private System.DateTime m_PfOfflineTime = DateTime.Now ; 
		/// <summary>
		/// PfOfflineTime 批发下架时间
		/// </summary>
		public System.DateTime PfOfflineTime
		{
			get
			{
				return this.m_PfOfflineTime ;
			}
			set
			{
				this.m_PfOfflineTime = value ;
			}
		}
		#endregion
	
		#region PfEverOnline
		private System.Boolean m_PfEverOnline = false ; 
		/// <summary>
		/// PfEverOnline 是否上架批发过？
		/// </summary>
		public System.Boolean PfEverOnline
		{
			get
			{
				return this.m_PfEverOnline ;
			}
			set
			{
				this.m_PfEverOnline = value ;
			}
		}
		#endregion
	
		#region BigClass
		private System.String m_BigClass = "" ; 
		/// <summary>
		/// BigClass 大类
		/// </summary>
		public System.String BigClass
		{
			get
			{
				return this.m_BigClass ;
			}
			set
			{
				this.m_BigClass = value ;
			}
		}
		#endregion
	
		#region SmallClass
		private System.String m_SmallClass = "" ; 
		/// <summary>
		/// SmallClass 小类
		/// </summary>
		public System.String SmallClass
		{
			get
			{
				return this.m_SmallClass ;
			}
			set
			{
				this.m_SmallClass = value ;
			}
		}
		#endregion
	
		#region SubSmallClass
		private System.String m_SubSmallClass = "" ; 
		/// <summary>
		/// SubSmallClass 次小类
		/// </summary>
		public System.String SubSmallClass
		{
			get
			{
				return this.m_SubSmallClass ;
			}
			set
			{
				this.m_SubSmallClass = value ;
			}
		}
		#endregion
	
		#region EmSalesIncremental
		private System.Int32 m_EmSalesIncremental = 0 ; 
		/// <summary>
		/// EmSalesIncremental 线上销量增量
		/// </summary>
		public System.Int32 EmSalesIncremental
		{
			get
			{
				return this.m_EmSalesIncremental ;
			}
			set
			{
				this.m_EmSalesIncremental = value ;
			}
		}
		#endregion
	
		#region CommissionTemplateID
		private System.Int32 m_CommissionTemplateID = 0 ; 
		/// <summary>
		/// CommissionTemplateID 分销佣金模板id
		/// </summary>
		public System.Int32 CommissionTemplateID
		{
			get
			{
				return this.m_CommissionTemplateID ;
			}
			set
			{
				this.m_CommissionTemplateID = value ;
			}
		}
		#endregion
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.ID;
	    }
	    #endregion
	}
}
