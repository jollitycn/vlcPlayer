using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using CJBasic.Loggers;

namespace WxPayAPI
{
    public class Log
    {
        //在网站根目录下创建日志目录
        public static FileAgileLogger logger = null;

        /**
         * 向日志文件写入调试信息
         * @param className 类名
         * @param content 写入内容
         */
        public static void Debug(string className, string content)
        {
            if(WxPayConfig.LOG_LEVENL >= 3)
            {
                WriteLog("DEBUG", className, content);
            }
        }

        /**
        * 向日志文件写入运行时信息
        * @param className 类名
        * @param content 写入内容
        */
        public static void Info(string className, string content)
        {
            if (WxPayConfig.LOG_LEVENL >= 2)
            {
                WriteLog("INFO", className, content);
            }
        }

        /**
        * 向日志文件写入出错信息
        * @param className 类名
        * @param content 写入内容
        */
        public static void Error(string className, string content)
        {
            if(WxPayConfig.LOG_LEVENL >= 1)
            {
                WriteLog("ERROR", className, content);
            }
        }

        /**
        * 实际的写日志操作
        * @param type 日志记录类型
        * @param className 类名
        * @param content 写入内容
        */
        protected static void WriteLog(string type, string className, string content)
        {
            if (Log.logger != null)
            {
                //向日志文件写入内容
                string write_content = type + " " + className + ": " + content;
                Log.logger.LogWithTime(write_content);
            }
            
        }
    }
}