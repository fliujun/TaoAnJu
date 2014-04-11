//弹窗ID
var arr = new Array(), $alert = $("#alert"), $mask = $("#mask");

//关闭弹窗
function closeWin() {
    for (var i = 0; i < arr.length; i++) {
        $(arr[i]).fadeOut(500);
    }
    $mask.hide();
}

//显示弹窗
function openWin(s) {
    arr.push(s);
    $mask.show();
    $(s).fadeIn(500);
}

//弹出提示
function showAlert(s, isError) {
    if (isError) {
        $alert.addClass("alertError");
    } else {
        $alert.removeClass("alertError");
    }
    arr.push("#alert");
    $alert.fadeIn(300);
    $("#alertContent").html(s);
}
function showAlertMask(s, isError) {
    if (isError) {
        $alert.addClass("alertError");
    } else {
        $alert.removeClass("alertError");
    }
    openWin("#alert");
    $("#alertContent").html(s);
}

//点击空白隐藏弹窗
$mask.click(function () {
    closeWin();
});

//选择地区按钮
$("#btnArea").click(function () {
    $("#areaWin").fadeIn(200);
});

//选择地区
$("#areaWin li a").click(function () {
    $("#txtArea").text($(this).text());
    $("#areaWin").fadeOut();
});

//搜索
$("#btnSearch").click(function () {
    var flexslider = $("header").height() + $("#flexslider").height() + 50;
    $("html,body").animate({ scrollTop: flexslider }, 200);
    $("#items").hide();
    $("#items").show(500);
    closeWin();
});

//返回顶部
$("#btnBack").click(function () {
    $('html,body').animate({ scrollTop: 0 }, 400);
});

//滚动显示返回顶部
var backhide;
$(window).scroll(function () {
    if ($(document).scrollTop() > 500) {
        clearTimeout(backhide);
        $("#back").show();
        backhide = setTimeout(function () {
            $("#back").hide(300);
        }, 1500);
    }
});


//置顶
$("#back").hover(function () {
    clearTimeout(backhide);
}, function () {
    backhide = setTimeout(function () {
        $("#back").hide(300);
    }, 1500);
});

//获取URL参数
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

//报名
var $btnApply = $('#btnApply'), $username = $("#username"), $usertel = $("#usertel"), $username2 = $("#username2"), $usertel2 = $("#usertel2"), $boxUpBM = $("#boxUpBM");
$btnApply.button();
$(".btnApply").on("click", function () {
    var id = $("#itemId").val();
    var username, usertel;
    if ($boxUpBM.is(":hidden")) {
        username = $.trim($username.val());
        usertel = $.trim($usertel.val());
    } else {
        username = $.trim($username2.val());
        usertel = $.trim($usertel2.val());
    }

    if (!id) {
        showAlert("参数丢失，请刷新页面后重试", true);
        return;
    }
    if (username.length == 0) {
        showAlert("请输入您的姓名", true);
        return;
    }
    if (usertel.length == 0 || !isMobile(usertel)) {
        showAlert("请输入正确的手机号", true);
        return;
    }
    baoming(id, username, usertel);
});

//在线报名
function baoming(id, username, usertel) {
    $.ajax({
        url: "handler/MyHandler.ashx",
        type: "POST",
        data: { method: "baoming", id: id, username: username, usertel: usertel },
        beforeSend: function () {
            $btnApply.button("loading");
        },
        success: function (result) {
            var data = $.parseJSON(result);
            if (data.success) {
                showAlert("恭喜您申请成功，关注微信（taoanjufc）即可获得一对一免费买房服务，还可查询更多信息、参与抽奖、领取看房现金红包！");
            } else {
                showAlert(data.error, true);
            }
        },
        complete: function () {
            $btnApply.button('reset');
        },
        error: function () {
        }
    });
}

//是否是11位手机号
function isMobile(n) {
    return /^1\d{10}$/.test(n) && n != 11111111111;
}

//判断浏览器是平板、手机还是PC
function getBType() {
    var agent = navigator.userAgent.toLowerCase();
    var res = agent.match(/android/);
    if (res == "android")
        return res;
    res = agent.match(/iphone/);
    if (res == "iphone")
        return "ios";
    res = agent.match(/ipad/);
    if (res == "ipad")
        return "ios";
    res = agent.match(/windows/);
    if (res == "windows")
        return "wp";
    return "pc";
}

//底部显示
function showB(type) {
    switch (type) {
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 7:
        case 8://走进淘安居
            showAlertMask("<p>淘安居房地产经纪（北京）有限公司是一家专注于项目运作、房地产策划及营销代理业务的经纪公司，拥有房地产策划、销售代理服务、产业整合和土地运营四大核心业务体系。 公司具备专业化的营销策划推广人才和精干的销售团队，目前已在海南、北京、河北燕郊、香河、大厂、固安、廊坊及湖北等多个区域代理过十余个项目，涵盖住宅、别墅、写字楼、商业和工业园区等多种业态。</p>");
            break;
        case 9:
        case 10:
        case 11:
        case 12:
            showAlertMask('<a href="Content/images/weixinEQ.jpg" class="col-lg-5 col-md-5 col-sm-8 col-xs-12" data-lightbox="weixinEQ" data-title="淘安居官方微信二维码，扫一扫关注就有惊喜，红包火热派发中！您还可以直接添加微信号：taoanjufc"><img src="Content/images/weixinEQ.jpg" style="width:100%;margin-bottom:20px;" /></a>');
            break;
    }

}