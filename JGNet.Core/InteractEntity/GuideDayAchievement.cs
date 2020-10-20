using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class GuideDayAchievement : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "GuideDayAchievement" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _GuideID = "GuideID" ;
		public const string _ReportDate = "ReportDate" ;
		public const string _QuantityOfSale = "QuantityOfSale" ;
		public const string _MoneyOfSale = "MoneyOfSale" ;
		public const string _SalesActualRecv = "SalesActualRecv" ;
		public const string _SalesActualRecvShop = "SalesActualRecvShop" ;
		public const string _AchievementPercent = "AchievementPercent" ;
		public const string _MoneyOfPrice = "MoneyOfPrice" ;
		public const string _SalesCount = "SalesCount" ;
		public const string _JointRate = "JointRate" ;
		public const string _PerMemberPay = "PerMemberPay" ;
		public const string _PerCostumePay = "PerCostumePay" ;
		public const string _AverageDiscount = "AverageDiscount" ;
		public const string _TaskTarget = "TaskTarget" ;
		public const string _CompletionRate = "CompletionRate" ;
		public const string _CreateTime = "CreateTime" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自增ID（主键）
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
		/// ShopID 店铺ID
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
	
		#region ReportDate
		private System.Int32 m_ReportDate = 0 ; 
		/// <summary>
		/// ReportDate 哪一天的统计，固定8位数字，如20180302
		/// </summary>
		public System.Int32 ReportDate
		{
			get
			{
				return this.m_ReportDate ;
			}
			set
			{
				this.m_ReportDate = value ;
			}
		}
		#endregion
	
		#region QuantityOfSale
		private System.Int32 m_QuantityOfSale = 0 ; 
		/// <summary>
		/// QuantityOfSale 销售量
		/// </summary>
		public System.Int32 QuantityOfSale
		{
			get
			{
				return this.m_QuantityOfSale ;
			}
			set
			{
				this.m_QuantityOfSale = value ;
			}
		}
		#endregion
	
		#region MoneyOfSale
		private System.Decimal m_MoneyOfSale = 0 ; 
		/// <summary>
		/// MoneyOfSale 个人销售额
		/// </summary>
		public System.Decimal MoneyOfSale
		{
			get
			{
				return this.m_MoneyOfSale ;
			}
			set
			{
				this.m_MoneyOfSale = value ;
			}
		}
		#endregion
	
		#region SalesActualRecv
		private System.Decimal m_SalesActualRecv = 0 ; 
		/// <summary>
		/// SalesActualRecv 个人实收额 = 销售额 - 积分抵扣 - vip赠送金额
		/// </summary>
		public System.Decimal SalesActualRecv
		{
			get
			{
				return this.m_SalesActualRecv ;
			}
			set
			{
				this.m_SalesActualRecv = value ;
			}
		}
		#endregion
	
		#region SalesActualRecvShop
		private System.Decimal m_SalesActualRecvShop = 0 ; 
		/// <summary>
		/// SalesActualRecvShop 店铺实收总额
		/// </summary>
		public System.Decimal SalesActualRecvShop
		{
			get
			{
				return this.m_SalesActualRecvShop ;
			}
			set
			{
				this.m_SalesActualRecvShop = value ;
			}
		}
		#endregion
	
		#region AchievementPercent
		private System.Double m_AchievementPercent = 0 ; 
		/// <summary>
		/// AchievementPercent 个人业绩占比 = 个人实收额 / 店铺实收总额
		/// </summary>
		public System.Double AchievementPercent
		{
			get
			{
				return this.m_AchievementPercent ;
			}
			set
			{
				this.m_AchievementPercent = value ;
			}
		}
		#endregion
	
		#region MoneyOfPrice
		private System.Decimal m_MoneyOfPrice = 0 ; 
		/// <summary>
		/// MoneyOfPrice 吊牌额
		/// </summary>
		public System.Decimal MoneyOfPrice
		{
			get
			{
				return this.m_MoneyOfPrice ;
			}
			set
			{
				this.m_MoneyOfPrice = value ;
			}
		}
		#endregion
	
		#region SalesCount
		private System.Int32 m_SalesCount = 0 ; 
		/// <summary>
		/// SalesCount 成交笔数（销售单数）
		/// </summary>
		public System.Int32 SalesCount
		{
			get
			{
				return this.m_SalesCount ;
			}
			set
			{
				this.m_SalesCount = value ;
			}
		}
		#endregion
	
		#region JointRate
		private System.Double m_JointRate = 0 ; 
		/// <summary>
		/// JointRate 连带率 = 件数 / 单数
		/// </summary>
		public System.Double JointRate
		{
			get
			{
				return this.m_JointRate ;
			}
			set
			{
				this.m_JointRate = value ;
			}
		}
		#endregion
	
		#region PerMemberPay
		private System.Double m_PerMemberPay = 0 ; 
		/// <summary>
		/// PerMemberPay 客单价 = 实收额 / 单数
		/// </summary>
		public System.Double PerMemberPay
		{
			get
			{
				return this.m_PerMemberPay ;
			}
			set
			{
				this.m_PerMemberPay = value ;
			}
		}
		#endregion
	
		#region PerCostumePay
		private System.Double m_PerCostumePay = 0 ; 
		/// <summary>
		/// PerCostumePay 物单价 = 实收额 / 销售量
		/// </summary>
		public System.Double PerCostumePay
		{
			get
			{
				return this.m_PerCostumePay ;
			}
			set
			{
				this.m_PerCostumePay = value ;
			}
		}
		#endregion
	
		#region AverageDiscount
		private System.Decimal m_AverageDiscount = 0 ; 
		/// <summary>
		/// AverageDiscount 平均折扣 = 销售额 / 吊牌额
		/// </summary>
		public System.Decimal AverageDiscount
		{
			get
			{
				return this.m_AverageDiscount ;
			}
			set
			{
				this.m_AverageDiscount = value ;
			}
		}
		#endregion
	
		#region TaskTarget
		private System.Int32 m_TaskTarget = 0 ; 
		/// <summary>
		/// TaskTarget 目标销售额
		/// </summary>
		public System.Int32 TaskTarget
		{
			get
			{
				return this.m_TaskTarget ;
			}
			set
			{
				this.m_TaskTarget = value ;
			}
		}
		#endregion
	
		#region CompletionRate
		private System.Double m_CompletionRate = 0 ; 
		/// <summary>
		/// CompletionRate 目标完成率 = 销售额 / 目标销售额
		/// </summary>
		public System.Double CompletionRate
		{
			get
			{
				return this.m_CompletionRate ;
			}
			set
			{
				this.m_CompletionRate = value ;
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
