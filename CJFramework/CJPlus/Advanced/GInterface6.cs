namespace CJPlus.Advanced
{
    using System.Collections.Generic;

    public interface GInterface6
    {
        List<InfoHandleRecordStatistics> GetCustomizeInfoStatistics();
        ThreadPoolInfo GetThreadPoolInfo();
        List<InfoHandleRecord> GetUncommittedCustomizeInfos();
    }
}

