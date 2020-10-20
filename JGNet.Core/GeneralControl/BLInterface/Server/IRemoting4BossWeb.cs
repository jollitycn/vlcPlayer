using JGNet.Core.Dev.InteractEntity;
using JGNet.Core.Dev.MyEnum;
using JGNet.Core.InteractEntity;
using JGNet.Core.MyEnum;
using JGNet.Core.RemotingEntity;
using JGNet.Core.Tools;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Dev.BLInterface
{
    public interface IRemoting4BossWeb
    {
        #region 充值
        string GetRechargeDonateRule();

        string Recharge(RechargeRecord rechargeRecord);

        string GetRechargeRecords(GetRechargeRecordsPara para);

        string UpdateRechargeRecord(UpdateRechargeRecordPara para);
        #endregion

        /// <summary>
        /// 修改店铺名称
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="shopName"></param>
        /// <returns></returns>
        InteractResult UpdateShopName(string shopID, string shopName);
        List<Shop> GetAllShop4Enabled();

        List<string> GetAllShopID4Enabled();

        List<Guide> GetAllGuide4ShopID(string shopID);
        
        /// <summary>
        /// 获取导购员对象集合 （id，名称的模糊查询，店铺排序）
        /// </summary>
        /// <param name="idOrName"></param>
        /// <returns></returns>
        List<Guide> GetGuideList(string idOrName);
      
        /// <summary>
        /// POS端、小程序导购端 是否显示品牌
        /// </summary>
        /// <returns></returns>
        bool IsShowBrand();

        /// <summary>
        /// 修改导购权限
        /// </summary>
        /// <param name="guideID"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        UpdateResult UpdateGuidePermission(string guideID, string permission);

        Dictionary<string, List<Guide>> GetGuideDicGroupByShopID();

        string GetAllPfCostumeColorStore(string costumeID, string colorName);

        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        UserType GetUserType(string userID);

        /// <summary>
        /// 获取后台管理员对象
        /// </summary>
        /// <param name="adminID">BossID</param>
        /// <returns></returns>
        AdminUser GetOneAdmin(string adminID);

        /// <summary>
        /// 获取后台管理员对象集合 （id，名称的模糊查询）
        /// </summary>
        /// <param name="idOrName"></param>
        /// <returns></returns>
        List<AdminUser> GetAdminUsers(string idOrName);

        /// <summary>
        /// 获取所有启用的后台管理员对象集合
        /// </summary>
        /// <param name="idOrName"></param>
        /// <returns></returns>
        List<AdminUser> GetAllAdminUser4Enabled();

        /// <summary>
        /// 获取所有停用的后台管理员对象集合
        /// </summary>
        /// <returns></returns>
        List<AdminUser> GetAdminUser4StopUsed();

        UpdateResult UpdateAdminPwd(string adminID, string password);
        
        /// <summary>
        /// 修改管理员权限
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        UpdateResult UpdateAdminPermission(string adminID, string permission);

        /// <summary>
        /// 新增管理员
        /// </summary>
        /// <param name="adminUser"></param>
        /// <returns></returns>
        InteractResult InsertAdminUser(AdminUser adminUser);

        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="adminUser"></param>
        /// <returns></returns>
        InteractResult UpdateAdminUser(AdminUser adminUser);

        /// <summary>
        /// 获取月任务目标 guideID为空时，返回的是店铺的月任务
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="guideID"></param>
        /// <param name="month">月份值 固定6位数 （如201806）</param>
        /// <returns></returns>
        MonthTask GetMonthTask(string shopID, string guideID, int month);

        string SearchPfCostume(SearchPfCostumePagePara para);

        /// <summary>
        /// 获取一段时间月任务目标总和 guideID为空时，返回的是店铺的月任务
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="guideID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        int GetDayTaskSum(string shopID, string guideID, DateTime startTime, DateTime endTime);

        /// <summary>
        /// 获取具体某一天的目标额度（店铺id为空时返回所有店的任务总和，guideID为空时返回值为店铺的任务值）
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="guideID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        int GetOneDayTask(string shopID, string guideID, DateTime date);

        /// <summary>
        /// 获取会员头像
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        byte[] GetMemberHeadImage(string memberID);
        
        /// <summary>
        /// 获取时间段新增会员
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="guideID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        List<Member> GetNewMemberList(string shopID, string guideID, DateTime startTime, DateTime endTime);


        /// <summary>
        /// 获取时间段新增会员数量
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="guideID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        int GetNewMemberCount(string shopID, string guideID, DateTime startTime, DateTime endTime);

        /// <summary>
        /// 获取所有会员数量  （shopID为空，返回所有店。  guideID 为空返回该店所有导购  下的会员数）
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="guideID"></param>
        /// <returns></returns>
        int GetAllMemberCount(string shopID, string guideID);

        /// <summary>
        /// 获取一段时间内会员充值金额总和
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="guideID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        int GetRechargeRecordSum(string shopID, string guideID, DateTime startDate, DateTime endDate);

        VipContributionPage GetVipContributionPage(DateTime startDate, DateTime endDate, string shopID);

        /// <summary>
        /// 获取某店铺的一段时间日营业额集合，不包含总合值 (shopID为string.Empty 返回所有店总和)
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="shopID"></param>
        /// <returns></returns>
        DayBenefitReport[] GetDayBenefitReportList(DateTime startDate, DateTime endDate, string shopID, int pageIndex, int pageSize, out int entityCount);

        /// <summary>
        /// 获取某店铺的一段时间日营业额集合,包含总合值 (shopID为string.Empty 返回所有店总和)
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="shopID"></param>
        /// <returns></returns>
        DayBenefitReportPage GetDayBenefitReportPage(DateTime startDate, DateTime endDate, string shopID);

        string GetBigClassList();

        /// <summary>
        /// 获取某店铺的一段时间日营业额集合 按店铺分组查询 (shopID为string.Empty 返回所有店总和)
        /// </summary>
        /// <param name="startTime">开始时间 （固定8位数）</param>
        /// <param name="endTime">结束时间（固定8位数）</param>
        /// <param name="shopID">店铺编号</param>
        /// <returns></returns>
        DayBenefitReportPage GetOneShopDayBenefitReportByShopIDGroup(DateTime startTime, DateTime endTime ,string shopID, DateType dateType);

        string UpdateClassPhotoUrl(int id, string url);

        string DeleteClassPhotoUrl(int id);

        /// <summary>
        /// 获取某店铺的月营业额
        /// </summary>
        /// <param name="reportDate">报表时间</param>
        /// <param name="shopID">店铺编号</param>
        /// <returns></returns>
        MonthBenefitReport GetOneShopMonthBenefitReport(int reportDate, string shopID);


 
        /// <summary>
        /// 获取所有店铺的月营业额集合
        /// </summary>
        /// <param name="reportDate">报表时间</param>
        /// <returns></returns>
        List<MonthBenefitReport> GetAllShopMonthBenefitReportList(int reportDate);

        /// <summary>
        /// 获取所有店铺的月营业额汇总
        /// </summary>
        /// <param name="reportDate">报表时间</param>
        /// <returns></returns>
        MonthBenefitReport GetMonthBenefitReportTotal(int reportDate);

        string CancelRetailOrder(CancelRetailOrderPara para);


        /// <summary>
        /// 获取前一段时间的营业图表数据 集合
        /// </summary>
        /// <param name="shopID">店铺ID （id为空，返回所有店总和）</param>
        /// <param name="date">需查询的日期</param>
        /// <param name="dateType">日期类型</param>
        /// <param name="lastDateCount">查询前几（天，月）</param>
        /// <returns></returns>
        List<GraphData> GetLastDateDayBenefitReportList(string shopID, DateTime date, DateType dateType, int lastDateCount);


        /// <summary>
        /// 获取一段时间日销售明细集合
        /// </summary>
        /// <param name="shopID">店铺id  （ID为空，表示查询所有店总和）</param>
        /// <param name="startTime">开始时间（固定8位数）</param>
        /// <param name="endTime">结束时间（固定8位数）</param>
        /// <returns></returns>
        ShopSalesDetailPage GetShopSalesDetailPage(string shopID, DateTime startTime, DateTime endTime, int pageIndex, int pageSize);

        /// <summary>
        /// 获取一段时间销售单分页
        /// </summary>
        /// <param name="shopID">‘_online’为线上商城</param>
        /// <param name="guideID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="isSupervisor">是否为特殊用户（丹枫）</param>
        /// <param name="retailOrderType">销售单类型</param>
        /// <returns></returns>
        RetailCostumePage GetRetailCostumePage(string shopID, string guideID, DateTime startDate, DateTime endDate, int pageSize, int pageIndex, bool isSupervisor,bool isNotPay, 
            RetailOrderType retailOrderType, string costumeID, RetailOrderState retailOrderState);

        string GetRetailCostume(string orderID);

        /// <summary>
        /// 设置销售单是否给商场人可见（特殊人员查账）
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="isSupervisor"></param>
        UpdateResult SetVisiable4Supervisor(string orderID, bool isSupervisor);

        string InsertEmPosterImage(EmPosterImage emPosterImage);


        /// <summary>
        /// 根据款号或名称获取服装
        /// </summary>
        /// <param name="costumeIDOrName">款号或名称</param>
        /// <returns></returns>
        CostumeListPage GetCostumeListByIDOrName(SearchCostumePagePara para);

        /// <summary>
        /// 获取某一商品的用于显示的所有尺码（11个）
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        Dictionary<string, string> GetOneCostume_SizeNameList4Show(string costumeID);

        /// <summary>
        /// 根据款号列表获取服装集合
        /// </summary>
        /// <param name="costumeIDs"></param>
        /// <returns></returns>
        List<Costume> GetCostume4CostumeIDs(List<string> costumeIDs);


        /// <summary>
        /// 获取本店库存 （店铺ID为空，返回所有店）
        /// </summary>
        /// <param name="shopID">店铺ID （店铺ID为空，返回所有店）</param>
        /// <param name="costumeID">款号</param>
        /// <returns></returns>
       // CostumeItem GetCostumeStoreInShopID(string shopID, string costumeID);

        /// <summary>
        /// 获取衣服详情
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        Costume GetCostume(string costumeID);
       
        /// <summary>
        /// 获取衣服大图片信息
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        byte[] GetCostumePhotoData(string costumeID);

        /// <summary>
        /// 获取所有店的 单店单款衣服单颜色库存
        /// </summary>
        /// <param name="shopIDs"></param>
        /// <param name="costumeID"></param>
        /// <param name="colorName"></param>
        /// <returns></returns>
        List<ShopCostumeColorStore> GetAllShopCostumeColorStore(List<string> shopIDs, string costumeID, string colorName);

        string UpdateEmHot(string emCostumeID, bool isHot);

        string UpdateEmNew(string emCostumeID, bool isNew);

        /// <summary>
        /// 禁用服装
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        InteractResult DisableCostume(string costumeID);
        
        /// <summary>
        /// 更新服装
        /// </summary>
        /// <param name="costume">服装对象</param>
        InteractResult UpdateCostume(Costume costume);

        /// <summary>
        /// 更新服装图片和缩略图
        /// </summary>
        /// <param name="uploadCostumePhotoPara">修改图片的参数</param>
        UpdateResult UpdateCostumePhoto(UploadCostumePhotoPara uploadCostumePhotoPara);

        /// <summary>
        /// 获取服装缩略图字典集合
        /// </summary>
        /// <param name="costumeIDs"></param>
        /// <returns></returns>
        Dictionary<string, string> GetCostumePhotoThumbnailUrl(List<string> costumeIDs);

        string GetEmOfflineCostume(GetEmOfflineCostumePara para);

        /// <summary>
        /// 获取单款服装缩略图
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        string GetOneCostumePhotoThumbnailUrl(string costumeID);

        /// <summary>
        /// 获取畅（滞）销排行榜
        /// </summary>
        /// <param name="shopID">店铺id   id为空返回所有店铺的数据</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="salesQuantityType">畅（滞）销类型 0：畅销；1：滞销</param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">每页多少条</param>
        /// <returns></returns>
        SalesQuantityRankingPage GetSalesQuantityRankingPage(string shopID, int brandID, int classID, DateTime startTime, DateTime endTime, SalesQuantityType salesQuantityType, int pageIndex, int pageSize);

        /// <summary>
        /// 获取导购业绩汇总
        /// </summary>
        /// <param name="shopID">店铺编号</param>
        /// <param name="guideID">导购编号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isOnlyShowNoZero">是否统计销售为0的数据</param>
        /// <returns></returns>
        List<GuideAchievementSummary> GetGuideAchievementSummarys(string shopID, string guideID, DateTime startDate, DateTime endDate, bool isOnlyShowNoZero);

        InteractResult<GuideRankingInfo> GetGuideRanking(string shopID, string guideID, DateTime startDate, DateTime endDate, int pageIndex);

        /// <summary>
        /// 获取某店铺 一个时间段的支付详情 (店铺有空，返回所有店铺)
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束</param>
        /// <returns></returns>
        PaymentDetailSummary GetPaymentDetailSummary(string shopID, DateTime startDate, DateTime endDate);

        /// <summary>
        /// 获取对应分组类型 的库存分析
        /// </summary>
        /// <param name="chooseShopID">店铺ID（null或""，返回所有店）</param>
        /// <param name="chooseBrandID">品牌ID （-1 返回所有品牌）</param>
        /// <param name="groupType">分组类型</param>
        /// <returns></returns>
        CostumeStoreAnalysis GetCostumeStoreAnalysis(string chooseShopID, int chooseBrandID, GroupType groupType);

        /// <summary>
        /// 获取对应分组类型 一时间段的商品毛利
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="groupType"></param>
        /// <returns></returns>
        List<GoodMaori> GetCostumeMaoris(string shopID, DateTime startDate, DateTime endDate, GroupType groupType);

        /// <summary>
        /// 获取对应分组类型 的商品分析
        /// </summary>
        /// <param name="groupType">分组类型</param>
        /// <param name="shopID">店铺ID（null或""，返回所有店）</param>
        /// <param name="year"></param>
        /// <param name="season"></param>
        /// <returns></returns>
        List<CostumeAnalysis> GetCostumeAnalysis(GroupType groupType, string shopID, int year, string season);

        InteractResult InsertEmCostumePhoto(EmCostumePhoto emCostumePhoto);

        /// <summary>
        /// 获取对应分组类型 的销售分析
        /// </summary>
        /// <param name="groupType"></param>
        /// <param name="shopID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        RetailAnalysisInfo GetRetailAnalysis(GroupType groupType, string shopID , DateTime startDate, DateTime endDate);

        /// <summary>
        /// 获取分组类型的销售明细
        /// </summary>
        /// <param name="groupType"></param>
        /// <param name="shopID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="groupTypeName"></param>
        /// <returns></returns>
        RetailAnalysisDeatilInfo GetRetailAnalysisDeatilInfo(GroupType groupType, string shopID, DateTime startDate, DateTime endDate, string groupTypeName);

        InteractResult<CosLoginInfo> GetCosLoginInfo();

        /// <summary>
        /// 获取总体的商品分析
        /// </summary>
        /// <returns></returns>
        CostumeAnalysis GetTotalCostumeAnalysis();

        /// <summary>
        /// 获取VIP客户购买详情 分组统计
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        RetailOrderForVIPPage GetRetailOrderForVIPPage(string shopID, DateTime startTime, DateTime endTime);

        /// <summary>
        /// 获取前一段时间的VIP和普通客户购买额 数据 集合
        /// </summary>
        /// <param name="shopID">店铺ID</param>
        /// <param name="date">统计时间</param>
        /// <param name="dateType">日期类型</param>
        /// <param name="lastDateCount">查询前几（天，月，年）  （包含当天，月，年）</param>
        /// <returns></returns>
        WxChartsData GetLastDateRetailOrderForVIPList(string shopID, DateTime date, DateType dateType, int lastDateCount);

        /// <summary>
        /// 获取VIP消费记录列表 按天统计
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        List<VIPConsumeRecordListByDate> GetVIPConsumeRecordListByDate(string memberID, int pageIndex, int pageSize, out int totalCount);

        /// <summary>
        /// 获取衣柜分页 按天统计
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<WardrobeData> GetWardrobeDataPage(string memberID, int pageIndex, int pageSize, out int totalCount);
        /// <summary>
        /// 获取一段时间内的活跃率与留存率
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        ActivityMemberInfo GetActivityMemberInfo(string shopID, DateTime startDate, DateTime endDate);

        /// <summary>
        /// 获取供应商来往账
        /// </summary>
        /// <param name="supplierID">supplierID为空时，返回所有供应商</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        SupplierAccountRecordSumInfo GetSupplierAccountRecordSumInfo(string supplierID, DateTime startDate, DateTime endDate, DebtType debtTypeBe);

        /// <summary>
        /// 获取线上商城各订单状态数量
        /// </summary>
        /// <returns></returns>
        OrderCount GetEmOrderCount();

        /// <summary>
        /// 根据单号获取订单
        /// </summary>
        /// <param name="emRetailOrderID"></param>
        /// <returns></returns>
        EmRetailOrder GetOneEmRetailOrder(string emRetailOrderID);

        /// <summary>
        /// 根据输入字符（订单号|手机号|姓名|商品ID|商品名称|）获取线上销售订单分页
        /// </summary>
        /// <param name="idOrName">（订单号|手机号|姓名|商品ID|商品名称|）</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        EmOrderPage GetEmOrderPage(string idOrName, int pageIndex, int pageSize);

        /// <summary>
        /// 根据订单状态获取对应的销售单分页
        /// </summary>
        /// <param name="orderState"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        EmOrderPage GetEmOrderPageByState(EmRetailOrderState orderState, int pageIndex, int pageSize);

        /// <summary>
        /// 获取售后订单分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="isQueryShop">是否为待商家处理</param>
        /// <returns></returns>
        EmOrderPage GetEmOrderPageByRefund(int pageIndex, int pageSize, bool isQueryShop);

        /// <summary>
        /// 获取物流信息
        /// </summary>
        /// <param name="type">公司类型</param>
        /// <param name="postid">快递单号</param>
        /// <returns></returns>
        List<DataInfo> GetLogistics(string type, string postid);

        /// <summary>
        /// 修改地址
        /// </summary>
        /// <param name="emRetailOrderID"></param>
        /// <param name="receiverName"></param>
        /// <param name="receiverTelphone"></param>
        /// <param name="receiverCityZone"></param>
        /// <param name="receiverDetailAddress"></param>
        /// <returns></returns>
        UpdateResult UpdateReceiverInfo(string emRetailOrderID, string receiverName, string receiverTelphone, string receiverCityZone, string receiverDetailAddress);

        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="shopID">发货店铺</param>
        /// <param name="emRetailOrderID">订单号</param>
        /// <param name="expressCompany">物流公司</param>
        /// <param name="expressOrderID">订单号</param>
        /// <returns></returns>
        InteractResult EmOutbound(string shopID, string emRetailOrderID, string expressCompany, string expressOrderID);

        /// <summary>
        /// 拒绝退款
        /// </summary>
        /// <param name="emRefundOrderID">退款订单号</param>
        /// <param name="operateID">操作人</param>
        /// <param name="rejectCauese">拒绝理由</param>
        /// <returns></returns>
        RefundResult RefusedRefund(string emRefundOrderID, string operateID, string rejectCauese);

        /// <summary>
        /// 同意退款
        /// </summary>
        /// <param name="emRefundOrderID">退款订单号</param>
        /// <param name="operateID">操作人</param>
        /// <returns></returns>
        RefundResult AgreeRefund(string emRefundOrderID, string refundReceiverName, string refundReceiverTelphone, string refundReceiverCityZone, string refundReceiverDetailAddress, string operateID);

        /// <summary>
        /// 确认退款
        /// </summary>
        /// <param name="emRefundOrderID">退款订单号</param>
        /// <param name="operateID">操作人</param>
        /// <param name="remarks">备注</param>
        /// <returns></returns>
        RefundResult ConfirmRefund(string emRefundOrderID, string operateID, string remarks);

        /// <summary>
        /// 新增退货地址
        /// </summary>
        /// <param name="emRefundAddress"></param>
        /// <returns></returns>
        InsertResult InsertEmRefundAddress(EmRefundAddress emRefundAddress);

        /// <summary>
        /// 修改退货地址
        /// </summary>
        /// <param name="emRefundAddress"></param>
        /// <returns></returns>
        UpdateResult UpdateEmRefundAddress(EmRefundAddress emRefundAddress);

        /// <summary>
        /// 删除退货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DeleteResult DeleteEmRefundAddress(int id);

        /// <summary>
        /// 获取退货地址
        /// </summary>
        /// <returns></returns>
        List<EmRefundAddress> GetEmRefundAddressList();

        /// <summary>
        /// 修改默认地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UpdateResult UpdateDefaultEmRefundAddress(int id);

        /// <summary>
        /// 获取店铺信息 （不包含Logo）
        /// </summary>
        /// <param name="businessAccountID"></param>
        /// <returns></returns>
        EMall GetOneEMallWithoutBlob(string businessAccountID);

        /// <summary>
        /// 获取店铺Logo
        /// </summary>
        /// <param name="businessAccountID"></param>
        /// <returns></returns>
        byte[] GetEMallLogo(string businessAccountID);

        /// <summary>
        /// 修改店铺信息
        /// </summary>
        /// <param name="eMall"></param>
        /// <returns></returns>
        string UpdateEMallWithoutBlob(EMall eMall);

        /// <summary>
        /// 修改店铺Logo
        /// </summary>
        /// <param name="businessAccountID"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        UpdateResult UpdateEMallLogo(string businessAccountID,byte[] datas);

        /// <summary>
        /// 上传宣传海报图片到腾讯云
        /// </summary>
        /// <param name="businessAccountID"></param>
        /// <param name="name"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        string UploadPosterImageToCos(string businessAccountID, int index, byte[] datas);

        /// <summary>
        /// 删除海报
        /// </summary>
        /// <param name="businessAccountID"></param>
        /// <param name="photoName"></param>
        /// <returns></returns>
        InteractResult DeletePosterImage(string businessAccountID, string photoName);

        /// <summary>
        /// 修改海报顺序
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        string UpdatePosterImageIndexs(List<UpdateDisplayIndex> list);

        /// <summary>
        /// 删除腾讯云图片（并删除DB中对应的数据）
        /// </summary>
        /// <param name="photoName"></param>
        /// <returns></returns>
        DeleteResult DeletePhotoToCos(string photoName);


        /// <summary>
        /// 上传线上商品图片到腾讯云
        /// </summary>
        /// <param name="name">图片名称</param>
        /// <param name="datas">图片数据</param>
        /// <param name="emCostumePhoto"></param>
        /// <returns></returns>
        UpdateResult UploadPhotoToCos(string name, byte[] datas, EmCostumePhoto emCostumePhoto);

        /// <summary>
        /// 修改图片显示的顺序
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        UpdateResult UpdateDisplayIndexs(List<UpdateDisplayIndex> list);

        /// <summary>
        /// 根据快递单号自动匹配快递公司（返回第一个匹配的公司ID）
        /// </summary>
        /// <param name="postid"></param>
        /// <returns></returns>
        string WebAutoExpressCompanyName(string postid);

        /// <summary>
        /// 获取所有开启中的快递公司
        /// </summary>
        /// <returns></returns>
        List<EmExpressCompany> GetEnabledEmExpressCompanys();


        /// <summary>
        /// 获取所有快递公司
        /// </summary>
        /// <returns></returns>
        List<EmExpressCompany> GetAllEmExpressCompany();

        /// <summary>
        /// 批量更新快递公司信息
        /// </summary>
        /// <param name="emExpressCompanies"></param>
        /// <returns></returns>
        UpdateResult UpdateEmExpressCompanys(List<EmExpressCompany> emExpressCompanies);

        /// <summary>
        /// 获取评价信息
        /// </summary>
        /// <param name="emRetailOrderID">订单号</param>
        /// <returns></returns>
        List<EmRemark> GetEmRemarks(string emRetailOrderID);

        /// <summary>
        /// 获取退款详情过程内容
        /// </summary>
        /// <param name="emRefundOrderID"></param>
        /// <returns></returns>
        List<EmRefundTrackInfo> GetEmRefundTrackInfos(string emRefundOrderID);

        /// <summary>
        /// 获取退货单
        /// </summary>
        /// <param name="refundOrderID"></param>
        /// <returns></returns>
        EmRefundOrder GetOneEmRefundOrder(string refundOrderID);

        /// <summary>
        /// 获取线上商品分页
        /// </summary>
        /// <param name="idOrName">款号或名称</param>
        /// <param name="pageIndex"></param>
        /// <param name="isOnlyShowRecommand">是否仅显示推荐商品</param>
        /// <returns></returns>
        EmCostumePage GetEmCostumePage(string idOrName, int pageIndex, EmCostumeType emCostumeType);

        /// <summary>
        /// 获取线下商品分页
        /// </summary>
        /// <param name="idOrName"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        EmCostumePage GetOfflineCostumePage(string idOrName, int pageIndex);

        /// <summary>
        /// 获取上架（或待上架）商品信息
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        EmCostumeInfo GetEmCostumeInfo(string costumeID);

        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="emCostumeInfo"></param>
        /// <returns></returns>
        InteractResult ShelvesEmCostumeInfo(EmCostumeInfo emCostumeInfo);

        /// <summary>
        /// 修改线上商品
        /// </summary>
        /// <param name="emCostumeInfo"></param>
        /// <returns></returns>
        InteractResult UpateEmCostumeInfo(EmCostumeInfo emCostumeInfo);

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="emCostumeID"></param>
        /// <returns></returns>
        UpdateResult UpdateEmShowOnlineIsFalse(string emCostumeID);

        /// <summary>
        /// 设置商品的推荐状态
        /// </summary>
        /// <param name="emCostumeID"></param>
        /// <param name="emIsRecommand"></param>
        /// <returns></returns>
        UpdateResult UpdateEmRecommand(string emCostumeID, bool emIsRecommand);

        /// <summary>
        /// 获取有效的运费模版
        /// </summary>
        List<EmCarriageCostTemplate> GetValidCarriageCostTemplates();

        /// <summary>
        /// 获取指定运费模版详情
        /// </summary>
        /// <param name="templateID"></param>
        /// <returns></returns>
        CarriageCost GetCarriageCost(int templateID);

        #region 促销规则
        /// <summary>
        /// 获取促销规则
        /// </summary>
        /// <param name="salesPromotionID"></param>
        /// <returns></returns>
        SalesPromotion GetOneSalesPromotion(string salesPromotionID);

        /// <summary>
        /// 获取开启中的促销规则
        /// </summary>
        /// <param name="promotionType">2：全部</param>
        /// <param name="shopID"></param>
        /// <returns></returns>
        List<SalesPromotion> GetEnabledSalesPromotions(PromotionTypeEnum promotionType, string shopID, SalesPromotionState salesPromotionState);

        /// <summary>
        /// 添加促销规则
        /// </summary>
        /// <param name="sourceUserID"></param>
        /// <param name="salesPromotion"></param>
        /// <returns></returns>
        InsertResult InsertSalesPromotion(string sourceUserID, SalesPromotion salesPromotion);

        /// <summary>
        /// 更新促销规则
        /// </summary>
        /// <param name="sourceUserID"></param>
        /// <param name="salesPromotion"></param>
        /// <returns></returns>
        UpdateResult UpdateSalesPromotion(string sourceUserID, SalesPromotion salesPromotion);

        /// <summary>
        /// 删除促销规则
        /// </summary>
        /// <param name="sourceUserID"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        DeleteResult DeleteSalesPromotion(string sourceUserID, string id);

        /// <summary>
        /// 促销规则是否被使用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IsSalesPromotionUseResult IsSalesPromotionUse(string id);

        /// <summary>
        /// 使用促销的服装集合分页
        /// </summary>
        /// <param name="salesPromotionID"></param>
        /// <param name="costumeIDOrName"></param>
        /// <param name="bigClass"></param>
        /// <param name="brandID"></param>
        /// <param name="year"></param>
        /// <param name="season"></param>
        /// <param name="isInSalesPromotion"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        CostumeListPage GetSalesPromotionCostumePage(string salesPromotionID, string costumeIDOrName, int classID, int brandID, int year, string season, bool isInSalesPromotion, int pageIndex, int pageSize);

        CostumeListPage GetSalesPromotionCostumePage4NeedAdd(string costumeIDOrName, int classID, int brandID, int year, string season, int pageIndex, int pageSize, List<string> costumeIDs);


        /// <summary>
        /// 向已存在的促销规则中添加商品
        /// </summary>
        /// <param name="salesPromotionID"></param>
        /// <param name="costumeIDs"></param>
        /// <returns></returns>
        UpdateResult AddCostumeIDs(string salesPromotionID, List<string> costumeIDs);

        /// <summary>
        /// 向已存在的促销规则中移除商品
        /// </summary>
        /// <param name="salesPromotionID"></param>
        /// <param name="costumeIDs"></param>
        /// <returns></returns>
        UpdateResult RemoveCostumeIDs(string salesPromotionID, List<string> costumeIDs);

        #endregion


        #region SMS
        /// <summary>
        /// 插入短信记录
        /// </summary>
        /// <param name="returnVisitSmsRecord"></param>
        /// <returns></returns>
        InsertResult InsertSmsRecord(ReturnVisitSmsRecord returnVisitSmsRecord);

        /// <summary>
        /// 根据ID获取短信记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReturnVisitSmsRecord GetOneReturnVisitSmsRecord(string id);
        #endregion


        #region 配置信息
        /// <summary>
        /// 多少积分兑换为1元
        /// </summary>
        /// <returns></returns>
        int GetIntegrationExchange();

        /// <summary>
        /// 收银的时候售价锁定
        /// </summary>
        /// <returns></returns>
        bool IsLockSalePriceForSale();

        /// <summary>
        /// 获取配置信息值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetParaValue4ParameterConfig(string key);

        /// <summary>
        /// 更新配置信息
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        InteractResult UpdateParameterConfig(ParameterConfig config);

        #endregion
    }
}
