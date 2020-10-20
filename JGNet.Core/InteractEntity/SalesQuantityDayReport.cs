using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class SalesQuantityDayReport : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "SalesQuantityDayReport" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _ReportDate = "ReportDate" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _ColorName = "ColorName" ;
		public const string _QuantityOfSale = "QuantityOfSale" ;
		public const string _SumMoney = "SumMoney" ;
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
	
		#region CostumeID
		private System.String m_CostumeID = "" ; 
		/// <summary>
		/// CostumeID 服装ID
		/// </summary>
		public System.String CostumeID
		{
			get
			{
				return this.m_CostumeID ;
			}
			set
			{
				this.m_CostumeID = value ;
			}
		}
		#endregion
	
		#region ColorName
		private System.String m_ColorName = "" ; 
		/// <summary>
		/// ColorName 颜色
		/// </summary>
		public System.String ColorName
		{
			get
			{
				return this.m_ColorName ;
			}
			set
			{
				this.m_ColorName = value ;
			}
		}
		#endregion
	
		#region QuantityOfSale
		private System.Int32 m_QuantityOfSale = 0 ; 
		/// <summary>
		/// QuantityOfSale 销售量（扣除退货）
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
	
		#region SumMoney
		private System.Decimal m_SumMoney = 0 ; 
		/// <summary>
		/// SumMoney 小计金额
		/// </summary>
		public System.Decimal SumMoney
		{
			get
			{
				return this.m_SumMoney ;
			}
			set
			{
				this.m_SumMoney = value ;
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
