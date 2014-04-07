$(function () {

    loadData();

    $(".flexslider").flexslider({});
    //加载更多
    $("#btnCardmore").click(function () {
        PageNum++;
        loadData();
    });

    //打开报名
    $("body").on("click", ".btnBuy", function () {
        if ($(this).attr("class").indexOf("over") > -1) {
            showAlert("此楼盘已经下线，请关注其他楼盘");
        } else {
            var id = $(this).attr("title");
            $("#baoming")[0].reset();
            $("#itemId").val(id);
            openWin("#baoming");
        }
    });
});

var PageNum = 1, $divLoad = $("#divLoad"), $divMore = $("#divMore"), $items = $("#items");

function loadData() {
    $.ajax({
        type: "POST",
        url: "Handler/MyHandler.ashx",
        data: { method: 'initItemData', PageNum: PageNum },
        beforeSend: function () {
            $divLoad.show();
            $divMore.hide();
        },
        success: function (result) {
            var result = $.parseJSON(result);
            if (result.success) {
                if (result.RecordCount > 0) {
                    $items.append(result.html);
                } else {
                    $divMore.html("加载完毕");
                }
            }
        },
        complete: function () {
            $divMore.show();
            $divLoad.hide();
        },
        error: function () {
        }
    });
}