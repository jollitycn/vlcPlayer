using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Common.Core.Util
{
  public  class MathUtil
    {
        //获取随机种子
        public static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

    }
}
