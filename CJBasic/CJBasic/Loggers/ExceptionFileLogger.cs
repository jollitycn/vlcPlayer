namespace CJBasic.Loggers
{
    using System;
    using System.Text;

    public class ExceptionFileLogger : IExceptionLogger
    {
        protected IAgileLogger agileLogger;
        protected CJBasic.Loggers.ErrorLevel errorLevel;

        public ExceptionFileLogger()
        {
            this.errorLevel = CJBasic.Loggers.ErrorLevel.Standard;
        }

        public ExceptionFileLogger(IAgileLogger logger) : this(logger, CJBasic.Loggers.ErrorLevel.Standard)
        {
        }

        public ExceptionFileLogger(IAgileLogger logger, CJBasic.Loggers.ErrorLevel _errorLevel)
        {
            this.errorLevel = CJBasic.Loggers.ErrorLevel.Standard;
            this.agileLogger = logger;
            this.errorLevel = _errorLevel;
        }

        public void Log(Exception ee, string methodPath, Type[] genericTypes, string[] argumentNames, object[] argumentValues)
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
            string location = builder.ToString();
            if ((argumentNames != null) && (argumentNames.Length > 0))
            {
                StringBuilder builder2 = new StringBuilder("<Parameters>");
                for (num = 0; num < argumentNames.Length; num++)
                {
                    builder2.Append(string.Format("<{0}>{1}</{0}>", argumentNames[num], (argumentValues[num] == null) ? "NULL" : argumentValues[num].ToString()));
                }
                builder2.Append("</Parameters>");
                location = location + "@" + builder2.ToString();
            }
            this.agileLogger.Log(ee, location, this.errorLevel);
        }

        public IAgileLogger AgileLogger
        {
            set
            {
                this.agileLogger = value;
            }
        }

        public CJBasic.Loggers.ErrorLevel ErrorLevel
        {
            set
            {
                this.errorLevel = value;
            }
        }
    }
}

