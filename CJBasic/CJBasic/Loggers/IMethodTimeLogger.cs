namespace CJBasic.Loggers
{
    using System;

    public interface IMethodTimeLogger
    {
        void Log(string methodPath, Type[] genericTypes, string[] argumentNames, object[] argumentValues, double millisecondsConsumed);
    }
}

