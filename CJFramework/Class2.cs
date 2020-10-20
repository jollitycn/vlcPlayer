using CJBasic;
using CJBasic.Loggers;
using CJBasic.ObjectManagement.Managers;
using CJPlus.FileTransceiver;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

internal class FileTransfering : IFileTransferingEvents, IFileTransferingEventsHelper, IDisposable
{
    [CompilerGenerated]
    private static CbFileSendedProgress cbFileSendedProgress_1;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject> cbGeneric_5;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject> cbGeneric_6;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject> cbGeneric_7;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject, FileTransDisrupttedType> cbGeneric_8;
    private ResumedProjectItemOutter class93_0 = new ResumedProjectItemOutter();
    private IObjectManager<string, IFileTransHelper> iobjectManager_0 = new SafeDictionary<string, IFileTransHelper>();
    private IObjectManager<string, TransferingProject> iobjectManager_1 = new SafeDictionary<string, TransferingProject>();
    private IObjectManager<string, TransferingProject> iobjectManager_2 = new SafeDictionary<string, TransferingProject>();
    private IAgileLogger RnOiFeTpq = new EmptyAgileLogger();
    public static string string_0 = ".tmpe$";

    public event CbGeneric<TransferingProject> FileResumedTransStarted;

    public event CbGeneric<TransferingProject> FileTransCompleted;

    public event CbGeneric<TransferingProject, FileTransDisrupttedType> FileTransDisruptted;

    public event CbFileSendedProgress FileTransProgress;

    public event CbGeneric<TransferingProject> FileTransStarted;

    public event CbGeneric<string> SingleFileRevFinished;

    public FileTransfering()
    {
        if (cbGeneric_5 == null)
        {
            cbGeneric_5 = new CbGeneric<TransferingProject>(FileTransfering.smethod_0);
        }
        this.FileTransStarted += cbGeneric_5;
        if (cbGeneric_6 == null)
        {
            cbGeneric_6 = new CbGeneric<TransferingProject>(FileTransfering.smethod_1);
        }
        this.FileResumedTransStarted += cbGeneric_6;
        if (cbGeneric_7 == null)
        {
            cbGeneric_7 = new CbGeneric<TransferingProject>(FileTransfering.smethod_2);
        }
        this.FileTransCompleted += cbGeneric_7;
        if (cbGeneric_8 == null)
        {
            cbGeneric_8 = new CbGeneric<TransferingProject, FileTransDisrupttedType>(FileTransfering.smethod_3);
        }
        this.FileTransDisruptted += cbGeneric_8;
        if (cbFileSendedProgress_1 == null)
        {
            cbFileSendedProgress_1 = new CbFileSendedProgress(FileTransfering.smethod_4);
        }
        this.FileTransProgress += cbFileSendedProgress_1;
    }

    public void Dispose()
    {
        this.class93_0.Dispose();
    }

    public ResumedProjectItem imethod_0(TransferingProject transferingProject_0)
    {
        return this.class93_0.GetResumedProjectItem(transferingProject_0);
    }

    public void imethod_1(TransferingProject transferingProject_0)
    {
        this.iobjectManager_2.Add(transferingProject_0.ProjectID, transferingProject_0);
    }

    public TransferingProject GetTransferingProject(string string_1)
    {
        TransferingProject project = this.iobjectManager_1.Get(string_1);
        if (project == null)
        {
            project = this.iobjectManager_2.Get(string_1);
        }
        return project;
    }

    public FileTransferingProgress GetFileTransferingProgress(string string_1)
    {
        IFileTransHelper interface2 = this.iobjectManager_0.Get(string_1);
        if (interface2 == null)
        {
            return null;
        }
        return interface2.imethod_2();
    }

    public List<string> GetFileTransHelper(string string_1)
    {
        if (string_1 == null)
        {
            List<string> keyList = this.iobjectManager_0.GetKeyList();
            keyList.AddRange(this.iobjectManager_2.GetKeyList());
            return keyList;
        }
        List<string> list3 = new List<string>();
        foreach (TransferingProject project in this.iobjectManager_1.GetAll())
        {
            if (project.SenderID == string_1)
            {
                list3.Add(project.ProjectID);
            }
        }
        foreach (TransferingProject project in this.iobjectManager_2.GetAll())
        {
            if (project.SenderID == string_1)
            {
                list3.Add(project.ProjectID);
            }
        }
        return list3;
    }

    public void imethod_13()
    {
        foreach (IFileTransHelper interface2 in this.iobjectManager_0.GetAll())
        {
            interface2.imethod_3();
        }
        this.class93_0.SetResumedProjectItem();
    }

    public void imethod_2(string string_1)
    {
        TransferingProject project = this.iobjectManager_2.Get(string_1);
        if (project != null)
        {
            this.iobjectManager_2.Remove(string_1);
            this.FileTransDisruptted(project, FileTransDisrupttedType.RejectAccepting);
        }
    }

    public TransferingProject imethod_3(string string_1)
    {
        return this.iobjectManager_2.Get(string_1);
    }

    public void imethod_4(TransferingProject transferingProject_0, ResumedProjectItem resumedProjectItem_0, bool bool_0)
    {
        this.iobjectManager_2.Remove(transferingProject_0.ProjectID);
        if (!this.iobjectManager_1.Contains(transferingProject_0.ProjectID))
        {
            this.iobjectManager_1.Add(transferingProject_0.ProjectID, transferingProject_0);
            bool flag = bool_0 && (resumedProjectItem_0 != null);
            IFileTransHelper interface2 = null;
            if (transferingProject_0.IsFolder)
            {
                DirectoryReceiver class2 = flag ? new DirectoryReceiver(this.RnOiFeTpq, transferingProject_0.ProjectID, string_0, resumedProjectItem_0) : new DirectoryReceiver(this.RnOiFeTpq, transferingProject_0.ProjectID, transferingProject_0.LocalSavePath, transferingProject_0.TotalSize, string_0);
                class2.FileTransReceived += new CbGeneric<string>(this.OnSingleFileRevFinished);
                interface2 = class2;
            }
            else if (transferingProject_0.LocalSaveStream == null)
            {
                interface2 = flag ? new FileReceiver(this.RnOiFeTpq, transferingProject_0.ProjectID, resumedProjectItem_0) : new FileReceiver(this.RnOiFeTpq, transferingProject_0.ProjectID, transferingProject_0.LocalSavePath, transferingProject_0.TotalSize, string_0);
            }
            else
            {
                interface2 = new Class124(this.RnOiFeTpq, transferingProject_0.ProjectID, transferingProject_0.LocalSaveStream, transferingProject_0.TotalSize);
            }
            interface2.FileTransCompleted += new CbGeneric<string>(this.OnFileTransCompleted);
            interface2.FileTransDisruptted += new CbFileTransDisruptted(this.method_3);
            interface2.FileTransProgress += new CbFileSendedProgress(this.OnFileTransProgress);
            this.iobjectManager_0.Add(transferingProject_0.ProjectID, interface2);
            this.class93_0.RemoveResumedProjectItem(resumedProjectItem_0, !flag);
            if (flag)
            {
                this.FileTransStarted(transferingProject_0);
            }
            else
            {
                this.FileTransCompleted(transferingProject_0);
            }
        }
    }

    public void imethod_5(string string_1, FileTransDisrupttedType fileTransDisrupttedType_0, string string_2)
    {
        if (this.iobjectManager_2.Contains(string_1))
        {
            TransferingProject project = this.iobjectManager_2.Get(string_1);
            project.method_2(string_2);
            this.iobjectManager_2.Remove(string_1);
            this.FileTransDisruptted(project, fileTransDisrupttedType_0);
}
        else
        {
            IFileTransHelper interface2 = this.iobjectManager_0.Get(string_1);
            if (interface2 == null)
            {
                if (this.iobjectManager_1.Contains(string_1))
                {
                    this.iobjectManager_1.Remove(string_1);
                }
            }
            else
            {
                interface2.imethod_1(fileTransDisrupttedType_0, false, string_2);
            }
        }
    }

    public void imethod_6()
    {
        foreach (string str in this.iobjectManager_0.GetKeyList())
        {
            this.imethod_5(str, FileTransDisrupttedType.SelfOffline, null);
        }
    }

    public void imethod_7(string string_1)
    {
        foreach (string str in this.GetFileTransHelper(string_1))
        {
            this.imethod_5(str, FileTransDisrupttedType.DestOffline, null);
        }
    }

    public void imethod_8(string string_1)
    {
        foreach (string str in this.GetFileTransHelper(string_1))
        {
            this.imethod_5(str, FileTransDisrupttedType.ReliableP2PChannelClosed, null);
        }
    }

    public string imethod_9(string string_1)
    {
        IFileTransHelper interface2 = this.iobjectManager_0.Get(string_1);
        if (interface2 == null)
        {
            return null;
        }
        return interface2.imethod_5();
    }

    public void method_0(IAgileLogger iagileLogger_0)
    {
        this.RnOiFeTpq = iagileLogger_0 ?? new EmptyAgileLogger();
    }

    private void OnSingleFileRevFinished(string string_1)
    {
        if (this.SingleFileRevFinished != null)
        {
            this.SingleFileRevFinished(string_1);
        }
    }
    private void OnFileTransCompleted(string string_1)
    {
        TransferingProject project = this.GetTransferingProject(string_1);
        this.iobjectManager_1.Remove(string_1);
        this.iobjectManager_0.Remove(string_1);
        this.FileTransCompleted(project);
    }


    private void method_3(string string_1, FileTransDisrupttedType fileTransDisrupttedType_0, string string_2)
    {
        TransferingProject project = this.GetTransferingProject(string_1);
        project.method_2(string_2);
        IFileTransHelper interface2 = this.iobjectManager_0.Get(string_1);
        ResumedProjectItem item = null;
        if (interface2.imethod_4())
        {
            DirectoryReceiver class2 = (DirectoryReceiver) interface2;
            item = new ResumedProjectItem(project.SenderID, project.OriginPath, project.TotalSize, project.OriginLastUpdateTime, interface2.imethod_8(), interface2.imethod_7(), interface2.imethod_9(), class2.method_0(), class2.method_1(), class2.method_2());
        }
        else
        {
            item = new ResumedProjectItem(project.SenderID, project.OriginPath, project.TotalSize, project.OriginLastUpdateTime, interface2.imethod_8(), interface2.imethod_7(), interface2.imethod_9());
        }
        this.class93_0.UpdateResumedProjectItem(item);
        this.iobjectManager_1.Remove(string_1);
        this.iobjectManager_0.Remove(string_1);
        this.FileTransDisruptted(project, fileTransDisrupttedType_0);
    }

    private void OnFileTransProgress(string string_1, ulong ulong_0, ulong ulong_1)
    {
        this.FileTransProgress(string_1, ulong_0, ulong_1);
    }

    public void ocqOcyhOmB(string string_1, FilePackage filePackage_0)
    {
        IFileTransHelper interface2 = this.iobjectManager_0.Get(filePackage_0.ProjectID);
        if (interface2 != null)
        {
            interface2.FileReceive(filePackage_0);
        }
    }

    [CompilerGenerated]
    private static void smethod_0(object object_0)
    {
    }

    [CompilerGenerated]
    private static void smethod_1(object object_0)
    {
    }

    [CompilerGenerated]
    private static void smethod_2(object object_0)
    {
    }

    [CompilerGenerated]
    private static void smethod_3(object object_0, FileTransDisrupttedType fileTransDisrupttedType_0)
    {
    }

    [CompilerGenerated]
    private static void smethod_4(object object_0, ulong ulong_0, ulong ulong_1)
    {
    }

    public int TTL4ResumedFileItem
    {
        get
        {
            return this.class93_0.TTL4ResumedFileItem;
        }
        set
        {
            this.class93_0.TTL4ResumedFileItem = value;
        }
    }
}

