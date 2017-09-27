//启用严格模式
'use strict';
var MateralTools;
(function (MateralTools) {
    var MChat;
    (function (MChat) {
        /**
         * 普通工具类
         */
        var ChatManager = (function () {
            /**
             * 构造函数
             * @param url 链接地址
             * @param userID 发送者UserID
             * @param targetUserID 目标UserID
             * @param openFun 打开链接处理方法
             * @param receiveFun 接收返回处理方法
             * @param errorFun 错误事件处理方法
             * @param closeFun 链接关闭处理方法
             */
            function ChatManager(url, userID, targetUserID, openFun, receiveFun, errorFun, closeFun) {
                this._targetUserID = targetUserID;
                this._url = url;
                this._userID = userID;
                this._openFun = openFun;
                this._receiveFun = receiveFun;
                this._errorFun = errorFun;
                this._closeFun = closeFun;
                this.Open();
            }
            /**
             * 打开链接
             * @param url 链接地址
             * @param userID 发送者UserID
             * @param openFun 打开链接处理方法
             * @param receiveFun 接收返回处理方法
             * @param errorFun 错误事件处理方法
             * @param closeFun 链接关闭处理方法
             */
            ChatManager.prototype.Open = function (url, userID, openFun, receiveFun, errorFun, closeFun) {
                if (url === void 0) { url = null; }
                if (userID === void 0) { userID = null; }
                if (openFun === void 0) { openFun = null; }
                if (receiveFun === void 0) { receiveFun = null; }
                if (errorFun === void 0) { errorFun = null; }
                if (closeFun === void 0) { closeFun = null; }
                url = url ? url : this._url;
                userID = userID ? userID : this._userID;
                openFun = openFun != null ? openFun : this._openFun;
                receiveFun = receiveFun ? receiveFun : this._receiveFun;
                errorFun = errorFun ? errorFun : this._errorFun;
                closeFun = closeFun ? closeFun : this._closeFun;
                this._ws = new WebSocket('ws://' + url + '?UserID=' + userID);
                this._ws.addEventListener("open", function () {
                    if (openFun != null && openFun != undefined) {
                        openFun();
                    }
                });
                this._ws.addEventListener("message", function (e) {
                    if (receiveFun != null && receiveFun != undefined) {
                        receiveFun(e);
                    }
                });
                this._ws.addEventListener("error", function (e) {
                    if (errorFun != null && errorFun != undefined) {
                        errorFun(JSON.stringify(e));
                    }
                });
                this._ws.addEventListener("close", function () {
                    if (closeFun != null && closeFun != undefined) {
                        closeFun();
                    }
                });
            };
            /**
             * 关闭链接
             */
            ChatManager.prototype.Close = function () {
                this._ws.close();
            };
            /**
             * 发送
             * @param message 要发送的消息
             * @param closeFun 如果链接是关闭的处理方法
             */
            ChatManager.prototype.Send = function (message, closeFun) {
                if (this._ws.readyState == WebSocket.OPEN) {
                    this._ws.send(this._targetUserID + "|" + message);
                }
                else {
                    if (closeFun != null && closeFun != undefined) {
                        closeFun();
                    }
                }
            };
            return ChatManager;
        }());
        MChat.ChatManager = ChatManager;
    })(MChat = MateralTools.MChat || (MateralTools.MChat = {}));
})(MateralTools || (MateralTools = {}));
//# sourceMappingURL=ChatManager.js.map