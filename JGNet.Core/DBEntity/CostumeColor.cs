using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class CostumeColor : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "CostumeColor" ;
		public const string _ID = "ID" ;
		public const string _Name = "Name" ;
		public const string _FirstCharSpell = "FirstCharSpell" ;
		public const string _AutoCode = "AutoCode" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 色号(主键)
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
		/// Name 颜色名称
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
	
		#region AutoCode
		private System.Int32 m_AutoCode = 0 ; 
		public System.Int32 AutoCode
		{
			get
			{
				return this.m_AutoCode ;
			}
			set
			{
				this.m_AutoCode = value ;
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
