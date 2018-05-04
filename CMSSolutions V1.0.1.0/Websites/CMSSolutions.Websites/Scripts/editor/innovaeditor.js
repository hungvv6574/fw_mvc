/*** Editor Script Wrapper ***/
var oScripts = document.getElementsByTagName("script");
var sEditorPath;
for (var i = 0; i < oScripts.length; i++) {
    var sSrc = oScripts[i].src.toLowerCase();
    if (sSrc.indexOf("scripts/editor/innovaeditor.js") != -1) sEditorPath = oScripts[i].src.replace(/innovaeditor.js/, "");
}

document.write("<scr" + "ipt src='" + sEditorPath + "common/nlslightbox/nlslightbox.js' type='text/javascript'></scr" + "ipt>");
document.write("<scr" + "ipt src='" + sEditorPath + "common/nlslightbox/nlsanimation.js' type='text/javascript'></scr" + "ipt>");
document.write("<link href='" + sEditorPath + "common/nlslightbox/nlslightbox.css' rel='stylesheet' type='text/css' />");
document.write("<scr" + "ipt src='" + sEditorPath + "common/nlslightbox/dialog.js' type='text/javascript'></scr" + "ipt>");
document.write("<scr" + "ipt src='" + sEditorPath + "common/webfont.js' type='text/javascript'></scr" + "ipt>");
document.write("<scr" + "ipt src='" + sEditorPath + "common/googleapis-webfont.js' type='text/javascript'></scr" + "ipt>");

document.write("<link rel='stylesheet' href='" + sEditorPath + "style/istoolbar.css' type='text/css' />");
document.write("<script src='" + sEditorPath + "istoolbar.js'></script>");

if (navigator.appName.indexOf('Microsoft') != -1) {
    document.write("<scr" + "ipt src='" + sEditorPath + "editor.js'></script>");
    document.write("<scr" + "ipt src='" + sEditorPath + "common/language/en-US/webtext.js'></script>");
} else if (navigator.userAgent.indexOf('Safari') != -1) {
    document.write("<script src='" + sEditorPath + "saf/editor.js'></script>");
} else {
    document.write("<script src='" + sEditorPath + "moz/editor.js'></script>");
}

 //Auto turn on textarea to editor
$(document).ready(function () {
    oUtil.initializeEditor("richtext",
        {
            width: "99.9999%",
            toolbarMode: 2,
            /*Enable Custom File Browser */
            fileBrowser: "/Scripts/Editor/assetmanager/asset.aspx",
        }
    );
});