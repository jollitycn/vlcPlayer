namespace CJPlus.Rapid
{
    using CJBasic.Loggers;
    using System;

    public interface IRapidEngine
    {
        string LogFilePath { get; set; }

        IAgileLogger Logger { set; }

        bool SecurityLogEnabled { get; set; }
    }
}

