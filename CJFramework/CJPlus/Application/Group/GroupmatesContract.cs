namespace CJPlus.Application.Group
{
    using System;
    using System.Collections.Generic;

    public class GroupmatesContract : Groupmates
    {
        public GroupmatesContract()
        {
        }

        public GroupmatesContract(List<string> online, List<string> offline)
        {
            base.OnlineGroupmates = online;
            base.OfflineGroupmates = offline;
        }
    }
}

