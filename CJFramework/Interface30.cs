using CJFramework;
using CJFramework.Engine.Udp.Reliable;
using CJFramework.Server.UserManagement;
using CJPlus.Application.P2PSession;
using System;
using System.Net;

internal interface Interface30
{
    UserAddressInfo GetUserData(string string_0);
    void imethod_0(string string_0);
    void imethod_1(string string_0);
    IPEndPoint imethod_2();
    void imethod_3(P2PAddress p2PAddress_0);
    void imethod_4(string string_0, FeedbackVacancyBody feedbackVacancyBody_0);
    void imethod_5(string string_0, AgileIPE agileIPE_0, string string_1);
    void imethod_6(AgileIPE agileIPE_0, string string_0);
    void imethod_7(string string_0, ushort ushort_0);
}

