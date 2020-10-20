using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core
{
    /// <summary>
    /// Manage自定义信息的类型
    /// </summary>
    public class ManageInformationTypes
    {
        /// <summary>
        /// 补全缺失的基础数据
        /// </summary>
        public const int CheckBaseData = 4000;

        /// <summary>
        /// 获取店铺收款汇总
        /// </summary>
        public const int GetRetailSummary = 4001;

        /// <summary>
        /// 获取售价管理信息。
        /// </summary>
        public const int GetShopCostumePrices = 4002;

        /// <summary>
        /// 修改店铺库存吊牌价
        /// </summary>
        public const int UpdateShopCostumePrice = 4003;

        /// <summary>
        /// 获取采购汇总
        /// </summary>
        public const int GetPurchaseSummary = 4004;

        /// <summary>
        /// 自动生成款号id
        /// </summary>
        public const int GetAutoCostumeID = 4005;

        /// <summary>
        /// 报损冲单
        /// </summary>
        public const int CancelScrap = 4006;

        /// <summary>
        /// 获取采购明细
        /// </summary>
        public const int GetPurchaseDetails = 4007;

        /// <summary>
        /// 采购进货冲单
        /// </summary>
        public const int CancelPurchase = 4008;

        /// <summary>
        /// 采购退货冲单
        /// </summary>
        public const int CancelReturn = 4009;

        /// <summary>
        /// 批发发货冲单
        /// </summary>
        public const int CancelPfDelivery = 4010;

        /// <summary>
        /// 批发退货冲单
        /// </summary>
        public const int CancelPfReturn = 4011;

        /// <summary>
        /// 禁用服装
        /// </summary>
        public const int DisableCostume = 4012;
        
        /// <summary>
        /// 新增充值规则。参数RechargeDonateRule，返回InsertResultAndAutoID
        /// </summary>
        public const int InsertRechargeDonateRule = 4013;

        /// <summary>
        /// 修改充值规则。参数UpdateRechargeDonateRulePara，返回UpdateRechargeDonateRuleResult
        /// </summary>
        public const int UpdateRechargeDonateRule = 4014;
        
        /// <summary>
        /// 新增促销活动。参数SalesPromotion，返回InsertResult
        /// </summary>
        public const int InsertSalesPromotion = 4015;

        /// <summary>
        /// 修改促销活动。参数SalesPromotion，返回UpdateResult
        /// </summary>
        public const int UpdateSalesPromotion = 4016;
        
        /// <summary>
        /// 修改配置。参数ParameterConfig,返回UpdateResult
        /// </summary>
        public const int UpdateParameterConfig = 4017;
        
        /// <summary>
        /// 新增导购员。参数Guide
        /// </summary>
        public const int InsertGuide = 4018;

        /// <summary>
        /// 修改导购员。参数Guide
        /// </summary>
        public const int UpdateGuide = 4019;

        /// <summary>
        /// 新增供应商。参数Supplier，返回InteractResult
        /// </summary>
        public const int InsertSupplier = 4020;

        /// <summary>
        /// 修改供应商。参数Supplier，返回InteractResult
        /// </summary>
        public const int UpdateSupplier = 4021;

        /// <summary>
        /// 查询供应商列表。参数null，返回List<Supplier>
        /// </summary>
        public const int GetSupplierList = 4022;

        /// <summary>
        /// 新增服装信息。参数Costume，返回InsertCostumeResult
        /// </summary>
        public const int InsertCostume = 4023;

        /// <summary>
        /// 修改服装信息。参数Costume,返回InteractResult
        /// </summary>
        public const int UpdateCostume = 4024;

        /// <summary>
        /// 删除供应商。参数string，返回InteractResult
        /// </summary>
        public const int DeleteSupplier = 4025;

        /// <summary>
        /// 删除导购员。参数string，返回DeleteResult
        /// </summary>
        public const int DeleteGuide = 4026;

        /// <summary>
        /// 逻辑删除促销活动。参数string，返回DeleteResult
        /// </summary>
        public const int DeleteSalesPromotion = 4027;

        /// <summary>
        /// 删除充值赠送规则。参数int，返回DeleteResult
        /// </summary>
        public const int DeleteRechargeDonateRule = 4028;

        /// <summary>
        /// 获取店铺列表。参数null，返回List<Shop>
        /// </summary>
        public const int GetShopList = 4029;

        /// <summary>
        /// 根据id或者名称查询供应商信息。参数string，返回List<Supplier>
        /// </summary>
        public const int GetSupplierList4IDOrName = 4030;

        /// <summary>
        /// 修改店铺的充值赠送规则。参数List<UpdateShopRechargeRuleIDPara>，返回UpdateResult
        /// </summary>
        public const int UpdateShopRechargeRuleID = 4031;

        /// <summary>
        /// 补货发货。参数Outbound,返回InteractResult
        /// </summary>
        public const int ReplenishOutbound = 4032;

        /// <summary>
        /// 新增颜色。参数CostumeColor，返回InteractResult
        /// </summary>
        public const int InsertCostumeColor = 4033;

        /// <summary>
        /// 修改颜色。参数CostumeColor，返回InteractResult
        /// </summary>
        public const int UpdateCostumeColor = 4034;

        /// <summary>
        /// 删除颜色。参数string，返回InteractResult
        /// </summary>
        public const int DeleteCostumeColor = 4035;

        /// <summary>
        /// 新增品牌。参数Brand，返回InteractResult
        /// </summary>
        public const int InsertBrand = 4036;

        /// <summary>
        /// 修改品牌。参数Brand，返回InteractResult
        /// </summary>
        public const int UpdateBrand = 4037;

        /// <summary>
        /// 删除品牌。参数int，返回InteractResult
        /// </summary>
        public const int DeleteBrand = 4038;

        /// <summary>
        /// 新增服装大类。
        /// </summary>
        public const int InsertBigCostumeClass = 4039;

        /// <summary>
        /// 修改服装分类。
        /// </summary>
        public const int UpdateBigCostumeClass = 4040;

        /// <summary>
        /// 删除服装分类。参数string，返回InteractResult
        /// </summary>
        public const int DeleteBigCostumeClass = 4041;

        /// <summary>
        /// 促销活动已有商品参与。参数string，返回IsSalesPromotionUseResult
        /// </summary>
        public const int IsSalesPromotionUse = 4042;
        
        /// <summary>
        /// 逻辑删除服装。参数string，返回DeleteResult
        /// </summary>
        public const int DeleteCostume = 4043;

        /// <summary>
        /// 采购进货。参数PurchaseCostume，返回InteractResult
        /// </summary>
        public const int PurchaseCostume = 4044;

        /// <summary>
        /// 根据补货申请单信息，返回对应的库存信息。参数CostumeStore4ReplenishInfoPara，返回List<CostumeStore>
        /// </summary>
        public const int GetCostumeStore4ReplenishInfo = 4045;

        /// <summary>
        /// 采购退货（给供应商）。参数ReturnCostume，返回InteractResult
        /// </summary>
        public const int ReturnCostume = 4046;

        /// <summary>
        /// 获取采购进货分页信息。参数PurchaseCostumePagePara，返回PurchaseCostumePage。
        /// </summary>
        public const int GetPurchaseCostumePage = 4047;
        
        /// <summary>
        /// 新增店铺。参数Shop，返回InsertShopGetAutoCode
        /// </summary>
        public const int InsertShop = 4048;

        /// <summary>
        /// 修改店铺。参数Shop，返回UpdateShopResult
        /// </summary>
        public const int UpdateShop = 4049;

        /// <summary>
        /// 新增后台管理用户。参数AdminUser
        /// </summary>
        public const int InsertAdminUser = 4050;

        /// <summary>
        /// 修改后台管理用户。参数AdminUse
        /// </summary>
        public const int UpdateAdminUser = 4051;
        
        /// <summary>
        /// 获取总仓库存信息（分页），根据款号id，模糊查询。参数CostumeStore4GeneralStorePagePara，返回CostumeStore4GeneralStorePage
        /// </summary>
        public const int GetCostumeStore4GeneralStorePage = 4052;

        /// <summary>
        /// 获取单商品的库存信息（所有店铺，精确查询）。参数string，返回List<CostumeStore>
        /// </summary>
        public const int GetOneCostumeStoreInAllShop = 4053;
        
        /// <summary>
        /// 获取采购退货分页信息。参数ReturnOrderPagePara，返回ReturnOrderPage
        /// </summary>
        public const int GetReturnOrderPage = 4054;
        
        /// <summary>
        /// 删除后台管理用户。参数string，返回DeleteAdminUserResult
        /// </summary>
        public const int DeleteAdminUser = 4055;
        
        /// <summary>
        /// 今天之前的日报表是否手动结存。参数string，返回IsDayReportManualConfirmResult
        /// </summary>
        public const int IsLastDayReportManualConfirm = 4056;

        /// <summary>
        /// 获取今天之前未手动结存的日报。参数string，返回DayReport
        /// </summary>
        public const int GetLastDayReport = 4057;

        /// <summary>
        /// 报损。参数ScrapCostume，返回InteractResult
        /// </summary>
        public const int Scrap = 4058;
        
        /// <summary>
        /// 获取报损单明细。参数string，返回List<ScrapDetail>
        /// </summary>
        public const int GetScrapDetails = 4059;

        /// <summary>
        /// 在途库存。参数TransitCostumeStorePara，返回List<TransitCostumeStore>
        /// </summary>
        public const int TransitCostumeStore = 4060;

        /// <summary>
        /// 检查某一款某一颜色库存是否为0，返回InteractResult
        /// </summary>
        public const int IsCostumeStoreCountZero = 4061;

        /// <summary>
        /// 禁用店铺，返回InteractResult
        /// </summary>
        public const int DisableShop = 4062;

        /// <summary>
        /// 修改批发客户往来账
        /// </summary>
        public const int UpdatePfAccountRecord = 4063;

        /// <summary>
        /// 删除批发客户往来账
        /// </summary>
        public const int DeletePfAccountRecord = 4064;

        /// <summary>
        /// 修改供应商往来账
        /// </summary>
        public const int UpdateSupplierAccountRecord = 4065;

        /// <summary>
        /// 删除供应商往来账
        /// </summary>
        public const int DeleteSupplierAccountRecord = 4066;

        /// <summary>
        /// 根据品牌 名称/编号 模糊查询。
        /// </summary>
        public const int GetBrands4IdOrName = 4067;

        /// <summary>
        /// 根据色号/名称模糊查询颜色
        /// </summary>
        public const int GetCostumeColor4IDOrName = 4068;

        /// <summary>
        /// 新增小类
        /// </summary>
        public const int InsertSmallClass = 4069;

        /// <summary>
        /// 修改小类
        /// </summary>
        public const int UpdateSmallClass = 4070;

        /// <summary>
        /// 新增次小类
        /// </summary>
        public const int InsertSubSmallClass = 4071;

        /// <summary>
        /// 修改次小类
        /// </summary>
        public const int UpdateSubSmallClass = 4072;

        /// <summary>
        /// 删除次小类
        /// </summary>
        public const int DeleteSubSmallClass = 4073;

        /// <summary>
        /// 删除季节
        /// </summary>
        public const int DeleteSeason = 4074;

        /// <summary>
        /// 修改季节
        /// </summary>
        public const int UpdateSeason = 4075;

        /// <summary>
        /// 检查款号尺码库存是否为0
        /// </summary>
        public const int CheckCostumeSize = 4076;







        /// <summary>
        /// 获取某一月所有店铺的营业月报。参数GetReportsPara，返回List<MonthBenefitReport>
        /// </summary>
        public const int GetAllShopMonthBenefitReport4ReportMonth = 4150;

        /// <summary>
        /// 获取畅滞排行榜各店铺信息。参数SalesQuantityRankingsPara，返回List<SalesQuantityRanking>
        /// </summary>
        public const int GetSalesQuantityRankings = 4151;

        /// <summary>
        /// 新增月销售任务。参数MonthTask，返回InsertMonthTaskResult
        /// </summary>
        public const int InsertMonthTask = 4152;
        
        /// <summary>
        /// 新增供应商往来账。
        /// </summary>
        public const int InsertSupplierAccountRecord = 4153;

        /// <summary>
        /// 上传服装图片。参数UploadCostumePhotoPara
        /// </summary>
        public const int UploadCostumePhoto = 4154;

        /// <summary>
        /// 获取供应商往来账分页信息。参数SupplierAccountRecordPagePara，返回SupplierAccountRecordPage
        /// </summary>
        public const int GetSupplierAccountRecordPage = 4155;
        
        /// <summary>
        /// 获取 供应商往来账 详情，参数string，返回SupplierAccountRecordDetailInfo
        /// </summary>
        public const int GetSupplierAccountRecordDetailInfo = 4156;
        
        /// <summary>
        /// 修改 月支出 列表。参数List<MonthExpenseInfo>，返回UpdateResult
        /// </summary>
        public const int UpdateMonthExpenses = 4157;

        /// <summary>
        /// 获取 运营信息。参数null，返回OperationInfo
        /// </summary>
        public const int GetOperationInfo = 4158;
        
        /// <summary>
        /// 获取 盘点汇总 分页信息。参数GetCheckStoreSummaryPagePara，返回CheckStoreSummaryPage
        /// </summary>
        public const int GetCheckStoreSummaryPage = 4159;

        /// <summary>
        /// 修改 盘点汇总 平均售价。参数AveragePrice2AndWinLostMoney,返回UpdateResult
        /// </summary>
        public const int UpdateAveragePrice2AndWinLostMoney = 4160;

        /// <summary>
        /// 将图片上传到腾讯云。参数PhotoDatas
        /// </summary>
        public const int UploadPhotoToCos = 4161;

        /// <summary>
        /// 将腾讯云的图片删除。参数string，返回DeleteResult
        /// </summary>
        public const int DeletePhotoToCos = 4162;

        /// <summary>
        /// 修改图片显示的顺利。参数List<UpdateDisplayIndex>， 返回UpdateResult
        /// </summary>
        public const int UpdateDisplayIndexs = 4163;

        /// <summary>
        /// 将线上商城的宣传海报图片上传到腾讯云。参数PosterImage
        /// </summary>
        public const int UploadPosterImageToCos = 4164;

        /// <summary>
        /// 将线上商城的宣传海报图片从腾讯云删除。参数DeletePosterImagePara，返回DeleteResult
        /// </summary>
        public const int DeletePosterImageToCos = 4165;

        /// <summary>
        /// 新增 电子优惠券类别。参数GiftTicketTemplate，返回InsertResult
        /// </summary>
        public const int InsertGiftTicketTemplate = 4166;

        /// <summary>
        /// 修改 电子优惠券类别。参数GiftTicketTemplate，返回UpdateResult
        /// </summary>
        public const int UpdateGiftTicketTemplate = 4167;

        /// <summary>
        /// 删除 电子优惠券类别。参数int，返回DeleteResult
        /// </summary>
        public const int DeleteGiftTicketTemplate = 4168;

        /// <summary>
        ///  获取 电子优惠券类别分页信息。参数GiftTicketTemplatePagePara，返回GiftTicketTemplatePage
        /// </summary>
        public const int GetGiftTicketTemplatePage = 4169;

        /// <summary>
        /// 获取 电子优惠券类别列表。参数null，返回List<GiftTicketTemplate>
        /// </summary>
        public const int GetGiftTicketTemplates = 4170;
        
        /// <summary>
        /// 设置服装使用电子优惠券情况。参数CostumeGiftTicketInfo，返回UpdateResult
        /// </summary>
        public const int UpdateCostumeGiftTicket = 4171;
       
        /// <summary>
        /// 获取 进销存日报 列表信息。参数InventoryDayReportsPara，返回List<InventoryDayReport>
        /// </summary>
        public const int GetInventoryDayReports = 4172;

        /// <summary>
        /// 获取 商品价格区间简报。
        /// </summary>
        public const int GetPriceRangeReports = 4173;

        /// <summary>
        /// 获取 各店铺商品价格区间简报。参数GetShopPriceRangeReportPara，返回List<PriceRangeReport>
        /// </summary>
        public const int GetShopPriceRangeReport = 4174;

        /// <summary>
        /// 获取 导购端回访会员功能的参数设置。参数null，返回GuideReturnVisitPara
        /// </summary>
        public const int GetGuideReturnVisitPara = 4175;

        /// <summary>
        /// 修改 导购端回访会员功能的参数设置。参数GuideReturnVisitPara，返回UpdateResult
        /// </summary>
        public const int UpdateGuideReturnVisitPara = 4176;
        
        /// <summary>
        /// 获取 库存分析。参数GetCostumeStoreAnalysisPara，返回List<CostumeStoreAnalysisData>
        /// </summary>
        public const int GetCostumeStoreAnalysis = 4178;

        /// <summary>
        /// 修改服装分类序号。参数List<CostumeClassOrderNo>，返回UpdateResult
        /// </summary>
        public const int UpdateCostumeClassOrderNo = 4179;

        /// <summary>
        /// 根据来源单据编号获取供应商往来账详情信息。参数string，返回List<BoundDetail>
        /// </summary>
        public const int GetDetail4SupplierAccountRecord = 4180;

        /// <summary>
        /// 判断一款衣服库存是否为0。参数string，返回WebResponseObj<bool>
        /// </summary>
        public const int IsCostumeStoreZero = 4181;

        /// <summary>
        /// 修改服装是否有效。参数UpdateCostumeValidPara，返回InteractResult
        /// </summary>
        public const int UpdateCostumeValid = 4182;

        /// <summary>
        /// 期初库存录入。参数CreateCostumeStore，返回InteractResult
        /// </summary>
        public const int InsertCostumeStores = 4183;

        /// <summary>
        /// 获取库存信息。参数string，返回CostumeStoreInfoSum
        /// </summary>
        public const int GetCostumeStores = 4184;

        /// <summary>
        /// 隐藏起初建仓功能。参数null，返回InteractResult
        /// </summary>
        public const int HideCreateStore = 4185;

        /// <summary>
        /// 删除某个大类下的指定小类。参数string，返回InteractResult
        /// </summary>
        public const int DeleteSmallClass = 4186;
        
        /// <summary>
        /// 批发客户充值。参数PfCustomerRechargeRecord，返回InteractResult
        /// </summary>
        public const int InsertPfCustomerRechargeRecord = 4187;

        /// <summary>
        /// 批发发货。参数PfDeliveryInfo，返回InteractResult
        /// </summary>
        public const int PfDelivery = 4188;

        /// <summary>
        /// 批发退货。参数PfDeliveryInfo，返回InteractResult
        /// </summary>
        public const int PfReturn = 4189;

        /// <summary>
        /// 获取 批发客户库存分页信息。参数GetPfCustomerStorePagePara，返回PfCustomerStorePage
        /// </summary>
        public const int GetPfCustomerStorePage = 4190;

        /// <summary>
        /// 批发客户销售。参数PfCustomerRetailInfo，返回InteractResult
        /// </summary>
        public const int PfCustomerRetail = 4191;

        /// <summary>
        /// 批发客户销售单分页查询。参数GetCustomerRetailPagePara,返回CustomerRetailPage
        /// </summary>
        public const int GetCustomerRetailPage = 4192;

        /// <summary>
        /// 获取批发客户销售单明细。参数string，返回List<PfCustomerRetailDetail>
        /// </summary>
        public const int GetPfCustomerRetailDetails = 4193;

        /// <summary>
        /// 修改批发客户销售。参数PfCustomerRetailInfo，返回InteractResult
        /// </summary>
        public const int UpdatePfCustomerRetail = 4194;

        /// <summary>
        /// 批发客户期初库存录入。参数CreatePfCostumeStore，返回InteractResult
        /// </summary>
        public const int InsertPfCostumeStores = 4195;

        /// <summary>
        /// 获取批发客户期初库存信息。参数null，返回List<PfCustomerStore>
        /// </summary>
        public const int GetPfCostumeStores = 4196;

        /// <summary>
        /// 批发客户往来账记账。参数PfAccountRecord，返回InteractResult
        /// </summary>
        public const int InsertPfAccountRecord = 4197;

        /// <summary>
        /// 获取批发客户库存信息。参数string，返回PfCostumeStoreInfo
        /// </summary>
        public const int GetPfCostumeStoreInfo = 4198;

        /// <summary>
        /// 获取客户往来账明细分页信息。参数GetPfAccountRecordPagePara，返回PfAccountRecordPage
        /// </summary>
        public const int GetPfAccountRecordPage = 4199;

        /// <summary>
        /// 获取服装颜色id。参数null，返回InteractResult
        /// </summary>
        public const int GetCostumeColorId = 4200;

        /// <summary>
        /// 获取供应商id。参数null，返回InteractResult
        /// </summary>
        public const int GetSupplierId = 4201;

        /// <summary>
        /// 获取导购员id。参数null，返回InteractResult
        /// </summary>
        public const int GetGuideId = 4202;

        /// <summary>
        /// 获取批发客户余额变化分页信息
        /// </summary>
        public const int GetPfCustomerBalanceRecordPage = 4203;

        /// <summary>
        /// 获取客户往来账明细（发货，退货，线上订单付款）
        /// </summary>
        public const int GetPfAccountRecordDetails = 4204;

        /// <summary>
        /// 获取批发客户id。
        /// </summary>
        public const int GetPfCustomerId = 4205;

        /// <summary>
        /// 获取批发客户库存信息
        /// </summary>
        public const int GetPfCustomerStores = 4206;

        /// <summary>
        /// 删除批发客户销售单
        /// </summary>
        public const int DeletePfCustomerRetailOrder = 4207;

        /// <summary>
        /// 修改展示的尺码
        /// </summary>
        public const int UpdateShowSizeName = 4208;

        /// <summary>
        /// 获取批发客户商品批发价格
        /// </summary>
        public const int GetCostumePfPrice = 4209;

        /// <summary>
        /// 批发发货挂单。参数PfInfo，返回InteractResult
        /// </summary>
        public const int HangUpPfDelivery = 4210;

        /// <summary>
        /// 批发退货挂单。参数PfInfo，返回InteractResult
        /// </summary>
        public const int HangUpPfReturn = 4211;

        /// <summary>
        /// 采购进货挂单。参数PurchaseCostume，返回InteractResult
        /// </summary>
        public const int HangUpPurchase = 4212;

        /// <summary>
        /// 采购退货挂单。参数ReturnCostume，返回InteractResult
        /// </summary>
        public const int HangUpReturn = 4213;

        /// <summary>
        /// 获取挂单的采购单
        /// </summary>
        public const int GetHangUpPurchases = 4214;

        /// <summary>
        /// 删除挂单的采购单
        /// </summary>
        public const int DeleteHangUpPurchase = 4215;

        /// <summary>
        /// 获取挂单的批发单
        /// </summary>
        public const int GetHangUpPfs = 4216;

        /// <summary>
        /// 删除挂单的批发单
        /// </summary>
        public const int DeleteHangUpPf = 4217;
    }
}
