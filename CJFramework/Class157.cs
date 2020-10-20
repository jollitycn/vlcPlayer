using System;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

internal static class Class157
{
    public static Interface26 CreateInterface26(Enum6 enum6_0)
    {
        if (enum6_0 == ((Enum6) 0))
        {
            return new PassiveStreamTcpEngine();
        }
        return new PassiveTextTcpEngine();
    }

    public static IConnection smethod_0(Enum6 enum6_0, bool bool_0, X509Certificate2 x509Certificate2_0, SslProtocols sslProtocols_0, bool bool_1)
    {
        if (enum6_0 == ((Enum6) 0))
        {
            if (bool_0)
            {
                return new WebSocketEngine(x509Certificate2_0, sslProtocols_0, bool_1);
            }
            return new StreamTcpEngine();
        }
        return new TextTcpEngine();
    }

    public static Interface43 smethod_1()
    {
        return new Class83();
    }

    public static Interface29 smethod_2()
    {
        return new Class82();
    }
}

