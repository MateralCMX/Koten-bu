using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MChat.Model
{
    /// <summary>
    /// WebSocket消息模型
    /// </summary>
    public class ReceivedMessageModel
    {
        /// <summary>
        /// 目标SocketID
        /// </summary>
        public string TargetSocketID { get; set; }
        /// <summary>
        /// 接收到的消息
        /// </summary>
        public string Message { get; set; }
    }
}
