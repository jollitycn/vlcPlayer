using CJBasic.Helpers;
using CJPlus.Application.FileTransfering;
using CJPlus.FileTransceiver;
using System;

internal abstract class FileMessage
{
    private FileTransfer class26_0;
    protected IFileTransferingEventsHelper interface1_0 = null;
    protected IFileTransferingEventsHelper1 interface7_0 = null;
    protected IStreamContractHelper interface9_0 = null;
    protected FileMessageTypeRoom object_0;

    protected FileMessage()
    {
    }

    public bool CanProcess(int int_0)
    {
        return this.object_0.Contains(int_0);
    }

    public void method_0(FileMessageTypeRoom fileMessageTypeRoom_0)
    {
        this.object_0 = fileMessageTypeRoom_0;
    }

    public void method_1(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void method_2(IFileTransferingEventsHelper interface1_1)
    {
        this.interface1_0 = interface1_1;
    }

    public void method_3(IFileTransferingEventsHelper1 interface7_1)
    {
        this.interface7_0 = interface7_1;
    }

    public void method_4(FileTransfer class26_1)
    {
        this.class26_0 = class26_1;
    }

    protected IMessageHandler method_5(IMessageHandler interface37_0)
    {
        TransferingProject project;
        CancelFileContract contract2;
        FileTransDisrupttedType type;
        if (interface37_0.Header.MessageType == this.object_0.BeginSendFile)
        {
            BeginSendFileContract contract3 = this.interface9_0.imethod_1<BeginSendFileContract>(interface37_0);
            project = new TransferingProject(contract3.ProjectID, contract3.IsFolder, contract3.OriginPath, contract3.LastUpdateTime, interface37_0.Header.DestUserID, interface37_0.Header.UserID, contract3.TotalSize, false, contract3.Comment);
            ResumedProjectItem item = this.interface1_0.imethod_0(project);
            this.interface1_0.imethod_1(project);
            this.class26_0.method_9(contract3.ProjectID, interface37_0.Header.UserID, FileHelper.GetFileNameNoPath(contract3.OriginPath), contract3.TotalSize, item, contract3.Comment);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.RejectOrAcceptFile)
        {
            RejectOrAcceptFileContract contract = this.interface9_0.imethod_1<RejectOrAcceptFileContract>(interface37_0);
            project = this.interface7_0.imethod_2(contract.ProjectID);
            if (project != null)
            {
                project.method_2(contract.RejectCause);
                this.class26_0.method_7(project, contract.Agree);
                if (contract.Agree)
                {
                    project.TimeStarted = DateTime.Now;
                    project.IsTransfering = true;
                    this.interface7_0.HnFdepcbbe(contract.ProjectID, contract.ReceivedCount, contract.DisrupttedFileRelativePath, contract.DisrupttedFileReceivedCount);
                }
                else
                {
                    this.interface7_0.imethod_7(contract.ProjectID, FileTransDisrupttedType.RejectAccepting, null);
                }
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.FilePackageData)
        {
            FilePackage package = this.interface9_0.imethod_1<FilePackage>(interface37_0);
            this.interface1_0.ocqOcyhOmB(interface37_0.Header.UserID, package);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.CancelFileSending)
        {
            contract2 = this.interface9_0.imethod_1<CancelFileContract>(interface37_0);
            type = contract2.InnerError ? FileTransDisrupttedType.DestInnerError : FileTransDisrupttedType.DestCancel;
            this.interface1_0.imethod_5(contract2.ProjectID, type, contract2.Cause);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.CancelFileReceiving)
        {
            contract2 = this.interface9_0.imethod_1<CancelFileContract>(interface37_0);
            type = contract2.InnerError ? FileTransDisrupttedType.DestInnerError : FileTransDisrupttedType.DestCancel;
            this.interface7_0.imethod_7(contract2.ProjectID, type, contract2.Cause);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.SingleFileRevFinishedNotify)
        {
            SingleFileNotifyContract contract4 = this.interface9_0.imethod_1<SingleFileNotifyContract>(interface37_0);
            this.interface7_0.imethod_12(contract4.ProjectID);
            return null;
        }
        return null;
    }
}

