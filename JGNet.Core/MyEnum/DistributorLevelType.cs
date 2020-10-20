using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.MyEnum
{
    public enum DistributorLevelType
    {
        /// <summary>
     /// 所有
     /// </summary>
        [Description("所有")]
        All = -1,
        /// <summary>
        /// 一级
        /// </summary>
        [Description("一级")]
        LevelOne = 1,

        /// <summary>
        /// 二级
        /// </summary>
        [Description("二级")]
        LevelTwo = 2,
        /// <summary>
        /// 三级
        /// </summary>
        [Description("三级")]
        LevelThree = 3,

        /// <summary>
        /// 四级
        /// </summary>
        [Description("四级")]
        LevelFour = 4,

        /// <summary>
        /// 五级
        /// </summary>
        [Description("五级")]
        LevelFive = 5,

        /// <summary>
        /// 六级
        /// </summary>
        [Description("六级")]
        LevelSix = 6,

        /// <summary>
        /// 七级
        /// </summary>
        [Description("七级")]
        LevelSeven= 7,

        /// <summary>
        /// 八级
        /// </summary>
        [Description("八级")]
        LevelEight =8,


        /// <summary>
        /// 九级
        /// </summary>
        [Description("九级")]
        LevelNine = 9,

        /// <summary>
        /// 二级
        /// </summary>
        [Description("十级")]
        LevelTen = 10,
    }
}
