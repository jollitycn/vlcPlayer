using System;
using System.Collections.Generic;
using DataRabbit;
using CJBasic.Helpers;

namespace JGNet
{
    public partial class DayReport : IStatisticabled
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public string ShopName { get; set; }

        private Decimal salesTotal = 0;

        public bool IsStatistics { get; set; }
        public Decimal SalesTotal
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return SalesTotalMoney + RefundTotalMoney - this.CarriageCost;
                }
                return this.salesTotal;
            }
            set
            {
                this.salesTotal = value;
            }

        }

        /// <summary>
        /// �˿��˻�ʱ�������������ܽ��
        /// </summary>
        public decimal RefundInBankCard { get; set; }

        /// <summary>
        /// �˿��˻�ʱ������΢���ܽ��
        /// </summary>
        public decimal RefundInWeiXin { get; set; }

        /// <summary>
        /// �˿��˻�ʱ������֧�����ܽ��
        /// </summary>
        public decimal RefundInAlipay { get; set; }

        /// <summary>
        /// ����ʱ�յ����������
        /// </summary>
        public decimal SalesInMoneyOther { get; set; }

        /// <summary>
        /// �˿��˻�ʱ�������������
        /// </summary>
        public decimal RefundInMoneyOther { get; set; }
    }
}
