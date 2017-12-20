using MateralTools.MCache;
using MateralTools.MConvert;
using MateralTools.MEncryption;
using MateralTools.MHttpWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MWeChat
{
    public class WeChatManager
    {
        /// <summary>
        /// APPID
        /// </summary>
        public static string APPID { get; set; }
        /// <summary>
        /// APPSecret
        /// </summary>
        public static string AppSecret { get; set; }
        /// <summary>
        /// TokenKey
        /// </summary>
        private const string TokenKey = "MATERALWECHATTOKENKEY";
        /// <summary>
        /// 公众号认证
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage WeChatAuthentication(string token, string signature, string timestamp, string nonce, string echostr)
        {
            string[] ArrTmp = { token, timestamp, nonce };
            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);
            string result = EncryptionManager.MD5Encode_32(tmpStr, true);
            if (result == signature)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(echostr, Encoding.GetEncoding("UTF-8"), "application/x-www-form-urlencoded")
                };
            }
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("", Encoding.GetEncoding("UTF-8"), "application/x-www-form-urlencoded")
                };
            }
        }
        /// <summary>
        /// 获取微信Token
        /// </summary>
        /// <returns></returns>
        public WeChatTokenModel GetWeChatToken()
        {
            WeChatTokenModel tokenM = WebCacheManager.Get<WeChatTokenModel>(TokenKey);
            if (tokenM == null)
            {
                if (!string.IsNullOrEmpty(APPID) && !string.IsNullOrEmpty(AppSecret))
                {
                    string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", APPID, AppSecret);
                    string resStr = HttpWebManager.SendRequest(url, "", MethodType.Get, ParamType.Text, Encoding.UTF8);
                    tokenM = ConvertManager.JsonToModel<WeChatTokenModel>(resStr);
                    WebCacheManager.Set(TokenKey, tokenM, DateTimeOffset.Now.AddSeconds(tokenM.expires_in - 60));
                }
            }
            return tokenM;
        }
        /// <summary>
        /// 设置微信菜单
        /// </summary>
        /// <param name="wxMenuM">微信菜单模型</param>
        public void SetWeChatMenu(WeChatMenuModel wxMenuM)
        {
            string jsonStr = ConvertManager.ModelToJson(wxMenuM);
        }
    }
}
