using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet
{
    /// <summary>
    /// 绑定微信帐号结果。
    /// </summary>
    public enum BindWxShopManResult
    {
        Success = 0,

        /// <summary>
        /// 微信号已经绑定过。
        /// </summary>
        Exist,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error,

        /// <summary>
        /// 不存在该OpenID
        /// </summary>
        NotExistOpenID,

        /// <summary>
        /// 不存在该商户ID
        /// </summary>
        NotExistBusinessAccountID,

        /// <summary>
        /// 不存在该登录帐号
        /// </summary>
        NotExistUserID,

        /// <summary>
        /// 登录密码错误
        /// </summary>
        PasswordError,

        /// <summary>
        /// 用户被禁用
        /// </summary>
        UserIsDisabled,

        /// <summary>
        /// 商套已过期
        /// </summary>
        [Description("商套已过期")]
        BusinessAccountExpired,

        /// <summary>
        /// 试用商套已过期
        /// </summary>
        [Description("试用商套已过期")]
        TrialExpired,


        /// <summary>
        /// 商套手机助手未开通
        /// </summary>
        [Description("商套手机助手未开通")]
        MobileAideNotEnabled
    }
}
