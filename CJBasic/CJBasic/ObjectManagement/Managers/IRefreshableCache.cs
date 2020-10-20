namespace CJBasic.ObjectManagement.Managers
{
    using System;

    public interface IRefreshableCache
    {
        void Refresh();

        DateTime LastRefreshTime { get; set; }

        int RefreshSpanInSecs { get; }
    }
}

