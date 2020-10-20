using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class SupplierAccountRecordPagePara : BasePagePara
    {
        public string SupplierID { get; set; }

        public AccountType AccountType { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    public class PurchasePayManagePara : BasePagePara
    {
        public string SupplierID { get; set; }

        public SupplierAccountRecordPayType PayType { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    public class SupplierAccountRecordPage : BasePage
    {
        public List<SupplierAccountRecord> SupplierAccountRecords { get; set; }
         
        public SupplierAccountRecord Sum { get; set; }
    }

    [Serializable]
    public class SupplierAccountContrastPara
    {
        public string SupplierID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    [Serializable]
    public class SupplierAccountContrastItem
    {
        public SupplierAccountContrastInfo Sum { get; set; }

        public List<SupplierAccountContrastInfo> Infos { get; set; }
    }

    [Serializable]
    public class SupplierAccountContrastInfo
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
    public class SupplierAccountRecordSumInfo : BasePage
    {
        public SupplierAccountRecordEntity SupplierAccountRecordEntitySum { get; set; }

        public List<SupplierAccountRecordEntity> SupplierAccountRecordEntitieList { get; set; }
    }

    [Serializable]
    public class SupplierAccountRecordEntity
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 当前欠款额度
        /// </summary>
        public decimal CurrentAccountMoney { get; set; }

        /// <summary>
        /// 进货额度
        /// </summary>
        public decimal PurchaseAmount { get; set; }

        /// <summary>
        /// 退货额度
        /// </summary>
        public decimal ReturnAmount { get; set; }

        /// <summary>
        /// 收款额度
        /// </summary>
        public decimal IncomeAmount { get; set; }

        /// <summary>
        /// 付款额度
        /// </summary>
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// 发生额度
        /// </summary>
        public decimal HappenAmount { get { return this.PurchaseAmount + this.ReturnAmount; } }

        /// <summary>
        /// 还款额度
        /// </summary>
        public decimal PayAmount { get { return -(this.PaymentAmount + this.IncomeAmount); } }

        /// <summary>
        /// 本期欠款额度
        /// </summary>
        public decimal CurrentDebtAmount { get { return this.HappenAmount - this.PayAmount; } }
    }

    [Serializable]
    public class SupplierAccountRecordSummaryPara
    {
        public string SupplierID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    [Serializable]
    public class SupplierAccountRecord4SummaryPara
    {
        public string SupplierID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public SARSQueryType Type { get; set; }
    }

    public enum SARSQueryType
    {
        ShouldPay = 0,

        OtherMoney,

        PayMoney
    }

    [Serializable]
    public class SupplierAccountRecordSummaryInfo
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

    public enum DebtType {
        
        /// <summary>
        /// 所有类型
        /// </summary>
        All=-1,

        /// <summary>
        /// 有欠款
        /// </summary>
        HaveDebt=0,

        /// <summary>
        /// 没有欠款
        /// </summary>
        None=1
    }
}
