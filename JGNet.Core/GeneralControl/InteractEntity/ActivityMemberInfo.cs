using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.InteractEntity
{
    [Serializable]
    public class ActivityMemberInfo
    {
        public string ShopID { get; set; }
        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
        /// <summary>
        /// 活跃率
        /// </summary>
        public double ActivityRate { get; set; }

        /// <summary>
        /// 流失率
        /// </summary>
        public double LossRate { get; set; }

        public int ActivityMemberCount { get; set; }

        /// <summary>
        /// 流失客户数量
        /// </summary>
        public int LostMemberCount { get; set; }

        public int TotalMemberCount { get; set; }
    }
}
