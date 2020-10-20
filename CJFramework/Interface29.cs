using System;
using System.Net;

internal interface Interface29 : IDisposable, IEngine, ICommitMessageToServer, IUdpHelper
{
    void CommitMessageToServer(IMessageHandler interface37_0, IPEndPoint ipendPoint_0);
    void SendMessage(IMessageHandler interface37_0, IPEndPoint ipendPoint_0);
}

