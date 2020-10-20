namespace CJBasic.Loggers
{
    using CJBasic;
    using System;

    [EnumDescription("异常/错误严重级别")]
    public enum ErrorLevel
    {
        [EnumDescription("致命的", 4)]
        Fatal = 0,
        [EnumDescription("高", 3)]
        High = 1,
        [EnumDescription("低", 1)]
        Low = 3,
        [EnumDescription("普通", 2)]
        Standard = 2
    }
}

