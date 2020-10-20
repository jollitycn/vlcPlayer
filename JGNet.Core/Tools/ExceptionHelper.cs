using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core
{
    public static class ExceptionHelper
    {
        public static Exception InnerException(Exception ee)
        {
            while (ee.InnerException != null)
            {
                ee = ee.InnerException;
            }
            return ee;
        }
    }
}
