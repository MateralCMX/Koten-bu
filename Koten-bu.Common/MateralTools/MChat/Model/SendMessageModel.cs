using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MChat.Model
{
    public class SendMessageModel
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public SendMessageModel(string message)
        {
            Message = message;
            CreateTime = DateTime.UtcNow;
        }
        /// <summary>
        /// 要发送的的消息
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; private set; }
        /// <summary>
        /// 创建时间字符串
        /// </summary>
        public string CreateTimeStr
        {
            get
            {
                return CreateTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }
    }
}
