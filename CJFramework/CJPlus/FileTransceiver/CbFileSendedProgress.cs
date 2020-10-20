namespace CJPlus.FileTransceiver
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate void CbFileSendedProgress(string projectID, ulong total, ulong transfered);
}

