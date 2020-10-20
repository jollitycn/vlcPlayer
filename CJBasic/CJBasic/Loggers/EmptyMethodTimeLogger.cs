namespace CJBasic.Loggers
{
    using System;

    public class EmptyMethodTimeLogger : IMethodTimeLogger
    {
        public void Log(string methodPath, Type[] genericTypes, string[] argumentNames, object[] argumentValues, double millisecondsConsumed)
        {
        }
    }
}

