using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class CommissionTemplate : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "CommissionTemplate" ;
		public const string _AutoID = "AutoID" ;
		public const string _Name = "Name" ;
		public const string _FirstRate = "FirstRate" ;
		public const string _Rate1 = "Rate1" ;
		public const string _Rate2 = "Rate2" ;
		public const string _Rate3 = "Rate3" ;
		public const string _Rate4 = "Rate4" ;
		public const string _Rate5 = "Rate5" ;
		public const string _Rate6 = "Rate6" ;
		public const string _Rate7 = "Rate7" ;
		public const string _Rate8 = "Rate8" ;
		public const string _Rate9 = "Rate9" ;
		public const string _Rate10 = "Rate10" ;
		public const string _IsDefault = "IsDefault" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _LastEditTime = "LastEditTime" ;
		public const string _LastOperatorUserID = "LastOperatorUserID" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自增主键
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
		/// Name 名称
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
	
		#region FirstRate
		private System.Decimal m_FirstRate = 0 ; 
		/// <summary>
		/// FirstRate 第一次抽成比例
		/// </summary>
		public System.Decimal FirstRate
		{
			get
			{
				return this.m_FirstRate ;
			}
			set
			{
				this.m_FirstRate = value ;
			}
		}
		#endregion
	
		#region Rate1
		private System.Decimal m_Rate1 = 0 ; 
		/// <summary>
		/// Rate1 一级抽成比例
		/// </summary>
		public System.Decimal Rate1
		{
			get
			{
				return this.m_Rate1 ;
			}
			set
			{
				this.m_Rate1 = value ;
			}
		}
		#endregion
	
		#region Rate2
		private System.Decimal m_Rate2 = 0 ; 
		/// <summary>
		/// Rate2 二级抽成比例
		/// </summary>
		public System.Decimal Rate2
		{
			get
			{
				return this.m_Rate2 ;
			}
			set
			{
				this.m_Rate2 = value ;
			}
		}
		#endregion
	
		#region Rate3
		private System.Decimal m_Rate3 = 0 ; 
		/// <summary>
		/// Rate3 三级抽成比例
		/// </summary>
		public System.Decimal Rate3
		{
			get
			{
				return this.m_Rate3 ;
			}
			set
			{
				this.m_Rate3 = value ;
			}
		}
		#endregion
	
		#region Rate4
		private System.Decimal m_Rate4 = 0 ; 
		/// <summary>
		/// Rate4 四级抽成比例
		/// </summary>
		public System.Decimal Rate4
		{
			get
			{
				return this.m_Rate4 ;
			}
			set
			{
				this.m_Rate4 = value ;
			}
		}
		#endregion
	
		#region Rate5
		private System.Decimal m_Rate5 = 0 ; 
		/// <summary>
		/// Rate5 五级抽成比例
		/// </summary>
		public System.Decimal Rate5
		{
			get
			{
				return this.m_Rate5 ;
			}
			set
			{
				this.m_Rate5 = value ;
			}
		}
		#endregion
	
		#region Rate6
		private System.Decimal m_Rate6 = 0 ; 
		/// <summary>
		/// Rate6 六级抽成比例
		/// </summary>
		public System.Decimal Rate6
		{
			get
			{
				return this.m_Rate6 ;
			}
			set
			{
				this.m_Rate6 = value ;
			}
		}
		#endregion
	
		#region Rate7
		private System.Decimal m_Rate7 = 0 ; 
		/// <summary>
		/// Rate7 七级抽成比例
		/// </summary>
		public System.Decimal Rate7
		{
			get
			{
				return this.m_Rate7 ;
			}
			set
			{
				this.m_Rate7 = value ;
			}
		}
		#endregion
	
		#region Rate8
		private System.Decimal m_Rate8 = 0 ; 
		/// <summary>
		/// Rate8 八级抽成比例
		/// </summary>
		public System.Decimal Rate8
		{
			get
			{
				return this.m_Rate8 ;
			}
			set
			{
				this.m_Rate8 = value ;
			}
		}
		#endregion
	
		#region Rate9
		private System.Decimal m_Rate9 = 0 ; 
		/// <summary>
		/// Rate9 九级抽成比例
		/// </summary>
		public System.Decimal Rate9
		{
			get
			{
				return this.m_Rate9 ;
			}
			set
			{
				this.m_Rate9 = value ;
			}
		}
		#endregion
	
		#region Rate10
		private System.Decimal m_Rate10 = 0 ; 
		/// <summary>
		/// Rate10 十级抽成比例
		/// </summary>
		public System.Decimal Rate10
		{
			get
			{
				return this.m_Rate10 ;
			}
			set
			{
				this.m_Rate10 = value ;
			}
		}
		#endregion
	
		#region IsDefault
		private System.Boolean m_IsDefault = false ; 
		/// <summary>
		/// IsDefault 是否是默认
		/// </summary>
		public System.Boolean IsDefault
		{
			get
			{
				return this.m_IsDefault ;
			}
			set
			{
				this.m_IsDefault = value ;
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
