$(function () {
    var id = 1007;
    $("#itemId").val(id);

    if (getBType()) {
        openWin("#boxUpBM");
    }
});

function tobaoming() {
    openWin("#boxUpBM");
}

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