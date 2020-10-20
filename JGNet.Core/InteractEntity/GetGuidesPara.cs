using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetGuidesPara
    {
        public string IdOrName { get; set; }

        public string ShopID { get; set; }

        public GuideState State { get; set; }
    }

    public enum GuideState
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enable = 0,

        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disable = 1
    }
}
