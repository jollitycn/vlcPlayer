using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class EmRemark
    {
        public string Name { get; set; }

        public string WxHeadImageUrl { get; set; }

        public string CostumeName { get; set; }

        /// <summary>
        /// 云存储地址
        /// </summary>
        public string CostumeEmThumbnailUrl { get; set; }

        /// <summary>
        /// 线上价
        /// </summary>
        public decimal CostumeEmOnlinePrice { get; set; }
    }
}
