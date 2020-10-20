using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PfOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "PfOrder" ;
		public const string _ID = "ID" ;
		public const string _IsRefundOrder = "IsRefundOrder" ;
		public const string _AdminUserID = "AdminUserID" ;
		public const string _ShopID = "ShopID" ;
		public const string _PfCustomerID = "PfCustomerID" ;
		public const string _PfCustomerOrderID = "PfCustomerOrderID" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _TotalPrice = "TotalPrice" ;
		public const string _TotalPfPrice = "TotalPfPrice" ;
		public const string _PayType = "PayType" ;
		public const string _ExpressCompany = "ExpressCompany" ;
		public const string _ExpressOrderID = "ExpressOrderID" ;
		public const string _State = "State" ;
		public const string _PayMoney = "PayMoney" ;
		public const string _Remarks = "Remarks" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EntryTime = "EntryTime" ;
		public const string _IsCancel = "IsCancel" ;
		public const string _CancelUserID = "CancelUserID" ;
		public const string _PaymentBalance = "PaymentBalance" ;
		public const string _PaymentBalanceOld = "PaymentBalanceOld" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 单据编号（主键）
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
	
		#region IsRefundOrder
		private System.Boolean m_IsRefundOrder = false ; 
		/// <summary>
		/// IsRefundOrder 是否为退货单？
		/// </summary>
		public System.Boolean IsRefundOrder
		{
			get
			{
				return this.m_IsRefundOrder ;
			}
			set
			{
				this.m_IsRefundOrder = value ;
			}
		}
		#endregion
	
		#region AdminUserID
		private System.String m_AdminUserID = "" ; 
		/// <summary>
		/// AdminUserID 操作人的ID
		/// </summary>
		public System.String AdminUserID
		{
			get
			{
				return this.m_AdminUserID ;
			}
			set
			{
				this.m_AdminUserID = value ;
			}
		}
		#endregion
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 批发商店铺编号
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
	
		#region PfCustomerID
		private System.String m_PfCustomerID = "" ; 
		/// <summary>
		/// PfCustomerID 客户ID
		/// </summary>
		public System.String PfCustomerID
		{
			get
			{
				return this.m_PfCustomerID ;
			}
			set
			{
				this.m_PfCustomerID = value ;
			}
		}
		#endregion
	
		#region PfCustomerOrderID
		private System.String m_PfCustomerOrderID = "" ; 
		/// <summary>
		/// PfCustomerOrderID 批发订货单编号
		/// </summary>
		public System.String PfCustomerOrderID
		{
			get
			{
				return this.m_PfCustomerOrderID ;
			}
			set
			{
				this.m_PfCustomerOrderID = value ;
			}
		}
		#endregion
	
		#region TotalCount
		private System.Int32 m_TotalCount = 0 ; 
		/// <summary>
		/// TotalCount 总件数
		/// </summary>
		public System.Int32 TotalCount
		{
			get
			{
				return this.m_TotalCount ;
			}
			set
			{
				this.m_TotalCount = value ;
			}
		}
		#endregion
	
		#region TotalPrice
		private System.Decimal m_TotalPrice = 0 ; 
		/// <summary>
		/// TotalPrice 货品吊牌额
		/// </summary>
		public System.Decimal TotalPrice
		{
			get
			{
				return this.m_TotalPrice ;
			}
			set
			{
				this.m_TotalPrice = value ;
			}
		}
		#endregion
	
		#region TotalPfPrice
		private System.Decimal m_TotalPfPrice = 0 ; 
		/// <summary>
		/// TotalPfPrice 货品批发成本
		/// </summary>
		public System.Decimal TotalPfPrice
		{
			get
			{
				return this.m_TotalPfPrice ;
			}
			set
			{
				this.m_TotalPfPrice = value ;
			}
		}
		#endregion
	
		#region PayType
		private System.Byte m_PayType = 0 ; 
		/// <summary>
		/// PayType 付款类型(0:记账，1：余额，2：现金)
		/// </summary>
		public System.Byte PayType
		{
			get
			{
				return this.m_PayType ;
			}
			set
			{
				this.m_PayType = value ;
			}
		}
		#endregion
	
		#region ExpressCompany
		private System.String m_ExpressCompany = "" ; 
		/// <summary>
		/// ExpressCompany 快递公司名称（卖家发货）
		/// </summary>
		public System.String ExpressCompany
		{
			get
			{
				return this.m_ExpressCompany ;
			}
			set
			{
				this.m_ExpressCompany = value ;
			}
		}
		#endregion
	
		#region ExpressOrderID
		private System.String m_ExpressOrderID = "" ; 
		/// <summary>
		/// ExpressOrderID 快递单号（卖家发货）
		/// </summary>
		public System.String ExpressOrderID
		{
			get
			{
				return this.m_ExpressOrderID ;
			}
			set
			{
				this.m_ExpressOrderID = value ;
			}
		}
		#endregion
	
		#region State
		private System.Byte m_State = 0 ; 
		/// <summary>
		/// State 状态： 0（正常），1（挂单）
		/// </summary>
		public System.Byte State
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
	
		#region PayMoney
		private System.Decimal m_PayMoney = 0 ; 
		/// <summary>
		/// PayMoney 付款金额
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
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 单据日期
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
	
		#region EntryTime
		private System.DateTime m_EntryTime = DateTime.Now ; 
		/// <summary>
		/// EntryTime 制单时间
		/// </summary>
		public System.DateTime EntryTime
		{
			get
			{
				return this.m_EntryTime ;
			}
			set
			{
				this.m_EntryTime = value ;
			}
		}
		#endregion
	
		#region IsCancel
		private System.Boolean m_IsCancel = false ; 
		/// <summary>
		/// IsCancel 是否冲单？
		/// </summary>
		public System.Boolean IsCancel
		{
			get
			{
				return this.m_IsCancel ;
			}
			set
			{
				this.m_IsCancel = value ;
			}
		}
		#endregion
	
		#region CancelUserID
		private System.String m_CancelUserID = "" ; 
		/// <summary>
		/// CancelUserID 冲单用户ID
		/// </summary>
		public System.String CancelUserID
		{
			get
			{
				return this.m_CancelUserID ;
			}
			set
			{
				this.m_CancelUserID = value ;
			}
		}
		#endregion
	
		#region PaymentBalance
		private System.Decimal m_PaymentBalance = 0 ; 
		/// <summary>
		/// PaymentBalance 现在应收款结余
		/// </summary>
		public System.Decimal PaymentBalance
		{
			get
			{
				return this.m_PaymentBalance ;
			}
			set
			{
				this.m_PaymentBalance = value ;
			}
		}
		#endregion
	
		#region PaymentBalanceOld
		private System.Decimal m_PaymentBalanceOld = 0 ;
        /// <summary>
        /// PaymentBalanceOld 上欠金额（本次发货/退货前的客户期末余额）
        /// </summary>
        public System.Decimal PaymentBalanceOld
		{
			get
			{
				return this.m_PaymentBalanceOld ;
			}
			set
			{
				this.m_PaymentBalanceOld = value ;
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
