namespace CJBasic.Threading.Timers.RichTimer
{
    using CJBasic;
    using System;

    [EnumDescription("定时器类型")]
    public enum RichTimerType
    {
        [EnumDescription("每周期一次", 5)]
        EverySpan = 5,
        [EnumDescription("仅仅在目标时间执行一次", 6)]
        JustOnce = 6,
        [EnumDescription("不定时", 0)]
        None = 0,
        [EnumDescription("每天一次", 2)]
        PerDay = 2,
        [EnumDescription("每小时一次", 1)]
        PerHour = 1,
        [EnumDescription("每月一次", 4)]
        PerMonth = 4,
        [EnumDescription("每周一次", 3)]
        PerWeek = 3
    }
}

