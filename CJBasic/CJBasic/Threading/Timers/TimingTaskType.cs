namespace CJBasic.Threading.Timers
{
    using CJBasic;
    using System;

    [EnumDescription("定时任务的类型")]
    public enum TimingTaskType
    {
        [EnumDescription("每天一次")]
        PerDay = 1,
        [EnumDescription("每小时一次")]
        PerHour = 0,
        [EnumDescription("每月一次")]
        PerMonth = 3,
        [EnumDescription("每周一次")]
        PerWeek = 2
    }
}

