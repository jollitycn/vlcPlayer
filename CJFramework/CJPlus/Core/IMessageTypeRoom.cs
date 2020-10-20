namespace CJPlus.Core
{
    using System;
    using System.Collections.Generic;

    public interface IMessageTypeRoom
    {
        bool Contains(int messageType);
        void Initialize();

        int MaxKeyValue { get; }

        IList<int> PushKeyList { get; }

        int StartKey { get; set; }
    }
}

