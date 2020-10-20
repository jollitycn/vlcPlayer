using CJPlus.FileTransceiver;
using System;

internal interface IResumedProjectItemOutter : IDisposable
{
    void SetResumedProjectItem();
    void UpdateResumedProjectItem(ResumedProjectItem resumedProjectItem_0);
    ResumedProjectItem GetResumedProjectItem(TransferingProject transferingProject_0);
    void RemoveResumedProjectItem(ResumedProjectItem resumedProjectItem_0, bool bool_0);
    int TTL4ResumedFileItem { get; set; }
}

