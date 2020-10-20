using CJBasic.ObjectManagement.Managers;
using CJBasic.Threading.Engines;
using System;

internal class Class38 : BaseCycleEngine
{
    private int int_0 = 6;
    private ObjectManager<string, DateTime> objectManager_0 = new ObjectManager<string, DateTime>();

    public Class38()
    {
        base.DetectSpanInSecs = 2;
        base.Start();
    }

    protected override bool DoDetect()
    {
        if (this.objectManager_0.Count != 0)
        {
            this.objectManager_0.RemoveByPredication(new Predicate<DateTime>(this.method_2));
        }
        return true;
    }

    public void method_0(string string_0)
    {
        this.objectManager_0.Add(string_0, DateTime.Now);
    }

    public bool method_1(string string_0)
    {
        return this.objectManager_0.Contains(string_0);
    }

    private bool method_2(DateTime dateTime_0)
    {
        TimeSpan span = (TimeSpan) (DateTime.Now - dateTime_0);
        return (span.TotalSeconds > this.int_0);
    }
}

