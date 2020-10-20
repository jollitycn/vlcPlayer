using CJBasic;
using CJFramework;
using CJFramework.Engine.Udp.Reliable;
using System;
using System.Net;

internal interface Interface18
{
    event CbGeneric<IPEndPoint> ExitReceived;

    event CbGeneric<IPEndPoint, FeedbackVacancyBody> FeedbackVacancyReceived;

    event CbGeneric<IPEndPoint, string, ushort> PMTUTestAckReceived;

    event CbGeneric<IPEndPoint, string> SynAckReceived;

    void imethod_0(string string_0, AgileIPE agileIPE_0, string string_1);
    void imethod_1(IPEndPoint ipendPoint_0, FeedbackVacancyBody feedbackVacancyBody_0);
    void imethod_2(string string_0, ushort ushort_0);
    void imethod_3(string string_0);
}

