using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace JGNet.Common.Core
{
   public class DateTimeUtil
    {
        public static readonly string DEFAULT_DATETIME_FORMAT = "yyyy-MM-dd HH:mm";

        public static readonly string File_DATETIME_FORMAT = "yyyyMMddHHmmss";
        
        public static readonly string FULL_DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public static readonly string FULL_DATETIME_FORMAT_SLASH = "yyyy/MM/dd HH:mm:ss";
        public static readonly string FULL_DATETIME_FORMAT_DOT = "yyyy.MM.dd HH:mm:ss";
        public static readonly string DEFAULT_MONTH_FORMAT = "yyyy-MM";
        public static readonly string DEFAULT_DATE_FORMAT = "yyyy-MM-dd";
        public static readonly string DEFAULT_DATE_FORMAT_SLASH = "yyyy/MM/dd";
        public static readonly string DEFAULT_DATE_FORMAT_DOT = "yyyy.MM.dd";
        public static readonly string DEFAULT_SHORT_DATE_FORMAT = "yyyyMMdd";
        public static readonly string DEFAULT_SHORT_MONTH_FORMAT = "yyyyMM";
        public static readonly string DEFAULT_TIME_FORMAT = "HH:mm";





        /// <summary>
        /// 转换为对应的日期格式，包含完整时间
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(String dateStr)
        {
            DateTime dateTime = DateTime.Now;
            //方法一：Convert.ToDateTime(string)
            //string格式有要求，必须是yyyy - MM - dd hh: mm: ss
            try
            {

                dateTime = Convert.ToDateTime(dateStr);
                return dateTime;
            }
            catch { }
            try
            {
                dateTime = DateTime.ParseExact(dateStr, FULL_DATETIME_FORMAT, System.Globalization.CultureInfo.CurrentCulture);
                return dateTime;
            }
            catch { }
            try
            {
                dateTime = DateTime.ParseExact(dateStr, FULL_DATETIME_FORMAT_SLASH, System.Globalization.CultureInfo.CurrentCulture);
                return dateTime;
            }
            catch { }
            try
            {
                dateTime = DateTime.ParseExact(dateStr, FULL_DATETIME_FORMAT_DOT, System.Globalization.CultureInfo.CurrentCulture);
                return dateTime;
            }
            catch { }
            try
            {
                dateTime = DateTime.ParseExact(dateStr, DEFAULT_DATE_FORMAT, System.Globalization.CultureInfo.CurrentCulture);
                return dateTime;
            }
            catch { }
            try
            {
                dateTime = DateTime.ParseExact(dateStr, DEFAULT_DATE_FORMAT_SLASH, System.Globalization.CultureInfo.CurrentCulture);
                return dateTime;
            }
            catch { }
            try
            {
                dateTime = DateTime.ParseExact(dateStr, DEFAULT_DATE_FORMAT_DOT, System.Globalization.CultureInfo.CurrentCulture);
                return dateTime;
            }
            catch { }
            return dateTime;
        }


        public static double CompareMinutes(DateTime date1, DateTime date2)
        {
            TimeSpan timeSpan = date2 - date1;
            return timeSpan.TotalMinutes;
        }

        public static double CompareDays(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            return timeSpan.TotalDays;
        }

        public static void DateTimePicker_SetDateTimePicker(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            TimeHelper.GetOneMonthStartEndToday(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }
        public static void DateTimePicker_GetTodayAndAfterAMonth(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            //dateTimePicker_Start.Initialize();
            //dateTimePicker_End.Initialize();
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.GetTodayAndAfterAMonth(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }

        public static void DateTimePicker_Yestoday(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.Yestoday(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }

        public static void DateTimePicker_Today(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.Today(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }

        public static void DateTimePicker_ThisMonth(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.ThisMonth(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }

        public static void DateTimePicker_All(DateTimePicker startDateTimePicker, DateTimePicker endDateTimePicker)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.All(out startDate, out endDate);
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
        }

        public static void DateTimePicker_ThisWeek(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.ThisWeek(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }

        public static void DateTimePicker_LastYear(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.LastYear(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }

        internal static void DateTimePicker_LastWeek(DateTimePicker startDateTimePicker, DateTimePicker endDateTimePicker)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.LastWeek(out startDate, out endDate);
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
        }

        internal static void DateTimePicker_LastMonth(DateTimePicker startDateTimePicker, DateTimePicker endDateTimePicker)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.LastMonth(out startDate, out endDate);
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
        }

        public static void DateTimePicker_ThisYear(DateTimePicker startDateTimePicker, DateTimePicker endDateTimePicker)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.ThisYear(out startDate, out endDate);
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
        }

        public static void DateTimePicker_ThisYearTillToday(DateTimePicker startDateTimePicker, DateTimePicker endDateTimePicker)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.ThisYearTillToday(out startDate, out endDate);
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
        }

        public static void DateTimePicker_SetStartEndForMonth(YearMonthPicker dateTimePicker_Start, YearMonthPicker dateTimePicker_End)
        {
            //dateTimePicker_Start.Initialize();
            //dateTimePicker_End.Initialize();
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.SetStartEndForMonth(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }
    }
}
