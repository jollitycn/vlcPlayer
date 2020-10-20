using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJFramework;
using CJFramework.Engine.Tcp.Passive;
using CJPlus;
using CJPlus.Advanced;
using CJPlus.Application;
using CJPlus.Application.Basic;
using CJPlus.Application.Basic.Passive;
using CJPlus.Application.Contacts;
using CJPlus.Application.Contacts.Passive;
using CJPlus.Application.CustomizeInfo;
using CJPlus.Application.CustomizeInfo.Passive;
using CJPlus.Application.FileTransfering;
using CJPlus.Application.FileTransfering.Passive;
using CJPlus.Application.Friends;
using CJPlus.Application.Friends.Passive;
using CJPlus.Application.Group;
using CJPlus.Application.Group.Passive;
using CJPlus.Application.P2PSession;
using CJPlus.Application.P2PSession.Passive;
using CJPlus.Core;
using CJPlus.Rapid;
using System;
using System.Threading;

public class RapidPassiveEngine : IRapidEngine, CJPlus.Rapid.IRapidPassiveEngine
{
    private AdvancedOptions advancedOptions_0 = new AdvancedOptions();
    private AgileIPE agileIPE_0;
    private bool bool_0 = false;
    private bool bool_1 = false;
    private bool bool_2 = false;
    private bool bool_3 = false;
    private bool bool_4 = false;
    private bool bool_5 = true;
    private TcpPassiveEngine class108_0;
    private BasicOutter class113_0;
    private FriendsOutter class126_0;
    private ContactsOutter ContactsOutter_0;
    private FileHandler class13_0;
    private Class141 class141_0;
    private GroupOutter2 class19_0;
    private FileTransfering class2_0;
    private Class28 class28_0;
    private Class43 class43_0;
    private P2PController class58_0;
    private Class71 class71_0;
    private Class72 class72_0;
    private Delegate delegate_0;
    private Delegate delegate_1;
    private EmptyAgileLogger emptyAgileLogger_0 = null;
    private EventSafeTrigger eventSafeTrigger_0 = new EventSafeTrigger(new EmptyAgileLogger(), "XtxuKNjYrWlx9Xcr02U.a3a8sNjwrXpkp4McaV0");
    private int int_0 = 10;
    private int int_1 = 30;
    private Interface26 object_0;
    private CJFramework.Engine.Tcp.Passive.Sock5ProxyInfo sock5ProxyInfo_0;
    private string string_0 = "";
    private string string_1 = (AppDomain.CurrentDomain.BaseDirectory + "CJFrameworkLog.txt");
    private string systemToken = "";
    private string string_3 = "";

    public event CbGeneric ConnectionInterrupted
    {
        add
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_0;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Combine(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
        remove
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_0;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Remove(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
    }

    public event CbGeneric ConnectionRebuildStart
    {
        add
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_1;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Combine(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
        remove
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_1;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Remove(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
    }

    public event CbGeneric<string, int, byte[], string> MessageReceived;

    public event CbGeneric<LogonResponse> RelogonCompleted;

    public void Close()
    {
        if (this.object_0 != null)
        {
            this.class71_0.method_1();
            this.class72_0.Dispose();
            this.class141_0.Dispose();
            this.class28_0.Dispose();
            this.class2_0.Dispose();
            this.object_0.AutoReconnect = false;
            this.object_0.Dispose();
            if (this.class58_0 != null)
            {
                this.class58_0.Dispose();
            }
        }
    }

    public void CloseConnection(bool reconnectNow)
    {
        this.object_0.CloseConnection(reconnectNow);
    }

    public LogonResponse Initialize(string userID, string logonPassword, string serverIP, int serverPort, ICustomizeHandler customizeHandler)
    {
        if (this.emptyAgileLogger_0 == null)
        {
            if (this.string_1 == null)
            {
                this.emptyAgileLogger_0 = new EmptyAgileLogger();
            }
            else
            {
                FileAgileLogger logger = new FileAgileLogger(this.string_1) {
                    MaxLength4ChangeFile = 0x100000L
                };
                this.emptyAgileLogger_0 = (EmptyAgileLogger) logger;
            }
        }
        this.eventSafeTrigger_0.AgileLogger = this.emptyAgileLogger_0;
        this.string_0 = logonPassword;
        Class16 class2 = new Class16();
        MessageForbiddenHandler class3 = new MessageForbiddenHandler();
        this.object_0 = Class157.CreateInterface26((Enum6) 0);
        int num = (!this.advancedOptions_0.CheckResponseTTL4Query || !this.bool_4) ? 10 : 0;
        this.class72_0 = new Class72(num, this.int_1);
        this.class72_0.SetEngine((IEngine) this.object_0);
        Interface36 interface2 = new Class94((ICommitMessageToServer) this.object_0, class3, null);
        Class79 class4 = new Class79(this.class72_0, interface2);
        BasicMessageTypeRoom room = new BasicMessageTypeRoom();
        room.Initialize();
        CustomizeMessageTypeRoom room2 = new CustomizeMessageTypeRoom();
        room2.Initialize();
        FileMessageTypeRoom room3 = new FileMessageTypeRoom();
        room3.Initialize();
        P2PSessionMessageTypeRoom room4 = new P2PSessionMessageTypeRoom();
        room4.Initialize();
        FriendsMessageTypeRoom room5 = new FriendsMessageTypeRoom();
        room5.Initialize();
        GroupMessageTypeRoom room6 = new GroupMessageTypeRoom();
        room6.Initialize();
        ContactsMessageTypeRoom room7 = new ContactsMessageTypeRoom();
        room7.Initialize();
        this.class113_0 = new BasicOutter();
        this.class113_0.SetBasicMessageTypeRoom(room);
        this.class113_0.SetActionType(class4);
        this.class113_0.SetStreamContract(class2);
        this.class113_0.SetICommitMessageToServer((ICommitMessageToServer) this.object_0);
        this.class113_0.NgadStsqsh += new CbGeneric(this.method_1);
        this.class113_0.method_2(userID);
        this.class71_0 = new Class71(this.class113_0, this.bool_4 ? 0 : this.int_0);
        Class78 class9 = new Class78();
        class9.method_5(this.class113_0);
        class9.method_1(room);
        class9.method_2(class2);
        class9.method_4((ICommitMessageToServer) this.object_0);
        class9.method_3(class4);
        this.class43_0 = new Class43();
        this.class43_0.method_5(class4);
        this.class43_0.method_4(class2);
        this.class43_0.method_3(room2);
        this.class43_0.method_1(userID);
        CustomizeProcess class10 = new CustomizeProcess();
        class10.SetStreamContractHelper(class2);
        class10.SetCustomizeHandler(customizeHandler);
        class10.SetCustomizeMessageTypeRoom(room2);
        class10.SetActionType(class4);
        class10.Event_0 += new CbGeneric<string, int, byte[], string>(this.OnMessageReceived);
        Class75 class7 = new Class75(class4, class2, room4);
        class7.method_1(userID);
        Class24 class8 = new Class24();
        class8.method_0(room4);
        class8.method_1(class2);
        class8.DaTyrcXefU(class7);
        this.class2_0 = new FileTransfering();
        this.class2_0.method_0(this.emptyAgileLogger_0);
        this.class13_0 = new FileHandler();
        this.class13_0.method_0(this.emptyAgileLogger_0);
        this.class2_0.TTL4ResumedFileItem = this.advancedOptions_0.TempFile4ResumedTTL;
        this.class13_0.method_1(class4);
        this.class13_0.method_3(class2);
        this.class13_0.imethod_1(0x100000);
        this.class13_0.method_7(this.advancedOptions_0.UseWorkThreadPool);
        this.class13_0.Initialize(userID, room3.FilePackageData);
        this.class28_0 = new Class28();
        this.class28_0.method_2(this.advancedOptions_0.CheckFileZeroSpeedSpanInSecs);
        this.class28_0.method_0(this.emptyAgileLogger_0);
        this.class28_0.method_13(room3);
        this.class28_0.method_14(class2);
        this.class28_0.method_16(class4);
        this.class28_0.method_12(this.class2_0);
        this.class28_0.method_11(this.class13_0);
        this.class28_0.Initialize(userID);
        Class70 class11 = new Class70();
        class11.method_0(room3);
        class11.method_1(class2);
        class11.method_3(this.class13_0);
        class11.method_2(this.class2_0);
        class11.method_4(this.class28_0);
        this.class126_0 = new FriendsOutter();
        this.class126_0.method_4(class4);
        this.class126_0.method_3(class2);
        this.class126_0.method_2(room5);
        this.class126_0.FriendOffline += new CbGeneric<string>(this.method_6);
        this.class126_0.method_1(userID);
        Class59 class12 = new Class59();
        class12.method_2(class2);
        class12.method_3(this.class126_0);
        class12.method_1(room5);
        this.class19_0 = new GroupOutter2();
        this.class19_0.method_0(class4);
        this.class19_0.uBkeyEkxPJ(class2);
        this.class19_0.Iibebiqvn1(room6);
        this.class19_0.SetCommitMessageToServer((ICommitMessageToServer) this.object_0);
        this.class19_0.GroupmateOffline += new CbGeneric<string>(this.method_7);
        this.class19_0.method_4(userID);
        Class140 class13 = new Class140();
        class13.method_0(room6);
        class13.method_2(this.class19_0);
        class13.method_1(class2);
        this.ContactsOutter_0 = new ContactsOutter();
        this.ContactsOutter_0.method_2(class4);
        this.ContactsOutter_0.SetStreamContract(class2);
        this.ContactsOutter_0.SetMessageType(room7);
        this.ContactsOutter_0.SetCommitMessageToServer((ICommitMessageToServer) this.object_0);
        this.ContactsOutter_0.ContactsOffline += new CbGeneric<string>(this.method_8);
        this.ContactsOutter_0.method_5(userID);
        Class20 class14 = new Class20();
        class14.SetMessageType(room7);
        class14.SetOutter(this.ContactsOutter_0);
        class14.SetStreamContract(class2);
        IProcess[] processers = new IProcess[] { class9, class10, class8, class11, class12, class13, class14 };
        this.class141_0 = new Class141(processers, this.class72_0);
        this.class141_0.method_6(this.advancedOptions_0.AsynMessageQueueEnabled && !this.bool_4);
        this.class141_0.method_7(class4);
        this.class141_0.method_4(this.emptyAgileLogger_0);
        this.class141_0.method_8();
        new Class40(new IMessageTypeRoom[] { room, room2, room3, room4, room5, room6, room7 }, this.class141_0).method_2();
        MessageDispatcher class6 = new MessageDispatcher(new Class144(new Class115(this.class141_0)), class3);
        class6.imethod_0(this.emptyAgileLogger_0);
        this.object_0.SetAgileLogger(this.emptyAgileLogger_0);
        this.object_0.Sock5ProxyInfo = this.sock5ProxyInfo_0;
        this.object_0.SetAgileIPE(new AgileIPE(serverIP, serverPort));
        this.object_0.SetStreamContract(class2);
        this.object_0.imethod_12(class6);
        this.object_0.imethod_10(GlobalUtil.MaxLengthOfMessage);
        this.object_0.AutoReconnect = false;
        this.object_0.imethod_23((this.advancedOptions_0.WriteTimeoutInSecs <= 0) ? -1 : (this.advancedOptions_0.WriteTimeoutInSecs * 0x3e8));
        this.object_0.SocketSendBuffSize = this.advancedOptions_0.SocketSendBuffSize;
        this.object_0.UncompletedSendingCount4Busy = this.advancedOptions_0.UncompletedSendingCount4Busy;
        this.object_0.ConnectionInterrupted += new CbGeneric(this.method_5);
        this.object_0.imethod_25(new CbGeneric(this.method_4));
        this.object_0.ConnectionRebuildStart += new CbGeneric(this.method_2);
        this.object_0.Initialize();
        LogonFullResponse response = this.class113_0.method_7(this.systemToken, this.string_0);
        if (response.LogonResult != LogonResult.Succeed)
        {
            this.object_0.OnDispose();
            return response;
        }
        this.object_0.imethod_27();
        this.bool_0 = response.Boolean_0;
        this.bool_3 = response.GroupRelationEnabled;
        if ((this.bool_0 && this.advancedOptions_0.Boolean_0) && !this.bool_4)
        {
            if (response.UseAsP2PServer && (this.agileIPE_0 == null))
            {
                this.agileIPE_0 = new AgileIPE(this.object_0.GetAgileIPE().String_0, this.object_0.GetAgileIPE().Port + 1);
            }
            if (this.agileIPE_0 != null)
            {
                this.class58_0 = new P2PController();
                this.class58_0.method_6(this.agileIPE_0);
                this.class58_0.method_5(this.emptyAgileLogger_0);
                this.class58_0.method_3((Interface26) this.object_0);
                this.class58_0.method_2(class7);
                this.class58_0.method_4(room4);
                this.class58_0.P2PChannelClosed += new CbGeneric<P2PChannelState>(this.method_3);
                this.class58_0.method_7(userID, this.bool_2);
                interface2.imethod_2(this.class58_0);
                class8.method_2(this.class58_0);
                this.class13_0.method_4(new Class56(this.class58_0));
                this.class19_0.method_1(this.class58_0);
            }
        }
        if (this.bool_2)
        {
            this.class108_0 = new TcpPassiveEngine((Interface26) this.object_0, this.class113_0, this.emptyAgileLogger_0);
            this.class108_0.method_3();
        }
        this.class71_0.method_0();
        this.class113_0.SendHeartBeatMessage();
        this.string_3 = userID;
        this.bool_1 = true;
        this.object_0.AutoReconnect = this.bool_5;
        return response;
    }

    private void OnMessageReceived(string string_4, int int_2, byte[] byte_0, string string_5)
    {
        if (this.MessageReceived != null)
        {
            this.MessageReceived(string_4, int_2, byte_0, string_5);
        }
    }

    private void method_1()
    {
        new CbGeneric(this.Close).BeginInvoke(null, null);
    }

    private void method_2()
    {
        this.eventSafeTrigger_0.Action("ConnectionRebuildStart", this.delegate_1);
    }

    private void method_3(P2PChannelState p2PChannelState_0)
    {
        if (p2PChannelState_0.Reliable)
        {
            this.class2_0.imethod_8(p2PChannelState_0.DestUserID);
            this.class13_0.imethod_11(p2PChannelState_0.DestUserID);
        }
    }

    private void method_4()
    {
        try
        {
            LogonResponse response = this.class113_0.method_7(this.systemToken, this.string_0);
            if (response.LogonResult == LogonResult.Succeed)
            {
                this.object_0.imethod_27();
                this.class71_0.method_0();
                this.class113_0.SendHeartBeatMessage();
            }
            else
            {
                this.object_0.AutoReconnect = false;
            }
            this.eventSafeTrigger_0.Action<LogonResponse>("RelogonCompleted", this.RelogonCompleted, response);
        }
        catch (Exception exception)
        {
            LogonFullResponse response2 = new LogonFullResponse(LogonResult.Failed, exception.Message, false, false, false);
            this.eventSafeTrigger_0.Action<LogonResponse>("RelogonCompleted", this.RelogonCompleted, response2);
        }
    }

    private void method_5()
    {
        try
        {
            this.class2_0.imethod_6();
            this.class13_0.imethod_9();
            this.class71_0.method_1();
            this.eventSafeTrigger_0.Action("ConnectionInterrupted", this.delegate_0);
        }
        catch
        {
        }
    }

    private void method_6(string string_4)
    {
        this.class2_0.imethod_7(string_4);
        this.class13_0.imethod_10(string_4);
        if (this.class58_0 != null)
        {
            this.class58_0.Close(string_4);
        }
    }

    private void method_7(string string_4)
    {
        this.class2_0.imethod_7(string_4);
        this.class13_0.imethod_10(string_4);
        if (this.class58_0 != null)
        {
            this.class58_0.Close(string_4);
        }
    }

    private void method_8(string string_4)
    {
        this.class2_0.imethod_7(string_4);
        this.class13_0.imethod_10(string_4);
        if (this.class58_0 != null)
        {
            this.class58_0.Close(string_4);
        }
    }

    private void method_9(string string_4, int int_2, byte[] byte_0, string string_5, int int_3, ResultHandler resultHandler_0, object object_1)
    {
        try
        {
            this.SendMessage(string_4, int_2, byte_0, string_5, int_3);
            if (resultHandler_0 != null)
            {
                resultHandler_0(true, object_1);
            }
        }
        catch (Exception)
        {
            if (resultHandler_0 != null)
            {
                resultHandler_0(false, object_1);
            }
        }
    }

    public void SendMessage(string targetUserID, int informationType, byte[] message, string tag)
    {
        this.SendMessage(targetUserID, informationType, message, tag, GlobalUtil.MaxLengthOfMessage - 200);
    }

    public void SendMessage(string targetUserID, int informationType, byte[] message, string tag, int fragmentSize)
    {
        this.class43_0.method_9(targetUserID, informationType, message, tag, fragmentSize);
    }

    public void SendMessage(string targetUserID, int informationType, byte[] message, string tag, int fragmentSize, ResultHandler handler, object handlerTag)
    {
        new CbGeneric<string, int, byte[], string, int, ResultHandler, object>(this.method_9).BeginInvoke(targetUserID, informationType, message, tag, fragmentSize, handler, handlerTag, null, null);
    }

    public AdvancedOptions Advanced
    {
        get
        {
            return this.advancedOptions_0;
        }
    }

    public bool AutoReconnect
    {
        get
        {
            return this.bool_5;
        }
        set
        {
            if (this.bool_1 && (value != this.bool_5))
            {
                throw new Exception("Can't change the value of AutoReconnect after initialized");
            }
            this.bool_5 = value;
        }
    }

    public IBasicOutter BasicOutter
    {
        get
        {
            return this.class113_0;
        }
    }

    public bool ChannelIsBusy
    {
        get
        {
            return this.object_0.ChannelIsBusy;
        }
    }

    public bool Connected
    {
        get
        {
            if (this.object_0 == null)
            {
                return false;
            }
            return this.object_0.imethod_21();
        }
    }

    public IContactsOutter ContactsOutter
    {
        get
        {
            return this.ContactsOutter_0;
        }
    }

    public string CurrentUserID
    {
        get
        {
            if (!this.bool_1)
            {
                throw new Exception("Can't get the value of CurrentUserID before initialized");
            }
            return this.string_3;
        }
    }

    public ICustomizeOutter CustomizeOutter
    {
        get
        {
            return this.class43_0;
        }
    }

    public CJPlus.Application.FileTransfering.Passive.IFileOutter FileOutter
    {
        get
        {
            return this.class28_0;
        }
    }

    public IFriendsOutter FriendsOutter
    {
        get
        {
            return this.class126_0;
        }
    }

    public IGroupOutter GroupOutter
    {
        get
        {
            if (!this.bool_3)
            {
                throw new Exception("Group relation is not enabled. please set GroupManager property of server engine to enable group relation before its initializing ");
            }
            return this.class19_0;
        }
    }

    public int HeartBeatSpanInSecs
    {
        get
        {
            return this.int_0;
        }
        set
        {
            if (this.bool_1 && (value != this.int_0))
            {
                throw new Exception("Can't change the value of HeartBeatSpanInSecs after initialized");
            }
            this.int_0 = value;
        }
    }

    public string LogFilePath
    {
        get
        {
            return this.string_1;
        }
        set
        {
            this.string_1 = value;
        }
    }

    public IAgileLogger Logger
    {
        set
        {
            this.emptyAgileLogger_0 = (EmptyAgileLogger) value;
        }
    }

    public IP2PController P2PController
    {
        get
        {
            if (!this.bool_0)
            {
                throw new Exception("本次授权未开启P2P功能！");
            }
            return this.class58_0;
        }
    }

    public AgileIPE P2PServerAddress
    {
        get
        {
            return this.agileIPE_0;
        }
        set
        {
            if (this.bool_1 && (value != this.agileIPE_0))
            {
                throw new Exception("Can't change the value of P2PServerAddress after initialized");
            }
            this.agileIPE_0 = value;
        }
    }

    public bool SecurityLogEnabled
    {
        get
        {
            return this.bool_2;
        }
        set
        {
            this.bool_2 = value;
        }
    }

    public AgileIPE ServerAddress
    {
        get
        {
            if (this.object_0 == null)
            {
                return null;
            }
            return this.object_0.GetAgileIPE();
        }
    }

    public CJFramework.Engine.Tcp.Passive.Sock5ProxyInfo Sock5ProxyInfo
    {
        get
        {
            return this.sock5ProxyInfo_0;
        }
        set
        {
            if (this.bool_1 && (value != this.sock5ProxyInfo_0))
            {
                throw new Exception("Can't change the value of Sock5ProxyInfo after initialized");
            }
            this.sock5ProxyInfo_0 = value;
        }
    }

    public bool StressTesting
    {
        get
        {
            return this.bool_4;
        }
        set
        {
            this.bool_4 = value;
        }
    }

    public string SystemToken
    {
        get
        {
            return this.systemToken;
        }
        set
        {
            this.systemToken = value;
        }
    }

    public int WaitResponseTimeoutInSecs
    {
        get
        {
            return this.int_1;
        }
        set
        {
            if (this.bool_1 && (value != this.int_1))
            {
                throw new Exception("Can't change the value of WaitResponseTimeoutInSecs after initialized");
            }
            this.int_1 = value;
        }
    }
}

