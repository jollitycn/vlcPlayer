using CJBasic;
using CJBasic.Loggers;
using CJBasic.ObjectManagement.Managers;
using CJFramework;
using CJPlus.Application.P2PSession;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Net;

internal class OutConnectionManager
{
    [CompilerGenerated]
    private static CbGeneric<string, IPEndPoint, bool> cbGeneric_1;
    [CompilerGenerated]
    private static CbGeneric<string> cbGeneric_2;
    private IAgileLogger iagileLogger_0;
    private Interface26 object_0;
    private SafeDictionary<string, Interface26> safeDictionary_0 = new SafeDictionary<string, Interface26>();
    private string string_0;

    public event CbGeneric<string, IPEndPoint, bool> SomeOneConnected;

    public event CbGeneric<string> Event_1;

    public OutConnectionManager()
    {
        if (cbGeneric_1 == null)
        {
            cbGeneric_1 = new CbGeneric<string, IPEndPoint, bool>(OutConnectionManager.smethod_0);
        }
        this.SomeOneConnected += cbGeneric_1;
        if (cbGeneric_2 == null)
        {
            cbGeneric_2 = new CbGeneric<string>(OutConnectionManager.smethod_1);
        }
        this.Event_1 += cbGeneric_2;
    }

    public void CoNbnqugPr(string string_1, IMessageHandler interface37, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy)
    {
        Interface26 interface2 = this.safeDictionary_0.Get(string_1);
        if (interface2 != null)
        {
            interface2.CommitMessageToServer(interface37, bool_0, actionTypeOnChannelIsBusy);
        }
    }

    public void method_0(string string_1, Interface26 interface26_0, IAgileLogger iagileLogger_1)
    {
        this.string_0 = string_1;
        this.object_0 = interface26_0;
        this.iagileLogger_0 = iagileLogger_1;
    }

    public void method_1()
    {
        this.method_5();
    }

    public void method_2(UserAddressInfo userAddressInfo_0)
    {
        if (!this.safeDictionary_0.Contains(userAddressInfo_0.UserID))
        {
            if (userAddressInfo_0.P2PAddress_0.PublicIP == this.string_0)
            {
                this.method_3(userAddressInfo_0.UserID, new AgileIPE(userAddressInfo_0.P2PAddress_0.PrivateIP, userAddressInfo_0.P2PAddress_0.PrivateTcpPort), true);
            }
            else
            {
                this.method_3(userAddressInfo_0.UserID, new AgileIPE(userAddressInfo_0.P2PAddress_0.PublicIP, userAddressInfo_0.P2PAddress_0.PublicTcpPort), false);
                if (!this.safeDictionary_0.Contains(userAddressInfo_0.UserID))
                {
                    this.method_3(userAddressInfo_0.UserID, new AgileIPE(userAddressInfo_0.P2PAddress_0.PrivateIP, userAddressInfo_0.P2PAddress_0.PrivateTcpPort), true);
                }
            }
        }
    }

    private void method_3(string string_1, AgileIPE agileIPE_0, bool bool_0)
    {
        Interface26 interface2 = Class157.CreateInterface26(this.object_0.imethod_1());
        try
        {
            interface2.SetStreamContract(this.object_0.GetStreamContract());
            interface2.SetAgileLogger(this.object_0.GetAgileLogger());
            interface2.imethod_10(this.object_0.imethod_9());
            interface2.imethod_12(this.object_0.imethod_11());
            interface2.imethod_8(this.object_0.imethod_7());
            interface2.SocketSendBuffSize = this.object_0.SocketSendBuffSize;
            interface2.imethod_23(this.object_0.imethod_22());
            interface2.LjXdpkRter(null);
            interface2.SetData(0);
            interface2.SetAgileIPE(agileIPE_0);
            interface2.AutoReconnect = false;
            interface2.Initialize();
            interface2.ConnectionInterrupted += new CbGeneric(this.newEngine_ConnectionInterrupted);
            this.safeDictionary_0.Add(string_1, interface2);
            this.SomeOneConnected(string_1, interface2.GetAgileIPE().IPEndPoint_0, bool_0);
        }
        catch (Exception)
        {
            interface2.Dispose();
        }
    }

    public void Close(string string_1)
    {
        Interface26 interface2 = this.safeDictionary_0.Get(string_1);
        if (interface2 != null)
        {
            interface2.Dispose();
            this.safeDictionary_0.Remove(string_1);
          //  this.XppbFuVvfm(string_1);
        }
    }

    public void method_5()
    {
        foreach (Interface26 interface2 in this.safeDictionary_0.GetAll())
        {
            interface2.Dispose();
        }
        this.safeDictionary_0.Clear();
    }

    public void method_6()
    {
    }

    public bool method_7(string string_1)
    {
        return this.safeDictionary_0.Contains(string_1);
    }

    public bool? method_8(string string_1)
    {
        Interface26 interface2 = this.safeDictionary_0.Get(string_1);
        if (interface2 == null)
        {
            return null;
        }
        return new bool?(interface2.ChannelIsBusy);
    }

    [CompilerGenerated]
    private static void smethod_0(object object_1, object object_2, bool bool_0)
    {
    }

    [CompilerGenerated]
    private static void smethod_1(object object_1)
    {
    }

    private void newEngine_ConnectionInterrupted()
    {
        try
        {
            List<string> list = new List<string>();
            foreach (string str in this.safeDictionary_0.GetKeyList())
            {
                Interface26 interface2 = this.safeDictionary_0.Get(str);
                if (!((interface2 == null) || interface2.Connected))
                {
                    list.Add(str);
                }
            }
            foreach (string str in list)
            {
                this.safeDictionary_0.Remove(str);
            }
            foreach (string str in list)
            {
            //    this.XppbFuVvfm(str);
            }
        }
        catch (Exception exception)
        {
            this.iagileLogger_0.Log(exception, "OMCS.Communication.Plus.Application.P2PSession.Passive.Tcp.OutConnectionManager.newEngine_ConnectionInterrupted", ErrorLevel.Standard);
        }
    }
}

