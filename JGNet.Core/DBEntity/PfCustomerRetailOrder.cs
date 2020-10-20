using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PfCustomerRetailOrder : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "PfCustomerRetailOrder" ;
		public const string _ID = "ID" ;
		public const string _PfCustomerID = "PfCustomerID" ;
		public const string _TotalCount = "TotalCount" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _EntryUserID = "EntryUserID" ;
		public const string _EntryTime = "EntryTime" ;
		public const string _Comment = "Comment" ;
		public const string _PfOrderID = "PfOrderID" ;
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
	
		#region PfCustomerID
		private System.String m_PfCustomerID = "" ; 
		/// <summary>
		/// PfCustomerID 批发客户id
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
	
		#region TotalCount
		private System.Int32 m_TotalCount = 0 ; 
		/// <summary>
		/// TotalCount 商品总件数
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
	
		#region EntryUserID
		private System.String m_EntryUserID = "" ; 
		/// <summary>
		/// EntryUserID 制单人ID
		/// </summary>
		public System.String EntryUserID
		{
			get
			{
				return this.m_EntryUserID ;
			}
			set
			{
				this.m_EntryUserID = value ;
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
	
		#region Comment
		private System.String m_Comment = "" ; 
		/// <summary>
		/// Comment 备注
		/// </summary>
		public System.String Comment
		{
			get
			{
				return this.m_Comment ;
			}
			set
			{
				this.m_Comment = value ;
			}
		}
		#endregion
	
		#region PfOrderID
		private System.String m_PfOrderID = "" ; 
		/// <summary>
		/// PfOrderID 批发单据编号（买断客户批发发货时自动生成销售单）
		/// </summary>
		public System.String PfOrderID
		{
			get
			{
				return this.m_PfOrderID ;
			}
			set
			{
				this.m_PfOrderID = value ;
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
