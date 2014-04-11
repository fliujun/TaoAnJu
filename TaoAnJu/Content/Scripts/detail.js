$(function () {
    //var opt = { title: "小淘提示", content: "现在立即关注淘安居官方微信（taoanjufc），即可领取看房现金红包，还可微信在线预约排号，更多实用功能等你来发现！" };
    //$('#btnBuyHelp').popover(opt);

    if (getBType()) {
        openWin("#boxUpBM");
    }
    
    var id = GetQueryString("id");
    $("#itemId").val(id);
    $.ajax({
        url: "handler/MyHandler.ashx",
        type: "POST",
        data: { method: "itemDetail", itemid: id },
        success: function (result) {
            var data = $.parseJSON(result);
            if (data.html) {
                $("#tableinfo").html(data.html);
                if (data.Location) {
                    initMap(data.Location);
                }
            }
            if (data.ItemName) {
                $(".itemName").text(data.ItemName);
            }
            if (data.sliderPics) {
                var str = "";
                $.each(data.sliderPics, function (index, item) {
                    str = str + '<li class="slide"><img src="' + item + '" /></li>';
                });
                $("#pics").html(str);
                $('.slider').glide({
                    animationTime: 500, //动画过度效果，只有当浏览器支持CSS3的时候生效
                    arrows: false, //是否显示左右导航器
                });
            }
            if (data.Discount) {
                $(".btnApply").text(data.Discount);
            }
            if (data.Hotline) {
                $("#Hotline").append("咨询热线：<a href='tel:" + data.Hotline + "'>&nbsp;<label style='color:green;font-size:22px;'>" + data.Hotline + "</label></a>");
                $("#btnTel").attr("href", "tel:" + data.Hotline);
                $(".itemTel").text(data.Hotline);
            }
            if (data.ReferencePrice) {
                $("#ReferencePrice").html("<label style='font-size:18px;'>当前均价</label><label style='color:red;'>" + data.ReferencePrice+"</label>");
            }
            if (data.vedio) {
                var str = "";
                $.each(data.vedio, function (index, item) {
                    str = str + '<div class="col-lg-12"><embed src="' + item.vc_ViewFile + '" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" autostart="false" loop=" target="_blank" wmode="opaque" width="100%" height="300"></embed></div>';
                });
                $("#vedio").html(str);
            }
            if (data.OpeningTime) {
                var str = data.ItemName + "，" + data.Discount + "，" + data.OpeningTime + "盛大开盘！";
                $(".txtAdLine").append(str);
            }
            if (data.pics) {
                var str = "";
                $.each(data.pics, function (index, data) {
                    str = str + '<div class="picRow"><div class="pic-title">' + data[0].vc_PicType + '</div><div class="row">';
                    $.each(data, function (i, obj) {
                        str = str + '<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">' +
                                        '<a href="' + obj.vc_PicFile + '" data-lightbox="itempic" data-title="' + obj.vc_PicType + ' / ' + obj.vc_PicDesc + '">' +
                                            '<img src="' + obj.vc_Pic1 + '"/>' +
                                        '</a>' +
                                    '</div>';
                    });
                    str = str + '</div></div>';
                });
                $("#itemPics").html(str);
            }
        }
    });
});

//初始化地图
function initMap(addr) {
    var map = new qq.maps.Map(document.getElementById("qqmap"),
    {
        center: new qq.maps.LatLng(39.914850, 116.403765),
        zoom: 13,
        draggable: true,
        scrollwheel: true,
        disableDoubleClickZoom: true
    });

    var callbacks = {
        //若服务请求成功，则运行以下函数，并将结果传入
        complete: function (result) {
            map.setCenter(result.detail.location);
            var marker = new qq.maps.Marker({
                map: map,
                position: result.detail.location
            });
        },
        //若服务请求失败，则运行以下函数
        error: function () {
            console.error("地图定位出错");
        }
    }
    //创建类实例
    geocoder = new qq.maps.Geocoder(callbacks);
    //地址解析
    //geocoder.getLocation("中国,北京,海淀区,海淀大街38号");
    geocoder.getLocation(addr);

    //var pano_container = document.getElementById('qqmap');  //街景容器
    //var pano = new qq.maps.Panorama(pano_container, {
    //    pano: '10011501120802180635300',    //场景ID
    //    pov: {   //视角
    //        heading: 1,  //偏航角
    //        pitch: 0     //俯仰角
    //    },
    //    zoom: 1      //缩放
    //});
}