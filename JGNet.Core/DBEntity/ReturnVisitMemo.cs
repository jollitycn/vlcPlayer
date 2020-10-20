using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class ReturnVisitMemo : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "ReturnVisitMemo" ;
		public const string _AutoID = "AutoID" ;
		public const string _MemberID = "MemberID" ;
		public const string _MemberName = "MemberName" ;
		public const string _RetailOrderID = "RetailOrderID" ;
		public const string _FollowType = "FollowType" ;
		public const string _FollowDate = "FollowDate" ;
		public const string _FollowContent = "FollowContent" ;
		public const string _FollowAudioUrl = "FollowAudioUrl" ;
		public const string _FollowImage1Url = "FollowImage1Url" ;
		public const string _FollowImage2Url = "FollowImage2Url" ;
		public const string _FollowImage3Url = "FollowImage3Url" ;
		public const string _GuideID = "GuideID" ;
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
	
		#region MemberID
		private System.String m_MemberID = "" ; 
		/// <summary>
		/// MemberID 会员ID（手机号）
		/// </summary>
		public System.String MemberID
		{
			get
			{
				return this.m_MemberID ;
			}
			set
			{
				this.m_MemberID = value ;
			}
		}
		#endregion
	
		#region MemberName
		private System.String m_MemberName = "" ; 
		/// <summary>
		/// MemberName 会员名称
		/// </summary>
		public System.String MemberName
		{
			get
			{
				return this.m_MemberName ;
			}
			set
			{
				this.m_MemberName = value ;
			}
		}
		#endregion
	
		#region RetailOrderID
		private System.String m_RetailOrderID = "" ; 
		/// <summary>
		/// RetailOrderID 对应的销售单号
		/// </summary>
		public System.String RetailOrderID
		{
			get
			{
				return this.m_RetailOrderID ;
			}
			set
			{
				this.m_RetailOrderID = value ;
			}
		}
		#endregion
	
		#region FollowType
		private System.String m_FollowType = "" ; 
		/// <summary>
		/// FollowType 跟进类型
		/// </summary>
		public System.String FollowType
		{
			get
			{
				return this.m_FollowType ;
			}
			set
			{
				this.m_FollowType = value ;
			}
		}
		#endregion
	
		#region FollowDate
		private System.DateTime m_FollowDate = DateTime.Now ; 
		/// <summary>
		/// FollowDate 跟进日期（计划在这一天继续回访）
		/// </summary>
		public System.DateTime FollowDate
		{
			get
			{
				return this.m_FollowDate ;
			}
			set
			{
				this.m_FollowDate = value ;
			}
		}
		#endregion
	
		#region FollowContent
		private System.String m_FollowContent = "" ; 
		/// <summary>
		/// FollowContent 备忘内容
		/// </summary>
		public System.String FollowContent
		{
			get
			{
				return this.m_FollowContent ;
			}
			set
			{
				this.m_FollowContent = value ;
			}
		}
		#endregion
	
		#region FollowAudioUrl
		private System.String m_FollowAudioUrl = "" ; 
		/// <summary>
		/// FollowAudioUrl 备忘语音的云存储地址
		/// </summary>
		public System.String FollowAudioUrl
		{
			get
			{
				return this.m_FollowAudioUrl ;
			}
			set
			{
				this.m_FollowAudioUrl = value ;
			}
		}
		#endregion
	
		#region FollowImage1Url
		private System.String m_FollowImage1Url = "" ; 
		/// <summary>
		/// FollowImage1Url 备忘图片1的云存储地址
		/// </summary>
		public System.String FollowImage1Url
		{
			get
			{
				return this.m_FollowImage1Url ;
			}
			set
			{
				this.m_FollowImage1Url = value ;
			}
		}
		#endregion
	
		#region FollowImage2Url
		private System.String m_FollowImage2Url = "" ; 
		/// <summary>
		/// FollowImage2Url 备忘图片2的云存储地址
		/// </summary>
		public System.String FollowImage2Url
		{
			get
			{
				return this.m_FollowImage2Url ;
			}
			set
			{
				this.m_FollowImage2Url = value ;
			}
		}
		#endregion
	
		#region FollowImage3Url
		private System.String m_FollowImage3Url = "" ; 
		/// <summary>
		/// FollowImage3Url 备忘图片3的云存储地址
		/// </summary>
		public System.String FollowImage3Url
		{
			get
			{
				return this.m_FollowImage3Url ;
			}
			set
			{
				this.m_FollowImage3Url = value ;
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
