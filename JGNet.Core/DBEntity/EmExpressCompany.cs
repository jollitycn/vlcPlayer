using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmExpressCompany : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "EmExpressCompany" ;
		public const string _ExpressCompanyID = "ExpressCompanyID" ;
		public const string _ExpressCompanyName = "ExpressCompanyName" ;
		public const string _Comment = "Comment" ;
		public const string _Enabled = "Enabled" ;
	    #endregion
	 
	    #region Property
	
		#region ExpressCompanyID
		private System.String m_ExpressCompanyID = "" ; 
		/// <summary>
		/// ExpressCompanyID 快递公司编码
		/// </summary>
		public System.String ExpressCompanyID
		{
			get
			{
				return this.m_ExpressCompanyID ;
			}
			set
			{
				this.m_ExpressCompanyID = value ;
			}
		}
		#endregion
	
		#region ExpressCompanyName
		private System.String m_ExpressCompanyName = "" ; 
		/// <summary>
		/// ExpressCompanyName 快递公司名称
		/// </summary>
		public System.String ExpressCompanyName
		{
			get
			{
				return this.m_ExpressCompanyName ;
			}
			set
			{
				this.m_ExpressCompanyName = value ;
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
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.ExpressCompanyID;
	    }
	    #endregion
	}
}
