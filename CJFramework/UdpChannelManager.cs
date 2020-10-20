using CJBasic;
using CJBasic.Loggers;
using CJBasic.ObjectManagement.Managers;
using CJFramework;
using CJFramework.Core;
using CJFramework.Engine.Udp.Reliable;
using CJPlus.Application.P2PSession;
using CJPlus.Application.P2PSession.Passive;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

internal class UdpChannelManager : IDisposable, Interface18, IP2PChannel, Interface24
{
    private AgileIPE agileIPE_0;
    private AgileIPE agileIPE_1;
    internal static bool bool_0 = false;
    private bool bool_1;
    private bool bool_2 = true;
    [CompilerGenerated]
    private static CbGeneric<P2PChannelState> cbGeneric_7;
    [CompilerGenerated]
    private static CbGeneric<P2PChannelState> cbGeneric_8;
    private IPv6UdpClient class164_0;
    private Class83 class83_0;
    private IAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private int int_0 = 0;
    private Interface30 interface30_0;
    private Interface26 object_0;
    private P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_0 = null;
    private SafeDictionary<string, P2PChannelState> safeDictionary_0 = new SafeDictionary<string, P2PChannelState>();
    private string string_0;
    public string string_1;

    public event CbGeneric Event_0;

    public event CbGeneric<IPEndPoint> ExitReceived;

    public event CbGeneric<IPEndPoint, FeedbackVacancyBody> FeedbackVacancyReceived;

    public event CbGeneric<P2PChannelState> P2PChannelClosed;

    public event CbGeneric<P2PChannelState> P2PChannelOpened;

    public event CbGeneric<IPEndPoint, string, ushort> PMTUTestAckReceived;

    public event CbGeneric<IPEndPoint, string> SynAckReceived;

    public UdpChannelManager(AgileIPE agileIPE_2, Interface26 interface26_0, P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_1, bool bool_3, IAgileLogger iagileLogger_0)
    {
        if (cbGeneric_7 == null)
        {
            cbGeneric_7 = new CbGeneric<P2PChannelState>(UdpChannelManager.smethod_0);
        }
        this.P2PChannelOpened += cbGeneric_7;
        if (cbGeneric_8 == null)
        {
            cbGeneric_8 = new CbGeneric<P2PChannelState>(UdpChannelManager.smethod_1);
        }
        this.P2PChannelClosed += cbGeneric_8;
        this.agileIPE_0 = agileIPE_2;
        this.object_0 = interface26_0;
        this.p2PSessionMessageTypeRoom_0 = p2PSessionMessageTypeRoom_1;
        this.bool_1 = bool_3;
        this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
    }

    public void Dispose()
    {
        if (this.class83_0 != null)
        {
            this.class83_0.Dispose();
        }
    }

    public Dictionary<string, P2PChannelState> GetP2PChannelState()
    {
        return this.safeDictionary_0.ToDictionary();
    }

    public P2PChannelState GetP2PChannelState(string string_2)
    {
        return this.safeDictionary_0.Get(string_2);
    }

    public void imethod_0(string string_2, AgileIPE agileIPE_2, string string_3)
    {
        this.interface30_0.imethod_5(string_2, agileIPE_2, string_3);
    }

    public void imethod_1(IPEndPoint ipendPoint_0, FeedbackVacancyBody feedbackVacancyBody_0)
    {
        string str = null;
        using (List<P2PChannelState>.Enumerator enumerator = this.safeDictionary_0.GetAll().GetEnumerator())
        {
            P2PChannelState current;
            while (enumerator.MoveNext())
            {
                current = enumerator.Current;
                if (current.DestIPE.Equals(new AgileIPE(ipendPoint_0)))
                {
                    goto Label_003F;
                }
            }
            goto Label_0056;
        Label_003F:
            str = current.DestUserID;
        }
    Label_0056:
        this.interface30_0.imethod_4(str, feedbackVacancyBody_0);
    }

    public void imethod_10()
    {
        this.method_6();
    }

    public void imethod_2(string string_2, ushort ushort_0)
    {
        this.interface30_0.imethod_7(string_2, ushort_0);
    }

    public void imethod_3(string string_2)
    {
        if (this.agileIPE_1 != null)
        {
            this.interface30_0.imethod_6(this.agileIPE_1, string_2);
        }
    }

    public int GetPort()
    {
        return this.class164_0.method_2();
    }

    public bool imethod_5()
    {
        return this.bool_2;
    }

    public void imethod_6(bool bool_3)
    {
        this.bool_2 = bool_3;
    }

    public void imethod_7(UserAddressInfo userAddressInfo_0)
    {
        this.method_11(userAddressInfo_0);
    }

    public void Close(string string_2)
    {
        if (this.class83_0 != null)
        {
            P2PChannelState state = this.safeDictionary_0.Get(string_2);
            if (state != null)
            {
                this.class83_0.GetIUdpSessionHelper().imethod_3(state.DestIPE.IPEndPoint_0);
                this.safeDictionary_0.Remove(string_2);
                this.P2PChannelClosed(state);
            }
        }
    }


    public void imethod_9()
    {
        if (this.class83_0 != null)
        {
            this.class83_0.GetIUdpSessionHelper().imethod_4();
            this.safeDictionary_0.Clear();
            this.int_0 = 0;
            this.class83_0.Dispose();
            this.class83_0 = null;
        }
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

    private void method_10(IPEndPoint ipendPoint_0, byte[] byte_0)
    {
        IPv6UdpClient class2;
        Monitor.Enter(class2 = this.class164_0);
        try
        {
            if (((this.class83_0 == null) && ipendPoint_0.Equals(this.agileIPE_0.IPEndPoint_0)) && (byte_0.Length == 4))
            {
                this.int_0 = BitConverter.ToInt32(byte_0, 0);
                this.agileIPE_1 = new AgileIPE(this.string_1, this.int_0);
                this.class164_0.DataReceived -= new CbGeneric<IPEndPoint, byte[]>(this.method_10);
                this.method_7();
                if (this.Event_0 != null)
                {
                    this.Event_0();
                }
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.Application.P2PSession.Passive.Udp.UdpChannelManager.udpServerEngineP2P_MessageReceived", ErrorLevel.High);
        }
        finally
        {
            Monitor.Exit(class2);
        }
    }



    private void method_11(UserAddressInfo userAddressInfo_0)
    {
        if (this.class83_0 != null)
        {
            if (this.string_1 == userAddressInfo_0.P2PAddress_0.PublicIP)
            {
                if (userAddressInfo_0.P2PAddress_0 != null)
                {
                    this.method_12(userAddressInfo_0.UserID, new IPEndPoint(IPAddress.Parse(userAddressInfo_0.P2PAddress_0.PrivateIP), userAddressInfo_0.P2PAddress_0.PrivateUdpPort));
                }
            }
            else
            {
                if (userAddressInfo_0.P2PAddress_0.PublicUdpPort > 0)
                {
                    this.method_12(userAddressInfo_0.UserID, new IPEndPoint(IPAddress.Parse(userAddressInfo_0.P2PAddress_0.PublicIP), userAddressInfo_0.P2PAddress_0.PublicUdpPort));
                }
                this.method_12(userAddressInfo_0.UserID, new IPEndPoint(IPAddress.Parse(userAddressInfo_0.P2PAddress_0.PrivateIP), userAddressInfo_0.P2PAddress_0.PrivateUdpPort));
            }
        }
    }

    private void method_12(string string_2, IPEndPoint ipendPoint_0)
    {
        if (this.class83_0 != null)
        {
            for (int i = 0; i < 3; i++)
            {
                this.class83_0.GetIUdpSessionHelper().imethod_1(ipendPoint_0);
                Thread.Sleep(100);
            }
        }
    }

    public bool? method_13(string string_2)
    {
        if (this.class83_0 == null)
        {
            return null;
        }
        P2PChannelState state = this.GetP2PChannelState(string_2);
        if (state == null)
        {
            return null;
        }
        return new bool?(this.class83_0.GetIUdpSessionHelper().imethod_2(state.DestIPE.IPEndPoint_0));
    }

    public void OnFeedbackVacancyReceived(string string_2, FeedbackVacancyBody feedbackVacancyBody_0)
    {
        P2PChannelState state = this.safeDictionary_0.Get(string_2);
        if ((state != null) && (this.FeedbackVacancyReceived != null))
        {
            this.FeedbackVacancyReceived(state.DestIPE.IPEndPoint_0, feedbackVacancyBody_0);
        }
    }



    //public event CbGeneric Event_0;

    //public event CbGeneric<IPEndPoint> ExitReceived;

    //public event CbGeneric<IPEndPoint, FeedbackVacancyBody> FeedbackVacancyReceived;

    //public event CbGeneric<P2PChannelState> P2PChannelClosed;

    //public event CbGeneric<P2PChannelState> P2PChannelOpened;

    //public event CbGeneric<IPEndPoint, string, ushort> PMTUTestAckReceived;

    //public event CbGeneric<IPEndPoint, string> SynAckReceived;

    public void OnSynAckReceived(IPEndPoint ipendPoint_0, string string_2)
    {
        if (this.SynAckReceived != null)
        {
            this.SynAckReceived(ipendPoint_0, string_2);
        }
    }

    public void OnPMTUTestAckReceived(string string_2, ushort ushort_0)
    {
        P2PChannelState state = this.safeDictionary_0.Get(string_2);
        if ((state != null) && (this.PMTUTestAckReceived != null))
        {
            this.PMTUTestAckReceived(state.DestIPE.IPEndPoint_0, string_2, ushort_0);
        }
    }

    public void OnExitReceived(string string_2, IPEndPoint ipendPoint_0)
    {
        if (this.ExitReceived != null)
        {
            this.ExitReceived(ipendPoint_0);
        }
    }

    public void method_2(IAgileLogger iagileLogger_0)
    {
        this.emptyAgileLogger_0 = iagileLogger_0 ?? new EmptyAgileLogger();
    }

    public int method_3()
    {
        return this.int_0;
    }

    public IUdpSessionHelper method_4()
    {
        return this.class83_0.GetIUdpSessionHelper();
    }

    public void method_5(string string_2, string string_3, Interface30 interface30_1)
    {
        this.string_0 = string_2;
        this.string_1 = string_3;
        this.interface30_0 = interface30_1;
        this.method_6();
        bool_0 = true;
    }

    private void method_6()
    {
        this.class164_0 = new IPv6UdpClient(0);
        this.class164_0.DataReceived += new CbGeneric<IPEndPoint, byte[]>(this.method_10);
        this.class164_0.Initialize();
        byte[] bytes = BitConverter.GetBytes(0x1e240);
        for (int i = 0; i < 3; i++)
        {
            this.class164_0.Send(bytes, this.agileIPE_0.IPEndPoint_0);
            Thread.Sleep(10);
        }
    }

    private void method_7()
    {
        this.class83_0 = new Class83();
        this.class83_0.imethod_19(this.object_0.imethod_1());
        this.class83_0.SetStreamContract(this.object_0.GetStreamContract());
        this.class83_0.SetAgileLogger(this.emptyAgileLogger_0);
        this.class83_0.imethod_10(this.object_0.imethod_9());
        this.class83_0.imethod_12(this.object_0.imethod_11());
        this.class83_0.SetData(0);
        this.class83_0.imethod_8(this.object_0.imethod_7());
        this.class83_0.SocketSendBuffSize = this.object_0.SocketSendBuffSize;
        this.class83_0.method_0(this.class164_0, true, this, this.string_0);
        this.class83_0.GetIUdpSessionHelper().UdpSessionClosed += new CbGeneric<Interface17, SessionClosedCause>(this.OnP2PChannelClosed);
        this.class83_0.GetIUdpSessionHelper().UdpSessionOpened += new CbGeneric<Interface17>(this.OnP2PChannelOpened);
    }

    private void OnP2PChannelOpened(Interface17 interface17_0)
    {
        if (interface17_0.imethod_0())
        {
            P2PChannelState state = new P2PChannelState(interface17_0.imethod_2(), ProtocolType.UDP, new AgileIPE(interface17_0.imethod_1()), DateTime.Now, true, false) {
                Enabled = this.bool_2
            };
            bool flag = this.safeDictionary_0.Contains(interface17_0.imethod_2());
            this.safeDictionary_0.Add(interface17_0.imethod_2(), state);
            if (!flag)
            {
                this.P2PChannelOpened(state);
            }
        }
    }

    private void OnP2PChannelClosed(Interface17 interface17_0, SessionClosedCause sessionClosedCause_0)
    {
        if (interface17_0.imethod_0())
        {
            P2PChannelState state = this.safeDictionary_0.Get(interface17_0.imethod_2());
            if (state != null)
            {
                this.safeDictionary_0.Remove(interface17_0.imethod_2());
                this.P2PChannelClosed(state);
            }
        }
    }

    public void P2PConnectAsyn(UserAddressInfo userAddressInfo_0)
    {
        new CbGeneric<UserAddressInfo>(this.imethod_7).BeginInvoke(userAddressInfo_0, null, null);
    }

    public bool SendMessage(string string_2, IMessageHandler interface37_0, bool bool_3, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if (this.class83_0 == null)
        {
            return false;
        }
        P2PChannelState state = this.safeDictionary_0.Get(string_2);
        if (!((state != null) && state.Enabled))
        {
            return false;
        }
        try
        {
            if (bool_3)
            {
                this.class83_0.PostMessageToClient(state.DestIPE.IPEndPoint_0, interface37_0, actionTypeOnChannelIsBusy_0);
            }
            else
            {
                this.class83_0.SendMessageToClient(state.DestIPE.IPEndPoint_0, interface37_0, actionTypeOnChannelIsBusy_0);
            }
            state.MessageSent();
            return true;
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.Application.P2PSession.Passive.Udp.UdpChannelManager.SendMessage", ErrorLevel.High);
            return false;
        }
    }

    [CompilerGenerated]
    private static void smethod_0(object object_1)
    {
    }

    [CompilerGenerated]
    private static void smethod_1(object object_1)
    {
    }
}

