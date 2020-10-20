using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJPlus.FileTransceiver;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

internal class Class22 : IFileOutter
{
    private bool bool_0 = false;
    private bool bool_1 = false;
    private bool bool_2 = false;
    private bool bool_3 = false;
    [CompilerGenerated]
    private static CbFileSendedProgress cbFileSendedProgress_1;
    [CompilerGenerated]
    private static CbFileTransCompleted cbFileTransCompleted_1;
    [CompilerGenerated]
    private static CbFileTransDisruptted cbFileTransDisruptted_1;
    private int Diaygioqui = 20;
    private EmptyAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private FileTransDisrupttedType fileTransDisrupttedType_0 = FileTransDisrupttedType.InnerError;
    private int int_0 = 0x800;
    private int int_1 = 0x100000;
    private IFilePackageHelper interface35_0;
    private int object_0 = 0;
    private object object_1 = new object();
    private static Random random_0 = new Random();
    private Stream stream_0;
    private string string_0;
    private string string_1 = null;
    private string string_2 = "";
    private string string_3 = "";
    private Thread thread_0 = null;
    private ulong ulong_0 = 0L;
    private ulong ulong_1 = 0L;
    private ulong ulong_2 = 0L;

    public event CbFileTransCompleted FileTransCompleted;

    public event CbFileTransDisruptted FileTransDisruptted;

    public event CbFileSendedProgress FileTransProgress;

    public Class22(IAgileLogger iagileLogger_0, IFilePackageHelper interface35_1, string string_4, Stream stream_1, ulong ulong_3, string string_5)
    {
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        this.interface35_0 = interface35_1;
        this.stream_0 = stream_1;
        this.string_0 = string_4;
        this.ulong_0 = ulong_3;
        this.string_1 = string_5;
        if (cbFileTransCompleted_1 == null)
        {
            cbFileTransCompleted_1 = new CbFileTransCompleted(Class22.smethod_0);
        }
        this.FileTransCompleted += cbFileTransCompleted_1;
        if (cbFileTransDisruptted_1 == null)
        {
            cbFileTransDisruptted_1 = new CbFileTransDisruptted(Class22.smethod_1);
        }
        this.FileTransDisruptted += cbFileTransDisruptted_1;
        if (cbFileSendedProgress_1 == null)
        {
            cbFileSendedProgress_1 = new CbFileSendedProgress(Class22.smethod_2);
        }
        this.FileTransProgress += cbFileSendedProgress_1;
    }

    public void HnFdepcbbe(bool bool_4)
    {
        if (bool_4)
        {
            new CbSimple(this.method_1).BeginInvoke(null, null);
        }
        else
        {
            this.thread_0 = new Thread(new ParameterizedThreadStart(this.method_0));
            this.thread_0.Start();
        }
    }

    public void imethod_0(FileTransDisrupttedType fileTransDisrupttedType_1, string string_4)
    {
        this.object_0 = 1;
        this.fileTransDisrupttedType_0 = fileTransDisrupttedType_1;
        this.string_3 = string_4;
        if ((fileTransDisrupttedType_1 == FileTransDisrupttedType.DestCancel) && (string_4 == "NetworkSpeedSlow"))
        {
            this.MhcyEttgGe(this.fileTransDisrupttedType_0, this.string_3);
        }
    }

    public FileTransferingProgress imethod_1()
    {
        return new FileTransferingProgress(this.string_2, this.ulong_0, this.ulong_1);
    }

    public int imethod_10()
    {
        return this.Diaygioqui;
    }

    public void imethod_11(int int_2)
    {
        this.Diaygioqui = int_2;
    }

    public int imethod_12()
    {
        return this.int_1;
    }

    public void imethod_13(int int_2)
    {
        this.int_1 = int_2;
    }

    public void imethod_2()
    {
        if (this.object_0 == 0)
        {
            if (!this.bool_3)
            {
                this.ulong_2 = this.ulong_1;
                this.bool_3 = true;
            }
            else
            {
                ulong num = this.ulong_1 - this.ulong_2;
                if (num > 0L)
                {
                    this.ulong_2 = this.ulong_1;
                }
                else
                {
                    this.object_0 = 1;
                    if (!this.bool_1)
                    {
                        this.fileTransDisrupttedType_0 = FileTransDisrupttedType.SendThreadNotStarted;
                        this.MhcyEttgGe(this.fileTransDisrupttedType_0, this.string_3);
                    }
                    else if (!this.bool_0)
                    {
                        this.fileTransDisrupttedType_0 = FileTransDisrupttedType.ReadFileBlocked;
                        this.MhcyEttgGe(this.fileTransDisrupttedType_0, this.string_3);
                    }
                    else
                    {
                        this.fileTransDisrupttedType_0 = FileTransDisrupttedType.NetworkSpeedSlow;
                        this.MhcyEttgGe(this.fileTransDisrupttedType_0, this.string_3);
                    }
                }
            }
        }
    }

    public bool imethod_3()
    {
        return false;
    }

    public string imethod_4()
    {
        return this.string_0;
    }

    public string imethod_5()
    {
        return this.string_2;
    }

    public void imethod_6(string string_4)
    {
        this.string_2 = string_4;
    }

    public ulong imethod_7()
    {
        return FileHelper.GetFileSize(this.string_0);
    }

    public int imethod_8()
    {
        return this.imethod_8();
    }

    public void imethod_9(int int_2)
    {
        this.int_0 = int_2;
    }

    private void method_0(object object_2)
    {
        this.method_1();
    }

    private void method_1()
    {
        this.bool_1 = true;
        try
        {
            if (this.int_1 < this.int_0)
            {
                this.int_1 = this.int_0;
            }
            byte[] buff = new byte[this.int_1];
            byte[] dst = new byte[this.int_0];
            byte num5 = 0;
            while (this.ulong_1 >= this.ulong_0)
            {
                FilePackage package;
            Label_0048:
                if (0 == 0)
                {
                    goto Label_0234;
                }
                ulong num = this.ulong_0 - this.ulong_1;
                if (num > ((ulong) buff.Length))
                {
                    FileHelper.ReadFileData(this.stream_0, buff, buff.Length, 0);
                }
                else
                {
                    buff = new byte[num];
                    FileHelper.ReadFileData(this.stream_0, buff, (int) num, 0);
                }
                this.bool_0 = true;
                int num4 = buff.Length / this.int_0;
                int count = buff.Length % this.int_0;
                for (int i = 0; i < num4; i++)
                {
                    if (this.object_0 != 0)
                    {
                        break;
                    }
                    Buffer.BlockCopy(buff, i * this.int_0, dst, 0, this.int_0);
                    this.ulong_1 += (ulong) dst.Length;
                    package = new FilePackage(this.string_2, num5 = (byte) (num5 + 1), dst, PackageType.FileTransferingPackage);
                    this.interface35_0.sendMessage(this.string_1, package);
                    this.FileTransProgress(this.imethod_5(), this.ulong_0, this.ulong_1);
                    if (((this.Diaygioqui <= 0) ? 1 : this.object_0) == null)
                    {
                        Thread.Sleep(this.Diaygioqui);
                    }
                }
                if (((count <= 0) ? 1 : this.object_0) == null)
                {
                    byte[] buffer3 = new byte[count];
                    Buffer.BlockCopy(buff, num4 * this.int_0, buffer3, 0, count);
                    this.ulong_1 += (ulong) buffer3.Length;
                    package = new FilePackage(this.string_2, num5 = (byte) (num5 + 1), buffer3, PackageType.FileTransferingPackage);
                    this.interface35_0.sendMessage(this.string_1, package);
                    this.FileTransProgress(this.imethod_5(), this.ulong_0, this.ulong_1);
                    if (((this.Diaygioqui <= 0) ? 1 : this.object_0) == null)
                    {
                        Thread.Sleep(this.Diaygioqui);
                    }
                }
            }
           // goto Label_0048;
        Label_0234:
            if (this.object_0 == null)
            {
                this.FileTransCompleted(this.imethod_5());
            }
            else if (this.fileTransDisrupttedType_0 != FileTransDisrupttedType.NetworkSpeedSlow)
            {
                this.MhcyEttgGe(this.fileTransDisrupttedType_0, this.string_3);
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.FileTransceiver.FileSender.DoSend", ErrorLevel.Standard);
            this.MhcyEttgGe(FileTransDisrupttedType.InnerError, exception.Message);
        }
    }

    private void MhcyEttgGe(FileTransDisrupttedType fileTransDisrupttedType_1, string string_4)
    {
        lock (this.object_1)
        {
            if (!this.bool_2)
            {
                this.bool_2 = true;
                this.FileTransDisruptted(this.imethod_5(), fileTransDisrupttedType_1, string_4);
            }
        }
    }

    [CompilerGenerated]
    private static void smethod_0(object object_2)
    {
    }

    [CompilerGenerated]
    private static void smethod_1(object object_2, FileTransDisrupttedType fileTransDisrupttedType_1, object object_3)
    {
    }

    [CompilerGenerated]
    private static void smethod_2(object object_2, ulong ulong_3, ulong ulong_4)
    {
    }
}

