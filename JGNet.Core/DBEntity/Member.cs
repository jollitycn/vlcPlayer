using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	[Serializable]
	public partial class Member : IEntity<System.String>
	{
	    #region Force Static Check
		public const string TableName = "Member" ;
		public const string _PhoneNumber = "PhoneNumber" ;
		public const string _Password = "Password" ;
		public const string _Name = "Name" ;
		public const string _Sex = "Sex" ;
		public const string _WeiXin = "WeiXin" ;
		public const string _CreatedTime = "CreatedTime" ;
		public const string _GuideID = "GuideID" ;
		public const string _ShopID = "ShopID" ;
		public const string _Source = "Source" ;
		public const string _IntroducerID = "IntroducerID" ;
		public const string _MemberLevel = "MemberLevel" ;
		public const string _SequenceCode = "SequenceCode" ;
		public const string _IsIntroducer = "IsIntroducer" ;
		public const string _AccruedCommission = "AccruedCommission" ;
		public const string _WithdrawCommission = "WithdrawCommission" ;
		public const string _Birthday = "Birthday" ;
		public const string _Birthday2 = "Birthday2" ;
		public const string _DetailAddress = "DetailAddress" ;
		public const string _Remarks = "Remarks" ;
		public const string _State = "State" ;
		public const string _CurrentIntegration = "CurrentIntegration" ;
		public const string _AccruedIntegration = "AccruedIntegration" ;
		public const string _Balance = "Balance" ;
		public const string _Donate = "Donate" ;
		public const string _AccruedSpend = "AccruedSpend" ;
		public const string _DonateCoef = "DonateCoef" ;
		public const string _BuyCount = "BuyCount" ;
		public const string _QuantityOfBuy = "QuantityOfBuy" ;
		public const string _LastSpendTime = "LastSpendTime" ;
		public const string _BalanceExceptDonate = "BalanceExceptDonate" ;
		public const string _AccruedRecharge = "AccruedRecharge" ;
		public const string _HeadImageUrl = "HeadImageUrl" ;
		public const string _DormancyActivated = "DormancyActivated" ;
		public const string _LastVisitTime = "LastVisitTime" ;
		public const string _Phone = "Phone" ;
		public const string _SeeCommission = "SeeCommission" ;
	    #endregion
	 
	    #region Property
	
		#region PhoneNumber
		private System.String m_PhoneNumber = "" ; 
		/// <summary>
		/// PhoneNumber 会员卡号，手机号码（主键）
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
	
		#region Password
		private System.String m_Password = "" ; 
		/// <summary>
		/// Password 密码（初始密码：000000）
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
		/// Name 中文姓名
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
	
		#region Sex
		private System.Boolean m_Sex = false ; 
		/// <summary>
		/// Sex 性别（1：男，0：女）
		/// </summary>
		public System.Boolean Sex
		{
			get
			{
				return this.m_Sex ;
			}
			set
			{
				this.m_Sex = value ;
			}
		}
		#endregion
	
		#region WeiXin
		private System.String m_WeiXin = "" ; 
		/// <summary>
		/// WeiXin 微信
		/// </summary>
		public System.String WeiXin
		{
			get
			{
				return this.m_WeiXin ;
			}
			set
			{
				this.m_WeiXin = value ;
			}
		}
		#endregion
	
		#region CreatedTime
		private System.DateTime m_CreatedTime = DateTime.Now ; 
		/// <summary>
		/// CreatedTime 申请日期
		/// </summary>
		public System.DateTime CreatedTime
		{
			get
			{
				return this.m_CreatedTime ;
			}
			set
			{
				this.m_CreatedTime = value ;
			}
		}
		#endregion
	
		#region GuideID
		private System.String m_GuideID = "" ; 
		/// <summary>
		/// GuideID 开卡人（导购）
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
	
		#region ShopID
		private System.String m_ShopID = "" ; 
		/// <summary>
		/// ShopID 开卡店铺
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
	
		#region Source
		private System.Byte m_Source = 0 ; 
		/// <summary>
		/// Source 客户来源（0 ：无，1：网上，2：熟人介绍，3：传单，4：广告）
		/// </summary>
		public System.Byte Source
		{
			get
			{
				return this.m_Source ;
			}
			set
			{
				this.m_Source = value ;
			}
		}
		#endregion
	
		#region IntroducerID
		private System.String m_IntroducerID = "" ; 
		/// <summary>
		/// IntroducerID 推荐人（会员）
		/// </summary>
		public System.String IntroducerID
		{
			get
			{
				return this.m_IntroducerID ;
			}
			set
			{
				this.m_IntroducerID = value ;
			}
		}
		#endregion
	
		#region MemberLevel
		private System.Int32 m_MemberLevel = 0 ; 
		/// <summary>
		/// MemberLevel 等级0：1级，1：2级…
		/// </summary>
		public System.Int32 MemberLevel
		{
			get
			{
				return this.m_MemberLevel ;
			}
			set
			{
				this.m_MemberLevel = value ;
			}
		}
		#endregion
	
		#region SequenceCode
		private System.String m_SequenceCode = "" ; 
		/// <summary>
		/// SequenceCode 序列编码
		/// </summary>
		public System.String SequenceCode
		{
			get
			{
				return this.m_SequenceCode ;
			}
			set
			{
				this.m_SequenceCode = value ;
			}
		}
		#endregion
	
		#region IsIntroducer
		private System.Boolean m_IsIntroducer = false ; 
		/// <summary>
		/// IsIntroducer 是否是推荐人
		/// </summary>
		public System.Boolean IsIntroducer
		{
			get
			{
				return this.m_IsIntroducer ;
			}
			set
			{
				this.m_IsIntroducer = value ;
			}
		}
		#endregion
	
		#region AccruedCommission
		private System.Decimal m_AccruedCommission = 0 ; 
		/// <summary>
		/// AccruedCommission 累计佣金
		/// </summary>
		public System.Decimal AccruedCommission
		{
			get
			{
				return this.m_AccruedCommission ;
			}
			set
			{
				this.m_AccruedCommission = value ;
			}
		}
		#endregion
	
		#region WithdrawCommission
		private System.Decimal m_WithdrawCommission = 0 ; 
		/// <summary>
		/// WithdrawCommission 已提现佣金
		/// </summary>
		public System.Decimal WithdrawCommission
		{
			get
			{
				return this.m_WithdrawCommission ;
			}
			set
			{
				this.m_WithdrawCommission = value ;
			}
		}
		#endregion
	
		#region Birthday
		private System.DateTime m_Birthday = DateTime.Now ; 
		/// <summary>
		/// Birthday 生日日期
		/// </summary>
		public System.DateTime Birthday
		{
			get
			{
				return this.m_Birthday ;
			}
			set
			{
				this.m_Birthday = value ;
			}
		}
		#endregion
	
		#region Birthday2
		private System.Int32 m_Birthday2 = 0 ; 
		/// <summary>
		/// Birthday2 生日，如803表示8月3日
		/// </summary>
		public System.Int32 Birthday2
		{
			get
			{
				return this.m_Birthday2 ;
			}
			set
			{
				this.m_Birthday2 = value ;
			}
		}
		#endregion
	
		#region DetailAddress
		private System.String m_DetailAddress = "" ; 
		/// <summary>
		/// DetailAddress 邮寄地址
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
	
		#region State
		private System.Byte m_State = 0 ; 
		/// <summary>
		/// State 状态
		/// </summary>
		public System.Byte State
		{
			get
			{
				return this.m_State ;
			}
			set
			{
				this.m_State = value ;
			}
		}
		#endregion
	
		#region CurrentIntegration
		private System.Int32 m_CurrentIntegration = 0 ; 
		/// <summary>
		/// CurrentIntegration 当前积分
		/// </summary>
		public System.Int32 CurrentIntegration
		{
			get
			{
				return this.m_CurrentIntegration ;
			}
			set
			{
				this.m_CurrentIntegration = value ;
			}
		}
		#endregion
	
		#region AccruedIntegration
		private System.Int32 m_AccruedIntegration = 0 ; 
		/// <summary>
		/// AccruedIntegration 累计积分
		/// </summary>
		public System.Int32 AccruedIntegration
		{
			get
			{
				return this.m_AccruedIntegration ;
			}
			set
			{
				this.m_AccruedIntegration = value ;
			}
		}
		#endregion
	
		#region Balance
		private System.Decimal m_Balance = 0 ; 
		/// <summary>
		/// Balance 余额
		/// </summary>
		public System.Decimal Balance
		{
			get
			{
				return this.m_Balance ;
			}
			set
			{
				this.m_Balance = value ;
			}
		}
		#endregion
	
		#region Donate
		private System.Decimal m_Donate = 0 ; 
		/// <summary>
		/// Donate 总的赠送金额
		/// </summary>
		public System.Decimal Donate
		{
			get
			{
				return this.m_Donate ;
			}
			set
			{
				this.m_Donate = value ;
			}
		}
		#endregion
	
		#region AccruedSpend
		private System.Decimal m_AccruedSpend = 0 ; 
		/// <summary>
		/// AccruedSpend 累计消费
		/// </summary>
		public System.Decimal AccruedSpend
		{
			get
			{
				return this.m_AccruedSpend ;
			}
			set
			{
				this.m_AccruedSpend = value ;
			}
		}
		#endregion
	
		#region DonateCoef
		private System.Double m_DonateCoef = 0 ; 
		/// <summary>
		/// DonateCoef 赠送比例
		/// </summary>
		public System.Double DonateCoef
		{
			get
			{
				return this.m_DonateCoef ;
			}
			set
			{
				this.m_DonateCoef = value ;
			}
		}
		#endregion
	
		#region BuyCount
		private System.Int32 m_BuyCount = 0 ; 
		/// <summary>
		/// BuyCount 购买笔数
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
	
		#region QuantityOfBuy
		private System.Int32 m_QuantityOfBuy = 0 ; 
		/// <summary>
		/// QuantityOfBuy 购买总数量（扣除退货）
		/// </summary>
		public System.Int32 QuantityOfBuy
		{
			get
			{
				return this.m_QuantityOfBuy ;
			}
			set
			{
				this.m_QuantityOfBuy = value ;
			}
		}
		#endregion
	
		#region LastSpendTime
		private System.DateTime m_LastSpendTime = DateTime.Now ; 
		/// <summary>
		/// LastSpendTime 最后消费日期
		/// </summary>
		public System.DateTime LastSpendTime
		{
			get
			{
				return this.m_LastSpendTime ;
			}
			set
			{
				this.m_LastSpendTime = value ;
			}
		}
		#endregion
	
		#region BalanceExceptDonate
		private System.Decimal m_BalanceExceptDonate = 0 ; 
		/// <summary>
		/// BalanceExceptDonate 余额扣除赠送部分后。公式：Balance*（1- DonateCoef）
		/// </summary>
		public System.Decimal BalanceExceptDonate
		{
			get
			{
				return this.m_BalanceExceptDonate ;
			}
			set
			{
				this.m_BalanceExceptDonate = value ;
			}
		}
		#endregion
	
		#region AccruedRecharge
		private System.Decimal m_AccruedRecharge = 0 ; 
		/// <summary>
		/// AccruedRecharge 累计充值金额
		/// </summary>
		public System.Decimal AccruedRecharge
		{
			get
			{
				return this.m_AccruedRecharge ;
			}
			set
			{
				this.m_AccruedRecharge = value ;
			}
		}
		#endregion
	
		#region HeadImageUrl
		private System.String m_HeadImageUrl = "" ; 
		/// <summary>
		/// HeadImageUrl 头像的云存储地址
		/// </summary>
		public System.String HeadImageUrl
		{
			get
			{
				return this.m_HeadImageUrl ;
			}
			set
			{
				this.m_HeadImageUrl = value ;
			}
		}
		#endregion
	
		#region DormancyActivated
		private System.Boolean m_DormancyActivated = false ; 
		/// <summary>
		/// DormancyActivated 是否做了休眠激活回访？
		/// </summary>
		public System.Boolean DormancyActivated
		{
			get
			{
				return this.m_DormancyActivated ;
			}
			set
			{
				this.m_DormancyActivated = value ;
			}
		}
		#endregion
	
		#region LastVisitTime
		private System.DateTime m_LastVisitTime = DateTime.Now ; 
		/// <summary>
		/// LastVisitTime 最后回访时间
		/// </summary>
		public System.DateTime LastVisitTime
		{
			get
			{
				return this.m_LastVisitTime ;
			}
			set
			{
				this.m_LastVisitTime = value ;
			}
		}
		#endregion
	
		#region Phone
		private System.String m_Phone = "" ; 
		/// <summary>
		/// Phone 手机号码
		/// </summary>
		public System.String Phone
		{
			get
			{
				return this.m_Phone ;
			}
			set
			{
				this.m_Phone = value ;
			}
		}
		#endregion
	
		#region SeeCommission
		private System.Boolean m_SeeCommission = false ; 
		/// <summary>
		/// SeeCommission 能否看佣金（0：不能，1：能）
		/// </summary>
		public System.Boolean SeeCommission
		{
			get
			{
				return this.m_SeeCommission ;
			}
			set
			{
				this.m_SeeCommission = value ;
			}
		}
		#endregion
	    #endregion
	 
	    #region IEntity Members
	    public System.String GetPKeyValue()
	    {
	       return this.PhoneNumber;
	    }
	    #endregion
	}
}
