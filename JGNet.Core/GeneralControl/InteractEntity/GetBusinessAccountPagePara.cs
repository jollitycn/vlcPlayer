using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.GeneralControl.InteractEntity
{
    [Serializable]
    public class GetBusinessAccountPagePara : BasePagePara
    {
        public string BusinessAccountID { get; set; }

        /// <summary>
        /// 账套状态
        /// </summary>
        public BusinessAccountState BusinessAccountState { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public BusinessAccountType BusinessAccountType { get; set; }
    }

    public static class BusinessAccountOrderBy
    {
        public const string ExpiredDate = BusinessAccount._ExpiredDate;

        public const string WillExpiredDay = "WillExpiredDay";
    }

    public enum BusinessAccountState
    {
        /// <summary>
        /// 所有
        /// </summary>
        All = 0,

        /// <summary>
        /// 启用
        /// </summary>
        Enabled,

        /// <summary>
        /// 停用
        /// </summary>
        Stop
    }

    public enum BusinessAccountType
    {
        /// <summary>
        /// 所有
        /// </summary>
        All = 0,

        /// <summary>
        /// 正式
        /// </summary>
        Formal,

        /// <summary>
        /// 试用
        /// </summary>
        Trial
    }
}
