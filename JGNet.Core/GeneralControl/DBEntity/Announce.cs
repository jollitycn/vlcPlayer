using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class Announce : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "Announce" ;
		public const string _AutoID = "AutoID" ;
		public const string _AnnounceType = "AnnounceType" ;
		public const string _AnnounceContent = "AnnounceContent" ;
		public const string _State = "State" ;
		public const string _ExcuteTimePlan = "ExcuteTimePlan" ;
		public const string _CompleteTime = "CompleteTime" ;
		public const string _CancelTime = "CancelTime" ;
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
	
		#region AnnounceType
		private System.Int32 m_AnnounceType = 0 ; 
		/// <summary>
		/// AnnounceType 公告类型。1：版本升级，2：
		/// </summary>
		public System.Int32 AnnounceType
		{
			get
			{
				return this.m_AnnounceType ;
			}
			set
			{
				this.m_AnnounceType = value ;
			}
		}
		#endregion
	
		#region AnnounceContent
		private System.String m_AnnounceContent = "" ; 
		/// <summary>
		/// AnnounceContent 公告内容
		/// </summary>
		public System.String AnnounceContent
		{
			get
			{
				return this.m_AnnounceContent ;
			}
			set
			{
				this.m_AnnounceContent = value ;
			}
		}
		#endregion
	
		#region State
		private System.Int32 m_State = 0 ; 
		/// <summary>
		/// State 状态。1：发布中，2：已完成，3：已取消
		/// </summary>
		public System.Int32 State
		{
			get
			{
				return this.m_State ;
			}
			set
			{
				this.m_State = value ;
			}
		}
		#endregion
	
		#region ExcuteTimePlan
		private System.DateTime m_ExcuteTimePlan = DateTime.Now ; 
		/// <summary>
		/// ExcuteTimePlan 预计执行时间
		/// </summary>
		public System.DateTime ExcuteTimePlan
		{
			get
			{
				return this.m_ExcuteTimePlan ;
			}
			set
			{
				this.m_ExcuteTimePlan = value ;
			}
		}
		#endregion
	
		#region CompleteTime
		private System.DateTime m_CompleteTime = DateTime.Now ; 
		/// <summary>
		/// CompleteTime 完成时间
		/// </summary>
		public System.DateTime CompleteTime
		{
			get
			{
				return this.m_CompleteTime ;
			}
			set
			{
				this.m_CompleteTime = value ;
			}
		}
		#endregion
	
		#region CancelTime
		private System.DateTime m_CancelTime = DateTime.Now ; 
		/// <summary>
		/// CancelTime 取消时间
		/// </summary>
		public System.DateTime CancelTime
		{
			get
			{
				return this.m_CancelTime ;
			}
			set
			{
				this.m_CancelTime = value ;
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
