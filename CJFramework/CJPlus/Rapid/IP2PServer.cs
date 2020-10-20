namespace CJPlus.Rapid
{
    using System;

    public interface IP2PServer : IDisposable
    {
        void Initialize(int udpPort);
    }
}

