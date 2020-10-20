using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class WxShopMan : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "WxShopMan" ;
		public const string _WxOpenID = "WxOpenID" ;
		public const string _BusinessAccountID = "BusinessAccountID" ;
		public const string _ShopID = "ShopID" ;
		public const string _UserType = "UserType" ;
		public const string _UserID = "UserID" ;
		public const string _FirstLoginTime = "FirstLoginTime" ;
		public const string _LastLoginTime = "LastLoginTime" ;
	    #endregion
	 
	    #region Property
	
		#region WxOpenID
		private System.String m_WxOpenID = "" ; 
		/// <summary>
		/// WxOpenID 微信OpenID(主键)
		/// </summary>
		public System.String WxOpenID
		{
			get
			{
				return this.m_WxOpenID ;
			}
			set
			{
				this.m_WxOpenID = value ;
			}
		}
		#endregion
	
		#region BusinessAccountID
		private System.String m_BusinessAccountID = "" ; 
		/// <summary>
		/// BusinessAccountID 所属商户ID
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
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 店铺ID
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
	
		#region UserType
		private System.Byte m_UserType = 0 ; 
		/// <summary>
		/// UserType 店员类型：管理员、导购
		/// </summary>
		public System.Byte UserType
		{
			get
			{
				return this.m_UserType ;
			}
			set
			{
				this.m_UserType = value ;
			}
		}
		#endregion
	
		#region UserID
		private System.String m_UserID = "" ; 
		/// <summary>
		/// UserID 管理员或导购帐号
		/// </summary>
		public System.String UserID
		{
			get
			{
				return this.m_UserID ;
			}
			set
			{
				this.m_UserID = value ;
			}
		}
		#endregion
	
		#region FirstLoginTime
		private System.DateTime m_FirstLoginTime = DateTime.Now ; 
		/// <summary>
		/// FirstLoginTime 首次登录时间
		/// </summary>
		public System.DateTime FirstLoginTime
		{
			get
			{
				return this.m_FirstLoginTime ;
			}
			set
			{
				this.m_FirstLoginTime = value ;
			}
		}
		#endregion
	
		#region LastLoginTime
		private System.DateTime m_LastLoginTime = DateTime.Now ; 
		/// <summary>
		/// LastLoginTime 最后登录时间
		/// </summary>
		public System.DateTime LastLoginTime
		{
			get
			{
				return this.m_LastLoginTime ;
			}
			set
			{
				this.m_LastLoginTime = value ;
			}
		}
		#endregion
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.WxOpenID;
	    }
	    #endregion
		
		#region ToString 
		public override string ToString()
		{
			return this.WxOpenID.ToString()  ;
		}
		#endregion
	}
}
