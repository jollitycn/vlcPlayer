using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class WxMember : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "WxMember" ;
		public const string _WxOpenID = "WxOpenID" ;
		public const string _BusinessAccountID = "BusinessAccountID" ;
		public const string _PhoneNumber = "PhoneNumber" ;
		public const string _Name = "Name" ;
		public const string _WxNickName = "WxNickName" ;
		public const string _WxHeadImageUrl = "WxHeadImageUrl" ;
		public const string _FirstLoginTime = "FirstLoginTime" ;
		public const string _LastLoginBAccountID = "LastLoginBAccountID" ;
		public const string _LastLoginTime = "LastLoginTime" ;
		public const string _DefaultAddressID = "DefaultAddressID" ;
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
		/// BusinessAccountID 商户帐号
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
	
		#region PhoneNumber
		private System.String m_PhoneNumber = "" ; 
		/// <summary>
		/// PhoneNumber 会员卡号，手机号码
		/// </summary>
		public System.String PhoneNumber
		{
			get
			{
				return this.m_PhoneNumber ;
			}
			set
			{
				this.m_PhoneNumber = value ;
			}
		}
		#endregion
	
		#region Name
		private System.String m_Name = "" ; 
		/// <summary>
		/// Name 姓名
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
	
		#region WxNickName
		private System.String m_WxNickName = "" ; 
		/// <summary>
		/// WxNickName 微信昵称
		/// </summary>
		public System.String WxNickName
		{
			get
			{
				return this.m_WxNickName ;
			}
			set
			{
				this.m_WxNickName = value ;
			}
		}
		#endregion
	
		#region WxHeadImageUrl
		private System.String m_WxHeadImageUrl = "" ; 
		/// <summary>
		/// WxHeadImageUrl 微信头像Url
		/// </summary>
		public System.String WxHeadImageUrl
		{
			get
			{
				return this.m_WxHeadImageUrl ;
			}
			set
			{
				this.m_WxHeadImageUrl = value ;
			}
		}
		#endregion
	
		#region FirstLoginTime
		private System.DateTime m_FirstLoginTime = DateTime.Now ; 
		/// <summary>
		/// FirstLoginTime 首次登录商城时间
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
	
		#region LastLoginBAccountID
		private System.String m_LastLoginBAccountID = "" ; 
		/// <summary>
		/// LastLoginBAccountID 最后登录商城的商户ID
		/// </summary>
		public System.String LastLoginBAccountID
		{
			get
			{
				return this.m_LastLoginBAccountID ;
			}
			set
			{
				this.m_LastLoginBAccountID = value ;
			}
		}
		#endregion
	
		#region LastLoginTime
		private System.DateTime m_LastLoginTime = DateTime.Now ; 
		/// <summary>
		/// LastLoginTime 最后登录商城时间
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
	
		#region DefaultAddressID
		private System.Int32 m_DefaultAddressID = 0 ; 
		/// <summary>
		/// DefaultAddressID 默认收货地址ID
		/// </summary>
		public System.Int32 DefaultAddressID
		{
			get
			{
				return this.m_DefaultAddressID ;
			}
			set
			{
				this.m_DefaultAddressID = value ;
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
	}
}
