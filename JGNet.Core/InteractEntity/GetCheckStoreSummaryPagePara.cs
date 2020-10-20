using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetCheckStoreSummaryPagePara : BasePagePara
    {
        public string ShopID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public CheckStoreState State { get; set; }
    }

    public enum CheckStoreState
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 盘盈
        /// </summary>
        [Description("盘盈")]
        Win = 1,

        /// <summary>
        /// 盘亏
        /// </summary>
        [Description("盘亏")]
        Lost = 2
    }

    public class CheckStoreSummaryPage : BasePage
    {
        public List<CheckStoreSummary> CheckStoreSummarys { get; set; }

        public CheckStoreSummary CheckStoreSummarySum { get; set; }
    }
}
