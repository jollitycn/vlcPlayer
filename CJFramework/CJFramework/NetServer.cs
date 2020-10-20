namespace CJFramework
{
    using System;

    public static class NetServer
    {
        public const string MultiUserID = "*";
        public const string SystemUserID = "_0";

        public static bool IsServerUser(string userID)
        {
            return ((userID == "_0") || string.IsNullOrEmpty(userID));
        }
    }
}

