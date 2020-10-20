using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class GuideFavoriteSmsTemplate : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "GuideFavoriteSmsTemplate" ;
		public const string _AutoID = "AutoID" ;
		public const string _GuideID = "GuideID" ;
		public const string _Subject = "Subject" ;
		public const string _SmsContent = "SmsContent" ;
		public const string _CreateTime = "CreateTime" ;
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
		/// GuideID 导购ID
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
		/// Subject 主题
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
	
		#region SmsContent
		private System.String m_SmsContent = "" ; 
		/// <summary>
		/// SmsContent 模版内容
		/// </summary>
		public System.String SmsContent
		{
			get
			{
				return this.m_SmsContent ;
			}
			set
			{
				this.m_SmsContent = value ;
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
