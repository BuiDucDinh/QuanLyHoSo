<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageOnly.ascx.cs" Inherits="NghiepVu_Control_Image" %>

<link href="/Resources/css/Style.css" rel="stylesheet" />
<script src="/Scripts/jquery-1.4.1.min.js"></script>
<style>
    .x-panel-body, .x-layout-split {
        background: none !important;
    }
</style>
<div style="height: 110px">
    <div id="ImageManager">
        <ext:ImageButton runat="server" ID="btnUploadOnly" Cls="upload-btn" ImageUrl="/images/select_image_vi.jpg">
            <Listeners>
                <Click Handler="#{wdDetailOnly}.show()" />
            </Listeners>
        </ext:ImageButton>

    </div>
    <ext:Window runat="server" ID="wdDetailOnly" Hidden="true" Icon="ApplicationForm"
        DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
        MinWidth="800" MinHeight="500" Modal="true" Padding="3" Resizable="false">
        <%-- <AutoLoad Url="~/Control/Images/ImageManager1.aspx?type=only&control=" Mode="IFrame" ShowMask="true" />--%>
        <Listeners>
            <Hide Fn="getImagesOnly" />
        </Listeners>
    </ext:Window>
    <ext:Hidden runat="server" ID="txtImageOnly" Text="" Cls="idhidden">
        <Listeners>
            <Change Handler="getImagesOnly();" />
        </Listeners>
    </ext:Hidden>
    <div class="error"></div>

    <script src="/Resources/js/Scroll%20hoz/jquery.js"></script>
    <script src="/Resources/js/Scroll%20hoz/enscroll-0.4.2.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var obj = {};
            obj.arrImg = '<%=ImageID%>'
            loadImageOnly(obj, '<%=txtImageOnly.ClientID%>');
        });


        function getImagesOnly() {
            $('.idhidden').each(function () {
                var string = $(this).val();
                if (typeof string != 'undefined') {
                    var split = string.split(';');
                    var obj = {};
                    obj.arrImg = split[0];
                    if (typeof obj.arrImg !== 'undefined') {
                        var control = split[1];
                        loadImageOnly(obj, control);
                    }
                }
            });

          <%--  var obj = {};
            var s = $('#<%=txtImageOnly.ClientID%>').val();
            if (typeof s != 'undefined') {
                var lst = s.split(';');
                var control = lst[1];
                obj.arrImg = lst[0];//$('#<%=txtImageOnly.ClientID%>').val();
                if (typeof obj.arrImg !== 'undefined') {
                    loadImageOnly(obj, control);
                }
            }--%>

        }
        function loadImageOnly(obj, control) {
            $.ajax({
                type: "POST",
                url: "/WebService/UpdateFile.asmx/UpImages",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var c = $('#' + control);
                    c.removeAttr('src');
                    if (data.d != '') {
                        var json = $.parseJSON(data.d);
                        c.attr("src", '/FileUpload/Images/' + json[0][1]);
                        return;
                    }
                    else {
                        c.attr("src", '/images/select_image_vi.jpg');
                    }
                },
                error: function (xhr, status, error) {
                    //$('.error').html(xhr.responseText);
                }
            });
        }
    </script>
</div>
