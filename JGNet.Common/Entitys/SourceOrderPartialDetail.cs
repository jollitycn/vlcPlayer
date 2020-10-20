using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Common
{
    /// <summary>
    /// 原始单据部分明细
    /// </summary>
    public class SourceOrderPartialDetail
    {
        /// <summary>
        /// 发货店铺ID
        /// </summary>
        public string SourceShopID { get; set; }

        /// <summary>
        /// 收货店铺ID
        /// </summary>
        public string DestShopID { get; set; }

        /// <summary>
        /// 发货店操作人员ID
        /// </summary>
        public string SourceOperatorID { get; set; }

        /// <summary>
        /// 收货店铺操作人ID
        /// </summary>
        public string DestOperatorID { get; set; }


    }
}
