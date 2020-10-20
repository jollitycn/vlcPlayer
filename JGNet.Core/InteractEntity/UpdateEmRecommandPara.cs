using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class UpdateEmRecommandPara
    {
        /// <summary>
        /// 款号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 是否在线上商城中作为店主推荐
        /// </summary>
        public bool EmIsRecommand { get; set; }
    }
}
