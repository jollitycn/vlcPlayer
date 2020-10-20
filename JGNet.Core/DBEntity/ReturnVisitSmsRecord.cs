using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class ReturnVisitSmsRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "ReturnVisitSmsRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _GuideID = "GuideID" ;
		public const string _MemberID = "MemberID" ;
		public const string _SmsContent = "SmsContent" ;
		public const string _SentTime = "SentTime" ;
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
	
		#region GuideID
		private System.String m_GuideID = "" ; 
		/// <summary>
		/// GuideID 导购员编号
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
	
		#region SmsContent
		private System.String m_SmsContent = "" ; 
		/// <summary>
		/// SmsContent 短信内容
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
	
		#region SentTime
		private System.DateTime m_SentTime = DateTime.Now ; 
		/// <summary>
		/// SentTime 发送时间
		/// </summary>
		public System.DateTime SentTime
		{
			get
			{
				return this.m_SentTime ;
			}
			set
			{
				this.m_SentTime = value ;
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
