using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JGNet.Common.Core
{
    [Serializable]
    public class NoPermissonException : Exception
    {
        public NoPermissonException(String permission) : base("没有" + permission + "权限！")
        {
        }
    }
}
