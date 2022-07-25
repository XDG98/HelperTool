using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
    public static class TimeHelper
    {
        #region 当前时间
        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNowTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static DateTime GetNowTime(string format)
        {
            return GetTime(GetNowTime(), format);
        }

        /// <summary>
        /// 获取当前时间字符串
        /// </summary>
        /// <returns></returns>
        public static string GetNowTimeString()
        {
            return GetTimeString(GetNowTime());
        }

        /// <summary>
        /// 获取当前时间字符串
        /// </summary>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string GetNowTimeString(string format)
        {
            return GetTimeString(GetNowTime(), format);
        }

        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetNowTimeTicks()
        {
            return GetNowTime().Ticks;
        }

        /// <summary>
        /// 获取当前时间年份
        /// </summary>
        /// <returns></returns>
        public static int GetNowTimeYear()
        {
            return GetNowTime().Year;
        }

        /// <summary>
        /// 获取当前时间月份
        /// </summary>
        /// <returns></returns>
        public static int GetNowTimeMonth()
        {
            return GetNowTime().Month;
        }

        /// <summary>
        /// 获取当前时间日
        /// </summary>
        /// <returns></returns>
        public static int GetNowTimeDay()
        {
            return GetNowTime().Day;
        }

        /// <summary>
        /// 获取当前时间小时
        /// </summary>
        /// <returns></returns>
        public static int GetNowTimeHour()
        {
            return GetNowTime().Hour;
        }

        /// <summary>
        /// 获取当前时间分钟
        /// </summary>
        /// <returns></returns>
        public static int GetNowTimeMinute()
        {
            return GetNowTime().Minute;
        }

        /// <summary>
        /// 获取当前时间秒
        /// </summary>
        /// <returns></returns>
        public static int GetNowTimeSecond()
        {
            return GetNowTime().Second;
        }

        /// <summary>
        /// 获取当前时间毫秒
        /// </summary>
        /// <returns></returns>
        public static int GetNowTimeMillisecond()
        {
            return GetNowTime().Millisecond;
        }
        #endregion

        #region 参数时间
        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static DateTime GetTime(string timeString)
        {
            DateTime.TryParse(timeString, out DateTime time);
            return time;
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static DateTime GetTime(string timeString, string format)
        {
            DateTime.TryParse(GetTimeString(GetTime(timeString), format), out DateTime time);
            return time;
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static DateTime GetTime(DateTime dateTime, string format)
        {
            DateTime.TryParse(GetTimeString(dateTime, format), out DateTime time);
            return time;
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeTicks(DateTime dateTime)
        {
            return dateTime.Ticks;
        }

        /// <summary>
        /// 获取时间年份
        /// </summary>
        /// <returns></returns>
        public static int GetTimeYear(DateTime dateTime)
        {
            return dateTime.Year;
        }

        /// <summary>
        /// 获取时间月份
        /// </summary>
        /// <returns></returns>
        public static int GetTimeMonth(DateTime dateTime)
        {
            return dateTime.Month;
        }

        /// <summary>
        /// 获取当前时间日
        /// </summary>
        /// <returns></returns>
        public static int GetTimeDay(DateTime dateTime)
        {
            return dateTime.Day;
        }

        /// <summary>
        /// 获取当前时间小时
        /// </summary>
        /// <returns></returns>
        public static int GetTimeHour(DateTime dateTime)
        {
            return dateTime.Hour;
        }

        /// <summary>
        /// 获取时间分钟
        /// </summary>
        /// <returns></returns>
        public static int GetTimeMinute(DateTime dateTime)
        {
            return dateTime.Minute;
        }

        /// <summary>
        /// 获取时间秒
        /// </summary>
        /// <returns></returns>
        public static int GetTimeSecond(DateTime dateTime)
        {
            return dateTime.Second;
        }

        /// <summary>
        /// 获取时间毫秒
        /// </summary>
        /// <returns></returns>
        public static int GetTimeMillisecond(DateTime dateTime)
        {
            return dateTime.Millisecond;
        }

        /// <summary>
        /// 获取时间字符串
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public static string GetTimeString(string timeString, string format)
        {
            return GetTimeString(GetTime(timeString), format);
        }

        /// <summary>
        /// 获取时间字符串
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public static string GetTimeString(DateTime time)
        {
            return time.ToString();
        }

        /// <summary>
        /// 获取时间字符串
        /// </summary>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string GetTimeString(DateTime time, string format)
        {
            return time.ToString(format);
        }
        #endregion

        #region 两时间差
        /// <summary>
        /// 两个时间相差多少年月日时分秒毫秒
        /// </summary>
        /// <param name="dateTime1">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static List<double> GetIntervalDetail(DateTime dateTime1, DateTime dateTime2)
        {
            List<double> intervalDetailList = new List<double>();
            intervalDetailList.Add(GetIntervalYear(dateTime1, dateTime2));
            intervalDetailList.Add(GetIntervalMonth( dateTime1, dateTime2));
            intervalDetailList.Add(GetIntervalDay(dateTime1, dateTime2));
            intervalDetailList.Add(GetIntervalHour(dateTime1, dateTime2));
            intervalDetailList.Add(GetIntervalMinute(dateTime1, dateTime2));
            intervalDetailList.Add(GetIntervalSecond(dateTime1, dateTime2));
            intervalDetailList.Add(GetIntervalMillisecond(dateTime1, dateTime2));

            return intervalDetailList;
        }

        /// <summary>
        /// 两时间相差多少年
        /// </summary>
        /// <param name="dateTime1">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static double GetIntervalYear(DateTime dateTime1, DateTime dateTime2)
        {
            return GetIntervalDay(dateTime1, dateTime2) / 365;
        }

        /// <summary>
        /// 两时间相隔多少月
        /// </summary>
        /// <param name="dateTime1">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static double GetIntervalMonth(DateTime dateTime1, DateTime dateTime2)
        {
            return GetIntervalYear(dateTime2, dateTime1) * 12; ;
        }

        /// <summary>
        /// 两时间相隔多少天
        /// </summary>
        /// <param name="dateTime1">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static double GetIntervalDay(DateTime dateTime1, DateTime dateTime2)
        {
            return GetTimeSpan(dateTime1, dateTime2).TotalDays;
        }

        /// <summary>
        /// 两时间相隔多少时
        /// </summary>
        /// <param name="dateTime1">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static double GetIntervalHour(DateTime dateTime1, DateTime dateTime2)
        {
            return GetTimeSpan(dateTime1, dateTime2).TotalHours;
        }

        /// <summary>
        /// 两时间相隔多少分
        /// </summary>
        /// <param name="dateTime1">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static double GetIntervalMinute(DateTime dateTime1, DateTime dateTime2)
        {
            return GetTimeSpan(dateTime1, dateTime2).TotalMinutes;
        }

        /// <summary>
        /// 两时间相隔多少秒
        /// </summary>
        /// <param name="dateTime1">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static double GetIntervalSecond(DateTime dateTime1, DateTime dateTime2)
        {
            return GetTimeSpan(dateTime1, dateTime2).TotalSeconds;
        }

        /// <summary>
        /// 两时间相隔多少毫秒
        /// </summary>
        /// <param name="dateTime1">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static double GetIntervalMillisecond(DateTime dateTime1, DateTime dateTime2)
        {
            return GetTimeSpan(dateTime1, dateTime2).TotalMilliseconds;
        }

        /// <summary>
        /// 计算两时间差
        /// </summary>
        /// <param name="dateTime1">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static TimeSpan GetTimeSpan(DateTime dateTime1, DateTime dateTime2)
        {
            if (dateTime1 > dateTime2)
            {
                return dateTime1 - dateTime2;
            }
            else
            {
                return dateTime2 - dateTime1;
            }
        }
        #endregion

    }
}
