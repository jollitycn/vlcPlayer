using CJBasic.ObjectManagement.Managers;
using CJPlus.Advanced;
using System;
using System.Collections.Generic;
using System.Threading;

internal class Class66 : GInterface6
{
    private int int_0 = 0;
    private SafeDictionary<int, InfoHandleRecordStatistics> safeDictionary_0 = new SafeDictionary<int, InfoHandleRecordStatistics>();
    private SafeDictionary<int, InfoHandleRecord> safeDictionary_1 = new SafeDictionary<int, InfoHandleRecord>();

    public List<InfoHandleRecordStatistics> GetCustomizeInfoStatistics()
    {
        return this.safeDictionary_0.GetAll();
    }

    public ThreadPoolInfo GetThreadPoolInfo()
    {
        return new ThreadPoolInfo();
    }

    public List<InfoHandleRecord> GetUncommittedCustomizeInfos()
    {
        return this.safeDictionary_1.GetAll();
    }

    public int method_0(int int_1, InformationStyle informationStyle_0)
    {
        int id = Interlocked.Increment(ref this.int_0);
        InfoHandleRecord record = new InfoHandleRecord(id, int_1, informationStyle_0);
        this.safeDictionary_1.Add(id, record);
        return id;
    }

    public void method_1(int int_1, bool bool_0)
    {
        InfoHandleRecord record = this.safeDictionary_1.Get(int_1);
        record.method_0();
        this.safeDictionary_1.Remove(int_1);
        if (!this.safeDictionary_0.Contains(record.InformationType))
        {
            this.safeDictionary_0.Add(record.InformationType, new InfoHandleRecordStatistics(record.InformationType, record.InformationStyle));
        }
        this.safeDictionary_0.Get(record.InformationType).method_0(record, bool_0);
    }
}

