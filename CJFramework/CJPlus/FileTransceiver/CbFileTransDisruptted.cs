namespace CJPlus.FileTransceiver
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate void CbFileTransDisruptted(string projectID, FileTransDisrupttedType disrupttedType, string cause);
}

