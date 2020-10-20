using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class SizeGroup : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "SizeGroup" ;
		public const string _SizeGroupName = "SizeGroupName" ;
		public const string _ShowName = "ShowName" ;
		public const string _Comment = "Comment" ;
		public const string _NameOfF = "NameOfF" ;
		public const string _NameOfXS = "NameOfXS" ;
		public const string _NameOfS = "NameOfS" ;
		public const string _NameOfM = "NameOfM" ;
		public const string _NameOfL = "NameOfL" ;
		public const string _NameOfXL = "NameOfXL" ;
		public const string _NameOfXL2 = "NameOfXL2" ;
		public const string _NameOfXL3 = "NameOfXL3" ;
		public const string _NameOfXL4 = "NameOfXL4" ;
		public const string _NameOfXL5 = "NameOfXL5" ;
		public const string _NameOfXL6 = "NameOfXL6" ;
		public const string _Enabled = "Enabled" ;
	    #endregion
	 
	    #region Property
	
		#region SizeGroupName
		private System.String m_SizeGroupName = "" ; 
		/// <summary>
		/// SizeGroupName 尺码组名称（主键）
		/// </summary>
		public System.String SizeGroupName
		{
			get
			{
				return this.m_SizeGroupName ;
			}
			set
			{
				this.m_SizeGroupName = value ;
			}
		}
		#endregion
	
		#region ShowName
		private System.String m_ShowName = "" ; 
		/// <summary>
		/// ShowName 显示的别名
		/// </summary>
		public System.String ShowName
		{
			get
			{
				return this.m_ShowName ;
			}
			set
			{
				this.m_ShowName = value ;
			}
		}
		#endregion
	
		#region Comment
		private System.String m_Comment = "" ; 
		/// <summary>
		/// Comment 尺码组说明
		/// </summary>
		public System.String Comment
		{
			get
			{
				return this.m_Comment ;
			}
			set
			{
				this.m_Comment = value ;
			}
		}
		#endregion
	
		#region NameOfF
		private System.String m_NameOfF = "" ; 
		/// <summary>
		/// NameOfF F的别称
		/// </summary>
		public System.String NameOfF
		{
			get
			{
				return this.m_NameOfF ;
			}
			set
			{
				this.m_NameOfF = value ;
			}
		}
		#endregion
	
		#region NameOfXS
		private System.String m_NameOfXS = "" ; 
		/// <summary>
		/// NameOfXS XS的别称
		/// </summary>
		public System.String NameOfXS
		{
			get
			{
				return this.m_NameOfXS ;
			}
			set
			{
				this.m_NameOfXS = value ;
			}
		}
		#endregion
	
		#region NameOfS
		private System.String m_NameOfS = "" ; 
		public System.String NameOfS
		{
			get
			{
				return this.m_NameOfS ;
			}
			set
			{
				this.m_NameOfS = value ;
			}
		}
		#endregion
	
		#region NameOfM
		private System.String m_NameOfM = "" ; 
		public System.String NameOfM
		{
			get
			{
				return this.m_NameOfM ;
			}
			set
			{
				this.m_NameOfM = value ;
			}
		}
		#endregion
	
		#region NameOfL
		private System.String m_NameOfL = "" ; 
		public System.String NameOfL
		{
			get
			{
				return this.m_NameOfL ;
			}
			set
			{
				this.m_NameOfL = value ;
			}
		}
		#endregion
	
		#region NameOfXL
		private System.String m_NameOfXL = "" ; 
		public System.String NameOfXL
		{
			get
			{
				return this.m_NameOfXL ;
			}
			set
			{
				this.m_NameOfXL = value ;
			}
		}
		#endregion
	
		#region NameOfXL2
		private System.String m_NameOfXL2 = "" ; 
		public System.String NameOfXL2
		{
			get
			{
				return this.m_NameOfXL2 ;
			}
			set
			{
				this.m_NameOfXL2 = value ;
			}
		}
		#endregion
	
		#region NameOfXL3
		private System.String m_NameOfXL3 = "" ; 
		public System.String NameOfXL3
		{
			get
			{
				return this.m_NameOfXL3 ;
			}
			set
			{
				this.m_NameOfXL3 = value ;
			}
		}
		#endregion
	
		#region NameOfXL4
		private System.String m_NameOfXL4 = "" ; 
		public System.String NameOfXL4
		{
			get
			{
				return this.m_NameOfXL4 ;
			}
			set
			{
				this.m_NameOfXL4 = value ;
			}
		}
		#endregion
	
		#region NameOfXL5
		private System.String m_NameOfXL5 = "" ; 
		public System.String NameOfXL5
		{
			get
			{
				return this.m_NameOfXL5 ;
			}
			set
			{
				this.m_NameOfXL5 = value ;
			}
		}
		#endregion
	
		#region NameOfXL6
		private System.String m_NameOfXL6 = "" ; 
		public System.String NameOfXL6
		{
			get
			{
				return this.m_NameOfXL6 ;
			}
			set
			{
				this.m_NameOfXL6 = value ;
			}
		}
		#endregion
	
		#region Enabled
		private System.Boolean m_Enabled = false ; 
		/// <summary>
		/// Enabled 是否启用？
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
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.SizeGroupName;
	    }
	    #endregion
	}
}
