using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmPosterImage : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "EmPosterImage" ;
		public const string _AutoID = "AutoID" ;
		public const string _BusinessAccountID = "BusinessAccountID" ;
		public const string _PhotoName = "PhotoName" ;
		public const string _LinkAddress = "LinkAddress" ;
		public const string _DisplayIndex = "DisplayIndex" ;
		public const string _Type = "Type" ;
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
	
		#region PhotoName
		private System.String m_PhotoName = "" ; 
		/// <summary>
		/// PhotoName 图片名称。格式：款号_时间序列号
		/// </summary>
		public System.String PhotoName
		{
			get
			{
				return this.m_PhotoName ;
			}
			set
			{
				this.m_PhotoName = value ;
			}
		}
		#endregion
	
		#region LinkAddress
		private System.String m_LinkAddress = "" ; 
		/// <summary>
		/// LinkAddress 存储的链接地址
		/// </summary>
		public System.String LinkAddress
		{
			get
			{
				return this.m_LinkAddress ;
			}
			set
			{
				this.m_LinkAddress = value ;
			}
		}
		#endregion
	
		#region DisplayIndex
		private System.Int32 m_DisplayIndex = 0 ; 
		/// <summary>
		/// DisplayIndex 显示的顺序。
		/// </summary>
		public System.Int32 DisplayIndex
		{
			get
			{
				return this.m_DisplayIndex ;
			}
			set
			{
				this.m_DisplayIndex = value ;
			}
		}
		#endregion
	
		#region Type
		private System.Byte m_Type = 0 ; 
		/// <summary>
		/// Type 图片类型（0：海报，1：广告）
		/// </summary>
		public System.Byte Type
		{
			get
			{
				return this.m_Type ;
			}
			set
			{
				this.m_Type = value ;
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
