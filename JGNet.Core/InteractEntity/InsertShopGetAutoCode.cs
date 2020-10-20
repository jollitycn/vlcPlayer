using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class InsertShopGetAutoCode
    {
        public InsertShopResult InsertShopResult { get; set; }

        public int AutoCode { get; set; }
    }

    public enum InsertShopResult
    {
        Success = 0,

        /// <summary>
        /// 总仓已经存在
        /// </summary>
        GeneralStoreIsExist,

        /// <summary>
        /// id已经存在
        /// </summary>
        IDIsExist,

        /// <summary>
        /// 店铺数量超过
        /// </summary>
        MoreThanShopCount,

        /// <summary>
        /// 内部错误。
        /// </summary>
        Error
    }
}
