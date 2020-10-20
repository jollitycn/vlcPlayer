using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet.Core
{
    public class ParameterConfigKey
    {
        /// <summary>
        /// 多少积分兑换为1元
        /// </summary>
        public const string IntegrationExchange = "IntegrationExchange";

        /// <summary>
        /// 多少元兑换1积分
        /// </summary>
        public const string MoneyExchange = "MoneyExchange";

        /// <summary>
        /// 折扣比例  （满折扣100:1）
        /// </summary>
        public const decimal DiscountRatio = 100;
        
        /// <summary>
        /// 款型
        /// </summary>
        public const string CostumeModel = "CostumeModel";

        /// <summary>
        /// 风格
        /// </summary>
        public const string CostumeStyle = "CostumeStyle";

        /// <summary>
        /// 季节
        /// </summary>
        public const string Season = "Season";

        /// <summary>
        /// 导购端回访会员功能的参数设置
        /// </summary>
        public const string GuideReturnVisitPara = "GuideReturnVisitPara";

        /// <summary>
        /// 收入
        /// </summary>
        public const string IncomeTypes = "IncomeTypes";

        /// <summary>
        /// 支出
        /// </summary>
        public const string SpendingTypes = "SpendingTypes";

        /// <summary>
        /// 服装使用电子优惠券信息(CostumeGiftTicketInfo 中间转换)
        /// </summary>
        public const string CostumeGiftTicket = "CostumeGiftTicket";

        #region 微信小程序
        public const string Wx_AppID = "Wx_AppID";

        public const string Wx_AppSecret = "Wx_AppSecret";

        public const string Wx_KEY = "Wx_KEY";

        public const string Wx_MCHID = "Wx_MCHID";

        public const string Wx_NOTIFY_URL = "Wx_NOTIFY_URL";
        #endregion

        /// <summary>
        /// 展示的尺码
        /// </summary>
        public const string ShowSizeName = "ShowSizeName";

        /// <summary>
        /// 导购端销售回访是否只看自己
        /// </summary>
        public const string X_SeeMyself = "X_SeeMyself";
        
        /// <summary>
        /// 销售、出库是否允许负数库存
        /// </summary>
        public const string LimitCostumeStore = "LimitCostumeStore";

        /// <summary>
        /// 默认尺码组
        /// </summary>
        public const string DefaultSizeGroup = "DefaultSizeGroup";

        /// <summary>
        /// 条形码模板
        /// </summary>
        public const string BarCodeTemplate = "BarCodeTemplate";

        /// <summary>
        /// 供应商进货折扣
        /// </summary>
        public const string SupplierDiscount = "SupplierDiscount";

        /// <summary>
        /// pos端 和 导购端 只能查看本店的会员
        /// </summary>
        public const string SeeOwnShopMember = "SeeOwnShopMember";

        ///// <summary>
        ///// 总仓是否允许销售
        ///// </summary>
        //public const string IsGeneralStoreRetail = "IsGeneralStoreRetail";

        /// <summary>
        /// 是否隐藏期初建仓功能
        /// </summary>
        public const string IsHideCreateStore = "IsHideCreateStore";

        /// <summary>
        /// 是否隐藏期初往来账录入
        /// </summary>
        public const string IsHidePayment = "IsHidePayment";

        /// <summary>
        /// 使用进货折扣自动算成本价
        /// </summary>
        public const string AutoCostPrice = "AutoCostPrice";

        /// <summary>
        /// 调拨直接入库
        /// </summary>
        public const string AllocateInDirectly = "AllocateInDirectly";

        /// <summary>
        ///  结算时是否四舍五入
        /// </summary>
        public const string RetailBalanceRound = "RetailBalanceRound";

        /// <summary>
        /// 批发价四舍五入取整
        /// </summary>
        public const string PfPriceRound = "PfPriceRound";

        /// <summary>
        /// 是否隐藏批发客户期初建仓功能
        /// </summary>
        public const string IsHideCreatePfStore = "IsHideCreatePfStore";

        /// <summary>
        /// 是否隐藏批发客户期初往来账录入
        /// </summary>
        public const string IsHidePfPayment = "IsHidePfPayment";
        /// <summary>
        /// POS端、小程序导购端 是否显示品牌
        /// </summary>
        public const string NotShowBrand = "NotShowBrand";

        /// <summary>
        /// 分销佣金比例
        /// </summary>
        public const string CommissionRatio = "CommissionRatio";

        /// <summary>
        /// 默认打印小票的次数
        /// </summary>
        public const string PrintCount = "PrintCount";

        /// <summary>
        /// 流水号
        /// </summary>
        public const string FlowNumber = "FlowNumber";

        /// <summary>
        /// 收银的时候售价锁定。
        /// </summary>
        public const string LockSalePriceForSale = "LockSalePriceForSale";

        /// <summary>
        /// 分销层级收益信息
        /// </summary>
        public const string DistributionInfo = "DistributionInfo";

        /// <summary>
        /// 线上订单导出设置
        /// </summary>
        public const string EmOrderExportInfo = "EmOrderExportInfo";

        /// <summary>
        /// 佣金打款方式
        /// </summary>
        public const string PfCommissionPayWay = "PfCommissionPayWay";

        /// <summary>
        /// 销售单打印类型
        /// </summary>
        public const string RetailPrintType = "RetailPrintType";
    }

    public enum RetailPrintType
    {
        /// <summary>
        /// 小票
        /// </summary>
        [Description("小票")]
        SmallTickets = 0,

        /// <summary>
        /// 销售单
        /// </summary>
        [Description("销售单")]
        Order = 1
    }

    public enum PfCommissionPayWay
    {
        /// <summary>
        /// 申请提现
        /// </summary>
        Application = 0,

        /// <summary>
        /// 后台主动打款
        /// </summary>
        Active = 1
    }
    
    public static class BoolNum
    {
        public const string False = "0";
        public const string True = "1";
    }

    public enum BarCodeTemplateEnum
    {
        CostumeID = 0,

        CostumeIDColorName,

        CostumeIDColorNameSizeName
    }
    
}
