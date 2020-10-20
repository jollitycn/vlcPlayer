namespace CJPlus
{
    using CJFramework;
    using CJPlus.Serialization;
    using System;

    public static class GlobalUtil
    {
        private static int int_0 = 0x5000;

        public static VersionType GetVersionType()
        {
            return Class62.GetVersionType();
        }

        public static void SetAuthorizedUser(string userID, string pwd)
        {
            Class62.SetAuthorizedUser(userID, pwd);
        }

        public static void SetDogServerIP(string ip)
        {
            Class62.lnSukhqmte(ip);
        }

        public static void SetMaxLengthOfMessage(int maxLen)
        {
            int_0 = maxLen;
        }

        public static void SetMaxLengthOfUserID(byte maxLen)
        {
            Class41.SetMaxLengthOfUserID(maxLen);
        }

        public static void SetStartCode(string code)
        {
            Class62.SetStartCode(code);
        }

        public static void Test()
        {
            string s = "/wQtAQgAAAD7AAAAA2lvcwAAAAAAAAAAAl8wAAAAAAAAAAAA9wAAAAAAAAAAAMBpjJvU0AjVAAAAL1VzZXJzL0xhd3JlbmNlL0xpYnJhcnkvRGV2ZWxvcGVyL0NvcmVTaW11bGF0b3IvRGV2aWNlcy9GNDJFNzkyQy04NDQ3LTRCQ0QtQjVGOS1EMzA5MzNDNkM1NTQvZGF0YS9Db250YWluZXJzL0RhdGEvQXBwbGljYXRpb24vMEQ3MDZCNkEtMThDQS00Q0EwLUE4NEItN0M4NEJBRTdCOEJFL0RvY3VtZW50cy8xMDZFOTlBMS00RjZBLTQ1QTItQjMyMC1CMEFENEE4RTg0NzMuSlBHBQAAAGlvc18x8iMeAQAAAAA=";
            byte[] buffer = Convert.FromBase64String(s);
            Class41.smethod_1(buffer, 0);
            CompactPropertySerializer.Default.Deserialize<Application.FileTransfering.BeginSendFileContract>(buffer, Class41.int_1);
        }

        public static int MaxLengthOfMessage
        {
            get
            {
                return int_0;
            }
        }
    }
}

