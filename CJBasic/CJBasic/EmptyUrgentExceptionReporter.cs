namespace CJBasic
{
    using System;

    public sealed class EmptyUrgentExceptionReporter : IUrgentExceptionReporter
    {
        public void CommitUrgentException(string description, string location, Exception ee)
        {
        }
    }
}

