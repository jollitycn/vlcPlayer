using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class UpdateRechargeRecordPara
    {
        public string ID { get; set; }

        public decimal MoneyCash { get; set; }

        public decimal MoneyBankCard { get; set; }

        public decimal MoneyWeiXin { get; set; }

        public decimal MoneyAlipay { get; set; }

        public decimal DonateMoney { get; set; }

        public string Remarks { get; set; }
    }
}
