using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class MonthTask : IEntity<System.Int32>
	{
	    #region Force Static Check
		public const string TableName = "MonthTask" ;
		public const string _AutoID = "AutoID" ;
		public const string _ShopID = "ShopID" ;
		public const string _GuideID = "GuideID" ;
		public const string _Month = "Month" ;
		public const string _MoneyOfSale = "MoneyOfSale" ;
		public const string _D1OfSale = "D1OfSale" ;
		public const string _D2OfSale = "D2OfSale" ;
		public const string _D3OfSale = "D3OfSale" ;
		public const string _D4OfSale = "D4OfSale" ;
		public const string _D5OfSale = "D5OfSale" ;
		public const string _D6OfSale = "D6OfSale" ;
		public const string _D7OfSale = "D7OfSale" ;
		public const string _D8OfSale = "D8OfSale" ;
		public const string _D9OfSale = "D9OfSale" ;
		public const string _D10OfSale = "D10OfSale" ;
		public const string _D11OfSale = "D11OfSale" ;
		public const string _D12OfSale = "D12OfSale" ;
		public const string _D13OfSale = "D13OfSale" ;
		public const string _D14OfSale = "D14OfSale" ;
		public const string _D15OfSale = "D15OfSale" ;
		public const string _D16OfSale = "D16OfSale" ;
		public const string _D17OfSale = "D17OfSale" ;
		public const string _D18OfSale = "D18OfSale" ;
		public const string _D19OfSale = "D19OfSale" ;
		public const string _D20OfSale = "D20OfSale" ;
		public const string _D21OfSale = "D21OfSale" ;
		public const string _D22OfSale = "D22OfSale" ;
		public const string _D23OfSale = "D23OfSale" ;
		public const string _D24OfSale = "D24OfSale" ;
		public const string _D25OfSale = "D25OfSale" ;
		public const string _D26OfSale = "D26OfSale" ;
		public const string _D27OfSale = "D27OfSale" ;
		public const string _D28OfSale = "D28OfSale" ;
		public const string _D29OfSale = "D29OfSale" ;
		public const string _D30OfSale = "D30OfSale" ;
		public const string _D31OfSale = "D31OfSale" ;
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
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 所属店铺
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
	
		#region GuideID
		private System.String m_GuideID = "" ; 
		/// <summary>
		/// GuideID 导购员编号
		/// </summary>
		public System.String GuideID
		{
			get
			{
				return this.m_GuideID ;
			}
			set
			{
				this.m_GuideID = value ;
			}
		}
		#endregion
	
		#region Month
		private System.Int32 m_Month = 0 ; 
		/// <summary>
		/// Month 哪一月的任务，固定6位数字，如201803
		/// </summary>
		public System.Int32 Month
		{
			get
			{
				return this.m_Month ;
			}
			set
			{
				this.m_Month = value ;
			}
		}
		#endregion
	
		#region MoneyOfSale
		private System.Int32 m_MoneyOfSale = 0 ; 
		/// <summary>
		/// MoneyOfSale 目标销售额
		/// </summary>
		public System.Int32 MoneyOfSale
		{
			get
			{
				return this.m_MoneyOfSale ;
			}
			set
			{
				this.m_MoneyOfSale = value ;
			}
		}
		#endregion
	
		#region D1OfSale
		private System.Int32 m_D1OfSale = 0 ; 
		/// <summary>
		/// D1OfSale 本月1号的日目标销售额
		/// </summary>
		public System.Int32 D1OfSale
		{
			get
			{
				return this.m_D1OfSale ;
			}
			set
			{
				this.m_D1OfSale = value ;
			}
		}
		#endregion
	
		#region D2OfSale
		private System.Int32 m_D2OfSale = 0 ; 
		public System.Int32 D2OfSale
		{
			get
			{
				return this.m_D2OfSale ;
			}
			set
			{
				this.m_D2OfSale = value ;
			}
		}
		#endregion
	
		#region D3OfSale
		private System.Int32 m_D3OfSale = 0 ; 
		public System.Int32 D3OfSale
		{
			get
			{
				return this.m_D3OfSale ;
			}
			set
			{
				this.m_D3OfSale = value ;
			}
		}
		#endregion
	
		#region D4OfSale
		private System.Int32 m_D4OfSale = 0 ; 
		public System.Int32 D4OfSale
		{
			get
			{
				return this.m_D4OfSale ;
			}
			set
			{
				this.m_D4OfSale = value ;
			}
		}
		#endregion
	
		#region D5OfSale
		private System.Int32 m_D5OfSale = 0 ; 
		public System.Int32 D5OfSale
		{
			get
			{
				return this.m_D5OfSale ;
			}
			set
			{
				this.m_D5OfSale = value ;
			}
		}
		#endregion
	
		#region D6OfSale
		private System.Int32 m_D6OfSale = 0 ; 
		public System.Int32 D6OfSale
		{
			get
			{
				return this.m_D6OfSale ;
			}
			set
			{
				this.m_D6OfSale = value ;
			}
		}
		#endregion
	
		#region D7OfSale
		private System.Int32 m_D7OfSale = 0 ; 
		public System.Int32 D7OfSale
		{
			get
			{
				return this.m_D7OfSale ;
			}
			set
			{
				this.m_D7OfSale = value ;
			}
		}
		#endregion
	
		#region D8OfSale
		private System.Int32 m_D8OfSale = 0 ; 
		public System.Int32 D8OfSale
		{
			get
			{
				return this.m_D8OfSale ;
			}
			set
			{
				this.m_D8OfSale = value ;
			}
		}
		#endregion
	
		#region D9OfSale
		private System.Int32 m_D9OfSale = 0 ; 
		public System.Int32 D9OfSale
		{
			get
			{
				return this.m_D9OfSale ;
			}
			set
			{
				this.m_D9OfSale = value ;
			}
		}
		#endregion
	
		#region D10OfSale
		private System.Int32 m_D10OfSale = 0 ; 
		public System.Int32 D10OfSale
		{
			get
			{
				return this.m_D10OfSale ;
			}
			set
			{
				this.m_D10OfSale = value ;
			}
		}
		#endregion
	
		#region D11OfSale
		private System.Int32 m_D11OfSale = 0 ; 
		public System.Int32 D11OfSale
		{
			get
			{
				return this.m_D11OfSale ;
			}
			set
			{
				this.m_D11OfSale = value ;
			}
		}
		#endregion
	
		#region D12OfSale
		private System.Int32 m_D12OfSale = 0 ; 
		public System.Int32 D12OfSale
		{
			get
			{
				return this.m_D12OfSale ;
			}
			set
			{
				this.m_D12OfSale = value ;
			}
		}
		#endregion
	
		#region D13OfSale
		private System.Int32 m_D13OfSale = 0 ; 
		public System.Int32 D13OfSale
		{
			get
			{
				return this.m_D13OfSale ;
			}
			set
			{
				this.m_D13OfSale = value ;
			}
		}
		#endregion
	
		#region D14OfSale
		private System.Int32 m_D14OfSale = 0 ; 
		public System.Int32 D14OfSale
		{
			get
			{
				return this.m_D14OfSale ;
			}
			set
			{
				this.m_D14OfSale = value ;
			}
		}
		#endregion
	
		#region D15OfSale
		private System.Int32 m_D15OfSale = 0 ; 
		public System.Int32 D15OfSale
		{
			get
			{
				return this.m_D15OfSale ;
			}
			set
			{
				this.m_D15OfSale = value ;
			}
		}
		#endregion
	
		#region D16OfSale
		private System.Int32 m_D16OfSale = 0 ; 
		public System.Int32 D16OfSale
		{
			get
			{
				return this.m_D16OfSale ;
			}
			set
			{
				this.m_D16OfSale = value ;
			}
		}
		#endregion
	
		#region D17OfSale
		private System.Int32 m_D17OfSale = 0 ; 
		public System.Int32 D17OfSale
		{
			get
			{
				return this.m_D17OfSale ;
			}
			set
			{
				this.m_D17OfSale = value ;
			}
		}
		#endregion
	
		#region D18OfSale
		private System.Int32 m_D18OfSale = 0 ; 
		public System.Int32 D18OfSale
		{
			get
			{
				return this.m_D18OfSale ;
			}
			set
			{
				this.m_D18OfSale = value ;
			}
		}
		#endregion
	
		#region D19OfSale
		private System.Int32 m_D19OfSale = 0 ; 
		public System.Int32 D19OfSale
		{
			get
			{
				return this.m_D19OfSale ;
			}
			set
			{
				this.m_D19OfSale = value ;
			}
		}
		#endregion
	
		#region D20OfSale
		private System.Int32 m_D20OfSale = 0 ; 
		public System.Int32 D20OfSale
		{
			get
			{
				return this.m_D20OfSale ;
			}
			set
			{
				this.m_D20OfSale = value ;
			}
		}
		#endregion
	
		#region D21OfSale
		private System.Int32 m_D21OfSale = 0 ; 
		public System.Int32 D21OfSale
		{
			get
			{
				return this.m_D21OfSale ;
			}
			set
			{
				this.m_D21OfSale = value ;
			}
		}
		#endregion
	
		#region D22OfSale
		private System.Int32 m_D22OfSale = 0 ; 
		public System.Int32 D22OfSale
		{
			get
			{
				return this.m_D22OfSale ;
			}
			set
			{
				this.m_D22OfSale = value ;
			}
		}
		#endregion
	
		#region D23OfSale
		private System.Int32 m_D23OfSale = 0 ; 
		public System.Int32 D23OfSale
		{
			get
			{
				return this.m_D23OfSale ;
			}
			set
			{
				this.m_D23OfSale = value ;
			}
		}
		#endregion
	
		#region D24OfSale
		private System.Int32 m_D24OfSale = 0 ; 
		public System.Int32 D24OfSale
		{
			get
			{
				return this.m_D24OfSale ;
			}
			set
			{
				this.m_D24OfSale = value ;
			}
		}
		#endregion
	
		#region D25OfSale
		private System.Int32 m_D25OfSale = 0 ; 
		public System.Int32 D25OfSale
		{
			get
			{
				return this.m_D25OfSale ;
			}
			set
			{
				this.m_D25OfSale = value ;
			}
		}
		#endregion
	
		#region D26OfSale
		private System.Int32 m_D26OfSale = 0 ; 
		public System.Int32 D26OfSale
		{
			get
			{
				return this.m_D26OfSale ;
			}
			set
			{
				this.m_D26OfSale = value ;
			}
		}
		#endregion
	
		#region D27OfSale
		private System.Int32 m_D27OfSale = 0 ; 
		public System.Int32 D27OfSale
		{
			get
			{
				return this.m_D27OfSale ;
			}
			set
			{
				this.m_D27OfSale = value ;
			}
		}
		#endregion
	
		#region D28OfSale
		private System.Int32 m_D28OfSale = 0 ; 
		public System.Int32 D28OfSale
		{
			get
			{
				return this.m_D28OfSale ;
			}
			set
			{
				this.m_D28OfSale = value ;
			}
		}
		#endregion
	
		#region D29OfSale
		private System.Int32 m_D29OfSale = 0 ; 
		public System.Int32 D29OfSale
		{
			get
			{
				return this.m_D29OfSale ;
			}
			set
			{
				this.m_D29OfSale = value ;
			}
		}
		#endregion
	
		#region D30OfSale
		private System.Int32 m_D30OfSale = 0 ; 
		public System.Int32 D30OfSale
		{
			get
			{
				return this.m_D30OfSale ;
			}
			set
			{
				this.m_D30OfSale = value ;
			}
		}
		#endregion
	
		#region D31OfSale
		private System.Int32 m_D31OfSale = 0 ; 
		public System.Int32 D31OfSale
		{
			get
			{
				return this.m_D31OfSale ;
			}
			set
			{
				this.m_D31OfSale = value ;
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
