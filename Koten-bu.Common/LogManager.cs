using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.Common
{
    /// <summary>
    /// 日志保存类型
    /// </summary>
    public enum LogSaveType
    {
        /// <summary>
        /// 文件
        /// </summary>
        File,
        /// <summary>
        /// 数据库
        /// </summary>
        DataBase
    }
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        RecordLog,
        /// <summary>
        /// 异常日志
        /// </summary>
        ExceptionLog
    }
    public static class LogManager
    {
        /// <summary>
        /// 日志保存类型
        /// </summary>
        private static LogSaveType _saveType = LogSaveType.File;
        /// <summary>
        /// 日志保存类型
        /// </summary>
        public static LogSaveType SaveType {
            get
            {
                return _saveType;
            }
            set
            {
                _saveType = value;
            }
        }
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
        /// 写入记录日志
        /// </summary>
        /// <param name="message">日志消息</param>
        public static void WriteRecordLog(string message)
        {
            throw new NotImplementedException();
        }
    }
}
