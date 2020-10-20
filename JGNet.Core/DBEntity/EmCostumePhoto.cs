using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmCostumePhoto : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "EmCostumePhoto" ;
		public const string _AutoID = "AutoID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _ColorName = "ColorName" ;
		public const string _PhotoName = "PhotoName" ;
		public const string _LinkAddress = "LinkAddress" ;
		public const string _DisplayIndex = "DisplayIndex" ;
		public const string _IsMain = "IsMain" ;
		public const string _IsVideo = "IsVideo" ;
		public const string _Comment = "Comment" ;
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
	
		#region CostumeID
		private System.String m_CostumeID = "" ; 
		/// <summary>
		/// CostumeID 款号
		/// </summary>
		public System.String CostumeID
		{
			get
			{
				return this.m_CostumeID ;
			}
			set
			{
				this.m_CostumeID = value ;
			}
		}
		#endregion
	
		#region ColorName
		private System.String m_ColorName = "" ; 
		/// <summary>
		/// ColorName 颜色
		/// </summary>
		public System.String ColorName
		{
			get
			{
				return this.m_ColorName ;
			}
			set
			{
				this.m_ColorName = value ;
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
	
		#region IsMain
		private System.Boolean m_IsMain = false ; 
		/// <summary>
		/// IsMain 是否为主显示图片
		/// </summary>
		public System.Boolean IsMain
		{
			get
			{
				return this.m_IsMain ;
			}
			set
			{
				this.m_IsMain = value ;
			}
		}
		#endregion
	
		#region IsVideo
		private System.Boolean m_IsVideo = false ; 
		/// <summary>
		/// IsVideo 是否为视频
		/// </summary>
		public System.Boolean IsVideo
		{
			get
			{
				return this.m_IsVideo ;
			}
			set
			{
				this.m_IsVideo = value ;
			}
		}
		#endregion
	
		#region Comment
		private System.String m_Comment = "" ; 
		/// <summary>
		/// Comment 备注
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
