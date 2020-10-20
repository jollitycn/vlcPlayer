namespace CJBasic.Emit.DynamicProxy
{
    using System;

    public sealed class EmptyAopInterceptor : IAopInterceptor
    {
        public IArounder NewArounder()
        {
            return new EmptyArounder();
        }

        public void PostProcess(InterceptedMethod method, object returnVal)
        {
        }

        public void PreProcess(InterceptedMethod method)
        {
        }
    }
}

