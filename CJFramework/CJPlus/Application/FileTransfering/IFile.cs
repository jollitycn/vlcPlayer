namespace CJPlus.Application.FileTransfering
{
    using CJBasic;
    using CJPlus.FileTransceiver;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;

    public interface IFile
    {
        event CbFileRequestReceived FileRequestReceived;

        event CbGeneric<TransferingProject, bool> FileResponseReceived;

        void BeginReceiveFile(string projectID, Stream saveStream);
        void BeginReceiveFile(string projectID, string savePath);
        void BeginReceiveFile(string projectID, string savePath, bool allowResume);
        void BeginSendFile(string accepterID, string fileOrDirPath, string comment, out string projectID);
        void BeginSendFile(string accepterID, string fileOrDirPath, string comment, SendingFileParas paras, out string projectID);
        void BeginSendFile(string accepterID, Stream stream, string projectName, ulong size, string comment, SendingFileParas paras, out string projectID);
        void CancelAllTransfering();
        void CancelTransfering(string projectID);
        void CancelTransfering(string projectID, string cause);
        void CancelTransferingAbout(string destUserID);
        List<string> GetTransferingAbout(string destUserID);
        FileTransferingProgress GetTransferingProgress(string projectID);
        TransferingProject GetTransferingProject(string projectID);
        void RejectFile(string projectID);
        void RejectFile(string projectID, string cause);

        IFileTransferingEvents FileReceivingEvents { get; }

        IFileTransferingEvents FileSendingEvents { get; }

        int TTL4ResumedFileItem { get; set; }
    }
}

