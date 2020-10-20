using CJBasic;
using CJBasic.Threading.Engines;
using System;
using System.Runtime.InteropServices;

internal class WorkProcesser : IWorkProcesser<IMessageHandler>
{
    private CbGeneric<IMessageHandler> cbGeneric_0;
    private WorkerEngine<IMessageHandler> workerEngine_0 = new WorkerEngine<IMessageHandler>();

    public WorkProcesser(int int_0, CbGeneric<IMessageHandler> handler)
    {
        this.cbGeneric_0 = handler;
        this.workerEngine_0.WorkerThreadCount = int_0;
        this.workerEngine_0.WorkProcesser = this;
        this.workerEngine_0.Initialize(0x186a0);
        this.workerEngine_0.Start();
    }

    public void HandleMessage(IMessageHandler interface37_0)
    {
        this.workerEngine_0.AddWork(interface37_0);
    }

    public void method_1(out int int_0, out int int_1)
    {
        int_0 = this.workerEngine_0.WorkCount;
        int_1 = this.workerEngine_0.MaxWaitWorkCount;
    }

    public void Process(IMessageHandler work)
    {
        this.cbGeneric_0(work);
    }
}

