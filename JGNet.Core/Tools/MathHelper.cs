using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Server.Tools
{
    public static class MathHelper
    {
        public static decimal Rounded(decimal d, int decimals)
        {
            return Math.Round(d, decimals, MidpointRounding.AwayFromZero);
        }

        public static double Rounded(double d, int decimals)
        {
            return Math.Round(d, decimals, MidpointRounding.AwayFromZero);
        }
    }
}
