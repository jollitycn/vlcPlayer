using CJBasic;
using CJBasic.Loggers;
using CJFramework.Server;
using CJFramework.Server.UserManagement;
using CJPlus;
using CJPlus.Advanced;
using CJPlus.Application.Basic;
using CJPlus.Application.Basic.Server;
using CJPlus.Application.Contacts;
using CJPlus.Application.Contacts.Server;
using CJPlus.Application.CustomizeInfo;
using CJPlus.Application.CustomizeInfo.Server;
using CJPlus.Application.FileTransfering;
using CJPlus.Application.FileTransfering.Server;
using CJPlus.Application.Friends;
using CJPlus.Application.Friends.Server;
using CJPlus.Application.Group;
using CJPlus.Application.Group.Server;
using CJPlus.Application.P2PSession;
using CJPlus.Core;
using CJPlus.Rapid;
using System;
using System.Net;
using System.Threading;

internal class ServerEngine : IRapidEngine, IRapidServerEngine, Interface41
{
    private bool bool_0 = false;
    private bool bool_1 = false;
    private bool bool_2 = false;
    private bool bool_3 = true;
    private bool bool_4 = true;
    private Server class112_0;
    private FileHandler class13_0;
    private Class135 class135_0;
    private GroupOutter class139_0 = new GroupOutter();
    private Class159 class159_0;
    private Class17 class17_0;
    private FileTransfering class2_0;
    private Class21 class21_0 = new Class21();
    private Class25 class25_0 = new Class25();
    private Parameterized class27_0;
    private Class40 class40_0;
    private ContactsMessageHandler class60_0 = new ContactsMessageHandler();
    private Class64 class64_0 = new Class64();
    private UserManager class98_0;
    private EmptyAgileLogger emptyAgileLogger_0 = null;
    private IContactsManager icontactsManager_0;
    private IFriendsManager ifriendsManager_0;
    private IGroupManager igroupManager_0;
    private int int_0 = 0;
    private int int_1 = 0;
    private int int_2 = 30;
    private int int_3 = 30;
    private IConnection object_0;
    private IP2PServer object_1;
    private string string_0 = (AppDomain.CurrentDomain.BaseDirectory + "CJFrameworkLog.txt");
    private string string_1 = null;
    private CJPlus.Rapid.WssOptions wssOptions_0 = null;

    public event CbGeneric<string, int, byte[], string> MessageReceived;

    public void Close()
    {
        if (this.object_0 != null)
        {
            this.object_0.Dispose();
        }
        if (this.object_1 != null)
        {
            this.object_1.Dispose();
        }
        if (this.class27_0 != null)
        {
            this.class27_0.Dispose();
        }
        if (this.class2_0 != null)
        {
            this.class2_0.Dispose();
        }
        if (this.class98_0 != null)
        {
            this.class98_0.Dispose();
        }
        this.bool_0 = false;
    }

    public bool imethod_0(IPEndPoint ipendPoint_0, Enum4 enum4_0, IMessageHandler interface37_0)
    {
        bool flag;
        if (enum4_0 != ((Enum4) 0))
        {
            return true;
        }
        if (!(flag = ((interface37_0.Header.MessageType == this.int_0) || (interface37_0.Header.MessageType == this.int_1)) || (interface37_0.Header.MessageType == 100)))
        {
            string msg = string.Format("First Message Verify failed ！Address:{0},Message Type:{1},UserID:{2},ClientType:{3}", new object[] { ipendPoint_0, interface37_0.Header.MessageType, interface37_0.Header.UserID, (int) interface37_0.Header.GetClientType() });
            this.emptyAgileLogger_0.LogWithTime(msg);
        }
        return flag;
    }

    public void Initialize(int port, ICustomizeHandler customizeHandler)
    {
        this.Initialize(port, customizeHandler, null);
    }

    public void Initialize(int port, ICustomizeHandler customizeHandler, IBasicHandler basicHandler)
    {
        if (this.emptyAgileLogger_0 == null)
        {
            if (this.string_0 == null)
            {
                this.emptyAgileLogger_0 = new EmptyAgileLogger();
            }
            else
            {
                FileAgileLogger logger = new FileAgileLogger(this.string_0) {
                    MaxLength4ChangeFile = 0x100000L
                };
                this.emptyAgileLogger_0 = (EmptyAgileLogger) logger;
            }
        }
        Class16 class4 = new Class16();
        MessageForbiddenHandler class8 = new MessageForbiddenHandler();
        CJPlus.Rapid.WssOptions options = this.wssOptions_0 ?? new CJPlus.Rapid.WssOptions();
        this.object_0 = Class157.smethod_0((Enum6) 0, true, options.X509Certificate2, options.SslProtocols, options.OnlyWssClient);
        BasicMessageTypeRoom room3 = new BasicMessageTypeRoom();
        room3.Initialize();
        this.int_0 = room3.Logon;
        this.int_1 = room3.HeartBeat;
        CustomizeMessageTypeRoom room4 = new CustomizeMessageTypeRoom();
        room4.Initialize();
        FileMessageTypeRoom room2 = new FileMessageTypeRoom();
        room2.Initialize();
        P2PSessionMessageTypeRoom room = new P2PSessionMessageTypeRoom();
        room.Initialize();
        FriendsMessageTypeRoom room5 = new FriendsMessageTypeRoom();
        room5.Initialize();
        GroupMessageTypeRoom room6 = new GroupMessageTypeRoom();
        room6.Initialize();
        ContactsMessageTypeRoom room7 = new ContactsMessageTypeRoom();
        room7.Initialize();
        this.class40_0 = new Class40(new IMessageTypeRoom[] { room3, room4, room2, room, room5, room6, room7 }, null);
        this.class40_0.method_2();
        this.class98_0 = new UserManager();
        this.class98_0.RelogonMode = RelogonMode.ReplaceOld;
        this.class98_0.method_2(this.int_2);
        this.class98_0.SetAgileLogger(this.emptyAgileLogger_0);
        this.class98_0.method_3((IConnection) this.object_0);
        this.class98_0.Initialize();
        this.class135_0 = new Class135(this.class98_0);
        RegularSender class5 = new RegularSender();
        class5.method_0(this.class98_0);
        class5.method_2(class8);
        class5.method_1((IAction) this.object_0);
        class5.method_3(this.emptyAgileLogger_0);
        if (basicHandler == null)
        {
            basicHandler = new EmptyBasicHandler();
        }
        Class159 class7 = new Class159();
        class7.Event_0 += new CbGeneric<string, IPEndPoint>(this.OnConnectionBound);
        class7.method_1(room3);
        class7.method_3(class4);
        class7.method_2(this.class98_0);
        class7.method_7(this.bool_2);
        class7.method_5(class5);
        class7.method_8(this.class21_0.DiagnosticsEnabled ? this.class64_0 : basicHandler);
        class7.method_9(this.class135_0);
        class7.method_10(this.igroupManager_0 != null);
        class7.method_12(this.bool_3);
        class7.method_14(this.bool_4);
        class7.method_15();
        this.class159_0 = class7;
        if (customizeHandler == null)
        {
            customizeHandler = new EmptyCustomizeHandler();
        }
        Server class2 = new Server();
        class2.SetStreamContract(class4);
        class2.SetAgileLogger(this.emptyAgileLogger_0);
        class2.SetICustomizeHandler(this.class21_0.DiagnosticsEnabled ? this.class64_0 : customizeHandler);
        class2.SetCustomizeMessageTypeRoom(room4);
        class2.method_1(class5);
        class2.SetUserManager(this.class98_0);
        class2.method_8(this.int_3);
        class2.method_11(this.class21_0.CheckResponseTTL4Query ? 10 : 0);
        class2.method_9(this.class135_0);
        class2.Event_0 += new CbGeneric<string, int, byte[], string>(this.method_6);
        class2.method_14(this.class21_0.CustomizeInfoHandleMode, this.class21_0.QueueWorkerThreadCount);
        this.class21_0.method_0((IConnection) this.object_0, this.class21_0.DiagnosticsEnabled ? this.class64_0.method_0() : null, class2.method_13());
        this.class112_0 = class2;
        Class132 class3 = new Class132();
        class3.method_1(room);
        class3.method_0(class4);
        class3.method_2(class5);
        class3.method_3(this.class98_0);
        class3.method_4(this.class135_0);
        class3.method_5(this.emptyAgileLogger_0);
        this.class2_0 = new FileTransfering();
        this.class2_0.method_0(this.emptyAgileLogger_0);
        this.class13_0 = new FileHandler();
        this.class13_0.method_0(this.emptyAgileLogger_0);
        this.class2_0.TTL4ResumedFileItem = this.class21_0.TempFile4ResumedTTL;
        this.class13_0.method_2(class5);
        this.class13_0.method_3(class4);
        this.class13_0.imethod_1(0x100000);
        this.class13_0.method_4(new Class3(0x800));
        this.class13_0.method_7(this.class21_0.UseWorkThreadPool);
        this.class13_0.Initialize("_0", room2.FilePackageData);
        this.class27_0 = new Parameterized(port);
        this.class27_0.method_2(this.class21_0.CheckFileZeroSpeedSpanInSecs);
        this.class27_0.method_0(this.emptyAgileLogger_0);
        this.class27_0.method_11(this.class13_0);
        this.class27_0.method_13(room2);
        this.class27_0.method_12(this.class2_0);
        this.class27_0.method_14(class4);
        this.class27_0.method_15(class5);
        this.class27_0.method_3("_0");
        Class69 class6 = new Class69();
        class6.method_0(room2);
        class6.method_6(class5);
        class6.method_1(class4);
        class6.method_3(this.class13_0);
        class6.method_2(this.class2_0);
        class6.method_4(this.class27_0);
        this.class98_0.SomeOneDisconnected += new CbGeneric<UserData, DisconnectedType>(this.method_8);
        this.class25_0.method_6(this.class21_0.DiagnosticsEnabled ? this.class64_0 : this.ifriendsManager_0);
        this.class25_0.method_1(room5);
        this.class25_0.method_7(this.class135_0);
        this.class25_0.method_3(class4);
        this.class25_0.method_5(class5);
        this.class25_0.method_2(this.class98_0);
        this.class25_0.method_9();
        this.class139_0.SetMessageTypeRoom(room6);
        this.class139_0.method_2(class4);
        this.class139_0.method_4(class5);
        this.class139_0.method_0(this.class98_0);
        this.class139_0.SetGroupManager(this.class21_0.DiagnosticsEnabled ? this.class64_0 : this.igroupManager_0);
        this.class139_0.method_6(this.class135_0);
        this.class139_0.Init();
        this.class60_0.method_1(room7);
        this.class60_0.method_2(class4);
        this.class60_0.method_4(class5);
        this.class60_0.method_0(this.class98_0);
        this.class60_0.method_5(this.class21_0.DiagnosticsEnabled ? this.class64_0 : this.icontactsManager_0);
        this.class60_0.method_6(this.class135_0);
        this.class60_0.method_7();
        IProcess[] processers = new IProcess[] { class7, class2, class6, class3, this.class25_0, this.class139_0, this.class60_0 };
        MessageDispatcher class9 = new MessageDispatcher(new Class144(new Class115(processers)), class8);
        class9.imethod_0(this.emptyAgileLogger_0);
        this.object_0.imethod_22(this);
        this.object_0.SetAgileLogger(this.emptyAgileLogger_0);
        this.object_0.LjXdpkRter(this.string_1);
        this.object_0.SetData(port);
        this.object_0.imethod_10(GlobalUtil.MaxLengthOfMessage);
        this.object_0.SetStreamContract(class4);
        this.object_0.imethod_12(class9);
        this.object_0.SocketSendBuffSize = this.class21_0.SocketSendBuffSize;
        this.object_0.imethod_26((this.class21_0.WriteTimeoutInSecs <= 0) ? -1 : (this.class21_0.WriteTimeoutInSecs * 0x3e8));
        this.object_0.MaxChannelCacheSize = this.class21_0.MaxChannelCacheSize;
        this.object_0.Boolean_0 = this.class21_0.Boolean_0;
        this.object_0.AsynConnectionEvent = this.class21_0.AsynConnectionEvent;
        this.object_0.UncompletedSendingCount4Busy = this.class21_0.UncompletedSendingCount4Busy;
        ((BaseTcpEngine) this.object_0).method_1(new Class119(class2, this.class98_0));
        this.object_0.Initialize();
        if (this.bool_1)
        {
            this.class17_0 = new Class17(this.class98_0, new SecurityFileLogger(this.emptyAgileLogger_0));
            this.class17_0.method_2();
        }
        if (this.bool_3)
        {
            this.object_1 = this.method_9(port + 1);
        }
        this.class64_0.ieduNnurne(customizeHandler, basicHandler, this.igroupManager_0, this.ifriendsManager_0, this.icontactsManager_0);
        this.bool_0 = true;
    }

    public bool method_0()
    {
        return ((this.object_0 == null) || ((BaseTcpEngine) this.object_0).method_0());
    }

    public bool method_4()
    {
        return this.bool_4;
    }

    public void method_5(bool bool_5)
    {
        if (this.bool_0 && (bool_5 != this.method_4()))
        {
            throw new Exception("Can't change the value of P2PEnabled after initialized");
        }
        this.bool_4 = bool_5;
    }

    private void method_6(string string_2, int int_4, byte[] byte_0, string string_3)
    {
        if (this.MessageReceived != null)
        {
            if (!this.class21_0.DiagnosticsEnabled)
            {
                this.MessageReceived(string_2, int_4, byte_0, string_3);
            }
            else
            {
                int num = this.class64_0.method_0().method_0(int_4, InformationStyle.DirectByRapidEngine);
                bool flag = false;
                try
                {
                    this.MessageReceived(string_2, int_4, byte_0, string_3);
                }
                catch
                {
                    flag = true;
                    throw;
                }
                finally
                {
                    this.class64_0.method_0().method_1(num, flag);
                }
            }
        }
    }

    private void OnConnectionBound(string string_2, IPEndPoint ipendPoint_0)
    {
        this.object_0.OnConnectionBound(ipendPoint_0, string_2);
    }

    private void method_8(UserData userData_0, DisconnectedType disconnectedType_0)
    {
        if (this.class2_0 != null)
        {
            this.class2_0.imethod_7(userData_0.UserID);
            this.class13_0.imethod_10(userData_0.UserID);
        }
    }

    private IP2PServer method_9(int int_4)
    {
        P2PServer class2 = new P2PServer();
        class2.Initialize(int_4);
        return class2;
    }

    public void SendMessage(string targetUserID, int informationType, byte[] message, string tag)
    {
        this.SendMessage(targetUserID, informationType, message, tag, GlobalUtil.MaxLengthOfMessage - 200);
    }

    public void SendMessage(string targetUserID, int informationType, byte[] message, string tag, int fragmentSize)
    {
        if (this.bool_0)
        {
            this.class112_0.Send(targetUserID, informationType, message, tag, fragmentSize);
        }
    }

    public GInterface3 Advanced
    {
        get
        {
            return this.class21_0;
        }
    }

    public bool AutoRespondHeartBeat
    {
        get
        {
            return this.bool_2;
        }
        set
        {
            if (this.bool_0 && (value != this.bool_2))
            {
                throw new Exception("Can't change the value of AutoRespondHeartBeat after initialized");
            }
            this.bool_2 = value;
        }
    }

    public IBasicController BasicController
    {
        get
        {
            return this.class159_0;
        }
    }

    public int ConnectionCount
    {
        get
        {
            return this.object_0.ConnectionCount;
        }
    }

    public IContactsOutter ContactsController
    {
        get
        {
            if (this.icontactsManager_0 == null)
            {
                return null;
            }
            return this.class60_0;
        }
    }

    public IContactsManager ContactsManager
    {
        get
        {
            return this.icontactsManager_0;
        }
        set
        {
            if (this.bool_0 && (value != this.icontactsManager_0))
            {
                throw new Exception("Can't change the value of ContactsManager after initialized");
            }
            this.icontactsManager_0 = value;
        }
    }

    public GInterface CustomizeController
    {
        get
        {
            return this.class112_0;
        }
    }

    public IFileController FileController
    {
        get
        {
            return this.class27_0;
        }
    }

    public GInterface4 FriendsController
    {
        get
        {
            if (this.ifriendsManager_0 == null)
            {
                return null;
            }
            return this.class25_0;
        }
    }

    public IFriendsManager FriendsManager
    {
        get
        {
            return this.ifriendsManager_0;
        }
        set
        {
            if (this.bool_0 && (value != this.ifriendsManager_0))
            {
                throw new Exception("Can't change the value of FriendManager after initialized");
            }
            this.ifriendsManager_0 = value;
        }
    }

    public IGroupOutter GroupController
    {
        get
        {
            if (this.igroupManager_0 == null)
            {
                return null;
            }
            return this.class139_0;
        }
    }

    public IGroupManager GroupManager
    {
        get
        {
            return this.igroupManager_0;
        }
        set
        {
            if (this.bool_0 && (value != this.igroupManager_0))
            {
                throw new Exception("Can't change the value of GroupManager after initialized");
            }
            this.igroupManager_0 = value;
        }
    }

    public int HeartbeatTimeoutInSecs
    {
        get
        {
            return this.int_2;
        }
        set
        {
            if (this.bool_0 && (value != this.int_2))
            {
                throw new Exception("Can't change the value of HeartbeatTimeoutInSecs after initialized");
            }
            this.int_2 = value;
        }
    }

    public string IPAddressBinding
    {
        get
        {
            return this.string_1;
        }
        set
        {
            if (this.bool_0 && (value != this.string_1))
            {
                throw new Exception("Can't change the value of IPAddressBinding after initialized");
            }
            this.string_1 = value;
        }
    }

    public string LogFilePath
    {
        get
        {
            return this.string_0;
        }
        set
        {
            this.string_0 = value;
        }
    }

    public IAgileLogger Logger
    {
        set
        {
            this.emptyAgileLogger_0 = (EmptyAgileLogger) value;
        }
    }

    public int MaxConnectionCount
    {
        get
        {
            return this.object_0.MaxConnectionCount;
        }
    }

    public GInterface8 PlatformUserManager
    {
        get
        {
            return this.class135_0;
        }
    }

    public int Port
    {
        get
        {
            return this.object_0.Port;
        }
    }

    public bool SecurityLogEnabled
    {
        get
        {
            return this.bool_1;
        }
        set
        {
            this.bool_1 = value;
        }
    }

    public string ServerID
    {
        get
        {
            return this.object_0.ServerID;
        }
    }

    public IServiceTypeNameMatcher ServiceTypeNameMatcher
    {
        get
        {
            return this.class40_0;
        }
    }

    public bool UseAsP2PServer
    {
        get
        {
            return this.bool_3;
        }
        set
        {
            if (this.bool_0 && (value != this.bool_3))
            {
                throw new Exception("Can't change the value of UseAsP2PServer after initialized");
            }
            this.bool_3 = value;
        }
    }

    public IUserManager UserManager
    {
        get
        {
            return this.class98_0;
        }
    }

    public int WaitResponseTimeoutInSecs
    {
        get
        {
            return this.int_3;
        }
        set
        {
            if (this.bool_0 && (value != this.int_3))
            {
                throw new Exception("Can't change the value of WaitResponseTimeoutInSecs after initialized");
            }
            this.int_3 = value;
        }
    }

    public int WriteTimeoutInSecs
    {
        get
        {
            return this.class21_0.WriteTimeoutInSecs;
        }
        set
        {
            this.class21_0.WriteTimeoutInSecs = value;
        }
    }

    public CJPlus.Rapid.WssOptions WssOptions
    {
        get
        {
            return this.wssOptions_0;
        }
        set
        {
            this.wssOptions_0 = value;
        }
    }
}

