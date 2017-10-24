using MateralTools.MCache;
using MateralTools.MConvert;
using MateralTools.MWeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Koten_bu.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WeChatManager.APPID = "wxf4984c388e518385";
            WeChatManager.AppSecret = "1115885c9c4c4dd55915aadd4d2fa7bf";

            #region 测试代码--微信Token
            string resStr = "{\"access_token\":\"zWtGZHO2EHfig - nBhIUb0XtQrh88kqDXV4RalOUvZi22tFELCKieW30O85aQafsH8DOKX1HS - J1Scb7Bdi7jShgrLg4Jc8_sBxcFuqYnGyf5QplcIZLXwOt7tHlcxDKEJPFaAIAXDT\",\"expires_in\":7200}";
            WeChatTokenModel tempTokenM = ConvertManager.JsonToModel<WeChatTokenModel>(resStr);
            WebCacheManager.Set("MATERALWECHATTOKENKEY", tempTokenM, DateTimeOffset.Now.AddSeconds(tempTokenM.expires_in - 60));
            #endregion
        }
    }
}
