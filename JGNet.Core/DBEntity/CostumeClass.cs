using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class CostumeClass : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "CostumeClass" ;
		public const string _BigClass = "BigClass" ;
		public const string _SmallClassStr = "SmallClassStr" ;
		public const string _OrderNo = "OrderNo" ;
		public const string _ClassLevel = "ClassLevel" ;
		public const string _ClassCode = "ClassCode" ;
	    #endregion
	 
	    #region Property
	
		#region BigClass
		private System.String m_BigClass = "" ; 
		/// <summary>
		/// BigClass 大类名称（主键）（ClassLevel：次小类时：大类-小类）
		/// </summary>
		public System.String BigClass
		{
			get
			{
				return this.m_BigClass ;
			}
			set
			{
				this.m_BigClass = value ;
			}
		}
		#endregion
	
		#region SmallClassStr
		private System.String m_SmallClassStr = "" ; 
		/// <summary>
		/// SmallClassStr 包含的小类，用英文逗号分隔
		/// </summary>
		public System.String SmallClassStr
		{
			get
			{
				return this.m_SmallClassStr ;
			}
			set
			{
				this.m_SmallClassStr = value ;
			}
		}
		#endregion
	
		#region OrderNo
		private System.Int32 m_OrderNo = 0 ; 
		/// <summary>
		/// OrderNo 用于排序的序号。
		/// </summary>
		public System.Int32 OrderNo
		{
			get
			{
				return this.m_OrderNo ;
			}
			set
			{
				this.m_OrderNo = value ;
			}
		}
		#endregion
	
		#region ClassLevel
		private System.Int32 m_ClassLevel = 0 ; 
		/// <summary>
		/// ClassLevel 0：大类，小类，1：大类-小类，次小类
		/// </summary>
		public System.Int32 ClassLevel
		{
			get
			{
				return this.m_ClassLevel ;
			}
			set
			{
				this.m_ClassLevel = value ;
			}
		}
		#endregion
	
		#region ClassCode
		private System.String m_ClassCode = "" ; 
		/// <summary>
		/// ClassCode 编号
		/// </summary>
		public System.String ClassCode
		{
			get
			{
				return this.m_ClassCode ;
			}
			set
			{
				this.m_ClassCode = value ;
			}
		}
		#endregion
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.BigClass;
	    }
	    #endregion
	}
}
