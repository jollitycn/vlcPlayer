using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class RechargeDonateRule : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "RechargeDonateRule" ;
		public const string _AutoID = "AutoID" ;
		public const string _Name = "Name" ;
		public const string _RuleExpression = "RuleExpression" ;
		public const string _CreateTime = "CreateTime" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 规则编号（自增）
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
		/// Name 规则名称
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
	
		#region RuleExpression
		private System.String m_RuleExpression = "" ; 
		/// <summary>
		/// RuleExpression 充值规则表达式
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
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 规则创建时间
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
