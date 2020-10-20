namespace CJBasic.Loggers
{
    using System;

    public class EmptyLogger : ILogger, IDisposable
    {
        public void Dispose()
        {
        }

        public void Log(string msg)
        {
        }

        public void LogWithTime(string msg)
        {
        }

        public bool Enabled
        {
            get
            {
                return true;
            }
            set
            {
            }
        }
    }
}

