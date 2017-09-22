/// <reference path="../m-tools/m-tools.ts" />
'use strict';
Materal.DOMManager.AddEvent(window, "load", function () {
    let ClientInfoM: Materal.ClientInfoModel = new Materal.ClientInfoModel();
    //是IE时执行
    if (ClientInfoM.BrowserInfoM.IE) {
        let IEVersion: number = parseFloat(ClientInfoM.BrowserInfoM.Version);
        //IE版本小于等于IE8
        if (IEVersion <= 8) {
            if (!Materal.ToolManager.IsNullOrUndefined(document.createElement)) {
                document.createElement("header");
                document.createElement("main");
                document.createElement("nav");
                document.createElement("section");
                document.createElement("article");
                document.createElement("footer");
                document.createElement("video");
            }
        }
    }
    console.log(ClientInfoM);
});