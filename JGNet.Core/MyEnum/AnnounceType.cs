using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.MyEnum
{
    public enum AnnounceType
    {
        /// <summary>
        /// 版本升级
        /// </summary>
        VersionUpgrade = 1
        
    }

    public enum AnnounceState
    {
        /// <summary>
        /// 发布中
        /// </summary>
        Releasing = 1,

        /// <summary>
        /// 已完成
        /// </summary>
        Finished,

        /// <summary>
        /// 已取消
        /// </summary>
        Cancel
    }
}
