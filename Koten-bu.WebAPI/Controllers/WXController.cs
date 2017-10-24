using Koten_bu.Manager;
using MateralTools.MCache;
using MateralTools.MConvert;
using MateralTools.MEncryption;
using MateralTools.MHttpWeb;
using MateralTools.MResult;
using MateralTools.MWeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Security;

namespace Koten_bu.WebAPI.Controllers
{

    [RoutePrefix("api/WX")]
    public class WXController : ApiController
    {
        /// <summary>
        /// TOKEN
        /// </summary>
        public const string TOKEN = "KotenbuToken";
        /// <summary>
        /// 微信验证
        /// </summary>
        /// <param name="signature">随机字符串</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">参数1</param>
        /// <param name="echostr">参数2</param>
        /// <returns>验证结果</returns>
        public HttpResponseMessage Get(string signature, string timestamp, string nonce, string echostr)
        {
            WeChatManager weChatMa = new WeChatManager();
            return weChatMa.WeChatAuthentication("KotenbuToken", signature, timestamp, nonce, echostr);
        }
        /// <summary>
        ///  获取WXToken
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetWXToken")]
        public MResultModel<WeChatTokenModel> GetWXToken()
        {
            WeChatManager weChatMa = new WeChatManager();
            WeChatTokenModel tokenM = weChatMa.GetWeChatToken();
            if (tokenM != null)
            {
                return MResultModel<WeChatTokenModel>.GetSuccessResultM(tokenM, "获取WXToken成功");
            }
            else
            {
                return MResultModel<WeChatTokenModel>.GetFailResultM(null, "获取WXToken失败");
            }
        }
    }
}
