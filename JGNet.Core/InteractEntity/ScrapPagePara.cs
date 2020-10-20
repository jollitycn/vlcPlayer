using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class ScrapPagePara : BasePagePara
    {
        /// <summary>
        /// 单据编号
        /// </summary>
        public string ScrapOrderID { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }
        
        /// <summary>
        /// 开始日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }
        
    }

    public class ScrapPage : BasePage
    {
        public List<ScrapOrder> ScrapOrderList { get; set; } 
        public ScrapOrder ScrapOrderSum { get; set; }
    }
}
