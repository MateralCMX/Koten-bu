using Koten_bu.DAL;
using Koten_bu.Model;
using System;

namespace Koten_bu.Manager
{
    /// <summary>
    /// 日志管理器
    /// </summary>
    public static class LogManager
    {
        private static LogDAL logDal = new LogDAL();
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="title">日志标题</param>
        /// <param name="message">日志消息</param>
        public static void WriteLog(LogTypeEnum logType, string title, string message)
        {
            LogModel logM = new LogModel(logType, title, message);
            if (logM.Validation())
            {
                logDal.Add(logM);
            }
        }
        /// <summary>
        /// 写入异常日志
        /// </summary>
        /// <param name="title">日志标题</param>
        /// <param name="message">日志消息</param>
        public static void WriteExceptionLog(string title, string message)
        {
            WriteLog(LogTypeEnum.ExceptionLog, title, message);
        }
        /// <summary>
        /// 写入系统日志
        /// </summary>
        /// <param name="title">日志标题</param>
        /// <param name="message">日志消息</param>
        public static void WriteSystemLog(string title, string message)
        {
            WriteLog(LogTypeEnum.SystemLog, title, message);
        }
        /// <summary>
        /// 写入操作日志
        /// </summary>
        /// <param name="title">日志标题</param>
        /// <param name="message">日志消息</param>
        public static void WriteOperationLog(string title, string message)
        {
            WriteLog(LogTypeEnum.OperationLog, title, message);
        }
    }
}
