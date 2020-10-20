using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class BusinessAccount : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "BusinessAccount" ;
		public const string _ID = "ID" ;
		public const string _Name = "Name" ;
		public const string _Password = "Password" ;
		public const string _Contact = "Contact" ;
		public const string _ContactPhone = "ContactPhone" ;
		public const string _ContactQQ = "ContactQQ" ;
		public const string _ContactPhone2 = "ContactPhone2" ;
		public const string _ProvinceCity = "ProvinceCity" ;
		public const string _Address = "Address" ;
		public const string _DBIP = "DBIP" ;
		public const string _DBPort = "DBPort" ;
		public const string _DBName = "DBName" ;
		public const string _DBUser = "DBUser" ;
		public const string _DBPwd = "DBPwd" ;
		public const string _ServerIP = "ServerIP" ;
		public const string _ServerLanIP = "ServerLanIP" ;
		public const string _ServerPort = "ServerPort" ;
		public const string _ServerRemotingPort = "ServerRemotingPort" ;
		public const string _BusinessWebUrl = "BusinessWebUrl" ;
		public const string _EMallWebUrl = "EMallWebUrl" ;
		public const string _ShopCount = "ShopCount" ;
		public const string _OpenTime = "OpenTime" ;
		public const string _ExpiredDate = "ExpiredDate" ;
		public const string _IsTrial = "IsTrial" ;
		public const string _MobileAideEnabled = "MobileAideEnabled" ;
		public const string _OnlineEnabled = "OnlineEnabled" ;
		public const string _OnlineType = "OnlineType" ;
		public const string _OnlineStartTime = "OnlineStartTime" ;
		public const string _Enabled = "Enabled" ;
		public const string _Remarks = "Remarks" ;
		public const string _ERPEnabled = "ERPEnabled" ;
		public const string _HostingMoney = "HostingMoney" ;
		public const string _IsStreamline = "IsStreamline" ;
		public const string _IsOpenDistribution = "IsOpenDistribution" ;
		public const string _DistributionType = "DistributionType" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 帐套ID(主键)
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
		/// Name 帐套名称
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
	
		#region Password
		private System.String m_Password = "" ; 
		/// <summary>
		/// Password 帐套密码
		/// </summary>
		public System.String Password
		{
			get
			{
				return this.m_Password ;
			}
			set
			{
				this.m_Password = value ;
			}
		}
		#endregion
	
		#region Contact
		private System.String m_Contact = "" ; 
		/// <summary>
		/// Contact 联系人
		/// </summary>
		public System.String Contact
		{
			get
			{
				return this.m_Contact ;
			}
			set
			{
				this.m_Contact = value ;
			}
		}
		#endregion
	
		#region ContactPhone
		private System.String m_ContactPhone = "" ; 
		/// <summary>
		/// ContactPhone 联系电话
		/// </summary>
		public System.String ContactPhone
		{
			get
			{
				return this.m_ContactPhone ;
			}
			set
			{
				this.m_ContactPhone = value ;
			}
		}
		#endregion
	
		#region ContactQQ
		private System.String m_ContactQQ = "" ; 
		/// <summary>
		/// ContactQQ 联系QQ
		/// </summary>
		public System.String ContactQQ
		{
			get
			{
				return this.m_ContactQQ ;
			}
			set
			{
				this.m_ContactQQ = value ;
			}
		}
		#endregion
	
		#region ContactPhone2
		private System.String m_ContactPhone2 = "" ; 
		/// <summary>
		/// ContactPhone2 备用联系电话
		/// </summary>
		public System.String ContactPhone2
		{
			get
			{
				return this.m_ContactPhone2 ;
			}
			set
			{
				this.m_ContactPhone2 = value ;
			}
		}
		#endregion
	
		#region ProvinceCity
		private System.String m_ProvinceCity = "" ; 
		/// <summary>
		/// ProvinceCity 所在省市，格式如：广东省，汕头市
		/// </summary>
		public System.String ProvinceCity
		{
			get
			{
				return this.m_ProvinceCity ;
			}
			set
			{
				this.m_ProvinceCity = value ;
			}
		}
		#endregion
	
		#region Address
		private System.String m_Address = "" ; 
		/// <summary>
		/// Address 详细地址
		/// </summary>
		public System.String Address
		{
			get
			{
				return this.m_Address ;
			}
			set
			{
				this.m_Address = value ;
			}
		}
		#endregion
	
		#region DBIP
		private System.String m_DBIP = "" ; 
		/// <summary>
		/// DBIP 数据库IP
		/// </summary>
		public System.String DBIP
		{
			get
			{
				return this.m_DBIP ;
			}
			set
			{
				this.m_DBIP = value ;
			}
		}
		#endregion
	
		#region DBPort
		private System.Int32 m_DBPort = 0 ; 
		/// <summary>
		/// DBPort 数据库端口
		/// </summary>
		public System.Int32 DBPort
		{
			get
			{
				return this.m_DBPort ;
			}
			set
			{
				this.m_DBPort = value ;
			}
		}
		#endregion
	
		#region DBName
		private System.String m_DBName = "" ; 
		/// <summary>
		/// DBName 数据库名称（JGNet_[ ID]）
		/// </summary>
		public System.String DBName
		{
			get
			{
				return this.m_DBName ;
			}
			set
			{
				this.m_DBName = value ;
			}
		}
		#endregion
	
		#region DBUser
		private System.String m_DBUser = "" ; 
		/// <summary>
		/// DBUser 数据库用户
		/// </summary>
		public System.String DBUser
		{
			get
			{
				return this.m_DBUser ;
			}
			set
			{
				this.m_DBUser = value ;
			}
		}
		#endregion
	
		#region DBPwd
		private System.String m_DBPwd = "" ; 
		/// <summary>
		/// DBPwd 数据库密码
		/// </summary>
		public System.String DBPwd
		{
			get
			{
				return this.m_DBPwd ;
			}
			set
			{
				this.m_DBPwd = value ;
			}
		}
		#endregion
	
		#region ServerIP
		private System.String m_ServerIP = "" ; 
		/// <summary>
		/// ServerIP 服务端IP
		/// </summary>
		public System.String ServerIP
		{
			get
			{
				return this.m_ServerIP ;
			}
			set
			{
				this.m_ServerIP = value ;
			}
		}
		#endregion
	
		#region ServerLanIP
		private System.String m_ServerLanIP = "" ; 
		/// <summary>
		/// ServerLanIP 服务端局域网IP
		/// </summary>
		public System.String ServerLanIP
		{
			get
			{
				return this.m_ServerLanIP ;
			}
			set
			{
				this.m_ServerLanIP = value ;
			}
		}
		#endregion
	
		#region ServerPort
		private System.Int32 m_ServerPort = 0 ; 
		/// <summary>
		/// ServerPort 服务端口
		/// </summary>
		public System.Int32 ServerPort
		{
			get
			{
				return this.m_ServerPort ;
			}
			set
			{
				this.m_ServerPort = value ;
			}
		}
		#endregion
	
		#region ServerRemotingPort
		private System.Int32 m_ServerRemotingPort = 0 ; 
		/// <summary>
		/// ServerRemotingPort Remoting端口
		/// </summary>
		public System.Int32 ServerRemotingPort
		{
			get
			{
				return this.m_ServerRemotingPort ;
			}
			set
			{
				this.m_ServerRemotingPort = value ;
			}
		}
		#endregion
	
		#region BusinessWebUrl
		private System.String m_BusinessWebUrl = "" ; 
		/// <summary>
		/// BusinessWebUrl 商户小程序Web地址（老板报表、导购）
		/// </summary>
		public System.String BusinessWebUrl
		{
			get
			{
				return this.m_BusinessWebUrl ;
			}
			set
			{
				this.m_BusinessWebUrl = value ;
			}
		}
		#endregion
	
		#region EMallWebUrl
		private System.String m_EMallWebUrl = "" ; 
		/// <summary>
		/// EMallWebUrl 商城小程序Web地址
		/// </summary>
		public System.String EMallWebUrl
		{
			get
			{
				return this.m_EMallWebUrl ;
			}
			set
			{
				this.m_EMallWebUrl = value ;
			}
		}
		#endregion
	
		#region ShopCount
		private System.Int32 m_ShopCount = 0 ; 
		/// <summary>
		/// ShopCount 实体店铺的数量，默认值：1.
		/// </summary>
		public System.Int32 ShopCount
		{
			get
			{
				return this.m_ShopCount ;
			}
			set
			{
				this.m_ShopCount = value ;
			}
		}
		#endregion
	
		#region OpenTime
		private System.DateTime m_OpenTime = DateTime.Now ; 
		/// <summary>
		/// OpenTime 开户时间
		/// </summary>
		public System.DateTime OpenTime
		{
			get
			{
				return this.m_OpenTime ;
			}
			set
			{
				this.m_OpenTime = value ;
			}
		}
		#endregion
	
		#region ExpiredDate
		private System.DateTime m_ExpiredDate = DateTime.Now ; 
		/// <summary>
		/// ExpiredDate 截至日期（或试用过期日期）
		/// </summary>
		public System.DateTime ExpiredDate
		{
			get
			{
				return this.m_ExpiredDate ;
			}
			set
			{
				this.m_ExpiredDate = value ;
			}
		}
		#endregion
	
		#region IsTrial
		private System.Boolean m_IsTrial = false ; 
		/// <summary>
		/// IsTrial 是否是试用用户？
		/// </summary>
		public System.Boolean IsTrial
		{
			get
			{
				return this.m_IsTrial ;
			}
			set
			{
				this.m_IsTrial = value ;
			}
		}
		#endregion
	
		#region MobileAideEnabled
		private System.Boolean m_MobileAideEnabled = false ; 
		/// <summary>
		/// MobileAideEnabled 是否开通了手机助手？（老板报表、导购）
		/// </summary>
		public System.Boolean MobileAideEnabled
		{
			get
			{
				return this.m_MobileAideEnabled ;
			}
			set
			{
				this.m_MobileAideEnabled = value ;
			}
		}
		#endregion
	
		#region OnlineEnabled
		private System.Boolean m_OnlineEnabled = false ; 
		/// <summary>
		/// OnlineEnabled 是否开通了线上商城？
		/// </summary>
		public System.Boolean OnlineEnabled
		{
			get
			{
				return this.m_OnlineEnabled ;
			}
			set
			{
				this.m_OnlineEnabled = value ;
			}
		}
		#endregion
	
		#region OnlineType
		private System.Byte m_OnlineType = 0 ; 
		/// <summary>
		/// OnlineType 线上商城类型（0：所有，1：零售，2：批发）
		/// </summary>
		public System.Byte OnlineType
		{
			get
			{
				return this.m_OnlineType ;
			}
			set
			{
				this.m_OnlineType = value ;
			}
		}
		#endregion
	
		#region OnlineStartTime
		private System.DateTime m_OnlineStartTime = DateTime.Now ; 
		/// <summary>
		/// OnlineStartTime 线上商城首次开启时间
		/// </summary>
		public System.DateTime OnlineStartTime
		{
			get
			{
				return this.m_OnlineStartTime ;
			}
			set
			{
				this.m_OnlineStartTime = value ;
			}
		}
		#endregion
	
		#region Enabled
		private System.Boolean m_Enabled = false ; 
		/// <summary>
		/// Enabled 启用？
		/// </summary>
		public System.Boolean Enabled
		{
			get
			{
				return this.m_Enabled ;
			}
			set
			{
				this.m_Enabled = value ;
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
	
		#region ERPEnabled
		private System.Boolean m_ERPEnabled = false ; 
		/// <summary>
		/// ERPEnabled 是否有ERP功能
		/// </summary>
		public System.Boolean ERPEnabled
		{
			get
			{
				return this.m_ERPEnabled ;
			}
			set
			{
				this.m_ERPEnabled = value ;
			}
		}
		#endregion
	
		#region HostingMoney
		private System.Decimal m_HostingMoney = 0 ; 
		/// <summary>
		/// HostingMoney 托管费
		/// </summary>
		public System.Decimal HostingMoney
		{
			get
			{
				return this.m_HostingMoney ;
			}
			set
			{
				this.m_HostingMoney = value ;
			}
		}
		#endregion
	
		#region IsStreamline
		private System.Boolean m_IsStreamline = false ; 
		/// <summary>
		/// IsStreamline 是否是精简版
		/// </summary>
		public System.Boolean IsStreamline
		{
			get
			{
				return this.m_IsStreamline ;
			}
			set
			{
				this.m_IsStreamline = value ;
			}
		}
		#endregion
	
		#region IsOpenDistribution
		private System.Boolean m_IsOpenDistribution = false ; 
		/// <summary>
		/// IsOpenDistribution 是否开通分销
		/// </summary>
		public System.Boolean IsOpenDistribution
		{
			get
			{
				return this.m_IsOpenDistribution ;
			}
			set
			{
				this.m_IsOpenDistribution = value ;
			}
		}
		#endregion
	
		#region DistributionType
		private System.Byte m_DistributionType = 0 ; 
		/// <summary>
		/// DistributionType 分销类型（0：所有，1：零售，2：批发）
		/// </summary>
		public System.Byte DistributionType
		{
			get
			{
				return this.m_DistributionType ;
			}
			set
			{
				this.m_DistributionType = value ;
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
