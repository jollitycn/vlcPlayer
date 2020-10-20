namespace CJBasic.Loggers
{
    using System;

    public class EmptyExceptionLogger : IExceptionLogger
    {
        public void Log(Exception ee, string methodPath, Type[] genericTypes, string[] argumentNames, object[] argumentValues)
        {
        }
    }
}

