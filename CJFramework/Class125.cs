using CJBasic;
using CJFramework;
using CJFramework.Server;
using CJFramework.Server.UserManagement;
using CJPlus.Application.P2PSession;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;

internal class Class125 : Interface41
{
    private bool bool_0 = false;
    [CompilerGenerated]
    private static CbGeneric<string, IPEndPoint, bool> cbGeneric_2;
    [CompilerGenerated]
    private static CbGeneric<string> cbGeneric_3;
    private UserManager class98_0;
    private Interface26 object_0;
    private IConnection object_1;
    private P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_0 = null;

    public event CbGeneric<string, IPEndPoint, bool> SomeOneConnected;

    public event CbGeneric<string> OnSomeOneDisconnected;

    public Class125()
    {
        if (cbGeneric_2 == null)
        {
            cbGeneric_2 = new CbGeneric<string, IPEndPoint, bool>(Class125.OnSomeOneConnected);
        }
        this.SomeOneConnected += cbGeneric_2;
        if (cbGeneric_3 == null)
        {
            cbGeneric_3 = new CbGeneric<string>(Class125.smethod_1);
        }
        this.OnSomeOneDisconnected += cbGeneric_3;
    }

    public bool imethod_0(IPEndPoint ipendPoint_0, Enum4 enum4_0, IMessageHandler interface37_0)
    {
        if ((enum4_0 == ((Enum4) 0)) && (interface37_0.Header.MessageType != this.p2PSessionMessageTypeRoom_0.TcpP2PChannelTest))
        {
            return false;
        }
        if (enum4_0 == ((Enum4) 0))
        {
            this.object_1.OnConnectionBound(ipendPoint_0, interface37_0.Header.UserID);
        }
        return true;
    }

    public void method_0(string string_0, int int_0, Interface26 interface26_0, P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_1)
    {
        this.object_0 = interface26_0;
        this.p2PSessionMessageTypeRoom_0 = p2PSessionMessageTypeRoom_1;
        this.bool_0 = this.object_0.imethod_4() == string_0;
        this.method_1();
    }

    private void method_1()
    {
        this.object_1 = Class157.smethod_0(this.object_0.imethod_1(), false, null, SslProtocols.None, false);
        this.object_1.SetData(this.object_0.Port);
        this.object_1.LjXdpkRter(null);
        this.object_1.imethod_33(true);
        this.object_1.imethod_22(this);
        this.object_1.SetStreamContract(this.object_0.GetStreamContract());
        this.object_1.SetAgileLogger(this.object_0.GetAgileLogger());
        this.object_1.imethod_10(this.object_0.imethod_9());
        this.object_1.imethod_12(this.object_0.imethod_11());
        this.object_1.imethod_8(this.object_0.imethod_7());
        this.object_1.SocketSendBuffSize = this.object_0.SocketSendBuffSize;
        this.object_1.imethod_26(this.object_0.imethod_22());
        this.class98_0 = new UserManager();
        this.class98_0.RelogonMode = RelogonMode.ReplaceOld;
        this.class98_0.method_2(0);
        this.class98_0.method_3((IConnection) this.object_1);
        this.class98_0.SomeOneConnected += new CbGeneric<UserData>(this.OnSomeOneConnected);
        this.class98_0.SomeOneDisconnected += new CbGeneric<UserData, DisconnectedType>(this.SomeOneDisconnected);
        this.class98_0.Initialize();
        this.object_1.Initialize();
    }

    public void method_10(string string_0, IMessageHandler interface37_0, bool bool_1, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        IPEndPoint userAddress = this.class98_0.GetUserAddress(string_0);
        if (userAddress != null)
        {
            if (bool_1)
            {
                this.object_1.PostMessageToClient(userAddress, interface37_0, actionTypeOnChannelIsBusy_0);
            }
            else
            {
                this.object_1.SendMessageToClient(userAddress, interface37_0, actionTypeOnChannelIsBusy_0);
            }
        }
    }

    private void SomeOneDisconnected(UserData userData_0, DisconnectedType disconnectedType_0)
    {
        this.OnSomeOneDisconnected(userData_0.UserID);
    }

    private void OnSomeOneConnected(UserData userData_0)
    {
        this.SomeOneConnected(userData_0.UserID, userData_0.Address, !this.bool_0);
    }

    public void method_4()
    {
        this.object_1.Dispose();
    }

    public void method_5()
    {
        this.object_1.imethod_35();
        this.object_1.Dispose();
    }

    public void method_6()
    {
        this.method_1();
    }

    public void Close(string string_0)
    {
        IPEndPoint userAddress = this.class98_0.GetUserAddress(string_0);
        if (userAddress != null)
        {
            this.object_1.Disconnected(userAddress, DisconnectedType.NetworkInterrupted);
        }
    }

    public bool? method_8(string string_0)
    {
        IPEndPoint userAddress = this.class98_0.GetUserAddress(string_0);
        if (userAddress == null)
        {
            return null;
        }
        return new bool?(this.object_1.IsBusy(userAddress));
    }

    public bool IsUserOnLine(string string_0)
    {
        return this.class98_0.IsUserOnLine(string_0);
    }

    [CompilerGenerated]
    private static void OnSomeOneConnected(object object_2, object object_3, bool bool_1)
    {
    }

    [CompilerGenerated]
    private static void smethod_1(object object_2)
    {
    }
}

