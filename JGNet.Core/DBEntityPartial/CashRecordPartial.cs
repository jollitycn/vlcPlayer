using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class CashRecord
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorUserName { get; set; }

        /// <summary>
        /// 费用类型名称
        /// </summary>
        public string FeeTypeName
        {
            get {
                switch (this.m_FeeType)
                {
                    case 0:
                        return "上缴销售款";
                    case 1:
                        return "收入";
                    case 2:
                        return "支出";
                }
                return string.Empty;
            }
        }
    }
}
