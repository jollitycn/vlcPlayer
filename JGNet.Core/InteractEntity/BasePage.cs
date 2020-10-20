using System;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class BasePagePara: BaseOrderPara
    {
        // <summary>
        /// 分页的大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 要查询目标页的索引
        /// </summary>
        public int PageIndex { get; set; } 
    }

    [Serializable]
    public class BasePage
    {
        public int TotalEntityCount { get; set; }
    }
}