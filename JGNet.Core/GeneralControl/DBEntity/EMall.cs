using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EMall : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "EMall" ;
		public const string _BusinessAccountID = "BusinessAccountID" ;
		public const string _Name = "Name" ;
		public const string _LogoUrl = "LogoUrl" ;
		public const string _PosterImage = "PosterImage" ;
		public const string _Announce = "Announce" ;
		public const string _Hotline = "Hotline" ;
		public const string _Comment = "Comment" ;
		public const string _ShopAddress = "ShopAddress" ;
		public const string _MiniProgramImg = "MiniProgramImg" ;
		public const string _PosterImageHeight = "PosterImageHeight" ;
		public const string _IsShowClassPhoto = "IsShowClassPhoto" ;
		public const string _IsShowAdsPhoto = "IsShowAdsPhoto" ;
	    #endregion
	 
	    #region Property
	
		#region BusinessAccountID
		private System.String m_BusinessAccountID = "" ; 
		/// <summary>
		/// BusinessAccountID 商户帐号(主键)
		/// </summary>
		public System.String BusinessAccountID
		{
			get
			{
				return this.m_BusinessAccountID ;
			}
			set
			{
				this.m_BusinessAccountID = value ;
			}
		}
		#endregion
	
		#region Name
		private System.String m_Name = "" ; 
		/// <summary>
		/// Name 商城名称
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
	
		#region LogoUrl
		private System.String m_LogoUrl = "" ; 
		/// <summary>
		/// LogoUrl 商城logo的云存储地址
		/// </summary>
		public System.String LogoUrl
		{
			get
			{
				return this.m_LogoUrl ;
			}
			set
			{
				this.m_LogoUrl = value ;
			}
		}
		#endregion
	
		#region PosterImage
		private System.String m_PosterImage = "" ; 
		/// <summary>
		/// PosterImage 宣传海报图片的url
		/// </summary>
		public System.String PosterImage
		{
			get
			{
				return this.m_PosterImage ;
			}
			set
			{
				this.m_PosterImage = value ;
			}
		}
		#endregion
	
		#region Announce
		private System.String m_Announce = "" ; 
		/// <summary>
		/// Announce 公告
		/// </summary>
		public System.String Announce
		{
			get
			{
				return this.m_Announce ;
			}
			set
			{
				this.m_Announce = value ;
			}
		}
		#endregion
	
		#region Hotline
		private System.String m_Hotline = "" ; 
		/// <summary>
		/// Hotline 客服热线电话号码
		/// </summary>
		public System.String Hotline
		{
			get
			{
				return this.m_Hotline ;
			}
			set
			{
				this.m_Hotline = value ;
			}
		}
		#endregion
	
		#region Comment
		private System.String m_Comment = "" ; 
		/// <summary>
		/// Comment 简介
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
	
		#region ShopAddress
		private System.String m_ShopAddress = "" ; 
		/// <summary>
		/// ShopAddress 详细地址
		/// </summary>
		public System.String ShopAddress
		{
			get
			{
				return this.m_ShopAddress ;
			}
			set
			{
				this.m_ShopAddress = value ;
			}
		}
		#endregion
	
		#region MiniProgramImg
		private System.Byte[] m_MiniProgramImg = null ; 
		/// <summary>
		/// MiniProgramImg 小程序码或小程序二维码 图片
		/// </summary>
		public System.Byte[] MiniProgramImg
		{
			get
			{
				return this.m_MiniProgramImg ;
			}
			set
			{
				this.m_MiniProgramImg = value ;
			}
		}
		#endregion
	
		#region PosterImageHeight
		private System.Int32 m_PosterImageHeight = 0 ; 
		/// <summary>
		/// PosterImageHeight 海报高度
		/// </summary>
		public System.Int32 PosterImageHeight
		{
			get
			{
				return this.m_PosterImageHeight ;
			}
			set
			{
				this.m_PosterImageHeight = value ;
			}
		}
		#endregion
	
		#region IsShowClassPhoto
		private System.Boolean m_IsShowClassPhoto = false ; 
		/// <summary>
		/// IsShowClassPhoto 是否展示分类类别图片
		/// </summary>
		public System.Boolean IsShowClassPhoto
		{
			get
			{
				return this.m_IsShowClassPhoto ;
			}
			set
			{
				this.m_IsShowClassPhoto = value ;
			}
		}
		#endregion
	
		#region IsShowAdsPhoto
		private System.Boolean m_IsShowAdsPhoto = false ; 
		/// <summary>
		/// IsShowAdsPhoto 是否展示广告图片
		/// </summary>
		public System.Boolean IsShowAdsPhoto
		{
			get
			{
				return this.m_IsShowAdsPhoto ;
			}
			set
			{
				this.m_IsShowAdsPhoto = value ;
			}
		}
		#endregion
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.BusinessAccountID;
	    }
	    #endregion
	}
}
