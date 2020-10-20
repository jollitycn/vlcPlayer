using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJPlus.FileTransceiver;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

internal class Class124 : IFileTransHelper
{
    private bool bool_0 = false;
    private byte byte_0 = 0;
    [CompilerGenerated]
    private static CbFileSendedProgress cbFileSendedProgress_1;
    [CompilerGenerated]
    private static CbFileTransDisruptted cbFileTransDisruptted_1;
    [CompilerGenerated]
    private static CbGeneric<string> cbGeneric_1;
    private EmptyAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private EventSafeTrigger eventSafeTrigger_0 = new EventSafeTrigger(new EmptyAgileLogger(), "XrZokLIgmVlcsHl3C7.nxZXDMlUfKsyJYxeVn");
    private FilePackage[] filePackage_0 = new FilePackage[0x100];
    private int int_0 = 0;
    private int int_1 = 0;
    private int object_0 = 0;
    private object object_1;
    private Stream stream_0;
    private string string_0 = "";
    private ulong ulong_0 = 0L;
    private ulong ulong_1;

    public event CbGeneric<string> FileTransCompleted;

    public event CbFileTransDisruptted FileTransDisruptted;

    public event CbFileSendedProgress FileTransProgress;

    public Class124(IAgileLogger iagileLogger_0, string string_1, Stream stream_1, ulong ulong_2)
    {
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        this.string_0 = string_1;
        this.stream_0 = stream_1;
        this.ulong_1 = ulong_2;
        if (cbGeneric_1 == null)
        {
            cbGeneric_1 = new CbGeneric<string>(Class124.smethod_0);
        }
        this.FileTransCompleted += cbGeneric_1;
        if (cbFileTransDisruptted_1 == null)
        {
            cbFileTransDisruptted_1 = new CbFileTransDisruptted(Class124.smethod_1);
        }
        this.FileTransDisruptted += cbFileTransDisruptted_1;
        if (cbFileSendedProgress_1 == null)
        {
            cbFileSendedProgress_1 = new CbFileSendedProgress(Class124.smethod_2);
        }
        this.FileTransProgress += cbFileSendedProgress_1;
        if (ulong_2 == 0L)
        {
            this.stream_0.Flush();
            this.stream_0.Close();
            new CbGeneric(this.method_0).BeginInvoke(null, null);
        }
    }

    public void FileReceive(FilePackage filePackage_1)
    {
        if ((this.object_0 == null) && (this.stream_0 != null))
        {
            this.int_0++;
            byte index = (byte) (this.byte_0 + 1);
            if (filePackage_1.Index == index)
            {
                this.method_1(filePackage_1);
                this.byte_0 = (byte) (this.byte_0 + 1);
                for (index = (byte) (this.byte_0 + 1); this.filePackage_0[index] != null; index = (byte) (this.byte_0 + 1))
                {
                    FilePackage package = this.filePackage_0[index];
                    this.filePackage_0[index] = null;
                    this.method_1(package);
                    this.byte_0 = (byte) (this.byte_0 + 1);
                }
            }
            else
            {
                this.filePackage_0[filePackage_1.Index] = filePackage_1;
            }
        }
    }

    public void imethod_1(FileTransDisrupttedType fileTransDisrupttedType_0, bool bool_1, string string_1)
    {
        try
        {
            this.object_0 = 1;
            this.stream_0.Flush();
            this.stream_0 = null;
        }
        catch (Exception)
        {
        }
        this.FileTransDisruptted(this.string_0, fileTransDisrupttedType_0, string_1);
    }

    public FileTransferingProgress imethod_2()
    {
        return new FileTransferingProgress(this.string_0, this.ulong_1, this.ulong_0);
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
        return (string) this.object_1;
    }

    public ulong imethod_6()
    {
        return this.ulong_1;
    }

    public string imethod_7()
    {
        return "justStream";
    }

    public string imethod_8()
    {
        return "justStream";
    }

    public ulong imethod_9()
    {
        return this.ulong_0;
    }

    private void method_0()
    {
        Thread.Sleep(0x3e8);
        this.eventSafeTrigger_0.Action<string>("FileTransCompleted", this.FileTransCompleted, this.string_0);
    }

    private void method_1(FilePackage filePackage_1)
    {
        try
        {
            this.stream_0.Write(filePackage_1.Data, 0, filePackage_1.Data.Length);
            this.ulong_0 += (ulong) filePackage_1.Data.Length;
            this.FileTransProgress(filePackage_1.ProjectID, this.ulong_1, this.ulong_0);
            if (this.ulong_0 == this.ulong_1)
            {
                this.stream_0.Flush();
                this.eventSafeTrigger_0.ActionAsyn<string>("FileTransCompleted", this.FileTransCompleted, filePackage_1.ProjectID);
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.FileTransceiver.FileReceiver.Receive", ErrorLevel.Standard);
            this.FileTransDisruptted(this.string_0, FileTransDisrupttedType.InnerError, exception.Message);
        }
    }

    [CompilerGenerated]
    private static void smethod_0(object object_2)
    {
    }

    [CompilerGenerated]
    private static void smethod_1(object object_2, FileTransDisrupttedType fileTransDisrupttedType_0, object object_3)
    {
    }

    [CompilerGenerated]
    private static void smethod_2(object object_2, ulong ulong_2, ulong ulong_3)
    {
    }
}

