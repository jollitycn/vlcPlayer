using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PrintTemplate : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "PrintTemplate" ;
		public const string _AutoID = "AutoID" ;
		public const string _Type = "Type" ;
		public const string _PrintCount = "PrintCount" ;
		public const string _Name = "Name" ;
		public const string _SystemVariable = "SystemVariable" ;
		public const string _ColumnName = "ColumnName" ;
		public const string _AdditionalText = "AdditionalText" ;
		public const string _Rows = "Rows" ;
		public const string _IsPrintQRCode = "IsPrintQRCode" ;
	    #endregion
	 
	    #region Property
	
		#region AutoID
		private System.Int32 m_AutoID = 0 ; 
		/// <summary>
		/// AutoID 自增ID(主键)，从1开始
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
	
		#region Type
		private System.Byte m_Type = 0 ; 
		/// <summary>
		/// Type 类型（0：销售/退货，1：采购进货…）
		/// </summary>
		public System.Byte Type
		{
			get
			{
				return this.m_Type ;
			}
			set
			{
				this.m_Type = value ;
			}
		}
		#endregion
	
		#region PrintCount
		private System.Byte m_PrintCount = 0 ; 
		/// <summary>
		/// PrintCount 打印份数
		/// </summary>
		public System.Byte PrintCount
		{
			get
			{
				return this.m_PrintCount ;
			}
			set
			{
				this.m_PrintCount = value ;
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
	
		#region SystemVariable
		private System.String m_SystemVariable = "" ; 
		/// <summary>
		/// SystemVariable 系统变量，由英文逗号连接。
		/// </summary>
		public System.String SystemVariable
		{
			get
			{
				return this.m_SystemVariable ;
			}
			set
			{
				this.m_SystemVariable = value ;
			}
		}
		#endregion
	
		#region ColumnName
		private System.String m_ColumnName = "" ; 
		/// <summary>
		/// ColumnName 表格列名，（列名1#百分比1，列名2#百分比2…）
		/// </summary>
		public System.String ColumnName
		{
			get
			{
				return this.m_ColumnName ;
			}
			set
			{
				this.m_ColumnName = value ;
			}
		}
		#endregion
	
		#region AdditionalText
		private System.String m_AdditionalText = "" ; 
		/// <summary>
		/// AdditionalText 结尾附加文字
		/// </summary>
		public System.String AdditionalText
		{
			get
			{
				return this.m_AdditionalText ;
			}
			set
			{
				this.m_AdditionalText = value ;
			}
		}
		#endregion
	
		#region Rows
		private System.Byte m_Rows = 0 ; 
		/// <summary>
		/// Rows 一页行数
		/// </summary>
		public System.Byte Rows
		{
			get
			{
				return this.m_Rows ;
			}
			set
			{
				this.m_Rows = value ;
			}
		}
		#endregion
	
		#region IsPrintQRCode
		private System.Boolean m_IsPrintQRCode = false ; 
		/// <summary>
		/// IsPrintQRCode 是否打印商城二维码
		/// </summary>
		public System.Boolean IsPrintQRCode
		{
			get
			{
				return this.m_IsPrintQRCode ;
			}
			set
			{
				this.m_IsPrintQRCode = value ;
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
