namespace CJBasic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Management;
    using System.Runtime.InteropServices;

    public static class MachineHelper
    {
        private static PerformanceCounter CpuPerformanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private static PerformanceCounter MemPerformanceCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use", "");

        public static List<CpuInfo> GetCpuInfo()
        {
            ManagementObjectCollection objects = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_Processor").Get();
            long num = 0;
            foreach (ManagementObject obj2 in objects)
            {
                num++;
            }
            List<CpuInfo> list = new List<CpuInfo>();
            foreach (ManagementObject obj2 in objects)
            {
                list.Add(new CpuInfo(obj2.GetPropertyValue("Name").ToString(), (uint) obj2.GetPropertyValue("CurrentClockSpeed"), (uint) (((long) Environment.ProcessorCount) / ((long) num))));
            }
            return list;
        }

        public static ulong GetDiskFreeSpace(string diskName)
        {
            ulong lpFreeBytesAvailable = 0L;
            ulong lpTotalNumberOfBytes = 0L;
            ulong lpTotalNumberOfFreeBytes = 0L;
            GetDiskFreeSpaceEx(diskName, out lpFreeBytesAvailable, out lpTotalNumberOfBytes, out lpTotalNumberOfFreeBytes);
            return lpFreeBytesAvailable;
        }

        [DllImport("kernel32.dll")]
        private static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);
        public static IList<string> GetMacAddress()
        {
            ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
            IList<string> list = new List<string>();
            foreach (ManagementObject obj2 in instances)
            {
                if ((bool) obj2["IPEnabled"])
                {
                    list.Add(obj2["MacAddress"].ToString().Replace(":", ""));
                }
                obj2.Dispose();
            }
            return list;
        }

        public static void GetPerformanceUsage(out float cpuUsage, out float memoryUsage)
        {
            cpuUsage = CpuPerformanceCounter.NextValue();
            ulong num = 0L;
            ulong num2 = 0L;
            ManagementClass class2 = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject obj2 in class2.GetInstances())
            {
                if (obj2["TotalVisibleMemorySize"] != null)
                {
                    num = (ulong) obj2["TotalVisibleMemorySize"];
                }
                if (obj2["FreePhysicalMemory"] != null)
                {
                    num2 = (ulong) obj2["FreePhysicalMemory"];
                }
                break;
            }
            class2.Dispose();
            if (num == 0L)
            {
                memoryUsage = 0f;
            }
            else
            {
                memoryUsage = ((num - num2) * ((ulong) 100L)) / num;
            }
        }

        public static ulong GetPhysicalMemorySize()
        {
            ulong num = 0L;
            ulong num2 = 0L;
            ManagementClass class2 = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject obj2 in class2.GetInstances())
            {
                if (obj2["TotalVisibleMemorySize"] != null)
                {
                    num = (ulong) obj2["TotalVisibleMemorySize"];
                }
                if (obj2["FreePhysicalMemory"] != null)
                {
                    num2 = (ulong) obj2["FreePhysicalMemory"];
                }
                break;
            }
            class2.Dispose();
            return num;
        }

        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
        public static bool IsCurrentMachine(string macAddress)
        {
            return GetMacAddress().Contains(macAddress);
        }

        public static bool IsGreater(string ss)
        {
            return (DateTime.Now > DateTime.Parse("20" + ss));
        }

        [DllImport("sensapi.dll")]
        private static extern bool IsNetworkAlive(out int connectionDescription);
        public static bool IsNetworkConnected()
        {
            int num;
            return IsNetworkAlive(out num);
        }

        public static bool IsNetworkConnected2()
        {
            int num;
            return InternetGetConnectedState(out num, 0);
        }
    }
}

