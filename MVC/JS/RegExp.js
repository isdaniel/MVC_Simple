/// <reference path="jquery-2.0.0.min.js" />
/// <reference path="jquery-1.2.6-vsdoc.js" />
function IsWrite(wdstring,tagname) {
    if (tagname == "" || tagname == "-1") {
        return wdstring;
    }
    else {
        return "成功";
    }
}
