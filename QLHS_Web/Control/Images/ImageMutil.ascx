<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageMutil.ascx.cs" Inherits="Control_Images_ImageMutil" %>


<link href="/Resources/css/Style.css" rel="stylesheet" />
<script src="/Scripts/jquery-1.4.1.min.js"></script>
<link href="/css/uploadfile.css" rel="stylesheet" />
<style>
    
    .x-panel-body,.x-layout-split {
        background: none !important;
    }
</style>
<div style="height: 110px">
    <ext:Panel runat="server" Border="false" Width="800" Layout="border" Region="Center" Height="100" Cls="bgwhite">
        <Items>
            <ext:Panel ID="pnButton" runat="server" Region="West" Border="false" Split="true" Margins="0 0 0 0" DefaultAnchor="100%" Width="120">
                <Content>
                    <ext:ImageButton runat="server" ID="btnUpload" Cls="upload-btn" ImageUrl="/images/select_image_vi.jpg" >
                        <Listeners>
                            <Click Handler="#{wdDetailMutil}.show()" />
                        </Listeners>
                    </ext:ImageButton>

                </Content>
            </ext:Panel>
            <ext:Panel runat="server" Width="350" Border="false" Region="Center" LabelWidth="100" Height="110">
                <Content>
                    <div class="displayImg horizontal" style="display: none">
                        <div class="table" id="lstImg">
                        </div>
                    </div>
                </Content>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window runat="server" ID="wdDetailMutil" Hidden="true" Title="Tài liệu" Icon="ApplicationForm"
        DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
        MinWidth="800" MinHeight="500" Modal="true" Padding="3" Resizable="false">
        <%--<AutoLoad Url="~/Control/Images/ImageManager1.aspx?type=mutil" Mode="IFrame" ShowMask="true" />--%>
        <Listeners>
            <Hide Fn="getImagesMutil" />
        </Listeners>
    </ext:Window>
    <ext:Hidden runat="server" ID="txtImageMutil" Text="" ClientIDMode="Static" />
    <div class="error"></div>

    <script type="text/javascript">
        $(document).ready(function () {
            
            var obj = {};
            obj.arrImg = '<%=ImageID%>'
            loadImageMutil(obj);
        });
        function getImagesMutil() {
            var obj = {};
            obj.arrImg = $('#txtImageMutil').val();
            if (typeof obj.arrImg !== 'undefined') {
                loadImageMutil(obj);
            }
        }
        function loadImageMutil(obj) {
            $.ajax({
                type: "POST",
                url: "/WebService/UpdateFile.asmx/UpImages",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != '') {
                        var json = $.parseJSON(data.d);
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
                },
                error: function (xhr, status, error) {
                    //$('.error').html(xhr.responseText);
                }
            });
        }
        //getImages();
    </script>
</div>
