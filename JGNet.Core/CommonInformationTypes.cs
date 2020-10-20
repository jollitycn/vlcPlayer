using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core
{
    public class CommonInformationTypes
    {
        /// <summary>
        /// 库存变化查询
        /// </summary>
        public const int GetCostumeStoreChange = 1000;

        /// <summary>
        /// 取消差异单
        /// </summary>
        public const int CancelDifferenceOrder = 1001;

        /// <summary>
        /// 拒绝补货申请单
        /// </summary>
        public const int RefusedReplenishOrder = 1002;

        /// <summary>
        /// 进货库存变化查询
        /// </summary>
        public const int GetCostumeStoreChange4In = 1003;

        /// <summary>
        /// 转入库存变化查询
        /// </summary>
        public const int GetCostumeStoreChange4Into = 1004;

        /// <summary>
        /// 退货库存变化查询
        /// </summary>
        public const int GetCostumeStoreChange4Return = 1005;

        /// <summary>
        /// 转出库存变化查询
        /// </summary>
        public const int GetCostumeStoreChange4TurnOut = 1006;

        /// <summary>
        /// 销售库存变化查询
        /// </summary>
        public const int GetCostumeStoreChange4Retail = 1007;

        /// <summary>
        /// 报损库存变化查询
        /// </summary>
        public const int GetCostumeStoreChange4Scrap = 1008;

        /// <summary>
        /// 盈亏库存变化查询
        /// </summary>
        public const int GetCostumeStoreChange4Profit = 1009;

        /// <summary>
        /// 获取库存的吊牌价
        /// </summary>
        public const int GetCostumeStorePrice = 1010;

        /// <summary>
        /// 盘点单获取历史库存
        /// </summary>
        public const int GetCostumeStoreHistory4CheckStore = 1011;

        /// <summary>
        /// 盘点冲单
        /// </summary>
        public const int OverrideCheckStore = 1012;

        /// <summary>
        /// 获取本店库存情况（补全库存不存在信息）。参数CostumeStoreListPara，返回List<CostumeStoreResult>
        /// </summary>
        public const int GetCostumeStores = 1013;

        /// <summary>
        /// 调拨单挂单。参数AllocateOutboundPara，返回InteractResult
        /// </summary>
        public const int HangUpAllocateOrder = 1014;

        /// <summary>
        /// 删除挂单的调拨单。
        /// </summary>
        public const int DeleteUpAllocateOrder = 1015;

        /// <summary>
        /// 获取自动生成条形码
        /// </summary>
        public const int GetBarCode4Costume = 1016;

        /// <summary>
        /// 禁用批发客户
        /// </summary>
        public const int DisablePfCustomer = 1017;

        /// <summary>
        /// 根据类别id获取类别编码
        /// </summary>
        public const int GetClassCode4ID = 1018;

        /// <summary>
        /// 根据类别编码获取类别
        /// </summary>
        public const int GetCostumeClass4Code = 1019;

        /// <summary>
        /// 获取自动生成条形码
        /// </summary>
        public const int GetBarCode4CostumeInfos = 1020;

        /// <summary>
        /// 解析条形码
        /// </summary>
        public const int ParsingBarCode = 1021;

        /// <summary>
        /// 商品档案导入
        /// </summary>
        public const int ImportCostumes = 1022;

        /// <summary>
        /// 采购付款管理
        /// </summary>
        public const int PurchasePayManage = 1023;

        /// <summary>
        /// 供应商往来账对账表
        /// </summary>
        public const int GetSupplierAccountContrast = 1024;

        /// <summary>
        /// 根据单据id查询供应商往来账明细
        /// </summary>
        public const int GetSupplierAccountRecord = 1025;

        /// <summary>
        /// 供应商往来账汇总
        /// </summary>
        public const int GetSupplierAccountRecordSummary = 1026;

        /// <summary>
        /// 供应商往来账汇总明细
        /// </summary>
        public const int GetSupplierAccountRecord4Summary = 1027;

        /// <summary>
        /// 批发收款管理
        /// </summary>
        public const int PfCollectionManage = 1028;

        /// <summary>
        /// 客户往来账对账表
        /// </summary>
        public const int GetPfAccountContrast = 1029;

        /// <summary>
        /// 根据单据id查询客户往来账明细
        /// </summary>
        public const int GetPfAccountRecord = 1030;

        /// <summary>
        /// 客户往来账汇总
        /// </summary>
        public const int GetPfAccountRecordSummary = 1031;

        /// <summary>
        /// 客户往来账汇总明细
        /// </summary>
        public const int GetPfAccountRecord4Summary = 1032;

        /// <summary>
        /// 供应商导入
        /// </summary>
        public const int ImportSupplier = 1033;

        /// <summary>
        /// 客户导入
        /// </summary>
        public const int ImportPfCustomer = 1034;

        /// <summary>
        /// 品牌导入
        /// </summary>
        public const int ImportBrand = 1035;

        /// <summary>
        /// 类别导入
        /// </summary>
        public const int ImportCostumeClass = 1036;

        /// <summary>
        /// 采购单绑定供应商
        /// </summary>
        public const int PurchaseBindingSupplierID = 1037;

        /// <summary>
        /// 会员消费汇总
        /// </summary>
        public const int GetReatilSumInfo = 1038;

        /// <summary>
        /// 会员余额变化
        /// </summary>
        public const int GetMemberBalanceChange = 1039;

        /// <summary>
        /// 获取销售单
        /// </summary>
        public const int GetReatilOrders = 1040;

        /// <summary>
        /// 客户进销存
        /// </summary>
        public const int GetPfCustomerInvoicing = 1041;
        
        /// <summary>
        /// 客户进销存(输入一个款号时)
        /// </summary>
        public const int GetPfInvoicingOnlyCostumeID = 1042;

        /// <summary>
        /// 删除店铺
        /// </summary>
        public const int DeleteShop = 1043;

        /// <summary>
        /// 商品进销存
        /// </summary>
        public const int GetCostumeInvoicing = 1044;

        /// <summary>
        /// 获取会员某天充值记录
        /// </summary>
        public const int GetRechargeRecords4Day = 1045;

        /// <summary>
        /// 商品进销存进货明细
        /// </summary>
        public const int GetCostumeInvoicingDetail4In = 1046;

        /// <summary>
        /// 商品进销存批发明细
        /// </summary>
        public const int GetCostumeInvoicingDetail4Pf = 1047;

        /// <summary>
        /// 商品进销存零售明细
        /// </summary>
        public const int GetCostumeInvoicingDetail4Retail = 1048;

        /// <summary>
        /// 客户进销存发货明细
        /// </summary>
        public const int GetPfInvoicing4Delivery = 1049;

        /// <summary>
        /// 客户进销存销售明细
        /// </summary>
        public const int GetPfInvoicing4Retail = 1050;

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        public const int GetUserInfo = 1051;

        /// <summary>
        /// 销售分析
        /// </summary>
        public const int GetSalesAnalysis = 1052;

        /// <summary>
        /// 查询管理员
        /// </summary>
        public const int GetAdminUsers = 1053;

        /// <summary>
        /// 查询导购员
        /// </summary>
        public const int GetGuides = 1054;

        /// <summary>
        /// 获取角色信息
        /// </summary>
        public const int GetRoles = 1055;

        /// <summary>
        /// 获取角色权限
        /// </summary>
        public const int GetRolePermissions4RoleID = 1056;

        /// <summary>
        /// 新增角色
        /// </summary>
        public const int InsertRole = 1057;

        /// <summary>
        /// 修改角色
        /// </summary>
        public const int UpdateRole = 1058;

        /// <summary>
        /// 删除角色
        /// </summary>
        public const int DeleteRole = 1059;

        /// <summary>
        /// 根据销售单id模糊查询分页信息
        /// </summary>
        public const int GetRetailPageLikeID = 1060;

        /// <summary>
        /// 获取提前多少天到今天范围内的销售单分页信息。
        /// </summary>
        public const int GetRetailPageAdvance = 1061;

        /// <summary>
        /// 获取销售分析明细
        /// </summary>
        public const int GetSalesAnalysisDeatilInfo = 1062;

        /// <summary>
        /// 获取过滤掉超级管理员的角色信息
        /// </summary>
        public const int GetRolesFilterAdmin = 1063;

        /// <summary>
        /// 修改导购员密码
        /// </summary>
        public const int UpdateGuidePwd = 1064;

        /// <summary>
        /// 编辑服装
        /// </summary>
        public const int EditCostume = 1065;

        /// <summary>
        /// 期初库存录入编辑商品
        /// </summary>
        public const int UpdateStartStoreCostume = 1066;

        /// <summary>
        /// 修改供应商应付结余
        /// </summary>
        public const int UpdateSupplierPaymentBalance = 1067;

        /// <summary>
        /// 修改批发客户应付结余
        /// </summary>
        public const int UpdatePfPaymentBalance = 1068;

        /// <summary>
        /// 修改所选店铺库存的吊牌价和售价
        /// </summary>
        public const int UpdateCostumeStorePrice = 1069;

        /// <summary>
        /// 盘点汇总获取对应的盘点单
        /// </summary>
        public const int GetCheckStoreOrders4Summary = 1070;

        /// <summary>
        /// 获取调拨单
        /// </summary>
        public const int GetAllocateOrders = 1071;

        /// <summary>
        /// 导入颜色
        /// </summary>
        public const int ImportCostumeColors = 1072;

        /// <summary>
        /// 载入子盘点单
        /// </summary>
        public const int GetCheckStoreDetails4Child = 1073;

        /// <summary>
        /// 修改充值记录
        /// </summary>
        public const int UpdateRechargeRecord = 1074;

        /// <summary>
        /// 获取充值记录
        /// </summary>
        public const int GetOneRechargeRecord = 1075;

        /// <summary>
        /// 修改是否在线上商城中展示
        /// </summary>
        public const int UpdateEmShowOnline = 1076;

        /// <summary>
        /// 修改是否上架批发
        /// </summary>
        public const int UpdatePfShowOnline = 1077;

        /// <summary>
        /// 获取批发销售分析
        /// </summary>
        public const int GetPfRetailAnalysis = 1078;

        /// <summary>
        /// 获取层级收益信息
        /// </summary>
        public const int GetDistributionInfo = 1079;

        /// <summary>
        /// 修改层级收益信息
        /// </summary>
        public const int UpdateDistributionInfo = 1080;

        /// <summary>
        /// 获取零售分销人员
        /// </summary>
        public const int GetRetailDistributionTree = 1081;

        /// <summary>
        /// 零售新增下线会员
        /// </summary>
        public const int AddMember4Distribution = 1082;

        /// <summary>
        /// 修改会员名称
        /// </summary>
        public const int UpdateMemberName = 1083;

        /// <summary>
        /// 获取批发分销人员
        /// </summary>
        public const int GetPfDistributionTree = 1084;

        /// <summary>
        /// 获取批发客户
        /// </summary>
        public const int GetPfCustomer = 1085;

        /// <summary>
        /// 获取打印设置
        /// </summary>
        public const int GetPrintTemplateInfo = 1086;

        /// <summary>
        /// 保存打印设置
        /// </summary>
        public const int SavePrintTemplateInfo = 1087;

        /// <summary>
        /// 获取商品分布
        /// </summary>
        public const int GetCostumeDistributions = 1088;

        /// <summary>
        /// 获取商品分布明细
        /// </summary>
        public const int GetCostumeDistributionDetails = 1089;

        /// <summary>
        /// 获取服装主图
        /// </summary>
        public const int GetMainCostumePhotoAddress = 1090;

        /// <summary>
        /// 获取服装图片列表
        /// </summary>
        public const int GetCostumePhotoAddressList = 1091;

        /// <summary>
        /// 删除海报
        /// </summary>
        public const int DeletePosterImage = 1092;

        /// <summary>
        /// 修改海报顺序
        /// </summary>
        public const int UpdatePosterImageIndexs = 1093;

        /// <summary>
        /// 获取海报
        /// </summary>
        public const int GetEmPosterImages = 1094;

        /// <summary>
        /// 所选导购在这一天中的有销售的销售单
        /// </summary>
        public const int GetGuideReatil4Days = 1095;

        /// <summary>
        /// 隐藏客户期初库存录入功能
        /// </summary>
        public const int HideCreatePfStore = 1096;

        /// <summary>
        /// 启用店铺
        /// </summary>
        public const int EnableShop = 1097;

        /// <summary>
        /// 修改线上销量
        /// </summary>
        public const int UpdateEmSales = 1098;

        /// <summary>
        /// 新增服装图片视频
        /// </summary>
        public const int InsertEmCostumePhoto = 1099;

        /// <summary>
        /// 获取腾讯云签名
        /// </summary>
        public const int GetCosCloudSignature = 1100;

        /// <summary>
        /// 新增分销佣金模板
        /// </summary>
        public const int InsertCommissionTemplate = 1101;

        /// <summary>
        /// 修改分销佣金模板
        /// </summary>
        public const int UpdateCommissionTemplate = 1102;

        /// <summary>
        /// 查询分销佣金模板列表
        /// </summary>
        public const int GetCommissionTemplates = 1103;

        /// <summary>
        /// 根据id获取分销佣金模板列表
        /// </summary>
        public const int GetOneCommissionTemplate = 1104;

        /// <summary>
        /// 删除获取分销佣金模板列表
        /// </summary>
        public const int DeleteCommissionTemplate = 1105;

        /// <summary>
        /// 分销佣金模板列表是否含有默认模板
        /// </summary>
        public const int IsCommissionTemplateHaveDefault = 1106;
        
        /// <summary>
        /// 分销佣金模板列表是被使用
        /// </summary>
        public const int IsCommissionTemplateUse = 1107;

        /// <summary>
        /// 获取一条批发单信息
        /// </summary>
        public const int GetOnePfOrder = 1108;

        /// <summary>
        /// 新增线上店铺海报图片
        /// </summary>
        public const int InsertEmPosterImage = 1109;

        /// <summary>
        /// 获取批发客户库存
        /// </summary>
        public const int GetPfCustomerStoreList = 1110;

        /// <summary>
        /// 获取批发客户库存
        /// </summary>
        public const int GetOnePfCustomerStore = 1111;

        /// <summary>
        /// 线上订单导出设置
        /// </summary>
        public const int SetEmOrderExportInfo = 1112;

        /// <summary>
        /// 获取线上订单导出设置
        /// </summary>
        public const int GetEmOrderExportInfo = 1113;

        /// <summary>
        /// 获取线上批发订单导出数据
        /// </summary>
        public const int GetEmPfOrderExportData = 1114;

        /// <summary>
        /// 获取线上零售订单导出数据
        /// </summary>
        public const int GetEmRetailOrderExportData = 1115;

        /// <summary>
        /// 获取大类类别
        /// </summary>
        public const int GetBigClassList = 1116;

        /// <summary>
        /// 修改类别图片存储的链接地址
        /// </summary>
        public const int UpdateClassPhotoUrl = 1117;

        /// <summary>
        /// 删除类别图片
        /// </summary>
        public const int DeleteClassPhotoUrl = 1118;

        /// <summary>
        /// 设置佣金打款方式
        /// </summary>
        public const int SetPfCommissionPayWay = 1119;

        /// <summary>
        /// 获取佣金打款方式
        /// </summary>
        public const int GetPfCommissionPayWay = 1120;

        /// <summary>
        /// 获取零售分销人员
        /// </summary>
        public const int GetDistributors4Retail = 1121;

        /// <summary>
        /// 获取批发分销人员
        /// </summary>
        public const int GetDistributors4Pf = 1122;

        /// <summary>
        /// 获取零售佣金明细
        /// </summary>
        public const int GetCommissionRecords4Retail = 1123;

        /// <summary>
        /// 获取批发佣金明细
        /// </summary>
        public const int GetCommissionRecords4Pf = 1124;

        /// <summary>
        /// 获取打款管理
        /// </summary>
        public const int GetDistributorPayManage = 1125;

        /// <summary>
        /// 模糊查询批发客户列表
        /// </summary>
        public const int GetPfCustomers = 1126;

        /// <summary>
        /// 佣金打款
        /// </summary>
        public const int PayCommission = 1127;

        /// <summary>
        /// 获取零售分销人员
        /// </summary>
        public const int GetDistributors4Member = 1128;

        /// <summary>
        /// 获取批发分销人员
        /// </summary>
        public const int GetPfDistributors = 1129;

        /// <summary>
        /// 修改批发客户能否查看佣金
        /// </summary>
        public const int UpdatePfCustomerSeeCommission = 1130;

        /// <summary>
        /// 修改会员能否查看佣金
        /// </summary>
        public const int UpdateMemberSeeCommission = 1131;

        /// <summary>
        /// 获取所有启用的品牌列表
        /// </summary>
        public const int GetEnableBrands = 1132;

        /// <summary>
        /// 品牌是否禁用
        /// </summary>
        public const int UpdateBrandDisable = 1133;

        /// <summary>
        /// 获取分销人员信息
        /// </summary>
        public const int GetDistributor = 1134;

        /// <summary>
        /// 修改分销人员提款申请记录
        /// </summary>
        public const int UpdateDistributorWithdrawRecord = 1135;

        /// <summary>
        /// 获取商品分布明细 累计进货明细
        /// </summary>
        public const int GetCostumeDistributionDetails4In = 1136;

        /// <summary>
        /// 获取商品分布明细 本期销售明细
        /// </summary>
        public const int GetCostumeDistributionDetails4Retail = 1137;

        /// <summary>
        /// 获取销售单打印类型
        /// </summary>
        public const int GetRetailPrintType = 1138;

        /// <summary>
        /// 设置销售单打印类型
        /// </summary>
        public const int SetRetailPrintType = 1139;





























        /// <summary>
        /// 注册会员。
        /// </summary>
        public const int RegisterMember = 1500;

        /// <summary>
        /// 获取会员分页列表。参数为MemberListPagePara，返回MemberListPage。
        /// </summary>
        public const int GetMemberListPage = 1501;

        /// <summary>
        /// 修改会员。参数为Member，返回UpdateMemberResult枚举。
        /// </summary>
        public const int UpdateMember = 1502;

        /// <summary>
        /// 获取单个会员信息。参数为string，返回Member
        /// </summary>
        public const int GetOneMember = 1503;
        
        /// <summary>
        /// 获取本店库存情况。参数CostumeStoreListPara，返回List<CostumeStoreResult>
        /// </summary>
        public const int GetCostumeStoreList = 1504;

        /// <summary>
        /// 获取销售单分页列表。参数为RetailListPagePara，返回RetailListPage。
        /// </summary>
        public const int GetRetailListPage = 1505;

        /// <summary>
        /// 获取退货单分页列表。参数为RefundListPagePara，返回RefundListPage。
        /// </summary>
        public const int GetRefundListPage = 1506;

        /// <summary>
        /// 获取销售单明细列表。参数为string，返回List<RetailDetail>。
        /// </summary>
        public const int GetRetailDetailList = 1507;

        /// <summary>
        /// 获取退货单明细列表。参数为string，返回List<RefundDetail>。
        /// </summary>
        public const int GetRefundDetailList = 1508;

        /// <summary>
        /// 获取库存分页信息。参数为CostumeStoreListPagePara，返回CostumeStoreListPage。
        /// </summary>
        public const int GetCostumeStoreListPage = 1509;
        
        /// <summary>
        /// 会员充值。参数RechargeRecord, 返回RechargeResult
        /// </summary>
        public const int Recharge = 1510;

        /// <summary>
        /// 获取充值记录。参数RechargeRecordListPara，返回List<RechargeRecord>
        /// </summary>
        public const int GetRechargeRecordList = 1511;

        /// <summary>
        /// 获取本店铺的导购员。参数string，返回List<Guide>
        /// </summary>
        public const int GetGuideList = 1512;

        /// <summary>
        /// 获取服装分类列表。参数null，返回List<CostumeClassInfo>
        /// </summary>
        public const int GetCostumeClassList = 1513;

        /// <summary>
        /// 补货申请分页查询。参数ReplenishCostumePagePara，返回ReplenishCostumePage
        /// </summary>
        public const int GetReplenishCostumePage = 1514;

        /// <summary>
        /// 获取补货申请单明细。参数string，返回List<ReplenishDetail>
        /// </summary>
        public const int GetReplenishDetail = 1515;

        /// <summary>
        /// 入库。参数InboundPara，返回InboundResult
        /// </summary>
        public const int Inbound = 1516;

        /// <summary>
        /// 获取服装分页信息。参数CostumeListPagePara，返回CostumeListPage
        /// </summary>
        public const int GetCostumeListPage = 1517;

        /// <summary>
        /// 获取入库单分页信息。参数InboundOrderPagePara，返回InboundOrderPage
        /// </summary>
        public const int GetInboundOrderPage = 1518;

        /// <summary>
        /// 查询出库单信息。参数string，返回Outbound
        /// </summary>
        public const int GetOneOutbound = 1519;

        /// <summary>
        /// 获取入库单明细。参数string,返回List<InboundDetail>
        /// </summary>
        public const int GetInboundDetail = 1520;

        /// <summary>
        /// 获取出库单分页信息。参数OutboundOrderPagePara，返回OutboundOrderPage
        /// </summary>
        public const int GetOutboundOrderPage = 1521;

        /// <summary>
        /// 获取出库单明细。参数string，返回List<OutboundDetail>
        /// </summary>
        public const int GetOutboundDetail = 1522;

        /// <summary>
        /// 获取入库差异单分页信息。参数DifferenceOrderPagePara，返回DifferenceOrderPage
        /// </summary>
        public const int GetDifferenceOrderPage = 1523;

        /// <summary>
        /// 获取入库差异单明细。参数string，返回List<DifferenceDetail>
        /// </summary>
        public const int GetDifferenceDetail = 1524;

        /// <summary>
        /// 获取品牌。参数null，返回List<Brand>
        /// </summary>
        public const int GetBrand = 1525;

        /// <summary>
        /// 取消补货申请单
        /// </summary>
        public const int CancelReplenish = 1526;

        /// <summary>
        /// 获取后台管理用户。参数null，返回List<AdminUser>
        /// </summary>
        public const int GetAllAdminUser = 1527;

        /// <summary>
        /// 调拨。参数AllocateOutboundPara，返回InteractResult
        /// </summary>
        public const int AllocateOutbound = 1528;

        /// <summary>
        /// 获取调拨单分页信息。参数AllocateOrderPagePara，返回AllocateOrderPage
        /// </summary>
        public const int GetAllocateOrderPage = 1529;

        /// <summary>
        /// 盘点审核。参数CheckStoreOrderIDAndUser，返回InteractResult
        /// </summary>
        public const int CheckStore = 1530;

        /// <summary>
        /// 获取出库单。参数string，返回OutboundOrder
        /// </summary>
        public const int GetOutboundOrder = 1531;

        /// <summary>
        /// 获取入库单。参数string，返回InboundOrder
        /// </summary>
        public const int GetInboundOrder = 1532;

        /// <summary>
        /// 获取补货申请单，参数string，返回ReplenishOrder
        /// </summary>
        public const int GetReplenishOrder = 1533;

        /// <summary>
        /// 获取调拨单。参数string，返回AllocateOrder
        /// </summary>
        public const int GetAllocateOrder = 1534;

        /// <summary>
        /// 根据店铺id获取库存信息。参数GetCostumeStorePara，返回CostumeStorePage
        /// </summary>
        public const int GetCostumeStoreInShopID = 1535;

        /// <summary>
        /// 获取盘点分页信息。参数CheckStoreOrderPagePara，返回CheckStoreOrderPage
        /// </summary>
        public const int GetCheckStoreOrderPage = 1536;

        /// <summary>
        /// 获取盘点明细。参数string，返回List<CheckStoreDetail>
        /// </summary>
        public const int GetCheckStoreDetail = 1537;

        /// <summary>
        /// 获取工作台信息。参数WorkTableInfoPara，返回WorkTableInfo
        /// </summary>
        public const int WorkTableInfo = 1538;

        /// <summary>
        /// 差异单确认。参数DifferenceOrderConfirmedPara，返回DifferenceOrderConfirmedResult
        /// </summary>
        public const int DifferenceOrderConfirmed = 1539;

        /// <summary>
        /// 根据来源单据编号获取差异单信息。参数string，返回DifferenceOrder
        /// </summary>
        public const int GetOneDifferenceOrder4SourceOrderID = 1540;

        /// <summary>
        /// 获取库存变化跟踪分页信息。参数CostumeStoreTrackPagePara，返回CostumeStoreTrackPage
        /// </summary>
        public const int GetCostumeStoreTrackPage = 1541;

        /// <summary>
        /// 新增现金记录。参数CashRecord，返回InsertResult
        /// </summary>
        public const int InsertCashRecord = 1542;

        /// <summary>
        /// 获取现金记录分页信息。参数CashRecordPagePara，返回CashRecordPage
        /// </summary>
        public const int GetCashRecordPage = 1543;

        /// <summary>
        /// 查询配置列表。参数null，返回List<ParameterConfig>
        /// </summary>
        public const int GetAllParameterConfig = 1544;

        /// <summary>
        /// 新增待审核盘点单。参数CheckStore，返回InteractResult
        /// </summary>
        public const int InsertCheckStore = 1545;

        /// <summary>
        /// 取消盘点单。参数CheckStoreOrderIDAndUser，返回UpdateCheckStoreResult
        /// </summary>
        public const int CancelCheckStore = 1546;

        /// <summary>
        /// 修改盘点单。参数CheckStore，返回InteractResult
        /// </summary>
        public const int UpdateCheckStore = 1547;

        /// <summary>
        /// 获取日报分页信息。参数DayReportPagePara，返回DayReportPage
        /// </summary>
        public const int GetDayReportPage = 1548;

        /// <summary>
        /// 删除盘点单。参数string，返回DeleteCheckStoreResult
        /// </summary>
        public const int DeleteCheckStore = 1549;

        /// <summary>
        /// 获取导购业绩汇总信息。参数GuideAchievementSummarysPara，返回GuideAchievementSummarys
        /// </summary>
        public const int GetGuideAchievementSummarys = 1550;

        /// <summary>
        /// 获取导购业绩信息。参数GuideAchievementsPara，返回List<GuideDayAchievement>
        /// </summary>
        public const int GetGuideAchievements = 1551;
        
        /// <summary>
        /// 获取 营业月报/营业月报汇总 信息。参数GetMonthBenefitReportPara， 返回List<MonthBenefitReport>
        /// </summary>
        public const int GetMonthBenefitReports = 1552;

        /// <summary>
        /// 根据单据编号获取采购进货。参数string，返回PurchaseOrder
        /// </summary>
        public const int GetOnePurchaseOrder = 1553;

        /// <summary>
        /// 根据单据编号获取采购退货。参数string，返回ReturnOrder
        /// </summary>
        public const int GetOneReturnOrder = 1554;

        /// <summary>
        /// 根据单据编号获取报损单。参数string，返回ScrapOrder
        /// </summary>
        public const int GetOneScrapOrder = 1555;
        
        /// <summary>
        /// 获取今天的日报信息。参数string，返回DayReport
        /// </summary>
        public const int GetTodayDayReport = 1556;

        /// <summary>
        /// 根据会员手机号码模糊查询满足的会员。参数string，返回List<Member>
        /// </summary>
        public const int GetMembers4PhoneNumber = 1557;

        /// <summary>
        /// 获取畅滞排行榜。参数SalesQuantityRankingPagePara，返回SalesQuantityRankingPage
        /// </summary>
        public const int GetSalesQuantityRankingPage = 1558;

        /// <summary>
        /// 根据时间范围获取销售单明细。参数DayBenefitReportDetailPara，返回List<DayBenefitReportDetail>
        /// </summary>
        public const int GetDayBenefitReportDetail = 1559;

        /// <summary>
        /// 获取报损分页信息。参数ScrapPagePara，返回ScrapPage
        /// </summary>
        public const int GetScrapPage = 1560;

        /// <summary>
        /// 获取颜色。参数null，返回List<CostumeColor>
        /// </summary>
        public const int GetCostumeColor = 1561;

        /// <summary>
        /// 商品销售分析。参数CostumeRetailAnalysisPagePara，返回CostumeRetailAnalysisPage
        /// </summary>
        public const int GetCostumeRetailAnalysisPage = 1562;

        /// <summary>
        /// 获取打卡分页信息。参数SignRecordPagePara，返回SignRecordPage
        /// </summary>
        public const int GetSignRecordPage = 1563;
        
        /// <summary>
        /// 获取月销售任务分页信息。参数MonthTaskPagePara，返回MonthTaskPage
        /// </summary>
        public const int GetMonthTaskPage = 1564;

        /// <summary>
        /// 获取月销售任务列表。参数GetMonthTaskPara，返回List<MonthTask>
        /// </summary>
        public const int GetMonthTasks = 1565;
        
        /// <summary>
        /// 修改月销售任务。参数MonthTask，返回UpdateMonthTaskResult
        /// </summary>
        public const int UpdateMonthTask = 1566;

        /// <summary>
        /// 调拨单冲单。参数string，返回InteractResult
        /// </summary>
        public const int OverrideAllocateOrder = 1567;

        /// <summary>
        /// 补货申请单冲单。参数string，返回OverrideOrderResult
        /// </summary>
        public const int OverrideReplenishOrder = 1568;

        /// <summary>
        /// 获取服装图片。参数string, 返回byte[]
        /// </summary>
        public const int GetCostumePhoto = 1569;

        /// <summary>
        /// 获取本店库存分页信息。参数GetCostumeItemPagePara，返回CostumeItemPage
        /// </summary>
        public const int GetCostumeItemPage = 1570;
        
        /// <summary>
        /// 销售冲单。参数CancelRetailOrderPara，返回CancelRetailOrderResult
        /// </summary>
        public const int CancelRetailOrder = 1571;

        /// <summary>
        /// 添加 串码调整记录 。参数ConfusedStoreAdjustRecord，返回InteractResult
        /// </summary>
        public const int AddConfusedStoreAdjustRecord = 1572;

        /// <summary>
        /// 获取 串码调整记录 分页信息。参数GetConfusedStoreAdjustRecordPagePara，返回ConfusedStoreAdjustRecordPage
        /// </summary>
        public const int GetConfusedStoreAdjustRecordPage = 1573;

        /// <summary>
        /// 退货冲单。参数CancelRetailOrderPara，返回CancelRetailOrderResult
        /// </summary>
        public const int CancelRefundOrder = 1574;

        /// <summary>
        /// 获取导购员日业绩。参数GetGuideDayAchievementsPara，返回List<GuideDayAchievement>
        /// </summary>
        public const int GetGuideDayAchievements = 1575;

        /// <summary>
        /// 发放优惠券。参数IssueGiftTicketPara，返回InsertResult
        /// </summary>
        public const int IssueGiftTicket = 1576;

        /// <summary>
        /// 获取 电子优惠券分页信息。参数GiftTicketPagePara，返回GiftTicketPage
        /// </summary>
        public const int GetGiftTicketPage = 1577;

        /// <summary>
        /// 禁用电子优惠券。参数EnabledGiftTicketPara，返回UpdateResult
        /// </summary>
        public const int EnabledGiftTicket = 1578;

        /// <summary>
        /// 根据会员id或名称模糊查询会员信息。参数string，返回List<Member>
        /// </summary>
        public const int GetMembersLike4IDOrName = 1579;
        
        /// <summary>
        /// 获取会员头像。参数string，返回byte[]
        /// </summary>
        public const int GetMemberHeadImage = 1580;

        /// <summary>
        /// 获取所有尺码组。参数null，返回List<SizeGroup>
        /// </summary>
        public const int GetAllSizeGroup = 1584;

        /// <summary>
        /// 是否启用尺码组。参数EnabledSizeGroupPara,返回InteractResult
        /// </summary>
        public const int EnabledSizeGroup = 1585;

        /// <summary>
        /// 获取一段时间内各个店铺的营业报表信息。参数GetShopBenefitReportsPara，返回List<DayBenefitReport>
        /// </summary>
        public const int GetShopBenefitReports = 1586;

        /// <summary>
        /// 获取某个店铺的营业报表信息。参数GetBenefitReportsPara，返回List<DayBenefitReport>
        /// </summary>
        public const int GetBenefitReports = 1587;

        /// <summary>
        /// 查询促销活动列表。参数GetSalesPromotionListPara，返回List<SalesPromotion>
        /// </summary>
        public const int GetSalesPromotionList = 1588;

        /// <summary>
        /// 查询充值规则列表。参数null，返回List<RechargeDonateRule>
        /// </summary>
        public const int GetRechargeDonateRuleList = 1589;

        /// <summary>
        /// 获取销售分析。参数GetRetailAnalysisPara，返回RetailAnalysisInfo
        /// </summary>
        public const int GetRetailAnalysis = 1590;

        /// <summary>
        /// 获取 导购某天的业绩数据。参数GetGuideAchievementDetailsPara，返回List<GuideAchievementDetail>
        /// </summary>
        public const int GetGuideAchievementDetails = 1591;

        /// <summary>
        /// 获取总仓店铺id。参数null，返回string
        /// </summary>
        public const int GetGeneralStoreShopID = 1592;

        /// <summary>
        /// 获取小程序码或小程序二维码 图片 （打印小票用）。参数null，返回byte[]
        /// </summary>
        public const int GetEMallMiniProgramImg = 1593;

        /// <summary>
        /// 修改销售单时间。参数UpdateTimePara，返回InteractResult
        /// </summary>
        public const int UpdateRetailTime = 1594;

        /// <summary>
        /// 重结报表（ 根据基础信息，重新生成对应的报表及数据变化）。参数CreateAllReportPara,返回InteractResult
        /// </summary>
        public const int CreateAllReport = 1595;

        /// <summary>
        /// 获取销售分析明细。参数GetRetailAnalysisDeatilInfoPara，返回RetailAnalysisDeatilInfo
        /// </summary>
        public const int GetRetailAnalysisDeatilInfo = 1596;

        /// <summary>
        /// 批发发货/退货单查询。参数GetPfOrderPagePara，返回PfOrderPage
        /// </summary>
        public const int GetPfOrderPage = 1597;

        /// <summary>
        /// 获取批发发货/退货单明细。参数string，返回List<PfOrderDetail>
        /// </summary>
        public const int GetPfOrderDetails = 1598;

        /// <summary>
        /// 导入会员信息。
        /// </summary>
        public const int ImportMembers = 1599;

        /// <summary>
        /// 获取 批发客户分页信息。参数GetPfCustomerPagePara，返回PfCustomerPage
        /// </summary>
        public const int GetPfCustomerPage = 1600;

        /// <summary>
        /// 新增 批发客户 信息。参数PfCustomer，返回InteractResult
        /// </summary>
        public const int InsertPfCustomer = 1601;

        /// <summary>
        /// 修改 批发客户 信息。参数PfCustomer，返回InteractResult
        /// </summary>
        public const int UpdatePfCustomer = 1602;

        /// <summary>
        /// 删除 批发客户 信息。参数string，返回InteractResult
        /// </summary>
        public const int DeletePfCustomer = 1603;

        /// <summary>
        /// 新增尺码组
        /// </summary>
        public const int InsertSizeGroup = 1604;

        /// <summary>
        /// 修改尺码组
        /// </summary>
        public const int UpdateSizeGroup = 1605;

        /// <summary>
        /// 删除尺码组
        /// </summary>
        public const int DeleteSizeGroup = 1606;
    }
}
