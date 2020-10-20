using CJBasic;
using CJBasic.Loggers;
using CJFramework.Core;
using CJPlus.Application.Basic.Passive;
using System;
using System.Net;

internal class TcpPassiveEngine
{
    private IAgileLogger iagileLogger_0;
    private IBasicOutter ibasicOutter_0;
    private Interface26 object_0;

    public TcpPassiveEngine()
    {
    }

    public TcpPassiveEngine(Interface26 interface26_0, IBasicOutter ibasicOutter_1, IAgileLogger iagileLogger_1)
    {
        this.object_0 = interface26_0;
        this.ibasicOutter_0 = ibasicOutter_1;
        this.iagileLogger_0 = iagileLogger_1;
    }

    public void method_0(Interface26 interface26_0)
    {
        this.object_0 = interface26_0;
    }

    public void method_1(IBasicOutter ibasicOutter_1)
    {
        this.ibasicOutter_0 = ibasicOutter_1;
    }

    private void method_10()
    {
        this.iagileLogger_0.LogWithTime("TcpPassiveEngine Connection Rebuild Failure.");
    }

    private void method_11()
    {
        this.iagileLogger_0.LogWithTime("TcpPassiveEngine Connection Interrupted.");
    }

    public void method_2(IAgileLogger iagileLogger_1)
    {
        this.iagileLogger_0 = iagileLogger_1;
    }

    public void method_3()
    {
        this.object_0.ConnectionInterrupted += new CbGeneric(this.method_11);
        this.object_0.ConnectionRebuildFailure += new CbGeneric(this.method_10);
        this.object_0.ConnectionRebuildStart += new CbGeneric(this.method_9);
        this.object_0.ConnectionRebuildSucceed += new CbGeneric(this.method_8);
        this.object_0.EngineDisposed += new CbGeneric<IEngine>(this.method_7);
        this.object_0.InvalidMessageReceived += new CbGeneric<IPEndPoint, MessageInvalidType>(this.method_6);
        this.ibasicOutter_0.BeingKickedOut += new CbGeneric(this.method_5);
        this.ibasicOutter_0.BeingPushedOut += new CbGeneric(this.method_4);
    }

    private void method_4()
    {
        this.iagileLogger_0.LogWithTime("Being Pushed Out.[notify from server]");
    }

    private void method_5()
    {
        this.iagileLogger_0.LogWithTime("Being Kicked Out.[notify from server]");
    }

    private void method_6(IPEndPoint ipendPoint_0, MessageInvalidType messageInvalidType_0)
    {
        this.iagileLogger_0.LogWithTime(string.Format("TcpPassiveEngine Invalid Message Received. Invalid Type:{0}", messageInvalidType_0));
    }

    private void method_7(IEngine interface3_0)
    {
        this.iagileLogger_0.LogWithTime("TcpPassiveEngine Disposed.");
    }

    private void method_8()
    {
        this.iagileLogger_0.LogWithTime("TcpPassiveEngine Connection Rebuild Succeed.");
    }

    private void method_9()
    {
        this.iagileLogger_0.LogWithTime("TcpPassiveEngine Connection Rebuild Start.");
    }
}

