namespace CJPlus.Core
{
    using System;

    public class DefaultServiceTypeNameMatcher : IServiceTypeNameMatcher
    {
        public string GetServiceName(int messageType)
        {
            return messageType.ToString();
        }
    }
}

