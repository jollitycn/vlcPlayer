using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmCarriageCostTemplate : IEntity<System.Int32>
    {
	    #region Force Static Check
		public const string TableName = "EmCarriageCostTemplate" ;
		public const string _AutoID = "AutoID" ;
		public const string _Name = "Name" ;
		public const string _DefaultCarriageCost = "DefaultCarriageCost" ;
		public const string _GoodsAddress = "GoodsAddress" ;
		public const string _DeliveryTime = "DeliveryTime" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _LastEditTime = "LastEditTime" ;
		public const string _LastOperatorUserID = "LastOperatorUserID" ;
		public const string _IsValid = "IsValid" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自增主键（从1000开始）
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
	
		#region Name
		private System.String m_Name = "" ; 
		/// <summary>
		/// Name 模版名称
		/// </summary>
		public System.String Name
		{
			get
			{
				return this.m_Name ;
			}
			set
			{
				this.m_Name = value ;
			}
		}
		#endregion
	
		#region DefaultCarriageCost
		private System.Decimal m_DefaultCarriageCost = 0 ; 
		/// <summary>
		/// DefaultCarriageCost 默认运费
		/// </summary>
		public System.Decimal DefaultCarriageCost
		{
			get
			{
				return this.m_DefaultCarriageCost ;
			}
			set
			{
				this.m_DefaultCarriageCost = value ;
			}
		}
		#endregion
	
		#region GoodsAddress
		private System.String m_GoodsAddress = "" ; 
		/// <summary>
		/// GoodsAddress 宝贝地址。格式：中国，广东省，汕头市，龙湖区
		/// </summary>
		public System.String GoodsAddress
		{
			get
			{
				return this.m_GoodsAddress ;
			}
			set
			{
				this.m_GoodsAddress = value ;
			}
		}

		#endregion
	
		#region DeliveryTime
		private System.Int32 m_DeliveryTime = 0 ; 
		/// <summary>
		/// DeliveryTime 多少小时内发货。
		/// </summary>
		public System.Int32 DeliveryTime
		{
			get
			{
				return this.m_DeliveryTime ;
			}
			set
			{
				this.m_DeliveryTime = value ;
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
	
		#region LastEditTime
		private System.DateTime m_LastEditTime = DateTime.Now ; 
		/// <summary>
		/// LastEditTime 最后编辑时间
		/// </summary>
		public System.DateTime LastEditTime
		{
			get
			{
				return this.m_LastEditTime ;
			}
			set
			{
				this.m_LastEditTime = value ;
			}
		}
		#endregion
	
		#region LastOperatorUserID
		private System.String m_LastOperatorUserID = "" ; 
		/// <summary>
		/// LastOperatorUserID 最后编辑的用户ID
		/// </summary>
		public System.String LastOperatorUserID
		{
			get
			{
				return this.m_LastOperatorUserID ;
			}
			set
			{
				this.m_LastOperatorUserID = value ;
			}
		}
		#endregion
	
		#region IsValid
		private System.Boolean m_IsValid = false ; 
		/// <summary>
		/// IsValid 是否有效
		/// </summary>
		public System.Boolean IsValid
		{
			get
			{
				return this.m_IsValid ;
			}
			set
			{
				this.m_IsValid = value ;
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
