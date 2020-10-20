namespace CJBasic.Threading
{
    using CJBasic;
    using CJBasic.Loggers;
    using System;
    using System.Threading;

    public class ThreadPoolTester
    {
        private FileAgileLogger logger;

        public ThreadPoolTester()
        {
            this.logger = new FileAgileLogger(AppDomain.CurrentDomain.BaseDirectory + "ThreadPoolTestLog.txt");
        }

        public ThreadPoolTester(string logPath)
        {
            this.logger = new FileAgileLogger(AppDomain.CurrentDomain.BaseDirectory + "ThreadPoolTestLog.txt");
            this.logger = new FileAgileLogger(logPath);
        }

        public void TestOne()
        {
            int workerThreads = 0;
            int completionPortThreads = 0;
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            string str = string.Format("Available worker : {0} , iocp : {1} .", workerThreads, completionPortThreads);
            string str2 = string.Format("{0}{1}{2}{3}", new object[] { DateTime.Now.Hour.ToString("00"), DateTime.Now.Minute.ToString("00"), DateTime.Now.Second.ToString("00"), DateTime.Now.Millisecond.ToString("000") });
            this.logger.LogWithTime(string.Format("准备启动线程{0}...   -- 【{1}】", str2, str));
            new CbGeneric<string>(this.TestThread).BeginInvoke(str2, null, null);
        }

        private void TestThread(string id)
        {
            int workerThreads = 0;
            int completionPortThreads = 0;
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            string str = string.Format("Available worker : {0} , iocp : {1} .", workerThreads, completionPortThreads);
            this.logger.LogWithTime(string.Format("成功启动线程{0}。    -- 【{1}】", id, str));
        }
    }
}

