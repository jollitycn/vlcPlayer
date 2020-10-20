using System;
using System.Collections.Generic;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using DataRabbit;

namespace JGNet
{
    public partial class SupplierAccountRecord
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String SupplierName { get; set; }

        
        public String AdminUserName { get; set; }

        public String AccountTypeName { get; set; }

        public string PayTypeName
        {
            get
            {
                return EnumHelper.GetDescription((SupplierAccountRecordPayType)this.PayType);
            }
        }
    }
}
