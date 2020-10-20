namespace CJBasic.Loggers
{
    using CJBasic;
    using System;

    public interface IAgileLogger
    {
        event CbGeneric<Exception> InnerExceptionOccurred;

        void Log(Exception ee, string location, ErrorLevel level);
        void Log(string errorType, string msg, string location, ErrorLevel level);
        void LogSimple(Exception ee, string location, ErrorLevel level);
        void LogWithTime(string msg);

        bool Enabled { set; }
    }
}

