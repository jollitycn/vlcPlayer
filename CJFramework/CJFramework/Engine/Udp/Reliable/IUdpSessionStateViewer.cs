namespace CJFramework.Engine.Udp.Reliable
{
    using System.Collections.Generic;
    using System.Net;

    public interface IUdpSessionStateViewer
    {
        List<InUdpSessionState> GetInUdpSessionStates();
        OutUdpSessionState GetOutUdpSessionState(IPEndPoint destIPE);
        List<OutUdpSessionState> GetOutUdpSessionStates();
    }
}

