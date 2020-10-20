using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class Guide : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "Guide" ;
		public const string _ID = "ID" ;
		public const string _Name = "Name" ;
		public const string _Password = "Password" ;
		public const string _Sex = "Sex" ;
		public const string _ShopID = "ShopID" ;
		public const string _Birthday = "Birthday" ;
		public const string _Marriaged = "Marriaged" ;
		public const string _IdentityNo = "IdentityNo" ;
		public const string _HomeAddress = "HomeAddress" ;
		public const string _MobilePhone = "MobilePhone" ;
		public const string _HomePhone = "HomePhone" ;
		public const string _Contact = "Contact" ;
		public const string _JoinTime = "JoinTime" ;
		public const string _PositiveTime = "PositiveTime" ;
		public const string _DimissionTime = "DimissionTime" ;
		public const string _BankCard = "BankCard" ;
		public const string _Remarks = "Remarks" ;
		public const string _State = "State" ;
		public const string _HeadImageUrl = "HeadImageUrl" ;
		public const string _SmsSignature = "SmsSignature" ;
		public const string _Permission = "Permission" ;
		public const string _SimplePermisssion = "SimplePermisssion" ;
		public const string _RoleIDs = "RoleIDs" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 营业员编号（主键）
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
		/// Name 营业员姓名
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
		/// Password 密码（初始密码：000000）
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
	
		#region Sex
		private System.Boolean m_Sex = false ; 
		/// <summary>
		/// Sex 性别
		/// </summary>
		public System.Boolean Sex
		{
			get
			{
				return this.m_Sex ;
			}
			set
			{
				this.m_Sex = value ;
			}
		}
		#endregion
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 所属店铺
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
	
		#region Birthday
		private System.DateTime m_Birthday = DateTime.Now ; 
		/// <summary>
		/// Birthday 出生日期
		/// </summary>
		public System.DateTime Birthday
		{
			get
			{
				return this.m_Birthday ;
			}
			set
			{
				this.m_Birthday = value ;
			}
		}
		#endregion
	
		#region Marriaged
		private System.Boolean m_Marriaged = false ; 
		/// <summary>
		/// Marriaged 婚姻状态（1：已婚，0：未婚）
		/// </summary>
		public System.Boolean Marriaged
		{
			get
			{
				return this.m_Marriaged ;
			}
			set
			{
				this.m_Marriaged = value ;
			}
		}
		#endregion
	
		#region IdentityNo
		private System.String m_IdentityNo = "" ; 
		/// <summary>
		/// IdentityNo 身份证号码
		/// </summary>
		public System.String IdentityNo
		{
			get
			{
				return this.m_IdentityNo ;
			}
			set
			{
				this.m_IdentityNo = value ;
			}
		}
		#endregion
	
		#region HomeAddress
		private System.String m_HomeAddress = "" ; 
		/// <summary>
		/// HomeAddress 家庭地址
		/// </summary>
		public System.String HomeAddress
		{
			get
			{
				return this.m_HomeAddress ;
			}
			set
			{
				this.m_HomeAddress = value ;
			}
		}
		#endregion
	
		#region MobilePhone
		private System.String m_MobilePhone = "" ; 
		/// <summary>
		/// MobilePhone 手机号码
		/// </summary>
		public System.String MobilePhone
		{
			get
			{
				return this.m_MobilePhone ;
			}
			set
			{
				this.m_MobilePhone = value ;
			}
		}
		#endregion
	
		#region HomePhone
		private System.String m_HomePhone = "" ; 
		/// <summary>
		/// HomePhone 家庭号码
		/// </summary>
		public System.String HomePhone
		{
			get
			{
				return this.m_HomePhone ;
			}
			set
			{
				this.m_HomePhone = value ;
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
	
		#region JoinTime
		private System.DateTime m_JoinTime = DateTime.Now ; 
		/// <summary>
		/// JoinTime 进店日期
		/// </summary>
		public System.DateTime JoinTime
		{
			get
			{
				return this.m_JoinTime ;
			}
			set
			{
				this.m_JoinTime = value ;
			}
		}
		#endregion
	
		#region PositiveTime
		private System.DateTime m_PositiveTime = DateTime.Now ; 
		/// <summary>
		/// PositiveTime 转正日期
		/// </summary>
		public System.DateTime PositiveTime
		{
			get
			{
				return this.m_PositiveTime ;
			}
			set
			{
				this.m_PositiveTime = value ;
			}
		}
		#endregion
	
		#region DimissionTime
		private System.DateTime m_DimissionTime = DateTime.Now ; 
		/// <summary>
		/// DimissionTime 离职日期
		/// </summary>
		public System.DateTime DimissionTime
		{
			get
			{
				return this.m_DimissionTime ;
			}
			set
			{
				this.m_DimissionTime = value ;
			}
		}
		#endregion
	
		#region BankCard
		private System.String m_BankCard = "" ; 
		/// <summary>
		/// BankCard 银行卡号
		/// </summary>
		public System.String BankCard
		{
			get
			{
				return this.m_BankCard ;
			}
			set
			{
				this.m_BankCard = value ;
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
	
		#region State
		private System.Byte m_State = 0 ; 
		/// <summary>
		/// State 是否禁用（1：是，0：否）
		/// </summary>
		public System.Byte State
		{
			get
			{
				return this.m_State ;
			}
			set
			{
				this.m_State = value ;
			}
		}
		#endregion
	
		#region HeadImageUrl
		private System.String m_HeadImageUrl = "" ; 
		/// <summary>
		/// HeadImageUrl 头像的云存储地址
		/// </summary>
		public System.String HeadImageUrl
		{
			get
			{
				return this.m_HeadImageUrl ;
			}
			set
			{
				this.m_HeadImageUrl = value ;
			}
		}
		#endregion
	
		#region SmsSignature
		private System.String m_SmsSignature = "" ; 
		/// <summary>
		/// SmsSignature 短信签名
		/// </summary>
		public System.String SmsSignature
		{
			get
			{
				return this.m_SmsSignature ;
			}
			set
			{
				this.m_SmsSignature = value ;
			}
		}
		#endregion
	
		#region Permission
		private System.String m_Permission = "" ; 
		/// <summary>
		/// Permission 手机POS助手端模块权限，使用英文逗号连接
		/// </summary>
		public System.String Permission
		{
			get
			{
				return this.m_Permission ;
			}
			set
			{
				this.m_Permission = value ;
			}
		}
		#endregion
	
		#region SimplePermisssion
		private System.String m_SimplePermisssion = "" ; 
		/// <summary>
		/// SimplePermisssion 手机精简版权限，使用英文逗号连接
		/// </summary>
		public System.String SimplePermisssion
		{
			get
			{
				return this.m_SimplePermisssion ;
			}
			set
			{
				this.m_SimplePermisssion = value ;
			}
		}
		#endregion
	
		#region RoleIDs
		private System.String m_RoleIDs = "" ; 
		/// <summary>
		/// RoleIDs 角色id，使用英文逗号连接
		/// </summary>
		public System.String RoleIDs
		{
			get
			{
				return this.m_RoleIDs ;
			}
			set
			{
				this.m_RoleIDs = value ;
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
