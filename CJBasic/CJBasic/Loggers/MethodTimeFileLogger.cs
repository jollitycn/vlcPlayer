namespace CJBasic.Loggers
{
    using System;
    using System.Text;

    public class MethodTimeFileLogger : IMethodTimeLogger
    {
        private IAgileLogger agileLogger;
        private int minSpanInMSecsToLog;

        public MethodTimeFileLogger()
        {
            this.minSpanInMSecsToLog = 0;
        }

        public MethodTimeFileLogger(IAgileLogger logger, int _minSpanInMSecsToLog)
        {
            this.minSpanInMSecsToLog = 0;
            this.agileLogger = logger;
            this.minSpanInMSecsToLog = _minSpanInMSecsToLog;
        }

        public void Log(string methodPath, Type[] genericTypes, string[] argumentNames, object[] argumentValues, double millisecondsConsumed)
        {
            if (millisecondsConsumed >= this.minSpanInMSecsToLog)
            {
                int num;
                StringBuilder builder = new StringBuilder(methodPath);
                if ((genericTypes != null) && (genericTypes.Length > 0))
                {
                    builder.Append("<");
                    for (num = 0; num < genericTypes.Length; num++)
                    {
                        builder.Append(genericTypes[num].ToString());
                        if (num != (genericTypes.Length - 1))
                        {
                            builder.Append(",");
                        }
                    }
                    builder.Append(">");
                }
                string str = builder.ToString();
                if ((argumentNames != null) && (argumentNames.Length > 0))
                {
                    StringBuilder builder2 = new StringBuilder("<Parameters>");
                    for (num = 0; num < argumentNames.Length; num++)
                    {
                        builder2.Append(string.Format("<{0}>{1}</{0}>", argumentNames[num], (argumentValues[num] == null) ? "NULL" : argumentValues[num].ToString()));
                    }
                    builder2.Append("</Parameters>");
                    str = str + "@" + builder2.ToString();
                }
                string msg = string.Format("{0}，耗时:{1}ms", str, millisecondsConsumed);
                this.agileLogger.LogWithTime(msg);
            }
        }

        public IAgileLogger AgileLogger
        {
            set
            {
                this.agileLogger = value;
            }
        }

        public int MinSpanInMSecsToLog
        {
            get
            {
                return this.minSpanInMSecsToLog;
            }
            set
            {
                this.minSpanInMSecsToLog = value;
            }
        }
    }
}

