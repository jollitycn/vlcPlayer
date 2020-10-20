using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmStoreRemark : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "EmStoreRemark" ;
		public const string _AutoID = "AutoID" ;
		public const string _MemeberID = "MemeberID" ;
		public const string _EmRetailOrderID = "EmRetailOrderID" ;
		public const string _GoodsScore = "GoodsScore" ;
		public const string _ServiceAttitudeScore = "ServiceAttitudeScore" ;
		public const string _ExpressScore = "ExpressScore" ;
		public const string _RemarkTime = "RemarkTime" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自增主键
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
	
		#region MemeberID
		private System.String m_MemeberID = "" ; 
		/// <summary>
		/// MemeberID 会员卡号（手机号）
		/// </summary>
		public System.String MemeberID
		{
			get
			{
				return this.m_MemeberID ;
			}
			set
			{
				this.m_MemeberID = value ;
			}
		}
		#endregion
	
		#region EmRetailOrderID
		private System.String m_EmRetailOrderID = "" ; 
		/// <summary>
		/// EmRetailOrderID 线上销售单号
		/// </summary>
		public System.String EmRetailOrderID
		{
			get
			{
				return this.m_EmRetailOrderID ;
			}
			set
			{
				this.m_EmRetailOrderID = value ;
			}
		}
		#endregion
	
		#region GoodsScore
		private System.Byte m_GoodsScore = 0 ; 
		/// <summary>
		/// GoodsScore 宝贝与描述相符，1-5分
		/// </summary>
		public System.Byte GoodsScore
		{
			get
			{
				return this.m_GoodsScore ;
			}
			set
			{
				this.m_GoodsScore = value ;
			}
		}
		#endregion
	
		#region ServiceAttitudeScore
		private System.Byte m_ServiceAttitudeScore = 0 ; 
		/// <summary>
		/// ServiceAttitudeScore 卖家服务态度，1-5分
		/// </summary>
		public System.Byte ServiceAttitudeScore
		{
			get
			{
				return this.m_ServiceAttitudeScore ;
			}
			set
			{
				this.m_ServiceAttitudeScore = value ;
			}
		}
		#endregion
	
		#region ExpressScore
		private System.Byte m_ExpressScore = 0 ; 
		/// <summary>
		/// ExpressScore 物流服务质量，1-5分
		/// </summary>
		public System.Byte ExpressScore
		{
			get
			{
				return this.m_ExpressScore ;
			}
			set
			{
				this.m_ExpressScore = value ;
			}
		}
		#endregion
	
		#region RemarkTime
		private System.DateTime m_RemarkTime = DateTime.Now ; 
		/// <summary>
		/// RemarkTime 评价时间
		/// </summary>
		public System.DateTime RemarkTime
		{
			get
			{
				return this.m_RemarkTime ;
			}
			set
			{
				this.m_RemarkTime = value ;
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
