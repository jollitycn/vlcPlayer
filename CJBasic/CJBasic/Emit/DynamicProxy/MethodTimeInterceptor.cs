namespace CJBasic.Emit.DynamicProxy
{
    using CJBasic.Loggers;
    using CJBasic.ObjectManagement.Pool;
    using System;

    public sealed class MethodTimeInterceptor : IAopInterceptor, IPooledObjectCreator<TimeLogArounder>
    {
        private IMethodTimeLogger methodTimeLogger;
        private IObjectPool<TimeLogArounder> timeLogArounderPool;

        public MethodTimeInterceptor()
        {
            this.timeLogArounderPool = new ObjectPool<TimeLogArounder>();
        }

        public MethodTimeInterceptor(IMethodTimeLogger logger)
        {
            this.timeLogArounderPool = new ObjectPool<TimeLogArounder>();
            this.methodTimeLogger = logger;
            this.timeLogArounderPool.MinObjectCount = 1;
            this.timeLogArounderPool.PooledObjectCreator = this;
            this.timeLogArounderPool.Initialize();
        }

        public MethodTimeInterceptor(IAgileLogger logger, int minSpanInMSecsToLog) : this(new MethodTimeFileLogger(logger, minSpanInMSecsToLog))
        {
        }

        public MethodTimeInterceptor(string logFilePath, int minSpanInMSecsToLog) : this(new MethodTimeFileLogger(new FileAgileLogger(logFilePath), minSpanInMSecsToLog))
        {
        }

        public TimeLogArounder Create()
        {
            return new TimeLogArounder(this.timeLogArounderPool, this.methodTimeLogger);
        }

        public IArounder NewArounder()
        {
            return this.timeLogArounderPool.Rent();
        }

        public void PostProcess(InterceptedMethod method, object returnVal)
        {
        }

        public void PreProcess(InterceptedMethod method)
        {
        }

        public void Reset(TimeLogArounder obj)
        {
        }

        public IMethodTimeLogger MethodTimeLogger
        {
            set
            {
                this.methodTimeLogger = value;
            }
        }
    }
}

