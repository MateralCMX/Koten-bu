//启用严格模式
'use strict';
namespace MateralTools.MChat {

    /**
     * 普通工具类
     */
    export class ChatManager {
        /*WebSocket对象*/
        private _ws: WebSocket;
        /*目标用户ID*/
        private _targetUserID: string;
        /*链接地址*/
        private _url: string;
        /*用户ID */
        private _userID: string;
        /*打开链接处理方法*/
        private _openFun: Function;
        /*接收返回处理方法*/
        private _receiveFun: Function;
        /*错误事件处理方法*/
        private _errorFun: Function;
        /*链接关闭处理方法*/
        private _closeFun: Function;
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
        constructor(url: string, userID: string, targetUserID: string, openFun: Function, receiveFun: Function, errorFun: Function, closeFun: Function) {
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
        public Open(url: string = null, userID: string = null, openFun: Function = null, receiveFun: Function = null, errorFun: Function = null, closeFun: Function = null) {
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
        }
        /**
         * 关闭链接
         */
        public Close(): void {
            this._ws.close();
        }
        /**
         * 发送
         * @param message 要发送的消息
         * @param closeFun 如果链接是关闭的处理方法
         */
        public Send(message: string, closeFun: Function): void {
            if (this._ws.readyState == WebSocket.OPEN) {
                var data = {
                    TargetSocketID: this._targetUserID,
                    Message: message
                };
                this._ws.send(JSON.stringify(data));
            }
            else {
                if (closeFun != null && closeFun != undefined) {
                    closeFun();
                }
            }
        }
    }
}