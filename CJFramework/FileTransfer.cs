using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJBasic.Threading.Engines;
using CJPlus.Application.FileTransfering;
using CJPlus.FileTransceiver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

internal abstract class FileTransfer : IDisposable, IEngineActor, IFile
{
    private AgileCycleEngine agileCycleEngine_0;
    private IAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private IFileTransferingEventsHelper1 fblKqUhvkd = null;
    internal FileMessageTypeRoom fileMessageTypeRoom_0;
    private int int_0 = 20;
    internal IStreamContractHelper interface9_0 = null;
    private IFileTransferingEventsHelper object_0 = null;
    internal string string_0;

    public event CbFileRequestReceived FileRequestReceived;

    public event CbGeneric<TransferingProject, bool> FileResponseReceived;

    protected FileTransfer()
    {
    }

    public void BeginReceiveFile(string projectID, Stream saveStream)
    {
        if (saveStream == null)
        {
            throw new Exception("The value of saveStream can't be null !");
        }
        TransferingProject project = this.object_0.imethod_3(projectID);
        if (project != null)
        {
            project.LocalSaveStream = saveStream;
            project.TimeStarted = DateTime.Now;
            project.IsTransfering = true;
            RejectOrAcceptFileContract body = new RejectOrAcceptFileContract(projectID, true, 0L, null);
            this.object_0.imethod_4(project, null, false);
            IMessageHandler interface2 = this.interface9_0.imethod_4<RejectOrAcceptFileContract>(this.string_0, this.fileMessageTypeRoom_0.RejectOrAcceptFile, body, project.SenderID);
            this.SendMessage(interface2, false);
        }
    }

    public void BeginReceiveFile(string projectID, string savePath)
    {
        this.BeginReceiveFile(projectID, savePath, true);
    }

    public void BeginReceiveFile(string projectID, string savePath, bool allowResume)
    {
        if (savePath == null)
        {
            throw new Exception("The value of saveFilePath can't be null !");
        }
        TransferingProject project = this.object_0.imethod_3(projectID);
        if (project != null)
        {
            project.LocalSavePath = savePath;
            project.TimeStarted = DateTime.Now;
            project.IsTransfering = true;
            ResumedProjectItem item = this.object_0.imethod_0(project);
            RejectOrAcceptFileContract body = null;
            if (project.IsFolder)
            {
                if (!((item != null) && allowResume))
                {
                    body = new RejectOrAcceptFileContract(projectID, true, 0L, null);
                }
                else
                {
                    body = new RejectOrAcceptFileContract(projectID, true, item.ReceivedCount, null, item.DisrupttedFileRelativePath, item.DisrupttedFileSize, item.DisrupttedFileReceivedCount);
                }
            }
            else
            {
                ulong num = (!allowResume || (item == null)) ? ((ulong) 0L) : item.ReceivedCount;
                body = new RejectOrAcceptFileContract(projectID, true, num, null);
            }
            this.object_0.imethod_4(project, item, allowResume);
            IMessageHandler interface2 = this.interface9_0.imethod_4<RejectOrAcceptFileContract>(this.string_0, this.fileMessageTypeRoom_0.RejectOrAcceptFile, body, project.SenderID);
            this.SendMessage(interface2, false);
        }
    }

    public void BeginSendFile(string accepterID, string fileOrDirPath, string comment, out string projectID)
    {
        this.BeginSendFile(accepterID, fileOrDirPath, comment, null, out projectID);
    }

    public void BeginSendFile(string accepterID, string fileOrDirPath, string comment, SendingFileParas paras, out string projectID)
    {
        bool flag;
        if (accepterID == null)
        {
            accepterID = "_0";
        }
        if (!(flag = Directory.Exists(fileOrDirPath)))
        {
            FileStream stream = File.Open(fileOrDirPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            stream.Close();
            stream.Dispose();
        }
        projectID = Class23.smethod_0(this.string_0);
        FileSystemInfo info = null;
        ulong directorySize = 0L;
        if (flag)
        {
            info = new DirectoryInfo(fileOrDirPath);
            directorySize = FileHelper.GetDirectorySize(fileOrDirPath);
        }
        else
        {
            info = new FileInfo(fileOrDirPath);
            directorySize = (ulong) ((FileInfo) info).Length;
        }
        string fullName = info.FullName;
        this.fblKqUhvkd.imethod_5(accepterID, fullName, flag, directorySize, info.LastWriteTime, projectID, paras, comment);
        BeginSendFileContract body = new BeginSendFileContract(fullName, flag, directorySize, info.LastWriteTime, comment, projectID);
        IMessageHandler interface2 = this.interface9_0.imethod_4<BeginSendFileContract>(this.string_0, this.fileMessageTypeRoom_0.BeginSendFile, body, accepterID);
        this.SendMessage(interface2, false);
    }

    public void BeginSendFile(string accepterID, Stream stream, string projectName, ulong size, string comment, SendingFileParas paras, out string projectID)
    {
        if (accepterID == null)
        {
            accepterID = "_0";
        }
        projectID = Class23.smethod_0(this.string_0);
        this.fblKqUhvkd.imethod_6(accepterID, stream, projectName, size, projectID, paras, comment);
        BeginSendFileContract body = new BeginSendFileContract(projectName, false, size, DateTime.Now, comment, projectID);
        IMessageHandler interface2 = this.interface9_0.imethod_4<BeginSendFileContract>(this.string_0, this.fileMessageTypeRoom_0.BeginSendFile, body, accepterID);
        this.SendMessage(interface2, false);
    }

    public void CancelAllTransfering()
    {
        this.CancelTransferingAbout(null);
    }

    public void CancelTransfering(string projectID)
    {
        this.CancelTransfering(projectID, null);
    }

    public void CancelTransfering(string projectID, string cause)
    {
        TransferingProject project = this.fblKqUhvkd.imethod_2(projectID);
        if (project == null)
        {
            project = this.object_0.GetTransferingProject(projectID);
        }
        if (project != null)
        {
            CancelFileContract contract;
            if (project.IsSender)
            {
                this.fblKqUhvkd.imethod_7(projectID, FileTransDisrupttedType.ActiveCancel, cause);
                contract = new CancelFileContract(projectID, false, cause);
                IMessageHandler interface2 = this.interface9_0.imethod_4<CancelFileContract>(this.string_0, this.fileMessageTypeRoom_0.CancelFileSending, contract, project.AccepterID);
                this.SendMessage(interface2, false);
            }
            else if (!project.IsTransfering)
            {
                this.RejectFile(project.ProjectID);
            }
            else
            {
                contract = new CancelFileContract(projectID, false, cause);
                IMessageHandler interface3 = this.interface9_0.imethod_4<CancelFileContract>(this.string_0, this.fileMessageTypeRoom_0.CancelFileReceiving, contract, project.SenderID);
                this.SendMessage(interface3, false);
                this.object_0.imethod_5(projectID, FileTransDisrupttedType.ActiveCancel, cause);
            }
        }
    }

    public void CancelTransferingAbout(string destUserID)
    {
        if (destUserID == null)
        {
            destUserID = "_0";
        }
        foreach (string str in this.object_0.GetFileTransHelper(destUserID))
        {
            this.CancelTransfering(str);
        }
        foreach (string str in this.fblKqUhvkd.imethod_4(destUserID))
        {
            this.CancelTransfering(str);
        }
    }

    public virtual void Dispose()
    {
        if (this.agileCycleEngine_0 != null)
        {
            this.agileCycleEngine_0.Stop();
        }
    }

    public bool EngineAction()
    {
        try
        {
            this.fblKqUhvkd.imethod_13();
            this.object_0.imethod_13();
        }
        catch
        {
        }
        return true;
    }

    public List<string> GetTransferingAbout(string destUserID)
    {
        if (destUserID == null)
        {
            destUserID = "_0";
        }
        List<string> list = this.object_0.GetFileTransHelper(destUserID);
        foreach (string str in this.fblKqUhvkd.imethod_4(destUserID))
        {
            list.Add(str);
        }
        return list;
    }

    public FileTransferingProgress GetTransferingProgress(string projectID)
    {
        FileTransferingProgress progress = this.fblKqUhvkd.imethod_3(projectID);
        if (progress == null)
        {
            progress = this.object_0.GetFileTransferingProgress(projectID);
        }
        return progress;
    }

    public TransferingProject GetTransferingProject(string projectID)
    {
        TransferingProject project = this.fblKqUhvkd.imethod_2(projectID);
        if (project == null)
        {
            project = this.object_0.GetTransferingProject(projectID);
        }
        return project;
    }

    public void method_0(IAgileLogger iagileLogger_0)
    {
        this.emptyAgileLogger_0 = iagileLogger_0 ?? new EmptyAgileLogger();
    }

    public int method_1()
    {
        return this.int_0;
    }

    private void SpringFileRequestReceived(string string_1, string string_2, string string_3, ulong ulong_0, ResumedProjectItem resumedProjectItem_0, string string_4)
    {
        try
        {
            if (this.FileRequestReceived != null)
            {
                this.FileRequestReceived(string_1, string_2, string_3, ulong_0, resumedProjectItem_0, string_4);
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.Application.FileTransfering.BaseFileController.SpringFileRequestReceived", ErrorLevel.Standard);
        }
    }

    public void method_11(IFileTransferingEventsHelper1 interface7_0)
    {
        this.fblKqUhvkd = interface7_0;
    }

    public void method_12(IFileTransferingEventsHelper interface1_0)
    {
        this.object_0 = interface1_0;
    }

    public void method_13(FileMessageTypeRoom fileMessageTypeRoom_1)
    {
        this.fileMessageTypeRoom_0 = fileMessageTypeRoom_1;
    }

    public void method_14(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void method_2(int int_1)
    {
        this.int_0 = int_1;
    }

    public void method_3(string string_1)
    {
        this.string_0 = string_1;
        this.object_0.FileTransDisruptted += new CbGeneric<TransferingProject, FileTransDisrupttedType>(this.HandleMessage);
        this.fblKqUhvkd.FileTransDisruptted += new CbGeneric<TransferingProject, FileTransDisrupttedType>(this.method_5);
        this.object_0.SingleFileRevFinished += new CbGeneric<string>(this.SingleFileNotifyContract);
        if (this.int_0 > 0)
        {
            this.agileCycleEngine_0 = new AgileCycleEngine(this);
            this.agileCycleEngine_0.DetectSpanInSecs = 20;
            this.agileCycleEngine_0.Start();
        }
    }

    private void SingleFileNotifyContract(string string_1)
    {
        TransferingProject project = this.object_0.GetTransferingProject(string_1);
        if (project != null)
        {
            SingleFileNotifyContract body = new SingleFileNotifyContract(string_1);
            IMessageHandler interface2 = this.interface9_0.imethod_4<SingleFileNotifyContract>(this.string_0, this.fileMessageTypeRoom_0.SingleFileRevFinishedNotify, body, project.SenderID);
            this.SendMessage(interface2, false);
        }
    }

    private void method_5(TransferingProject transferingProject_0, FileTransDisrupttedType fileTransDisrupttedType_0)
    {
        CancelFileContract contract;
        IMessageHandler interface2;
        if (fileTransDisrupttedType_0 == FileTransDisrupttedType.InnerError)
        {
            contract = new CancelFileContract(transferingProject_0.ProjectID, true, transferingProject_0.FileTransDisrupttedCause);
            interface2 = this.interface9_0.imethod_4<CancelFileContract>(this.string_0, this.fileMessageTypeRoom_0.CancelFileSending, contract, transferingProject_0.AccepterID);
            this.SendMessage(interface2, false);
        }
        else if (fileTransDisrupttedType_0 == FileTransDisrupttedType.ReliableP2PChannelClosed)
        {
            contract = new CancelFileContract(transferingProject_0.ProjectID, false, "ReliableP2PChannelClosed");
            interface2 = this.interface9_0.imethod_4<CancelFileContract>(this.string_0, this.fileMessageTypeRoom_0.CancelFileSending, contract, transferingProject_0.AccepterID);
            this.SendMessage(interface2, false);
        }
        else if (fileTransDisrupttedType_0 == FileTransDisrupttedType.NetworkSpeedSlow)
        {
            contract = new CancelFileContract(transferingProject_0.ProjectID, false, "NetworkSpeedSlow");
            interface2 = this.interface9_0.imethod_4<CancelFileContract>(this.string_0, this.fileMessageTypeRoom_0.CancelFileSending, contract, transferingProject_0.AccepterID);
            this.SendMessage(interface2, true);
        }
    }

    private void HandleMessage(TransferingProject transferingProject_0, FileTransDisrupttedType fileTransDisrupttedType_0)
    {
        CancelFileContract contract;
        IMessageHandler interface2;
        if (fileTransDisrupttedType_0 == FileTransDisrupttedType.InnerError)
        {
            contract = new CancelFileContract(transferingProject_0.ProjectID, true, transferingProject_0.FileTransDisrupttedCause);
            interface2 = this.interface9_0.imethod_4<CancelFileContract>(this.string_0, this.fileMessageTypeRoom_0.CancelFileReceiving, contract, transferingProject_0.SenderID);
            this.SendMessage(interface2, false);
        }
        else if (fileTransDisrupttedType_0 == FileTransDisrupttedType.ReliableP2PChannelClosed)
        {
            contract = new CancelFileContract(transferingProject_0.ProjectID, false, "ReliableP2PChannelClosed");
            interface2 = this.interface9_0.imethod_4<CancelFileContract>(this.string_0, this.fileMessageTypeRoom_0.CancelFileReceiving, contract, transferingProject_0.SenderID);
            this.SendMessage(interface2, false);
        }
        else if (fileTransDisrupttedType_0 == FileTransDisrupttedType.NetworkSpeedSlow)
        {
            contract = new CancelFileContract(transferingProject_0.ProjectID, false, "NetworkSpeedSlow");
            interface2 = this.interface9_0.imethod_4<CancelFileContract>(this.string_0, this.fileMessageTypeRoom_0.CancelFileReceiving, contract, transferingProject_0.SenderID);
            this.SendMessage(interface2, true);
        }
    }

    internal void method_7(TransferingProject transferingProject_0, bool bool_0)
    {
        if (this.FileResponseReceived != null)
        {
            new CbGeneric<TransferingProject, bool>(this.SpringFileResponseReceived).BeginInvoke(transferingProject_0, bool_0, null, null);
        }
    }

    private void SpringFileResponseReceived(TransferingProject transferingProject_0, bool bool_0)
    {
        try
        {
            if (this.FileResponseReceived != null)
            {
                this.FileResponseReceived(transferingProject_0, bool_0);
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.Application.FileTransfering.BaseFileController.SpringFileResponseReceived", ErrorLevel.Standard);
        }
    }

    internal void method_9(string string_1, string string_2, string string_3, ulong ulong_0, ResumedProjectItem resumedProjectItem_0, string string_4)
    {
        if (this.FileRequestReceived != null)
        {
            new CbFileRequestReceived(this.SpringFileRequestReceived).BeginInvoke(string_1, string_2, string_3, ulong_0, resumedProjectItem_0, string_4, null, null);
        }
    }

    public void RejectFile(string projectID)
    {
        this.RejectFile(projectID, null);
    }

    public void RejectFile(string projectID, string cause)
    {
        TransferingProject project = this.object_0.imethod_3(projectID);
        if (project != null)
        {
            project.method_2(cause);
            this.object_0.imethod_2(projectID);
            IMessageHandler interface2 = this.interface9_0.imethod_4<RejectOrAcceptFileContract>(this.string_0, this.fileMessageTypeRoom_0.RejectOrAcceptFile, new RejectOrAcceptFileContract(projectID, false, 0L, cause), project.SenderID);
            this.SendMessage(interface2, false);
        }
    }

    protected abstract void SendMessage(IMessageHandler interface37_0, bool bool_0);

    public IFileTransferingEvents FileReceivingEvents
    {
        get
        {
            return (IFileTransferingEvents) this.object_0;
        }
    }

    public IFileTransferingEvents FileSendingEvents
    {
        get
        {
            return (IFileTransferingEvents) this.fblKqUhvkd;
        }
    }

    public int TTL4ResumedFileItem
    {
        get
        {
            return this.object_0.TTL4ResumedFileItem;
        }
        set
        {
            this.object_0.TTL4ResumedFileItem = value;
        }
    }
}

