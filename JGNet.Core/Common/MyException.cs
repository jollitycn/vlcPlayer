using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Common
{
    public class MyException : ApplicationException
    {
        public MyException()
        { }
        
        public MyException(string message) : base(message)
        { }
        
        public MyException(string message, Exception inner) : base(message, inner)
        { }

    }
}
