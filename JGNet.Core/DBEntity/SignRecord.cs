using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class SignRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "SignRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _GuideID = "GuideID" ;
		public const string _ShopID = "ShopID" ;
		public const string _SignType = "SignType" ;
		public const string _SignedTime = "SignedTime" ;
		public const string _ReferTime = "ReferTime" ;
		public const string _AbsentMinutes = "AbsentMinutes" ;
		public const string _Photo = "Photo" ;
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
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 所属店铺
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
	
		#region SignType
		private System.Byte m_SignType = 0 ; 
		/// <summary>
		/// SignType 打卡类型：早班上班、早班下班、晚班上班、晚班下班
		/// </summary>
		public System.Byte SignType
		{
			get
			{
				return this.m_SignType ;
			}
			set
			{
				this.m_SignType = value ;
			}
		}
		#endregion
	
		#region SignedTime
		private System.DateTime m_SignedTime = DateTime.Now ; 
		/// <summary>
		/// SignedTime 打卡时间
		/// </summary>
		public System.DateTime SignedTime
		{
			get
			{
				return this.m_SignedTime ;
			}
			set
			{
				this.m_SignedTime = value ;
			}
		}
		#endregion
	
		#region ReferTime
		private System.DateTime m_ReferTime = DateTime.Now ; 
		/// <summary>
		/// ReferTime 参考时间
		/// </summary>
		public System.DateTime ReferTime
		{
			get
			{
				return this.m_ReferTime ;
			}
			set
			{
				this.m_ReferTime = value ;
			}
		}
		#endregion
	
		#region AbsentMinutes
		private System.Int32 m_AbsentMinutes = 0 ; 
		/// <summary>
		/// AbsentMinutes 缺勤时间，单位：分钟。
		/// </summary>
		public System.Int32 AbsentMinutes
		{
			get
			{
				return this.m_AbsentMinutes ;
			}
			set
			{
				this.m_AbsentMinutes = value ;
			}
		}
		#endregion
	
		#region Photo
		private System.Byte[] m_Photo = null ; 
		/// <summary>
		/// Photo 拍照照片
		/// </summary>
		public System.Byte[] Photo
		{
			get
			{
				return this.m_Photo ;
			}
			set
			{
				this.m_Photo = value ;
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
