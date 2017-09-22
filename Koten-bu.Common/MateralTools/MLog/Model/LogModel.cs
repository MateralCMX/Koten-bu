using System;

namespace MateralTools.MLog.Model
{
    /// <summary>
    /// 日志模型
    /// </summary>
    public class LogModel
    {
        /// <summary>
        /// 记录时间
        /// </summary>
        private DateTime RecordTime { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public LogType LogType { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="logType">日志类型</param>
        public LogModel(LogType logType = LogType.Exception)
        {
            RecordTime = DateTime.Now;
            LogType = logType;
        }
    }
}
