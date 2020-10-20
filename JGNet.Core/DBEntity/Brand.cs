using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class Brand : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "Brand" ;
		public const string _AutoID = "AutoID" ;
		public const string _Name = "Name" ;
		public const string _FirstCharSpell = "FirstCharSpell" ;
		public const string _SupplierID = "SupplierID" ;
		public const string _OrderNo = "OrderNo" ;
		public const string _IsDisable = "IsDisable" ;
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
	
		#region Name
		private System.String m_Name = "" ; 
		/// <summary>
		/// Name 品牌名称
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
	
		#region FirstCharSpell
		private System.String m_FirstCharSpell = "" ; 
		/// <summary>
		/// FirstCharSpell 首拼字母缩写（全小写）
		/// </summary>
		public System.String FirstCharSpell
		{
			get
			{
				return this.m_FirstCharSpell ;
			}
			set
			{
				this.m_FirstCharSpell = value ;
			}
		}
		#endregion
	
		#region SupplierID
		private System.String m_SupplierID = "" ; 
		/// <summary>
		/// SupplierID 供应商编号
		/// </summary>
		public System.String SupplierID
		{
			get
			{
				return this.m_SupplierID ;
			}
			set
			{
				this.m_SupplierID = value ;
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
	
		#region IsDisable
		private System.Boolean m_IsDisable = false ; 
		/// <summary>
		/// IsDisable 是否禁用
		/// </summary>
		public System.Boolean IsDisable
		{
			get
			{
				return this.m_IsDisable ;
			}
			set
			{
				this.m_IsDisable = value ;
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
