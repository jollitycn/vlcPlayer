using CJPlus.FileTransceiver;
using System;
using System.Collections.Generic;
using System.IO;

internal class ResumedProjectItemOutter : IDisposable, IResumedProjectItemOutter
{
    private Dictionary<string, List<ResumedProjectItem>> dictionary_0 = new Dictionary<string, List<ResumedProjectItem>>();
    private int int_0 = 300;
    private object object_0 = new object();
    private object object_1 = null;

    public void Dispose()
    {
        foreach (List<ResumedProjectItem> list in this.dictionary_0.Values)
        {
            foreach (ResumedProjectItem item in new List<ResumedProjectItem>(list))
            {
                if (File.Exists(item.LocalTempFileSavePath))
                {
                    try
                    {
                        File.Delete(item.LocalTempFileSavePath);
                    }
                    catch
                    {
                    }
                }
            }
        }
        this.dictionary_0.Clear();
    }

    public void SetResumedProjectItem()
    {
        try
        {
            int num = 0;
            foreach (List<ResumedProjectItem> list in this.dictionary_0.Values)
            {
                foreach (ResumedProjectItem item in new List<ResumedProjectItem>(list))
                {
                    TimeSpan span = (TimeSpan) (DateTime.Now - item.DisrupttedTime);
                    if (span.TotalSeconds >= this.int_0)
                    {
                        num++;
                        list.Remove(item);
                        if (File.Exists(item.LocalTempFileSavePath))
                        {
                            File.Delete(item.LocalTempFileSavePath);
                        }
                    }
                }
            }
            if (num > 0)
            {
                Dictionary<string, List<ResumedProjectItem>> dictionary = this.dictionary_0;
                this.dictionary_0 = new Dictionary<string, List<ResumedProjectItem>>();
                foreach (string str in dictionary.Keys)
                {
                    if (dictionary[str].Count > 0)
                    {
                        this.dictionary_0.Add(str, dictionary[str]);
                    }
                }
            }
        }
        catch
        {
        }
    }

    public void UpdateResumedProjectItem(ResumedProjectItem resumedProjectItem_0)
    {
        if (this.int_0 <= 0)
        {
            try
            {
                if (File.Exists(resumedProjectItem_0.LocalTempFileSavePath))
                {
                    File.Delete(resumedProjectItem_0.LocalTempFileSavePath);
                }
            }
            catch
            {
            }
        }
        else
        {
            lock (this.object_0)
            {
                if (!this.dictionary_0.ContainsKey(resumedProjectItem_0.SenderID))
                {
                    this.dictionary_0.Add(resumedProjectItem_0.SenderID, new List<ResumedProjectItem>());
                }
                this.dictionary_0[resumedProjectItem_0.SenderID].Add(resumedProjectItem_0);
                this.SetResumedProjectItem();
            }
        }
    }

    public ResumedProjectItem GetResumedProjectItem(TransferingProject transferingProject_0)
    {
        if (this.int_0 <= 0)
        {
            return null;
        }
        ResumedProjectItem item2 = null;
        lock (this.object_0)
        {
            if (!this.dictionary_0.ContainsKey(transferingProject_0.SenderID))
            {
                return null;
            }
            foreach (ResumedProjectItem item3 in new List<ResumedProjectItem>(this.dictionary_0[transferingProject_0.SenderID]))
            {
                if ((((item3.OriginPath == transferingProject_0.OriginPath) && (item3.OriginSize == transferingProject_0.TotalSize)) && (item3.OriginLastUpdateTime == transferingProject_0.OriginLastUpdateTime)) && ((transferingProject_0.LocalSavePath == null) || (transferingProject_0.LocalSavePath == item3.LocalSavePath)))
                {
                    if (File.Exists(item3.LocalTempFileSavePath))
                    {
                        if (item2 == null)
                        {
                            item2 = item3;
                        }
                        else if (item3.DisrupttedTime > item2.DisrupttedTime)
                        {
                            item2 = item3;
                        }
                    }
                    else
                    {
                        this.dictionary_0[transferingProject_0.SenderID].Remove(item3);
                    }
                }
            }
            return item2;
        }
    }

    public void RemoveResumedProjectItem(ResumedProjectItem resumedProjectItem_0, bool bool_0)
    {
        if ((resumedProjectItem_0 != null) && (this.int_0 > 0))
        {
            lock (this.object_0)
            {
                if (this.dictionary_0.ContainsKey(resumedProjectItem_0.SenderID))
                {
                    if (bool_0 && File.Exists(resumedProjectItem_0.LocalTempFileSavePath))
                    {
                        File.Delete(resumedProjectItem_0.LocalTempFileSavePath);
                    }
                    this.dictionary_0[resumedProjectItem_0.SenderID].Remove(resumedProjectItem_0);
                }
            }
        }
    }

    public int TTL4ResumedFileItem
    {
        get
        {
            return this.int_0;
        }
        set
        {
            this.int_0 = value;
        }
    }
}

