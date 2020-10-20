namespace CJPlus.Core
{
    using System;

    public interface IServiceTypeNameMatcher
    {
        string GetServiceName(int messageType);
    }
}

