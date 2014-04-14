function tobaoming() {
    openWin("#boxUpBM");
}

function showCenter(type) {

    switch (type) {
        case 'about':
            $("#boxUpContent").html('<h2>关于华宇经典</h2><hr/><div  style="text-align:left;"><p><strong>北京指尖美景传媒广告有限公司代理，全力推荐！</strong></p><p>华宇经典紧邻香河县主干道——新华大街，与毗邻的城市东西轴线——新开街构成香河县的十字交叉黄金枢纽、交通四通八达，瞬间通达城市东西南北。滚滚人流，车流汇集于此，通过京哈高速、京唐高铁（在建中）、密涿高速（在建中），更是辐射北京东部500万高端商务人流。</p></div>');
            openWin("#boxShow");
            break;
        case 'contact':
            $("#boxUpContent").html('<h2>联系我们</h2><hr/><div style="text-align:left;"><h4>公司地址：北京朝阳通惠河北路31号泰珍嘉大厦5、6层</h4><h4>官方热线：<a href="tel:400-627-6577" style="color:white;">400-627-6577</a></h4>推荐直接在线报名，豪礼赠不停！华宇经典，环北京最超值楼盘！</h4></div>');
            openWin("#boxShow");
            break;
    }
}

/**回到顶部按钮*/
$(window).scroll(function () {
    $("#sys_backtotop").unbind("click");
    if ($("#sys_backtotop").length == 0) {
        $("body").append("<a href='javascript:;'><div id='sys_backtotop' style='border-radius:20px 20px;background:rgb(55,193,0);color:white;box-shadow: 0 0 .3em .005em rgba(0,0,0,0.3);font-weight:bold;padding:0.5%;position:fixed;right:1.5%;bottom:1.5%;overflow:hidden;display:none;z-index:9;'>顶↑</div></a>");
    }
    if ($(window).scrollTop() > 100) {
        $("#sys_backtotop").fadeIn(500);
    } else {
        $("#sys_backtotop").fadeOut(500);
    }

    $("#sys_backtotop").bind("click", function () {
        $('body,html').animate({
            scrollTop: 0
        }, 1000);
        return false;
    });
});

var flag = false;
function DrawImage(ImgD, width, height) {
    return;
    var image = new Image();
    image.src = ImgD.src;
    if (image.width > 0 && image.height > 0) {
        flag = true;
        if (image.width / image.height >= width / height) {
            if (image.width > width) {
                ImgD.width = width;
                ImgD.height = (image.height * width) / image.width;
            } else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
            //ImgD.alt=image.width+"×"+image.height;
        }
        else {
            if (image.height > height) {
                ImgD.height = height;
                ImgD.width = (image.width * height) / image.height;
            } else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
            //ImgD.alt=image.width+"×"+image.height;
        }
    }
}

$(function () {
    var id = 1007;
    $("#itemId").val(id);

    if (getBType()) {
        openWin("#boxUpBM");
    }

    $.ajax({
        url: "handler/MyHandler.ashx",
        type: "POST",
        data: { method: "initPicInfo", itemid: 1007 },
        success: function (result) {
            var data = $.parseJSON(result);
            var str = '<table width="100%" border="0" cellspacing="0" cellpadding="0"><tbody><tr>';
            $.each(data.pics, function (index, data) {
                $.each(data, function (i, obj) {
                    str = str + '<td><table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 155px; margin: 5px;"><tbody>' +
                    '<tr align="center"><td><table width="100%" border="0" cellspacing="0" cellpadding="0"><tbody>' +
                    '<tr><td style="width: 155px; height: 125px; border: 1px solid #C4D5E3; padding: 2px;">' +
                    '<a href="' + obj.vc_PicFile + '" target="_blank">' +
                    '<img src="' + obj.vc_Pic1 + '" border="0" width="150" height="112" onload="DrawImage(this,150,120)"></a>' +
                    '</td></tr><tr><td height="30"><a href="' + obj.vc_PicFile + '" target="_blank">' + obj.vc_PicType + ' / ' + obj.vc_PicDesc + '</a></td></tr></tbody></table></td>' +
                    '</tr></tbody></table></td>';
                });
            });
            $("#sj1").html(str);
            $("#sj2").html(str);

            var speed = 15;
            sj2.innerHTML = sj1.innerHTML;
            function Marquee1() {
                if (sj2.offsetWidth - sj.scrollLeft <= 0)
                    sj.scrollLeft -= sj1.offsetWidth;
                else {
                    sj.scrollLeft++;
                }
            }
            var MyMar1 = setInterval(Marquee1, speed);
            sj.onmouseover = function () { clearInterval(MyMar1); };
            sj.onmouseout = function () { MyMar1 = setInterval(Marquee1, speed); };
        }
    });
});