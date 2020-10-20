using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJPlus.FileTransceiver;
using CJPlus.Serialization;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal class DirectoryReceiver : IFileTransHelper
{
    [CompilerGenerated]
    private static CbFileSendedProgress cbFileSendedProgress_1;
    [CompilerGenerated]
    private static CbFileSendedProgress cbFileSendedProgress_2;
    [CompilerGenerated]
    private static CbFileTransDisruptted cbFileTransDisruptted_1;
    [CompilerGenerated]
    private static CbFileTransDisruptted cbFileTransDisruptted_2;
    [CompilerGenerated]
    private static CbGeneric<string> cbGeneric_2;
    [CompilerGenerated]
    private static CbGeneric<string> cbGeneric_3;
    private EmptyAgileLogger emptyAgileLogger_0;
    private FileReceiver enisnmwGbe;
    private EventSafeTrigger eventSafeTrigger_0;
    private object object_0;
    private string string_0;
    private string string_1;
    private string string_2;
    private string string_3;
    private string string_4;
    private ulong ulong_0;
    private ulong ulong_1;
    private ulong ulong_2;
    private ulong ulong_3;
    private ulong ulong_4;

    public event CbGeneric<string> FileTransReceived;

    public event CbGeneric<string> FileTransCompleted;

    public event CbFileTransDisruptted FileTransDisruptted;

    public event CbFileSendedProgress FileTransProgress;

    public DirectoryReceiver(IAgileLogger iagileLogger_0, string string_5, string string_6, ResumedProjectItem resumedProjectItem_0)
    {
        this.eventSafeTrigger_0 = new EventSafeTrigger(new EmptyAgileLogger(), "XrZokLIgmVlcsHl3C7.nxZXDMlUfKsyJYxeVn");
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.ulong_0 = 0L;
        this.ulong_1 = 0L;
        this.ulong_2 = 0L;
        this.string_3 = "";
        this.ulong_4 = 0L;
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        this.string_3 = string_5;
        this.string_0 = resumedProjectItem_0.LocalSavePath;
        this.string_4 = string_6;
        string[] strArray = this.string_0.Trim().Split(new char[] { '\\' });
        this.object_0 = strArray[strArray.Length - 2];
        this.ulong_3 = resumedProjectItem_0.OriginSize;
        this.ulong_0 = resumedProjectItem_0.ReceivedCount;
        if (cbGeneric_3 == null)
        {
            cbGeneric_3 = new CbGeneric<string>(DirectoryReceiver.smethod_3);
        }
        this.FileTransCompleted += cbGeneric_3;
        if (cbFileTransDisruptted_2 == null)
        {
            cbFileTransDisruptted_2 = new CbFileTransDisruptted(DirectoryReceiver.smethod_4);
        }
        this.FileTransDisruptted += cbFileTransDisruptted_2;
        if (cbFileSendedProgress_2 == null)
        {
            cbFileSendedProgress_2 = new CbFileSendedProgress(DirectoryReceiver.smethod_5);
        }
        this.FileTransProgress += cbFileSendedProgress_2;
        this.ulong_4 = resumedProjectItem_0.ReceivedCount - resumedProjectItem_0.DisrupttedFileReceivedCount;
        string str = this.string_0 + resumedProjectItem_0.DisrupttedFileRelativePath;
        this.enisnmwGbe = new FileReceiver(this.emptyAgileLogger_0, this.string_3, resumedProjectItem_0.LocalTempFileSavePath, str, resumedProjectItem_0.DisrupttedFileSize, resumedProjectItem_0.DisrupttedFileReceivedCount);
        this.enisnmwGbe.FileTransDisruptted += new CbFileTransDisruptted(this.method_5);
        this.enisnmwGbe.FileTransCompleted += new CbGeneric<string>(this.OnFileTransCompleted);
        this.enisnmwGbe.FileTransProgress += new CbFileSendedProgress(this.method_3);
    }

    public DirectoryReceiver(IAgileLogger iagileLogger_0, string string_5, string string_6, ulong ulong_5, string string_7)
    {
        this.eventSafeTrigger_0 = new EventSafeTrigger(new EmptyAgileLogger(), "XrZokLIgmVlcsHl3C7.nxZXDMlUfKsyJYxeVn");
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.ulong_0 = 0L;
        this.ulong_1 = 0L;
        this.ulong_2 = 0L;
        this.string_3 = "";
        this.ulong_4 = 0L;
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        this.string_3 = string_5;
        if (!string_6.EndsWith(@"\"))
        {
            string_6 = string_6 + @"\";
        }
        this.string_0 = string_6;
        this.string_4 = string_7;
        string[] strArray = this.string_0.Trim().Split(new char[] { '\\' });
        this.object_0 = strArray[strArray.Length - 2];
        this.ulong_3 = ulong_5;
        if (cbGeneric_2 == null)
        {
            cbGeneric_2 = new CbGeneric<string>(DirectoryReceiver.smethod_0);
        }
        this.FileTransCompleted += cbGeneric_2;
        if (cbFileTransDisruptted_1 == null)
        {
            cbFileTransDisruptted_1 = new CbFileTransDisruptted(DirectoryReceiver.smethod_1);
        }
        this.FileTransDisruptted += cbFileTransDisruptted_1;
        if (cbFileSendedProgress_1 == null)
        {
            cbFileSendedProgress_1 = new CbFileSendedProgress(DirectoryReceiver.smethod_2);
        }
        this.FileTransProgress += cbFileSendedProgress_1;
    }

    public void FileReceive(FilePackage filePackage_0)
    {
        try
        {
            if (filePackage_0.PackageType == PackageType.NewChildFolder)
            {
                Directory.CreateDirectory(this.string_0 + Encoding.UTF8.GetString(filePackage_0.Data));
            }
            else if (filePackage_0.PackageType == PackageType.FoldTransferingNextFile)
            {
                if ((this.enisnmwGbe != null) && (this.enisnmwGbe.imethod_6() > this.enisnmwGbe.imethod_9()))
                {
                    this.emptyAgileLogger_0.LogWithTime(string.Format("当前文件[{0}]还未接收完，就收到了准备接收下个文件的指令！", this.enisnmwGbe.imethod_5()));
                }
                FoldTransferingNextFileInfo info = CompactPropertySerializer.Default.Deserialize<FoldTransferingNextFileInfo>(filePackage_0.Data, 0);
                string str = this.string_0 + info.RelativeFilePath;
                this.enisnmwGbe = new FileReceiver(this.emptyAgileLogger_0, this.string_3, str, info.FileLength, this.string_4);
                this.enisnmwGbe.FileTransDisruptted += new CbFileTransDisruptted(this.method_5);
                this.enisnmwGbe.FileTransCompleted += new CbGeneric<string>(this.OnFileTransCompleted);
                this.enisnmwGbe.FileTransProgress += new CbFileSendedProgress(this.method_3);
            }
            else if (filePackage_0.PackageType == PackageType.FileTransferingPackage)
            {
                this.enisnmwGbe.FileReceive(filePackage_0);
            }
            else
            {
                this.FileTransReceived(this.string_3);
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.FileTransceiver.DirectoryReceiver.Receive", ErrorLevel.Standard);
        }
    }



    public void imethod_1(FileTransDisrupttedType fileTransDisrupttedType_0, bool bool_0, string string_5)
    {
        this.enisnmwGbe.imethod_1(fileTransDisrupttedType_0, bool_0, string_5);
    }

    public FileTransferingProgress imethod_2()
    {
        return new FileTransferingProgress(this.string_3, this.ulong_3, this.ulong_0);
    }

    public void imethod_3()
    {
        this.enisnmwGbe.imethod_3();
    }

    public bool imethod_4()
    {
        return true;
    }

    public string imethod_5()
    {
        return (string) this.object_0;
    }

    public ulong imethod_6()
    {
        return this.ulong_3;
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

    public string method_0()
    {
        return this.string_2;
    }

    public ulong method_1()
    {
        return this.ulong_1;
    }

    public ulong method_2()
    {
        return this.ulong_2;
    }

    private void method_3(string string_5, ulong ulong_5, ulong ulong_6)
    {
        this.ulong_0 = this.ulong_4 + ulong_6;
        this.FileTransProgress(this.string_3, this.ulong_3, this.ulong_0);
        if (ulong_6 == ulong_5)
        {
            this.ulong_4 += this.enisnmwGbe.imethod_6();
        }
    }

    private void OnFileTransCompleted(string string_5)
    {
        if (this.FileTransCompleted != null)
        {
            this.FileTransCompleted(string_5);
        }
    }

    private void method_5(string string_5, FileTransDisrupttedType fileTransDisrupttedType_0, string string_6)
    {
        this.ulong_2 = this.enisnmwGbe.imethod_9();
        this.ulong_1 = this.enisnmwGbe.imethod_6();
        this.string_1 = this.enisnmwGbe.imethod_8();
        this.string_2 = this.enisnmwGbe.imethod_7().Substring(this.string_0.Length);
        this.FileTransDisruptted(this.string_3, fileTransDisrupttedType_0, string_6);
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
    private static void smethod_2(object object_1, ulong ulong_5, ulong ulong_6)
    {
    }

    [CompilerGenerated]
    private static void smethod_3(object object_1)
    {
    }

    [CompilerGenerated]
    private static void smethod_4(object object_1, FileTransDisrupttedType fileTransDisrupttedType_0, object object_2)
    {
    }

    [CompilerGenerated]
    private static void smethod_5(object object_1, ulong ulong_5, ulong ulong_6)
    {
    }
}

