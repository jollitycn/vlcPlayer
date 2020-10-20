using CJBasic;
using CJFramework;
using CJFramework.Engine.Udp.Reliable;
using System;
using System.Net;
using System.Threading;

internal class Class32 : Interface18
{
    public event CbGeneric<IPEndPoint> ExitReceived;

    public event CbGeneric<IPEndPoint, FeedbackVacancyBody> FeedbackVacancyReceived;

    public event CbGeneric<IPEndPoint, string, ushort> PMTUTestAckReceived;

    public event CbGeneric<IPEndPoint, string> SynAckReceived;

    public void imethod_0(string string_0, AgileIPE agileIPE_0, string string_1)
    {
    }

    public void imethod_1(IPEndPoint ipendPoint_0, FeedbackVacancyBody feedbackVacancyBody_0)
    {
    }

    public void imethod_2(string string_0, ushort ushort_0)
    {
    }

    public void imethod_3(string string_0)
    {
    }
}

