namespace CJBasic.Loggers
{
    using CJBasic;
    using CJBasic.Helpers;
    using System;
    using System.Threading;

    public sealed class FileAgileLogger : IAgileLogger, IDisposable
    {
        private bool enabled;
        private CJBasic.Loggers.FileLogger fileLogger;
        private string filePath;
        private long maxLength;

        public event CbGeneric<Exception> InnerExceptionOccurred;

        public FileAgileLogger()
        {
            this.filePath = "";
            this.maxLength = 0x7fffffffffffffffL;
            this.enabled = true;
        }

        public FileAgileLogger(string file_Path)
        {
            this.filePath = "";
            this.maxLength = 0x7fffffffffffffffL;
            this.enabled = true;
            this.filePath = file_Path;
        }

        public void Dispose()
        {
            if (this.fileLogger != null)
            {
                this.fileLogger.Dispose();
            }
        }

        public void Log(Exception ee, string location, ErrorLevel level)
        {
            string str = "";
            if (ee is NullReferenceException)
            {
                try
                {
                    str = str + "[" + NullReferenceHelper.GetExceptionMethodAddress(ee) + "] at ";
                }
                catch
                {
                }
            }
            string msg = ee.Message + " [:] " + str + ee.StackTrace;
            this.Log(ee.GetType().ToString(), msg, location, level);
        }

        public void Log(string errorType, string msg, string location, ErrorLevel level)
        {
            try
            {
                if (this.enabled)
                {
                    string str = string.Format("\n{0} : {1} －－ {2} 。错误类型:{3}。位置：{4}", new object[] { DateTime.Now.ToString(), EnumDescription.GetFieldText(level), msg, errorType, location });
                    this.FileLogger.Log(str);
                }
            }
            catch (Exception exception)
            {
                exception = exception;
            }
        }

        public void LogSimple(Exception ee, string location, ErrorLevel level)
        {
            this.Log(ee.GetType().ToString(), ee.Message, location, level);
        }

        public void LogWithTime(string msg)
        {
            try
            {
                if (this.enabled)
                {
                    this.FileLogger.LogWithTime(msg);
                }
            }
            catch (Exception exception)
            {
                if (this.InnerExceptionOccurred != null)
                {
                    this.InnerExceptionOccurred(exception);
                }
            }
        }

        public bool Enabled
        {
            set
            {
                this.enabled = value;
            }
        }

        private CJBasic.Loggers.FileLogger FileLogger
        {
            get
            {
                if (this.fileLogger == null)
                {
                    this.fileLogger = new CJBasic.Loggers.FileLogger(this.filePath);
                    this.fileLogger.MaxLength4ChangeFile = this.maxLength;
                }
                return this.fileLogger;
            }
        }

        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;
            }
        }

        public long MaxLength4ChangeFile
        {
            get
            {
                return this.maxLength;
            }
            set
            {
                if (value <= 0L)
                {
                    throw new ArgumentOutOfRangeException("MaxLength4ChangeFile must greater than 0.");
                }
                this.maxLength = value;
                if (this.fileLogger != null)
                {
                    this.fileLogger.MaxLength4ChangeFile = value;
                }
            }
        }
    }
}

