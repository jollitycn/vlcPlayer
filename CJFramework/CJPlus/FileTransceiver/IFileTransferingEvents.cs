namespace CJPlus.FileTransceiver
{
    using CJBasic;
    using System;

    public interface IFileTransferingEvents
    {
        event CbGeneric<TransferingProject> FileResumedTransStarted;

        event CbGeneric<TransferingProject> FileTransCompleted;

        event CbGeneric<TransferingProject, FileTransDisrupttedType> FileTransDisruptted;

        event CbFileSendedProgress FileTransProgress;

        event CbGeneric<TransferingProject> FileTransStarted;
    }
}

