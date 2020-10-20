namespace CJPlus.Rapid
{
    using System;

    public static class RapidEngineFactory
    {
        public static IP2PServer CreateP2PServer()
        {
            return new P2PServer();
        }

        public static RapidPassiveEngine CreatePassiveEngine()
        {
            return new RapidPassiveEngine();
        }

        public static IRapidServerEngine CreateServerEngine()
        {
            return new ServerEngine();
        }
    }
}

