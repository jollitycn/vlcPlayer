using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJPlus.FileTransceiver;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

internal class FileSender : IFileOutter
{
    private bool bool_0 = false;
    private bool bool_1 = false;
    private bool bool_2 = false;
    private bool bool_3 = false;
    [CompilerGenerated]
    private  CbFileSendedProgress cbFileSendedProgress_1;
    [CompilerGenerated]
    private  CbFileTransCompleted cbFileTransCompleted_1;
    [CompilerGenerated]
    private  CbFileTransDisruptted cbFileTransDisruptted_1;
    private EmptyAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private FileTransDisrupttedType fileTransDisrupttedType_0 = FileTransDisrupttedType.InnerError;
    private int int_0 = 0x800;
    private int int_1 = 20;
    private int int_2 = 0x100000;
    private IFilePackageHelper interface35_0;
    private int object_0 = 0;
    private object object_1 = new object();
    private static Random random_0 = new Random();
    private string string_0;
    private string string_1 = null;
    private string string_2 = "";
    private string string_3 = "";
    private Thread thread_0 = null;
    private ulong ulong_0 = 0L;
    private ulong ulong_1 = 0L;
    private ulong ulong_2 = 0L;
    private ulong ulong_3 = 0L;

    public event CbFileTransCompleted FileTransCompleted;

    public event CbFileTransDisruptted FileTransDisruptted;

    public event CbFileSendedProgress FileTransProgress;

    public FileSender(IAgileLogger iagileLogger_0, IFilePackageHelper interface35_1, string string_4, string string_5, ulong ulong_4)
    {
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        this.interface35_0 = interface35_1;
        this.string_0 = string_4;
        this.string_1 = string_5;
        this.ulong_0 = ulong_4;
        if (cbFileTransCompleted_1 == null)
        {
            cbFileTransCompleted_1 = new CbFileTransCompleted(FileSender.smethod_0);
        }
        this.FileTransCompleted += cbFileTransCompleted_1;
        if (cbFileTransDisruptted_1 == null)
        {
            cbFileTransDisruptted_1 = new CbFileTransDisruptted(FileSender.smethod_1);
        }
        this.FileTransDisruptted += cbFileTransDisruptted_1;
        if (cbFileSendedProgress_1 == null)
        {
            cbFileSendedProgress_1 = new CbFileSendedProgress(FileSender.smethod_2);
        }
        this.FileTransProgress += cbFileSendedProgress_1;
    }

    public void HnFdepcbbe(bool bool_4)
    {
        if (bool_4)
        {
            new CbSimple(this.DoSend).BeginInvoke(null, null);
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
            this.method_2(this.fileTransDisrupttedType_0, this.string_3);
        }
    }

    public FileTransferingProgress imethod_1()
    {
        return new FileTransferingProgress(this.string_2, this.ulong_1, this.ulong_2);
    }

    public int imethod_10()
    {
        return this.int_1;
    }

    public void imethod_11(int int_3)
    {
        this.int_1 = int_3;
    }

    public int imethod_12()
    {
        return this.int_2;
    }

    public void imethod_13(int int_3)
    {
        this.int_2 = int_3;
    }

    public void imethod_2()
    {
        if (this.object_0 == 0)
        {
            if (!this.bool_3)
            {
                this.ulong_3 = this.ulong_2;
                this.bool_3 = true;
            }
            else
            {
                ulong num = this.ulong_2 - this.ulong_3;
                if (num > 0L)
                {
                    this.ulong_3 = this.ulong_2;
                }
                else
                {
                    this.object_0 = 1;
                    if (!this.bool_1)
                    {
                        this.fileTransDisrupttedType_0 = FileTransDisrupttedType.SendThreadNotStarted;
                        this.method_2(this.fileTransDisrupttedType_0, this.string_3);
                    }
                    else if (!this.bool_0)
                    {
                        this.fileTransDisrupttedType_0 = FileTransDisrupttedType.ReadFileBlocked;
                        this.method_2(this.fileTransDisrupttedType_0, this.string_3);
                    }
                    else
                    {
                        this.fileTransDisrupttedType_0 = FileTransDisrupttedType.NetworkSpeedSlow;
                        this.method_2(this.fileTransDisrupttedType_0, this.string_3);
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
        return FileHelper.GetFileNameNoPath(this.string_0);
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

    public void imethod_9(int int_3)
    {
        this.int_0 = int_3;
    }

    private void method_0(object object_2)
    {
        this.DoSend();
    }

    private void DoSend()
    {
        this.bool_1 = true;
        FileStream fs = null;
        try
        {
            fs = new FileStream(this.string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            fs.Seek((long) this.ulong_0, SeekOrigin.Begin);
            this.ulong_1 = (ulong) fs.Length;
            this.ulong_2 = this.ulong_0;
            if (this.int_2 < this.int_0)
            {
                this.int_2 = this.int_0;
            }
            byte[] buff = new byte[this.int_2];
            byte[] dst = new byte[this.int_0];
            byte num2 = 0;
            while (this.ulong_2 >= this.ulong_1)
            {
                FilePackage package; 
                if (0 == 0)
                {
                    goto Label_0265;
                }
                ulong num3 = this.ulong_1 - this.ulong_2;
                if (num3 > ((ulong) buff.Length))
                {
                    FileHelper.ReadFileData(fs, buff, buff.Length, 0);
                }
                else
                {
                    buff = new byte[num3];
                    FileHelper.ReadFileData(fs, buff, (int) num3, 0);
                }
                this.bool_0 = true;
                int num5 = buff.Length / this.int_0;
                int count = buff.Length % this.int_0;
                for (int i = 0; i < num5; i++)
                {
                    if (this.object_0 != 0)
                    {
                        break;
                    }
                    Buffer.BlockCopy(buff, i * this.int_0, dst, 0, this.int_0);
                    this.ulong_2 += (ulong) dst.Length;
                    package = new FilePackage(this.string_2, num2 = (byte) (num2 + 1), dst, PackageType.FileTransferingPackage);
                    this.interface35_0.sendMessage(this.string_1, package);
                    this.cbFileSendedProgress_1(this.imethod_5(), this.ulong_1, this.ulong_2);
                    if (((this.int_1 <= 0) ? 1 : this.object_0) == null)
                    {
                        Thread.Sleep(this.int_1);
                    }
                }
                if (((count <= 0) ? 1 : this.object_0) == null)
                {
                    byte[] buffer3 = new byte[count];
                    Buffer.BlockCopy(buff, num5 * this.int_0, buffer3, 0, count);
                    this.ulong_2 += (ulong) buffer3.Length;
                    package = new FilePackage(this.string_2, num2 = (byte) (num2 + 1), buffer3, PackageType.FileTransferingPackage);
                    this.interface35_0.sendMessage(this.string_1, package);
                    this.cbFileSendedProgress_1(this.imethod_5(), this.ulong_1, this.ulong_2);
                    if (((this.int_1 <= 0) ? 1 : this.object_0) == null)
                    {
                        Thread.Sleep(this.int_1);
                    }
                }
            }
          //  goto Label_007E;
        Label_0265:
            fs.Close();
            if (this.object_0 == null)
            {
                this.cbFileTransCompleted_1(this.imethod_5());
            }
            else if (this.fileTransDisrupttedType_0 != FileTransDisrupttedType.NetworkSpeedSlow)
            {
                this.method_2(this.fileTransDisrupttedType_0, this.string_3);
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.FileTransceiver.FileSender.DoSend", ErrorLevel.Standard);
            this.method_2(FileTransDisrupttedType.InnerError, exception.Message);
            if (fs != null)
            {
                fs.Close();
            }
        }
    }

    private void method_2(FileTransDisrupttedType fileTransDisrupttedType_1, string string_4)
    {
        lock (this.object_1)
        {
            if (!this.bool_2)
            {
                this.bool_2 = true;
                this.cbFileTransDisruptted_1(this.imethod_5(), fileTransDisrupttedType_1, string_4);
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
    private static void smethod_2(object object_2, ulong ulong_4, ulong ulong_5)
    {
    }
}

