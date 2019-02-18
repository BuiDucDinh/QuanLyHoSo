(function ($) {
    $.fn.extend({
        smartpaginator: function (options) {
            var settings = $.extend({
                totalrecords: 0,
                recordsperpage: 0,
                length: 10,
                next: 'Next',
                prev: 'Prev',
                first: 'First',
                last: 'Last',
                go: 'Go',
                theme: 'green',
                display: 'double',
                initval: 1,
                datacontainer: '', //data container id
                dataelement: '', //children elements to be filtered e.g. tr or div
                onchange: null,
                controlsalways: false
            }, options);
            return this.each(function () {
                var currentPage = 0;
                var startPage = 0;
                var totalpages = parseInt(settings.totalrecords / settings.recordsperpage);
                if (settings.totalrecords % settings.recordsperpage > 0) totalpages++;
                var initialized = false;
                var container = $(this).addClass('pager').addClass(settings.theme);
                container.find('ul').remove();
                container.find('div').remove();
                container.find('span').remove();
                var dataContainer;
                var dataElements;
                if (settings.datacontainer != '') {
                    dataContainer = $('#' + settings.datacontainer);
                    dataElements = $('' + settings.dataelement + '', dataContainer);
                }
                var list = $('<ul/>');
                var btnPrev = $('<div/>').text(settings.prev).click(function () { if ($(this).hasClass('disabled')) return false; currentPage = parseInt(list.find('li a.active').text()) - 1; navigate(--currentPage); }).addClass('btn');
                var btnNext = $('<div/>').text(settings.next).click(function () { if ($(this).hasClass('disabled')) return false; currentPage = parseInt(list.find('li a.active').text()); navigate(currentPage); }).addClass('btn');
                var btnFirst = $('<div/>').text(settings.first).click(function () { if ($(this).hasClass('disabled')) return false; currentPage = 0; navigate(0); }).addClass('btn');
                var btnLast = $('<div/>').text(settings.last).click(function () { if ($(this).hasClass('disabled')) return false; currentPage = totalpages - 1; navigate(currentPage); }).addClass('btn');
                var inputPage = $('<input/>').attr('type', 'text').keydown(function (e) {
                    if (isTextSelected(inputPage)) inputPage.val('');
                    if (e.which >= 48 && e.which < 58) {
                        var value = parseInt(inputPage.val() + (e.which - 48));
                        if (!(value > 0 && value <= totalpages)) e.preventDefault();
                    } else if (!(e.which == 8 || e.which == 46)) e.preventDefault();
                });
                var btnGo = $('<input/>').attr('type', 'button').attr('value', settings.go).addClass('btn').click(function () { if (inputPage.val() == '') return false; else { currentPage = parseInt(inputPage.val()) - 1; navigate(currentPage); } });
                container.append(btnFirst).append(btnPrev).append(list).append(btnNext).append(btnLast).append($('<div/>').addClass('short').append(inputPage).append(btnGo));
                if (settings.display == 'single') {
                    btnGo.css('display', 'none');
                    inputPage.css('display', 'none');
                }
                buildNavigation(startPage);
                if (settings.initval == 0) settings.initval = 1;
                currentPage = settings.initval - 1;
                navigate(currentPage);
                initialized = true;
                function showLabels(pageIndex) {
                    container.find('span').remove();
                    var upper = (pageIndex + 1) * settings.recordsperpage;
                    if (upper > settings.totalrecords) upper = settings.totalrecords;
                    container.append($('<span/>').append($('<b/>').text(pageIndex * settings.recordsperpage + 1)))
                                             .append($('<span/>').text('-'))
                                             .append($('<span/>').append($('<b/>').text(upper)))
                                             .append($('<span/>').text('of'))
                                             .append($('<span/>').append($('<b/>').text(settings.totalrecords)));
                }
                function buildNavigation(startPage) {
                    list.find('li').remove();
                    if (settings.totalrecords <= settings.recordsperpage) return;
                    for (var i = startPage; i < startPage + settings.length; i++) {
                        if (i == totalpages) break;
                        list.append($('<li/>')
                                    .append($('<a>').attr('id', (i + 1)).addClass(settings.theme).addClass('normal')
                                    //.attr('href', 'javascript:void(0)')
                                    .text(i + 1))
                                    .click(function () {
                                        currentPage = startPage + $(this).closest('li').prevAll().length;
                                        navigate(currentPage);
                                    }
                                    )
                        );
                    }
                    showLabels(startPage);
                    inputPage.val((startPage + 1));
                    list.find('li a').addClass(settings.theme).removeClass('active');
                    list.find('li:eq(0) a').addClass(settings.theme).addClass('active');
                    //set width of paginator
                    var sW = list.find('li:eq(0) a').outerWidth() + (parseInt(list.find('li:eq(0)').css('margin-left')) * 2);
                    var width = sW * list.find('li').length;
                    list.css({ width: width });
                    showRequiredButtons(startPage);
                }
                function navigate(topage) {
                    //make sure the page in between min and max page count
                    var index = topage;
                    var mid = settings.length / 2;
                    if (settings.length % 2 > 0) mid = (settings.length + 1) / 2;
                    var startIndex = 0;
                    if (topage >= 0 && topage < totalpages) {
                        if (topage >= mid) {
                            if (totalpages - topage > mid)
                                startIndex = topage - (mid - 1);
                            else if (totalpages > settings.length)
                                startIndex = totalpages - settings.length;
                        }
                        buildNavigation(startIndex); showLabels(currentPage);
                        list.find('li a').removeClass('active');
                        inputPage.val(currentPage + 1);
                        list.find('li a[id="' + (index + 1) + '"]').addClass('active');
                        //var recordStartIndex = currentPage * settings.recordsperpage;
                        //var recordsEndIndex = recordStartIndex + settings.recordsperpage;
                        //if (recordsEndIndex > settings.totalrecords)
                        //    recordsEndIndex = settings.totalrecords % recordsEndIndex;
                        //if (initialized) {
                        //    if (settings.onchange != null) {
                        //        settings.onchange((currentPage + 1), recordStartIndex, recordsEndIndex);
                        //    }
                        //}
                        //if (dataContainer != null) {
                        //    if (dataContainer.length > 0) {
                        //        //hide all elements first
                        //        dataElements.css('display', 'none');
                        //        //display elements that need to be displayed
                        //        if ($(dataElements[0]).find('th').length > 0) { //if there is a header, keep it visible always
                        //            $(dataElements[0]).css('display', '');
                        //            recordStartIndex++;
                        //            recordsEndIndex++;
                        //        }
                        //        for (var i = recordStartIndex; i < recordsEndIndex; i++)
                        //            $(dataElements[i]).css('display', '');
                        //    }
                        //}

                        loadImage((index + 1), 10);
                        showRequiredButtons();
                        
                    }
                }
                function showRequiredButtons() {
                    if (totalpages > settings.length) {
                        if (currentPage > 0) {
                            if (!settings.controlsalways) {
                                btnPrev.css('display', '');
                            }
                            else {
                                btnPrev.css('display', '').removeClass('disabled');
                            }
                        }
                        else {
                            if (!settings.controlsalways) {
                                btnPrev.css('display', 'none');
                            }
                            else {
                                btnPrev.css('display', '').addClass('disabled');
                            }
                        }
                        if (currentPage > settings.length / 2 - 1) {
                            if (!settings.controlsalways) {
                                btnFirst.css('display', '');
                            }
                            else {
                                btnFirst.css('display', '').removeClass('disabled');
                            }
                        }
                        else {
                            if (!settings.controlsalways) {
                                btnFirst.css('display', 'none');
                            }
                            else {
                                btnFirst.css('display', '').addClass('disabled');
                            }
                        }

                        if (currentPage == totalpages - 1) {
                            if (!settings.controlsalways) {
                                btnNext.css('display', 'none');
                            }
                            else {
                                btnNext.css('display', '').addClass('disabled');
                            }
                        }
                        else {
                            if (!settings.controlsalways) {
                                btnNext.css('display', '');
                            }
                            else {
                                btnNext.css('display', '').removeClass('disabled');
                            }
                        }
                        if (totalpages > settings.length && currentPage < (totalpages - (settings.length / 2)) - 1) {
                            if (!settings.controlsalways) {
                                btnLast.css('display', '');
                            }
                            else {
                                btnLast.css('display', '').removeClass('disabled');
                            }
                        }
                        else {
                            if (!settings.controlsalways) {
                                btnLast.css('display', 'none');
                            }
                            else {
                                btnLast.css('display', '').addClass('disabled');
                            }
                        };
                    }
                    else {
                        if (!settings.controlsalways) {
                            btnFirst.css('display', 'none');
                            btnPrev.css('display', 'none');
                            btnNext.css('display', 'none');
                            btnLast.css('display', 'none');
                        }
                        else {
                            btnFirst.css('display', '').addClass('disabled');
                            btnPrev.css('display', '').addClass('disabled');
                            btnNext.css('display', '').addClass('disabled');
                            btnLast.css('display', '').addClass('disabled');
                        }
                    }
                }
                function isTextSelected(el) {
                    var startPos = el.get(0).selectionStart;
                    var endPos = el.get(0).selectionEnd;
                    var doc = document.selection;
                    if (doc && doc.createRange().text.length != 0) {
                        return true;
                    } else if (!doc && el.val().substring(startPos, endPos).length != 0) {
                        return true;
                    }
                    return false;
                }
            });
        }
    });
})(jQuery);


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
                
            }
        },
        error: function (err) {
            alert('error count');
            return;
        }
    });

}
//var pagingItem = function (event) {
//    debugger;
//    var index = $(this).attr('id');
//    loadImage(index, 10);
//};
//$(document).on('click', '#black li a', pagingItem);

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
            $.each(lstVal, function (index, value) {
                $('#cb' + value).attr('checked', 'checked');
            });
            //$('input:checkbox').each(function () {
            //    var val = $(this).val();
            //    if ($.inArray(val, lstVal) >= 0) {
            //        debugger;
            //        $(this).attr('checked', 'checked');
            //    }
            //});
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

var checkbox = function (event) {
    debugger;
    var val = $(this).val();
    if ($(this).is(':checked')) {
        lstVal.push($(this).attr('value'));
    }
    else {
        lstVal.splice($.inArray(val, lstVal), 1);
    }
};
$(document).on('click', 'input:checkbox', checkbox);
//var lstVal = [];   đc khai báo trong file ImageManager1.aspx
