using CJBasic;
using CJBasic.Loggers;
using CJBasic.ObjectManagement.Managers;
using CJPlus;
using CJPlus.FileTransceiver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

internal class FileHandler : IFileTransferingEvents, IFileTransferingEventsHelper1
{
    private bool bool_0 = true;
    [CompilerGenerated]
    private static CbFileSendedProgress cbFileSendedProgress_1;
    [CompilerGenerated]
    private static CbFileSendedProgress cbFileSendedProgress_0; 
     [CompilerGenerated]
    private static CbGeneric<TransferingProject> cbGeneric_4;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject> cbGeneric_3;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject> cbGeneric_0;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject> cbGeneric_2;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject> cbGeneric_1;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject> cbGeneric_5;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject, FileTransDisrupttedType> cbGeneric_6;
    [CompilerGenerated]
    private static CbGeneric<TransferingProject> cbGeneric_7;
    private Interface2 class3_0 = new Class3();
    private IAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private int int_0 = 0x100000;
    private IActionType interface31_0 = null;
    private Interface40 interface40_0;
    private IStreamContractHelper interface9_0 = null;
    private IFilePackageHelper object_0 = null;
    private SafeDictionary<string, TransferingProject> safeDictionary_0 = new SafeDictionary<string, TransferingProject>();
    private SafeDictionary<string, IFileOutter> safeDictionary_1 = new SafeDictionary<string, IFileOutter>();
    private string string_0 = "";

    public event CbGeneric<TransferingProject> FileResumedTransStarted;

    public event CbGeneric<TransferingProject> FileTransCompleted;

    public event CbGeneric<TransferingProject, FileTransDisrupttedType> FileTransDisruptted;

    public event CbFileSendedProgress FileTransProgress;

    public event CbGeneric<TransferingProject> FileTransStarted;

    public FileHandler()
    {
        if (cbGeneric_4 == null)
        {
            cbGeneric_4 = new CbGeneric<TransferingProject>(FileHandler.smethod_0);
        }
        this.FileTransStarted += cbGeneric_4;
        if (cbGeneric_5 == null)
        {
            cbGeneric_5 = new CbGeneric<TransferingProject>(FileHandler.smethod_1);
        }
        this.FileResumedTransStarted += cbGeneric_5;
        if (cbFileSendedProgress_1 == null)
        {
            cbFileSendedProgress_1 = new CbFileSendedProgress(FileHandler.smethod_2);
        }
        this.FileTransProgress += cbFileSendedProgress_1;
        if (cbGeneric_6 == null)
        {
            cbGeneric_6 = new CbGeneric<TransferingProject, FileTransDisrupttedType>(FileHandler.smethod_3);
        }
        this.FileTransDisruptted += cbGeneric_6;
        if (cbGeneric_7 == null)
        {
            cbGeneric_7 = new CbGeneric<TransferingProject>(FileHandler.smethod_4);
        }
        this.FileTransCompleted += cbGeneric_7;
    }

    public void HnFdepcbbe(string string_1, ulong ulong_0, string string_2, ulong ulong_1)
    {
        TransferingProject project = this.imethod_2(string_1);
        if (project != null)
        {
            SendingFileParas paras = this.class3_0.imethod_0(project.AccepterID);
            int filePackageSize = paras.FilePackageSize;
            int sendingSpanInMSecs = paras.SendingSpanInMSecs;
            if (project.method_0() != null)
            {
                filePackageSize = project.method_0().FilePackageSize;
                sendingSpanInMSecs = project.method_0().SendingSpanInMSecs;
            }
            if (filePackageSize > (GlobalUtil.MaxLengthOfMessage - 100))
            {
                filePackageSize = GlobalUtil.MaxLengthOfMessage - 100;
            }
            IFileOutter interface2 = null;
            if (project.IsFolder)
            {
                interface2 = new DirectorySender(this.emptyAgileLogger_0, (IFilePackageHelper) this.object_0, project.OriginPath, project.AccepterID, string_2, ulong_0, ulong_1);
            }
            else if (project.OriginStream == null)
            {
                interface2 = new FileSender(this.emptyAgileLogger_0, (IFilePackageHelper) this.object_0, project.OriginPath, project.AccepterID, ulong_0);
            }
            else
            {
                interface2 = new Class22(this.emptyAgileLogger_0, (IFilePackageHelper) this.object_0, project.OriginPath, project.OriginStream, project.TotalSize, project.AccepterID);
            }
            interface2.imethod_9(filePackageSize);
            interface2.imethod_11(sendingSpanInMSecs);
            interface2.imethod_13(this.int_0);
            interface2.imethod_6(project.ProjectID);
            interface2.FileTransProgress += new CbFileSendedProgress(this.method_8);
            interface2.FileTransCompleted += new CbFileTransCompleted(this.method_9);
            interface2.FileTransDisruptted += new CbFileTransDisruptted(this.method_10);
            this.safeDictionary_1.Add(interface2.imethod_5(), interface2);
            if (ulong_0 == 0L)
            {
                this.FileTransStarted(project);
            }
            else
            {
                this.FileTransCompleted(project);
            }
            interface2.HnFdepcbbe(this.bool_0);
        }
    }

    public int imethod_0()
    {
        return this.int_0;
    }

    public void imethod_1(int int_1)
    {
        this.int_0 = int_1;
    }

    public void imethod_10(string string_1)
    {
        foreach (string str in this.imethod_4(string_1))
        {
            this.imethod_7(str, FileTransDisrupttedType.DestOffline, null);
        }
    }

    public void imethod_11(string string_1)
    {
        foreach (string str in this.imethod_4(string_1))
        {
            this.imethod_7(str, FileTransDisrupttedType.ReliableP2PChannelClosed, null);
        }
    }

    public void imethod_12(string string_1)
    {
        DirectorySender class2 = this.safeDictionary_1.Get(string_1) as DirectorySender;
        if (class2 != null)
        {
            class2.method_5();
        }
    }

    public void imethod_13()
    {
        foreach (IFileOutter interface2 in this.safeDictionary_1.GetAll())
        {
            interface2.imethod_2();
        }
    }

    public TransferingProject imethod_2(string string_1)
    {
        return this.safeDictionary_0.Get(string_1);
    }

    public FileTransferingProgress imethod_3(string string_1)
    {
        IFileOutter interface2 = this.safeDictionary_1.Get(string_1);
        if (interface2 == null)
        {
            return null;
        }
        return interface2.imethod_1();
    }

    public List<string> imethod_4(string string_1)
    {
        if (string_1 == null)
        {
            return this.safeDictionary_1.GetKeyList();
        }
        List<string> list2 = new List<string>();
        foreach (TransferingProject project in this.safeDictionary_0.GetAll())
        {
            if (project.AccepterID == string_1)
            {
                list2.Add(project.ProjectID);
            }
        }
        return list2;
    }

    public void imethod_5(string string_1, string string_2, bool bool_1, ulong ulong_0, DateTime dateTime_0, string string_3, SendingFileParas sendingFileParas_0, string string_4)
    {
        TransferingProject project = new TransferingProject(string_3, bool_1, string_2, dateTime_0, string_1, this.string_0, ulong_0, true, string_4);
        project.method_1(sendingFileParas_0);
        this.safeDictionary_0.Add(project.ProjectID, project);
    }

    public void imethod_6(string string_1, Stream stream_0, string string_2, ulong ulong_0, string string_3, SendingFileParas sendingFileParas_0, string string_4)
    {
        TransferingProject project = new TransferingProject(string_3, stream_0, string_2, string_1, this.string_0, ulong_0, true, string_4);
        project.method_1(sendingFileParas_0);
        this.safeDictionary_0.Add(project.ProjectID, project);
    }

    public void imethod_7(string string_1, FileTransDisrupttedType fileTransDisrupttedType_0, string string_2)
    {
        IFileOutter interface2 = this.safeDictionary_1.Get(string_1);
        if (interface2 != null)
        {
            interface2.imethod_0(fileTransDisrupttedType_0, string_2);
        }
        else
        {
            TransferingProject project = this.safeDictionary_0.Get(string_1);
            if (project != null)
            {
                this.safeDictionary_0.Remove(string_1);
                project.method_2(string_2);
                this.FileTransDisruptted(project, fileTransDisrupttedType_0);
            }
        }
    }

    public void imethod_8(string string_1, out int int_1, out int int_2)
    {
        int_1 = 0;
        int_2 = 0;
        IFileOutter interface2 = this.safeDictionary_1.Get(string_1);
        if (interface2 != null)
        {
            int_1 = interface2.imethod_10();
            int_2 = interface2.imethod_8();
        }
    }

    public void imethod_9()
    {
        foreach (string str in this.safeDictionary_0.GetKeyList())
        {
            this.imethod_7(str, FileTransDisrupttedType.SelfOffline, null);
        }
    }

    public void Initialize(string string_1, int int_1)
    {
        this.string_0 = string_1;
        if (this.method_5())
        {
            this.object_0 = new FilePackageHelper(this.string_0, int_1, this.interface31_0, this.interface9_0);
        }
        else
        {
            this.object_0 = new FilePackageHelper2("_0", int_1, this.interface40_0, this.interface9_0);
        }
    }

    public void method_0(IAgileLogger iagileLogger_0)
    {
        this.emptyAgileLogger_0 = iagileLogger_0 ?? new EmptyAgileLogger();
    }

    public void method_1(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    private void method_10(string string_1, FileTransDisrupttedType fileTransDisrupttedType_0, string string_2)
    {
        TransferingProject project = this.imethod_2(string_1);
        if (project != null)
        {
            project.method_2(string_2);
            this.safeDictionary_1.Remove(string_1);
            this.safeDictionary_0.Remove(string_1);
            this.FileTransDisruptted(project, fileTransDisrupttedType_0);
        }
    }

    public void method_2(Interface40 interface40_1)
    {
        this.interface40_0 = interface40_1;
    }

    public void method_3(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void method_4(Interface2 interface2_0)
    {
        this.class3_0 = interface2_0 ?? new Class3();
    }

    public bool method_5()
    {
        return (this.interface40_0 == null);
    }

    public bool method_6()
    {
        return this.bool_0;
    }

    public void method_7(bool bool_1)
    {
        this.bool_0 = bool_1;
    }

    private void method_8(string string_1, ulong ulong_0, ulong ulong_1)
    {
        this.FileTransProgress(string_1, ulong_0, ulong_1);
    }

    private void method_9(string string_1)
    {
        TransferingProject project = this.imethod_2(string_1);
        if (project != null)
        {
            this.safeDictionary_1.Remove(string_1);
            this.safeDictionary_0.Remove(string_1);
            this.FileTransCompleted(project);
        }
    }

    [CompilerGenerated]
    private static void smethod_0(object object_1)
    {
    }

    [CompilerGenerated]
    private static void smethod_1(object object_1)
    {
    }

    [CompilerGenerated]
    private static void smethod_2(object object_1, ulong ulong_0, ulong ulong_1)
    {
    }

    [CompilerGenerated]
    private static void smethod_3(object object_1, FileTransDisrupttedType fileTransDisrupttedType_0)
    {
    }

    [CompilerGenerated]
    private static void smethod_4(object object_1)
    {
    }
}

