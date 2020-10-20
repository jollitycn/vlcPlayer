namespace CJBasic.Helpers
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct CpuInfo
    {
        public string Name;
        public uint ClockSpeed;
        public uint CoreCount;
        public CpuInfo(string name, uint speed, uint coreCount)
        {
            this.Name = name;
            this.ClockSpeed = speed;
            this.CoreCount = coreCount;
        }
    }
}

