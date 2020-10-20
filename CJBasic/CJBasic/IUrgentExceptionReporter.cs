namespace CJBasic
{
    using System;

    public interface IUrgentExceptionReporter
    {
        void CommitUrgentException(string description, string location, Exception ee);
    }
}

