using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class CostumeStoreTrackPagePara : BasePagePara
    {
        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 款号id
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 尺码
        /// </summary>
        public string SizeName { get; set; }

        /// <summary>
        /// 变化类型
        /// </summary>
        public string CostumeStoreChangeType { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }
        
    }

    public class CostumeStoreTrackPage : BasePage
    {
        public List<CostumeStoreTrack> CostumeStoreTrackList { get; set; }
         
        public CostumeStoreTrack CostumeStoreTrackSum { get; set; }
    }
}
