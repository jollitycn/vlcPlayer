using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class VersionUpdateRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "VersionUpdateRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _UpdateContent = "UpdateContent" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _Version = "Version" ;
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
	
		#region UpdateContent
		private System.String m_UpdateContent = "" ; 
		/// <summary>
		/// UpdateContent 公告内容
		/// </summary>
		public System.String UpdateContent
		{
			get
			{
				return this.m_UpdateContent ;
			}
			set
			{
				this.m_UpdateContent = value ;
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
	
		#region Version
		private System.String m_Version = "" ; 
		/// <summary>
		/// Version 版本
		/// </summary>
		public System.String Version
		{
			get
			{
				return this.m_Version ;
			}
			set
			{
				this.m_Version = value ;
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
