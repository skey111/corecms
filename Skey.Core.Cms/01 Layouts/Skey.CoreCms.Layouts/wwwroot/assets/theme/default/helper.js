$(function () {
    var cturl = document.location.pathname;
    if (document.location.search != "") {
        cturl = document.location.pathname + document.location.search;
    }
    $("#divmenubox li").each(function () {
        var html = $(this).html();
        if (html.indexOf(cturl) != -1) {
            $(this).addClass(" layui-nav-itemed");
        }
    });
}) 