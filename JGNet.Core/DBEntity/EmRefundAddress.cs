using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmRefundAddress : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "EmRefundAddress" ;
		public const string _AutoID = "AutoID" ;
		public const string _Name = "Name" ;
		public const string _Telphone = "Telphone" ;
		public const string _CityZone = "CityZone" ;
		public const string _DetailAddress = "DetailAddress" ;
		public const string _IsDefault = "IsDefault" ;
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
		/// Name 收货人姓名
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
	
		#region Telphone
		private System.String m_Telphone = "" ; 
		/// <summary>
		/// Telphone 收货人电话
		/// </summary>
		public System.String Telphone
		{
			get
			{
				return this.m_Telphone ;
			}
			set
			{
				this.m_Telphone = value ;
			}
		}
		#endregion
	
		#region CityZone
		private System.String m_CityZone = "" ; 
		/// <summary>
		/// CityZone 所在城市，格式：xx省xx市xx区
		/// </summary>
		public System.String CityZone
		{
			get
			{
				return this.m_CityZone ;
			}
			set
			{
				this.m_CityZone = value ;
			}
		}
		#endregion
	
		#region DetailAddress
		private System.String m_DetailAddress = "" ; 
		/// <summary>
		/// DetailAddress 收货详细地址：xx街道xx小区xx栋xx号
		/// </summary>
		public System.String DetailAddress
		{
			get
			{
				return this.m_DetailAddress ;
			}
			set
			{
				this.m_DetailAddress = value ;
			}
		}
		#endregion
	
		#region IsDefault
		private System.Boolean m_IsDefault = false ; 
		/// <summary>
		/// IsDefault 是否是默认地址
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
