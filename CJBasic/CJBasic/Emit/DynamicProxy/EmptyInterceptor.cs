namespace CJBasic.Emit.DynamicProxy
{
    using System;

    public sealed class EmptyInterceptor : IAopInterceptor, IArounder
    {
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
        }

        public void PostProcess(InterceptedMethod method, object returnVal)
        {
        }

        public void PreProcess(InterceptedMethod method)
        {
        }
    }
}

