namespace CJBasic.Emit.DynamicProxy
{
    using CJBasic.Loggers;
    using CJBasic.ObjectManagement.Pool;
    using System;
    using System.Diagnostics;

    public sealed class TimeLogArounder : IArounder
    {
        private InterceptedMethod interceptedMethod;
        private IMethodTimeLogger methodTimeLogger;
        private IObjectPool<TimeLogArounder> objectPool;
        private Stopwatch stopwatch = new Stopwatch();

        public TimeLogArounder(IObjectPool<TimeLogArounder> pool, IMethodTimeLogger logger)
        {
            this.objectPool = pool;
            this.methodTimeLogger = logger;
        }

        public void BeginAround(InterceptedMethod method)
        {
            this.interceptedMethod = method;
            this.stopwatch.Reset();
            this.stopwatch.Start();
        }

        public void EndAround(object returnVal)
        {
            this.stopwatch.Stop();
            string methodPath = string.Format("{0}.{1}", this.interceptedMethod.Target.GetType().ToString(), this.interceptedMethod.MethodName);
            this.methodTimeLogger.Log(methodPath, this.interceptedMethod.GenericTypes, this.interceptedMethod.ArgumentNames, this.interceptedMethod.ArgumentValues, (double) this.stopwatch.ElapsedMilliseconds);
            this.stopwatch.Reset();
            this.objectPool.GiveBack(this);
        }

        public void OnException(InterceptedMethod method, Exception ee)
        {
            this.stopwatch.Stop();
            this.stopwatch.Reset();
            this.objectPool.GiveBack(this);
        }
    }
}

