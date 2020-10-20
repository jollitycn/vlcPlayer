using JGNet.Core.Dev.InteractEntity;
using JGNet.Core.InteractEntity;
using JGNet.Core.MyEnum;
using JGNet.Core.Pf.Enum;
using JGNet.Core.Pf.InteractEntity;
using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Dev.BLInterface.MainForm
{
    public interface IRemoting4ShopWeb
    {
        #region 线上商城
        /// <summary>
        /// 获取商城海报
        /// </summary>
        /// <returns></returns>
        string GetEMallPosterImage();

        string IsOpenAccountDistribution(string businessAccountID, AccountDistributionType type);

        /// <summary>
        /// 登陆成功后，首页加载信息，包含商品推荐第一页
        /// </summary>
        /// <returns></returns>
        string GetHomePageInfoJson();

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="costumeID"></param>
        /// <param name="colorName"></param>
        /// <param name="sizeName"></param>
        /// <param name="buyCount"></param>
        /// <returns></returns>
        string AddEmShoppingCart(string phoneNumber, string costumeID, string colorName, string sizeName, int buyCount);

        /// <summary>
        /// 修改购物车
        /// </summary>
        /// <param name="emShoppingCartId"></param>
        /// <param name="buyCount"></param>
        /// <returns></returns>
        string UpdateEmShoppingCart(string emShoppingCartId, int buyCount);

        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="emShoppingCartId"></param>
        /// <returns></returns>
        string DeleteEmShoppingCart(string emShoppingCartId);
        
        /// <summary>
        /// 获取购物车
        /// </summary>
        /// <param name="clientIP"></param>
        /// <param name="wxOpenID"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        //string GetEmShoppingCartPage(string clientIP, string phoneNumber, int pageIndex);

        /// <summary>
        /// 商品推荐分页加载
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string LoadRecommandCostume(int pageIndex);

        /// <summary>
        /// 获取总店某商品的库存数
        /// </summary>
        /// <param name="costumeID"></param>
        /// <param name="shopID"></param>
        /// <returns></returns>
        string GetCostumeStoreList_SizeCount(string costumeID);

        /// <summary>
        ///  获取促销活动
        /// </summary>
        /// <returns></returns>
        string GetSalesPromotion();

        /// <summary>
        /// 获取全部商品。0：新品：上架时间倒序。1：销量：销量降序。2：价格：升序。3：价格：降序
        /// </summary>
        /// <param name="title"></param>
        /// <param name="pageIndex"></param>
        /// <param name="costumeSortType"></param>
        /// <returns></returns>
        string GetEmCostumePage(string title, int pageIndex, CostumeSortType costumeSortType);

        string GetAdsImages();

        /// <summary>
        /// 新增店铺评价
        /// </summary>
        /// <param name="memeberID"></param>
        /// <param name="emRetailOrderID"></param>
        /// <param name="goodsScore"></param>
        /// <param name="serviceAttitudeScore"></param>
        /// <param name="expressScore"></param>
        /// <returns></returns>
        string InsertEmStoreRemark(string memeberID, string emRetailOrderID, byte goodsScore, byte serviceAttitudeScore, byte expressScore);

        string SeeCommission(string customerID, DistributorType distributorType);

        /// <summary>
        /// 退款申请
        /// </summary>
        /// <param name="emRetailOrderID"></param>
        /// <param name="totalMoneyRefund"></param>
        /// <param name="refundCause"></param>
        /// <param name="refundNote"></param>
        /// <param name="myEmOrderDetails"></param>
        /// <param name="isOnlyRefund"></param>
        /// <returns></returns>
        string RefundApplication(string emRetailOrderID, decimal totalMoneyRefund, string refundCause, string refundNote, List<MyEmOrderDetail> myEmOrderDetails, bool isOnlyRefund);

        string GetClassUrls();

        /// <summary>
        /// 获取openid
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string GetOpenid(string code);

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        string GetAccessToken();

        /// <summary>
        /// 获取微信小程序码
        /// </summary>
        /// <returns></returns>
        string Getwxacodeunlimit(string scene);

        /// <summary>
        /// 更新AccessToken
        /// </summary>
        /// <returns></returns>
        string UpdateAccessToken();

        /// <summary>
        /// 获取启用的快递公司信息列表
        /// </summary>
        /// <returns></returns>
        string GetEnabledEmExpressCompanys(LanguageType languageType);

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetParaValue4ParameterConfig(string key);

        /// <summary>
        /// 获取充值赠送规则
        /// </summary>
        /// <returns></returns>
        string GetRechargeDonateRule();

        string GetCosCloudSignature();

        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        InsertResult AddMember(string phoneNumber, string name,string introducerID);

        /// <summary>
        /// 点击服装获取详情
        /// </summary>
        /// <param name="clientIP"></param>
        /// <param name="wxOpenID"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        string GetEmCostumeDetail(string clientIP, string phoneNumber, string costumeID);

        string GetPfCommissionPayWay();

        /// <summary>
        /// 规格选择，默认给出颜色与尺码
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        string GetSpecsChoose(string costumeID);

        /// <summary>
        /// 获取用户评价
        /// </summary>
        /// <param name="costumeID"></param>
        /// <param name="pageIndex"></param>
        /// <param name="remarkScore"></param>
        /// <returns></returns>
        string GetEmRemarkPage(string costumeID, int pageIndex, int remarkScore);

        /// <summary>
        /// 获取服装库存
        /// </summary>
        /// <param name="costumeID"></param>
        /// <param name="colorName"></param>
        /// <param name="sizeName"></param>
        /// <returns></returns>
        string GetEmCostumeStore(string costumeID, string colorName, string sizeName);

        /// <summary>
        /// 分类
        /// </summary>
        /// <returns></returns>
        string GetEmCostumeByClassification();

        /// <summary>
        /// 根据大类分页查询
        /// </summary>
        /// <param name="bigClass"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string GetEmCostumeByBigClass(int classID, int pageIndex);

        /// <summary>
        /// 收藏商品
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        string AddEmFavoriteCostume(string phoneNumber, string costumeID);

        /// <summary>
        /// 获取我的收藏
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string GetEmFavoriteCostumePage(string phoneNumber, int pageIndex);

        /// <summary>
        /// 批量删除收藏的商品
        /// </summary>
        /// <param name="emFavoriteCostumeIDs"></param>
        /// <returns></returns>
        string DeleteEmFavoriteCostume(List<int> emFavoriteCostumeIDs);


        string DeleteEmFavoriteCostume(string phoneNumber, List<string> costumeIDs);


        /// <summary>
        /// 删除指定收藏的商品
        /// </summary>
        /// <param name="emFavoriteCostumeID"></param>
        /// <returns></returns>
        string DeleteEmFavoriteCostume(int emFavoriteCostumeID);

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="totalMoneyReceived"></param>
        /// <param name="emShoppingCartIDs"></param>
        /// <param name="wxMemberAddressID"></param>
        /// <param name="salesPromotionID"></param>
        /// <param name="carriageCost"></param>
        /// <param name="moneyDiscounted"></param>
        /// <param name="buyerMessage"></param>
        /// <param name="giftTicketIDKeys"></param>
        /// <returns></returns>
        string ConfirmOrder(string memberID, decimal totalMoneyReceived, List<int> emShoppingCartIDs, int wxMemberAddressID, string salesPromotionID, decimal carriageCost, decimal moneyDiscounted, string buyerMessage, List<string> giftTicketIDKeys);

        /// <summary>
        /// 获取店铺评分
        /// </summary>
        /// <returns></returns>
        string GetEmStoreScore();

        /// <summary>
        /// 获取充值记录id
        /// </summary>
        /// <returns></returns>
        string GetRechargeRecordID();

        /// <summary>
        ///  获取 我的订单 分页信息
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="state"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string GetEmRetailOrderPage(string memberID, int state, int pageIndex);

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string DeleteEmRetailOrder(string id);

        /// <summary>
        /// 查看物流
        /// </summary>
        /// <param name="expressCompany"></param>
        /// <param name="expressOrderID"></param>
        /// <returns></returns>
        string GetLogistics(string expressCompany, string expressOrderID);

        /// <summary>
        /// 修改退款申请
        /// </summary>
        /// <param name="emRetailOrderID"></param>
        /// <param name="refundCause"></param>
        /// <param name="totalMoneyRefund"></param>
        /// <returns></returns>
        string UpdateRefundApplication(string emRetailOrderID, string refundCause, decimal totalMoneyRefund);

        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string CloseEmRetailOrder(string id);

        /// <summary>
        /// 确认收货
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string ConfirmReceive(string id);

        /// <summary>
        /// 发表评价
        /// </summary>
        /// <param name="memeberID"></param>
        /// <param name="emRetailOrderID"></param>
        /// <param name="costumeID"></param>
        /// <param name="brandName"></param>
        /// <param name="colorName"></param>
        /// <param name="sizeName"></param>
        /// <param name="remarkScore"></param>
        /// <param name="remarkContent"></param>
        /// <param name="anonymous"></param>
        /// <returns></returns>
        string InsertEmRemark(string memeberID, string emRetailOrderID, string costumeID, string brandName, string colorName, string sizeName, int remarkScore, string remarkContent, int anonymous);

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="emRemarkID"></param>
        /// <param name="photoName"></param>
        /// <param name="datas"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        string UploadPhoto(int emRemarkID, string photoName, byte[] datas, int index);

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetOrderDetail(string id);

        /// <summary>
        /// 获取邮费
        /// </summary>
        /// <param name="carriageCostTemplateID"></param>
        /// <param name="province"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        string GetCarriageCost(int carriageCostTemplateID, string province, string city);

        /// <summary>
        /// 获取商品列表中最大的邮费值
        /// </summary>
        /// <param name="carriageCostTemplateIDs"></param>
        /// <param name="province"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        string GetMaxCarriageCost4Choose(List<int> carriageCostTemplateIDs, string province, string city);

        /// <summary>
        /// 获取logo
        /// </summary>
        /// <returns></returns>
        string GetLogo();

        /// <summary>
        /// 获取商城名称
        /// </summary>
        /// <param name="businessAccountID"></param>
        /// <returns></returns>
        string GetEmallName(string businessAccountID);

        /// <summary>
        /// 立即下单
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="totalMoneyReceived"></param>
        /// <param name="costumeID"></param>
        /// <param name="colorName"></param>
        /// <param name="sizeName"></param>
        /// <param name="buyCount"></param>
        /// <param name="wxMemberAddressID"></param>
        /// <param name="salesPromotionID"></param>
        /// <param name="carriageCost"></param>
        /// <param name="moneyDiscounted"></param>
        /// <param name="buyerMessage"></param>
        /// <param name="giftTicketIDs"></param>
        /// <returns></returns>
        string Shopping(string memberID, decimal totalMoneyReceived, string costumeID, string colorName, string sizeName, int buyCount, int wxMemberAddressID, string salesPromotionID, decimal carriageCost, decimal moneyDiscounted,
            string buyerMessage, List<string> giftTicketIDs);

        /// <summary>
        /// 获取余额和积分
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        string GetBalanceAndIntegration(string phoneNumber);

        /// <summary>
        /// 填写物流单号
        /// </summary>
        /// <param name="emRetailOrderID"></param>
        /// <param name="expressCompany4Refund"></param>
        /// <param name="expressOrderID4Refund"></param>
        /// <returns></returns>
        string WriteExpress(string emRetailOrderID, string expressCompany4Refund, string expressOrderID4Refund);

        /// <summary>
        /// VIP卡支付
        /// </summary>
        /// <param name="emRetailOrderID"></param>
        /// <param name="moneyVipCard"></param>
        /// <param name="moneyIntegration"></param>
        /// <returns></returns>
        string PayInVIPCard(string emRetailOrderID, decimal moneyVipCard, decimal moneyIntegration);

        /// <summary>
        /// 会员登陆
        /// </summary>
        /// <param name="ip"></param>
        void AddIP(string ip);

        /// <summary>
        /// 检查库存
        /// </summary>
        /// <param name="myEmOrderDetails"></param>
        /// <returns></returns>
        string CheckCostumeStore(List<MyEmOrderDetail> myEmOrderDetails);

        /// <summary>
        /// 退货单详情
        /// </summary>
        /// <param name="emRetailOrderID"></param>
        /// <returns></returns>
        string GetRefundDetail(string emRetailOrderID);

        /// <summary>
        /// 退款详情
        /// </summary>
        /// <param name="emRetailOrderID"></param>
        /// <returns></returns>
        string GetEmRefundTrackInfos(string emRetailOrderID, LanguageType languageType);

        /// <summary>
        /// 获取会员有效的电子优惠券列表
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        string GetValidGiftTickets(string memberID);

        /// <summary>
        /// 获取服装对应的电子礼券使用情况
        /// </summary>
        /// <returns></returns>
        string GetCostumeGiftTicketInfo();

        /// <summary>
        /// 获取手机号码
        /// </summary>
        /// <param name="wxOpenID"></param>
        /// <param name="encryptedData"></param>
        /// <param name="iv"></param>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        string GetPhoneNumber(string wxOpenID, string encryptedData, string iv, string sessionKey);

        /// <summary>
        /// 获取电子优惠券使用情况
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="retailDetailList"></param>
        /// <returns></returns>
        string CalcGiftTickets(string memberID, List<RetailDetail> retailDetailList);

        /// <summary>
        /// 获取订单待处理条数
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        string GetOrderCount(string memberID);

        /// <summary>
        /// 获取线上店铺海报图片
        /// </summary>
        /// <returns></returns>
        string GetEmPosterImages();
        #endregion

        #region 批发商城

        /// <summary>
        /// 批发客户登陆校验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        string PfCustomerLogin(string id, string pwd);

        /// <summary>
        /// 获取批发商城的首页信息
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <returns></returns>
        string GetPfHomeInfoJson(string pfCustomerID);

        /// <summary>
        /// 获取整合商城的首页信息
        /// </summary>
        /// <param name="olCustomerType"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        string GetOnlineHomeInfo(OLCustomerType olCustomerType, string customerID);

        /// <summary>
        /// 根据批发客户的折扣获取批发商品信息
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="idOrName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pfCostumeType"></param>
        /// <returns></returns>
        string QueryPfCostumePageJson(string pfCustomerID, string idOrName, int pageIndex, OLCostumeType pfCostumeType);

        /// <summary>
        /// 根据客户的折扣获取批发商品信息
        /// </summary>
        /// <param name="olCustomerType"></param>
        /// <param name="customerID"></param>
        /// <param name="idOrName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pfCostumeType"></param>
        /// <returns></returns>
        string GetOLCostumePage(OLCustomerType olCustomerType, string customerID, string idOrName, int pageIndex, OLCostumeType pfCostumeType);

        /// <summary>
        /// 根据客户的类型和商品ID 获取批发商品信息
        /// </summary>
        /// <param name="customerType"></param>
        /// <param name="customerID"></param>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        string GetOneOLCostume(OLCustomerType customerType, string customerID, string costumeID);

        /// <summary>
        /// 获取批发客户收藏的批发商品分页信息
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string GetPfCustomerFavoriteCostumePage(string pfCustomerID, int pageIndex);


        /// <summary>
        /// 获取客户收藏的批发商品分页信息 （新整合）
        /// </summary>
        /// <param name="oLCustomerType"></param>
        /// <param name="customerID"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string GetOLCustomerFavoriteCostumePage(OLCustomerType oLCustomerType, string customerID, int pageIndex);

        /// <summary>
        /// 新增批发客户收藏的批发商品
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        string AddPfCustomerFavoriteCostume(string pfCustomerID, string costumeID);

        /// <summary>
        /// 删除批发客户收藏的批发商品
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="costumeIDs"></param>
        /// <returns></returns>
        string DeletePfCustomerFavoriteCostume(string pfCustomerID, List<string> costumeIDs);

        /// <summary>
        /// 获取批发商品信息明细
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        string GetPfCostumeDetail(string pfCustomerID, string costumeID);

        /// <summary>
        /// 获取所有大类和第一个大类的商品信息
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <returns></returns>
        string GetPfCostumeByClassification(string pfCustomerID);

        /// <summary>
        /// 根据大类获取批发商品信息
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="bigClass"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string GetPfCostumeByBigClass(string pfCustomerID, int classID, int pageIndex);

        /// <summary>
        /// 根据客户类型 获取所有大类和第一个大类的商品信息
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <returns></returns>
        string GetOLCostumeByClassification(OLCustomerType customerType, string customerID);

        /// <summary>
        /// 根据客户类型和大类 获取批发商品信息
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="bigClass"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string GetOLCostumeByBigClass(OLCustomerType customerType, string customerID, int classID, int pageIndex);

        /// <summary>
        /// 新增批发客户收货地址
        /// </summary>
        /// <param name="pfCustomerAddress"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        string AddPfCustomerAddress(PfCustomerAddress pfCustomerAddress, bool isDefault);

        /// <summary>
        /// 修改批发客户收货地址
        /// </summary>
        /// <param name="pfCustomerAddress"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        string UpdatePfCustomerAddress(PfCustomerAddress pfCustomerAddress, bool isDefault);

        /// <summary>
        /// 删除批发客户收货地址
        /// </summary>
        /// <param name="pfCustomerAddressId"></param>
        /// <returns></returns>
        string DeletePfCustomerAddress(int pfCustomerAddressId);

        /// <summary>
        /// 获取批发客户收货地址列表
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <returns></returns>
        string GetPfCustomerAddressListJson(string pfCustomerID);

        /// <summary>
        /// 获取批发客户收货地址列表 （返回整合的List<DeliveryAddress> 集合）
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <returns></returns>
        string GetPfCustomerAddressListJson2(string pfCustomerID);

        /// <summary>
        /// 获取批发客户的购物车分页信息
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string GetPfShoppingCartPageJson(string pfCustomerID, int pageIndex,bool isEmRetail=false);

        /// <summary>
        /// 获取客户购物车分页信息
        /// </summary>
        /// <param name="oLCustomerType"></param>
        /// <param name="userID"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        //string GetOLShoppingCartPageJson(OLCustomerType oLCustomerType, string userID, int pageIndex);

        /// <summary>
        /// 删除批发购物车
        /// </summary>
        /// <param name="pfShoppingCartIds"></param>
        /// <returns></returns>
        string DeletePfShoppingCarts(List<int> pfShoppingCartIds);

        /// <summary>
        /// 添加批发客户购物车
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="costumeID"></param>
        /// <param name="colorName_sizeNameCounts">key:颜色，value</param>
        /// <returns></returns>
        string AddPfShoppingCart(string pfCustomerID, string costumeID, List<AddPfShoppingCartPara> paras, bool isEmRetail = false);

        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="oLCustomerType"></param>
        /// <param name="userID"></param>
        /// <param name="costumeID"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        //string AddOLShoppingCart(OLCustomerType oLCustomerType, string userID, string costumeID, List<AddPfShoppingCartPara> paras);

        /// <summary>
        /// 修改批发客户购物车购物数量
        /// </summary>
        /// <param name="emShoppingCartId"></param>
        /// <param name="buyCount"></param>
        /// <returns></returns>
        string UpdatePfShoppingCart(List<UpdatePfShoppingCartInfo> infos);

        /// <summary>
        /// 填写订单
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="totalMoneyReceived"></param>
        /// <param name="shoppingCartIDs"></param>
        /// <param name="pfCustomerAddressId"></param>
        /// <param name="remarks"></param>
        /// <returns></returns>
        string ConfirmPfShoppingCarts(string pfCustomerID, decimal totalMoneyReceived, List<int> shoppingCartIDs, int pfCustomerAddressId, string remarks);

        /// <summary>
        /// 批发订货单付款
        /// </summary>
        /// <param name="pfCustomerOrderId"></param>
        /// <param name="totalPfPrice"></param>
        /// <returns></returns>
        string PayPfCustomerOrder(string pfCustomerOrderId);

        /// <summary>
        /// 获取批发订货单分页信息
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <returns></returns>
        string GetPfCustomerOrderPageJson(string pfCustomerID, int pageIndex, DateTime startTime, DateTime endTime, PfCustomerOrderState state);

        /// <summary>
        /// 获取批发订货单的总批发价和余额
        /// </summary>
        /// <param name="pfCustomerOrderId"></param>
        /// <returns></returns>
        string GetPfCustomerOrderTotalPfPriceAndBalance(string pfCustomerOrderId);

        /// <summary>
        /// 批发统计
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        string GetPfStatistics(string pfCustomerID, int year);

        /// <summary>
        /// 获取批发订货单的发货记录
        /// </summary>
        /// <returns></returns>
        string GetPfCustomerOrderDeliveryrecord(string pfCustomerOrderId);

        /// <summary>
        /// 获取批发订货单的发货记录详情
        /// </summary>
        /// <param name="pfOrderId"></param>
        /// <returns></returns>
        string GetPfCustomerOrderDeliveryrecordDetail(string pfCustomerOrderId, string pfOrderId);

        /// <summary>
        /// 获取批发客户信息
        /// </summary>
        /// <param name="pfCustomerId"></param>
        /// <returns></returns>
        string GetPfCustomerJson(string pfCustomerId);

        /// <summary>
        /// 获取批发客户默认收货地址ID
        /// </summary>
        /// <param name="pfCustomerId"></param>
        /// <returns></returns>
        int GetPfDefaultAddressID(string pfCustomerId);

        /// <summary>
        /// 获取批发客户默认收货地址
        /// </summary>
        /// <param name="pfCustomerId"></param>
        /// <returns></returns>
        string GetDefaultAddressJson(string pfCustomerId);

        /// <summary>
        /// 获取批发客户默认收货地址 （返回整合的DeliveryAddress 对象）
        /// </summary>
        /// <param name="pfCustomerId"></param>
        /// <returns></returns>
        string GetPfDefaultAddress(string pfCustomerId);

        /// <summary>
        /// 获取批发订货单明细
        /// </summary>
        /// <param name="pfCustomerOrderID"></param>
        /// <returns></returns>
        string GetPfCustomerDetails(string pfCustomerOrderID);

        /// <summary>
        /// 修改批发客户密码
        /// </summary>
        /// <param name="pfCustomerId"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        string UpdatePfCustomerPwd(string pfCustomerId, string oldPwd, string newPwd);
        #endregion

        #region 分销
        /// <summary>
        /// 获取分销人员实体
        /// </summary>
        /// <param name="distributorId"></param>
        /// <returns></returns>
        string GetOneDistributor(string distributorId);

        /// <summary>
        /// 获取分销人员信息
        /// </summary>
        /// <param name="distributorId"></param>
        /// <returns></returns>
        string GetDistributorInfo(string distributorId, DistributorType distributorType);

        /// <summary>
        /// 获取分销佣金详情
        /// </summary>
        /// <param name="distributorId"></param>
        /// <param name="distributorType"></param>
        /// <returns></returns>
        string GetDistributorCommission(string distributorId, DistributorType distributorType);

        /// <summary>
        /// 获取佣金明细
        /// </summary>
        /// <param name="distributorId"></param>
        /// <param name="distributorType"></param>
        /// <returns></returns>
        string GetCommissionDetail(string distributorId, DistributorType distributorType);

        /// <summary>
        ///  获取佣金明细详情
        /// </summary>
        /// <param name="distributorId"></param>
        /// <param name="distributorType"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        string GetDistributorCommissionRecords(string distributorId, DistributorType distributorType, int level);

        /// <summary>
        /// 分销人员下线信息
        /// </summary>
        /// <param name="distributorID">分销人员ID</param>
        /// <param name="distributorType">分销人员类型 0：批发； 1：零售</param>
        /// <param name="sequenceCode">分销人员的序列编码</param>
        /// <returns></returns>
        string GetLineInfos(string distributorID, DistributorType distributorType, string sequenceCode);

        /// <summary>
        /// 获取分销人员的 下线信息 (下线分析接口)
        /// </summary>
        /// <param name="distributorId"></param>
        /// <param name="day">-1表示所有。（N： 最后购买日期大于N天的）</param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string GetPfCustomers4Distributor(string distributorId, int day, int pageIndex);

        /// <summary>
        /// 提现申请
        /// </summary>
        /// <returns></returns>
        string InsertDistributorWithdrawRecord(DistributorWithdrawRecord distributorWithdrawRecord);

        /// <summary>
        /// 获取提现申请分页信息
        /// </summary>
        /// <param name="state"></param>
        /// <param name="distributorID"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        string GetDistributorWithdrawRecordPage(DistributorWithdrawRecordState state,string distributorID, int pageIndex);

        /// <summary>
        /// 根据批发客户的折扣获取批发商品信息
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="idOrName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pfCostumeType"></param>
        /// <returns></returns>
        string GetPfCostume4BarCodeValueJson(string pfCustomerID, string barCodeValue);
        #endregion
    }
}
