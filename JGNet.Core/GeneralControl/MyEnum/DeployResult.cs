using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    [Serializable]
    public enum DeployResult
    {
        Success = 0,

        /// <summary>
        /// 服务端ip未注册
        /// </summary>
        ServiceIPIsNotRegister,

        /// <summary>
        /// 心跳超时
        /// </summary>
        IsTimeout,

        /// <summary>
        /// 创建数据库失败
        /// </summary>
        CreateBataBaseIsError,

        /// <summary>
        /// 创建表失败
        /// </summary>
        CrateTableIsError,

        /// <summary>
        /// 插入默认数据失败
        /// </summary>
        InsertDataIsError,

        /// <summary>
        /// 复制服务端失败
        /// </summary>
        CopyServiceIsError,

        /// <summary>
        /// 开启服务端失败
        /// </summary>
        OpenServiceIsError,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }
}
