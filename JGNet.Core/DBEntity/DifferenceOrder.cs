using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class DifferenceOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "DifferenceOrder" ;
		public const string _ID = "ID" ;
		public const string _InboundOrderID = "InboundOrderID" ;
		public const string _OutboundOrderID = "OutboundOrderID" ;
		public const string _SourceOrderID = "SourceOrderID" ;
		public const string _TotalDiffCount = "TotalDiffCount" ;
		public const string _SumDiffCount = "SumDiffCount" ;
		public const string _InboundShopID = "InboundShopID" ;
		public const string _OutboundShopID = "OutboundShopID" ;
		public const string _Confirmed = "Confirmed" ;
		public const string _ConfirmUserID = "ConfirmUserID" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _ConfirmTime = "ConfirmTime" ;
		public const string _ConfirmInSameDay = "ConfirmInSameDay" ;
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
	
		#region SourceOrderID
		private System.String m_SourceOrderID = "" ; 
		/// <summary>
		/// SourceOrderID 来源单据编号（补货申请单 或 调拨单）
		/// </summary>
		public System.String SourceOrderID
		{
			get
			{
				return this.m_SourceOrderID ;
			}
			set
			{
				this.m_SourceOrderID = value ;
			}
		}
		#endregion
	
		#region TotalDiffCount
		private System.Int32 m_TotalDiffCount = 0 ; 
		/// <summary>
		/// TotalDiffCount 总差异数（绝对值相加）
		/// </summary>
		public System.Int32 TotalDiffCount
		{
			get
			{
				return this.m_TotalDiffCount ;
			}
			set
			{
				this.m_TotalDiffCount = value ;
			}
		}
		#endregion
	
		#region SumDiffCount
		private System.Int32 m_SumDiffCount = 0 ; 
		/// <summary>
		/// SumDiffCount 总差异数（正负抵消）
		/// </summary>
		public System.Int32 SumDiffCount
		{
			get
			{
				return this.m_SumDiffCount ;
			}
			set
			{
				this.m_SumDiffCount = value ;
			}
		}
		#endregion
	
		#region InboundShopID
		private System.String m_InboundShopID = "" ; 
		/// <summary>
		/// InboundShopID 入库店铺ID
		/// </summary>
		public System.String InboundShopID
		{
			get
			{
				return this.m_InboundShopID ;
			}
			set
			{
				this.m_InboundShopID = value ;
			}
		}
		#endregion
	
		#region OutboundShopID
		private System.String m_OutboundShopID = "" ; 
		/// <summary>
		/// OutboundShopID 出库店铺ID
		/// </summary>
		public System.String OutboundShopID
		{
			get
			{
				return this.m_OutboundShopID ;
			}
			set
			{
				this.m_OutboundShopID = value ;
			}
		}
		#endregion
	
		#region Confirmed
		private System.Boolean m_Confirmed = false ; 
		/// <summary>
		/// Confirmed 发货方/盘点店铺 是否已经确认？
		/// </summary>
		public System.Boolean Confirmed
		{
			get
			{
				return this.m_Confirmed ;
			}
			set
			{
				this.m_Confirmed = value ;
			}
		}
		#endregion
	
		#region ConfirmUserID
		private System.String m_ConfirmUserID = "" ; 
		/// <summary>
		/// ConfirmUserID 确认者的ID
		/// </summary>
		public System.String ConfirmUserID
		{
			get
			{
				return this.m_ConfirmUserID ;
			}
			set
			{
				this.m_ConfirmUserID = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 开单日期
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
	
		#region ConfirmTime
		private System.DateTime m_ConfirmTime = DateTime.Now ; 
		/// <summary>
		/// ConfirmTime 确认日期
		/// </summary>
		public System.DateTime ConfirmTime
		{
			get
			{
				return this.m_ConfirmTime ;
			}
			set
			{
				this.m_ConfirmTime = value ;
			}
		}
		#endregion
	
		#region ConfirmInSameDay
		private System.Boolean m_ConfirmInSameDay = false ; 
		/// <summary>
		/// ConfirmInSameDay 是否在出库同一天确认？
		/// </summary>
		public System.Boolean ConfirmInSameDay
		{
			get
			{
				return this.m_ConfirmInSameDay ;
			}
			set
			{
				this.m_ConfirmInSameDay = value ;
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
