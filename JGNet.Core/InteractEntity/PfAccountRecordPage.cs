using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class PfAccountRecordPage : BasePage
    {
        public List<PfAccountRecord> PfAccountRecords { get; set; }

        public PfAccountRecord Sum { get; set; }
    }

    public class GetPfAccountRecordPagePara : BasePagePara
    {
        public string PfCustomerID { get; set; }

        public PfAccountType PfAccountType { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    public class PfCollectionManagePara : BasePagePara
    {
        public string PfCustomerID { get; set; }

        /// <summary>
        /// 收款方式
        /// </summary>
        public PfAccountRecordType PayType { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    [Serializable]
    public class PfAccountContrastPara
    {
        public string PfCustomerID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    [Serializable]
    public class PfAccountContrastItem
    {
        public PfAccountContrastInfo Sum { get; set; }

        public List<PfAccountContrastInfo> Infos { get; set; }
    }

    [Serializable]
    public class PfAccountContrastInfo
    {
        public string DateStr { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 进货数量
        /// </summary>
        public int InCount { get; set; }

        /// <summary>
        /// 进货金额
        /// </summary>
        public decimal InMoney { get; set; }

        /// <summary>
        /// 退货数量
        /// </summary>
        public int OutCount { get; set; }

        /// <summary>
        /// 退货金额
        /// </summary>
        public decimal OutMoney { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal OtherMoney { get; set; }

        /// <summary>
        /// 已付金额
        /// </summary>
        public decimal PayMoney { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal PaymentBalance { get; set; }
    }

    [Serializable]
    public class PfAccountRecordSummaryPara
    {
        public string PfCustomerID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    [Serializable]
    public class PfAccountRecord4SummaryPara
    {
        public string PfCustomerID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public PARSQueryType Type { get; set; }
    }

    public enum PARSQueryType
    {
        ShouldPay = 0,

        OtherMoney,

        PayMoney
    }

    [Serializable]
    public class PfAccountRecordSummaryInfo
    {
        public string SupplierID { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 期初余额
        /// </summary>
        public decimal StartMoney { get; set; }

        /// <summary>
        /// 应付贷款
        /// </summary>
        public decimal ShouldPay { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal OtherMoney { get; set; }

        /// <summary>
        /// 已付金额
        /// </summary>
        public decimal PayMoney { get; set; }

        /// <summary>
        /// 期末余额
        /// </summary>
        public decimal EndMoney { get; set; }
    }
}
