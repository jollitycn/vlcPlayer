using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class SalesPromotion : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "SalesPromotion" ;
		public const string _ID = "ID" ;
		public const string _Name = "Name" ;
		public const string _PromotionType = "PromotionType" ;
		public const string _RuleExpression = "RuleExpression" ;
		public const string _CostumeIDStr = "CostumeIDStr" ;
		public const string _ContainsSpecify = "ContainsSpecify" ;
		public const string _ShopIDStr = "ShopIDStr" ;
		public const string _StartDate = "StartDate" ;
		public const string _EndDate = "EndDate" ;
		public const string _Enabled = "Enabled" ;
		public const string _Remarks = "Remarks" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _IsValid = "IsValid" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 编号
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
	
		#region Name
		private System.String m_Name = "" ; 
		/// <summary>
		/// Name 促销活动名称
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
	
		#region PromotionType
		private System.Byte m_PromotionType = 0 ; 
		/// <summary>
		/// PromotionType 促销类型。0：满减；1：多件多折
		/// </summary>
		public System.Byte PromotionType
		{
			get
			{
				return this.m_PromotionType ;
			}
			set
			{
				this.m_PromotionType = value ;
			}
		}
		#endregion
	
		#region RuleExpression
		private System.String m_RuleExpression = "" ; 
		/// <summary>
		/// RuleExpression 活动规则表达式
		/// </summary>
		public System.String RuleExpression
		{
			get
			{
				return this.m_RuleExpression ;
			}
			set
			{
				this.m_RuleExpression = value ;
			}
		}
		#endregion
	
		#region CostumeIDStr
		private System.String m_CostumeIDStr = "" ; 
		/// <summary>
		/// CostumeIDStr 款号字符串，由英文逗号连接。
		/// </summary>
		public System.String CostumeIDStr
		{
			get
			{
				return this.m_CostumeIDStr ;
			}
			set
			{
				this.m_CostumeIDStr = value ;
			}
		}
		#endregion
	
		#region ContainsSpecify
		private System.Boolean m_ContainsSpecify = false ; 
		/// <summary>
		/// ContainsSpecify Bool值表示CostumeIDStr指定的衣服是否参加活动
		/// </summary>
		public System.Boolean ContainsSpecify
		{
			get
			{
				return this.m_ContainsSpecify ;
			}
			set
			{
				this.m_ContainsSpecify = value ;
			}
		}
		#endregion
	
		#region ShopIDStr
		private System.String m_ShopIDStr = "" ; 
		/// <summary>
		/// ShopIDStr 参与活动的店铺ID。使用英文逗号分隔。
		/// </summary>
		public System.String ShopIDStr
		{
			get
			{
				return this.m_ShopIDStr ;
			}
			set
			{
				this.m_ShopIDStr = value ;
			}
		}
		#endregion
	
		#region StartDate
		private System.DateTime m_StartDate = DateTime.Now ; 
		/// <summary>
		/// StartDate 活动开始日期
		/// </summary>
		public System.DateTime StartDate
		{
			get
			{
				return this.m_StartDate ;
			}
			set
			{
				this.m_StartDate = value ;
			}
		}
		#endregion
	
		#region EndDate
		private System.DateTime m_EndDate = DateTime.Now ; 
		/// <summary>
		/// EndDate 活动结束日期
		/// </summary>
		public System.DateTime EndDate
		{
			get
			{
				return this.m_EndDate ;
			}
			set
			{
				this.m_EndDate = value ;
			}
		}
		#endregion
	
		#region Enabled
		private System.Boolean m_Enabled = false ; 
		/// <summary>
		/// Enabled 是否启用
		/// </summary>
		public System.Boolean Enabled
		{
			get
			{
				return this.m_Enabled ;
			}
			set
			{
				this.m_Enabled = value ;
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
	    public System.String GetPKeyValue()
	    {
	       return this.ID;
	    }
	    #endregion
	}
}
