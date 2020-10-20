using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace JGNet.Core.Tools
{
    public class DateTimePlus {
       public DateTime StartDate { get; set; }
       public DateTime EndDate { get; set; }
    }

    public static class TimeHelper
    {
        public static int GetReportMonth(DateTime dt)
        {
            return int.Parse(string.Format("{0}{1}", dt.Year, dt.Month.ToString().PadLeft(2, '0')));
        }

        public static int GetReportDay(DateTime dt)
        {
            return int.Parse(string.Format("{0}{1}{2}", dt.Year, dt.Month.ToString().PadLeft(2, '0'), dt.Day.ToString().PadLeft(2, '0')));
        }

        public static string GetReportDayString(DateTime dt)
        {
            return string.Format("{0}-{1}-{2}", dt.Year, dt.Month.ToString().PadLeft(2, '0'), dt.Day.ToString().PadLeft(2, '0'));
        }

        /// <summary>
        /// 获取某年的所有月份
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static List<int> GetReportMonth4Year(int year)
        {
            List<int> months = new List<int>();
            for (int i = 1;i<= 12;i++)
            {
                months.Add(int.Parse(string.Format("{0}{1}", year, i.ToString().PadLeft(2, '0'))));
            }
            return months;
        }


        /// <summary>
        /// 获取2个时间段之间的 月份
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static List<int> GetReportMonth4DateBetween(DateTime startTime, DateTime endTime)
        {
            List<int> months = new List<int>();
            while (GetReportMonth(startTime)<= GetReportMonth(endTime))
            {
                months.Add(GetReportMonth(startTime));
                startTime = startTime.AddMonths(1);
            }
            return months;
        }

        /// <summary>
        /// 获取2个时间段之间的 日期
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static List<int> GetReportDay4DateBetween(DateTime startTime, DateTime endTime)
        {
            List<int> days = new List<int>();
            while (GetReportDay(startTime) <= GetReportDay(endTime))
            {
                days.Add(GetReportDay(startTime));
                startTime = startTime.AddDays(1);
            }
            return days;
        }

        /// <summary>
        /// 获取2个时间段的天数差
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static int GetSpanDays(DateTime startTime, DateTime endTime)
        {
            startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day);
            endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day);
            return Math.Abs(endTime.Subtract(startTime).Days);
        }


        public static void GetStartEndMonth(int year, int month, out DateTime monthStartTime, out DateTime monthEndTime)
        {
            monthStartTime = new DateTime(year, month, 1);
            DateTime date = monthStartTime.AddMonths(1).AddDays(-1);
            monthEndTime = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }

        public static void GetStartEndMonth(int year, int month, out Date monthStartDate, out Date monthEndDate)
        {
            monthStartDate = new Date(year, month, 1);
            DateTime monthStartTime = new DateTime(year, month, 1);
            DateTime date = monthStartTime.AddMonths(1).AddDays(-1);
            monthEndDate = new Date(date.Year, date.Month, date.Day);
        }

        /// <summary>
        /// 获取当天开始时间和结束时间
        /// </summary>
        /// <param name="monthStartTime"></param>
        /// <param name="monthEndTime"></param>
        public static void GetStartEndDay(out DateTime monthStartTime, out DateTime monthEndTime)
        {
            monthStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            monthEndTime = new DateTime(monthStartTime.Year, monthStartTime.Month, monthStartTime.Day, 23, 59, 59);
        }
        /// <summary>
        /// 获取当天开始时间和结束时间
        /// </summary>
        /// <param name="monthStartTime"></param>
        /// <param name="monthEndTime"></param>
        public static void GetStartEndDay(DateTime specTime,out DateTime monthStartTime, out DateTime monthEndTime)
        {
            monthStartTime = new DateTime(specTime.Year, specTime.Month, specTime.Day, 00, 00, 00);
            monthEndTime = new DateTime(monthStartTime.Year, monthStartTime.Month, monthStartTime.Day, 23, 59, 59);
        }



        public static void GetTodayAndAfterAMonth(out DateTime monthStartTime, out DateTime monthEndTime)
        {
            monthStartTime = DateTime.Now;
            int month = monthStartTime.Month;
            int year = monthStartTime.Year;
            if (month == 12)
            {
                month = 1;
                year = year + 1;
            }
          
            int days = DateTime.DaysInMonth(monthStartTime.Year, month);
            monthEndTime = new DateTime(year, month, days);
        }

        public static void GetOneMonthStartEndMonth(  out DateTime monthStartTime, out DateTime monthEndTime)
        {
         
            monthStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            
            monthEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
        }

        public static bool IsToday(DateTime createTime)
        {
            DateTime now = DateTime.Now;
            return now.Year == createTime.Year && now.Month == createTime.Month && now.Day == createTime.Day;
        }

        /// <summary>
        /// 截止日期为当天
        /// </summary>
        /// <param name="monthStartTime"></param>
        /// <param name="monthEndTime"></param>
        public static void GetOneMonthStartEndToday(out DateTime monthStartTime, out DateTime monthEndTime)
        {
            monthStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            monthEndTime = DateTime.Now;
        }


        public static void SetStartEndForMonth(out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); 
            endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        }
        /// <summary>
        /// 设置某月份的第一天和最后一天
        /// </summary>
        /// <param name="date">如 201804 固定六位数</param>
        /// <param name="monthStartTime"></param>
        /// <param name="monthEndTime"></param>
        public static void SetOneMonthStartEndTime(int date, out DateTime monthStartTime, out DateTime monthEndTime)
        {
            int year= date / 100;
            int month = date % 100;
            monthStartTime = new DateTime(year, month, 1);
            monthEndTime = monthStartTime.AddMonths(1).AddSeconds(-1);
        }

        /// <summary>
        /// 设置某年份的第一天和最后一天
        /// </summary>
        /// <param name="year">如 2018 固定4位数</param>
        /// <param name="yearStartTime"></param>
        /// <param name="yearEndTime"></param>
        public static void SetOneYearStartEndTime(int year, out DateTime yearStartTime, out DateTime yearEndTime)
        {
            yearStartTime = new DateTime(year, 1, 1);
            yearEndTime = yearStartTime.AddYears(1).AddSeconds(-1);
        }


        /// <summary>
        /// 获取一年中的周
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static int GetWeekOfYear(DateTime dt)
        {
            System.Globalization.GregorianCalendar gc = new System.Globalization.GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dt, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }

        /// <summary>
        /// 根据一年中的第几周获取该周的开始日期与结束日期
        /// </summary>
        /// <param name="weekNumber">第几周</param>
        public static void GetFirstEndDayOfWeek(int weekNumber, out DateTime startDate, out DateTime endDate )
        {
            DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
            startDate = start.AddDays((weekNumber - 1) * 7);
            endDate = start.AddDays(weekNumber * 7 - 1);
        }

        public static DateTime GetReportMonth(String reportDate)
        {

            DateTime date = DateTime.Now;
            if (reportDate.Length == 6)
            {
                date = new DateTime(int.Parse(reportDate.Substring(0, 4)), int.Parse(reportDate.Substring(4, 2)), 1);  

            }
            return date;
        }

        /// <summary>
        /// 将6位月份数字转化成dateTime
        /// </summary>
        /// <param name="month">月份 （固定6位数）</param>
        /// <returns></returns>
        public static DateTime GetReportMonth(int month)
        {

            DateTime date = new DateTime();
            if (month.ToString().Length == 6)
            {
                date = new DateTime((month / 100), (month % 100), 1);
            }
            return date;
        }

        public static Date GetReportDate(String reportDate)
        {
            DateTime date = DateTime.Now;
            if (reportDate.Length == 8)
            {
                date = Convert.ToDateTime(reportDate.Substring(0, 4) + "-" + reportDate.Substring(4, 2) + "-" + reportDate.Substring(6));

            }
            return new Date(date);
        }

        /// <summary>
        /// 返回空时间的DATETIME
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetDateTimeWithEmptyTime(DateTime dateTime)
        {
            DateTime nowDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
            return nowDate;
        }

        public static int GetReportMonthMaxDay(int reportDate)
        {
            String year = reportDate.ToString().Substring(0, 4);
            String month = reportDate.ToString().Substring(4, 2);
            return DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(month));
        }

        /// <summary>
        /// 将 "5/9/18" 格式转为时间
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime FormatTimeStr(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return DateTime.Now;
            }
            if (str.Contains("/"))
            {
                string[] strs = str.Split('/');
                string yearStr = Convert.ToString(DateTime.Now.Year);
                string year2Prefix = yearStr.Substring(0, 2);
                int year2Suffix = Convert.ToInt32(yearStr.Substring(2));
                string strIndex2 = strs[2];
                int h = 0;
                int min = 0;
                if (strIndex2.Length > 2)
                {
                    string[] temps = strIndex2.Split(' ');
                    strIndex2 = temps[0];
                    string[] hmin = temps[1].Split(':');
                    h = Convert.ToInt16(hmin[0]);
                    min = Convert.ToInt16(hmin[1]);
                }
                int intIndex2 = Convert.ToInt32(strIndex2);
                if (intIndex2 > year2Suffix)
                {
                    year2Prefix = "19";
                }
                return new DateTime(Convert.ToInt16(year2Prefix + Convert.ToString(strIndex2).PadLeft(2, '0')), Convert.ToInt16(strs[0]), Convert.ToInt16(strs[1]), h, min, 0);
            }
            return DateTime.Now;
        }

        /// <summary>
        /// 11-7-17 10:24 或 5-13-18 的时间格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime FormatTimeStr2(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return DateTime.Now;
            }
            string[] strs = str.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int month = Convert.ToInt32(strs[0]);
            int day = Convert.ToInt32(strs[1]);
            string[] yearTemp = strs[2].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (yearTemp.Length == 1)
            {
                return new DateTime(Convert.ToInt32(20 + yearTemp[0]), month, day);
            }

            string[] hm = yearTemp[1].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return new DateTime(Convert.ToInt32(20 + yearTemp[0]), month, day, Convert.ToInt32(hm[0]), Convert.ToInt32(hm[1]), 1);
        }

        public static int GetBirthdayInt(DateTime dateTime)
        {
            return int.Parse(dateTime.Month.ToString() + dateTime.Day.ToString().PadLeft(2, '0'));
        }

        public static void Yestoday(out DateTime startDate, out DateTime endDate)
        {
            DateTime yestoday = DateTime.Now.AddDays(-1);
            GetStartEndDay(yestoday, out startDate, out endDate);
        }

        public static void Today(out DateTime startDate, out DateTime endDate)
        {
            GetStartEndDay(DateTime.Now, out startDate, out endDate);
        }

        public static void ThisMonth(out DateTime startDate, out DateTime endDate)
        {
            GetOneMonthStartEndMonth(out startDate, out endDate);
        }

        public static void ThisWeek(out DateTime startDate, out DateTime endDate)
        {
            DateTime date = DateTime.Now;  //当前时间  
            startDate = date.AddDays(1 - Convert.ToInt32(date.DayOfWeek.ToString("d")));  //本周周一  
            endDate = startDate.AddDays(6);  //本周周日  
        }

        public static void LastYear(out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(DateTime.Now.Year-1, 1, 1, 00, 00, 00);
            endDate = new DateTime(DateTime.Now.Year , 1, 1, 00, 00, 00);
            endDate = endDate.AddDays(-1);
            //  throw new NotImplementedException();
        }

        public static void ThisYear(out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(DateTime.Now.Year, 1, 1, 00, 00, 00);
            endDate = new DateTime(DateTime.Now.Year + 1, 1, 1, 00, 00, 00);
            endDate = endDate.AddDays(-1);
            //  throw new NotImplementedException();
        }
        public static void ThisYearTillToday(out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(DateTime.Now.Year, 1, 1, 00, 00, 00);
            endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            //   endDate = endDate.AddDays(-1);
        }

        public static void LastWeek(out DateTime startDate, out DateTime endDate)
        {
            //上周，同理，一个周是7天，上周就是本周再减去7天，下周也是一样
            startDate= DateTime.Now.AddDays(Convert.ToInt32 (1- Convert.ToInt32(DateTime.Now.DayOfWeek)) -7); //上周一
            endDate= DateTime.Now.AddDays(Convert.ToInt32 (1- Convert.ToInt32(DateTime.Now.DayOfWeek)) -7).AddDays(6); //上周末（星期日）
        }

        public static void LastMonth(out DateTime startDate, out DateTime endDate)
        {
            //上个月，减去一个月份
            startDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-1);
            endDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddDays(-1);
        }

        public static void All(out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(1900, 1, 1, 00, 00, 00);
            endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp(System.DateTime time)
        {
            long ts = ConvertDateTimeToInt(time);
            return ts.ToString();
        }
        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }

        /// <summary>        
        /// 时间戳转为C#格式时间        
        /// </summary>        
        /// <param name=”timeStamp”></param>        
        /// <returns></returns>        
        public static DateTime ConvertStringToDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
    }
}
