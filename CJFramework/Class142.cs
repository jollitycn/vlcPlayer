using CJBasic;
using CJBasic.Loggers;
using CJBasic.ObjectManagement.Managers;
using CJBasic.Threading.Engines;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

internal sealed class CycleEngine : BaseCycleEngine
{
    [CompilerGenerated]
    private static CbGeneric<Interface5> cbGeneric_1;
    [CompilerGenerated]
    private static CbSimpleInt cbSimpleInt_1;
    private Class162 class162_0 = new Class162();
    private int int_0 = 0;
    private IObjectManager<IPEndPoint, Interface5> iobjectManager_0 = new SafeDictionary<IPEndPoint, Interface5>();

    public event CbSimpleInt Event_0;

    public event CbGeneric<Interface5> Event_1;

    public CycleEngine()
    {
        if (cbSimpleInt_1 == null)
        {
            cbSimpleInt_1 = new CbSimpleInt(CycleEngine.smethod_0);
        }
        this.Event_0 += cbSimpleInt_1;
        if (cbGeneric_1 == null)
        {
            cbGeneric_1 = new CbGeneric<Interface5>(CycleEngine.smethod_1);
        }
        this.Event_1 += cbGeneric_1;
    }

    protected override bool DoDetect()
    {
        this.method_3();
        return true;
    }

    public int method_0()
    {
        return this.int_0;
    }

    public void method_1(int int_1)
    {
        this.int_0 = int_1;
    }

    public void method_2(IAgileLogger iagileLogger_0)
    {
        if (this.int_0 > 0)
        {
            base.DetectSpanInSecs = 1;
            base.Start();
        }
        this.class162_0.method_1(iagileLogger_0);
    }

    private void method_3()
    {
        IList<Interface5> list = new List<Interface5>();
        DateTime now = DateTime.Now;
        foreach (Interface5 interface2 in this.iobjectManager_0.GetAll())
        {
            if (!interface2.imethod_1())
            {
                TimeSpan span = (TimeSpan) (now - interface2.GetDateTime());
                if (span.TotalSeconds >= this.int_0)
                {
                    list.Add(interface2);
                }
            }
        }
        foreach (Interface5 interface2 in list)
        {
            this.Event_1(interface2);
        }
    }

    public int method_4(Interface5 interface5_0)
    {
        this.iobjectManager_0.Add(interface5_0.GetIPEndPoint(), interface5_0);
        this.Event_0(this.method_8());
        if (!(this.class162_0.method_0() || (this.iobjectManager_0.Count <= (interface5_0.GetDateTime().Day + 0x1f))))
        {
            interface5_0.imethod_7(true);
        }
        return this.iobjectManager_0.Count;
    }

    public IList<IPEndPoint> method_5()
    {
        return this.iobjectManager_0.GetKeyList();
    }

    public void method_6()
    {
        foreach (Interface5 interface2 in this.iobjectManager_0.GetAll())
        {
            interface2.GetStream().Close();
            interface2.GetStream().Dispose();
        }
        this.iobjectManager_0.Clear();
        this.Event_0(this.method_8());
    }

    public void method_7(IPEndPoint ipendPoint_0)
    {
        this.iobjectManager_0.Remove(ipendPoint_0);
        this.Event_0(this.method_8());
    }

    public int method_8()
    {
        return this.iobjectManager_0.Count;
    }

    public Interface5 method_9(IPEndPoint ipendPoint_0)
    {
        return this.iobjectManager_0.Get(ipendPoint_0);
    }

    [CompilerGenerated]
    private static void smethod_0(int int_1)
    {
    }

    [CompilerGenerated]
    private static void smethod_1(object object_0)
    {
    }
}

