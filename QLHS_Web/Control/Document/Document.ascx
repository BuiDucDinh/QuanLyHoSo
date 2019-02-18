<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Document.ascx.cs" Inherits="Control_Document_Document" EnableViewState="true" %>
<link href="/Resources/css/Style.css" rel="stylesheet" />
<script src="/Scripts/jquery-1.4.1.min.js"></script>
<link href="/css/uploadfile.css" rel="stylesheet" />
<style>
    .lstDoc, .overY {
        overflow-y: auto;
        padding: 0 10px;
    }

    .x-panel-body, .x-layout-split {
        background: none !important;
    }
</style>
<ext:Panel runat="server" Border="false" Width="800" Layout="border" Region="Center" Height="100">
    <Items>
        <ext:Hidden runat="server" ID="hdDocument">
            <Listeners>
                <Change Handler="getDocument(#{hdDocument}.getValue(),#{hdPanel}.getValue());" />
            </Listeners>
        </ext:Hidden>
        <ext:Panel ID="pnButton" runat="server" Region="West" Border="false" Split="true" DefaultAnchor="100%">
            <Content>
                <ext:ImageButton runat="server" ID="btnUpload" Cls="upload-btn" ImageUrl="/images/select_document_vi.jpg">
                    <Listeners>
                        <Click Handler="#{wdDetail}.show()" />
                    </Listeners>
                </ext:ImageButton>
            </Content>
        </ext:Panel>
        <ext:Panel runat="server" ID="pnDisplay" Border="false" Region="Center">
            <Content>
                <asp:Panel ID="lstDoc" CssClass="lstDoc" runat="server" Height="85">
                </asp:Panel>
            </Content>
        </ext:Panel>
        <ext:Hidden runat="server" ID="hdPanel" />
    </Items>
</ext:Panel>
<ext:Window runat="server" ID="wdDetail" Hidden="true" Title="Tài liệu" Icon="ApplicationForm"
    DefaultButton="0" Border="false" AutoScroll="true" Maximizable="true" Collapsible="true"
    MinWidth="900" MinHeight="450" Modal="true" Padding="3" Resizable="false">
    <Listeners>
        <Hide Handler="getDocument(#{hdDocument}.getValue(),#{hdPanel}.getValue());" />
    </Listeners>
</ext:Window>
<div class="error"></div>
<link href="/Template/css/font-awesome-4.6.3/css/font-awesome.min.css" rel="stylesheet" />
<script>
    $(document).ready(function () {
        var obj = {};
        obj.arrDoc = '<%=DocumentID%>'
        loadDocument(obj, '<%=lstDoc.ClientID%>');
    });
    function getDocument(value, element) {
        var obj = {};
        obj.arrDoc = value;
        if (typeof obj.arrDoc !== 'undefined') {
            loadDocument(obj, element);
        }
    }
    function loadDocument(obj, element) {
        if (obj.arrDoc != '0') {
            $.ajax({
                type: "POST",
                url: "/WebService/UpdateFile.asmx/LoadDocument",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var output = document.getElementById(element);
                    output.innerHTML = '';
                    if (data.d != '') {
                        var json = $.parseJSON(data.d);
                        for (var i = 0; i < json.length; i++) {

                            var a = document.createElement('a');
                            a.href = '/FileUpload/Document/' + json[i][2];
                            a.setAttribute('target', '_blank');
                            a.innerText = json[i][1];

                            //var i = document.createElement('i');
                            //i.setAttribute('class', 'fa fa-download icon');
                            //a.append(i, null);

                            var br = document.createElement('br');
                            output.insertBefore(a, null);

                            output.appendChild(br);
                        }
                    }
                },
                error: function (xhr, status, error) {
                    $('.error').html(xhr.responseText);
                }
            });
        }
    }
</script>
<style>
    .icon {
        padding-left: 15px;
    }
</style>
