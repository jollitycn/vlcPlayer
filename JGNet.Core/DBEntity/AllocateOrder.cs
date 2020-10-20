using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class AllocateOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "AllocateOrder" ;
		public const string _ID = "ID" ;
		public const string _SourceUserID = "SourceUserID" ;
		public const string _DestUserID = "DestUserID" ;
		public const string _SourceShopID = "SourceShopID" ;
		public const string _DestShopID = "DestShopID" ;
		public const string _InboundOrderID = "InboundOrderID" ;
		public const string _OutboundOrderID = "OutboundOrderID" ;
		public const string _DifferenceOrderID = "DifferenceOrderID" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _TotalPrice = "TotalPrice" ;
		public const string _Remarks = "Remarks" ;
		public const string _AllocateType = "AllocateType" ;
		public const string _State = "State" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EntryTime = "EntryTime" ;
		public const string _FinishedTime = "FinishedTime" ;
		public const string _CancelTime = "CancelTime" ;
		public const string _CancelUserID = "CancelUserID" ;
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
	
		#region SourceUserID
		private System.String m_SourceUserID = "" ; 
		/// <summary>
		/// SourceUserID 发货操作人的ID
		/// </summary>
		public System.String SourceUserID
		{
			get
			{
				return this.m_SourceUserID ;
			}
			set
			{
				this.m_SourceUserID = value ;
			}
		}
		#endregion
	
		#region DestUserID
		private System.String m_DestUserID = "" ; 
		/// <summary>
		/// DestUserID 收货操作人的ID
		/// </summary>
		public System.String DestUserID
		{
			get
			{
				return this.m_DestUserID ;
			}
			set
			{
				this.m_DestUserID = value ;
			}
		}
		#endregion
	
		#region SourceShopID
		private System.String m_SourceShopID = "" ; 
		/// <summary>
		/// SourceShopID 发货店铺ID
		/// </summary>
		public System.String SourceShopID
		{
			get
			{
				return this.m_SourceShopID ;
			}
			set
			{
				this.m_SourceShopID = value ;
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
	
		#region OutboundOrderID
		private System.String m_OutboundOrderID = "" ; 
		/// <summary>
		/// OutboundOrderID 出库单号
		/// </summary>
		public System.String OutboundOrderID
		{
			get
			{
				return this.m_OutboundOrderID ;
			}
			set
			{
				this.m_OutboundOrderID = value ;
			}
		}
		#endregion
	
		#region DifferenceOrderID
		private System.String m_DifferenceOrderID = "" ; 
		/// <summary>
		/// DifferenceOrderID 入库差异单号
		/// </summary>
		public System.String DifferenceOrderID
		{
			get
			{
				return this.m_DifferenceOrderID ;
			}
			set
			{
				this.m_DifferenceOrderID = value ;
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
	
		#region AllocateType
		private System.Byte m_AllocateType = 0 ; 
		/// <summary>
		/// AllocateType 调拨类型。0（铺货），1（退货），2（店间调拨）
		/// </summary>
		public System.Byte AllocateType
		{
			get
			{
				return this.m_AllocateType ;
			}
			set
			{
				this.m_AllocateType = value ;
			}
		}
		#endregion
	
		#region State
		private System.Byte m_State = 0 ; 
		/// <summary>
		/// State 状态： 0（已发货），1（已收货）
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
	
		#region FinishedTime
		private System.DateTime m_FinishedTime = DateTime.Now ; 
		/// <summary>
		/// FinishedTime 完成日期
		/// </summary>
		public System.DateTime FinishedTime
		{
			get
			{
				return this.m_FinishedTime ;
			}
			set
			{
				this.m_FinishedTime = value ;
			}
		}
		#endregion
	
		#region CancelTime
		private System.DateTime m_CancelTime = DateTime.Now ; 
		/// <summary>
		/// CancelTime 冲单时间
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
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.ID;
	    }
	    #endregion
	}
}
