using CJBasic.Helpers;
using CJBasic.ObjectManagement.Managers;
using CJBasic.Threading.Engines;
using System;
using System.Threading;

internal sealed class Class72 : IDisposable, IEngineActor, Interface13
{
    private AgileCycleEngine agileCycleEngine_0;
    private int int_0 = 5;
    private int int_1 = 30;
    private Interface26 interface26_0;
    private SafeDictionary<string, Class74> safeDictionary_0 = new SafeDictionary<string, Class74>();
    private SafeDictionary<string, Class73> safeDictionary_1 = new SafeDictionary<string, Class73>();

    public Class72(int int_2, int int_3)
    {
        this.int_0 = int_2;
        this.int_1 = int_3;
        if (this.int_0 > 0)
        {
            this.agileCycleEngine_0 = new AgileCycleEngine(this);
            this.agileCycleEngine_0.DetectSpanInSecs = 1;
            this.agileCycleEngine_0.Start();
        }
    }

    public void Dispose()
    {
        if (this.agileCycleEngine_0 != null)
        {
            this.agileCycleEngine_0.Stop();
        }
    }

    public bool EngineAction()
    {
        DateTime now;
        TimeSpan span;
        if (this.safeDictionary_1.Count > 0)
        {
            now = DateTime.Now;
            foreach (Class73 class2 in this.safeDictionary_1.GetAll())
            {
                span = (TimeSpan) (now - class2.method_2());
                if (span.TotalMilliseconds > (this.int_0 * 0x3e8))
                {
                    this.safeDictionary_1.Remove(class2.Key);
                }
            }
        }
        if (this.safeDictionary_0.Count > 0)
        {
            now = DateTime.Now;
            foreach (Class74 class3 in this.safeDictionary_0.GetAll())
            {
                span = (TimeSpan) (now - class3.method_0());
                if (span.TotalMilliseconds > (this.int_1 * 0x3e8))
                {
                    this.safeDictionary_0.Remove(class3.Key);
                    if (class3.method_1() != null)
                    {
                        class3.method_1()(new TimeoutException("Timeout waiting for reply!"), null, class3.method_2());
                    }
                }
            }
        }
        return true;
    }

    public void SetEngine(IEngine interface3_0)
    {
        this.interface26_0 = interface3_0 as Interface26;
    }

    private string method_1(int int_2, int int_3)
    {
        return string.Format("{0}_{1}", int_2, int_3);
    }

    public IMessageHandler PickupResponse(int int_2, int int_3)
    {
        Class73 class2;
        bool flag = !Thread.CurrentThread.IsBackground;
        DateTime now = DateTime.Now;
        string id = this.method_1(int_2, int_3);
    Label_0074:
        class2 = this.safeDictionary_1.Get(id);
        if (class2 == null)
        {
            if (!((this.interface26_0 == null) || this.interface26_0.Connected))
            {
                throw new Exception("Network connection is disconnected!");
            }
            if (this.int_1 > 0)
            {
                TimeSpan span = (TimeSpan) (DateTime.Now - now);
                if (span.TotalSeconds >= this.int_1)
                {
                    throw new TimeoutException("Timeout waiting for reply!");
                }
            }
            if (flag)
            {
                WindowsHelper.DoWindowsEvents();
            }
            Thread.Sleep(5);
            goto Label_0074;
        }
        this.safeDictionary_1.Remove(id);
        return class2.method_0();
    }

    public void PushResponse(IMessageHandler interface37_0)
    {
        string id = this.method_1(interface37_0.Header.MessageType, interface37_0.Header.MessageID);
        Class74 class2 = this.safeDictionary_0.Get(id);
        if (class2 != null)
        {
            this.safeDictionary_0.Remove(id);
            if (class2.method_1() != null)
            {
                class2.method_1()(null, interface37_0, class2.method_2());
            }
        }
        else
        {
            this.safeDictionary_1.Add(id, new Class73(id, interface37_0, DateTime.Now));
        }
    }

    public void RegisterCallback(int int_2, int int_3, Delegate0 delegate0_0, object object_0)
    {
        string str = this.method_1(int_2, int_3);
        Class74 class2 = new Class74(str, delegate0_0, object_0);
        this.safeDictionary_0.Add(str, class2);
    }

    public int Int32_0
    {
        get
        {
            return this.int_0;
        }
    }

    public int TimeoutSec
    {
        get
        {
            return this.int_1;
        }
    }
}

