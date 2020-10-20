namespace CJBasic.Loggers
{
    using CJBasic;
    using System;
    using System.Threading;

    public sealed class EmptyAgileLogger : IAgileLogger
    {
        public event CbGeneric<Exception> InnerExceptionOccurred;

        public void Log(Exception ee, string location, ErrorLevel level)
        {
        }

        public void Log(string errorType, string msg, string location, ErrorLevel level)
        {
        }

        public void LogSimple(Exception ee, string location, ErrorLevel level)
        {
        }

        public void LogWithTime(string msg)
        {
        }

        public bool Enabled
        {
            set
            {
            }
        }

        public static explicit operator EmptyAgileLogger(FileAgileLogger v)
        {
            throw new NotImplementedException();
        }
    }
}

