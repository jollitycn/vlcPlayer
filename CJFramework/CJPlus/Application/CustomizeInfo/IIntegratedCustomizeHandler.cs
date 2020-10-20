namespace CJPlus.Application.CustomizeInfo
{
    using System;

    public interface IIntegratedCustomizeHandler : ICustomizeHandler
    {
        bool CanHandle(int informationType);
    }
}

