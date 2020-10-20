using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class Shop : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "Shop" ;
		public const string _ID = "ID" ;
		public const string _Password = "Password" ;
		public const string _Name = "Name" ;
		public const string _MinDiscount = "MinDiscount" ;
		public const string _MaxChangeRemoved = "MaxChangeRemoved" ;
		public const string _IsGeneralStore = "IsGeneralStore" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _AutoCode = "AutoCode" ;
		public const string _RechargeRuleID = "RechargeRuleID" ;
		public const string _ForeShiftStartTime = "ForeShiftStartTime" ;
		public const string _ForeShiftEndTime = "ForeShiftEndTime" ;
		public const string _NightShiftStartTime = "NightShiftStartTime" ;
		public const string _NightShiftEndTime = "NightShiftEndTime" ;
		public const string _PhoneNumber = "PhoneNumber" ;
		public const string _Address = "Address" ;
		public const string _ShowOnEMall = "ShowOnEMall" ;
		public const string _NameOnEMall = "NameOnEMall" ;
		public const string _Enabled = "Enabled" ;
		public const string _Remarks = "Remarks" ;
	    #endregion
	 
	    #region Property
	
		#region ID
		private System.String m_ID = "" ; 
		/// <summary>
		/// ID 店铺ID（主键）
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
	
		#region Password
		private System.String m_Password = "" ; 
		/// <summary>
		/// Password 密码
		/// </summary>
		public System.String Password
		{
			get
			{
				return this.m_Password ;
			}
			set
			{
				this.m_Password = value ;
			}
		}
		#endregion
	
		#region Name
		private System.String m_Name = "" ; 
		/// <summary>
		/// Name 店铺名称
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
	
		#region MinDiscount
		private System.Decimal m_MinDiscount = 0 ; 
		/// <summary>
		/// MinDiscount 最低折扣
		/// </summary>
		public System.Decimal MinDiscount
		{
			get
			{
				return this.m_MinDiscount ;
			}
			set
			{
				this.m_MinDiscount = value ;
			}
		}
		#endregion
	
		#region MaxChangeRemoved
		private System.Int32 m_MaxChangeRemoved = 0 ; 
		/// <summary>
		/// MaxChangeRemoved 抹零上限
		/// </summary>
		public System.Int32 MaxChangeRemoved
		{
			get
			{
				return this.m_MaxChangeRemoved ;
			}
			set
			{
				this.m_MaxChangeRemoved = value ;
			}
		}
		#endregion
	
		#region IsGeneralStore
		private System.Boolean m_IsGeneralStore = false ; 
		/// <summary>
		/// IsGeneralStore 是否为总仓。（有且只有一个店铺为总仓）
		/// </summary>
		public System.Boolean IsGeneralStore
		{
			get
			{
				return this.m_IsGeneralStore ;
			}
			set
			{
				this.m_IsGeneralStore = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 创建日期
		/// </summary>
		public System.DateTime CreateTime
		{
			get
			{
				return this.m_CreateTime ;
			}
			set
			{
				this.m_CreateTime = value ;
			}
		}
		#endregion
	
		#region AutoCode
		private System.Int32 m_AutoCode = 0 ; 
		/// <summary>
		/// AutoCode 自动编号，从1开始。
		/// </summary>
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
	
		#region RechargeRuleID
		private System.Int32 m_RechargeRuleID = 0 ; 
		/// <summary>
		/// RechargeRuleID 充值赠送规则ID。（0表示不使用规则）
		/// </summary>
		public System.Int32 RechargeRuleID
		{
			get
			{
				return this.m_RechargeRuleID ;
			}
			set
			{
				this.m_RechargeRuleID = value ;
			}
		}
		#endregion
	
		#region ForeShiftStartTime
		private System.String m_ForeShiftStartTime = "" ; 
		/// <summary>
		/// ForeShiftStartTime 早班上班时间。如08:00 （英文冒号隔开)
		/// </summary>
		public System.String ForeShiftStartTime
		{
			get
			{
				return this.m_ForeShiftStartTime ;
			}
			set
			{
				this.m_ForeShiftStartTime = value ;
			}
		}
		#endregion
	
		#region ForeShiftEndTime
		private System.String m_ForeShiftEndTime = "" ; 
		/// <summary>
		/// ForeShiftEndTime 早班下班时间。
		/// </summary>
		public System.String ForeShiftEndTime
		{
			get
			{
				return this.m_ForeShiftEndTime ;
			}
			set
			{
				this.m_ForeShiftEndTime = value ;
			}
		}
		#endregion
	
		#region NightShiftStartTime
		private System.String m_NightShiftStartTime = "" ; 
		/// <summary>
		/// NightShiftStartTime 晚班上班时间。
		/// </summary>
		public System.String NightShiftStartTime
		{
			get
			{
				return this.m_NightShiftStartTime ;
			}
			set
			{
				this.m_NightShiftStartTime = value ;
			}
		}
		#endregion
	
		#region NightShiftEndTime
		private System.String m_NightShiftEndTime = "" ; 
		/// <summary>
		/// NightShiftEndTime 晚班下班时间。
		/// </summary>
		public System.String NightShiftEndTime
		{
			get
			{
				return this.m_NightShiftEndTime ;
			}
			set
			{
				this.m_NightShiftEndTime = value ;
			}
		}
		#endregion
	
		#region PhoneNumber
		private System.String m_PhoneNumber = "" ; 
		/// <summary>
		/// PhoneNumber 联系电话
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
	
		#region Address
		private System.String m_Address = "" ; 
		/// <summary>
		/// Address 地址
		/// </summary>
		public System.String Address
		{
			get
			{
				return this.m_Address ;
			}
			set
			{
				this.m_Address = value ;
			}
		}
		#endregion
	
		#region ShowOnEMall
		private System.Boolean m_ShowOnEMall = false ; 
		/// <summary>
		/// ShowOnEMall 是否在线上商城的实体店列表中显示？
		/// </summary>
		public System.Boolean ShowOnEMall
		{
			get
			{
				return this.m_ShowOnEMall ;
			}
			set
			{
				this.m_ShowOnEMall = value ;
			}
		}
		#endregion
	
		#region NameOnEMall
		private System.String m_NameOnEMall = "" ; 
		/// <summary>
		/// NameOnEMall 在线上商城显示的实体店名称
		/// </summary>
		public System.String NameOnEMall
		{
			get
			{
				return this.m_NameOnEMall ;
			}
			set
			{
				this.m_NameOnEMall = value ;
			}
		}
		#endregion
	
		#region Enabled
		private System.Boolean m_Enabled = false ; 
		/// <summary>
		/// Enabled 启用？
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
	
		#region Remarks
		private System.String m_Remarks = "" ; 
		/// <summary>
		/// Remarks 备注
		/// </summary>
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
	       return this.ID;
	    }
	    #endregion
	}
}
