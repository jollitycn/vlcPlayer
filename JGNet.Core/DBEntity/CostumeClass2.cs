using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class CostumeClass2 : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "CostumeClass2" ;
		public const string _AutoID = "AutoID" ;
		public const string _ClassCode = "ClassCode" ;
		public const string _ClassName = "ClassName" ;
		public const string _ClassLevel = "ClassLevel" ;
		public const string _ParentAutoID = "ParentAutoID" ;
		public const string _OrderNo = "OrderNo" ;
		public const string _PhotoUrl = "PhotoUrl" ;
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
	
		#region ClassCode
		private System.String m_ClassCode = "" ; 
		/// <summary>
		/// ClassCode 类别编号，可用于条形码中
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
	
		#region ClassName
		private System.String m_ClassName = "" ; 
		/// <summary>
		/// ClassName 类别名称
		/// </summary>
		public System.String ClassName
		{
			get
			{
				return this.m_ClassName ;
			}
			set
			{
				this.m_ClassName = value ;
			}
		}
		#endregion
	
		#region ClassLevel
		private System.Int32 m_ClassLevel = 0 ; 
		/// <summary>
		/// ClassLevel 0：大类，1：小类，2：次小类
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
	
		#region ParentAutoID
		private System.Int32 m_ParentAutoID = 0 ; 
		/// <summary>
		/// ParentAutoID 上级类别自增ID
		/// </summary>
		public System.Int32 ParentAutoID
		{
			get
			{
				return this.m_ParentAutoID ;
			}
			set
			{
				this.m_ParentAutoID = value ;
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
	
		#region PhotoUrl
		private System.String m_PhotoUrl = "" ; 
		/// <summary>
		/// PhotoUrl 图片存储的链接地址
		/// </summary>
		public System.String PhotoUrl
		{
			get
			{
				return this.m_PhotoUrl ;
			}
			set
			{
				this.m_PhotoUrl = value ;
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
