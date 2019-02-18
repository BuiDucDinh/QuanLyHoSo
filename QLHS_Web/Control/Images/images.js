
$(document).ready(function () {
    loadImage(1, 10);
    getPaging();
});
function getPaging() {
    var danhmuc = $('#hdDanhmuc').val();
    if (typeof danhmuc == 'undefined') {
        danhmuc = '';
    }
    var obj = {};
    obj.danhmuc = danhmuc;
    $.ajax({
        type: "POST",
        url: "/WebService/UpdateFile.asmx/LoadImagesCount",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            if (data.d != '') {
                var totalrow = data.d
                $('#black').smartpaginator({ totalrecords: totalrow, recordsperpage: 10, lenght: 4, datacontainer: 'lib', dataelement: '.img_detail', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });
                $(document).on('click', '#black li a', pagingItem);
            }
        },
        error: function (err) {
            alert('error r');
            return;
        }
    });

}
var pagingItem = function (event) {
    debugger;
    var index = $(this).attr('id');
    loadImage(index, 10);
};
$(document).on('click', '#black li a', pagingItem);

function loadImage(index, count) {
    var danhmuc = $('#hdDanhmuc').val();
    if (typeof danhmuc == 'undefined') {
        danhmuc = '';
    }
    var obj = {};
    obj.danhmuc = danhmuc;
    obj.index = index;
    obj.count = count;
    $.ajax({
        type: "POST",
        url: "/WebService/UpdateFile.asmx/LoadImages",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            if (data.d != '') {
                var output = document.getElementById("lib");
                output.innerHTML = '';
                var json = $.parseJSON(data.d);
                for (var i = 0; i < json.length; i++) {
                    var div = document.createElement('div');
                    div.className = "img_detail";

                    var checkbox = document.createElement('input');
                    checkbox.setAttribute("type", "checkbox");
                    checkbox.setAttribute("id", "cb" + json[i][0]);
                    checkbox.setAttribute("value", json[i][0]);

                    var label = document.createElement('label');
                    label.setAttribute("for", "cb" + json[i][0]);
                    var img = document.createElement('img');
                    img.setAttribute("class", "thumb");
                    img.setAttribute("src", '/FileUpload/Images/' + json[i][1]);
                    label.insertBefore(img, null);

                    div.insertBefore(label, null);
                    div.insertBefore(checkbox, label);

                    output.insertBefore(div, null);
                }
            }
            //var totalrow = $("#lib .img_detail").length;
            //$('#black').smartpaginator({ totalrecords: totalrow, recordsperpage: 10, lenght: 4, datacontainer: 'lib', dataelement: '.img_detail', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });

        },
        error: function (err) {
            //alert('error r');
            return;
        }
    });
}

var data = new FormData();
var img = [];
function handleFileSelect(event) {
    var files = event.target.files; //FileList object
    if (files.length > 0) {
        var output = document.getElementById("message");
        //load thumb
        for (var i = 0, f; f = files[i]; i++) {
            if (!f.type.match('image.*')) {
                alert('Chỉ được phép up ảnh')
                continue;
            }
            //var rightNow = new Date();
            //var res = rightNow.toISOString().slice(0, 30).replace(/-/g, "_").replace(/:/g, "_").replace(/./g, "_");
            // f.name = f.name.substring(0, f.name.lastIndexOf('.')) + res + f.name.substring(f.name.lastIndexOf('.') + 1, f.name.lenght);
            //img.push(f.name);
            data.append(f.name, f);
            var file = files[i];
            var picReader = new FileReader();

            picReader.addEventListener("load", function (event) {

                var picFile = event.target;
                var div = document.createElement('div');
                div.className = "img_detail";
                //var span = document.createElement('span');
                div.innerHTML = ['<img class="thumb" src="', picFile.result, '"/><span class="remove_img_preview"></span>'].join('');
                //div.appendChild(span);
                output.insertBefore(div, null);
                createImage(output);

            });
            picReader.readAsDataURL(file);
        }
    }
}

$("#btnUpload").click(function (evt) {
    var danhmuc = $('#hdDanhmuc').val();
    if (typeof danhmuc !== 'undefined' && danhmuc != '') {
        $.ajax({
            url: "ArticleGet.ashx",
            type: "POST",
            data: data,
            contentType: false,
            processData: false,
            success: function (result) {
                img = result.split(',');
                evt.preventDefault();

                Ext.net.DirectMethods.SaveImage(img, danhmuc, {
                    success: function (result) {
                        Ext.Msg.alert('Thông báo', 'Upload ảnh thành công!!!');
                        $('.img_detail').remove();
                        loadImage(1, 10);
                        getPaging();

                        data.forEach(function (val, key, fD) {
                            data.delete(key)
                        });
                    },
                    failure: function (errorMsg) {
                        Ext.Msg.alert('Failure', errorMsg);
                    }
                });
            },
            error: function (err) {
                alert('error r');
                return;
            }
        });

    }
    else {
        Ext.Msg.alert('Lỗi', 'Bạn chưa chọn danh mục ảnh');
    }
});

$('#message').on('click', '.remove_img_preview', function () {

    var itemRemove = $(this).parent('span');
    //alert(itemRemove.prop("tagName"));

    itemRemove.remove();
});
