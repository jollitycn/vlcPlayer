using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.BLInterface
{
    public interface IRemoting4SimpleWeb
    {
        #region 角色与权限
        /// <summary>
        /// 获取用户角色与权限
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        InteractResult<UserInfo> GetUserInfo(string userID);
        
        #endregion


        #region Supplier
        /// <summary>
        /// 新增供应商
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        InteractResult InsertSupplier(Supplier supplier);

        string GetPfCustomerStores(string costumeID, string pfCustomerID);

        InteractResult<List<CommissionTemplate>> GetCommissionTemplates();

        /// <summary>
        /// 修改供应商
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        InteractResult UpdateSupplier(Supplier supplier);

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InteractResult DeleteSupplier(string id);

        string PfReturn(PfInfo pfInfo);

        string HangUpPfDelivery(PfInfo pfInfo);

        /// <summary>
        /// 模糊查询供应商列表 （根据ID或名称）
        /// </summary>
        /// <param name="idOrName"></param>
        /// <returns></returns>
        List<Supplier> GetSupplierList4IDOrName(string idOrName, bool isEnabled);

        string GetEnableBrands();

        /// <summary>
        /// 获取所有启用的供应商集合
        /// </summary>
        /// <returns></returns>
        List<Supplier> GetSupplierList4Enabled();

        /// <summary>
        /// 获取自动生成的供应商ID
        /// </summary>
        /// <returns></returns>
        InteractResult GetSupplierId();

        string CancelPfDelivery(string orderID, string userId);

        /// <summary>
        /// 根据编号获取供应商
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        Supplier GetOneSupplier(string supplierID);
        /// <summary>
        /// 获取供应商的欠款
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        decimal GetSupplierPaymentBalance(string supplierID);
        #endregion

        #region Costume
        InsertCostumeResult InsertCostume(Costume costume);

        string HangUpPfReturn(PfInfo pfInfo);
        #endregion

        #region Brand
        List<Brand> GetAllBrand();

        List<Brand> GetBrandList4IDOrName(string idOrName, bool isEnabled);

        InteractResult<int> InsertBrand( Brand brand);

        InteractResult UpdateBrand( Brand brand);

        InteractResult DeleteBrand(int id);
        #endregion

        #region Size
        /// <summary>
        /// 获取所有的尺码组
        /// </summary>
        /// <returns></returns>
        List<SizeGroup> GetAllSizeGroup();

        /// <summary>
        /// 新增尺码组
        /// </summary>
        /// <param name="sizeGroup"></param>
        /// <returns></returns>
        InteractResult InsertSizeGroup(SizeGroup sizeGroup);

        /// <summary>
        /// 更新尺码组
        /// </summary>
        /// <param name="sizeGroup"></param>
        /// <returns></returns>
        InteractResult UpdateSizeGroup(SizeGroup sizeGroup);

        string CancelPfReturn(string orderID, string userId);

        /// <summary>
        /// 删除尺码组
        /// </summary>
        /// <param name="sizeGroupName"></param>
        /// <returns></returns>
        InteractResult DeleteSizeGroup(string sizeGroupName);

        /// <summary>
        /// 检查尺码是否可用
        /// </summary>
        /// <param name="costumeID"></param>
        /// <param name="sizeGroupName"></param>
        /// <param name="sizeNames">已选择的尺码</param>
        /// <returns></returns>
        InteractResult CheckCostumeSize(string costumeID, string sizeGroupName, List<string> sizeNames);

        string GetPfInfo(string orderID);
        #endregion


        #region CostumeClass
        /// <summary>
        /// 获取所有服装分类
        /// </summary>
        /// <returns></returns>
        List<CostumeClassInfo> GetAllCostumeClass();

        #region 大类
        /// <summary>
        /// 新增大类
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        InteractResult InsertBigCostumeClass(InsertCostumeClassPara para);

        string GetPfOrderPage(GetPfOrderPagePara para);

        /// <summary>
        /// 修改大类
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        InteractResult UpdateBigCostumeClass(UpdateBigClassPara para);

        /// <summary>
        /// 删除大类
        /// </summary>
        /// <param name="bigClass"></param>
        /// <returns></returns>
        InteractResult DeleteBigCostumeClass(int id);

        /// <summary>
        /// 更新大类排序
        /// </summary>
        /// <param name="costumeClassOrderNos"></param>
        /// <returns></returns>
        UpdateResult UpdateCostumeClassOrderNo(List<CostumeClassOrderNo> costumeClassOrderNos);

        string GetCostumePfPrice(string pfCustomerID, string costumeID);

        #endregion

        #region 小类
        InteractResult InsertSmallClass(InsertSmallClassPara para);

        InteractResult UpdateSmallClass(UpdateSmallClassPara para);

        InteractResult DeleteSmallClass(int id);

        #endregion

        #region 次小类
        InteractResult InsertSubSmallClass(InsertSubSmallClassPara para);

        InteractResult UpdateSubSmallClass(UpdateSubSmallClassPara para);

        InteractResult DeleteSubSmallClass(int id);

        #endregion


        #endregion
        #region CostumeColor
        /// <summary>
        /// 获取所有颜色
        /// </summary>
        /// <returns></returns>
        List<CostumeColor> GetAllCostumeColor();

        /// <summary>
        /// 根据id或 名称 模糊查询颜色集合
        /// </summary>
        /// <param name="idOrName"></param>
        /// <returns></returns>
        List<CostumeColor> GetCostumeColor4IDOrName(string idOrName);

        /// <summary>
        /// 新增颜色
        /// </summary>
        /// <param name="costumeColor"></param>
        /// <returns></returns>
        InteractResult InsertCostumeColor(CostumeColor costumeColor);

        /// <summary>
        /// 修改颜色
        /// </summary>
        /// <param name="costumeColor"></param>
        /// <returns></returns>
        InteractResult UpdateCostumeColor(CostumeColor costumeColor);

        /// <summary>
        /// 删除颜色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InteractResult DeleteCostumeColor(string id);

        #endregion

        #region Season
        /// <summary>
        /// 获取所有季节
        /// </summary>
        /// <returns></returns>
        string[] GetAllSeason();

        /// <summary>
        /// 插入季节  （新增，修改，删除）
        /// </summary>
        /// <param name="seasons">所有季节集合</param>
        /// <returns></returns>
        InteractResult InsertSeason(string[] seasons);


        InteractResult DeleteSeason(string season);

        InteractResult UpdateSeason(string oldSeason, string newSeason);

        #endregion

        #region Purchase
        /// <summary>
        /// 采购进货
        /// </summary>
        /// <param name="purchaseCostume"></param>
        /// <returns></returns>
        InteractResult PurchaseCostume(PurchaseCostume purchaseCostume);

        /// <summary>
        /// 采购退货
        /// </summary>
        /// <param name="returnCostume"></param>
        /// <returns></returns>
        InteractResult ReturnCostume(ReturnCostume returnCostume);

        /// <summary>
        /// 采购进货挂单
        /// </summary>
        /// <param name="purchaseCostume"></param>
        /// <returns></returns>
        InteractResult HangUpPurchase(PurchaseCostume purchaseCostume);

        /// <summary>
        /// 解析条形码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string ParsingBarCode(string code);

        /// <summary>
        /// 采购退货挂单
        /// </summary>
        /// <param name="purchaseCostume"></param>
        /// <returns></returns>
        InteractResult HangUpReturn(ReturnCostume returnCostume);

        /// <summary>
        /// 取消采购
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        InteractResult CancelPurchase(string orderID, string userId);

        /// <summary>
        /// 删除挂单
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        InteractResult DeleteHangUpPurchase(string orderID);

        /// <summary>
        /// 获取采购分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        PurchaseCostumePage GetPurchaseCostumePage(string orderID, string costumeID, string supplierID, PurchaseQueryType purchaseQueryType, PurchaseType purchaseType, DateTime startDate, DateTime endDate, int pageIndex, int pageSize);

        /// <summary>
        /// 根据单号获取采购单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PurchaseCostume GetOnePurchaseOrder(string id);

        #endregion


        #region CheckStore

        /// <summary>
        /// 获取要盘点的商品列表
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="date"></param>
        /// <param name="idOrName"></param>
        /// <param name="brandIDs"></param>
        /// <param name="classIDs"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        CostumeListPage GetCostumeListPage4CheckStore(string shopId, DateTime date, string idOrName, List<int> brandIDs, List<int> classIDs, int pageIndex, int pageSize);

        /// <summary>
        /// 要盘点的商品总数
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        string GetCheckStoreCount(string shopId, DateTime date);

        /// <summary>
        /// 获取 盘点单历史库存 (获取对应的 用于 原始尺码 - 显示的尺码 - 商品数量  对应值)
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="costumeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        string GetCostumeStoreHistory4CheckStore(string shopId, string costumeID, DateTime date);

        /// <summary>
        ///  批量获取 盘点单历史库存 (获取对应的 用于 原始尺码 - 显示的尺码 - 商品数量  对应值) 
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="costumeIDs"></param>
        /// <param name="date"></param>
        /// <returns>Dictionary<string, List<CostumeStore>> key:CostumeID</returns>
        string GetCostumeStoreHistory4CheckStore(string shopId, List<string> costumeIDs, DateTime date);

        /// <summary>
        /// 新增待审核盘点单
        /// </summary>
        /// <param name="checkStore"></param>
        /// <returns></returns>
        InteractResult InsertCheckStore(CheckStoreOrder checkStoreOrder, List<CheckStoreDetail> checkStoreDetailList, DateTime date);

        /// <summary>
        /// 修改盘点单
        /// </summary>
        /// <param name="checkStore"></param>
        /// <returns></returns>
        InteractResult UpdateCheckStore(CheckStoreOrder checkStoreOrder, List<CheckStoreDetail> checkStoreDetailList, DateTime date);

        /// <summary>
        /// 删除盘点单
        /// </summary>
        /// <param name="checkStoreOrderID"></param>
        /// <returns></returns>
        InteractResult DeleteCheckStore(string checkStoreOrderID);

        /// <summary>
        /// 获取盘点分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        CheckStoreOrderPage GetCheckStoreOrderPage(string costumeID, string shopID,bool onlyShowOwnShop, CheckStoreOrderState state, DateTime startDate, DateTime endDate, int pageIndex,int pageSize);

        /// <summary>
        /// 根据单号获取单个盘点单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CheckStoreOrder GetCheckStoreOrder(string id);

        /// <summary>
        /// 获取盘点明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<CheckStoreDetail> GetCheckStoreDetail(string id);

        /// <summary>
        /// 盘点审核
        /// </summary>
        /// <param name="checkStoreOrderIDAndUser"></param>
        /// <returns></returns>
        InteractResult CheckStore(CheckStoreOrderIDAndUser checkStoreOrderIDAndUser);

        /// <summary>
        /// 盘点冲单
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        InteractResult OverrideCheckStore(string orderID, string userID);

        /// <summary>
        /// 取消盘点单
        /// </summary>
        /// <param name="checkStoreOrderIDAndUser"></param>
        /// <returns></returns>
        InteractResult CancelCheckStore(CheckStoreOrderIDAndUser checkStoreOrderIDAndUser);
        #endregion


        #region Allocate 调拨
        /// <summary>
        /// 获取调拨单分页 旧
        /// </summary>
        /// <param name="orderID">单号 （不为空则忽略其他查询条件）</param>
        /// <param name="sourceShopID">发货店铺ID</param>
        /// <param name="destShopID">收货店铺ID</param>
        /// <param name="allocateOrderState">状态</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页多少条数据</param>
        /// <returns></returns>
        AllocateOrderPage GetAllocateOrderPage(string orderID, string sourceShopID, string destShopID, AllocateOrderState allocateOrderState, DateTime startDate, DateTime endDate, int pageIndex, int pageSize);

        /// <summary>
        /// 获取调拨单分页  新
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        InteractResult<AllocateOrderPage> GetAllocateOrders(string costumeID, string shopID,bool onlyShowOwnShop, AllocateOrderState allocateOrderState, AllocateOrderType orderType, DateTime startDate, DateTime endDate, int pageIndex, int pageSize);
        /// <summary>
        /// 根据orderID获取调拨单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AllocateOrder GetOneAllocateOrder(string id);

        /// <summary>
        /// 获取调拨单明细
        /// </summary>
        /// <param name="sourceOrderID"></param>
        /// <returns></returns>
        Outbound GetOneOutbound(string sourceOrderID);

        /// <summary>
        /// 发起调拨
        /// </summary>
        /// <param name="allocateOutboundPara"></param>
        /// <returns></returns>
        InteractResult AllocateOutbound(AllocateOutboundPara allocateOutboundPara);

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        InteractResult Inbound(InboundOrder inboundOrder, List<BoundDetail> InboundDetails);

        /// <summary>
        /// 挂单调拨单
        /// </summary>
        /// <param name="allocateOutboundPara"></param>
        /// <returns></returns>
        InteractResult HangUpAllocateOrder(AllocateOutboundPara allocateOutboundPara);

        /// <summary>
        /// 调拨冲单 （已发货，已收货）
        /// </summary>
        /// <param name="orderID">调拨单号</param>
        /// <returns></returns>
        InteractResult OverrideAllocateOrder(string orderID, string cancelUserID);

        /// <summary>
        /// 根据orderID删除挂单的调拨单
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        InteractResult DeleteUpAllocateOrder(string orderID);
        #endregion

        #region 差异单
        /// <summary>
        /// 获取差异单
        /// </summary>
        /// <param name="differenceID"></param>
        /// <returns></returns>
        DifferenceOrder GetDifferenceOrder4ID(string differenceOrderID);

        /// <summary>
        /// 获取差异单详情
        /// </summary>
        /// <param name="differenceID"></param>
        /// <returns></returns>
        List<DifferenceDetail> GetDifferenceDetail(string differenceOrderID);

        /// <summary>
        /// 获取差异单 差异详情
        /// </summary>
        /// <param name="sourceOrderID">原订单ID</param>
        /// <returns></returns>
        Dictionary<string, List<DifferenceDetail>> GetDifferenceDetailInfo(string sourceOrderID);

        /// <summary>
        /// 差异单确认
        /// </summary>
        /// <param name="differenceOrderID">差异单号</param>
        /// <param name="confirmUserID">操作人ID</param>
        /// <returns></returns>
        InteractResult DifferenceOrderConfirmed(string differenceOrderID, string confirmUserID);

        /// <summary>
        /// 差异单拒绝
        /// </summary>
        /// <param name="differenceOrderID">差异单号</param>
        /// <returns></returns>
        InteractResult CancelDifferenceOrder(string differenceOrderID);

        #endregion

        #region GiftTicket 优惠券
        
        /// <summary>
        /// 获取某一会员有效的优惠券
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        List<GiftTicket> GetValidGiftTickets(string memberID);

        /// <summary>
        /// 获取优惠券允许使用的商品列表
        /// </summary>
        /// <returns></returns>
        CostumeGiftTicketInfo GetCostumeGiftTicketInfo();

        /// <summary>
        /// 获取优惠券的总面值
        /// </summary>
        /// <param name="giftTickets"></param>
        /// <returns></returns>
        int GetSumDenomination4RetailDetail(string giftTickets);

        InteractResult<CosCloudSignature> GetCosCloudSignature();

        #endregion

        string GetEnabledPfCustomers();

        string PfDelivery(PfInfo pfInfo);

    }
}
