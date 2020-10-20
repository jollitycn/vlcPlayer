using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet
{
    /// <summary>
    /// 新增结果
    /// </summary>
    [Serializable]
    public enum InsertResult
    {
        [Description("成功")]
        Success = 0,

        [Description("内部错误")]
        Error
    }

    /// <summary>
    /// 修改结果
    /// </summary>
    [Serializable]
    public enum UpdateResult
    {
        Success = 0,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    /// <summary>
    /// 删除结果
    /// </summary>
    [Serializable]
    public enum DeleteResult
    {
        [Description("成功")]
        Success = 0,

        [Description("内部错误")]
        Error
    }
    
    /// <summary>
    /// 注册会员结果。
    /// </summary>
    public enum RegisterMemberResult
    {
        Success = 0,

        /// <summary>
        /// 已经存在。
        /// </summary>
        Exist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    /// <summary>
    /// 修改会员结果。
    /// </summary>
    public enum UpdateMemberResult
    {
        Success = 0,

        /// <summary>
        /// 会员不存在。
        /// </summary>
        IsNotExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }
    
    /// <summary>
    /// 充值结果
    /// </summary>
    public enum RechargeResult
    {
        Success = 0,

        /// <summary>
        /// 会员不存在
        /// </summary>
        [Description("会员不存在")]
        MemberIsNotExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        [Description("内部错误")]
        Error

    }
    
    public enum InsertGuideResult
    {
        Success = 0,

        /// <summary>
        /// 导购员账号已经存在
        /// </summary>
       Exist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum InsertSupplierResult
    {
        Success = 0,

        /// <summary>
        /// 供应商账号已经存在
        /// </summary>
        Exist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum InsertCostumeResult
    {
        Success = 0,

        /// <summary>
        /// 款号已经存在
        /// </summary>
        Exist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }
    
    public enum InsertCostumeColorResult
    {
        Success = 0,

        /// <summary>
        /// 色号已经存在
        /// </summary>
        CostumeColorResultIDIsExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum InsertCostumeClassResult
    {
        Success = 0,

        /// <summary>
        /// 大类已经存在
        /// </summary>
        BigClassIsExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum IsSalesPromotionUseResult
    {
        False = 0,

        True,
        
        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }
    
    public enum UpdateShopResult
    {
        Success = 0,

        /// <summary>
        /// 总仓已经存在
        /// </summary>
        GeneralStoreIsExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum InsertAdminResult
    {
        Success = 0,

        /// <summary>
        /// 管理员id已存在
        /// </summary>
        Exist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum IsDayReportManualConfirmResult
    {
        False = 0,
        
        True,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum DeleteAdminUserResult
    {
        Success = 0,

        /// <summary>
        /// 默认管理员id不能删除
        /// </summary>
        DefaultAdminIsNoDelete,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum CheckStoreOrderStatePendingReviewResult
    {
        False = 0,

        True,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum UpdateCheckStoreResult
    {
        Success = 0,

        /// <summary>
        /// 状态不是待审核
        /// </summary>
        StateIsNotPendingReview,

        /// <summary>
        /// 状态是已审核或者待审核
        /// </summary>
        StateIsApprovedOrPendingReview,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum ReplenishOutboundResult
    {
        [Description("成功")]
        Success = 0,

        /// <summary>
        /// 不是补货申请单
        /// </summary>
        [Description("不是补货申请单")]
        IsNotReplenish,

        /// <summary>
        /// 已经发货
        /// </summary> 
        [Description("已经发货")]
        IsDelivery,

        /// <summary>
        /// 库存不足
        /// </summary>
        [Description("库存不足")]
        CostumeStoreIsNotEnough,

        /// <summary>
        /// 内部错误。
        /// </summary>
        [Description("内部错误")]
        Error
    }
    
    public enum DifferenceOrderConfirmedResult
    {
        Success = 0,

        /// <summary>
        /// 来源单据编号类型不是盘点，补货申请或者调拨的一种
        /// </summary>
        SourceOrderIDIsError,

        /// <summary>
        /// 已经确认过
        /// </summary>
        IsConfirmed,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum DeleteCheckStoreResult
    {
        Success = 0,

        /// <summary>
        /// 状态是待审核或已审核，不能删除
        /// </summary>
        StateIsPendingReviewOrApproved,

        /// <summary>
        /// 不是自己店铺的盘点单
        /// </summary>
        IsNotMyselfShop,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum SignResult
    {
        Success = 0,

        /// <summary>
        /// 已经打卡
        /// </summary>
        IsSign,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum InsertMonthTaskResult
    {
        Success = 0,

        /// <summary>
        /// 已经存在
        /// </summary>
        IsExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum UpdateMonthTaskResult
    {
        Success = 0,

        /// <summary>
        /// 小于当前月份
        /// </summary>
        IsLessCurrentMonth,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum InsertParameterConfigResult
    {
        Success = 0,
        
        ParaKeyIsExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum InsertMembersResult
    {
        Success = 0,

        /// <summary>
        /// 会员存在
        /// </summary>
        MemberIsExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum InsertShopsResult
    {
        Success = 0,

        /// <summary>
        /// 店铺存在
        /// </summary>
        ShopIsExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum InsertCostumeStoreResult
    {
        Success = 0,

        /// <summary>
        /// 有服装在店铺里存在或者大类已经存在
        /// </summary>
        IsExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum OverrideOrderResult
    {
        Success = 0,

        /// <summary>
        /// 不是发货状态
        /// </summary>
        StateIsNotDelivery,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum UpdateRechargeDonateRuleResult
    {
        Success = 0,

        /// <summary>
        /// 充值金额已经存在开启
        /// </summary>
        RechargeMoneyOpenIsExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum ImportRetailDataResult
    {
        Success = 0,

        /// <summary>
        /// 已经存在数据
        /// </summary>
        IsExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }

    public enum CancelRetailOrderResult
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 0,

        /// <summary>
        /// 不是今天的单据
        /// </summary>
        [Description("不是今天的单据")]
        IsNotToday,

        /// <summary>
        /// 已经冲单
        /// </summary>
        [Description("已经冲单")]
        IsCancel,

        /// <summary>
        /// 是退货单
        /// </summary>
        [Description("是退货单")]
        IsRefundOrder,

        /// <summary>
        /// 是销售单
        /// </summary>
        [Description("是销售单")]
        IsRetailOrder,

        /// <summary>
        /// 内部错误。
        /// </summary>
        [Description("内部错误")]
        Error
    }

    public enum LastCheckStoreTaskState
    {

        /// <summary>
        /// 未完成
        /// </summary>
        NotFinish = 0,

        /// <summary>
        /// 完成
        /// </summary>
        Finish = 1,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error,

        /// <summary>
        /// 该店铺没有在未完成任务的参与店铺列表中
        /// </summary>
        NotContains
    }

    public enum ShopIDCheckStoreTask
    {
        Error = -1,

        Yes,

        No
    }

    public enum RefundResult
    {
        Success = 0,
        
        /// <summary>
        /// 退款申请状态不符合要求
        /// </summary>
        StateIsError,

        /// <summary>
        /// 已经退货过
        /// </summary>
        IsRefund,

        /// <summary>
        /// 会员不存在
        /// </summary>
        MemberIsNotExist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }
}
