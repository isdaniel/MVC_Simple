/// <reference path="jquery.min.js" />
/*
上傳檔案產生器
*/
$(function () {
    var num = 1;
    $("#multiplexupload").click(function () {
        var file = '<input type="file" name="files" id="file' + num + '" /><br/>';
        $("#uploadgroup").append(file);
        num++;
    });
});