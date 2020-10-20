using JGNet.Core.MyEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class InteractResult
    {
        public string Msg { get; set; }

        public ExeResult ExeResult { get; set; }

        /// <summary>
        /// 响应编码，界面根据编码显示对应文字
        /// </summary>
        public ResponseCode ResponseCode { get; set; }
    }

    [Serializable]
    public class InteractResult<T>
    {
        public string Msg { get; set; }

        public T Data { get; set; }

        public ExeResult ExeResult { get; set; }

        /// <summary>
        /// 响应编码，界面根据编码显示对应文字
        /// </summary>
        public ResponseCode ResponseCode { get; set; }
    }

    public enum ExeResult
    {
        Success = 0,

        Error
    }

    public enum ResponseCode
    {
        /// <summary>
        /// 网站发生异常
        /// </summary>
        WebError = -2,

        /// <summary>
        /// 服务发生异常
        /// </summary>
        Error = -1,

        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,

        /// <summary>
        /// 数据错误
        /// </summary>
        DataError = 1,
        
        /// <summary>
        /// 查询不到相关数据
        /// </summary>
        UnFindData = 2,

        /// <summary>
        /// 密码错误
        /// </summary>
        PwdError = 3,

        /// <summary>
        /// 原始密码错误
        /// </summary>
        OriginalPwdError = 4,

        /// <summary>
        /// 验证码不存在或已过期
        /// </summary>
        SmsCodeIsError = 5,

        #region 账套
        /// <summary>
        /// 账套过期 
        /// </summary>
        BusinessAccountIsExpired = 101,

        /// <summary>
        /// 账套不存在
        /// </summary>
        BusinessAccountNotExist = 102,

        /// <summary>
        /// 账套已被禁用
        /// </summary>
        BusinessAccountIsDisable = 103,
        #endregion

        #region 会员
        /// <summary>
        /// 会员不存在
        /// </summary>
        MemberIsNotExist = 201,

        /// <summary>
        /// 余额不足
        /// </summary>
        BalanceIsNotEnough = 202,

        /// <summary>
        /// 积分不足
        /// </summary>
        IntegrationIsNotEnough = 203,

        /// <summary>
        /// 号码已被使用
        /// </summary>
        PhoneNumberIsUse = 204,
        #endregion

        #region 单据
        /// <summary>
        /// 单据是关闭状态
        /// </summary>
        OrderStateIsClose = 301,

        /// <summary>
        /// 单据是取消状态
        /// </summary>
        OrderStateIsCancel = 302,

        /// <summary>
        /// 超过次数
        /// </summary>
        OverNumber = 303,

        /// <summary>
        /// 金额错误
        /// </summary>
        MoneyError = 304,

        /// <summary>
        /// 单据不是申请状态
        /// </summary>
        OrderStateIsNotApplication = 305,

        /// <summary>
        /// 单据不存在
        /// </summary>
        OrderIsNotExist = 306,

        /// <summary>
        /// 单据不是待填写物流状态
        /// </summary>
        OrderStateIsNotWriteExpress = 307,

        /// <summary>
        /// 单据已作废
        /// </summary>
        OrderIsInvalid = 308,

        /// <summary>
        /// 单据已付款
        /// </summary>
        OrderIsPay = 309,

        /// <summary>
        /// 查询不到此单号
        /// </summary>
        NotFindOrder = 310
        #endregion

    }
}
