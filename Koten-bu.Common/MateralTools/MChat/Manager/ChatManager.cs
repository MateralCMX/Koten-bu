using MateralTools.MChat.Model;
using MateralTools.MConvert;
using MateralTools.MHttpWeb;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.WebSockets;

namespace MateralTools.MChat
{
    /// <summary>
    /// 即时通讯管理类
    /// </summary>
    public class ChatManager
    {
        /// <summary>
        /// socketID名称
        /// </summary>
        public static string SOCKETIDNAME = "UserID";
        /// <summary>
        /// 连接池
        /// </summary>
        public static Dictionary<string, WebSocket> CONNECT_POOL;
        /// <summary>
        /// 离线消息池
        /// </summary>
        private static Dictionary<string, List<SendMessageModel>> MESSAGE_POOL;
        /// <summary>
        /// 连接池初始化
        /// </summary>
        /// <param name="socket">连接对象</param>
        /// <param name="socketID">连接ID</param>
        private static void ContainsKeyInit(WebSocket socket, string socketID)
        {
            if (CONNECT_POOL == null)
            {
                CONNECT_POOL = new Dictionary<string, WebSocket>();
            }
            if (MESSAGE_POOL == null)
            {
                MESSAGE_POOL = new Dictionary<string, List<SendMessageModel>>();
            }
            if (!CONNECT_POOL.ContainsKey(socketID))
            {
                CONNECT_POOL.Add(socketID, socket);//不存在，添加
            }
            else
            {
                if (socket != CONNECT_POOL[socketID])//当前对象不一致，更新
                {
                    CONNECT_POOL[socketID] = socket;
                }
            }
        }
        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task Start(AspNetWebSocketContext context)
        {
            string socketID = context.QueryString[SOCKETIDNAME].ToString();
            WebSocket socket = context.WebSocket;
            ContainsKeyInit(socket, socketID);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2048]);
            #region 离线消息处理
            if (MESSAGE_POOL.ContainsKey(socketID))
            {
                List<SendMessageModel> msgs = MESSAGE_POOL[socketID];
                foreach (SendMessageModel item in msgs)
                {
                    buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(ConvertManager.ModelToJson(item)));
                    await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                MESSAGE_POOL.Remove(socketID);
            }
            #endregion
            while (true)
            {
                if (socket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None);
                    string receivedMessage = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    ReceivedMessageModel recM = ConvertManager.JsonToModel<ReceivedMessageModel>(receivedMessage);
                    if (CONNECT_POOL.ContainsKey(recM.TargetSocketID))//判断客户端是否在线
                    {
                        WebSocket destSocket = CONNECT_POOL[recM.TargetSocketID];//目的客户端
                        if (destSocket != null && destSocket.State == WebSocketState.Open)
                        {
                            buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(ConvertManager.ModelToJson(new SendMessageModel(recM.Message))));
                            await destSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                        }
                    }
                    else
                    {
                        await Task.Run(() =>
                        {
                            if (!MESSAGE_POOL.ContainsKey(recM.TargetSocketID))//将用户添加至离线消息池中
                            {
                                MESSAGE_POOL.Add(recM.TargetSocketID, new List<SendMessageModel>());
                            }
                            MESSAGE_POOL[recM.TargetSocketID].Add(new SendMessageModel(recM.Message));//添加离线消息
                        });
                    }
                }
                else
                {
                    if (CONNECT_POOL.ContainsKey(socketID))
                    {
                        CONNECT_POOL.Remove(socketID);
                    }
                    break;
                }
            }
        }
    }
}