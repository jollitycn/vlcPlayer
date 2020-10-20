namespace CJBasic.Loggers
{
    using System;

    public interface IExceptionLogger
    {
        void Log(Exception ee, string methodPath, Type[] genericTypes, string[] argumentNames, object[] argumentValues);
    }
}

