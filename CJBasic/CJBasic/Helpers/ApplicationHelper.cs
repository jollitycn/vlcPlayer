namespace CJBasic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    public static class ApplicationHelper
    {
        private static Dictionary<string, Mutex> MutexForSingletonExeDic = new Dictionary<string, Mutex>();

        public static bool IsAppInstanceExist(string instanceName)
        {
            bool createdNew = false;
            Mutex mutex = new Mutex(false, instanceName, out createdNew);
            if (createdNew)
            {
                MutexForSingletonExeDic.Add(instanceName, mutex);
            }
            return !createdNew;
        }

        public static void OpenUrl(string url)
        {
            Process.Start(url);
        }

        public static void ReleaseAppInstance(string instanceName)
        {
            Mutex mutex = null;
            if (MutexForSingletonExeDic.ContainsKey(instanceName))
            {
                mutex = MutexForSingletonExeDic[instanceName];
            }
            if (mutex != null)
            {
                mutex.Close();
                MutexForSingletonExeDic.Remove(instanceName);
            }
        }

        public static void StartApplication(string appFilePath)
        {
            Process process = new Process();
            process.StartInfo.FileName = appFilePath;
            process.Start();
        }
    }
}

