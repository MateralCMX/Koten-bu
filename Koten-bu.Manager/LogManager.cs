using Koten_bu.Model;
using System;

namespace Koten_bu.Manager
{
    /// <summary>
    /// 日志管理器
    /// </summary>
    public static class LogManager
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="message">日志消息</param>
        public static void WriteLog(LogType logType, string message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 写入异常日志
        /// </summary>
        /// <param name="message">日志消息</param>
        public static void WriteExceptionLog(string message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 写入系统日志
        /// </summary>
        /// <param name="message">日志消息</param>
        public static void WriteSystemLog(string message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 写入操作日志
        /// </summary>
        /// <param name="message">日志消息</param>
        public static void WriteOperationLog(string message)
        {
            throw new NotImplementedException();
        }
    }
}
