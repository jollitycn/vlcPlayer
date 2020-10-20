using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class EmShoppingCart : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "EmShoppingCart" ;
		public const string _AutoID = "AutoID" ;
		public const string _PhoneNumber = "PhoneNumber" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _ColorName = "ColorName" ;
		public const string _SizeName = "SizeName" ;
		public const string _BuyCount = "BuyCount" ;
		public const string _CreateTime = "CreateTime" ;
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
	
		#region CostumeID
		private System.String m_CostumeID = "" ; 
		/// <summary>
		/// CostumeID 商品的款号
		/// </summary>
		public System.String CostumeID
		{
			get
			{
				return this.m_CostumeID ;
			}
			set
			{
				this.m_CostumeID = value ;
			}
		}
		#endregion
	
		#region ColorName
		private System.String m_ColorName = "" ; 
		/// <summary>
		/// ColorName 颜色
		/// </summary>
		public System.String ColorName
		{
			get
			{
				return this.m_ColorName ;
			}
			set
			{
				this.m_ColorName = value ;
			}
		}
		#endregion
	
		#region SizeName
		private System.String m_SizeName = "" ; 
		/// <summary>
		/// SizeName 尺码
		/// </summary>
		public System.String SizeName
		{
			get
			{
				return this.m_SizeName ;
			}
			set
			{
				this.m_SizeName = value ;
			}
		}
		#endregion
	
		#region BuyCount
		private System.Int32 m_BuyCount = 0 ; 
		/// <summary>
		/// BuyCount 件数
		/// </summary>
		public System.Int32 BuyCount
		{
			get
			{
				return this.m_BuyCount ;
			}
			set
			{
				this.m_BuyCount = value ;
			}
		}
		#endregion
	
		#region CreateTime
		private System.DateTime m_CreateTime = DateTime.Now ; 
		/// <summary>
		/// CreateTime 加入购物车时间
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
	    #endregion
	 
	    #region IEntity Members
	    public System.Int32 GetPKeyValue()
	    {
	       return this.AutoID;
	    }
	    #endregion
	}
}
