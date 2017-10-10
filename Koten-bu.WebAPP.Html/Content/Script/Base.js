/// <reference path="../../Lib/m-Tools/m-tools.js" />
/// <reference path="../../Lib/mui/js/mui.js" />
var MDMa = Materal.DOMManager;
var MTMa = Materal.ToolManager;
function KotenBuCommon()
{
    var UserInfo = {
        UserID: null
    };
    /*获得运行环境*/
    function GetRuntime()
    {
        var _run = "browser";
        if (mui.os.plus == true) {
            if (mui.os.ios == true || mui.os.iphone == true || mui.os.ipad == true) {
                _run = "ios";
            }
            else if (mui.os.android == true) {
                _run = "android";
            }
        } else {
            var ua = navigator.userAgent.toLowerCase();
            if (ua.match(/MicroMessenger/i) != "micromessenger" && ua.match(/windows phone/i) != "windows phone") {
                _run = "browser";
            }
            else {
                _run = "wechat";
            }
        }
        return _run;
    }
    /*打开窗口*/
    function OpenWindow(pageid)
    {
        var pageurl = "";
        switch (pageid) {
            /*扫描*/
            case "Scanning":
                pageurl = "View/Scanning.html";
                break;
        }
        if (pageurl != "" && pageid != "") {
            var autoShow = false;
            var aniShow = "pop-in";
            var duration = 0;
            var title = "";
            switch (GetRuntime()) {
                case "ios": duration = 300; break;
                case "android": autoShow = true; duration = 200; title = "努力加载中"; break;
            }
            mui.openWindow({
                url: pageurl,
                id: pageid,
                styles: { top: 0, bottom: 0 },
                extras: {},
                createNew: false,
                show: { autoShow: true, aniShow: aniShow, duration: duration },
                waiting: { autoShow: autoShow, title: title }
            });
        }
    }
    return {
        /*打开窗口*/
        OpenWindow: function (targetpage, validlogin)
        {
            if (targetpage != "") {
                if (validlogin) {
                    if (MTMa.IsNullOrUndefined(UserInfo.UserID)) {
                        OpenWindow("Login");
                    }
                    else {
                        OpenWindow(targetpage);
                    }
                }
                else {
                    OpenWindow(targetpage);
                }
            }
        },
        /*获得运行环境*/
        GetRuntime: GetRuntime,
        /*绑定跳转按钮*/
        BindJumpBtn: function ()
        {
            var JumpBtns = document.querySelectorAll("[data-targetpage]");
            if (JumpBtns) {
                for (var i = 0; i < JumpBtns.length; i++) {
                    JumpBtns[i].addEventListener("tap", function (e)
                    {
                        var TargetElement = e.target;
                        while (!TargetElement.dataset.targetpage) {
                            TargetElement = TargetElement.parentElement;
                        }
                        //if (TargetElement.dataset.extras) {
                        //    mMain.pageExtras = TargetElement.dataset.extras.split(",");
                        //}
                        //else {
                        //    mMain.pageExtras = [];
                        //}
                        if (TargetElement.dataset.validlogin) {
                            Common.OpenWindow(TargetElement.dataset.targetpage, true);
                        }
                        else {
                            Common.OpenWindow(TargetElement.dataset.targetpage, false);
                        }
                    });
                }
            }
        }
    }
}
var Common = new KotenBuCommon();
/*调试输出*/
function DebugLog(inputObj)
{
    try {
        console.log(Materal.JsonManager.JSONStringify(inputObj));
    }
    catch (ex) {
        console.log(inputObj);
    }
}