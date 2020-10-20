using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public enum SignType
    {
        All = -1,

        /// <summary>
        /// 早班上班
        /// </summary>
        EarlyWork = 0,

        /// <summary>
        /// 早班下班
        /// </summary>
        EarlyQuitting,

        /// <summary>
        /// 晚班上班
        /// </summary>
        EveningWork,

        /// <summary>
        /// 晚班下班
        /// </summary>
        EveningQuitting
    }
}
