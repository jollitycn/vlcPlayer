using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class InboundOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "InboundOrder" ;
		public const string _ID = "ID" ;
		public const string _SourceOrderID = "SourceOrderID" ;
		public const string _OperatorUserID = "OperatorUserID" ;
		public const string _ShopID = "ShopID" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _TotalPrice = "TotalPrice" ;
		public const string _TotalCost = "TotalCost" ;
		public const string _Remarks = "Remarks" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EntryTime = "EntryTime" ;
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
	
		#region SourceOrderID
		private System.String m_SourceOrderID = "" ; 
		/// <summary>
		/// SourceOrderID 来源单据编号（补货单 或 调拨单）
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
	
		#region OperatorUserID
		private System.String m_OperatorUserID = "" ; 
		/// <summary>
		/// OperatorUserID 清点入库的用户ID
		/// </summary>
		public System.String OperatorUserID
		{
			get
			{
				return this.m_OperatorUserID ;
			}
			set
			{
				this.m_OperatorUserID = value ;
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
	
		#region TotalCount
		private System.Int32 m_TotalCount = 0 ; 
		/// <summary>
		/// TotalCount 入库总件数
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
		/// TotalPrice 入库货品吊牌额
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
		/// TotalCost 入库货品进货成本
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
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.ID;
	    }
	    #endregion
	}
}
