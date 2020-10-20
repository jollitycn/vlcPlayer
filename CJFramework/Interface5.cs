using CJFramework;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

internal interface Interface5
{
    DateTime GetDateTime();
    bool imethod_1();
    Class47 imethod_10();
    void imethod_11(ref byte[] byte_0);
    void imethod_12();
    void imethod_13(string string_0);
    void imethod_14();
    void imethod_15();
    void imethod_16();
    void imethod_17();
    void imethod_18(out int int_0, out int int_1);
    int imethod_19();
    ClientType GetClientType();
    void SetClientType(ClientType clientType_0);
    Enum4 imethod_4();
    void imethod_5(Enum4 enum4_0);
    bool imethod_6();
    void imethod_7(bool bool_0);
    Stream GetStream();
    IPEndPoint GetIPEndPoint();
    bool VerifyUser(string string_0);

    bool ChannelIsBusy { get; }

    string UserID { get; }
}

