namespace CJBasic.Emit.DynamicProxy
{
    using System;

    public interface IAopInterceptor
    {
        IArounder NewArounder();
        void PostProcess(InterceptedMethod method, object returnVal);
        void PreProcess(InterceptedMethod method);
    }
}

