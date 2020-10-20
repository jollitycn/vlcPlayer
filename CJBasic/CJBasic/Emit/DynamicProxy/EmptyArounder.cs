namespace CJBasic.Emit.DynamicProxy
{
    using System;

    public class EmptyArounder : IArounder
    {
        public void BeginAround(InterceptedMethod method)
        {
        }

        public void EndAround(object returnVal)
        {
        }

        public void OnException(InterceptedMethod method, Exception ee)
        {
        }
    }
}

