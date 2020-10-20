namespace CJBasic.Emit.DynamicProxy
{
    using System;

    public interface IArounder
    {
        void BeginAround(InterceptedMethod method);
        void EndAround(object returnVal);
        void OnException(InterceptedMethod method, Exception ee);
    }
}

