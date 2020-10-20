namespace CJPlus.Application.CustomizeInfo
{
    using System;

    public interface ICustomizeHandler
    {
        void HandleInformation(string sourceUserID, int informationType, byte[] info);
        byte[] HandleQuery(string sourceUserID, int informationType, byte[] info);
    }
}

