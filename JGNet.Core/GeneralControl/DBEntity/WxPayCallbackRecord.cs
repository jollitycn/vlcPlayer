using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class WxPayCallbackRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "WxPayCallbackRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _WxContent = "WxContent" ;
		public const string _WxBusinessID = "WxBusinessID" ;
		public const string _WxOpenID = "WxOpenID" ;
		public const string _OrderID = "OrderID" ;
		public const string _PayMoney = "PayMoney" ;
		public const string _CallTime = "CallTime" ;
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
	
		#region WxContent
		private System.String m_WxContent = "" ; 
		/// <summary>
		/// WxContent 回调内容
		/// </summary>
		public System.String WxContent
		{
			get
			{
				return this.m_WxContent ;
			}
			set
			{
				this.m_WxContent = value ;
			}
		}
		#endregion
	
		#region WxBusinessID
		private System.String m_WxBusinessID = "" ; 
		/// <summary>
		/// WxBusinessID 微信商户ID
		/// </summary>
		public System.String WxBusinessID
		{
			get
			{
				return this.m_WxBusinessID ;
			}
			set
			{
				this.m_WxBusinessID = value ;
			}
		}
		#endregion
	
		#region WxOpenID
		private System.String m_WxOpenID = "" ; 
		/// <summary>
		/// WxOpenID 会员微信OpenID
		/// </summary>
		public System.String WxOpenID
		{
			get
			{
				return this.m_WxOpenID ;
			}
			set
			{
				this.m_WxOpenID = value ;
			}
		}
		#endregion
	
		#region OrderID
		private System.String m_OrderID = "" ; 
		/// <summary>
		/// OrderID 线上销售单ID 或者 充值记录ID
		/// </summary>
		public System.String OrderID
		{
			get
			{
				return this.m_OrderID ;
			}
			set
			{
				this.m_OrderID = value ;
			}
		}
		#endregion
	
		#region PayMoney
		private System.Decimal m_PayMoney = 0 ; 
		/// <summary>
		/// PayMoney 支付金额
		/// </summary>
		public System.Decimal PayMoney
		{
			get
			{
				return this.m_PayMoney ;
			}
			set
			{
				this.m_PayMoney = value ;
			}
		}
		#endregion
	
		#region CallTime
		private System.DateTime m_CallTime = DateTime.Now ; 
		/// <summary>
		/// CallTime 调用时间
		/// </summary>
		public System.DateTime CallTime
		{
			get
			{
				return this.m_CallTime ;
			}
			set
			{
				this.m_CallTime = value ;
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
