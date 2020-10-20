using JGNet.Core;
using JGNet.Core.Const;
using JGNet.Core.Dev.InteractEntity;
using JGNet.Core.InteractEntity;
using JGNet.Core.MyEnum;
using JGNet.Core.Tools;
using CJBasic;
using CJPlus.Rapid;
using CJPlus.Serialization;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Common
{
    public class ServerProxy
    {
        protected IRapidPassiveEngine engine;

        public ServerProxy(IRapidPassiveEngine _engine)
        {
            this.engine = _engine;
        }

        /// <summary>
        /// 库存变化查询
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public CostumeStoreChange GetCostumeStoreChange(GetCostumeStoreChangePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreChange, request);

            return CompactPropertySerializer.Default.Deserialize<CostumeStoreChange>(response, 0);
        }


        /// <summary>
        /// 获取采购明细
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public List<BoundDetail> GetPurchaseDetails(string orderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.GetPurchaseDetails, SerializeHelper.StringToByteArray(orderID));

            return CompactPropertySerializer.Default.Deserialize<List<BoundDetail>>(response, 0);
        }

        /// <summary>
        /// 取消差异单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractResult CancelDifferenceOrder(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.CancelDifferenceOrder, SerializeHelper.StringToByteArray(id));
            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 拒绝补货申请单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractResult RefusedReplenishOrder(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.RefusedReplenishOrder, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 进货库存变化查询
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InReturnTrackChange GetCostumeStoreChange4In(GetCostumeStoreChangePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreChange4In, request);

            return CompactPropertySerializer.Default.Deserialize<InReturnTrackChange>(response, 0);
        }

        /// <summary>
        /// 转入库存变化查询
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public IntoTurnOutTrackChange GetCostumeStoreChange4Into(GetCostumeStoreChangePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreChange4Into, request);

            return CompactPropertySerializer.Default.Deserialize<IntoTurnOutTrackChange>(response, 0);
        }

        /// <summary>
        /// 退货库存变化查询
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InReturnTrackChange GetCostumeStoreChange4Return(GetCostumeStoreChangePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreChange4Return, request);

            return CompactPropertySerializer.Default.Deserialize<InReturnTrackChange>(response, 0);
        }

        /// <summary>
        /// 转出库存变化查询
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public IntoTurnOutTrackChange GetCostumeStoreChange4TurnOut(GetCostumeStoreChangePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreChange4TurnOut, request);

            return CompactPropertySerializer.Default.Deserialize<IntoTurnOutTrackChange>(response, 0);
        }

        /// <summary>
        /// 销售库存变化查询
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public RetailTrackChange GetCostumeStoreChange4Retail(GetCostumeStoreChangePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreChange4Retail, request);

            return CompactPropertySerializer.Default.Deserialize<RetailTrackChange>(response, 0);
        }

        /// <summary>
        /// 根据销售单id模糊查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RetailOrder> GetRetailOrder4ID(string id, string shopID)
        {
            Parameter<string, string> para = new Parameter<string, string>(id, shopID);
            byte[] response = this.engine.CustomizeOutter.Query(PosInformationTypes.GetRetailOrder4ID, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<RetailOrder>>(response, 0);
        }

        /// <summary>
        /// 报损库存变化查询
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ScrapTrackChange GetCostumeStoreChange4Scrap(GetCostumeStoreChangePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreChange4Scrap, request);

            return CompactPropertySerializer.Default.Deserialize<ScrapTrackChange>(response, 0);
        }

        /// <summary>
        /// 盈亏库存变化查询
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ProfitTrackChange GetCostumeStoreChange4Profit(GetCostumeStoreChangePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreChange4Profit, request);

            return CompactPropertySerializer.Default.Deserialize<ProfitTrackChange>(response, 0);
        }

        /// <summary>
        /// 获取库存的吊牌价
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        public CostumePrice GetCostumeStorePrice(string shopId, string costumeID)
        {
            Parameter<string, string> para = new Parameter<string, string>(shopId, costumeID);
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStorePrice, request);

            return CompactPropertySerializer.Default.Deserialize<CostumePrice>(response, 0);
        }

        /// <summary>
        /// 盘点单获取历史库存
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        public WebResponseObj<List<CostumeStoreHistory>> GetCostumeStoreHistory4CheckStore(string shopId, string costumeID, Date date, bool isCheckColors)
        {
            Parameter<string, string, Date, bool> para = new Parameter<string, string, Date, bool>(shopId, costumeID, date, isCheckColors);
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreHistory4CheckStore, request);

            return CompactPropertySerializer.Default.Deserialize<WebResponseObj<List<CostumeStoreHistory>>>(response, 0);
        }

        /// <summary>
        /// 盘点冲单
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public InteractResult OverrideCheckStore(string orderID, string userID)
        {
            Parameter<string, string> para = new Parameter<string, string>(orderID, userID);
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.OverrideCheckStore, request);

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取本店库存情况（补全库存不存在信息）
        /// </summary>
        /// <param name="costumeStoreListPara"></param>
        /// <returns></returns>
        public List<CostumeItem> GetCostumeStores(CostumeStoreListPara costumeStoreListPara)
        {
            byte[] request = SerializeHelper.ResultToSerialize(costumeStoreListPara);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStores, request);

            return CompactPropertySerializer.Default.Deserialize<List<CostumeItem>>(response, 0);
        }

        /// <summary>
        /// 调拨单挂单
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult HangUpAllocateOrder(AllocateOutboundPara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.HangUpAllocateOrder, request);

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 删除挂单的调拨单。
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public InteractResult DeleteUpAllocateOrder(string orderID)
        {
            byte[] request = SerializeHelper.StringToByteArray(orderID);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DeleteUpAllocateOrder, request);

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取自动生成条形码
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public WebResponseObj<BarCode4CostumeInfo> GetBarCode4Costume(BarCode4Costume para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetBarCode4Costume, request);

            return CompactPropertySerializer.Default.Deserialize<WebResponseObj<BarCode4CostumeInfo>>(response, 0);
        }

        /// <summary>
        /// 禁用批发客户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractResult DisablePfCustomer(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DisablePfCustomer, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 根据类别编码获取类别id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractResult GetClassCode4ID(int id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetClassCode4ID, SerializeHelper.StringToByteArray(id.ToString()));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }


        /// <summary>
        /// 获取 批发客户库存分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public PfCustomerStorePage GetPfCustomerStorePage(GetPfCustomerStorePagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.GetPfCustomerStorePage, SerializeHelper.ResultToSerialize(para));
            return CompactPropertySerializer.Default.Deserialize<PfCustomerStorePage>(response, 0);
        }

        /// <summary>
        /// 获取批发客户库存信息
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        public List<CostumeItem> GetPfCustomerStores(string pfCustomerID, string costumeID, bool isAccurateGetCostumeID = false)
        {
            Parameter<string, string, bool> para = new Parameter<string, string, bool>(pfCustomerID, costumeID, isAccurateGetCostumeID);
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.GetPfCustomerStores, SerializeHelper.ResultToSerialize(para));
            return CompactPropertySerializer.Default.Deserialize<List<CostumeItem>>(response, 0);
        }

        /// <summary>
        /// 根据类别编码获取类别
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public CostumeClass2 GetCostumeClass4Code(string code)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeClass4Code, SerializeHelper.StringToByteArray(code));

            return CompactPropertySerializer.Default.Deserialize<CostumeClass2>(response, 0);
        }

        /// <summary>
        /// 获取自动生成条形码
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public WebResponseObj<List<BarCode4CostumeInfo>>  GetBarCode4CostumeInfos(List<BarCode4Costume> para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetBarCode4CostumeInfos, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<WebResponseObj<List<BarCode4CostumeInfo>>>(response, 0);
        }

        /// <summary>
        /// 解析条形码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public InteractResult<BarCode4Costume> ParsingBarCode(string code)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.ParsingBarCode, SerializeHelper.StringToByteArray(code));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<BarCode4Costume>>(response, 0);
        }

        /// <summary>
        /// 商品档案导入
        /// </summary>
        /// <param name="costumes"></param>
        /// <returns></returns>
        public InteractResult ImportCostumes(List<Costume> costumes)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.ImportCostumes, SerializeHelper.ResultToSerialize(costumes));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 采购付款管理
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<SupplierAccountRecordPage> PurchasePayManage(PurchasePayManagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.PurchasePayManage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<SupplierAccountRecordPage>>(response, 0);
        }

        /// <summary>
        /// 供应商往来账对账表
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<SupplierAccountContrastItem> GetSupplierAccountContrast(SupplierAccountContrastPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetSupplierAccountContrast, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<SupplierAccountContrastItem>>(response, 0);
        }

        /// <summary>
        /// 根据单据id查询供应商往来账明细
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public InteractResult<SupplierAccountRecord> GetSupplierAccountRecord(string orderId, SARSQueryType sARSQueryType)
        {
            Parameter<string, SARSQueryType> para = new Parameter<string, SARSQueryType>(orderId, sARSQueryType);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetSupplierAccountRecord, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<SupplierAccountRecord>>(response, 0);
        }

        /// <summary>
        /// 供应商往来账汇总
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<SupplierAccountRecordSummaryInfo>> GetSupplierAccountRecordSummary(SupplierAccountRecordSummaryPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetSupplierAccountRecordSummary, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<SupplierAccountRecordSummaryInfo>>>(response, 0);
        }

        /// <summary>
        /// 供应商往来账汇总明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<SupplierAccountRecord>> GetSupplierAccountRecord4Summary(SupplierAccountRecord4SummaryPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetSupplierAccountRecord4Summary, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<SupplierAccountRecord>>>(response, 0);
        }

        /// <summary>
        /// 批发收款管理
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<PfAccountRecordPage> PfCollectionManage(PfCollectionManagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.PfCollectionManage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<PfAccountRecordPage>>(response, 0);
        }

        /// <summary>
        /// 客户往来账对账表
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<PfAccountContrastItem> GetPfAccountContrast(PfAccountContrastPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfAccountContrast, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<PfAccountContrastItem>>(response, 0);
        }

        /// <summary>
        /// 根据单据id查询客户往来账明细
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public InteractResult<PfAccountRecord> GetPfAccountRecord(string orderId, PARSQueryType pARSQueryType)
        {
            Parameter<string, PARSQueryType> para = new Parameter<string, PARSQueryType>(orderId, pARSQueryType);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfAccountRecord, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<PfAccountRecord>>(response, 0);
        }

        /// <summary>
        /// 供应商往来账汇总
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<PfAccountRecordSummaryInfo>> GetPfAccountRecordSummary(PfAccountRecordSummaryPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfAccountRecordSummary, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PfAccountRecordSummaryInfo>>>(response, 0);
        }

        /// <summary>
        /// 供应商往来账汇总明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<PfAccountRecord>> GetPfAccountRecord4Summary(PfAccountRecord4SummaryPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfAccountRecord4Summary, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PfAccountRecord>>>(response, 0);
        }

        /// <summary>
        /// 供应商导入
        /// </summary>
        /// <param name="suppliers"></param>
        /// <returns></returns>
        public InteractResult ImportSupplier(List<Supplier> suppliers)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.ImportSupplier, SerializeHelper.ResultToSerialize(suppliers));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 客户导入
        /// </summary>
        /// <param name="pfCustomers"></param>
        /// <returns></returns>
        public InteractResult ImportPfCustomer(List<PfCustomer> pfCustomers)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.ImportPfCustomer, SerializeHelper.ResultToSerialize(pfCustomers));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 品牌导入
        /// </summary>
        /// <param name="brands"></param>
        /// <returns></returns>
        public InteractResult ImportBrand(List<Brand> brands)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.ImportBrand, SerializeHelper.ResultToSerialize(brands));
            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 类别导入
        /// </summary>
        /// <param name="costumeClass2s"></param>
        /// <returns></returns>
        public InteractResult ImportCostumeClass(List<CostumeClass2> costumeClass2s)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.ImportCostumeClass, SerializeHelper.ResultToSerialize(costumeClass2s));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 采购单绑定供应商
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public InteractResult PurchaseBindingSupplierID(string orderId, string supplierID)
        {
            Parameter<string, string> para = new Parameter<string, string>(orderId, supplierID);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.PurchaseBindingSupplierID, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 会员消费汇总
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<ReatilSumInfo>> GetReatilSumInfo(GetReatilSumInfoPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetReatilSumInfo, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<ReatilSumInfo>>>(response, 0);
        }

        /// <summary>
        /// 会员余额变化
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<MemberBalanceChange>> GetMemberBalanceChange(GetMemberBalanceChangePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetMemberBalanceChange, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<MemberBalanceChange>>>(response, 0);
        }

        /// <summary>
        /// 获取销售单
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="dateInt"></param>
        /// <returns></returns>
        public InteractResult<List<RetailOrder>> GetReatilOrders(string memberID, int dateInt)
        {
            Parameter<string, int> para = new Parameter<string, int>(memberID, dateInt);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetReatilOrders, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<RetailOrder>>>(response, 0);
        }

        /// <summary>
        /// 客户进销存
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<PfCustomerInvoicing>> GetPfCustomerInvoicing(GetPfCustomerInvoicingPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfCustomerInvoicing, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PfCustomerInvoicing>>>(response, 0);
        }

        /// <summary>
        /// 客户进销存(输入一个款号时)
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<PfCustomerInvoicing>> GetPfInvoicingOnlyCostumeID(GetPfCustomerInvoicingPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfInvoicingOnlyCostumeID, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PfCustomerInvoicing>>>(response, 0);
        }

        /// <summary>
        /// 删除店铺
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public InteractResult DeleteShop(string shopId)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DeleteShop, SerializeHelper.StringToByteArray(shopId));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 商品进销存
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<CostumeInvoicing>> GetCostumeInvoicing(GetCostumeInvoicingPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeInvoicing, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<CostumeInvoicing>>>(response, 0);
        }

        /// <summary>
        /// 获取会员某天充值记录
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public InteractResult<List<RechargeRecord>> GetRechargeRecords4Day(string memberID, int dateInt)
        {
            Parameter<string, int> para = new Parameter<string, int>(memberID, dateInt);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRechargeRecords4Day, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<RechargeRecord>>>(response, 0);
        }

        /// <summary>
        /// 商品进销存进货明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<PurchaseOrder>> GetCostumeInvoicingDetail4In(GetCostumeInvoicingDetailPara para, CostumeInvoicingDetailInType type)
        {
            Parameter<GetCostumeInvoicingDetailPara, CostumeInvoicingDetailInType> value = new Parameter<GetCostumeInvoicingDetailPara, CostumeInvoicingDetailInType>(para, type);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeInvoicingDetail4In, SerializeHelper.ResultToSerialize(value));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PurchaseOrder>>>(response, 0);
        }

        /// <summary>
        /// 商品进销存批发明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<PfOrder>> GetCostumeInvoicingDetail4Pf(GetCostumeInvoicingDetailPara para, CostumeInvoicingDetailPfType type)
        {
            Parameter<GetCostumeInvoicingDetailPara, CostumeInvoicingDetailPfType> value = new Parameter<GetCostumeInvoicingDetailPara, CostumeInvoicingDetailPfType>(para, type);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeInvoicingDetail4Pf, SerializeHelper.ResultToSerialize(value));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PfOrder>>>(response, 0);
        }

        /// <summary>
        /// 商品进销存零售明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<RetailOrder>> GetCostumeInvoicingDetail4Retail(GetCostumeInvoicingDetailPara para, CostumeInvoicingDetailRetailType type)
        {
            Parameter<GetCostumeInvoicingDetailPara, CostumeInvoicingDetailRetailType> value = new Parameter<GetCostumeInvoicingDetailPara, CostumeInvoicingDetailRetailType>(para, type);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeInvoicingDetail4Retail, SerializeHelper.ResultToSerialize(value));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<RetailOrder>>>(response, 0);
        }

        /// <summary>
        /// 客户进销存发货明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<PfOrder>> GetPfInvoicing4Delivery(GetPfInvoicingPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfInvoicing4Delivery, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PfOrder>>>(response, 0);
        }

        /// <summary>
        /// 客户进销存销售明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<PfCustomerRetailOrder>> GetPfInvoicing4Retail(GetPfInvoicingPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfInvoicing4Retail, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PfCustomerRetailOrder>>>(response, 0);
        }

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public InteractResult<UserInfo> GetUserInfo(string userId)
        {
            byte[] response = this.engine?.CustomizeOutter?.Query(CommonInformationTypes.GetUserInfo, SerializeHelper.StringToByteArray(userId));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<UserInfo>>(response, 0);
        }

        /// <summary>
        /// 销售分析
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<SalesAnalysisInfo> GetSalesAnalysis(GetSalesAnalysisPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetSalesAnalysis, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<SalesAnalysisInfo>>(response, 0);
        }

        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<AdminUser>> GetAdminUsers(GetAdminUsersPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetAdminUsers, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<AdminUser>>>(response, 0);
        }

        /// <summary>
        /// 查询导购员
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<Guide>> GetGuides(GetGuidesPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetGuides, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<Guide>>>(response, 0);
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public InteractResult<List<Role>> GetRoles()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRoles, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<Role>>>(response, 0);
        }

        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public InteractResult<List<int>> GetRolePermissions4RoleID(int roleId)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRolePermissions4RoleID, SerializeHelper.IntToByteArray(roleId));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<int>>>(response, 0);
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public InteractResult<int> InsertRole(Role role)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.InsertRole, SerializeHelper.ResultToSerialize(role));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<int>>(response, 0);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public InteractResult UpdateRole(Role role)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateRole, SerializeHelper.ResultToSerialize(role));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public InteractResult DeleteRole(int roleId)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DeleteRole, SerializeHelper.IntToByteArray(roleId));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 根据销售单id模糊查询分页信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public InteractResult<RetailListPage> GetRetailPageLikeID(RetailPageAdvancePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRetailPageLikeID, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<RetailListPage>>(response, 0);
        }

        /// <summary>
        /// 获取提前多少天到今天范围内的销售单分页信息。
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<RetailListPage> GetRetailPageAdvance(RetailPageAdvancePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRetailPageAdvance, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<RetailListPage>>(response, 0);
        }

        /// <summary>
        /// 获取销售分析明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<SalesAnalysisDeatilInfo> GetSalesAnalysisDeatilInfo(GetSalesAnalysisDeatilInfoPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetSalesAnalysisDeatilInfo, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<SalesAnalysisDeatilInfo>>(response, 0);
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public InteractResult<List<Role>> GetRolesFilterAdmin()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRolesFilterAdmin, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<Role>>>(response, 0);
        }

        /// <summary>
        /// 修改导购员密码
        /// </summary>
        /// <param name="guideId"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public InteractResult UpdateGuidePwd(string guideId, string pwd)
        {
            Parameter<string, string> para = new Parameter<string, string>(guideId, pwd);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateGuidePwd, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 编辑服装
        /// </summary>
        /// <param name="costume"></param>
        /// <returns></returns>
        public InteractResult EditCostume(EditCostume costume)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.EditCostume, SerializeHelper.ResultToSerialize(costume));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 期初库存录入编辑商品
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult UpdateStartStoreCostume(UpdateStartStoreCostumePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateStartStoreCostume, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改供应商应付结余
        /// </summary>
        /// <param name="id"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public InteractResult UpdateSupplierPaymentBalance(string id, decimal money)
        {
            Parameter<string, decimal> para = new Parameter<string, decimal>(id, money);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateSupplierPaymentBalance, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改批发客户应付结余
        /// </summary>
        /// <param name="id"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public InteractResult UpdatePfPaymentBalance(string id, decimal money)
        {
            Parameter<string, decimal> para = new Parameter<string, decimal>(id, money);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdatePfPaymentBalance, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改所选店铺库存的吊牌价和售价
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult UpdateCostumeStorePrice(UpdateCostumeStorePricePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateCostumeStorePrice, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 盘点汇总获取对应的盘点单
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        public InteractResult<List<CheckStoreOrder>> GetCheckStoreOrders4Summary(List<string> ids, string costumeID)
        {
            Parameter<List<string>, string> para = new Parameter<List<string>, string>(ids, costumeID);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCheckStoreOrders4Summary, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<CheckStoreOrder>>>(response, 0);
        }

        /// <summary>
        /// 获取调拨单分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<AllocateOrderPage> GetAllocateOrders(GetAllocateOrdersPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetAllocateOrders, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<AllocateOrderPage>>(response, 0);
        }

        /// <summary>
        /// 导入颜色
        /// </summary>
        /// <param name="costumeColorc"></param>
        /// <returns></returns>
        public InteractResult ImportCostumeColors(List<CostumeColor> costumeColorc)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.ImportCostumeColors, SerializeHelper.ResultToSerialize(costumeColorc));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 载入子盘点单
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public InteractResult<List<CheckStoreDetail>> GetCheckStoreDetails4Child(string shopID, Date date)
        {
            Parameter<string, Date> para = new Parameter<string, Date>(shopID, date);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCheckStoreDetails4Child, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<CheckStoreDetail>>>(response, 0);
        }

        /// <summary>
        /// 修改充值记录
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult UpdateRechargeRecord(UpdateRechargeRecordPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateRechargeRecord, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取充值记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractResult<RechargeRecord> GetOneRechargeRecord(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOneRechargeRecord, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<RechargeRecord>>(response, 0);
        }

        /// <summary>
        /// 修改是否在线上商城中展示
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public InteractResult UpdateEmShowOnline(string id, bool value)
        {
            Parameter<string, bool> para = new Parameter<string, bool>(id, value);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateEmShowOnline, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改是否上架批发
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public InteractResult UpdatePfShowOnline(string id, bool value)
        {
            Parameter<string, bool> para = new Parameter<string, bool>(id, value);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdatePfShowOnline, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取批发销售分析
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<PfRetailAnalysis> GetPfRetailAnalysis(GetPfRetailAnalysisPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfRetailAnalysis, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<PfRetailAnalysis>>(response, 0);
        }

        /// <summary>
        /// 获取层级收益信息
        /// </summary>
        /// <returns></returns>
        public InteractResult<DistributionInfo> GetDistributionInfo()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetDistributionInfo, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<DistributionInfo>>(response, 0);
        }

        /// <summary>
        /// 修改层级收益信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public InteractResult UpdateDistributionInfo(DistributionInfo info)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateDistributionInfo, SerializeHelper.ResultToSerialize(info));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取零售分销人员
        /// </summary>
        /// <returns></returns>
        public InteractResult<List<TreeModel>> GetRetailDistributionTree()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRetailDistributionTree, null);

            return (InteractResult<List<TreeModel>>)CJBasic.Helpers.SerializeHelper.DeserializeBytes(response, 0, response.Length);
        }

        /// <summary>
        /// 零售新增下线会员
        /// </summary>
        /// <returns></returns>
        public InteractResult AddMember4Distribution(string introducerID, string memberCard, string name)
        {
            Parameter<string, string, string> para = new Parameter<string, string, string>(introducerID, memberCard, name);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.AddMember4Distribution, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改会员名称
        /// </summary>
        /// <param name="memberCard"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public InteractResult UpdateMemberName(string memberCard, string name)
        {
            Parameter<string, string> para = new Parameter<string, string>(memberCard, name);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateMemberName, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取批发分销人员
        /// </summary>
        /// <returns></returns>
        public InteractResult<List<TreeModel>> GetPfDistributionTree()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfDistributionTree, null);

            return (InteractResult<List<TreeModel>>)CJBasic.Helpers.SerializeHelper.DeserializeBytes(response, 0, response.Length);
        }

        public EmOrderPage GetEmOrderPage(GetEmOrderPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(EMallInformationTypes.GetEmOrderPage, SerializeHelper.ResultToSerialize(para));
            return CompactPropertySerializer.Default.Deserialize<EmOrderPage>(response, 0);
        }

        /// <summary>
        /// 获取批发客户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractResult<PfCustomer> GetPfCustomer(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfCustomer, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<PfCustomer>>(response, 0);
        }

        /// <summary>
        /// 获取打印设置
        /// </summary>
        /// <param name="printTemplateType"></param>
        /// <returns></returns>
        public InteractResult<PrintTemplateInfo> GetPrintTemplateInfo(PrintTemplateType printTemplateType)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPrintTemplateInfo, SerializeHelper.IntToByteArray((int)printTemplateType));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<PrintTemplateInfo>>(response, 0);
        }

        /// <summary>
        /// 保存打印设置
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public InteractResult SavePrintTemplateInfo(PrintTemplateInfo info)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.SavePrintTemplateInfo, SerializeHelper.ResultToSerialize(info));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取商品分布
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<CostumeDistribution>> GetCostumeDistributions(GetCostumeDistributionsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeDistributions, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<CostumeDistribution>>>(response, 0);
        }

        /// <summary>
        /// 获取商品分布
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<CostumeDistributionDetail>> GetCostumeDistributionDetails(GetCostumeDistributionDetailsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeDistributionDetails, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<CostumeDistributionDetail>>>(response, 0);
        }

        /// <summary>
        /// 获取服装主图
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        public InteractResult<string> GetMainCostumePhotoAddress(string costumeID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetMainCostumePhotoAddress, SerializeHelper.StringToByteArray(costumeID));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<string>>(response, 0);
        }

        /// <summary>
        /// 获取服装图片列表
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        public InteractResult<List<EmCostumePhoto>> GetCostumePhotoAddressList(string costumeID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumePhotoAddressList, SerializeHelper.StringToByteArray(costumeID));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<EmCostumePhoto>>>(response, 0);
        }

        /// <summary>
        /// 删除海报
        /// </summary>
        /// <param name="photoName"></param>
        /// <returns></returns>
        public InteractResult DeletePosterImage(string photoName)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DeletePosterImage, SerializeHelper.StringToByteArray(photoName));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改海报顺序
        /// </summary>
        /// <param name="photoName"></param>
        /// <returns></returns>
        public InteractResult UpdatePosterImageIndexs(List<UpdateDisplayIndex> list)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdatePosterImageIndexs, SerializeHelper.ResultToSerialize(list));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取海报
        /// </summary>
        /// <returns></returns>
        public InteractResult<List<EmPosterImage>> GetEmPosterImages()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetEmPosterImages, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<EmPosterImage>>>(response, 0);
        }

        /// <summary>
        /// 所选导购在这一天中的有销售的销售单
        /// </summary>
        /// <returns></returns>
        public InteractResult<List<RetailDetail>> GetGuideReatil4Days(string shopID, string guideID, int day)
        {
            Parameter<string, string, int> para = new Parameter<string, string, int>(shopID, guideID, day);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetGuideReatil4Days, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<RetailDetail>>>(response, 0);
        }

        /// <summary>
        /// 隐藏客户期初库存录入功能
        /// </summary>
        /// <returns></returns>
        public InteractResult HideCreatePfStore()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.HideCreatePfStore, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 启用店铺
        /// </summary>
        /// <returns></returns>
        public InteractResult EnableShop(string shopID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.EnableShop, SerializeHelper.StringToByteArray(shopID));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改线上销量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newCount"></param>
        /// <param name="oldCount"></param>
        /// <returns></returns>
        public InteractResult UpdateEmSales(string id, int newCount)
        {
            Parameter<string, int> para = new Parameter<string, int>(id, newCount);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateEmSales, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 新增服装视频
        /// </summary>
        /// <param name="emCostumePhoto"></param>
        /// <returns></returns>
        public InteractResult InsertEmCostumePhoto4Video(EmCostumePhoto emCostumePhoto)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.InsertEmCostumePhoto, SerializeHelper.ResultToSerialize(emCostumePhoto));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 新增服装图片
        /// </summary>
        /// <param name="emCostumePhoto"></param>
        /// <returns></returns>
        public InteractResult InsertEmCostumePhoto(EmCostumePhoto emCostumePhoto)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.InsertEmCostumePhoto, SerializeHelper.ResultToSerialize(emCostumePhoto));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取腾讯云签名
        /// </summary>
        /// <returns></returns>
        public InteractResult<CosCloudSignature> GetCosCloudSignature()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCosCloudSignature, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<CosCloudSignature>>(response, 0);
        }

        /// <summary>
        /// 新增分销佣金模板
        /// </summary>
        /// <param name="commissionTemplate"></param>
        /// <returns></returns>
        public InteractResult InsertCommissionTemplate(CommissionTemplate commissionTemplate)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.InsertCommissionTemplate, SerializeHelper.ResultToSerialize(commissionTemplate));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改分销佣金模板
        /// </summary>
        /// <param name="commissionTemplate"></param>
        /// <returns></returns>
        public InteractResult UpdateCommissionTemplate(CommissionTemplate commissionTemplate)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateCommissionTemplate, SerializeHelper.ResultToSerialize(commissionTemplate));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 查询分销佣金模板列表
        /// </summary>
        /// <param name="commissionTemplate"></param>
        /// <returns></returns>
        public InteractResult<List<CommissionTemplate>> GetCommissionTemplates()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCommissionTemplates, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<CommissionTemplate>>>(response, 0);
        }

        /// <summary>
        /// 根据id获取分销佣金模板列表
        /// </summary>
        /// <param name="commissionTemplate"></param>
        /// <returns></returns>
        public InteractResult<CommissionTemplate> GetOneCommissionTemplate(int id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOneCommissionTemplate, SerializeHelper.IntToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<CommissionTemplate>>(response, 0);
        }

        /// <summary>
        /// 删除获取分销佣金模板列表
        /// </summary>
        /// <param name="commissionTemplate"></param>
        /// <returns></returns>
        public InteractResult DeleteCommissionTemplate(int id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DeleteCommissionTemplate, SerializeHelper.IntToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 分销佣金模板列表是否含有默认模板
        /// </summary>
        /// <param name="commissionTemplate"></param>
        /// <returns></returns>
        public InteractResult<bool> IsCommissionTemplateHaveDefault()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.IsCommissionTemplateHaveDefault, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<bool>>(response, 0);
        }

        /// <summary>
        /// 分销佣金模板列表是被使用
        /// </summary>
        /// <param name="commissionTemplate"></param>
        /// <returns></returns>
        public InteractResult<bool> IsCommissionTemplateUse(int id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.IsCommissionTemplateUse, SerializeHelper.IntToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<bool>>(response, 0);
        }

        /// <summary>
        /// 获取一条批发单信息
        /// </summary>
        /// <param name="commissionTemplate"></param>
        /// <returns></returns>
        public InteractResult<PfOrder> GetOnePfOrder(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOnePfOrder, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<PfOrder>>(response, 0);
        }

        /// <summary>
        /// 新增线上店铺海报图片
        /// </summary>
        /// <param name="commissionTemplate"></param>
        /// <returns></returns>
        public InteractResult InsertEmPosterImage(EmPosterImage emPosterImage)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.InsertEmPosterImage, SerializeHelper.ResultToSerialize(emPosterImage));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取批发客户库存
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        public InteractResult<List<PfCustomerStore>> GetPfCustomerStoreList(string pfCustomerID, string costumeID)
        {
            Parameter<string, string> para = new Parameter<string, string>(pfCustomerID, costumeID);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfCustomerStoreList, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PfCustomerStore>>>(response, 0);
        }

        /// <summary>
        /// 获取批发客户库存
        /// </summary>
        /// <param name="pfCustomerID"></param>
        /// <param name="costumeID"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public InteractResult<PfCustomerStore> GetOnePfCustomerStore(string pfCustomerID, string costumeID, string color)
        {
            Parameter<string, string, string> para = new Parameter<string, string, string>(pfCustomerID, costumeID, color);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOnePfCustomerStore, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<PfCustomerStore>>(response, 0);
        }

        /// <summary>
        /// 线上订单导出设置
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public InteractResult SetEmOrderExportInfo(EmOrderExportInfo info)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.SetEmOrderExportInfo, SerializeHelper.ResultToSerialize(info));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取线上订单导出设置
        /// </summary>
        /// <returns></returns>
        public InteractResult<EmOrderExportInfo> GetEmOrderExportInfo()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetEmOrderExportInfo, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<EmOrderExportInfo>>(response, 0);
        }

        /// <summary>
        /// 获取线上批发订单导出数据
        /// </summary>
        /// <returns></returns>
        public InteractResult<EmOrderExportData> GetEmPfOrderExportData(string orderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetEmPfOrderExportData, SerializeHelper.StringToByteArray(orderID));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<EmOrderExportData>>(response, 0);
        }

        /// <summary>
        /// 获取线上零售订单导出数据
        /// </summary>
        /// <returns></returns>
        public InteractResult<EmOrderExportData> GetEmRetailOrderExportData(string orderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetEmRetailOrderExportData, SerializeHelper.StringToByteArray(orderID));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<EmOrderExportData>>(response, 0);
        }

        /// <summary>
        /// 获取大类类别
        /// </summary>
        /// <returns></returns>
        public InteractResult<List<CostumeClass2>> GetBigClassList()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetBigClassList, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<CostumeClass2>>>(response, 0);
        }

        /// <summary>
        /// 修改类别图片存储的链接地址
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public InteractResult UpdateClassPhotoUrl(int id, string url)
        {
            Parameter<int, string> para = new Parameter<int, string>(id, url);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateClassPhotoUrl, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 删除类别图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractResult DeleteClassPhotoUrl(int id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DeleteClassPhotoUrl, SerializeHelper.IntToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 设置佣金打款方式
        /// </summary>
        /// <param name="pfCommissionPayWay"></param>
        /// <returns></returns>
        public InteractResult SetPfCommissionPayWay(PfCommissionPayWay pfCommissionPayWay)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.SetPfCommissionPayWay, SerializeHelper.IntToByteArray((int)pfCommissionPayWay));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取佣金打款方式
        /// </summary>
        /// <returns></returns>
        public InteractResult<PfCommissionPayWay> GetPfCommissionPayWay()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfCommissionPayWay, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<PfCommissionPayWay>>(response, 0);
        }

        /// <summary>
        /// 获取零售分销人员
        /// </summary>
        /// <param name="distributorIDOrName"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public InteractResult<DistributorCommissionPage> GetDistributors4Retail(GetDistributorsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetDistributors4Retail, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<DistributorCommissionPage>>(response, 0);
        }

        /// <summary>
        /// 获取批发分销人员
        /// </summary>
        /// <param name="distributorIDOrName"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public InteractResult<DistributorCommissionPage> GetDistributors4Pf(GetDistributorsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetDistributors4Pf, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<DistributorCommissionPage>>(response, 0);
        }

        /// <summary>
        /// 获取零售佣金明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<DistributorCommissionRecord>> GetCommissionRecords4Retail(GetCommissionRecordsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCommissionRecords4Retail, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<DistributorCommissionRecord>>>(response, 0);
        }

        /// <summary>
        /// 获取批发佣金明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<DistributorCommissionRecord>> GetCommissionRecords4Pf(GetCommissionRecordsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCommissionRecords4Pf, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<DistributorCommissionRecord>>>(response, 0);
        }

        /// <summary>
        /// 获取打款管理
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<DistributorWithdrawRecordPage> GetDistributorPayManage(GetDistributorWithdrawRecordPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetDistributorPayManage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<DistributorWithdrawRecordPage>>(response, 0);
        }

        /// <summary>
        /// 模糊查询批发客户列表
        /// </summary>
        /// <param name="idOrName"></param>
        /// <returns></returns>
        public InteractResult<List<PfCustomer>> GetPfCustomers(string idOrName)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfCustomers, SerializeHelper.StringToByteArray(idOrName));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PfCustomer>>>(response, 0);
        }

        /// <summary>
        /// 佣金打款
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public InteractResult PayCommission(DistributorWithdrawRecord record)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.PayCommission, SerializeHelper.ResultToSerialize(record));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取零售人员
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<Member>> GetDistributors4Member(GetDistributors4MemberPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetDistributors4Member, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<Member>>>(response, 0);
        }

        /// <summary>
        /// 获取批发分销人员
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<PfCustomer>> GetPfDistributors(GetPfDistributorsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfDistributors, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<PfCustomer>>>(response, 0);
        }

        /// <summary>
        /// 修改批发客户能否查看佣金
        /// </summary>
        /// <param name="id"></param>
        /// <param name="canSee"></param>
        /// <returns></returns>
        public InteractResult UpdatePfCustomerSeeCommission(string id, bool canSee)
        {
            Parameter<string, bool> para = new Parameter<string, bool>(id, canSee);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdatePfCustomerSeeCommission, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改会员能否查看佣金
        /// </summary>
        /// <param name="id"></param>
        /// <param name="canSee"></param>
        /// <returns></returns>
        public InteractResult UpdateMemberSeeCommission(string id, bool canSee)
        {
            Parameter<string, bool> para = new Parameter<string, bool>(id, canSee);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateMemberSeeCommission, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取所有启用的品牌列表
        /// </summary>
        /// <returns></returns>
        public InteractResult<List<Brand>> GetEnableBrands()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetEnableBrands, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<Brand>>>(response, 0);
        }

        /// <summary>
        /// 品牌是否禁用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isDisable"></param>
        /// <returns></returns>
        public InteractResult UpdateBrandDisable(int id, bool isDisable)
        {
            Parameter<int, bool> para = new Parameter<int, bool>(id, isDisable);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateBrandDisable, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取分销人员信息
        /// </summary>
        /// <param name="distributorId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public InteractResult<Distributor> GetDistributor(string distributorId, DistributorType type)
        {
            Parameter<string, DistributorType> para = new Parameter<string, DistributorType>(distributorId, type);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetDistributor, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<Distributor>>(response, 0);
        }

        /// <summary>
        /// 修改分销人员提款申请记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="money"></param>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public InteractResult UpdateDistributorWithdrawRecord(int id, decimal money, DateTime createTime, string remarks)
        {
            Parameter<int, decimal, DateTime, string> para = new Parameter<int, decimal, DateTime, string>(id, money, createTime, remarks);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateDistributorWithdrawRecord, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取商品分布明细 累计进货明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<OrderInfo>> GetCostumeDistributionDetails4In(GetCostumeDistributionDetailsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeDistributionDetails4In, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<OrderInfo>>>(response, 0);
        }

        /// <summary>
        /// 获取商品分布明细 本期销售明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult<List<OrderInfo>> GetCostumeDistributionDetails4Retail(GetCostumeDistributionDetailsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeDistributionDetails4Retail, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult<List<OrderInfo>>>(response, 0);
        }

        /// <summary>
        /// 获取销售单打印类型
        /// </summary>
        /// <returns></returns>
        public InteractResult<RetailPrintType> GetRetailPrintType()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRetailPrintType, null);

            return CompactPropertySerializer.Default.Deserialize<InteractResult<RetailPrintType>>(response, 0);
        }

        /// <summary>
        /// 修改销售单打印类型
        /// </summary>
        /// <returns></returns>
        public InteractResult SetRetailPrintType(RetailPrintType retailPrintType)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.SetRetailPrintType, SerializeHelper.IntToByteArray((int)retailPrintType));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }























        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="member">会员信息</param>
        /// <returns></returns>
        public InteractResult RegisterMember(Member member)
        {
            byte[] request = SerializeHelper.ResultToSerialize(member);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.RegisterMember, request);

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }
         
        /// <summary>
        /// 获取会员列表分页信息
        /// </summary>
        /// <param name="para">分页信息条件参数</param>
        /// <returns></returns>
        public MemberListPage GetMemberListPage(MemberListPagePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetMemberListPage, request);

            return CompactPropertySerializer.Default.Deserialize<MemberListPage>(response, 0);
        }

        public void GetBarCode4Costume(object para)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改会员
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public UpdateMemberResult UpdateMember(Member member)
        {
            byte[] request = SerializeHelper.ResultToSerialize(member);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateMember, request);

            return (UpdateMemberResult)SerializeHelper.ByteArrayToInt(response);
        }
        
        /// <summary>
        /// 获取单个会员信息
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public Member GetOneMember(string phoneNumber)
        {
            byte[] request = SerializeHelper.StringToByteArray(phoneNumber);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOneMember, request);

            return CompactPropertySerializer.Default.Deserialize<Member>(response, 0);
        }
        
        /// <summary>
        /// 获取本店库存情况
        /// </summary>
        /// <param name="costumeStoreListPara"></param>
        /// <returns></returns>
        public List<CostumeItem> GetCostumeStoreList(CostumeStoreListPara costumeStoreListPara)
        {
            byte[] request = SerializeHelper.ResultToSerialize(costumeStoreListPara);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreList, request);

            return CompactPropertySerializer.Default.Deserialize<List<CostumeItem>>(response, 0);
        }
        
        /// <summary>
        /// 获取销售单分页列表
        /// </summary>
        /// <param name="retailListPagePara"></param>
        /// <returns></returns>
        public RetailListPage GetRetailListPage(RetailListPagePara retailListPagePara)
        {
            byte[] request = SerializeHelper.ResultToSerialize(retailListPagePara);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRetailListPage, request);

            return CompactPropertySerializer.Default.Deserialize<RetailListPage>(response, 0);
        }
        
        /// <summary>
        /// 获取退货单分页列表
        /// </summary>
        /// <param name="refundListPagePara"></param>
        /// <returns></returns>
        public RefundListPage GetRefundListPage(RefundListPagePara refundListPagePara)
        {
            byte[] request = SerializeHelper.ResultToSerialize(refundListPagePara);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRefundListPage, request);

            return CompactPropertySerializer.Default.Deserialize<RefundListPage>(response, 0);
        }

        /// <summary>
        /// 获取批发客户销售单明细
        /// </summary>
        /// <param name="pfCustomerRetailOrderID"></param>
        /// <returns></returns>
        public List<PfCustomerRetailDetail> GetPfCustomerRetailDetails(string pfCustomerRetailOrderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.GetPfCustomerRetailDetails, SerializeHelper.StringToByteArray(pfCustomerRetailOrderID));
            return CompactPropertySerializer.Default.Deserialize<List<PfCustomerRetailDetail>>(response, 0);
        }

        /// <summary>
        /// 获取销售单明细列表。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RetailDetail> GetRetailDetailList(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRetailDetailList, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<List<RetailDetail>>(response, 0);
        }
        
        /// <summary>
        /// 获取退货单明细列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RetailDetail> GetRefundDetailList(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRefundDetailList, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<List<RetailDetail>>(response, 0);
        }
        
        /// <summary>
        /// 获取库存分页信息。
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public CostumeStoreListPage GetCostumeStoreListPage(CostumeStoreListPagePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreListPage, request);

            return CompactPropertySerializer.Default.Deserialize<CostumeStoreListPage>(response, 0);
        }

        /// <summary>
        /// 会员充值
        /// </summary>
        /// <param name="rechargeRecord"></param>
        /// <returns></returns>
        public RechargeResult Recharge(RechargeRecord rechargeRecord)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.Recharge, SerializeHelper.ResultToSerialize(rechargeRecord));

            return (RechargeResult)SerializeHelper.ByteArrayToInt(response);
        }

        /// <summary>
        /// 获取充值记录
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<RechargeRecord> GetRechargeRecordList(RechargeRecordListPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRechargeRecordList, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<RechargeRecord>>(response, 0);
        }

        /// <summary>
        /// 获取本店铺的导购员。
        /// </summary>
        /// <param name="shopID"></param>
        /// <returns></returns>
        public List<Guide> GetGuideList(string shopID )
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetGuideList, SerializeHelper.StringToByteArray(shopID));

            return CompactPropertySerializer.Default.Deserialize<List<Guide>>(response, 0);
        }
        
        /// <summary>
        /// 获取服装分类列表
        /// </summary>
        /// <returns></returns>
        public List<CostumeClassInfo> GetCostumeClassList()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeClassList, null);

            return CompactPropertySerializer.Default.Deserialize<List<CostumeClassInfo>>(response, 0);
        }

        /// <summary>
        /// 补货申请分页查询
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ReplenishCostumePage GetReplenishCostumePage(ReplenishCostumePagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetReplenishCostumePage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<ReplenishCostumePage>(response, 0);
        }

        /// <summary>
        /// 获取补货申请单明细
        /// </summary>
        /// <returns></returns>
        public List<ReplenishDetail> GetReplenishDetail(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetReplenishDetail, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<List<ReplenishDetail>>(response, 0);
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InboundResult Inbound(InboundPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.Inbound, SerializeHelper.ResultToSerialize(para));

            return (InboundResult)SerializeHelper.ByteArrayToInt(response);
        }

        /// <summary>
        /// 获取服装分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public CostumeListPage GetCostumeListPage(CostumeListPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeListPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<CostumeListPage>(response, 0);
        }

        /// <summary>
        /// 获取入库单分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InboundOrderPage GetInboundOrderPage(InboundOrderPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetInboundOrderPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InboundOrderPage>(response, 0);
        }

        /// <summary>
        /// 查询出库单信息
        /// </summary>
        /// <param name="sourceOrderID"></param>
        /// <returns></returns>
        public Outbound GetOneOutbound(string sourceOrderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOneOutbound, SerializeHelper.StringToByteArray(sourceOrderID));

            return CompactPropertySerializer.Default.Deserialize<Outbound>(response, 0);
        }

        /// <summary>
        /// 获取入库单明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BoundDetail> GetInboundDetail(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetInboundDetail, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<List<BoundDetail>>(response, 0);
        }

        /// <summary>
        /// 获取出库单分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public OutboundOrderPage GetOutboundOrderPage(OutboundOrderPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOutboundOrderPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<OutboundOrderPage>(response, 0);
        }

        /// <summary>
        /// 获取出库单明细。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BoundDetail> GetOutboundDetail(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOutboundDetail, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<List<BoundDetail>>(response, 0);
        }

        /// <summary>
        /// 获取入库差异单分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public DifferenceOrderPage GetDifferenceOrderPage(DifferenceOrderPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetDifferenceOrderPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<DifferenceOrderPage>(response, 0);
        }

        /// <summary>
        /// 获取入库差异单明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DifferenceDetail> GetDifferenceDetail(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetDifferenceDetail, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<List<DifferenceDetail>>(response, 0);
        }

        /// <summary>
        /// 获取品牌
        /// </summary>
        /// <returns></returns>
        public List<Brand> GetBrand()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetBrand, null);

            return CompactPropertySerializer.Default.Deserialize<List<Brand>>(response, 0);
        }

        /// <summary>
        /// 取消补货申请单。
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult CancelReplenish(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.CancelReplenish, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0); ;
        }

        /// <summary>
        ///  获取后台管理用户
        /// </summary>
        /// <returns></returns>
        public List<AdminUser> GetAllAdminUser()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetAllAdminUser, null);

            return CompactPropertySerializer.Default.Deserialize<List<AdminUser>>(response, 0);
        }

        /// <summary>
        /// 调拨
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult AllocateOutbound(AllocateOutboundPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.AllocateOutbound, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }
         

        /// <summary>
        /// 获取调拨单分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public AllocateOrderPage GetAllocateOrderPage(AllocateOrderPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetAllocateOrderPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<AllocateOrderPage>(response, 0);
        }

        /// <summary>
        /// 盘点审核
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult CheckStore(CheckStoreOrderIDAndUser para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.CheckStore, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取出库单
        /// </summary>
        /// <param name="outboundOrderID"></param>
        /// <returns></returns>
        public OutboundOrder GetOutboundOrder(string outboundOrderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOutboundOrder, SerializeHelper.StringToByteArray(outboundOrderID));

            return CompactPropertySerializer.Default.Deserialize<OutboundOrder>(response, 0);
        }

        /// <summary>
        /// 获取入库单
        /// </summary>
        /// <param name="inboundOrderID"></param>
        /// <returns></returns>
        public InboundOrder GetInboundOrder(string inboundOrderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetInboundOrder, SerializeHelper.StringToByteArray(inboundOrderID));

            return CompactPropertySerializer.Default.Deserialize<InboundOrder>(response, 0);
        }

        /// <summary>
        /// 获取补货申请单
        /// </summary>
        /// <param name="replenishOrderID"></param>
        /// <returns></returns>
        public ReplenishOrder GetReplenishOrder(string replenishOrderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetReplenishOrder, SerializeHelper.StringToByteArray(replenishOrderID));

            return CompactPropertySerializer.Default.Deserialize<ReplenishOrder>(response, 0);
        }

        /// <summary>
        /// 获取调拨单
        /// </summary>
        /// <param name="allocateOrderID"></param>
        /// <returns></returns>
        public AllocateOrder GetAllocateOrder(string allocateOrderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetAllocateOrder, SerializeHelper.StringToByteArray(allocateOrderID));

            return CompactPropertySerializer.Default.Deserialize<AllocateOrder>(response, 0);
        }

        /// <summary>
        /// 根据店铺id获取库存信息
        /// </summary>
        /// <param name="shopID"></param>
        /// <returns></returns>
        public CostumeStorePage GetCostumeStoreInShopID(GetCostumeStorePagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreInShopID, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<CostumeStorePage>(response, 0);
        }

        /// <summary>
        /// 获取盘点分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public CheckStoreOrderPage GetCheckStoreOrderPage(CheckStoreOrderPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCheckStoreOrderPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<CheckStoreOrderPage>(response, 0);
        }

        /// <summary>
        /// 获取盘点明细
        /// </summary>
        /// <param name="checkStoreOrderID"></param>
        /// <returns></returns>
        public List<CheckStoreDetail> GetCheckStoreDetail(string checkStoreOrderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCheckStoreDetail, SerializeHelper.StringToByteArray(checkStoreOrderID));

            return CompactPropertySerializer.Default.Deserialize<List<CheckStoreDetail>>(response, 0);
        }

        /// <summary>
        /// 获取工作台信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public WorkTableInfo WorkTableInfo(WorkTableInfoPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.WorkTableInfo, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<WorkTableInfo>(response, 0);
        }

        /// <summary>
        /// 差异单确认
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public DifferenceOrderConfirmedResult DifferenceOrderConfirmed(DifferenceOrderConfirmedPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DifferenceOrderConfirmed, SerializeHelper.ResultToSerialize(para));

            return (DifferenceOrderConfirmedResult)SerializeHelper.ByteArrayToInt(response);
        }

        /// <summary>
        /// 根据来源单据编号获取差异单信息。
        /// </summary>
        /// <param name="sourceOrderID"></param>
        /// <returns></returns>
        public DifferenceOrder GetOneDifferenceOrder4SourceOrderID(string sourceOrderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOneDifferenceOrder4SourceOrderID, SerializeHelper.StringToByteArray(sourceOrderID));

            return CompactPropertySerializer.Default.Deserialize<DifferenceOrder>(response, 0);
        }

        /// <summary>
        /// 获取库存变化跟踪分页信息
        /// </summary>
        /// <param name="costumeStoreTrackPagePara"></param>
        /// <returns></returns>
        public CostumeStoreTrackPage GetCostumeStoreTrackPage(CostumeStoreTrackPagePara costumeStoreTrackPagePara)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeStoreTrackPage, SerializeHelper.ResultToSerialize(costumeStoreTrackPagePara));

            return CompactPropertySerializer.Default.Deserialize<CostumeStoreTrackPage>(response, 0);
        }

        /// <summary>
        /// 新增现金记录
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InsertResult InsertCashRecord(CashRecord para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.InsertCashRecord, SerializeHelper.ResultToSerialize(para));

            return (InsertResult)SerializeHelper.ByteArrayToInt(response);
        }

        /// <summary>
        /// 获取现金记录分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public CashRecordPage GetCashRecordPage(CashRecordPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCashRecordPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<CashRecordPage>(response, 0);
        }

        /// <summary>
        /// 查询配置列表
        /// </summary>
        /// <returns></returns>
        public List<ParameterConfig> GetAllParameterConfig()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetAllParameterConfig, null);

            return CompactPropertySerializer.Default.Deserialize<List<ParameterConfig>>(response, 0);
        }

        /// <summary>
        /// 新增待审核盘点单
        /// </summary>
        /// <param name="checkStore"></param>
        /// <returns></returns>
        public InteractResult InsertCheckStore(CheckStore checkStore)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.InsertCheckStore, SerializeHelper.ResultToSerialize(checkStore));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 取消盘点单
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public UpdateCheckStoreResult CancelCheckStore(CheckStoreOrderIDAndUser para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.CancelCheckStore, SerializeHelper.ResultToSerialize(para));

            return (UpdateCheckStoreResult)SerializeHelper.ByteArrayToInt(response);
        }
        
        /// <summary>
        /// 修改盘点单
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult UpdateCheckStore(CheckStore para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateCheckStore, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取日报分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public DayReportPage GetDayReportPage(DayReportPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetDayReportPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<DayReportPage>(response, 0);
        }

        /// <summary>
        /// 删除盘点单
        /// </summary>
        /// <param name="checkStoreOrderID"></param>
        /// <returns></returns>
        public DeleteCheckStoreResult DeleteCheckStore(string checkStoreOrderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DeleteCheckStore, SerializeHelper.StringToByteArray(checkStoreOrderID));

            return (DeleteCheckStoreResult)SerializeHelper.ByteArrayToInt(response);
        }
        
        /// <summary>
        /// 获取导购业绩汇总信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public GuideAchievementSummarys GetGuideAchievementSummarys(GuideAchievementSummarysPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetGuideAchievementSummarys, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<GuideAchievementSummarys>(response, 0);
        }

        /// <summary>
        /// 获取导购业绩信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<GuideDayAchievement> GetGuideAchievements(GuideAchievementsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetGuideAchievements, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<GuideDayAchievement>>(response, 0);
        }
        
        /// <summary>
        /// 获取 营业月报/营业月报汇总 信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<MonthBenefitReport> GetMonthBenefitReports(GetMonthBenefitReportPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetMonthBenefitReports, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<MonthBenefitReport>>(response, 0);
        }

        /// <summary>
        /// 根据单据编号获取采购进货
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PurchaseOrder GetOnePurchaseOrder(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOnePurchaseOrder, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<PurchaseOrder>(response, 0);
        }

        /// <summary>
        /// 根据单据编号获取采购退货
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PurchaseOrder GetOneReturnOrder(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOneReturnOrder, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<PurchaseOrder>(response, 0);
        }

        /// <summary>
        /// 根据单据编号获取报损单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ScrapOrder GetOneScrapOrder(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetOneScrapOrder, SerializeHelper.StringToByteArray(id));

            return CompactPropertySerializer.Default.Deserialize<ScrapOrder>(response, 0);
        }
        
        /// <summary>
        /// 获取今天的日报信息
        /// </summary>
        /// <param name="shopID"></param>
        /// <returns></returns>
        public DayReport GetTodayDayReport(string shopID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetTodayDayReport, SerializeHelper.StringToByteArray(shopID));

            return CompactPropertySerializer.Default.Deserialize<DayReport>(response, 0);
        }

        /// <summary>
        /// 根据会员手机号码模糊查询满足的会员。
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public List<Member> GetMembers4PhoneNumber(string phoneNumber)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetMembers4PhoneNumber, SerializeHelper.StringToByteArray(phoneNumber));

            return CompactPropertySerializer.Default.Deserialize<List<Member>>(response, 0);
        }

        /// <summary>
        /// 获取畅滞排行榜
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public SalesQuantityRankingPage GetSalesQuantityRankingPage(SalesQuantityRankingPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetSalesQuantityRankingPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<SalesQuantityRankingPage>(response, 0);
        }

        /// <summary>
        /// 根据时间范围获取销售单明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<DayBenefitReportDetail> GetDayBenefitReportDetail(DayBenefitReportDetailPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetDayBenefitReportDetail, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<DayBenefitReportDetail>>(response, 0);
        }

        /// <summary>
        /// 获取报损分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ScrapPage GetScrapPage(ScrapPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetScrapPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<ScrapPage>(response, 0);
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <returns></returns>
        public List<CostumeColor> GetCostumeColor()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeColor, null);

            return CompactPropertySerializer.Default.Deserialize<List<CostumeColor>>(response, 0);
        }

        /// <summary>
        /// 商品销售分析
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public CostumeRetailAnalysisPage GetCostumeRetailAnalysisPage(CostumeRetailAnalysisPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeRetailAnalysisPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<CostumeRetailAnalysisPage>(response, 0);
        }

        /// <summary>
        /// 获取打卡分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public SignRecordPage GetSignRecordPage(SignRecordPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetSignRecordPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<SignRecordPage>(response, 0);
        }
        
        /// <summary>
        /// 获取年销售任务列表
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<MonthTask> GetMonthTaskPage(MonthTaskPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetMonthTaskPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<MonthTask>>(response, 0);
        }

        /// <summary>
        /// 获取月销售任务列表
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<MonthTask> GetMonthTasks(GetMonthTaskPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetMonthTasks, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<MonthTask>>(response, 0);
        }
       
        /// <summary>
        /// 修改月销售任务
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public UpdateMonthTaskResult UpdateMonthTask(MonthTask para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateMonthTask, SerializeHelper.ResultToSerialize(para));

            return (UpdateMonthTaskResult)SerializeHelper.ByteArrayToInt(response);
        }

        /// <summary>
        /// 调拨单冲单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractResult OverrideAllocateOrder(string id, string cancelUserID)
        {
            Parameter<string, string> para = new Parameter<string, string>(id, cancelUserID);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.OverrideAllocateOrder, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 补货申请单冲单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OverrideOrderResult OverrideReplenishOrder(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.OverrideReplenishOrder, SerializeHelper.StringToByteArray(id));

            return (OverrideOrderResult)SerializeHelper.ByteArrayToInt(response);
        }

        /// <summary>
        /// 获取服装图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] GetCostumePhoto(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumePhoto, SerializeHelper.StringToByteArray(id));

            return response;
        }

        /// <summary>
        /// 获取本店库存分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public CostumeItemPage GetCostumeItemPage(GetCostumeItemPagePara para)
        {
            byte[] request = SerializeHelper.ResultToSerialize(para);
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetCostumeItemPage, request);

            return CompactPropertySerializer.Default.Deserialize<CostumeItemPage>(response, 0);
        }
        
        /// <summary>
        /// 修改 月支出 列表
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public UpdateResult UpdateMonthExpenses(List<MonthExpenseInfo> para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.UpdateMonthExpenses, SerializeHelper.ResultToSerialize(para));
            return (UpdateResult)SerializeHelper.ByteArrayToInt(response);
        }

        /// <summary>
        /// 销售冲单
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult CancelRetailOrder(CancelRetailOrderPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.CancelRetailOrder, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }
        
        /// <summary>
        /// 添加 串码调整记录 。
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult AddConfusedStoreAdjustRecord(ConfusedStoreAdjustRecord para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.AddConfusedStoreAdjustRecord, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取 串码调整记录 分页信息。
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ConfusedStoreAdjustRecordPage GetConfusedStoreAdjustRecordPage(GetConfusedStoreAdjustRecordPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetConfusedStoreAdjustRecordPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<ConfusedStoreAdjustRecordPage>(response, 0);
        }

        /// <summary>
        /// 获取 盘点汇总 分页信息。
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public CheckStoreSummaryPage GetCheckStoreSummaryPage(GetCheckStoreSummaryPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.GetCheckStoreSummaryPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<CheckStoreSummaryPage>(response, 0);
        }

        /// <summary>
        /// 修改 盘点汇总 平均售价
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public UpdateResult UpdateAveragePrice2AndWinLostMoney(AveragePrice2AndWinLostMoney para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.UpdateAveragePrice2AndWinLostMoney, SerializeHelper.ResultToSerialize(para));

            return (UpdateResult)SerializeHelper.ByteArrayToInt(response);
        }

        /// <summary>
        /// 退货冲单
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult CancelRefundOrder(CancelRetailOrderPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.CancelRefundOrder, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取导购员日业绩
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<GuideDayAchievement> GetGuideDayAchievements(GetGuideDayAchievementsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetGuideDayAchievements, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<GuideDayAchievement>>(response, 0);
        }

        /// <summary>
        /// 发放优惠券
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InsertResult IssueGiftTicket(IssueGiftTicketPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.IssueGiftTicket, SerializeHelper.ResultToSerialize(para));

            return (InsertResult)SerializeHelper.ByteArrayToInt(response);
        }

        /// <summary>
        /// 获取 电子优惠券分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public GiftTicketPage GetGiftTicketPage(GiftTicketPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetGiftTicketPage, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<GiftTicketPage>(response, 0);
        }

        /// <summary>
        /// 禁用电子优惠券
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UpdateResult EnabledGiftTicket(EnabledGiftTicketPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.EnabledGiftTicket, SerializeHelper.ResultToSerialize(para));

            return (UpdateResult)SerializeHelper.ByteArrayToInt(response);
        }

        /// <summary>
        /// 获取 电子优惠券类别列表。
        /// </summary>
        /// <returns></returns>
        public List<GiftTicketTemplate> GetGiftTicketTemplates()
        {
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.GetGiftTicketTemplates, null);

            return CompactPropertySerializer.Default.Deserialize<List<GiftTicketTemplate>>(response, 0);
        }

        /// <summary>
        /// 根据会员id或名称模糊查询会员信息
        /// </summary>
        /// <param name="idOrName"></param>
        /// <returns></returns>
        public List<Member> GetMembersLike4IDOrName(string idOrName)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetMembersLike4IDOrName, SerializeHelper.StringToByteArray(idOrName));

            return CompactPropertySerializer.Default.Deserialize<List<Member>>(response, 0);
        }

        /// <summary>
        /// 获取会员头像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] GetMemberHeadImage(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetMemberHeadImage, SerializeHelper.StringToByteArray(id));

            return response;
        }
        
        /// <summary>
        /// 查询条形码
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<SizeGroup> GetAllSizeGroup()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetAllSizeGroup, null);

            return CompactPropertySerializer.Default.Deserialize<List<SizeGroup>>(response, 0);
        }

        /// <summary>
        /// 是否启用尺码组
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult EnabledSizeGroup(EnabledSizeGroupPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.EnabledSizeGroup, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }
        
        /// <summary>
        /// 获取一段时间内各个店铺的营业报表信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<DayBenefitReport> GetShopBenefitReports(GetShopBenefitReportsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetShopBenefitReports, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<DayBenefitReport>>(response, 0);
        }

        /// <summary>
        /// 获取某个店铺的营业报表信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<DayBenefitReport> GetBenefitReports(GetBenefitReportsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetBenefitReports, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<DayBenefitReport>>(response, 0);
        }

        /// <summary>
        /// 查询促销活动列表
        /// </summary>
        /// <returns></returns>
        public List<SalesPromotion> GetSalesPromotionList(GetSalesPromotionListPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetSalesPromotionList, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<SalesPromotion>>(response, 0);
        }

        /// <summary>
        /// 查询充值规则列表
        /// </summary>
        /// <returns></returns>
        public List<RechargeDonateRule> GetRechargeDonateRuleList()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRechargeDonateRuleList, null);

            return CompactPropertySerializer.Default.Deserialize<List<RechargeDonateRule>>(response, 0);
        }

        /// <summary>
        /// 获取销售分析
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public RetailAnalysisInfo GetRetailAnalysis(GetRetailAnalysisPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRetailAnalysis, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<RetailAnalysisInfo>(response, 0);
        }
        
        /// <summary>
        /// 获取 导购某天的业绩数据。
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<GuideAchievementDetail> GetGuideAchievementDetails(GetGuideAchievementDetailsPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetGuideAchievementDetails, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<List<GuideAchievementDetail>>(response, 0);
        }

        /// <summary>
        /// 获取总仓店铺id
        /// </summary>
        /// <returns></returns>
        public string GetGeneralStoreShopID()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetGeneralStoreShopID, null);

            return SerializeHelper.ByteArrayToString(response);
        }

        /// <summary>
        /// 获取小程序码或小程序二维码 图片 （打印小票用）
        /// </summary>
        /// <returns></returns>
        public byte[] GetEMallMiniProgramImg()
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetEMallMiniProgramImg, null);

            return response;
        }

        /// <summary>
        /// 修改销售单时间。
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult UpdateRetailTime(UpdateTimePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateRetailTime, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 重结报表（ 根据基础信息，重新生成对应的报表及数据变化）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public InteractResult CreateAllReport(CreateAllReportPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.CreateAllReport, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }
        
        /// <summary>
        /// 获取销售分析明细
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public RetailAnalysisDeatilInfo GetRetailAnalysisDeatilInfo(GetRetailAnalysisDeatilInfoPara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetRetailAnalysisDeatilInfo, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<RetailAnalysisDeatilInfo>(response, 0);
        }

        /// <summary>
        /// 批发发货/退货单查询
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public PfOrderPage GetPfOrderPage(GetPfOrderPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfOrderPage, SerializeHelper.ResultToSerialize(para));
            return CompactPropertySerializer.Default.Deserialize<PfOrderPage>(response, 0);
        }

        /// <summary>
        /// 获取批发发货/退货单明细。
        /// </summary>
        /// <param name="pfOrderID"></param>
        /// <returns></returns>
        public List<PfOrderDetail> GetPfOrderDetails(string pfOrderID)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfOrderDetails, SerializeHelper.StringToByteArray(pfOrderID));
            return CompactPropertySerializer.Default.Deserialize<List<PfOrderDetail>>(response, 0);
        }

        /// <summary>
        /// 导入会员信息。
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public InteractResult ImportMembers(List<Member> members)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.ImportMembers, SerializeHelper.ResultToSerialize(members));
            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 获取 批发客户分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public PfCustomerPage GetPfCustomerPage(GetPfCustomerPagePara para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.GetPfCustomerPage, SerializeHelper.ResultToSerialize(para));
            return CompactPropertySerializer.Default.Deserialize<PfCustomerPage>(response, 0);
        }

        /// <summary>
        /// 新增 批发客户 信息
        /// </summary>
        /// <param name="pfCustomer"></param>
        /// <returns></returns>
        public InteractResult InsertPfCustomer(PfCustomer pfCustomer)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.InsertPfCustomer, SerializeHelper.ResultToSerialize(pfCustomer));
            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改 批发客户 信息
        /// </summary>
        /// <param name="pfCustomer"></param>
        /// <returns></returns>
        public InteractResult UpdatePfCustomer(PfCustomer pfCustomer)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdatePfCustomer, SerializeHelper.ResultToSerialize(pfCustomer));
            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 删除 批发客户 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractResult DeletePfCustomer(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DeletePfCustomer, SerializeHelper.StringToByteArray(id));
            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 新增尺码组
        /// </summary>
        /// <param name="sizeGroup"></param>
        /// <returns></returns>
        public InteractResult InsertSizeGroup(SizeGroup sizeGroup)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.InsertSizeGroup, SerializeHelper.ResultToSerialize(sizeGroup));
            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 修改尺码组
        /// </summary>
        /// <param name="sizeGroup"></param>
        /// <returns></returns>
        public InteractResult UpdateSizeGroup(SizeGroup sizeGroup)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.UpdateSizeGroup, SerializeHelper.ResultToSerialize(sizeGroup));
            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 删除尺码组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractResult DeleteSizeGroup(string id)
        {
            byte[] response = this.engine.CustomizeOutter.Query(CommonInformationTypes.DeleteSizeGroup, SerializeHelper.StringToByteArray(id));
            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }


        /// <summary>
        /// 查询供应商列表
        /// </summary>
        /// <returns></returns>
        public List<Supplier> GetSupplierList()
        {
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.GetSupplierList, null);

            return CompactPropertySerializer.Default.Deserialize<List<Supplier>>(response, 0);
        }

        /// <summary>
        /// 获取供应商id
        /// </summary>
        /// <returns></returns>
        public InteractResult GetSupplierId()
        {
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.GetSupplierId, null);
            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }

        /// <summary>
        /// 新增供应商
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public InteractResult InsertSupplier(Supplier para)
        {
            byte[] response = this.engine.CustomizeOutter.Query(ManageInformationTypes.InsertSupplier, SerializeHelper.ResultToSerialize(para));

            return CompactPropertySerializer.Default.Deserialize<InteractResult>(response, 0);
        }
        /// <summary>
        /// 获取有效运费模板列表
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        internal List<EmCarriageCostTemplate> GetValidCarriageCostTemplates()
        {
            byte[] response = this.engine.CustomizeOutter.Query(EMallInformationTypes.GetValidCarriageCostTemplates, null);
            return CompactPropertySerializer.Default.Deserialize<List<EmCarriageCostTemplate>>(response, 0);
        }

    }
}