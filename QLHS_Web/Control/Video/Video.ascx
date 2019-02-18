<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Video.ascx.cs" Inherits="Control_Video_Video" %>

<link href="/Resources/css/Style.css" rel="stylesheet" />
<script src="/Scripts/jquery-1.4.1.min.js"></script>
<link href="/Resources/css/styleHozScroll.css" rel="stylesheet" />
<script src="/Resources/js/Scroll%20hoz/html5shiv.js"></script>
<link href="/css/uploadfile.css" rel="stylesheet" />
<style>
    .lstDoc, .overY {
        overflow-y: auto;
    }
    .x-panel-body,.x-layout-split {
        background: none !important;
    }
</style>
<div style="height: 110px">
    <ext:Panel runat="server" Border="false" Width="800" Layout="border" Region="Center" Height="100" Cls="bgwhite">
        <Items>
            <ext:Panel ID="pnButton" runat="server" Region="West" Border="false" Split="true" Margins="0 0 0 0" DefaultAnchor="100%" Width="120">
                <Content>
                    <ext:ImageButton runat="server" ID="btnUpload" Cls="upload-btn" ImageUrl="/images/select_Video.jpg" FieldLabel="Chọn video">
                        <Listeners>
                            <Click Handler="#{wdDetail}.show()" />
                        </Listeners>
                    </ext:ImageButton>

                </Content>
            </ext:Panel>
            <ext:Panel runat="server" ID="pnDisplay" Width="200" Border="false" Region="Center" LabelWidth="100">
                <Content>
                    <div class="displayImg horizontal" style="display: none">
                        <asp:Panel ID="lstVideo" CssClass="table" runat="server">
                        </asp:Panel>
                    </div>
                     <div class="displayImg horizontal" style="display: none">
                        <div class="table" id="lstImg">
                        </div>
                    </div>
                </Content>
            </ext:Panel>
            <ext:Hidden runat="server" ID="hdPanel" />
        </Items>
    </ext:Panel>

    <ext:Window runat="server" ID="wdDetail" Hidden="true" Title="Tài liệu" Icon="ApplicationForm"
        DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
        MinWidth="850" MinHeight="500" Modal="true" Padding="3" Resizable="false">
        <Listeners>
            <Hide Handler="getVideo(#{hdVideo}.getValue(),#{hdPanel}.getValue());" />
        </Listeners>
    </ext:Window>
    <ext:Hidden runat="server" ID="hdVideo" Text="" />
    <script>
        $(document).ready(function () {
            var obj = {};
            obj.arr = '<%=VideoID%>'
            loadVideos(obj, '<%=lstVideo.ClientID%>');

        });
        function getVideo(value, element) {
            var obj = {};
            obj.arr = value;
            if (typeof obj.arr !== 'undefined') {
                loadVideos(obj, element);
            }
        }
        function loadVideos(obj, element) {
            $.ajax({
                type: "POST",
                url: "/WebService/UpdateFile.asmx/LoadVideo",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != '') {
                        var json = $.parseJSON(data.d);
                        $('.displayImg').show();
                        var output = document.getElementById(element);
                        output.innerHTML = '';
                        for (var i = 0; i < json.length; i++) {
                            var article = document.createElement('article');
                            var a = document.createElement('a');
                            a.href = '/FileUpload/Video/' + json[i][2];
                            a.target = '_blank';
                            var img = document.createElement('img');
                            img.src = '/FileUpload/Images/' + json[i][3];
                            var p = document.createElement('p');
                            p.innerText = json[i][1];
                            a.insertBefore(img, null);
                            article.insertBefore(a, null);
                            article.insertBefore(p, null);
                            output.insertBefore(article, null);
                        }
                    }
                },
                error: function (xhr, status, error) {
                    //$('.error').html(xhr.responseText);
                }
            });
        }
    </script>
</div>
