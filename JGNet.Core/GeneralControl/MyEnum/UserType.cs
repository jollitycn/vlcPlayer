using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public enum UserType
    {
        /// <summary>
        /// 后台管理员(老板)
        /// </summary>
        Admin = 0,

        /// <summary>
        /// 导购员
        /// </summary>
        Guide = 1,

        /// <summary>
        /// 顾客
        /// </summary>
        Consumer = 2,

        /// <summary>
        /// 不存在
        /// </summary>
        NotExist = 3,

        /// <summary>
        /// 全部类型   用于查询全部
        /// </summary>
        All = 100,
    }
}
