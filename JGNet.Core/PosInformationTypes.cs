using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    /// <summary>
    /// Pos自定义信息的类型
    /// </summary>
    public class PosInformationTypes
    {
        /// <summary>
        /// 销售。参数为RetailCostume， 返回InteractResult
        /// </summary>
        public const int RetailCostume = 5000;
        
        /// <summary>
        /// 获取店铺信息。参数string，返回Shop
        /// </summary>
        public const int GetOneShop = 5001;

        /// <summary>
        /// 获取所有店铺信息。参数null, 返回List<Shop>
        /// </summary>
        public const int GetAllShop = 5002;

        /// <summary>
        /// 获取所有开启的促销活动。参数string, 返回List<SalesPromotion>
        /// </summary>
        public const int GetOpenSalesPromotionList = 5003;

        /// <summary>
        /// 退货。参数为RefundCostume， 返回InteractResult
        /// </summary>
        public const int RefundCostume = 5004;

        /// <summary>
        /// 获取一笔销售单。参数为string， 返回RetailCostume
        /// </summary>
        public const int GetOneRetailCostume = 5005;
        
        /// <summary>
        /// 获取充值赠送规则。参数为int，返回RechargeDonateRule。
        /// </summary>
        public const int GetRechargeDonateRule = 5006;

        /// <summary>
        /// 获取促销活动。参数string, 返回SalesPromotion
        /// </summary>
        public const int GetOneSalesPromotion = 5007;

        /// <summary>
        /// 补货申请。参数ReplenishCostume，返回InteractResult
        /// </summary>
        public const int ReplenishCostume = 5008;
        
        /// <summary>
        /// 自动补货。参数AutoReplenishCostumePara, 返回List<ReplenishDetail>
        /// </summary>
        public const int AutoReplenishCostume = 5009;
        
        /// <summary>
        /// 获取盘点单。参数string，返回CheckStoreOrder
        /// </summary>
        public const int GetCheckStoreOrder = 5010;
        
        /// <summary>
        /// 获取供应商信息。参数null，返回List<Supplier>
        /// </summary>
        public const int GetAllSupplier = 5011;
        
        /// <summary>
        /// 获取所有会员。参数null，返回List<Member>
        /// </summary>
        public const int GetAllMember = 5012;
        
        /// <summary>
        /// 获取所有导购员。参数null，返回List<Guide>
        /// </summary>
        public const int GetAllGuide = 5013;
        
        /// <summary>
        /// 根据单据编号查询差异单信息。参数string，返回DifferenceOrder
        /// </summary>
        public const int GetDifferenceOrder4ID = 5014;
        
        /// <summary>
        /// 根据来源单据获取入库单。参数string，返回InboundOrder
        /// </summary>
        public const int GetInboundOrder4SourceOrderID = 5015;

        /// <summary>
        /// 根据来源单据获取出库单。参数string，返回OutboundOrder
        /// </summary>
        public const int GetOutboundOrder4SourceOrderID = 5016;
        
        /// <summary>
        /// 根据销售单id模糊查询。参数string，返回List<RetailOrder>
        /// </summary>
        public const int GetRetailOrder4ID = 5017;

        /// <summary>
        /// 获取提前多少天到今天范围内的销售单。参数RetailOrderAdvancePara，返回List<RetailOrder>
        /// </summary>
        public const int GetRetailOrderAdvance = 5018;
        
        /// <summary>
        /// 打卡。参数SignRecord，返回SignResult
        /// </summary>
        public const int Sign = 5019;

        /// <summary>
        /// 是否已经打卡。参数SignRecord，返回int（1：已打卡，0：未打卡， -1：发生异常）
        /// </summary>
        public const int IsSign = 5020;

        /// <summary>
        /// 库存信息是否有记录。参数CheckCostumeStore，返回int（1：存在，0：不存在， -1：发生异常）
        /// </summary>
        public const int IsCostumeStoreExist = 5021;
        
        /// <summary>
        /// 获取会员有效的电子优惠券列表。参数string，返回List<GiftTicket>
        /// </summary>
        public const int GetValidGiftTickets = 5022;

        /// <summary>
        /// 获取销售单id。参数null，返回string
        /// </summary>
        public const int GetRetailOrderID = 5023;

        /// <summary>
        /// 获取销售明细中的电子优惠券。参数string，返回List<GiftTicket>
        /// </summary>
        public const int GetGiftTicket4RetailDetail = 5024;

        /// <summary>
        /// 检查服装是否有效。参数List<string>，返回InteractResult
        /// </summary>
        public const int IsCostumeValid = 5025;

        /// <summary>
        /// 补货挂单。参数ReplenishCostume，返回InteractResult
        /// </summary>
        public const int HangUpReplenish = 5026;

        /// <summary>
        /// 获取挂单状态的补货单。
        /// </summary>
        public const int GetHangUpReplenishOrders = 5027;

        /// <summary>
        /// 删除挂单状态的补货单
        /// </summary>
        public const int DeleteHangUpReplenishOrder = 5028;
    }
}
