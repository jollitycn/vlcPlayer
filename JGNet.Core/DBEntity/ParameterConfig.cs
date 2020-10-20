using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class ParameterConfig : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "ParameterConfig" ;
		public const string _ParaKey = "ParaKey" ;
		public const string _ParaValue = "ParaValue" ;
		public const string _Remarks = "Remarks" ;
	    #endregion
	 
	    #region Property
	
		#region ParaKey
		private System.String m_ParaKey = "" ; 
		/// <summary>
		/// ParaKey 配置键
		/// </summary>
		public System.String ParaKey
		{
			get
			{
				return this.m_ParaKey ;
			}
			set
			{
				this.m_ParaKey = value ;
			}
		}
		#endregion
	
		#region ParaValue
		private System.String m_ParaValue = "" ; 
		/// <summary>
		/// ParaValue 配置值
		/// </summary>
		public System.String ParaValue
		{
			get
			{
				return this.m_ParaValue ;
			}
			set
			{
				this.m_ParaValue = value ;
			}
		}
		#endregion
	
		#region Remarks
		private System.String m_Remarks = "" ; 
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
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.ParaKey;
	    }
	    #endregion
	}
}
