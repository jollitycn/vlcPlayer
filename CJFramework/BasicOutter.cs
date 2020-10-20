using CJBasic;
using CJFramework;
using CJFramework.Passive;
using CJPlus.Application.Basic;
using CJPlus.Application.Basic.Passive;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

internal class BasicOutter : IBasicOutter
{
    private BasicMessageTypeRoom basicMessageTypeRoom_0 = null;
    private bool bool_0 = false;
    private IActionType interface31_0 = null;
    private ICommitMessageToServer interface4_0;
    private IStreamContractHelper interface9_0 = null;
    private string string_0 = "";

    public event CbGeneric BeingKickedOut;

    public event CbGeneric BeingPushedOut;

    internal event CbGeneric NgadStsqsh;

    public List<string> GetAllOnlineUsers()
    {
        IMessageHandler interface2 = this.interface9_0.imethod_6(this.string_0, this.basicMessageTypeRoom_0.GetAllOnlineUsers);
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.basicMessageTypeRoom_0.GetAllOnlineUsers));
        return this.interface9_0.imethod_1<ResUsersContract>(interface3).UserList;
    }

    public IPEndPoint GetMyIPE()
    {
        IMessageHandler interface2 = this.interface9_0.imethod_6(this.string_0, this.basicMessageTypeRoom_0.GetMyIPE);
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.basicMessageTypeRoom_0.GetMyIPE));
        UserIpeResContract contract = this.interface9_0.imethod_1<UserIpeResContract>(interface3);
        return new IPEndPoint(IPAddress.Parse(contract.IP.Trim()), contract.Port);
    }

    public IPEndPoint GetIPEndPoint(string userID)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_5<QueryIPEContract>(this.string_0, this.basicMessageTypeRoom_0.Int32_0, new QueryIPEContract(userID));
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.basicMessageTypeRoom_0.Int32_0));
        UserIpeResContract contract = this.interface9_0.imethod_1<UserIpeResContract>(interface3);
        if (contract.IP == null)
        {
            return null;
        }
        return new IPEndPoint(IPAddress.Parse(contract.IP.Trim()), contract.Port);
    }

    public Dictionary<string, bool> IsUserOnline(List<string> list_0)
    {
        if ((list_0 == null) || (list_0.Count == 0))
        {
            return new Dictionary<string, bool>();
        }
        IMessageHandler interface2 = this.interface9_0.imethod_5<List<string>>(this.string_0, this.basicMessageTypeRoom_0.QueryOnlines, list_0);
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.basicMessageTypeRoom_0.QueryOnlines));
        return this.interface9_0.imethod_1<Dictionary<string, bool>>(interface3);
    }

    public bool IsUserOnline(string userID)
    {
        QueryOnlineContract body = new QueryOnlineContract(userID);
        IMessageHandler interface2 = this.interface9_0.imethod_5<QueryOnlineContract>(this.string_0, this.basicMessageTypeRoom_0.QueryOnline, body);
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.basicMessageTypeRoom_0.QueryOnline));
        return this.interface9_0.imethod_1<ResOnlineContract>(interface3).Online;
    }

    public void KickOut(string targetUserID)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_4<KickOutContract>(this.string_0, this.basicMessageTypeRoom_0.KickOut, new KickOutContract(targetUserID), "_0");
        this.interface31_0.Send(interface2, false, ActionTypeOnChannelIsBusy.Continue);
    }

    public void SetICommitMessageToServer(ICommitMessageToServer interface4_1)
    {
        this.interface4_0 = interface4_1;
    }

    public bool method_1()
    {
        return this.bool_0;
    }

    public void method_2(string string_1)
    {
        this.string_0 = string_1;
        this.bool_0 = true;
    }

    public BasicMessageTypeRoom GetBasicMessageTypeRoom()
    {
        return this.basicMessageTypeRoom_0;
    }

    public void SetBasicMessageTypeRoom(BasicMessageTypeRoom basicMessageTypeRoom_1)
    {
        this.basicMessageTypeRoom_0 = basicMessageTypeRoom_1;
    }

    public void SetStreamContract(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void SetActionType(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    public LogonFullResponse method_7(string string_1, string string_2)
    {
        ReqLogonContract body = new ReqLogonContract(string_2, string_1, AuthorizeTool.smethod_0().string_1);
        IMessageHandler interface2 = this.interface9_0.imethod_5<ReqLogonContract>(this.string_0, this.basicMessageTypeRoom_0.Logon, body);
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.basicMessageTypeRoom_0.Logon));
        return this.interface9_0.imethod_1<ResLogonContract>(interface3);
    }

    internal void method_8()
    {
        if (this.NgadStsqsh != null)
        {
            this.NgadStsqsh();
        }
        if (this.BeingKickedOut != null)
        {
            this.BeingKickedOut();
        }
    }

    internal void method_9()
    {
        if (this.NgadStsqsh != null)
        {
            this.NgadStsqsh();
        }
        if (this.BeingPushedOut != null)
        {
            this.BeingPushedOut();
        }
    }

    public int Ping()
    {
        DateTime now = DateTime.Now;
        IMessageHandler interface2 = this.interface9_0.imethod_5<Class110>(this.string_0, this.basicMessageTypeRoom_0.PingByServer, null);
        this.interface31_0.imethod_1(interface2, new int?(this.basicMessageTypeRoom_0.PingAck));
        TimeSpan span = (TimeSpan) (DateTime.Now - now);
        return (int) span.TotalMilliseconds;
    }

    public int PingByP2PChannel(string targetUserID)
    {
        if (!this.interface31_0.IsP2PChannelExist(targetUserID))
        {
            throw new InvalidOperationException(string.Format("P2PChannel to {0} is not exist !", targetUserID));
        }
        DateTime now = DateTime.Now;
        IMessageHandler interface2 = this.interface9_0.imethod_4<Class110>(this.string_0, this.basicMessageTypeRoom_0.PingByP2PChannel, null, targetUserID);
        this.interface31_0.SendByP2PChannel(interface2, ActionTypeOnNoP2PChannel.Discard, false, targetUserID, ActionTypeOnChannelIsBusy.Continue);
        this.interface31_0.imethod_6().PickupResponse(this.basicMessageTypeRoom_0.PingAck, interface2.Header.MessageID);
        TimeSpan span = (TimeSpan) (DateTime.Now - now);
        return (int) span.TotalMilliseconds;
    }

    public int PingByServer(string targetUserID)
    {
        DateTime now = DateTime.Now;
        IMessageHandler interface2 = this.interface9_0.imethod_4<Class110>(this.string_0, this.basicMessageTypeRoom_0.PingByServer, null, targetUserID);
        this.interface31_0.imethod_3(interface2, new int?(this.basicMessageTypeRoom_0.PingAck));
        TimeSpan span = (TimeSpan) (DateTime.Now - now);
        return (int) span.TotalMilliseconds;
    }

    public void SendHeartBeatMessage()
    {
        IMessageHandler interface2 = this.interface9_0.imethod_3<Class110>(this.string_0, this.basicMessageTypeRoom_0.HeartBeat, null, "_0", 0);
        this.interface31_0.Send(interface2, false, ActionTypeOnChannelIsBusy.Continue);
    }
}

