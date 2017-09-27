using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MVerify.Model
{
    /// <summary>
    /// 验证码异常类
    /// </summary>
    public class VerifyCodeException : ApplicationException
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public VerifyCodeException()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">错误信息</param>
        public VerifyCodeException(string message) : base(message)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="innerException">发生的错误</param>
        public VerifyCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">承载序列化对象数据的对象</param>
        /// <param name="context">关于来源和目标的上下文信息</param>
        protected VerifyCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
