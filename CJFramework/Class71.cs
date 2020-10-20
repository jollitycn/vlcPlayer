using CJBasic.Threading.Engines;
using System;

internal class Class71 : IEngineActor
{
    private AgileCycleEngine agileCycleEngine_0;
    private BasicOutter XjfvlYiJdt;

    public Class71()
    {
    }

    public Class71(BasicOutter class113_0, int int_0)
    {
        this.agileCycleEngine_0 = new AgileCycleEngine(this);
        this.agileCycleEngine_0.DetectSpanInSecs = int_0;
        this.XjfvlYiJdt = class113_0;
    }

    public bool EngineAction()
    {
        this.method_2();
        return true;
    }

    public void method_0()
    {
        if (this.agileCycleEngine_0.DetectSpanInSecs > 0)
        {
            this.agileCycleEngine_0.Start();
        }
    }

    public void method_1()
    {
        this.agileCycleEngine_0.Stop();
    }

    public void method_2()
    {
        if ((this.XjfvlYiJdt != null) && this.XjfvlYiJdt.method_1())
        {
            this.XjfvlYiJdt.SendHeartBeatMessage();
        }
    }
}

