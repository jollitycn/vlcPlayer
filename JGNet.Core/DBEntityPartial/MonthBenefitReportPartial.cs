using System;
using System.Collections.Generic;
using JGNet.Core.Tools;
using DataRabbit;

namespace JGNet
{
    public partial class MonthBenefitReport
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String ShopName { get; set; }

        public string SalesVipContributionName
        {
            get {
                return StringHelper.RateToWithPercent(this.m_SalesVipContribution);
            }
            
        }
        #region TaskTarget
        private System.Int32 m_TaskTarget = 0;
        /// <summary>
        /// TaskTarget Ŀ�����۶� 20180525
        /// </summary>
        public System.Int32 TaskTarget
        {
            get
            {
                return this.m_TaskTarget;
            }
            set
            {
                this.m_TaskTarget = value;
            }
        }
        #endregion

        #region CompletionRate
        private System.Double m_CompletionRate = 0;
        /// <summary>
        /// CompletionRate Ŀ������� = �������۶� / Ŀ�����۶� 20180525
        /// </summary>
        public System.Double CompletionRate
        {
            get
            {
                return this.m_CompletionRate;
            }
            set
            {
                this.m_CompletionRate = value;
            }
        }
        #endregion
        /// <summary>
        /// Vip���۶�ͬ���ʣ���%�ַ�����
        /// </summary>
        public string YearOnYearRate_VIPSalesTotalMoneyName
        {
            get
            {
                return StringHelper.RateToWithPercent(this.yearOnYearRate_VIPSalesTotalMoney);
            }
        }

        /// <summary>
        /// Vip���۶���ʣ���%�ַ�����
        /// </summary>
        public string QuarterOnQuarterRate_VIPSalesTotalMoneyName
        {
            get
            {
                return StringHelper.RateToWithPercent(this.quarterOnQuarterRate_VIPSalesTotalMoney);
            }
        }

        private double yearOnYearRate_VIPSalesTotalMoney = 0;
        /// <summary>
        ///  VIP���۶�ͬ����
        /// </summary>
        public double YearOnYearRate_VIPSalesTotalMoney
        {
            get { return this.yearOnYearRate_VIPSalesTotalMoney; }
            set { this.yearOnYearRate_VIPSalesTotalMoney = value; }
        }

        private double quarterOnQuarterRate_VIPSalesTotalMoney = 0; 
        /// <summary>
        /// VIP���۶����
        /// </summary>        
        public double QuarterOnQuarterRate_VIPSalesTotalMoney
        {
            get { return this.quarterOnQuarterRate_VIPSalesTotalMoney; }
            set { this.quarterOnQuarterRate_VIPSalesTotalMoney = value; }
        }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        ///  ����ʵ�ն�ͬ����
        /// </summary>
        public double QuarterOnQuarterRate_SalesActualRecvShop { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// ����ʵ�ն����
        /// </summary> 
        public double YearOnYearRate_SalesActualRecvShop { get; set; }

        public string QuarterOnQuarterRate_SalesActualRecvShopName
        {
            get
            {
                return StringHelper.RateToWithPercentAndPlusSign(this.QuarterOnQuarterRate_SalesActualRecvShop);
            }
        }

        public string YearOnYearRate_SalesActualRecvShopName
        {
            get
            {
                return StringHelper.RateToWithPercentAndPlusSign(this.YearOnYearRate_SalesActualRecvShop);
            }
        }

    }
}
