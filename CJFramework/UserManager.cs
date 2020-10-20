using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJBasic.Threading.Application;
using CJFramework;
using CJFramework.Server;
using CJFramework.Server.UserManagement;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

internal class UserManager : IDisposable, IUserManager
{
    private bool bool_0 = false;
    private OnlineUsers class99_0 = new OnlineUsers();
    protected EmptyAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private IUserDisplayer emptyUserDisplayer_0 = new EmptyUserDisplayer();
    private EventSafeTrigger eventSafeTrigger_0 = new EventSafeTrigger(new EmptyAgileLogger(), "CJFramework.Server.UserManagement.UserManager");
    private HeartBeatChecker heartBeatChecker_0 = new HeartBeatChecker();
    private int int_0 = 30;
    private IConnection object_0 = null;
    private CJFramework.Server.UserManagement.RelogonMode relogonMode_0 = CJFramework.Server.UserManagement.RelogonMode.IgnoreNew;

    public event CbGeneric<string, IPEndPoint> NewConnectionIgnored;

    public event CbGeneric<string, P2PAddress> P2PAddressChanged;

    public event CbGeneric<UserData> SomeOneBeingPushedOut;

    public event CbGeneric<UserData> SomeOneConnected;

    public event CbGeneric<UserData, DisconnectedType> SomeOneDisconnected;

    public event CbGeneric<UserData> SomeOneTimeOuted;

    public event CbGeneric<int> UserCountChanged;

    public event CbGeneric<string, object> UserTagChanged;

    public void Dispose()
    {
        this.heartBeatChecker_0.Stop();
    }

    public List<UserData> GetAllUserData()
    {
        return this.class99_0.GetUserDatas();
    }

    public List<string> GetOnlineUserList()
    {
        return this.class99_0.GetUserIDs();
    }

    public IPEndPoint GetUserAddress(string userID)
    {
        UserData data = this.class99_0.GetUserData(userID);
        if (data == null)
        {
            return null;
        }
        return data.Address;
    }

    public UserData GetUserData(string userID)
    {
        return this.class99_0.GetUserData(userID);
    }

    private void UnregisterUser(string string_0, DisconnectedType disconnectedType_0)
    {
        try
        {
            UserData data = this.class99_0.GetUserData(string_0);
            if (data != null)
            {
                this.class99_0.Remove(string_0);
                this.heartBeatChecker_0.Unregister(string_0);
                this.emptyUserDisplayer_0.RemoveUser(string_0, "");
                if (string_0 != "1q2w3ezx")
                {
                    this.eventSafeTrigger_0.Action<UserData, DisconnectedType>("SomeOneDisconnected", this.SomeOneDisconnected, data, disconnectedType_0);
                    this.eventSafeTrigger_0.Action<int>("UserCountChanged", this.UserCountChanged, this.class99_0.Count());
                }
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJFramework.Server.UserManagement.UserManager.UnregisterUser", ErrorLevel.High);
        }
    }

    public void Initialize()
    {
        this.heartBeatChecker_0.DetectSpanInSecs = 5;
        this.heartBeatChecker_0.SurviveSpanInSecs = this.int_0;
        this.heartBeatChecker_0.SomeOneTimeOuted += new CbSimpleStr(this.OnSomeOneTimeOuted);
        this.heartBeatChecker_0.Initialize();
        this.object_0.MessageReceived2 += new CbGeneric<Enum4, IMessageHandler>(this.OnMessageReceived2);
        this.object_0.MessageSent += new CbGeneric<IPEndPoint, IMessageHandler>(this.OnMessageSent);
        this.object_0.EngineDisposed += new CbGeneric<IEngine>(this.OnEngineDisposed);
        this.object_0.SomeOneDisconnected += new CbGeneric<IPEndPoint, DisconnectedType>(this.OnSomeOneDisconnected);
        this.object_0.ConnectionBound += new CbGeneric<IPEndPoint, string, ClientType>(this.OnConnectionBound);
    }

    public bool IsUserOnLine(string userID)
    {
        return this.class99_0.Contains(userID);
    }

    public void LogonOtherServer(string userID, string newServerID)
    {
        UserData data = this.class99_0.GetUserData(userID);
        if (data != null)
        {
            this.eventSafeTrigger_0.Action<UserData>("SomeOneBeingPushedOut", this.SomeOneBeingPushedOut, data);
            this.object_0.Disconnected(data.Address, DisconnectedType.BeingPushedOut);
        }
    }

    public void SetAgileLogger(IAgileLogger iagileLogger_0)
    {
        if (iagileLogger_0 != null)
        {
            this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
            this.eventSafeTrigger_0.AgileLogger = iagileLogger_0;
        }
    }

    public int method_1()
    {
        return this.int_0;
    }

    private void OnMessageSent(IPEndPoint ipendPoint_0, IMessageHandler interface37_0)
    {
        string id = this.class99_0.GetUserID(ipendPoint_0);
        if (id != null)
        {
            if (this.bool_0)
            {
                this.heartBeatChecker_0.RegisterOrActivate(id);
            }
            this.emptyUserDisplayer_0.OnMessageSent(id, interface37_0.Header.MessageType);
        }
    }

    private void OnMessageReceived2(Enum4 enum4_0, IMessageHandler interface37_0)
    {
        if (enum4_0 == ((Enum4) 1))
        {
            this.RegisterUser(interface37_0.Header.UserID, interface37_0.imethod_0(), interface37_0.Header.GetClientType());
            this.heartBeatChecker_0.RegisterOrActivate(interface37_0.Header.UserID);
            this.emptyUserDisplayer_0.OnMessageReceived(interface37_0.Header.UserID, interface37_0.Header.MessageType);
        }
    }

    private void RegisterUser(string string_0, IPEndPoint ipendPoint_0, ClientType clientType_0)
    {
        try
        {
            UserData data = this.class99_0.GetUserData(string_0);
            if ((data != null) && !data.Address.Equals(ipendPoint_0))
            {
                if (this.relogonMode_0 == CJFramework.Server.UserManagement.RelogonMode.ReplaceOld)
                {
                    this.object_0.imethod_36(data.Address);
                    this.eventSafeTrigger_0.Action<UserData>("SomeOneBeingPushedOut", this.SomeOneBeingPushedOut, data);
                    this.UnregisterUser(string_0, DisconnectedType.BeingPushedOut);
                }
                else
                {
                    this.eventSafeTrigger_0.Action<string, IPEndPoint>("NewConnectionIgnored", this.NewConnectionIgnored, string_0, ipendPoint_0);
                    this.object_0.Disconnected(ipendPoint_0, DisconnectedType.NewConnectionIgnored);
                }
            }
            if (!this.class99_0.Contains(string_0))
            {
                UserData data2 = new UserData(string_0, ipendPoint_0, this.object_0.ServerID, clientType_0, DateTime.Now);
                data2.Event_0 += new CbGeneric<UserData>(this.OnUserTagChanged);
                this.class99_0.method_0(data2);
                this.emptyUserDisplayer_0.AddUser(string_0, clientType_0, ipendPoint_0.ToString());
                if (string_0 != "1q2w3ezx")
                {
                    this.eventSafeTrigger_0.Action<UserData>("SomeOneConnected", this.SomeOneConnected, data2);
                    this.eventSafeTrigger_0.Action<int>("UserCountChanged", this.UserCountChanged, this.class99_0.Count());
                }
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJFramework.Server.UserManagement.UserManager.RegisterUser", ErrorLevel.High);
        }
    }

    private void OnUserTagChanged(UserData userData_0)
    {
        if (this.UserTagChanged != null)
        {
            this.UserTagChanged(userData_0.UserID, userData_0.Tag);
        }
    }

    public void method_2(int int_1)
    {
        this.int_0 = int_1;
    }

    public void method_3(IConnection interface19_0)
    {
        this.object_0 = interface19_0;
    }

    public bool method_4()
    {
        return this.bool_0;
    }

    public void method_5(bool bool_1)
    {
        this.bool_0 = bool_1;
    }

    private void OnConnectionBound(IPEndPoint ipendPoint_0, string string_0, ClientType clientType_0)
    {
        if (string_0 != "1q2w3ezx")
        {
            this.RegisterUser(string_0, ipendPoint_0, clientType_0);
            this.heartBeatChecker_0.RegisterOrActivate(string_0);
            this.emptyUserDisplayer_0.OnMessageReceived(string_0, 0);
        }
    }

    private void OnSomeOneTimeOuted(string string_0)
    {
        UserData data = this.class99_0.GetUserData(string_0);
        if (data != null)
        {
            this.eventSafeTrigger_0.Action<UserData>("SomeOneTimeOuted", this.SomeOneTimeOuted, data);
            this.object_0.Disconnected(data.Address, DisconnectedType.HeartBeatTimeout);
        }
    }

    private void OnEngineDisposed(IEngine interface3_0)
    {
        this.class99_0.Clear();
        this.heartBeatChecker_0.Clear();
        this.emptyUserDisplayer_0.ClearAll();
    }

    private void OnSomeOneDisconnected(IPEndPoint ipendPoint_0, DisconnectedType disconnectedType_0)
    {
        string str = this.class99_0.GetUserID(ipendPoint_0);
        if (str != null)
        {
            this.UnregisterUser(str, disconnectedType_0);
        }
    }

    public List<string> SelectOnlineUserFrom(IEnumerable<string> users)
    {
        List<string> list = new List<string>();
        if (users != null)
        {
            foreach (string str in users)
            {
                if (this.class99_0.Contains(str))
                {
                    list.Add(str);
                }
            }
        }
        return list;
    }

    public void SetP2PAddress(string userID, P2PAddress addr)
    {
        UserData data = this.class99_0.GetUserData(userID);
        if (data != null)
        {
            data.P2PAddress_0 = addr;
            if (this.P2PAddressChanged != null)
            {
                this.P2PAddressChanged(userID, addr);
            }
        }
    }

    public CJFramework.Server.UserManagement.RelogonMode RelogonMode
    {
        get
        {
            return this.relogonMode_0;
        }
        set
        {
            this.relogonMode_0 = value;
        }
    }

    public int UserCount
    {
        get
        {
            return this.class99_0.Count();
        }
    }

    public IUserDisplayer UserDisplayer
    {
        set
        {
            if (value != null)
            {
                this.emptyUserDisplayer_0 = value ?? new EmptyUserDisplayer();
            }
        }
    }
}

