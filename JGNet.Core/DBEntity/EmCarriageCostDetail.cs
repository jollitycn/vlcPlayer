using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmCarriageCostDetail : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "EmCarriageCostDetail" ;
		public const string _AutoID = "AutoID" ;
		public const string _TemplateID = "TemplateID" ;
		public const string _Province = "Province" ;
		public const string _City = "City" ;
		public const string _CarriageCost = "CarriageCost" ;
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
	
		#region TemplateID
		private System.Int32 m_TemplateID = 0 ; 
		/// <summary>
		/// TemplateID 运费模版ID
		/// </summary>
		public System.Int32 TemplateID
		{
			get
			{
				return this.m_TemplateID ;
			}
			set
			{
				this.m_TemplateID = value ;
			}
		}
		#endregion
	
		#region Province
		private System.String m_Province = "" ; 
		/// <summary>
		/// Province 省
		/// </summary>
		public System.String Province
		{
			get
			{
				return this.m_Province ;
			}
			set
			{
				this.m_Province = value ;
			}
		}
		#endregion
	
		#region City
		private System.String m_City = "" ; 
		/// <summary>
		/// City 市
		/// </summary>
		public System.String City
		{
			get
			{
				return this.m_City ;
			}
			set
			{
				this.m_City = value ;
			}
		}
		#endregion
	
		#region CarriageCost
		private System.Decimal m_CarriageCost = 0 ; 
		/// <summary>
		/// CarriageCost 运费
		/// </summary>
		public System.Decimal CarriageCost
		{
			get
			{
				return this.m_CarriageCost ;
			}
			set
			{
				this.m_CarriageCost = value ;
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
