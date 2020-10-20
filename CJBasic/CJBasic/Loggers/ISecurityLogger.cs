namespace CJBasic.Loggers
{
    using System;

    public interface ISecurityLogger
    {
        void Log(string userID, string source, string taskType, string comment);
    }
}

