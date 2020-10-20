using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core
{
    /// <summary>
    /// 通知自定义信息的类型
    /// </summary>
    public class NoticeInformationTypes
    {
        /// <summary>
        /// 新增分销人员。返回Distributor
        /// </summary>
        public const int InsertDistributor = 2000;

        /// <summary>
        /// 修改分销人员信息。返回Distributor
        /// </summary>
        public const int UpdateDistributor = 2001;

        /// <summary>
        /// 新增服装信息。返回List<Costume>
        /// </summary>
        public const int InsertCostumes = 2002;

        /// <summary>
        /// 修改服装信息。返回List<Costume>
        /// </summary>
        public const int UpdateCostumes = 2003;

        /// <summary>
        /// 修改配置。返回List<ParameterConfig>
        /// </summary>
        public const int UpdateParameterConfigs = 2004;

        /// <summary>
        /// 发送公告，返回Announce
        /// </summary>
        public const int SendAnnounce = 2005;

        /// <summary>
        /// 服务关闭，返回null
        /// </summary>
        public const int NoticeClose = 2006;

        /// <summary>
        /// 盘点冲单。返回string
        /// </summary>
        public const int OverrideCheckStore = 2007;

        /// <summary>
        /// 新增尺码组。返回SizeGroup
        /// </summary>
        public const int InsertSizeGroup = 2008;

        /// <summary>
        /// 修改尺码组。返回SizeGroup
        /// </summary>
        public const int UpdateSizeGroup = 2009;

        /// <summary>
        /// 删除尺码组。返回string
        /// </summary>
        public const int DeleteSizeGroup = 2010;

        /// <summary>
        /// 禁用服装信息。返回string
        /// </summary>
        public const int DisableCostume = 2011;

        /// <summary>
        /// 禁用店铺，返回string
        /// </summary>
        public const int DisableShop = 2012;

        /// <summary>
        /// 新增小类，返回CostumeClass2
        /// </summary>
        public const int InsertSmallClass = 2013;

        /// <summary>
        /// 修改小类，返回UpdateSmallClassPara
        /// </summary>
        public const int UpdateSmallClass = 2014;

        /// <summary>
        /// 删除某个大类下的指定小类。返回DeleteSmallClassPara
        /// </summary>
        public const int DeleteSmallClass = 2015;

        /// <summary>
        /// 新增次小类。返回CostumeClass2
        /// </summary>
        public const int InsertSubSmallClass = 2016;

        /// <summary>
        /// 修改次小类。返回UpdateSubSmallClassPara
        /// </summary>
        public const int UpdateSubSmallClass = 2017;

        /// <summary>
        /// 删除次小类。返回DeleteSubSmallClassPara
        /// </summary>
        public const int DeleteSubSmallClass = 2018;

        /// <summary>
        /// 服装生成条形码。返回string
        /// </summary>
        public const int CreateCostumeBarCode = 2019;

        /// <summary>
        /// 供应商导入。返回List<Supplier>
        /// </summary>
        public const int ImportSupplier = 2020;

        /// <summary>
        /// 客户导入。返回List<PfCustomer>
        /// </summary>
        public const int ImportPfCustomer = 2021;

        /// <summary>
        /// 品牌导入。返回List<Brand>
        /// </summary>
        public const int ImportBrand = 2022;

        /// <summary>
        /// 删除店铺，返回string
        /// </summary>
        public const int DeleteShop = 2023;

        /// <summary>
        /// 删除导购员。返回List<string>
        /// </summary>
        public const int DeleteGuides = 2024;









        /// <summary>
        /// 新增导购员。返回Guide
        /// </summary>
        public const int InsertGuide = 2900;
        
        /// <summary>
        /// 修改导购员。返回Guide
        /// </summary>
        public const int UpdateGuide = 2901;

        /// <summary>
        /// 删除导购员。返回string
        /// </summary>
        public const int DeleteGuide = 2902;
        
        /// <summary>
        /// 充值赠送规则发生改变。返回RechargeDonateRule
        /// </summary>
        public const int UpdateRechargeDonateRule = 2903;

        /// <summary>
        /// 店铺的充值赠送规则发生改变。返回RechargeDonateRule（后台：List<UpdateShopRechargeRuleIDPara>）
        /// </summary>
        public const int UpdateShopRechargeRuleID = 2904;

        /// <summary>
        /// 删除充值赠送规则。返回int
        /// </summary>
        public const int DeleteRechargeDonateRule = 2905;

        /// <summary>
        /// 新增促销活动。返回SalesPromotion
        /// </summary>
        public const int InsertSalesPromotion = 2906;

        /// <summary>
        /// 修改促销活动。返回SalesPromotion
        /// </summary>
        public const int UpdateSalesPromotion = 2907;

        /// <summary>
        /// 删除促销活动。返回string
        /// </summary>
        public const int DeleteSalesPromotion = 2908;

        /// <summary>
        /// 新增服装大类。返回CostumeClass2
        /// </summary>
        public const int InsertBigCostumeClass = 2909;

        /// <summary>
        /// 修改服装大类。返回UpdateBigClassPara
        /// </summary>
        public const int UpdateBigCostumeClass = 2910;

        /// <summary>
        /// 删除服装大类。返回DeleteBigCostumeClassPara
        /// </summary>
        public const int DeleteBigCostumeClass = 2911;
        
        /// <summary>
        /// 新增服装信息。返回Costume
        /// </summary>
        public const int InsertCostume = 2912;

        /// <summary>
        /// 修改服装信息。返回Costume
        /// </summary>
        public const int UpdateCostume = 2913;

        /// <summary>
        /// 删除服装信息。返回string
        /// </summary>
        public const int DeleteCostume = 2914;

        /// <summary>
        /// 新增品牌。返回Brand
        /// </summary>
        public const int InsertBrand = 2915;

        /// <summary>
        /// 修改品牌。返回Brand
        /// </summary>
        public const int UpdateBrand = 2916;

        /// <summary>
        /// 删除品牌。返回int
        /// </summary>
        public const int DeleteBrand = 2917;

        /// <summary>
        /// 新增店铺。返回Shop
        /// </summary>
        public const int InsertShop = 2918;

        /// <summary>
        /// 修改店铺。返回Shop
        /// </summary>
        public const int UpdateShop = 2919;
        
        /// 新增后台管理用户。返回AdminUser
        /// </summary>
        public const int InsertAdminUser = 2920;

        /// <summary>
        /// 修改后台管理用户。返回AdminUser
        /// </summary>/// <summary>
        public const int UpdateAdminUser = 2921;

        /// <summary>
        /// 新增颜色。返回CostumeColor
        /// </summary>
        public const int InsertCostumeColor = 2922;

        /// <summary>
        /// 修改颜色。返回CostumeColor
        /// </summary>
        public const int UpdateCostumeColor = 2923;

        /// <summary>
        /// 删除颜色。返回string
        /// </summary>
        public const int DeleteCostumeColor = 2924;

        /// <summary>
        /// 修改配置。返回ParameterConfig
        /// </summary>
        public const int UpdateParameterConfig = 2925;

        /// <summary>
        /// 修改供应商。返回Supplier
        /// </summary>
        public const int UpdateSupplier = 2926;

        /// <summary>
        /// 新增供应商。返回Supplier
        /// </summary>
        public const int InsertSupplier = 2927;

        /// <summary>
        /// 删除供应商。返回string
        /// </summary>
        public const int DeleteSupplier = 2928;

        /// <summary>
        /// 生成差异单。返回int
        /// </summary>
        public const int InsertDifferenceOrder = 2929;
        
        /// <summary>
        /// 补货申请。返回int（补货申请单申请有多少条需要处理）
        /// </summary>
        public const int ReplenishCostume = 2930;

        /// <summary>
        /// 调拨。返回int（调拨有多少条需要处理）
        /// </summary>
        public const int AllocateOutbound = 2931;

        /// <summary>
        /// 补货出库。返回int（补货出库有多少条需要处理）
        /// </summary>
        public const int ReplenishOutbound = 2932;
        
        /// <summary>
        /// 冲单通知。返回string
        /// </summary>
        public const int OverrideOrder = 2933;

        /// <summary>
        /// 新增后台管理用户。返回string
        /// </summary>
        public const int DeleteAdminUser = 2934;

        /// <summary>
        /// 取消补货申请单。返回string
        /// </summary>
        public const int CancelReplenish = 2935;

        /// <summary>
        /// 新增盘点单。返回null
        /// </summary>
        public const int InsertCheckStore = 2936;

        /// <summary>
        /// 盘点审核通过。返回string
        /// </summary>
        public const int CheckStorePass = 2937;

        /// <summary>
        /// 退回盘点单。返回string
        /// </summary>
        public const int CancelCheckStore = 2938;

        /// <summary>
        /// 取消盘点。返回string
        /// </summary>
        public const int CancelCheckStoreTask = 2939;

        /// <summary>
        /// 新增条形码。返回BarCode
        /// </summary>
        public const int InsertBarCode = 2940;

        /// <summary>
        /// 是否启用尺码组。返回EnabledSizeGroupPara
        /// </summary>
        public const int EnabledSizeGroup = 2941;

        /// <summary>
        /// 修改条形码。返回BarCode
        /// </summary>
        public const int UpdateBarCode = 2942;

        /// <summary>
        /// 修改服装有哪些尺码。返回UpdateSizeNamesInfo
        /// </summary>
        public const int UpdateSizeNames = 2943;

        /// <summary>
        /// 修改服装分类序号。返回List<CostumeClassOrderNo>
        /// </summary>
        public const int UpdateCostumeClassOrderNo = 2944;

        /// <summary>
        /// 有线上订单申请退货。返回int
        /// </summary>
        public const int NewEmRefundOrder = 2945;

        /// <summary>
        /// 有新的线上订单生成，返回int
        /// </summary>
        public const int NewEmRetailOrder = 2946;

        /// <summary>
        /// 修改服装是否有效，返回UpdateCostumeValidPara
        /// </summary>
        public const int UpdateCostumeValid = 2947;

        /// <summary>
        /// 修改小程序码或小程序二维码 图片 （打印小票用），返回UpdateEMallPhotoPara
        /// </summary>
        public const int UpdateEMallMiniProgramImg = 2948;

        /// <summary>
        /// 期初库存录入。返回null
        /// </summary>
        public const int InsertCostumeStores = 2949;

        /// <summary>
        /// 新增 批发客户 信息。返回PfCustomer
        /// </summary>
        public const int InsertPfCustomer = 2950;

        /// <summary>
        /// 修改 批发客户 信息。返回PfCustomer
        /// </summary>
        public const int UpdatePfCustomer = 2951;

        /// <summary>
        /// 删除 批发客户 信息。返回string
        /// </summary>
        public const int DeletePfCustomer = 2952;

        /// <summary>
        /// 批发客户期初库存录入
        /// </summary>
        public const int InsertPfCostumeStores = 2953;
         

    }

    public class UpdateSizeNamesInfo
    {
        public Dictionary<string, string> SizeNamesDict { get; set; }
    }
}
