using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class AdminUser : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "AdminUser" ;
		public const string _ID = "ID" ;
		public const string _Name = "Name" ;
		public const string _Password = "Password" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _Remarks = "Remarks" ;
		public const string _State = "State" ;
		public const string _Permission = "Permission" ;
		public const string _PCManagePermission = "PCManagePermission" ;
		public const string _SimplePermisssion = "SimplePermisssion" ;
		public const string _RoleIDs = "RoleIDs" ;
		public const string _SmsSignature = "SmsSignature" ;
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
		/// Password 密码（初始密码：123456）
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
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 创建日期
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
	
		#region Permission
		private System.String m_Permission = "" ; 
		/// <summary>
		/// Permission 手机管理助手端模块权限，使用英文逗号连接
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
	
		#region PCManagePermission
		private System.String m_PCManagePermission = "" ; 
		/// <summary>
		/// PCManagePermission PC管理端权限，使用英文逗号连接
		/// </summary>
		public System.String PCManagePermission
		{
			get
			{
				return this.m_PCManagePermission ;
			}
			set
			{
				this.m_PCManagePermission = value ;
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
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.ID;
	    }
	    #endregion
	}
}
