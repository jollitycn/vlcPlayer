using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class PaymentRecord : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "PaymentRecord" ;
		public const string _AutoID = "AutoID" ;
		public const string _BusinessAccountID = "BusinessAccountID" ;
		public const string _PaymentType = "PaymentType" ;
		public const string _Money = "Money" ;
		public const string _ExpiredDateOld = "ExpiredDateOld" ;
		public const string _ExpiredDateNew = "ExpiredDateNew" ;
		public const string _PromotionText = "PromotionText" ;
		public const string _CreateTime = "CreateTime" ;
		public const string _Remarks = "Remarks" ;
		public const string _OrderID = "OrderID" ;
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
	
		#region BusinessAccountID
		private System.String m_BusinessAccountID = "" ; 
		/// <summary>
		/// BusinessAccountID 商户帐号
		/// </summary>
		public System.String BusinessAccountID
		{
			get
			{
				return this.m_BusinessAccountID ;
			}
			set
			{
				this.m_BusinessAccountID = value ;
			}
		}
		#endregion
	
		#region PaymentType
		private System.Byte m_PaymentType = 0 ; 
		/// <summary>
		/// PaymentType 缴费类型：开户、续期、升级店铺数量
		/// </summary>
		public System.Byte PaymentType
		{
			get
			{
				return this.m_PaymentType ;
			}
			set
			{
				this.m_PaymentType = value ;
			}
		}
		#endregion
	
		#region Money
		private System.Decimal m_Money = 0 ; 
		/// <summary>
		/// Money 缴费金额
		/// </summary>
		public System.Decimal Money
		{
			get
			{
				return this.m_Money ;
			}
			set
			{
				this.m_Money = value ;
			}
		}
		#endregion
	
		#region ExpiredDateOld
		private System.DateTime m_ExpiredDateOld = DateTime.Now ; 
		/// <summary>
		/// ExpiredDateOld 旧过期日期
		/// </summary>
		public System.DateTime ExpiredDateOld
		{
			get
			{
				return this.m_ExpiredDateOld ;
			}
			set
			{
				this.m_ExpiredDateOld = value ;
			}
		}
		#endregion
	
		#region ExpiredDateNew
		private System.DateTime m_ExpiredDateNew = DateTime.Now ; 
		/// <summary>
		/// ExpiredDateNew 新过期日期
		/// </summary>
		public System.DateTime ExpiredDateNew
		{
			get
			{
				return this.m_ExpiredDateNew ;
			}
			set
			{
				this.m_ExpiredDateNew = value ;
			}
		}
		#endregion
	
		#region PromotionText
		private System.String m_PromotionText = "" ; 
		/// <summary>
		/// PromotionText 采用的促销活动说明
		/// </summary>
		public System.String PromotionText
		{
			get
			{
				return this.m_PromotionText ;
			}
			set
			{
				this.m_PromotionText = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 时间
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
	
		#region OrderID
		private System.String m_OrderID = "" ; 
		/// <summary>
		/// OrderID 自助续费id
		/// </summary>
		public System.String OrderID
		{
			get
			{
				return this.m_OrderID ;
			}
			set
			{
				this.m_OrderID = value ;
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
