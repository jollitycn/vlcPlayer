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

internal class DirectorySender : IFileOutter
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
    private FileSender class107_0;
    [CompilerGenerated]
    private static Comparison<FileInfo> comparison_0;
    [CompilerGenerated]
    private static Comparison<DirectoryInfo> comparison_1;
    private EmptyAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private FileTransDisrupttedType fileTransDisrupttedType_0 = FileTransDisrupttedType.InnerError;
    private int int_0 = 0x800;
    private int int_1 = 20;
    private int int_2 = 0x100000;
    private IFilePackageHelper interface35_0;
    private ManualResetEvent manualResetEvent_0 = new ManualResetEvent(false);
    private int object_0 = 0;
    private object object_1 = new object();
    private static Random random_0 = new Random();
    private string string_0;
    private string string_1 = null;
    private string string_2 = null;
    private string string_3 = "";
    private Thread thread_0 = null;
    private ulong ulong_0 = 0L;
    private ulong ulong_1 = 0L;
    private ulong ulong_2 = 0L;
    private ulong ulong_3 = 0L;

    public event CbFileTransCompleted FileTransCompleted;

    public event CbFileTransDisruptted FileTransDisruptted;

    public event CbFileSendedProgress FileTransProgress;

    public DirectorySender(IAgileLogger iagileLogger_0, IFilePackageHelper interface35_1, string string_4, string string_5, string string_6, ulong ulong_4, ulong ulong_5)
    {
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        this.interface35_0 = interface35_1;
        DirectoryInfo info = new DirectoryInfo(string_4 + @"\");
        this.string_0 = info.FullName;
        this.string_1 = string_5;
        this.string_2 = string_6;
        this.ulong_1 = ulong_4 - ulong_5;
        this.ulong_3 = ulong_5;
        this.ulong_0 = FileHelper.GetDirectorySize(this.string_0);
        if (cbFileTransCompleted_1 == null)
        {
            cbFileTransCompleted_1 = new CbFileTransCompleted(DirectorySender.smethod_0);
        }
        this.FileTransCompleted += cbFileTransCompleted_1;
        if (cbFileTransDisruptted_1 == null)
        {
            cbFileTransDisruptted_1 = new CbFileTransDisruptted(DirectorySender.smethod_1);
        }
        this.FileTransDisruptted += cbFileTransDisruptted_1;
        if (cbFileSendedProgress_1 == null)
        {
            cbFileSendedProgress_1 = new CbFileSendedProgress(DirectorySender.smethod_2);
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
        this.class107_0.imethod_0(fileTransDisrupttedType_1, string_4);
        this.OnFileTransDisruptted(this.string_3, fileTransDisrupttedType_1, string_4);
    }

    public FileTransferingProgress imethod_1()
    {
        return new FileTransferingProgress(this.string_3, this.ulong_0, this.ulong_2);
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
            this.class107_0.imethod_2();
        }
    }

    public bool imethod_3()
    {
        return true;
    }

    public string imethod_4()
    {
        string[] strArray = this.string_0.Trim().Split(new char[] { '\\' });
        return strArray[strArray.Length - 1];
    }

    public string imethod_5()
    {
        return this.string_3;
    }

    public void imethod_6(string string_4)
    {
        this.string_3 = string_4;
    }

    public ulong imethod_7()
    {
        return this.ulong_0;
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
        this.method_1();
    }

    private void method_1()
    {
        this.bool_1 = this.string_2 != null;
        this.DoSend(this.string_0);
        if (!this.bool_0)
        {
            FilePackage package = new FilePackage(this.string_3, 0, null, PackageType.Finished);
            this.interface35_0.sendMessage(this.string_1, package);
            this.FileTransCompleted(this.string_3);
        }
    }

    private void DoSend(string string_4)
    {
        try
        {
            int num;
            if (!(this.bool_1 && !this.bool_2))
            {
                string s = string_4.Substring(this.string_0.Length);
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                FilePackage package2 = new FilePackage(this.string_3, 0, bytes, PackageType.NewChildFolder);
                this.interface35_0.sendMessage(this.string_1, package2);
            }
            DirectoryInfo info4 = new DirectoryInfo(string_4);
            FileInfo[] files = info4.GetFiles();
            if (comparison_0 == null)
            {
                comparison_0 = new Comparison<FileInfo>(DirectorySender.smethod_3);
            }
            Array.Sort<FileInfo>(files, comparison_0);
            for (num = 0; num < files.Length; num++)
            {
                this.bool_3 = false;
                FileInfo info = files[num];
                string str = info.FullName.Substring(this.string_0.Length);
                if (this.bool_1 && (str == this.string_2))
                {
                    this.bool_2 = true;
                    this.bool_3 = true;
                }
                if (!this.bool_1 || this.bool_2)
                {
                    if (this.bool_3)
                    {
                        this.class107_0 = new FileSender(this.emptyAgileLogger_0, this.interface35_0, info.FullName, this.string_1, this.ulong_3);
                    }
                    else
                    {
                        FoldTransferingNextFileInfo info2 = new FoldTransferingNextFileInfo(str, (ulong) info.Length);
                        byte[] buffer = CompactPropertySerializer.Default.Serialize<FoldTransferingNextFileInfo>(info2);
                        FilePackage package = new FilePackage(this.string_3, 0, buffer, PackageType.FoldTransferingNextFile);
                        this.interface35_0.sendMessage(this.string_1, package);
                        this.class107_0 = new FileSender(this.emptyAgileLogger_0, this.interface35_0, info.FullName, this.string_1, 0L);
                    }
                    this.class107_0.imethod_9(this.int_0);
                    this.class107_0.imethod_11(this.int_1);
                    this.class107_0.imethod_13(this.int_2);
                    this.class107_0.imethod_6(this.string_3);
                    this.class107_0.FileTransDisruptted += new CbFileTransDisruptted(this.OnFileTransDisruptted);
                    this.class107_0.FileTransProgress += new CbFileSendedProgress(this.method_3);
                    this.class107_0.HnFdepcbbe(this.thread_0 == null);
                    this.manualResetEvent_0.WaitOne();
                    this.manualResetEvent_0.Reset();
                    if (this.bool_0)
                    {
                        return;
                    }
                }
            }
            DirectoryInfo[] directories = info4.GetDirectories();
            if (comparison_1 == null)
            {
                comparison_1 = new Comparison<DirectoryInfo>(DirectorySender.smethod_4);
            }
            Array.Sort<DirectoryInfo>(directories, comparison_1);
            for (num = 0; num < directories.Length; num++)
            {
                DirectoryInfo info3 = directories[num];
                this.DoSend(info3.FullName);
                if (this.bool_0)
                {
                    return;
                }
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.FileTransceiver.DirectorySender.DoSend", ErrorLevel.Standard);
        }
    }

    private void method_3(string string_4, ulong ulong_4, ulong ulong_5)
    {
        this.ulong_2 = this.ulong_1 + ulong_5;
        this.FileTransProgress(this.string_3, this.ulong_0, this.ulong_2);
        if (ulong_4 == ulong_5)
        {
            this.ulong_1 += ulong_4;
        }
    }

    private void OnFileTransDisruptted(string string_4, FileTransDisrupttedType fileTransDisrupttedType_1, string string_5)
    {
        lock (this.object_1)
        {
            if (this.bool_0)
            {
                return;
            }
            this.bool_0 = true;
        }
        this.manualResetEvent_0.Set();
        this.FileTransDisruptted(this.string_3, fileTransDisrupttedType_1, string_5);
    }

    public void method_5()
    {
        this.manualResetEvent_0.Set();
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

    [CompilerGenerated]
    private static int smethod_3(FileSystemInfo fileSystemInfo_0, FileSystemInfo fileSystemInfo_1)
    {
        return fileSystemInfo_0.Name.CompareTo(fileSystemInfo_1.Name);
    }

    [CompilerGenerated]
    private static int smethod_4(FileSystemInfo fileSystemInfo_0, FileSystemInfo fileSystemInfo_1)
    {
        return fileSystemInfo_0.Name.CompareTo(fileSystemInfo_1.Name);
    }
}

