using MateralTools.Base;
using MateralTools.MDataBase;
using MateralTools.MEnum;
using System;

namespace Koten_bu.Model
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogTypeEnum : Byte
    {
        /// <summary>
        /// 异常日志
        /// </summary>
        [EnumShowName("异常日志")]
        ExceptionLog = 0,
        /// <summary>
        /// 系统日志
        /// </summary>
        [EnumShowName("系统日志")]
        SystemLog = 1,
        /// <summary>
        /// 操作日志
        /// </summary>
        [EnumShowName("操作日志")]
        OperationLog = 2,
    }
    /// <summary>
    /// 日志模型
    /// </summary>
    [TableModel("T_Log","ID")]
    public class LogModel : BaseModel
    {
        #region 成员
        /// <summary>
        /// 标题
        /// </summary>
        [ColumnModel("Title", "varchar(200)")]
        public string Title { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        [ColumnModel("LogType", "tinyint")]
        public byte LogType { get; set; }
        /// <summary>
        /// 日志类型枚举
        /// </summary>
        public LogTypeEnum LogTypeE
        {
            get
            {
                return (LogTypeEnum)LogType;
            }
            private set
            {
                LogType = Convert.ToByte(value);
            }
        }
        /// <summary>
        /// 日志类型文本
        /// </summary>
        public string LogTypeStr
        {
            get
            {
                return EnumManager.GetShowName(LogTypeE);
            }
        }
        /// <summary>
        /// 日志内容
        /// </summary>
        [ColumnModel("LogContent", "varchar(MAX)")]
        public string LogContent { get; set; }
        #endregion
        #region 方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public LogModel() : base()
        {
            LogTypeE = LogTypeEnum.SystemLog;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="logType">日志类型</param>
        public LogModel(LogTypeEnum logType) : base()
        {
            LogTypeE = logType;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="title">日志标题</param>
        /// <param name="content">日志内容</param>
        public LogModel(LogTypeEnum logType,string title,string content)
        {
            LogTypeE = logType;
            Title = title;
            LogContent = content;
        }
        /// <summary>
        /// 检测合法性
        /// </summary>
        /// <param name="msg">验证消息</param>
        /// <returns>验证结果</returns>
        public override bool Validation(ref string msg)
        {
            bool isOK = true;
            msg = "";
            if (string.IsNullOrEmpty(Title)) { msg += "标题不能为空,"; isOK = false; }
            if (string.IsNullOrEmpty(LogContent)) { msg += "日志内容不能为空,"; isOK = false; }
            msg = msg.Substring(0, msg.Length - 1);
            return isOK;
        }
        #endregion
    }
}
