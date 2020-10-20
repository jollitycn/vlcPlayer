namespace CJBasic.Loggers
{
    using System;

    public interface ILogger : IDisposable
    {
        void Log(string msg);
        void LogWithTime(string msg);

        bool Enabled { get; set; }
    }
}

