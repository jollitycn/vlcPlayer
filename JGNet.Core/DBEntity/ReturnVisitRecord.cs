using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class ReturnVisitRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "ReturnVisitRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _MemberID = "MemberID" ;
		public const string _MemberName = "MemberName" ;
		public const string _RetailOrderID = "RetailOrderID" ;
		public const string _GuideID = "GuideID" ;
		public const string _Subject = "Subject" ;
		public const string _VisitContent = "VisitContent" ;
		public const string _VisitType = "VisitType" ;
		public const string _VisitTime = "VisitTime" ;
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
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 店铺
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
	
		#region GuideID
		private System.String m_GuideID = "" ; 
		/// <summary>
		/// GuideID 回访的导购ID
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
	
		#region Subject
		private System.String m_Subject = "" ; 
		/// <summary>
		/// Subject 回访主题
		/// </summary>
		public System.String Subject
		{
			get
			{
				return this.m_Subject ;
			}
			set
			{
				this.m_Subject = value ;
			}
		}
		#endregion
	
		#region VisitContent
		private System.String m_VisitContent = "" ; 
		/// <summary>
		/// VisitContent 回访内容
		/// </summary>
		public System.String VisitContent
		{
			get
			{
				return this.m_VisitContent ;
			}
			set
			{
				this.m_VisitContent = value ;
			}
		}
		#endregion
	
		#region VisitType
		private System.String m_VisitType = "" ; 
		/// <summary>
		/// VisitType 回访方式。电话，短信，微信，推送
		/// </summary>
		public System.String VisitType
		{
			get
			{
				return this.m_VisitType ;
			}
			set
			{
				this.m_VisitType = value ;
			}
		}
		#endregion
	
		#region VisitTime
		private System.DateTime m_VisitTime = DateTime.Now ; 
		/// <summary>
		/// VisitTime 回访时间
		/// </summary>
		public System.DateTime VisitTime
		{
			get
			{
				return this.m_VisitTime ;
			}
			set
			{
				this.m_VisitTime = value ;
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
