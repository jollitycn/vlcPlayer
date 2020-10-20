using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class BarCode : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "BarCode" ;
		public const string _BarCodeValue = "BarCodeValue" ;
		public const string _CostumeID = "CostumeID" ;
		public const string _ColorName = "ColorName" ;
		public const string _SizeName = "SizeName" ;
	    #endregion
	 
	    #region Property
	
		#region BarCodeValue
		private System.String m_BarCodeValue = "" ; 
		/// <summary>
		/// BarCodeValue 条形码的值（主键）
		/// </summary>
		public System.String BarCodeValue
		{
			get
			{
				return this.m_BarCodeValue ;
			}
			set
			{
				this.m_BarCodeValue = value ;
			}
		}
		#endregion
	
		#region CostumeID
		private System.String m_CostumeID = "" ; 
		/// <summary>
		/// CostumeID 款号
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
		/// ColorName 颜色（如果不填，则为空字串）
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
		/// SizeName 尺码，S/M/L/XL。（如果不填，则为空字串）
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
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.BarCodeValue;
	    }
	    #endregion
	}
}
