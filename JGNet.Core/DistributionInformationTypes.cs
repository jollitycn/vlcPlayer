using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core
{
    public class DistributionInformationTypes
    {
        /// <summary>
        /// 获取佣金抽成比例
        /// </summary>
        public const int GetCommissionRatio = 6000;

        /// <summary>
        /// 修改佣金抽成比例
        /// </summary>
        public const int UpdateCommissionRatio = 6001;

        /// <summary>
        /// 获取分销人员分页信息
        /// </summary>
        public const int GetDistributorPage = 6002;

        /// <summary>
        /// 新增分销人员
        /// </summary>
        public const int InsertDistributor = 6003;

        /// <summary>
        /// 获取线下客户
        /// </summary>
        public const int GetPfCustomerPage4Distributor = 6004;

        /// <summary>
        /// 修改分销人员信息
        /// </summary>
        public const int UpdateDistributor = 6005;

        /// <summary>
        /// 根据 客户编号/名称 模糊查询客户
        /// </summary>
        public const int GetPfCustomersLike = 6006;

        //新增批发客户：CommonInformationTypes.InsertPfCustomer，

        //录入回款金额
        public const int InsertPfAccountRecord4Fx = 6007;

        /// <summary>
        /// 获取 分销人员提款申请记录 分页信息。
        /// </summary>
        public const int GetDistributorWithdrawRecordPage = 6008;

        /// <summary>
        /// 提现管理付款
        /// </summary>
        public const int PayDistributorWithdrawRecord = 6009;

        /// <summary>
        /// 取消提现申请
        /// </summary>
        public const int CancelDistributorWithdrawRecord = 6010;

        /// <summary>
        /// 获取分销人员id
        /// </summary>
        public const int GetDistributorID = 6011;

        /// <summary>
        /// 导入商品信息
        /// </summary>
        public const int ImportPfInfos = 6012;

        /// <summary>
        /// 将图片上传到腾讯云。
        /// </summary>
        public const int UploadPhotoToCos = 6013;

        /// <summary>
        /// 将图片上传到腾讯云结果。
        /// </summary>
        public const int UploadPhotoToCosResult = 6014;
    }
}
