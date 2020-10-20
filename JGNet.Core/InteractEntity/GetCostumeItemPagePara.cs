using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class GetCostumeItemPagePara : CostumeStoreListPara
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

    public class CostumeItemPage : BasePage
    {
        public List<CostumeItem> CostumeItems { get; set; }
    }
}
