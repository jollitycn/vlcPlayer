using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class RolePermissions : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "RolePermissions" ;
		public const string _AutoID = "AutoID" ;
		public const string _RoleID = "RoleID" ;
		public const string _Permissions = "Permissions" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自增ID(主键)，从1开始
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
	
		#region RoleID
		private System.Int32 m_RoleID = 0 ; 
		/// <summary>
		/// RoleID 角色id
		/// </summary>
		public System.Int32 RoleID
		{
			get
			{
				return this.m_RoleID ;
			}
			set
			{
				this.m_RoleID = value ;
			}
		}
		#endregion
	
		#region Permissions
		private System.Int32 m_Permissions = 0 ; 
		/// <summary>
		/// Permissions 权限（枚举值）
		/// </summary>
		public System.Int32 Permissions
		{
			get
			{
				return this.m_Permissions ;
			}
			set
			{
				this.m_Permissions = value ;
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
