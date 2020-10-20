using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core
{
    /// <summary>
    /// 线上商城自定义信息的类型
    /// </summary>
    public class EMallInformationTypes
    {
        #region 线上商城
        /// <summary>
        /// 获取线上商城信息。参数null，返回EMall
        /// </summary>
        public const int GetEMall = 3300;

        /// <summary>
        /// 获取线上商城商场logo。参数null，返回byte[]
        /// </summary>
        public const int GetEMallLogo = 3301;

        /// <summary>
        /// 修改线上商城信息。参数EMall，返回UpdateResult
        /// </summary>
        public const int UpdateEMall = 3302;

        /// <summary>
        /// 修改线上商城商场logo。参数UpdateEMallLogoPara
        /// </summary>
        public const int UpdateEMallLogo = 3303;

        /// <summary>
        /// 获取上架商品。参数GetEmCostumePagePara,返回EmCostumePage
        /// </summary>
        public const int GetEmCostumePage = 3304;

        /// <summary>
        /// 是否在线上商城中作为店主推荐。参数UpdateEmRecommandPara，返回UpdateResult
        /// </summary>
        public const int UpdateEmRecommand = 3305;

        /// <summary>
        /// 下架。参数string，返回UpdateResult
        /// </summary>
        public const int UpdateEmShowOnlineIsFalse = 3306;

        /// <summary>
        /// 获取商品信息。参数GetEmCostumePara，返回EmCostumeInfo
        /// </summary>
        public const int GetEmCostumeInfo = 3307;

        /// <summary>
        /// 修改商品信息。
        /// </summary>
        public const int UpateEmCostumeInfo = 3308;

        /// <summary>
        /// 上架。参数EmCostumeInfo，返回UpdateResult
        /// </summary>
        public const int ShelvesEmCostumeInfo = 3309;

        /// <summary>
        /// 获取cos登陆信息。参数null，返回CosLoginInfo
        /// </summary>
        public const int GetCosLoginInfo = 3310;

        /// <summary>
        /// 线上订单销售管理列表分页查询。参数GetEmOrderPagePara，返回EmOrderPage
        /// </summary>
        public static int GetEmOrderPage = 3311;

        /// <summary>
        /// 新增运费模版。参数CarriageCost，返回InsertResult
        /// </summary>
        public static int InsertCarriageCost = 3312;

        /// <summary>
        /// 获取运费模板分页信息。参数CarriageCostTemplatePagePara，返回CarriageCostTemplatePage
        /// </summary>
        public static int GetCarriageCostTemplatePage = 3313;

        /// <summary>
        /// 删除运费模版。参数int，返回InteractResult
        /// </summary>
        public static int DeleteCarriageCostTemplate = 3314;

        /// <summary>
        /// 修改运费模版。参数CarriageCost，返回UpdateResult
        /// </summary>
        public static int UpdateCarriageCost = 3315;

        /// <summary>
        /// 获取运费模板详细信息。参数int，返回CarriageCost
        /// </summary>
        public static int GetCarriageCost = 3316;

        /// <summary>
        /// 发货。参数EmOutboundPara，返回InteractResult
        /// </summary>
        public static int EmOutbound = 3317;

        /// <summary>
        /// 获取物流信息。参数GetLogisticsPara，返回List<DataInfo>
        /// </summary>
        public static int GetLogistics = 3318;

        /// <summary>
        /// 获取 线上销售单明细。参数string，返回List<EmRetailDetail>
        /// </summary>
        public static int GetEmRetailDetail = 3319;

        /// <summary>
        /// 获取 快递公司列表。参数null，返回List<EmExpressCompany>
        /// </summary>
        public static int GetAllEmExpressCompany = 3320;

        /// <summary>
        /// 修改 快递公司信息。参数EmExpressCompany，返回UpdateResult
        /// </summary>
        public static int UpdateEmExpressCompany = 3321;

        /// <summary>
        /// 获取 启用的快递公司列表。参数null，返回List<EmExpressCompany>
        /// </summary>
        public static int GetEnabledEmExpressCompanys = 3322;

        /// <summary>
        /// 拒绝退款。参数RefusedRefundPara，返回RefundResult
        /// </summary>
        public static int RefusedRefund = 3323;

        /// <summary>
        /// 同意退款。参数AgreeRefundPara，返回RefundResult
        /// </summary>
        public static int AgreeRefund = 3324;

        /// <summary>
        /// 获取有效运费模板列表。参数null，返回List<EmCarriageCostTemplate>
        /// </summary>
        public static int GetValidCarriageCostTemplates = 3325;

        /// <summary>
        /// 线上订单退货管理列表分页查询。参数GetEmOrderPagePara，返回EmRefundOrderPage
        /// </summary>
        public static int GetEmRefundOrderPage = 3326;

        /// <summary>
        /// 确认退款。参数ConfirmRefundPara，返回RefundResult
        /// </summary>
        public static int ConfirmRefund = 3327;

        /// <summary>
        /// 下架的商品重新上架。参数string，返回UpdateResult
        /// </summary>
        public const int UpdateEmShowOnlineIsTrue = 3328;

        /// <summary>
        /// 获取 线上退货单明细，参数string，返回List<EmRefundDetail>
        /// </summary>
        public const int GetEmRefundDetails = 3329;

        /// <summary>
        /// 根据id获取线上销售单。参数string，返回EmRetailOrder
        /// </summary>
        public const int GetOneEmRetailOrder = 3330;

        /// <summary>
        /// 获取退款详情。参数string，返回List<EmRefundTrackInfo>
        /// </summary>
        public const int GetEmRefundTrackInfos = 3331;

        /// <summary>
        /// 获取退货地址。参数null，返回List<EmRefundAddress>
        /// </summary>
        public const int GetEmRefundAddressList = 3332;

        /// <summary>
        /// 新增退货地址。参数EmRefundAddress，返回InsertResult
        /// </summary>
        public const int InsertEmRefundAddress = 3333;

        /// <summary>
        /// 修改退货地址。参数EmRefundAddress，返回UpdateResult
        /// </summary>
        public const int UpdateEmRefundAddress = 3334;

        /// <summary>
        /// 删除退货地址。参数int，返回DeleteResult
        /// </summary>
        public const int DeleteEmRefundAddress = 3335;

        /// <summary>
        /// 模糊查询线上销售单id。参数string，返回List<EmRetailOrder>
        /// </summary>
        public const int GetEmRetailOrderIdLike = 3336;

        /// <summary>
        /// 获取线上退货单物流信息。参数string,返回EmRetailOrder
        /// </summary>
        public const int GetEmRefundOrderLogistics = 3337;

        /// <summary>
        /// 获取线上订单销售各状态单数。参数null，返回EmOrderCount4State
        /// </summary>
        public const int GetEmOrderCount4State = 3338;

        /// <summary>
        /// 修改小程序码或小程序二维码 图片 （打印小票用）。参数UpdateEMallPhotoPara
        /// </summary>
        public const int UpdateEMallMiniProgramImg = 3339;
        #endregion

        #region 线上批发商城
        /// <summary>
        /// 获取线上批发商品。参数GetEmPfCostumePagePara,返回EmPfCostumePage
        /// </summary>
        public const int GetEmPfCostumePage = 3340;

        /// <summary>
        /// 设置服装是否是新品。
        /// </summary>
        public const int IsCostumeNew = 3341;

        /// <summary>
        /// 设置服装是否是推荐。
        /// </summary>
        public const int IsCostumeHot = 3342;

        /// <summary>
        /// 批发下架。
        /// </summary>
        public const int UpdateOnlinePfIsFalse = 3343;

        /// <summary>
        /// 批发商品上架。
        /// </summary>
        public const int ShelvesEmPfCostumeInfo = 3344;

        /// <summary>
        /// 获取批发商品信息。(上传图片和线上商城的一致，上传成功后，重新获取信息，确保图片已上传)
        /// </summary>
        public const int GetEmPfCostumeInfo = 3345;

        /// <summary>
        /// 修改批发商品。
        /// </summary>
        public const int UpdateShelvesEmPfCostumeInfo = 3346;

        /// <summary>
        /// 获取批发订货单分页信息。
        /// </summary>
        public const int GetPfCustomerOrderPage = 3347;
        
        /// <summary>
        /// 作废批发订货单
        /// </summary>
        public const int InvalidPfCustomerOrder = 3348;

        /// <summary>
        /// 批发订货单发货
        /// </summary>
        public const int PfCustomerOrderDelivery = 3349;

        /// <summary>
        /// 获取批发订货单详情。
        /// </summary>
        public const int GetPfCustomerDetails = 3350;

        /// <summary>
        /// 获取线上批发商城信息。参数null，返回PfEMall
        /// </summary>
        public const int GetPfEMall = 3351;

        /// <summary>
        /// 获取线上批发商城商场logo。参数null，返回byte[]
        /// </summary>
        public const int GetPfEMallLogo = 3352;

        /// <summary>
        /// 修改线上批发商城信息。参数PfEMall，返回UpdateResult
        /// </summary>
        public const int UpdatePfEMall = 3353;

        /// <summary>
        /// 修改线上批发商城商场logo。参数UpdateEMallLogoPara
        /// </summary>
        public const int UpdatePfEMallLogo = 3354;

        /// <summary>
        /// 取消批发订货单
        /// </summary>
        public const int CancelPfCustomerOrder = 3355;

        /// <summary>
        /// 设置批发发货单物流信息。
        /// </summary>
        public const int SetPfOrderExpressInfo = 3356;

        /// <summary>
        /// 将线上批发商城的宣传海报图片上传到腾讯云。参数PosterImage
        /// </summary>
        public const int UploadPfPosterImageToCos = 3357;

        /// <summary>
        /// 将线上批发商城的宣传海报图片从腾讯云删除。参数DeletePosterImagePara，返回DeleteResult
        /// </summary>
        public const int DeletePfPosterImageToCos = 3358;

        /// <summary>
        /// 将图片上传到腾讯云。参数PhotoDatas
        /// </summary>
        public const int UploadPfPhotoToCos = 3359;

        /// <summary>
        /// 获取待发货、部分发货的批发订货单各有多少笔
        /// </summary>
        public const int GetPfCustomerOrderCount = 3360;
        #endregion
    }
}
