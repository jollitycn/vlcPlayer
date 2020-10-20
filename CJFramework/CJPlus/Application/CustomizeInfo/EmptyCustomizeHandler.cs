namespace CJPlus.Application.CustomizeInfo
{
    using System;

    public class EmptyCustomizeHandler : ICustomizeHandler
    {
        public void HandleInformation(string sourceUserID, int informationType, byte[] info)
        {
        }

        public byte[] HandleQuery(string sourceUserID, int requestInfoType, byte[] requestInfo)
        {
            return null;
        }
    }
}

