namespace CJBasic.Loggers
{
    using System;

    public class EmptySecurityLogger : ISecurityLogger
    {
        public void Log(string userID, string source, string taskType, string comment)
        {
        }
    }
}

