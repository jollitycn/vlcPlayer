namespace CJBasic.Emit.DynamicProxy
{
    using CJBasic.Loggers;
    using System;

    public class ExceptionInterceptor : IAopInterceptor, IArounder
    {
        private IExceptionLogger exceptionFilter;

        public ExceptionInterceptor()
        {
        }

        public ExceptionInterceptor(IAgileLogger logger) : this(new ExceptionFileLogger(logger))
        {
        }

        public ExceptionInterceptor(IExceptionLogger logger)
        {
            this.exceptionFilter = logger;
        }

        public ExceptionInterceptor(string logFilePath) : this(new ExceptionFileLogger(new FileAgileLogger(logFilePath)))
        {
        }

        public void BeginAround(InterceptedMethod method)
        {
        }

        public void EndAround(object returnVal)
        {
        }

        public IArounder NewArounder()
        {
            return this;
        }

        public void OnException(InterceptedMethod method, Exception ee)
        {
            string methodPath = string.Format("{0}.{1}", method.Target.GetType().ToString(), method.MethodName);
            this.exceptionFilter.Log(ee, methodPath, method.GenericTypes, method.ArgumentNames, method.ArgumentValues);
        }

        public void PostProcess(InterceptedMethod method, object returnVal)
        {
        }

        public void PreProcess(InterceptedMethod method)
        {
        }
    }
}

