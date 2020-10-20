using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class WxMemberAddress : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "WxMemberAddress" ;
		public const string _AutoID = "AutoID" ;
		public const string _PhoneNumber = "PhoneNumber" ;
		public const string _Name = "Name" ;
		public const string _Telphone1 = "Telphone1" ;
		public const string _Telphone2 = "Telphone2" ;
		public const string _CityZone = "CityZone" ;
		public const string _DetailAddress = "DetailAddress" ;
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
	
		#region PhoneNumber
		private System.String m_PhoneNumber = "" ; 
		/// <summary>
		/// PhoneNumber 会员卡号，手机号码
		/// </summary>
		public System.String PhoneNumber
		{
			get
			{
				return this.m_PhoneNumber ;
			}
			set
			{
				this.m_PhoneNumber = value ;
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
	
		#region Telphone1
		private System.String m_Telphone1 = "" ; 
		/// <summary>
		/// Telphone1 收货人电话1
		/// </summary>
		public System.String Telphone1
		{
			get
			{
				return this.m_Telphone1 ;
			}
			set
			{
				this.m_Telphone1 = value ;
			}
		}
		#endregion
	
		#region Telphone2
		private System.String m_Telphone2 = "" ; 
		/// <summary>
		/// Telphone2 收货人电话2
		/// </summary>
		public System.String Telphone2
		{
			get
			{
				return this.m_Telphone2 ;
			}
			set
			{
				this.m_Telphone2 = value ;
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
