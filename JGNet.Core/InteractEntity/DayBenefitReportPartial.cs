using System;
using System.Collections.Generic;
using JGNet.Core.Tools;
using JGNet.Server.Tools;
using DataRabbit;

namespace JGNet
{ 
	public partial class DayBenefitReport 
	{
        public String ShopName { get; set; }

        /// <summary>
        /// ��Ա��ֵ
        /// </summary>
        public decimal TotalRecharge { get; set; }

        public decimal SalesTotalMoney4NoVip { get { return this.m_SalesTotalMoney - this.m_SalesTotalMoneyVip; } }
        
        public string SalesVipContributionName {
            get
            {
                return StringHelper.RateToWithPercent(this.m_SalesVipContribution);
            }
        }
        public string SalesAverageDiscountName
        {
            get
            {
                return StringHelper.RateToWithPercent((double)this.m_SalesAverageDiscount);
            }
        }
        public string SalesJointRateName
        {
            get
            {
                return StringHelper.RateToWithPercent(this.m_SalesJointRate);
            }
        }
        public string SalesPerMemberPayName
        {
            get
            {
                return StringHelper.RateToWithPercent(this.m_SalesPerMemberPay);
            }
        }
        public string SalesPerCostumePayName
        {
            get
            {
                return StringHelper.RateToWithPercent(this.m_SalesPerCostumePay);
            }
        }
        public string RefundRateName
        {
            get
            {
                return StringHelper.RateToWithPercent(Math.Abs(this.m_RefundRate));
            }
        }


        /// <summary>
        /// ���۶�ͬ���ʣ���%�ַ�����
        /// </summary>
        public string YearOnYearRate_SalesTotalMoneyName
        {
            get
            {
                return StringHelper.RateToWithPercentAndPlusSign(this.yearOnYearRate_SalesTotalMoney); 
            }
        }

        /// <summary>
        /// ���۶���ʣ���%�ַ�����
        /// </summary>
        public string QuarterOnQuarterRate_SalesTotalMoneyName
        {
            get
            {
                return StringHelper.RateToWithPercentAndPlusSign(this.quarterOnQuarterRate_SalesTotalMoney);
            }
        }

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

        private double yearOnYearRate_SalesTotalMoney = 0;
        /// <summary>
        ///  ���۶�ͬ����
        /// </summary>
        public double YearOnYearRate_SalesTotalMoney
        {
            get { return this.yearOnYearRate_SalesTotalMoney; }
            set { this.yearOnYearRate_SalesTotalMoney = value; }
        }

        private double quarterOnQuarterRate_SalesTotalMoney = 0;
        /// <summary>
        /// ���۶����
        /// </summary>        
        public double QuarterOnQuarterRate_SalesTotalMoney
        {
            get { return this.quarterOnQuarterRate_SalesTotalMoney; }
            set { this.quarterOnQuarterRate_SalesTotalMoney = value; }
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
        /// Ŀ��ֵ
        /// </summary>
        public int TaskTarget { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// �����
        /// </summary>
        public double CompletionRate { get; set; }
        /// <summary>
        /// ë����
        /// </summary>
        public string SalesBenefitRate
        {
            get
            {
                if (this.SalesActualRecv == 0)
                {
                    return "0%";
                }
                return StringHelper.RateToWithPercent((double)MathHelper.Rounded(this.SalesBenefit / this.SalesActualRecv, 2));
            }
        }

        public string CompletionRateName { get { return StringHelper.RateToWithPercent(this.CompletionRate); } }

    }
}
