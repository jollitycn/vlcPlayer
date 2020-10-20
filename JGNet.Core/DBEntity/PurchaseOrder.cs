using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PurchaseOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "PurchaseOrder" ;
		public const string _ID = "ID" ;
		public const string _AdminUserID = "AdminUserID" ;
		public const string _SupplierID = "SupplierID" ;
		public const string _DestShopID = "DestShopID" ;
		public const string _InboundOrderID = "InboundOrderID" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _TotalPrice = "TotalPrice" ;
		public const string _TotalCost = "TotalCost" ;
		public const string _State = "State" ;
		public const string _PayMoney = "PayMoney" ;
		public const string _Remarks = "Remarks" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EntryTime = "EntryTime" ;
		public const string _IsCancel = "IsCancel" ;
		public const string _CancelUserID = "CancelUserID" ;
		public const string _SupplierAccountID = "SupplierAccountID" ;
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
	
		#region AdminUserID
		private System.String m_AdminUserID = "" ; 
		/// <summary>
		/// AdminUserID 进货操作人的ID
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
	
		#region SupplierID
		private System.String m_SupplierID = "" ; 
		/// <summary>
		/// SupplierID 供应商编号
		/// </summary>
		public System.String SupplierID
		{
			get
			{
				return this.m_SupplierID ;
			}
			set
			{
				this.m_SupplierID = value ;
			}
		}
		#endregion
	
		#region DestShopID
		private System.String m_DestShopID = "" ; 
		/// <summary>
		/// DestShopID 收货店铺ID
		/// </summary>
		public System.String DestShopID
		{
			get
			{
				return this.m_DestShopID ;
			}
			set
			{
				this.m_DestShopID = value ;
			}
		}
		#endregion
	
		#region InboundOrderID
		private System.String m_InboundOrderID = "" ; 
		/// <summary>
		/// InboundOrderID 入库单号
		/// </summary>
		public System.String InboundOrderID
		{
			get
			{
				return this.m_InboundOrderID ;
			}
			set
			{
				this.m_InboundOrderID = value ;
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
	
		#region TotalCost
		private System.Decimal m_TotalCost = 0 ; 
		/// <summary>
		/// TotalCost 货品进货成本
		/// </summary>
		public System.Decimal TotalCost
		{
			get
			{
				return this.m_TotalCost ;
			}
			set
			{
				this.m_TotalCost = value ;
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
	
		#region SupplierAccountID
		private System.String m_SupplierAccountID = "" ; 
		/// <summary>
		/// SupplierAccountID 帐套ID
		/// </summary>
		public System.String SupplierAccountID
		{
			get
			{
				return this.m_SupplierAccountID ;
			}
			set
			{
				this.m_SupplierAccountID = value ;
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
