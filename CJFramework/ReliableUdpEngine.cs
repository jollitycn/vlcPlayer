using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJBasic.ObjectManagement.Managers;
using CJFramework;
using CJFramework.Engine.Udp.Reliable;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

internal class ReliableUdpEngine : IUdpSessionStateViewer, IPv6, IUdpSessionHelper
{
    private Interface18 class32_0;
    private IAgileLogger emptyAgileLogger_0;
    private EventSafeTrigger eventSafeTrigger_0;
    private int int_0;
    private int int_1;
    private int object_0;
    private IPv6 object_1;
    private SafeDictionary<IPEndPoint, Class116> safeDictionary_0;
    private SafeDictionary<IPEndPoint, Class100> safeDictionary_1;
    private string string_0;

    public event CbGeneric<IPEndPoint, byte[]> DataReceived;

    public event CbGeneric<Interface17, SessionClosedCause> UdpSessionClosed;

    public event CbGeneric<Interface17> UdpSessionOpened;

    public ReliableUdpEngine(IPv6UdpClient class164_0, int int_2, IAgileLogger iagileLogger_0, Interface18 interface18_0) : this(class164_0, int_2, iagileLogger_0, interface18_0, "")
    {
    }

    public ReliableUdpEngine(IPv6UdpClient class164_0, int int_2, IAgileLogger iagileLogger_0, Interface18 interface18_0, string string_1)
    {
        this.object_0 = 0;
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.int_0 = 0x100000;
        this.int_1 = 100;
        this.eventSafeTrigger_0 = new EventSafeTrigger(new EmptyAgileLogger(), "NP0TGVBgJ9QwLAhYTKW.XpFDH2BqcL8UtxuLtNZ");
        this.safeDictionary_0 = new SafeDictionary<IPEndPoint, Class116>();
        this.safeDictionary_1 = new SafeDictionary<IPEndPoint, Class100>();
        this.string_0 = "";
        this.string_0 = string_1;
        this.object_1 = class164_0;
        this.object_1.DataReceived += new CbGeneric<IPEndPoint, byte[]>(this.udpClient_DataReceived);
        this.object_1.Initialize();
        this.int_0 = int_2;
        this.int_1 = this.int_0 / 500;
        this.emptyAgileLogger_0 = iagileLogger_0 ?? new EmptyAgileLogger();
        this.eventSafeTrigger_0.AgileLogger = this.emptyAgileLogger_0;
        this.class32_0 = interface18_0 ?? new Class32();
        this.class32_0.SynAckReceived += new CbGeneric<IPEndPoint, string>(this.method_7);
        this.class32_0.FeedbackVacancyReceived += new CbGeneric<IPEndPoint, FeedbackVacancyBody>(this.method_6);
        this.class32_0.ExitReceived += new CbGeneric<IPEndPoint>(this.method_2);
        this.class32_0.PMTUTestAckReceived += new CbGeneric<IPEndPoint, string, ushort>(this.method_1);
        new CbGeneric(this.CircleQuickly).BeginInvoke(null, null);
        new CbGeneric(this.CircleQuickly2).BeginInvoke(null, null);
    }

    public void Dispose()
    {
        this.object_0 = 1;
        foreach (Class100 class3 in this.safeDictionary_1.GetAll())
        {
            this.method_12(class3.imethod_1());
            this.class32_0.imethod_3(class3.imethod_2());
        }
        foreach (Class116 class2 in this.safeDictionary_0.GetAll())
        {
            this.method_12(class2.imethod_1());
            this.class32_0.imethod_3(class2.imethod_2());
        }
        this.object_1.Dispose();
    }

    public List<InUdpSessionState> GetInUdpSessionStates()
    {
        List<InUdpSessionState> list = new List<InUdpSessionState>();
        foreach (Class100 class2 in this.safeDictionary_1.GetAll())
        {
            list.Add(class2.method_16());
        }
        return list;
    }

    public OutUdpSessionState GetOutUdpSessionState(IPEndPoint destIPE)
    {
        Class116 class2 = this.safeDictionary_0.Get(destIPE);
        if (class2 == null)
        {
            return null;
        }
        return class2.method_20();
    }

    public List<OutUdpSessionState> GetOutUdpSessionStates()
    {
        List<OutUdpSessionState> list = new List<OutUdpSessionState>();
        foreach (Class116 class2 in this.safeDictionary_0.GetAll())
        {
            list.Add(class2.method_20());
        }
        return list;
    }

    public void imethod_0(byte[] byte_0, IPEndPoint ipendPoint_0)
    {
        this.Send(byte_0, ipendPoint_0);
    }

    public void imethod_1(IPEndPoint ipendPoint_0)
    {
        byte[] buffer = Class156.IHeader0(this.string_0, ipendPoint_0).method_0();
        this.object_1.Send(buffer, ipendPoint_0);
    }

    public bool imethod_2(IPEndPoint ipendPoint_0)
    {
        Class116 class2 = this.safeDictionary_0.Get(ipendPoint_0);
        if (class2 == null)
        {
            return false;
        }
        return class2.method_11(1);
    }

    public void imethod_3(IPEndPoint ipendPoint_0)
    {
        Class116 class2 = this.safeDictionary_0.Get(ipendPoint_0);
        if (class2 != null)
        {
            class2.Close(SessionClosedCause.ActiveClose, false);
            this.OnUdpSessionClosed(class2, SessionClosedCause.ActiveClose);
        }
        Class100 class3 = this.safeDictionary_1.Get(ipendPoint_0);
        if (class3 != null)
        {
            class3.Close(SessionClosedCause.ActiveClose, false);
            this.OnUdpSessionClosed(class3, SessionClosedCause.ActiveClose);
        }
    }

    public void imethod_4()
    {
        foreach (Class116 class3 in this.safeDictionary_0.GetAllReadonly())
        {
            class3.Close(SessionClosedCause.ActiveClose, false);
            this.OnUdpSessionClosed(class3, SessionClosedCause.ActiveClose);
        }
        foreach (Class100 class2 in this.safeDictionary_1.GetAllReadonly())
        {
            class2.Close(SessionClosedCause.ActiveClose, false);
            this.OnUdpSessionClosed(class2, SessionClosedCause.ActiveClose);
        }
        this.safeDictionary_1.Clear();
        this.safeDictionary_0.Clear();
    }

    public void Initialize()
    {
    }

    public string method_0()
    {
        return this.string_0;
    }

    private void method_1(IPEndPoint ipendPoint_0, string string_1, ushort ushort_0)
    {
        Class116 class2 = this.safeDictionary_0.Get(ipendPoint_0);
        if (class2 != null)
        {
            class2.method_15(ushort_0);
        }
    }

    private void OnDataReceived(Interface17 interface17_0, byte[] byte_0)
    {
        if (this.DataReceived != null)
        {
            this.DataReceived(interface17_0.imethod_1(), byte_0);
        }
    }
   

    private void OnUdpSessionClosed(Interface17 interface17_0, SessionClosedCause sessionClosedCause_0)
    {
        if (interface17_0.imethod_0())
        {
            this.safeDictionary_0.Remove(interface17_0.imethod_1());
        }
        else
        {
            this.safeDictionary_1.Remove(interface17_0.imethod_1());
        }
        this.eventSafeTrigger_0.Action<Interface17, SessionClosedCause>("UdpSessionClosed", this.UdpSessionClosed, interface17_0, sessionClosedCause_0);
    }

    private void method_12(IPEndPoint ipendPoint_0)
    {
        byte[] buffer = Class156.IHeader5().method_0();
        this.object_1.Send(buffer, ipendPoint_0);
    }

    private void method_2(IPEndPoint ipendPoint_0)
    {
        Class116 class2 = this.safeDictionary_0.Get(ipendPoint_0);
        if (class2 != null)
        {
            class2.Close(SessionClosedCause.DestExit, false);
            this.OnUdpSessionClosed(class2, SessionClosedCause.DestExit);
        }
        Class100 class3 = this.safeDictionary_1.Get(ipendPoint_0);
        if (class3 != null)
        {
            class3.Close(SessionClosedCause.DestExit, false);
            this.OnUdpSessionClosed(class3, SessionClosedCause.DestExit);
        }
    }

    private void udpClient_DataReceived(IPEndPoint ipendPoint_0, byte[] byte_0)
    {
        try
        {
            IHeader1 class2 = IHeader1.smethod_0(byte_0);
            if (class2 != null)
            {
                if (class2.method_0() == 0)
                {
                    IPEndPointBody class4 = IPEndPointBody.smethod_0(byte_0, 4, class2.method_4());
                    this.OnUdpSessionOpened(class2.method_2(), class4.method_0(), ipendPoint_0, new AgileIPE(class4.method_2(), class4.method_4()));
                }
                else if (class2.method_0() == 1)
                {
                    this.OnUdpSessionOpened(ipendPoint_0, StringBody.smethod_0(byte_0, 4, class2.method_4()).method_0());
                }
                else
                {
                    Class100 class3;
                    if (class2.method_0() == 2)
                    {
                        class3 = this.safeDictionary_1.Get(ipendPoint_0);
                        if ((class3 != null) && (class3.method_1() == class2.method_2()))
                        {
                            DataFragmentBody class7 = DataFragmentBody.smethod_0(byte_0, 4, class2.method_4());
                            class3.method_8(class7);
                        }
                    }
                    else if (class2.method_0() == 4)
                    {
                        FeedbackVacancyBody body = FeedbackVacancyBody.Parse(byte_0, 4, class2.method_4());
                        Class116 class5 = this.safeDictionary_0.Get(ipendPoint_0);
                        if (class5 != null)
                        {
                            class5.method_18(body, true);
                        }
                    }
                    else if (class2.method_0() == 5)
                    {
                        this.method_2(ipendPoint_0);
                    }
                    else if (class2.method_0() == 6)
                    {
                        class3 = this.safeDictionary_1.Get(ipendPoint_0);
                        if (class3 != null)
                        {
                            class3.method_9();
                        }
                    }
                    else if (class2.method_0() == 7)
                    {
                        class3 = this.safeDictionary_1.Get(ipendPoint_0);
                        if ((class3 != null) && (class3.method_1() == class2.method_2()))
                        {
                            Class154 class8 = Class154.smethod_0(byte_0, 4, class2.method_4());
                            ushort num = (ushort) (0x2c + class8.BodyTotalLength);
                            this.class32_0.imethod_2(class3.imethod_2(), num);
                        }
                    }
                }
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Udp.Reliable.ReliableUdpEngine.udpClient_DataReceived", ErrorLevel.Standard);
        }
    }

    private void CircleQuickly()
    {
        int num = 0;
        int num2 = 10;
        while (this.object_0 == 0)
        {
            try
            {
                Thread.Sleep(10);
                foreach (Class100 class2 in this.safeDictionary_1.GetAllReadonly())
                {
                    class2.method_12(10);
                }
                if ((num % num2) == 0)
                {
                    foreach (Class116 class3 in this.safeDictionary_0.GetAllReadonly())
                    {
                        class3.method_16(100);
                    }
                }
                num++;
                continue;
            }
            catch (Exception exception)
            {
                this.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Udp.Reliable.ReliableUdpEngine.CircleQuickly", ErrorLevel.Standard);
                continue;
            }
        }
    }

    private void CircleQuickly2()
    {
        int num = 0;
        int num2 = 50;
        while (this.object_0 == 0)
        {
            try
            {
                Thread.Sleep(100);
                foreach (Class100 class2 in this.safeDictionary_1.GetAllReadonly())
                {
                    FeedbackVacancyBody body = class2.method_15();
                    if (body != null)
                    {
                        this.class32_0.imethod_1(class2.imethod_1(), body);
                    }
                }
                if ((num % num2) == 0)
                {
                    foreach (Class116 class3 in this.safeDictionary_0.GetAllReadonly())
                    {
                        class3.method_22();
                        class3.method_21();
                    }
                    foreach (Class100 class2 in this.safeDictionary_1.GetAllReadonly())
                    {
                        class2.method_17();
                    }
                }
                num++;
                continue;
            }
            catch (Exception exception)
            {
                this.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Udp.Reliable.ReliableUdpEngine.CircleQuickly2", ErrorLevel.Standard);
                continue;
            }
        }
    }

    private void method_6(IPEndPoint ipendPoint_0, FeedbackVacancyBody feedbackVacancyBody_0)
    {
        Class116 class2 = this.safeDictionary_0.Get(ipendPoint_0);
        if (class2 != null)
        {
            class2.method_18(feedbackVacancyBody_0, false);
        }
    }

    private void method_7(IPEndPoint ipendPoint_0, string string_1)
    {
        this.OnUdpSessionOpened(ipendPoint_0, string_1);
    }

    private void method_8(Interface17 interface17_0, SessionClosedCause sessionClosedCause_0)
    {
        this.OnUdpSessionClosed(interface17_0, sessionClosedCause_0);
    }

    public void OnUdpSessionOpened(byte byte_0, string string_1, IPEndPoint ipendPoint_0, AgileIPE agileIPE_0)
    {
        Class100 class2 = this.safeDictionary_1.Get(ipendPoint_0);
        if (class2 != null)
        {
            if (class2.method_1() == byte_0)
            {
                return;
            }
            class2.Close(SessionClosedCause.DestIdentityChanged, false);
            this.OnUdpSessionClosed(class2, SessionClosedCause.DestIdentityChanged);
        }
        Class100 class3 = new Class100((IPv6) this.object_1, byte_0, ipendPoint_0, string_1, this.int_1);
        class3.method_7(this.safeDictionary_0.Get(ipendPoint_0) != null);
        class3.Event_0 += new CbGeneric<Interface17, byte[]>(this.OnDataReceived);
        class3.SessionClosed += new CbGeneric<Interface17, SessionClosedCause>(this.method_8);
        this.safeDictionary_1.Add(ipendPoint_0, class3);
        this.eventSafeTrigger_0.Action<Interface17>("UdpSessionOpened", this.UdpSessionOpened, class3);
        byte[] buffer = Class156.IHeader1(this.string_0).method_0();
        this.object_1.Send(buffer, ipendPoint_0);
        this.class32_0.imethod_0(string_1, agileIPE_0, this.string_0);
    }

    private void OnUdpSessionOpened(IPEndPoint ipendPoint_0, string string_1)
    {
        Class116 class2 = new Class116((IPv6) this.object_1, ipendPoint_0, string_1, this.int_1);
        class2.SessionClosed += new CbGeneric<Interface17, SessionClosedCause>(this.method_8);
        this.safeDictionary_0.Add(ipendPoint_0, class2);
        Class100 class3 = this.safeDictionary_1.Get(ipendPoint_0);
        if (class3 != null)
        {
            class3.method_7(true);
        }
        this.eventSafeTrigger_0.Action<Interface17>("UdpSessionOpened", this.UdpSessionOpened, class2);
    }

    public void Send(byte[] byte_0, IPEndPoint ipendPoint_0)
    {
        if (byte_0.Length > this.int_0)
        {
            throw new Exception("Data Size overflow !");
        }
        Class116 class2 = this.safeDictionary_0.Get(ipendPoint_0);
        if (class2 != null)
        {
            class2.method_7(byte_0);
        }
    }
}

