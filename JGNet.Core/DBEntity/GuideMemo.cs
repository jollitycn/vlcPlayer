using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class GuideMemo : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "GuideMemo" ;
		public const string _AutoID = "AutoID" ;
		public const string _GuideID = "GuideID" ;
		public const string _MemoContent = "MemoContent" ;
		public const string _MemoAudio = "MemoAudio" ;
		public const string _MemoImage1 = "MemoImage1" ;
		public const string _MemoImage2 = "MemoImage2" ;
		public const string _MemoImage3 = "MemoImage3" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _IsClosed = "IsClosed" ;
		public const string _ClosedTime = "ClosedTime" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自动编号（主键）
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
	
		#region GuideID
		private System.String m_GuideID = "" ; 
		/// <summary>
		/// GuideID 操作的导购ID
		/// </summary>
		public System.String GuideID
		{
			get
			{
				return this.m_GuideID ;
			}
			set
			{
				this.m_GuideID = value ;
			}
		}
		#endregion
	
		#region MemoContent
		private System.String m_MemoContent = "" ; 
		/// <summary>
		/// MemoContent 备忘内容
		/// </summary>
		public System.String MemoContent
		{
			get
			{
				return this.m_MemoContent ;
			}
			set
			{
				this.m_MemoContent = value ;
			}
		}
		#endregion
	
		#region MemoAudio
		private System.Byte[] m_MemoAudio = null ; 
		/// <summary>
		/// MemoAudio 备忘语音
		/// </summary>
		public System.Byte[] MemoAudio
		{
			get
			{
				return this.m_MemoAudio ;
			}
			set
			{
				this.m_MemoAudio = value ;
			}
		}
		#endregion
	
		#region MemoImage1
		private System.Byte[] m_MemoImage1 = null ; 
		/// <summary>
		/// MemoImage1 备忘图片1
		/// </summary>
		public System.Byte[] MemoImage1
		{
			get
			{
				return this.m_MemoImage1 ;
			}
			set
			{
				this.m_MemoImage1 = value ;
			}
		}
		#endregion
	
		#region MemoImage2
		private System.Byte[] m_MemoImage2 = null ; 
		/// <summary>
		/// MemoImage2 备忘图片2
		/// </summary>
		public System.Byte[] MemoImage2
		{
			get
			{
				return this.m_MemoImage2 ;
			}
			set
			{
				this.m_MemoImage2 = value ;
			}
		}
		#endregion
	
		#region MemoImage3
		private System.Byte[] m_MemoImage3 = null ; 
		/// <summary>
		/// MemoImage3 备忘图片3
		/// </summary>
		public System.Byte[] MemoImage3
		{
			get
			{
				return this.m_MemoImage3 ;
			}
			set
			{
				this.m_MemoImage3 = value ;
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
	
		#region IsClosed
		private System.Boolean m_IsClosed = false ; 
		/// <summary>
		/// IsClosed 是否已完成？
		/// </summary>
		public System.Boolean IsClosed
		{
			get
			{
				return this.m_IsClosed ;
			}
			set
			{
				this.m_IsClosed = value ;
			}
		}
		#endregion
	
		#region ClosedTime
		private System.DateTime m_ClosedTime = DateTime.Now ; 
		/// <summary>
		/// ClosedTime 完成时间
		/// </summary>
		public System.DateTime ClosedTime
		{
			get
			{
				return this.m_ClosedTime ;
			}
			set
			{
				this.m_ClosedTime = value ;
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
