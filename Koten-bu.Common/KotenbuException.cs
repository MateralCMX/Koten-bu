using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.Common
{
    /// <summary>
    /// 古典部异常类
    /// </summary>
    public class KotenbuException : Exception
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="WriteLog">是否写入日志</param>
        public KotenbuException(string message, bool WriteLog = true) : base(message)
        {
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="innerException">异常对象</param>
        /// <param name="WriteLog">是否写入日志</param>
        public KotenbuException(string message, Exception innerException, bool WriteLog = true) : base(message, innerException)
        {
        }
    }
}
