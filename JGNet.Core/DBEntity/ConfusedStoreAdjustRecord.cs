using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class ConfusedStoreAdjustRecord : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "ConfusedStoreAdjustRecord" ;
		public const string _OrderID = "OrderID" ;
		public const string _ShopID = "ShopID" ;
		public const string _OperatorUserID = "OperatorUserID" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _ColorName1 = "ColorName1" ;
		public const string _SizeName1 = "SizeName1" ;
		public const string _CountPre1 = "CountPre1" ;
		public const string _CountNow1 = "CountNow1" ;
		public const string _ColorName2 = "ColorName2" ;
		public const string _SizeName2 = "SizeName2" ;
		public const string _CountPre2 = "CountPre2" ;
		public const string _CountNow2 = "CountNow2" ;
		public const string _Remarks = "Remarks" ;
		public const string _CreateTime = "CreateTime" ;
	    #endregion
	 
	    #region Property
	
		#region OrderID
		private System.String m_OrderID = "" ; 
		/// <summary>
		/// OrderID 单据编号
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
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 报损店铺ID
		/// </summary>
		public System.String ShopID
		{
			get
			{
				return this.m_ShopID ;
			}
			set
			{
				this.m_ShopID = value ;
			}
		}
		#endregion
	
		#region OperatorUserID
		private System.String m_OperatorUserID = "" ; 
		/// <summary>
		/// OperatorUserID 报损用户ID
		/// </summary>
		public System.String OperatorUserID
		{
			get
			{
				return this.m_OperatorUserID ;
			}
			set
			{
				this.m_OperatorUserID = value ;
			}
		}
		#endregion
	
		#region CostumeID
		private System.String m_CostumeID = "" ; 
		/// <summary>
		/// CostumeID 服装ID
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
	
		#region ColorName1
		private System.String m_ColorName1 = "" ; 
		/// <summary>
		/// ColorName1 颜色A
		/// </summary>
		public System.String ColorName1
		{
			get
			{
				return this.m_ColorName1 ;
			}
			set
			{
				this.m_ColorName1 = value ;
			}
		}
		#endregion
	
		#region SizeName1
		private System.String m_SizeName1 = "" ; 
		/// <summary>
		/// SizeName1 尺码A
		/// </summary>
		public System.String SizeName1
		{
			get
			{
				return this.m_SizeName1 ;
			}
			set
			{
				this.m_SizeName1 = value ;
			}
		}
		#endregion
	
		#region CountPre1
		private System.Int32 m_CountPre1 = 0 ; 
		/// <summary>
		/// CountPre1 A调整前的数量
		/// </summary>
		public System.Int32 CountPre1
		{
			get
			{
				return this.m_CountPre1 ;
			}
			set
			{
				this.m_CountPre1 = value ;
			}
		}
		#endregion
	
		#region CountNow1
		private System.Int32 m_CountNow1 = 0 ; 
		/// <summary>
		/// CountNow1 A调整后的数量
		/// </summary>
		public System.Int32 CountNow1
		{
			get
			{
				return this.m_CountNow1 ;
			}
			set
			{
				this.m_CountNow1 = value ;
			}
		}
		#endregion
	
		#region ColorName2
		private System.String m_ColorName2 = "" ; 
		/// <summary>
		/// ColorName2 颜色B
		/// </summary>
		public System.String ColorName2
		{
			get
			{
				return this.m_ColorName2 ;
			}
			set
			{
				this.m_ColorName2 = value ;
			}
		}
		#endregion
	
		#region SizeName2
		private System.String m_SizeName2 = "" ; 
		/// <summary>
		/// SizeName2 尺码B
		/// </summary>
		public System.String SizeName2
		{
			get
			{
				return this.m_SizeName2 ;
			}
			set
			{
				this.m_SizeName2 = value ;
			}
		}
		#endregion
	
		#region CountPre2
		private System.Int32 m_CountPre2 = 0 ; 
		/// <summary>
		/// CountPre2 B调整前的数量
		/// </summary>
		public System.Int32 CountPre2
		{
			get
			{
				return this.m_CountPre2 ;
			}
			set
			{
				this.m_CountPre2 = value ;
			}
		}
		#endregion
	
		#region CountNow2
		private System.Int32 m_CountNow2 = 0 ; 
		/// <summary>
		/// CountNow2 B调整后的数量
		/// </summary>
		public System.Int32 CountNow2
		{
			get
			{
				return this.m_CountNow2 ;
			}
			set
			{
				this.m_CountNow2 = value ;
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
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.OrderID;
	    }
	    #endregion
	}
}
