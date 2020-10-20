using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Tools
{
    public static class StringHelper
    {
        /// <summary>
        /// 将比率转化为加%号的字符串 (参数是正数，加“+”符号)
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        public static string RateToWithPercentAndPlusSign(double rate)
        {
            string name = rate * 100 + "%";
            if (rate > 0)
            {
                return "+" + name;
            }
            return name;
        }


        /// <summary>
        /// 将比率转化为加%号的字符串(最多保留2位小数)
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        public static string RateToWithPercent(double rate)
        {
            return (int)(rate * 10000) / 100 + "%";
        }

        public static string RateToWithPercent(decimal rate)
        {
            return (int)(rate * 10000) / 100 + "%";
        }


        /// <summary>
        /// 将string集合转化为string
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string StringListToString(ICollection<string> list)
        {
            if (list == null || list.Count == 0)
            {
                return string.Empty;
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string item in list)
            {
                stringBuilder.Append(item + "，");
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }
    }
}
