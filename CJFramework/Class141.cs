using CJBasic.Collections;
using CJBasic.Loggers;
using CJBasic.Threading.Engines;
using CJFramework;
using System;
using System.Collections.Generic;
using System.Threading;

internal sealed class Class141 : IDisposable, IEngineActor, IProcess
{
    private AgileCycleEngine agileCycleEngine_0;
    private bool bool_0;
    private bool bool_1;
    private DispersiveKeyScope dispersiveKeyScope_0;
    private EmptyAgileLogger emptyAgileLogger_0;
    private IList<IProcess> ilist_0;
    private Interface13 interface13_0;
    private IActionType interface31_0;
    private object object_0;
    private Queue<IMessageHandler> queue_0;

    public Class141()
    {
        this.bool_0 = false;
        this.queue_0 = new Queue<IMessageHandler>();
        this.object_0 = new object();
        this.ilist_0 = new List<IProcess>();
        this.interface13_0 = null;
        this.dispersiveKeyScope_0 = new DispersiveKeyScope();
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.bool_1 = true;
    }

    public Class141(IEnumerable<IProcess> processers, Interface13 interface13_1)
    {
        this.bool_0 = false;
        this.queue_0 = new Queue<IMessageHandler>();
        this.object_0 = new object();
        this.ilist_0 = new List<IProcess>();
        this.interface13_0 = null;
        this.dispersiveKeyScope_0 = new DispersiveKeyScope();
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.bool_1 = true;
        this.ilist_0 = new List<IProcess>(processers);
        this.interface13_0 = interface13_1;
    }

    public bool CanProcess(int int_0)
    {
        return true;
    }

    public void Dispose()
    {
        if (this.agileCycleEngine_0 != null)
        {
            this.agileCycleEngine_0.StopAsyn();
        }
    }

    public bool EngineAction()
    {
        if (this.queue_0.Count == 0)
        {
            Thread.Sleep(2);
        }
        else
        {
            IMessageHandler interface2 = null;
            lock (this.object_0)
            {
                interface2 = this.queue_0.Dequeue();
            }
            IMessageHandler interface3 = this.method_10(interface2);
            if (interface3 != null)
            {
                this.interface31_0.Send(interface3, true, ActionTypeOnChannelIsBusy.Continue);
            }
        }
        return true;
    }

    public void method_0(IList<IProcess> value)
    {
        this.ilist_0 = value;
    }

    public void method_1(Interface13 interface13_1)
    {
        this.interface13_0 = interface13_1;
    }

    private IMessageHandler method_10(IMessageHandler interface37_0)
    {
        try
        {
            foreach (IProcess interface2 in this.ilist_0)
            {
                if (interface2.CanProcess(interface37_0.Header.MessageType))
                {
                    return interface2.ProcessMessage(interface37_0);
                }
            }
            this.emptyAgileLogger_0.Log("MessageTypeError", string.Format("Can't find Message Processer for MessageType [{0}].", interface37_0.Header.MessageType), "CJFramework.Passive.ContainerStylePassiveProcesser.HandleOneMessage", ErrorLevel.High);
            return null;
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, string.Format("CJFramework.Passive.ContainerStylePassiveProcesser.HandleOneMessage - {0}", interface37_0.ToString()), ErrorLevel.High);
            return null;
        }
    }

    public DispersiveKeyScope method_2()
    {
        return this.dispersiveKeyScope_0;
    }

    public void method_3(DispersiveKeyScope dispersiveKeyScope_1)
    {
        this.dispersiveKeyScope_0 = dispersiveKeyScope_1 ?? new DispersiveKeyScope();
    }

    public void method_4(IAgileLogger iagileLogger_0)
    {
        if (iagileLogger_0 != null)
        {
            this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        }
    }

    public bool method_5()
    {
        return this.bool_1;
    }

    public void method_6(bool bool_2)
    {
        if (this.bool_0 && (bool_2 != this.bool_1))
        {
            throw new Exception("Can't change the value of AsynMessageQueueEnabled after initialized.");
        }
        this.bool_1 = bool_2;
    }

    public void method_7(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    public void method_8()
    {
        if (this.bool_1)
        {
            this.agileCycleEngine_0 = new AgileCycleEngine(this);
            this.agileCycleEngine_0.DetectSpanInSecs = 0;
            this.agileCycleEngine_0.Start();
        }
        this.bool_0 = true;
    }

    public void method_9(int int_0)
    {
        this.dispersiveKeyScope_0.Add(int_0);
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        if (this.dispersiveKeyScope_0.Contains(interface37_0.Header.MessageType))
        {
            this.interface13_0.PushResponse(interface37_0);
            return null;
        }
        if (!this.bool_1)
        {
            return this.method_10(interface37_0);
        }
        lock (this.object_0)
        {
            this.queue_0.Enqueue(interface37_0);
        }
        return null;
    }
}

