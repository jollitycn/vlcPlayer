using System;
using System.Collections.Generic;
using JGNet.Core.Tools;
using DataRabbit;

namespace JGNet
{
    public partial class PfCustomerBalanceRecord
    {

        public String ChangeTypeName
        {
            get
            {
                return EnumHelper.GetDescription((PfCustomerBalanceType)ChangeType);
            }
        }

        /// <summary>
        /// ±¸×¢
        /// </summary>
        public string Remarks { get; set; }
    }
}
