using System;
using System.Collections.Generic;
using JGNet.Core.Const;
using JGNet.Core.Tools;
using DataRabbit;

namespace JGNet
{
    public partial class GiftTicket
    { 
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String CostumeID { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String ShopName { get; set; }
        public String StateName
        {
            get
            {
                return this.UseTime == SystemDefault.DateTimeNull?"未使用":"已使用";
            }
        }

        public override String ToString() {
            return CostumeID + " " + Denomination + " " + this.ExpiredDate;
        }

        public string EmTicketDescription
        {
            get
            {
                return GiftTicketHelper.GetEmTicketDescription(this.MinMoney, this.MinDiscount, this.IsAnd);
            }
        }

        /// <summary>
        /// 有效日期
        /// </summary>
        public string EffectiveDate
        {
            get {
                return this.EffectDate.ToShortDateString() + "  -  " + this.ExpiredDate.ToShortDateString();
            }
        }

        public String MemberName { get; set; }
    }
}
