using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class RechargeRecord : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "RechargeRecord" ;
		public const string _ID = "ID" ;
		public const string _ShopID = "ShopID" ;
		public const string _MemberID = "MemberID" ;
		public const string _MemberName = "MemberName" ;
		public const string _GuideID = "GuideID" ;
		public const string _BalanceOld = "BalanceOld" ;
		public const string _RechargeMoney = "RechargeMoney" ;
		public const string _MoneyCash = "MoneyCash" ;
		public const string _MoneyBankCard = "MoneyBankCard" ;
		public const string _MoneyWeiXin = "MoneyWeiXin" ;
		public const string _MoneyAlipay = "MoneyAlipay" ;
		public const string _DonateMoney = "DonateMoney" ;
		public const string _BalanceNew = "BalanceNew" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _Remarks = "Remarks" ;
		public const string _EmOnline = "EmOnline" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 充值记录编号（主键）
		/// </summary>
		public System.String ID
		{
			get
			{
				return this.m_ID ;
			}
			set
			{
				this.m_ID = value ;
			}
		}
		#endregion
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 店铺ID（主键）
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
		/// MemberName 会员姓名
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
	
		#region GuideID
		private System.String m_GuideID = "" ; 
		/// <summary>
		/// GuideID 导购
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
	
		#region BalanceOld
		private System.Decimal m_BalanceOld = 0 ; 
		/// <summary>
		/// BalanceOld 充值前余额
		/// </summary>
		public System.Decimal BalanceOld
		{
			get
			{
				return this.m_BalanceOld ;
			}
			set
			{
				this.m_BalanceOld = value ;
			}
		}
		#endregion
	
		#region RechargeMoney
		private System.Decimal m_RechargeMoney = 0 ; 
		/// <summary>
		/// RechargeMoney 充值金额
		/// </summary>
		public System.Decimal RechargeMoney
		{
			get
			{
				return this.m_RechargeMoney ;
			}
			set
			{
				this.m_RechargeMoney = value ;
			}
		}
		#endregion
	
		#region MoneyCash
		private System.Decimal m_MoneyCash = 0 ; 
		/// <summary>
		/// MoneyCash 现金付款金额
		/// </summary>
		public System.Decimal MoneyCash
		{
			get
			{
				return this.m_MoneyCash ;
			}
			set
			{
				this.m_MoneyCash = value ;
			}
		}
		#endregion
	
		#region MoneyBankCard
		private System.Decimal m_MoneyBankCard = 0 ; 
		/// <summary>
		/// MoneyBankCard 银联卡付款金额
		/// </summary>
		public System.Decimal MoneyBankCard
		{
			get
			{
				return this.m_MoneyBankCard ;
			}
			set
			{
				this.m_MoneyBankCard = value ;
			}
		}
		#endregion
	
		#region MoneyWeiXin
		private System.Decimal m_MoneyWeiXin = 0 ; 
		/// <summary>
		/// MoneyWeiXin 微信付款金额
		/// </summary>
		public System.Decimal MoneyWeiXin
		{
			get
			{
				return this.m_MoneyWeiXin ;
			}
			set
			{
				this.m_MoneyWeiXin = value ;
			}
		}
		#endregion
	
		#region MoneyAlipay
		private System.Decimal m_MoneyAlipay = 0 ; 
		/// <summary>
		/// MoneyAlipay 支付宝付款金额
		/// </summary>
		public System.Decimal MoneyAlipay
		{
			get
			{
				return this.m_MoneyAlipay ;
			}
			set
			{
				this.m_MoneyAlipay = value ;
			}
		}
		#endregion
	
		#region DonateMoney
		private System.Decimal m_DonateMoney = 0 ; 
		/// <summary>
		/// DonateMoney 赠送金额
		/// </summary>
		public System.Decimal DonateMoney
		{
			get
			{
				return this.m_DonateMoney ;
			}
			set
			{
				this.m_DonateMoney = value ;
			}
		}
		#endregion
	
		#region BalanceNew
		private System.Decimal m_BalanceNew = 0 ; 
		/// <summary>
		/// BalanceNew 充值后余额
		/// </summary>
		public System.Decimal BalanceNew
		{
			get
			{
				return this.m_BalanceNew ;
			}
			set
			{
				this.m_BalanceNew = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 充值时间
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
	
		#region Remarks
		private System.String m_Remarks = "" ; 
		/// <summary>
		/// Remarks 备注
		/// </summary>
		public System.String Remarks
		{
			get
			{
				return this.m_Remarks ;
			}
			set
			{
				this.m_Remarks = value ;
			}
		}
		#endregion
	
		#region EmOnline
		private System.Boolean m_EmOnline = false ; 
		/// <summary>
		/// EmOnline 是否为线上商城中充值？
		/// </summary>
		public System.Boolean EmOnline
		{
			get
			{
				return this.m_EmOnline ;
			}
			set
			{
				this.m_EmOnline = value ;
			}
		}
		#endregion
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.ID;
	    }
	    #endregion
	}
}
