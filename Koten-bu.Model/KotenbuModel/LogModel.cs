using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.Model
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 异常日志
        /// </summary>
        ExceptionLog = 0,
        /// <summary>
        /// 系统日志
        /// </summary>
        SystemLog = 1,
        /// <summary>
        /// 操作日志
        /// </summary>
        OperationLog = 2,
    }
    /// <summary>
    /// 日志模型
    /// </summary>
    public class LogModel : BaseModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 类型枚举
        /// </summary>
        public LogType TypeEnum { get; set; }
        /// <summary>
        /// 克隆对象
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 检测合法
        /// </summary>
        /// <returns></returns>
        public override bool Validation()
        {
            throw new NotImplementedException();
        }
    }
}
