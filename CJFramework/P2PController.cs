using CJBasic;
using CJBasic.Collections;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJFramework;
using CJFramework.Engine.Udp.Reliable;
using CJFramework.Server.UserManagement;
using CJPlus.Application.P2PSession;
using CJPlus.Application.P2PSession.Passive;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

internal class P2PController : IDisposable, IP2PChannel, IP2PController
{
    private AgileIPE agileIPE_0;
    private P2PClass class42_0;
    private UdpChannelManager class57_0;
    private Delegate delegate_0;
    private IAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private EventSafeTrigger eventSafeTrigger_0 = new EventSafeTrigger(new EmptyAgileLogger(), "dHTARxVc2MCGQxpD4uV.gCGjXVVJ2p4VYu2pSjs");
    private Interface30 interface30_0;
    private IPEndPoint ipendPoint_0;
    private Interface26 object_0;
    private CJPlus.Application.P2PSession.Passive.P2PChannelMode p2PChannelMode_0 = CJPlus.Application.P2PSession.Passive.P2PChannelMode.TcpAndUdp;
    private P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_0 = null;
    private SortedArray<string> sortedArray_0 = new SortedArray<string>();
    private string string_0;

    public event CbGeneric AllP2PChannelClosed
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

    public event CbGeneric<P2PChannelState> P2PChannelClosed;

    public event CbGeneric<P2PChannelState> P2PChannelOpened;

    public event CbGeneric<string> P2PConnectFailed;

    private void DoP2PConnect(string string_1)
    {
        try
        {
            this.sortedArray_0.Add(string_1);
            UserAddressInfo userData = this.interface30_0.GetUserData(string_1);
            if (userData == null)
            {
                return;
            }
            if ((userData.P2PAddress_0 != null) && (userData.P2PAddress_0.PublicIP == this.ipendPoint_0.Address.ToString()))
            {
                goto Label_009A;
            }
            int num = 0;
            goto Label_0090;
        Label_0061:
            if (num >= 10)
            {
                goto Label_009A;
            }
            Thread.Sleep(500);
            userData = this.interface30_0.GetUserData(string_1);
            num++;
            goto Label_0090;
        Label_0080:
            if (userData.P2PAddress_0.PublicUdpPort == 0)
            {
            }
            goto Label_0061;
        Label_0090:
            if (userData.P2PAddress_0 == null)
            {
                goto Label_0061;
            }
            goto Label_0080;
        Label_009A:
            if (userData.P2PAddress_0 != null)
            {
                if (this.p2PChannelMode_0 != CJPlus.Application.P2PSession.Passive.P2PChannelMode.Tcp)
                {
                    this.class57_0.imethod_7(userData);
                    if (!this.class57_0.IsP2PChannelExist(string_1))
                    {
                        this.interface30_0.imethod_1(string_1);
                        Thread.Sleep(0x7d0);
                        if (!this.class57_0.IsP2PChannelExist(string_1))
                        {
                            this.class57_0.imethod_7(userData);
                        }
                    }
                }
                if (this.p2PChannelMode_0 != CJPlus.Application.P2PSession.Passive.P2PChannelMode.Udp)
                {
                    this.class42_0.imethod_7(userData);
                    if (!this.class42_0.IsP2PChannelExist(string_1))
                    {
                        this.interface30_0.imethod_0(string_1);
                        Thread.Sleep(0xbb8);
                        if (!this.class42_0.IsP2PChannelExist(string_1))
                        {
                            this.class42_0.imethod_7(userData);
                        }
                    }
                }
            }
            if (!this.IsP2PChannelExist(string_1) && (this.P2PConnectFailed != null))
            {
                this.P2PConnectFailed(string_1);
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, string.Format("CJPlus.Application.P2PSession.Passive.P2PController.DoP2PConnect - {0}", string_1), ErrorLevel.High);
            if (!this.IsP2PChannelExist(string_1) && (this.P2PConnectFailed != null))
            {
                this.P2PConnectFailed(string_1);
            }
        }
        finally
        {
            this.sortedArray_0.Remove(string_1);
        }
    }

    public void Dispose()
    {
        this.class57_0.Dispose();
        this.class42_0.Dispose();
    }

    public Dictionary<string, P2PChannelState> GetP2PChannelState()
    {
        Dictionary<string, P2PChannelState> dictionary = this.class42_0.GetP2PChannelState();
        foreach (KeyValuePair<string, P2PChannelState> pair in this.class57_0.GetP2PChannelState())
        {
            if (!dictionary.ContainsKey(pair.Key))
            {
                dictionary.Add(pair.Key, pair.Value);
            }
        }
        return dictionary;
    }

    public P2PChannelState GetP2PChannelState(string destUserID)
    {
        P2PChannelState state = this.class42_0.GetP2PChannelState(destUserID);
        if (state == null)
        {
            state = this.class57_0.GetP2PChannelState(destUserID);
        }
        return state;
    }

    public IUdpSessionStateViewer GetUdpSessionStateViewer()
    {
        return this.class57_0.method_4();
    }

    public bool IsP2PChannelExist(string destUserID)
    {
        return (this.class42_0.IsP2PChannelExist(destUserID) || this.class57_0.IsP2PChannelExist(destUserID));
    }

    internal UdpChannelManager method_0()
    {
        return this.class57_0;
    }

    internal P2PClass method_1()
    {
        return this.class42_0;
    }

    private void method_10(P2PChannelState p2PChannelState_0)
    {
        this.eventSafeTrigger_0.ActionAsyn<P2PChannelState>("P2PChannelClosed", this.P2PChannelClosed, p2PChannelState_0);
    }

    private void method_11()
    {
        if (this.object_0.imethod_21())
        {
            IPEndPoint point = this.interface30_0.imethod_2();
            this.class42_0.imethod_10();
            this.class57_0.imethod_10();
            this.interface30_0.imethod_3(new P2PAddress(point.Address.ToString(), this.object_0.imethod_4(), this.object_0.Port, point.Port, this.class57_0.GetPort(), this.class57_0.method_3()));
        }
    }

    private void OnAllP2PChannelClosed()
    {
        this.class42_0.imethod_9();
        this.class57_0.imethod_9();
        this.eventSafeTrigger_0.ActionAsyn("AllP2PChannelClosed", this.delegate_0);
    }

    public void Close(string string_1)
    {
        this.class42_0.Close(string_1);
        this.class57_0.Close(string_1);
    }

    internal void method_2(Interface30 interface30_1)
    {
        this.interface30_0 = interface30_1;
    }

    public void method_3(Interface26 interface26_0)
    {
        this.object_0 = interface26_0;
    }

    public void method_4(P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_1)
    {
        this.p2PSessionMessageTypeRoom_0 = p2PSessionMessageTypeRoom_1;
    }

    public void method_5(IAgileLogger iagileLogger_0)
    {
        this.emptyAgileLogger_0 = iagileLogger_0 ?? new EmptyAgileLogger();
    }

    public void method_6(AgileIPE agileIPE_1)
    {
        this.agileIPE_0 = agileIPE_1;
    }

    public void method_7(string string_1, bool bool_0)
    {
        this.string_0 = string_1;
        this.object_0.ConnectionInterrupted += new CbGeneric(this.OnAllP2PChannelClosed);
        this.object_0.ConnectionRebuildSucceed += new CbGeneric(this.method_11);
        this.class42_0 = new P2PClass((Interface26) this.object_0, this.p2PSessionMessageTypeRoom_0, this.emptyAgileLogger_0);
        this.class42_0.P2PChannelClosed += new CbGeneric<P2PChannelState>(this.method_10);
        this.class42_0.P2PChannelOpened += new CbGeneric<P2PChannelState>(this.OnP2PChannelOpened);
        this.class57_0 = new UdpChannelManager(this.agileIPE_0, (Interface26) this.object_0, this.p2PSessionMessageTypeRoom_0, bool_0, this.emptyAgileLogger_0);
        this.class57_0.P2PChannelClosed += new CbGeneric<P2PChannelState>(this.method_10);
        this.class57_0.P2PChannelOpened += new CbGeneric<P2PChannelState>(this.OnP2PChannelOpened);
        this.class57_0.Event_0 += new CbGeneric(this.GetP2PAddress);
        this.ipendPoint_0 = this.interface30_0.imethod_2();
        this.class42_0.method_2(this.string_0, this.object_0.Port, this.ipendPoint_0.Address.ToString());
        this.class57_0.method_5(this.string_0, this.ipendPoint_0.Address.ToString(), this.interface30_0);
        this.interface30_0.imethod_3(new P2PAddress(this.ipendPoint_0.Address.ToString(), this.object_0.imethod_4(), this.object_0.Port, this.ipendPoint_0.Port, this.class57_0.GetPort(), this.class57_0.method_3()));
    }

    private void GetP2PAddress()
    {
        this.interface30_0.imethod_3(new P2PAddress(this.ipendPoint_0.Address.ToString(), this.object_0.imethod_4(), this.object_0.Port, this.ipendPoint_0.Port, this.class57_0.GetPort(), this.class57_0.method_3()));
    }

    private void OnP2PChannelOpened(P2PChannelState p2PChannelState_0)
    {
        this.eventSafeTrigger_0.ActionAsyn<P2PChannelState>("P2PChannelOpened", this.P2PChannelOpened, p2PChannelState_0);
    }

    public bool? P2PChannelIsBusy(string destUserID)
    {
        bool? nullable = this.class42_0.method_5(destUserID);
        if (nullable.HasValue)
        {
            return new bool?(nullable.Value);
        }
        nullable = this.class57_0.method_13(destUserID);
        if (nullable.HasValue)
        {
            return new bool?(nullable.Value);
        }
        return null;
    }

    public void P2PConnectAsyn(string destUserID)
    {
        if ((((this.p2PChannelMode_0 != CJPlus.Application.P2PSession.Passive.P2PChannelMode.None) && this.object_0.Connected) && (!this.class42_0.IsP2PChannelExist(destUserID) && !this.class57_0.IsP2PChannelExist(destUserID))) && !this.sortedArray_0.Contains(destUserID))
        {
            new CbGeneric<string>(this.DoP2PConnect).BeginInvoke(destUserID, null, null);
        }
    }

    public bool SendMessage(string string_1, IMessageHandler interface37_0, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        return (this.class42_0.SendMessage(string_1, interface37_0, bool_0, actionTypeOnChannelIsBusy_0) || this.class57_0.SendMessage(string_1, interface37_0, bool_0, actionTypeOnChannelIsBusy_0));
    }

    public CJPlus.Application.P2PSession.Passive.P2PChannelMode P2PChannelMode
    {
        get
        {
            return this.p2PChannelMode_0;
        }
        set
        {
            this.p2PChannelMode_0 = value;
        }
    }
}

