<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Image.ascx.cs" Inherits="NghiepVu_Control_Image" %>

<link href="/Resources/css/Style.css" rel="stylesheet" />
<script src="/Scripts/jquery-1.4.1.min.js"></script>
<script type="text/javascript">
    function getImage(fileupload) {
        if (fileupload.value != '') {
            //document.getelementbyid("btnimage").click();
        }
    }
</script>
<link href="/Resources/css/styleHozScroll.css" rel="stylesheet" />
<script src="/Resources/js/Scroll%20hoz/html5shiv.js"></script>
<div style="height: 110px">
    <div id="ImageManager">
        <ext:ImageButton runat="server" ID="btnUpload" ImageUrl="/images/select_image_vi.jpg">
            <Listeners>
                <Click Handler="#{wdDetail}.show()" />
            </Listeners>
        </ext:ImageButton>

        <div class="displayImg horizontal" style="display: none">
            <div class="table" id="lstImg">
            </div>
        </div>
        <%--        <asp:Button runat="server" ID="btnImage" Text="Load" ClientIDMode="Static" OnClick="btnImage_Click" CssClass="hidden" />--%>
    </div>

    <ext:Window runat="server" ID="wdDetail" Hidden="true" Title="Tài liệu" Icon="ApplicationForm"
        DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
        MinWidth="680" MinHeight="500" Modal="true" Padding="3" Resizable="false">
        <AutoLoad Url="~/Control/Images/ImageManager1.aspx?type=<%=type %>" Mode="IFrame" ShowMask="true" />
        <Listeners>
            <Hide Fn="getImages" />
        </Listeners>
    </ext:Window>
    <ext:Hidden runat="server" ID="txtImage" Text="" ClientIDMode="Static" />
    <div class="error"></div>

    <script src="/Resources/js/Scroll%20hoz/jquery.js"></script>
    <script src="/Resources/js/Scroll%20hoz/enscroll-0.4.2.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.horizontal').enscroll({
                horizontalTrackClass: 'horizontal-track2',
                horizontalHandleClass: 'horizontal-handle2',
                verticalScrolling: false,
                horizontalScrolling: true,
                addPaddingToPane: true
            });
            var obj = {};
            obj.arrImg = '<%=ImageID%>'
            loadImage(obj);
        });


        function getImages() {
            var obj = {};
            obj.arrImg = $('#txtImage').val();
            if (typeof obj.arrImg !== 'undefined') {
                loadImage(obj);
            }
        }
        function loadImage(obj) {
            $.ajax({
                type: "POST",
                url: "/WebService/Image.asmx/ListImages",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != '') {
                        var json = $.parseJSON(data.d);
                        if ('<%=type%>' == 'only') {
                            $('.displayImg').hide();
                            $('#Image_btnUpload').attr("src", '/FileUpload/Images/' + json[0][1]);
                        }
                        else {
                            $('.displayImg').show();
                            var output = document.getElementById("lstImg");
                            output.innerHTML = '';
                            // output.innerHTML();
                            for (var i = 0; i < json.length; i++) {
                                var article = document.createElement('article');
                                var img = document.createElement('img');
                                img.src = '/FileUpload/Images/' + json[i][1];
                                article.insertBefore(img, null);
                                output.insertBefore(article, null);
                            }
                        }
                    }
                },
                error: function (xhr, status, error) {
                    $('.error').html(xhr.responseText);
                }
            });
        }
        //getImages();
    </script>
</div>
