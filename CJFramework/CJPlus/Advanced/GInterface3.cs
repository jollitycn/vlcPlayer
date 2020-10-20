namespace CJPlus.Advanced
{
    using CJFramework;
    using System;
    using System.Runtime.InteropServices;

    public interface GInterface3
    {
        PortListenerState GetPortListenerState();
        void GetTaskQueueInfo(out int taskCount, out int maxTaskCount);

        bool AsynConnectionEvent { get; set; }

        bool Boolean_0 { get; set; }

        int CheckFileZeroSpeedSpanInSecs { get; set; }

        bool CheckResponseTTL4Query { get; set; }

        CJPlus.Advanced.CustomizeInfoHandleMode CustomizeInfoHandleMode { get; set; }

        bool DiagnosticsEnabled { get; set; }

        GInterface6 DiagnosticsViewer { get; }

        int MaxChannelCacheSize { get; set; }

        int QueueWorkerThreadCount { get; set; }

        int SocketSendBuffSize { get; set; }

        int TempFile4ResumedTTL { get; set; }

        int UncompletedSendingCount4Busy { get; set; }

        bool UseWorkThreadPool { get; set; }

        int WriteTimeoutInSecs { get; set; }
    }
}

