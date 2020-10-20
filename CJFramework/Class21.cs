using CJFramework;
using CJPlus.Advanced;
using System;
using System.Runtime.InteropServices;

internal class Class21 : BaseOptions, GInterface3
{
    private bool bool_2 = false;
    private bool bool_3 = false;
    private bool bool_4 = true;
    private bool bool_5 = false;
    private WorkProcesser class109_0;
    private CJPlus.Advanced.CustomizeInfoHandleMode customizeInfoHandleMode_0 = CJPlus.Advanced.CustomizeInfoHandleMode.IocpDirectly;
    private GInterface6 ginterface6_0;
    private int int_5 = 20;
    private int int_6 = 0;
    private IConnection interface19_0;

    public PortListenerState GetPortListenerState()
    {
        return this.interface19_0.GetPortListenerState();
    }

    public void GetTaskQueueInfo(out int taskCount, out int maxTaskCount)
    {
        taskCount = 0;
        maxTaskCount = 0;
        if (this.class109_0 != null)
        {
            this.class109_0.method_1(out taskCount, out maxTaskCount);
        }
    }

    public void method_0(IConnection interface19_1, GInterface6 ginterface6_1, WorkProcesser class109_1)
    {
        this.interface19_0 = interface19_1;
        this.ginterface6_0 = ginterface6_1;
        this.class109_0 = class109_1;
        this.bool_5 = true;
    }

    public bool AsynConnectionEvent
    {
        get
        {
            return this.bool_4;
        }
        set
        {
            if (this.bool_5 && (value != this.bool_4))
            {
                throw new Exception("Can't change the value of AsynConnectionEvent after initialized");
            }
            this.bool_4 = value;
        }
    }

    public bool Boolean_0
    {
        get
        {
            return this.bool_3;
        }
        set
        {
            if (this.bool_5 && (value != this.bool_3))
            {
                throw new Exception("Can't change the value of IPv6Enabled after initialized");
            }
            this.bool_3 = value;
        }
    }

    public CJPlus.Advanced.CustomizeInfoHandleMode CustomizeInfoHandleMode
    {
        get
        {
            return this.customizeInfoHandleMode_0;
        }
        set
        {
            if (this.bool_5 && (value != this.customizeInfoHandleMode_0))
            {
                throw new Exception("Can't change the value of CustomizeInfoHandleMode after initialized");
            }
            this.customizeInfoHandleMode_0 = value;
        }
    }

    public bool DiagnosticsEnabled
    {
        get
        {
            return this.bool_2;
        }
        set
        {
            if (this.bool_5 && (value != this.bool_2))
            {
                throw new Exception("Can't change the value of DiagnosticsEnabled after initialized");
            }
            this.bool_2 = value;
        }
    }

    public GInterface6 DiagnosticsViewer
    {
        get
        {
            return this.ginterface6_0;
        }
    }

    public int MaxChannelCacheSize
    {
        get
        {
            return this.int_6;
        }
        set
        {
            if (this.bool_5 && (value != this.int_6))
            {
                throw new Exception("Can't change the value of MaxChannelCacheSize after initialized");
            }
            this.int_6 = value;
        }
    }

    public int QueueWorkerThreadCount
    {
        get
        {
            return this.int_5;
        }
        set
        {
            if (this.bool_5 && (value != this.int_5))
            {
                throw new Exception("Can't change the value of QueueWorkerThreadCount after initialized");
            }
            this.int_5 = value;
        }
    }
}

