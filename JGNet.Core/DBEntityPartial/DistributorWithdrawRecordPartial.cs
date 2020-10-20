using System;
using System.Collections.Generic;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using DataRabbit;

namespace JGNet
{
    public partial class DistributorWithdrawRecord
    {
        public String StateName
        {
            get
            {
                return EnumHelper.GetDescription((DistributorWithdrawRecordState)State);
            }
        }

        public String DistributorName { get; set; }
        
        /// <summary>
        /// 打款后的金额
        /// </summary>
        public decimal NewMoney
        {
            get
            {
                return this.OldMoney - this.Money;
            }
        }
    }
}
