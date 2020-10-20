namespace CJBasic.Loggers
{
    using System;

    public class SecurityFileLogger : ISecurityLogger
    {
        private IAgileLogger agileLogger;

        public SecurityFileLogger()
        {
        }

        public SecurityFileLogger(IAgileLogger logger)
        {
            this.agileLogger = logger;
        }

        public void Log(string userID, string source, string taskType, string comment)
        {
            string msg = string.Format("User:{0},Source:{1},TaskType:{2},Comment:{3}.", new object[] { userID, source, taskType, comment });
            this.agileLogger.LogWithTime(msg);
        }

        public IAgileLogger AgileLogger
        {
            set
            {
                this.agileLogger = value;
            }
        }
    }
}

