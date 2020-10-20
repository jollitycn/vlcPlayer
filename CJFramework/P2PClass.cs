using CJBasic;
using CJBasic.Loggers;
using CJBasic.ObjectManagement.Managers;
using CJFramework;
using CJFramework.Core;
using CJPlus.Application.P2PSession;
using CJPlus.Application.P2PSession.Passive;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

internal class P2PClass : IDisposable, IP2PChannel, Interface24
{
    private bool bool_0 = true;
    [CompilerGenerated]
    private static CbGeneric<P2PChannelState> cbGeneric_2;
    [CompilerGenerated]
    private static CbGeneric<P2PChannelState> cbGeneric_3;
    private Class125 class125_0;
    private OutConnectionManager class18_0;
    private IAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private Interface26 object_0;
    private object object_1 = 0;
    private P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_0 = null;
    private SafeDictionary<string, P2PChannelState> safeDictionary_0 = new SafeDictionary<string, P2PChannelState>();
    private string string_0;

    public event CbGeneric<P2PChannelState> P2PChannelClosed;

    public event CbGeneric<P2PChannelState> P2PChannelOpened;

    public P2PClass(Interface26 interface26_0, P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_1, IAgileLogger iagileLogger_0)
    {
        if (cbGeneric_2 == null)
        {
            cbGeneric_2 = new CbGeneric<P2PChannelState>(P2PClass.smethod_0);
        }
        this.P2PChannelOpened += cbGeneric_2;
        if (cbGeneric_3 == null)
        {
            cbGeneric_3 = new CbGeneric<P2PChannelState>(P2PClass.smethod_1);
        }
        this.P2PChannelClosed += cbGeneric_3;
        this.object_0 = interface26_0;
        this.p2PSessionMessageTypeRoom_0 = p2PSessionMessageTypeRoom_1;
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
    }

    public void Dispose()
    {
        this.class125_0.method_4();
        this.class18_0.method_1();
    }

    public Dictionary<string, P2PChannelState> GetP2PChannelState()
    {
        return this.safeDictionary_0.ToDictionary();
    }

    public P2PChannelState GetP2PChannelState(string string_1)
    {
        return this.safeDictionary_0.Get(string_1);
    }

    public void imethod_10()
    {
        this.class125_0.method_6();
        this.class18_0.method_6();
    }

    public int GetPort()
    {
        return this.object_0.Port;
    }

    public bool imethod_5()
    {
        return this.bool_0;
    }

    public void imethod_6(bool bool_1)
    {
        this.bool_0 = bool_1;
    }

    public void imethod_7(UserAddressInfo userAddressInfo_0)
    {
        if ((this.object_1 != null) && !this.class125_0.IsUserOnLine(userAddressInfo_0.UserID))
        {
            this.class18_0.method_2(userAddressInfo_0);
        }
    }

    public void Close(string string_1)
    {
        this.class125_0.Close(string_1);
        this.class18_0.Close(string_1);
    }

    public void imethod_9()
    {
        this.safeDictionary_0.Clear();
        this.class125_0.method_5();
        this.class18_0.method_5();
    }

    public bool IsP2PChannelExist(string destUserID)
    {
        return this.safeDictionary_0.Contains(destUserID);
    }

    public void method_0(Interface26 interface26_0)
    {
        this.object_0 = interface26_0;
    }

    public void method_1(P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_1)
    {
        this.p2PSessionMessageTypeRoom_0 = p2PSessionMessageTypeRoom_1;
    }

    public void method_2(string string_1, int int_0, string string_2)
    {
        this.string_0 = string_1;
        this.class18_0 = new OutConnectionManager();
        this.class18_0.method_0(string_2, (Interface26) this.object_0, this.emptyAgileLogger_0);
        this.class125_0 = new Class125();
        this.class125_0.method_0(string_2, int_0, (Interface26) this.object_0, this.p2PSessionMessageTypeRoom_0);
        this.class125_0.OnSomeOneDisconnected += new CbGeneric<string>(this.OnP2PChannelClosed);
        this.class125_0.SomeOneConnected += new CbGeneric<string, IPEndPoint, bool>(this.OnP2PChannelOpened);
        this.class18_0.Event_1 += new CbGeneric<string>(this.OnP2PChannelClosed);
        this.class18_0.SomeOneConnected += new CbGeneric<string, IPEndPoint, bool>(this.OnP2PChannelOpened);
        this.object_1 = 1;
    } 

    private void OnP2PChannelOpened(string string_1, IPEndPoint ipendPoint_0, bool bool_1)
    {
        P2PChannelState state = new P2PChannelState(string_1, ProtocolType.TCP, new AgileIPE(ipendPoint_0), DateTime.Now, true, bool_1) {
            Enabled = this.bool_0
        };
        this.safeDictionary_0.Add(string_1, state);


         
     
        this.P2PChannelOpened(state);
        IMessageHandler interface3 = ((IStreamContractHelper) this.object_0.GetStreamContract()).imethod_4<Class110>(this.string_0, this.p2PSessionMessageTypeRoom_0.TcpP2PChannelTest, null, string_1);
        IMessageHandler interface4 = this.object_0.imethod_11().GetMessageForbidden().imethod_3(interface3);
        this.SendMessage(string_1, interface4, false, ActionTypeOnChannelIsBusy.Continue);
    }

    private void OnP2PChannelClosed(string string_1)
    {
        P2PChannelState state = this.safeDictionary_0.Get(string_1);
        if (state != null)
        {
            this.safeDictionary_0.Remove(string_1);
            this.P2PChannelClosed(state);
        }
    }

    public bool? method_5(string string_1)
    {
        if (this.GetP2PChannelState(string_1) != null)
        {
            bool? nullable3 = this.class18_0.method_8(string_1);
            if (nullable3.HasValue)
            {
                return new bool?(nullable3.Value);
            }
            nullable3 = this.class125_0.method_8(string_1);
            if (nullable3.HasValue)
            {
                return new bool?(nullable3.Value);
            }
        }
        return null;
    }

    public void MhxQupHswb(IAgileLogger iagileLogger_0)
    {
        this.emptyAgileLogger_0 = iagileLogger_0 ?? new EmptyAgileLogger();
    }

    public void P2PConnectAsyn(UserAddressInfo userAddressInfo_0)
    {
        new CbGeneric<UserAddressInfo>(this.imethod_7).BeginInvoke(userAddressInfo_0, null, null);
    }

    public bool SendMessage(string string_1, IMessageHandler interface37_0, bool bool_1, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        P2PChannelState state = this.safeDictionary_0.Get(string_1);
        if (!((state != null) && state.Enabled))
        {
            return false;
        }
        try
        {
            if (this.class18_0.method_7(string_1))
            {
                this.class18_0.CoNbnqugPr(string_1, interface37_0, bool_1, actionTypeOnChannelIsBusy_0);
            }
            else
            {
                this.class125_0.method_10(string_1, interface37_0, bool_1, actionTypeOnChannelIsBusy_0);
            }
            state.MessageSent();
            return true;
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.Application.P2PSession.Passive.Tcp.TcpChannelManager.SendMessage", ErrorLevel.High);
            return false;
        }
    }

    [CompilerGenerated]
    private static void smethod_0(object object_2)
    {
    }

    [CompilerGenerated]
    private static void smethod_1(object object_2)
    {
    }
}

