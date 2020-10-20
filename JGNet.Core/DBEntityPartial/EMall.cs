using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class EMall
    {
        /// <summary>
        /// 海报
        /// </summary>
        public List<EmPosterImage> PosterImages { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public List<CostumeClass2> CostumeClass2s { get; set; }

        /// <summary>
        /// 广告
        /// </summary>
        public List<EmPosterImage> AdsList { get; set; }
    }
}
