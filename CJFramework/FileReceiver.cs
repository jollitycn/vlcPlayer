using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJPlus.FileTransceiver;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

internal class FileReceiver : IFileTransHelper
{
    private bool bool_0;
    private byte byte_0;
    [CompilerGenerated]
    private static CbFileSendedProgress cbFileSendedProgress_1;
    [CompilerGenerated]
    private static CbFileSendedProgress cbFileSendedProgress_2;
    [CompilerGenerated]
    private static CbFileSendedProgress cbFileSendedProgress_3;
    [CompilerGenerated]
    private static CbFileTransDisruptted cbFileTransDisruptted_1;
    [CompilerGenerated]
    private static CbFileTransDisruptted cbFileTransDisruptted_2;
    [CompilerGenerated]
    private static CbFileTransDisruptted cbFileTransDisruptted_3;
    [CompilerGenerated]
    private static CbGeneric<string> cbGeneric_1;
    [CompilerGenerated]
    private static CbGeneric<string> cbGeneric_2;
    [CompilerGenerated]
    private static CbGeneric<string> cbGeneric_3;
    private EventSafeTrigger diYatLwGC;
    private EmptyAgileLogger emptyAgileLogger_0;
    private FilePackage[] filePackage_0;
    private FileStream fileStream_0;
    private string HtwoUmmJj;
    private int int_0;
    private int int_1;
    private int object_0;
    private string string_0;
    private string string_1;
    private string string_2;
    private ulong ulong_0;
    private ulong ulong_1;

    public event CbGeneric<string> FileTransCompleted;

    public event CbFileTransDisruptted FileTransDisruptted;

    public event CbFileSendedProgress FileTransProgress;

    public FileReceiver(IAgileLogger iagileLogger_0, string string_3, ResumedProjectItem resumedProjectItem_0)
    {
        this.diYatLwGC = new EventSafeTrigger(new EmptyAgileLogger(), "XrZokLIgmVlcsHl3C7.nxZXDMlUfKsyJYxeVn");
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.ulong_0 = 0L;
        this.HtwoUmmJj = "";
        this.object_0 = 0;
        this.int_0 = 0;
        this.byte_0 = 0;
        this.filePackage_0 = new FilePackage[0x100];
        this.int_1 = 0;
        this.bool_0 = false;
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        this.HtwoUmmJj = string_3;
        this.string_1 = resumedProjectItem_0.LocalTempFileSavePath;
        this.string_0 = resumedProjectItem_0.LocalSavePath;
        this.string_2 = FileHelper.GetFileNameNoPath(resumedProjectItem_0.LocalSavePath);
        this.fileStream_0 = new FileStream(this.string_1, FileMode.Open);
        this.fileStream_0.Seek((long) resumedProjectItem_0.ReceivedCount, SeekOrigin.Begin);
        this.ulong_1 = resumedProjectItem_0.OriginSize;
        this.ulong_0 = resumedProjectItem_0.ReceivedCount;
        if (cbGeneric_2 == null)
        {
            cbGeneric_2 = new CbGeneric<string>(FileReceiver.smethod_2);
        }
        this.FileTransCompleted += cbGeneric_2;
        if (cbFileTransDisruptted_2 == null)
        {
            cbFileTransDisruptted_2 = new CbFileTransDisruptted(FileReceiver.smethod_3);
        }
        this.FileTransDisruptted += cbFileTransDisruptted_2;
        if (cbFileSendedProgress_2 == null)
        {
            cbFileSendedProgress_2 = new CbFileSendedProgress(FileReceiver.smethod_4);
        }
        this.FileTransProgress += cbFileSendedProgress_2;
    }

    public FileReceiver(IAgileLogger iagileLogger_0, string string_3, string string_4, ulong ulong_2, string string_5)
    {
        this.diYatLwGC = new EventSafeTrigger(new EmptyAgileLogger(), "XrZokLIgmVlcsHl3C7.nxZXDMlUfKsyJYxeVn");
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.ulong_0 = 0L;
        this.HtwoUmmJj = "";
        this.object_0 = 0;
        this.int_0 = 0;
        this.byte_0 = 0;
        this.filePackage_0 = new FilePackage[0x100];
        this.int_1 = 0;
        this.bool_0 = false;
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        this.HtwoUmmJj = string_3;
        if (File.Exists(string_4))
        {
            File.Delete(string_4);
        }
        this.string_0 = string_4;
        this.string_1 = string_4 + string_5;
        while (File.Exists(this.string_1))
        {
            this.string_1 = this.string_1 + string_5;
        }
        this.string_2 = FileHelper.GetFileNameNoPath(string_4);
        this.fileStream_0 = new FileStream(this.string_1, FileMode.OpenOrCreate);
        this.ulong_1 = ulong_2;
        if (cbGeneric_1 == null)
        {
            cbGeneric_1 = new CbGeneric<string>(FileReceiver.smethod_0);
        }
        this.FileTransCompleted += cbGeneric_1;
        if (cbFileTransDisruptted_1 == null)
        {
            cbFileTransDisruptted_1 = new CbFileTransDisruptted(FileReceiver.smethod_1);
        }
        this.FileTransDisruptted += cbFileTransDisruptted_1;
        if (cbFileSendedProgress_1 == null)
        {
            cbFileSendedProgress_1 = new CbFileSendedProgress(FileReceiver.nAuyhuNgq);
        }
        this.FileTransProgress += cbFileSendedProgress_1;
        if (ulong_2 == 0L)
        {
            this.fileStream_0.Flush();
            this.fileStream_0.Close();
            if (!File.Exists(this.string_0))
            {
                File.Move(this.string_1, this.string_0);
            }
            new CbGeneric(this.method_0).BeginInvoke(null, null);
        }
    }

    public FileReceiver(IAgileLogger iagileLogger_0, string string_3, string string_4, string string_5, ulong ulong_2, ulong ulong_3)
    {
        this.diYatLwGC = new EventSafeTrigger(new EmptyAgileLogger(), "XrZokLIgmVlcsHl3C7.nxZXDMlUfKsyJYxeVn");
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.ulong_0 = 0L;
        this.HtwoUmmJj = "";
        this.object_0 = 0;
        this.int_0 = 0;
        this.byte_0 = 0;
        this.filePackage_0 = new FilePackage[0x100];
        this.int_1 = 0;
        this.bool_0 = false;
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        this.HtwoUmmJj = string_3;
        this.string_1 = string_4;
        this.string_0 = string_5;
        this.string_2 = FileHelper.GetFileNameNoPath(string_5);
        this.fileStream_0 = new FileStream(this.string_1, FileMode.Open);
        this.fileStream_0.Seek((long) ulong_3, SeekOrigin.Begin);
        this.ulong_1 = ulong_2;
        this.ulong_0 = ulong_3;
        if (cbGeneric_3 == null)
        {
            cbGeneric_3 = new CbGeneric<string>(FileReceiver.smethod_5);
        }
        this.FileTransCompleted += cbGeneric_3;
        if (cbFileTransDisruptted_3 == null)
        {
            cbFileTransDisruptted_3 = new CbFileTransDisruptted(FileReceiver.smethod_6);
        }
        this.FileTransDisruptted += cbFileTransDisruptted_3;
        if (cbFileSendedProgress_3 == null)
        {
            cbFileSendedProgress_3 = new CbFileSendedProgress(FileReceiver.smethod_7);
        }
        this.FileTransProgress += cbFileSendedProgress_3;
    }

    public void FileReceive(FilePackage filePackage_1)
    {
        if ((this.object_0 == null) && (this.fileStream_0 != null))
        {
            this.int_0++;
            byte index = (byte) (this.byte_0 + 1);
            if (filePackage_1.Index == index)
            {
                this.Receive(filePackage_1);
                this.byte_0 = (byte) (this.byte_0 + 1);
                for (index = (byte) (this.byte_0 + 1); this.filePackage_0[index] != null; index = (byte) (this.byte_0 + 1))
                {
                    FilePackage package = this.filePackage_0[index];
                    this.filePackage_0[index] = null;
                    this.Receive(package);
                    this.byte_0 = (byte) (this.byte_0 + 1);
                }
            }
            else
            {
                this.filePackage_0[filePackage_1.Index] = filePackage_1;
            }
        }
    }

    public void imethod_1(FileTransDisrupttedType fileTransDisrupttedType_0, bool bool_1, string string_3)
    {
        try
        {
            this.object_0 = 1;
            this.fileStream_0.Flush();
            this.fileStream_0.Close();
            this.fileStream_0 = null;
            if (bool_1)
            {
                File.Delete(this.string_1);
            }
        }
        catch (Exception)
        {
        }
        this.FileTransDisruptted(this.HtwoUmmJj, fileTransDisrupttedType_0, string_3);
    }

    public FileTransferingProgress imethod_2()
    {
        return new FileTransferingProgress(this.HtwoUmmJj, this.ulong_1, this.ulong_0);
    }

    public void imethod_3()
    {
        if (this.object_0 == 0)
        {
            if (!this.bool_0)
            {
                this.int_1 = this.int_0;
                this.bool_0 = true;
            }
            else
            {
                int num = this.int_0 - this.int_1;
                if (num > 0)
                {
                    this.int_1 = this.int_0;
                }
                else if (this.int_0 == 0)
                {
                    this.imethod_1(FileTransDisrupttedType.Timeout4FirstPackage, false, "");
                }
                else
                {
                    this.imethod_1(FileTransDisrupttedType.NetworkSpeedSlow, false, "");
                }
            }
        }
    }

    public bool imethod_4()
    {
        return false;
    }

    public string imethod_5()
    {
        return this.string_2;
    }

    public ulong imethod_6()
    {
        return this.ulong_1;
    }

    public string imethod_7()
    {
        return this.string_0;
    }

    public string imethod_8()
    {
        return this.string_1;
    }

    public ulong imethod_9()
    {
        return this.ulong_0;
    }

    private void method_0()
    {
        Thread.Sleep(0x3e8);
        this.diYatLwGC.Action<string>("FileTransCompleted", this.FileTransCompleted, this.HtwoUmmJj);
    }

    private void Receive(FilePackage filePackage_1)
    {
        try
        {
            this.fileStream_0.Write(filePackage_1.Data, 0, filePackage_1.Data.Length);
            this.ulong_0 += (ulong) filePackage_1.Data.Length;
            this.FileTransProgress(filePackage_1.ProjectID, this.ulong_1, this.ulong_0);
            if (this.ulong_0 == this.ulong_1)
            {
                this.fileStream_0.Flush();
                this.fileStream_0.Close();
                if (!File.Exists(this.string_0))
                {
                    File.Move(this.string_1, this.string_0);
                }
                this.diYatLwGC.ActionAsyn<string>("FileTransCompleted", this.FileTransCompleted, filePackage_1.ProjectID);
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.FileTransceiver.FileReceiver.Receive", ErrorLevel.Standard);
            this.FileTransDisruptted(this.HtwoUmmJj, FileTransDisrupttedType.InnerError, exception.Message);
        }
    }

    [CompilerGenerated]
    private static void nAuyhuNgq(object object_1, ulong ulong_2, ulong ulong_3)
    {
    }

    [CompilerGenerated]
    private static void smethod_0(object object_1)
    {
    }

    [CompilerGenerated]
    private static void smethod_1(object object_1, FileTransDisrupttedType fileTransDisrupttedType_0, object object_2)
    {
    }

    [CompilerGenerated]
    private static void smethod_2(object object_1)
    {
    }

    [CompilerGenerated]
    private static void smethod_3(object object_1, FileTransDisrupttedType fileTransDisrupttedType_0, object object_2)
    {
    }

    [CompilerGenerated]
    private static void smethod_4(object object_1, ulong ulong_2, ulong ulong_3)
    {
    }

    [CompilerGenerated]
    private static void smethod_5(object object_1)
    {
    }

    [CompilerGenerated]
    private static void smethod_6(object object_1, FileTransDisrupttedType fileTransDisrupttedType_0, object object_2)
    {
    }

    [CompilerGenerated]
    private static void smethod_7(object object_1, ulong ulong_2, ulong ulong_3)
    {
    }
}

