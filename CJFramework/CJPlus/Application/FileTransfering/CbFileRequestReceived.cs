namespace CJPlus.Application.FileTransfering
{
    using CJPlus.FileTransceiver;
    using System;
    using System.Runtime.CompilerServices;

    public delegate void CbFileRequestReceived(string projectID, string senderID, string fileName, ulong totalSize, ResumedProjectItem resumedFileItem, string comment);
}

