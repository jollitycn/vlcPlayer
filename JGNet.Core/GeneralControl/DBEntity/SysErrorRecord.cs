using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class SysErrorRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "SysErrorRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _BusinessAccountID = "BusinessAccountID" ;
		public const string _ErrorLevel = "ErrorLevel" ;
		public const string _ErrorMessage = "ErrorMessage" ;
		public const string _ClassMethod = "ClassMethod" ;
		public const string _StrackTrace = "StrackTrace" ;
		public const string _CreateTime = "CreateTime" ;
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
	
		#region ErrorLevel
		private System.Int32 m_ErrorLevel = 0 ; 
		/// <summary>
		/// ErrorLevel 错误等级。1：低，2：中，3：高，4：致命的
		/// </summary>
		public System.Int32 ErrorLevel
		{
			get
			{
				return this.m_ErrorLevel ;
			}
			set
			{
				this.m_ErrorLevel = value ;
			}
		}
		#endregion
	
		#region ErrorMessage
		private System.String m_ErrorMessage = "" ; 
		/// <summary>
		/// ErrorMessage 错误信息
		/// </summary>
		public System.String ErrorMessage
		{
			get
			{
				return this.m_ErrorMessage ;
			}
			set
			{
				this.m_ErrorMessage = value ;
			}
		}
		#endregion
	
		#region ClassMethod
		private System.String m_ClassMethod = "" ; 
		/// <summary>
		/// ClassMethod 类名.方法名
		/// </summary>
		public System.String ClassMethod
		{
			get
			{
				return this.m_ClassMethod ;
			}
			set
			{
				this.m_ClassMethod = value ;
			}
		}
		#endregion
	
		#region StrackTrace
		private System.String m_StrackTrace = "" ; 
		/// <summary>
		/// StrackTrace 调用堆栈
		/// </summary>
		public System.String StrackTrace
		{
			get
			{
				return this.m_StrackTrace ;
			}
			set
			{
				this.m_StrackTrace = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 发生时间
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
