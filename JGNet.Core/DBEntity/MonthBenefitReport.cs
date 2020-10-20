using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class MonthBenefitReport : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "MonthBenefitReport" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _ReportMonth = "ReportMonth" ;
		public const string _QuantityOfSale = "QuantityOfSale" ;
		public const string _QuantityOfRefund = "QuantityOfRefund" ;
		public const string _SalesCount = "SalesCount" ;
		public const string _SalesTotalMoney = "SalesTotalMoney" ;
		public const string _SalesTotalPrice = "SalesTotalPrice" ;
		public const string _SalesTotalMoneyVip = "SalesTotalMoneyVip" ;
		public const string _SalesInVipIntegration = "SalesInVipIntegration" ;
		public const string _SalesInVipDonate = "SalesInVipDonate" ;
		public const string _SalesTotalCost = "SalesTotalCost" ;
		public const string _SalesActualRecv = "SalesActualRecv" ;
		public const string _SalesBenefit = "SalesBenefit" ;
		public const string _SalesVipContribution = "SalesVipContribution" ;
		public const string _SalesAverageDiscount = "SalesAverageDiscount" ;
		public const string _SalesJointRate = "SalesJointRate" ;
		public const string _SalesPerMemberPay = "SalesPerMemberPay" ;
		public const string _SalesPerCostumePay = "SalesPerCostumePay" ;
		public const string _RefundRate = "RefundRate" ;
		public const string _CashCurrent = "CashCurrent" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _Remarks = "Remarks" ;
		public const string _MonthExpense = "MonthExpense" ;
		public const string _SalesBenefitNet = "SalesBenefitNet" ;
		public const string _SalesInGiftTicket = "SalesInGiftTicket" ;
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
	
		#region ReportMonth
		private System.Int32 m_ReportMonth = 0 ; 
		/// <summary>
		/// ReportMonth 哪一月的统计，固定6位数字，如201803
		/// </summary>
		public System.Int32 ReportMonth
		{
			get
			{
				return this.m_ReportMonth ;
			}
			set
			{
				this.m_ReportMonth = value ;
			}
		}
		#endregion
	
		#region QuantityOfSale
		private System.Int32 m_QuantityOfSale = 0 ; 
		/// <summary>
		/// QuantityOfSale 销售的商品总数量（不扣除退货）
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
	
		#region QuantityOfRefund
		private System.Int32 m_QuantityOfRefund = 0 ; 
		/// <summary>
		/// QuantityOfRefund 退货的商品总数量
		/// </summary>
		public System.Int32 QuantityOfRefund
		{
			get
			{
				return this.m_QuantityOfRefund ;
			}
			set
			{
				this.m_QuantityOfRefund = value ;
			}
		}
		#endregion
	
		#region SalesCount
		private System.Int32 m_SalesCount = 0 ; 
		/// <summary>
		/// SalesCount 销售单数（扣除退货）
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
	
		#region SalesTotalMoney
		private System.Decimal m_SalesTotalMoney = 0 ; 
		/// <summary>
		/// SalesTotalMoney 销售收入总金额（扣除退货）
		/// </summary>
		public System.Decimal SalesTotalMoney
		{
			get
			{
				return this.m_SalesTotalMoney ;
			}
			set
			{
				this.m_SalesTotalMoney = value ;
			}
		}
		#endregion
	
		#region SalesTotalPrice
		private System.Decimal m_SalesTotalPrice = 0 ; 
		/// <summary>
		/// SalesTotalPrice 销售商品吊牌总额（扣除退货）
		/// </summary>
		public System.Decimal SalesTotalPrice
		{
			get
			{
				return this.m_SalesTotalPrice ;
			}
			set
			{
				this.m_SalesTotalPrice = value ;
			}
		}
		#endregion
	
		#region SalesTotalMoneyVip
		private System.Decimal m_SalesTotalMoneyVip = 0 ; 
		/// <summary>
		/// SalesTotalMoneyVip 销售收入会员贡献的总金额（扣除退货）
		/// </summary>
		public System.Decimal SalesTotalMoneyVip
		{
			get
			{
				return this.m_SalesTotalMoneyVip ;
			}
			set
			{
				this.m_SalesTotalMoneyVip = value ;
			}
		}
		#endregion
	
		#region SalesInVipIntegration
		private System.Decimal m_SalesInVipIntegration = 0 ; 
		/// <summary>
		/// SalesInVipIntegration 销售时会员使用卡积分返现的总金额（扣除退货）
		/// </summary>
		public System.Decimal SalesInVipIntegration
		{
			get
			{
				return this.m_SalesInVipIntegration ;
			}
			set
			{
				this.m_SalesInVipIntegration = value ;
			}
		}
		#endregion
	
		#region SalesInVipDonate
		private System.Decimal m_SalesInVipDonate = 0 ; 
		/// <summary>
		/// SalesInVipDonate VIP卡付款金额的赠送部分（扣除退货）
		/// </summary>
		public System.Decimal SalesInVipDonate
		{
			get
			{
				return this.m_SalesInVipDonate ;
			}
			set
			{
				this.m_SalesInVipDonate = value ;
			}
		}
		#endregion
	
		#region SalesTotalCost
		private System.Decimal m_SalesTotalCost = 0 ; 
		/// <summary>
		/// SalesTotalCost 销售商品的成本（扣除退货）
		/// </summary>
		public System.Decimal SalesTotalCost
		{
			get
			{
				return this.m_SalesTotalCost ;
			}
			set
			{
				this.m_SalesTotalCost = value ;
			}
		}
		#endregion
	
		#region SalesActualRecv
		private System.Decimal m_SalesActualRecv = 0 ; 
		/// <summary>
		/// SalesActualRecv 实收额 = SalesTotalMoney - SalesInVipIntegration - SalesInVipDonate - SalesInGiftTicket
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
	
		#region SalesBenefit
		private System.Decimal m_SalesBenefit = 0 ; 
		/// <summary>
		/// SalesBenefit 零售毛利 = SalesActualRecv - SalesTotalCost
		/// </summary>
		public System.Decimal SalesBenefit
		{
			get
			{
				return this.m_SalesBenefit ;
			}
			set
			{
				this.m_SalesBenefit = value ;
			}
		}
		#endregion
	
		#region SalesVipContribution
		private System.Double m_SalesVipContribution = 0 ; 
		/// <summary>
		/// SalesVipContribution VIP贡献率 = SalesTotalMoneyVip / SalesTotalMoney
		/// </summary>
		public System.Double SalesVipContribution
		{
			get
			{
				return this.m_SalesVipContribution ;
			}
			set
			{
				this.m_SalesVipContribution = value ;
			}
		}
		#endregion
	
		#region SalesAverageDiscount
		private System.Decimal m_SalesAverageDiscount = 0 ; 
		/// <summary>
		/// SalesAverageDiscount 平均折扣 = SalesTotalMoney / SalesTotalPrice * 100
		/// </summary>
		public System.Decimal SalesAverageDiscount
		{
			get
			{
				return this.m_SalesAverageDiscount ;
			}
			set
			{
				this.m_SalesAverageDiscount = value ;
			}
		}
		#endregion
	
		#region SalesJointRate
		private System.Double m_SalesJointRate = 0 ; 
		/// <summary>
		/// SalesJointRate 连带率 =  QuantityOfSale / SalesCount
		/// </summary>
		public System.Double SalesJointRate
		{
			get
			{
				return this.m_SalesJointRate ;
			}
			set
			{
				this.m_SalesJointRate = value ;
			}
		}
		#endregion
	
		#region SalesPerMemberPay
		private System.Double m_SalesPerMemberPay = 0 ; 
		/// <summary>
		/// SalesPerMemberPay 客单价 = SalesActualRecv / SalesCount
		/// </summary>
		public System.Double SalesPerMemberPay
		{
			get
			{
				return this.m_SalesPerMemberPay ;
			}
			set
			{
				this.m_SalesPerMemberPay = value ;
			}
		}
		#endregion
	
		#region SalesPerCostumePay
		private System.Double m_SalesPerCostumePay = 0 ; 
		/// <summary>
		/// SalesPerCostumePay 物单价 = SalesActualRecv / QuantityOfSale
		/// </summary>
		public System.Double SalesPerCostumePay
		{
			get
			{
				return this.m_SalesPerCostumePay ;
			}
			set
			{
				this.m_SalesPerCostumePay = value ;
			}
		}
		#endregion
	
		#region RefundRate
		private System.Double m_RefundRate = 0 ; 
		/// <summary>
		/// RefundRate 退货率 = QuantityOfRefund / QuantityOfSale
		/// </summary>
		public System.Double RefundRate
		{
			get
			{
				return this.m_RefundRate ;
			}
			set
			{
				this.m_RefundRate = value ;
			}
		}
		#endregion
	
		#region CashCurrent
		private System.Decimal m_CashCurrent = 0 ; 
		/// <summary>
		/// CashCurrent 当月现金结余
		/// </summary>
		public System.Decimal CashCurrent
		{
			get
			{
				return this.m_CashCurrent ;
			}
			set
			{
				this.m_CashCurrent = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 结算时间
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
	
		#region MonthExpense
		private System.Decimal m_MonthExpense = 0 ; 
		/// <summary>
		/// MonthExpense 月支出 （只对汇总报表有效）
		/// </summary>
		public System.Decimal MonthExpense
		{
			get
			{
				return this.m_MonthExpense ;
			}
			set
			{
				this.m_MonthExpense = value ;
			}
		}
		#endregion
	
		#region SalesBenefitNet
		private System.Decimal m_SalesBenefitNet = 0 ; 
		/// <summary>
		/// SalesBenefitNet 净利润 = SalesBenefit - MonthExpense （只对汇总报表有效）
		/// </summary>
		public System.Decimal SalesBenefitNet
		{
			get
			{
				return this.m_SalesBenefitNet ;
			}
			set
			{
				this.m_SalesBenefitNet = value ;
			}
		}
		#endregion
	
		#region SalesInGiftTicket
		private System.Decimal m_SalesInGiftTicket = 0 ; 
		/// <summary>
		/// SalesInGiftTicket 销售时会员使用电子优惠券的总金额
		/// </summary>
		public System.Decimal SalesInGiftTicket
		{
			get
			{
				return this.m_SalesInGiftTicket ;
			}
			set
			{
				this.m_SalesInGiftTicket = value ;
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
