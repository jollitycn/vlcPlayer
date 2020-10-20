using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Tools
{
    public class YearHelper
    {
        /// <summary>
        /// 获取年份
        /// </summary>
        /// <param name="dateTime">结束年份</param>
        /// <param name="lastyears">前几年（lastyears>=1）</param>
        /// <returns></returns>
        public static List<int> GetYearList(DateTime dateTime,int lastyears=5)
        {
            int year = dateTime.Year;
            List<int> list = new List<int>();
            for (int i = 0; i < lastyears; i++)
            {
                list.Add(year - i);
            }
            return list;
        }
    }
}
