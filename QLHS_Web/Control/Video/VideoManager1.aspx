<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoManager1.aspx.cs" Inherits="NghiepVu_Control_VideoManager" %>

<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Scripts/jquery-1.7.1.min.js"></script>
    <link href="/css/uploadfile.css" rel="stylesheet" />
    <link href="/css/smartpaginator.css" rel="stylesheet" />
    <script src="/Scripts/smartpaginator.js"></script>
    <style>
        .fixheight {
            height: 100px;
        }
    </style>
    <script type="text/javascript">
        function NodeLoadType(node) {
            Ext.net.DirectMethods.NodeLoadType(node.id, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                    console.log();
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }

        function getInfoType(node) {
            Ext.net.DirectMethods.GetInfoType(node.id, {
                success: function (result) {
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }

        function Insert() {
            var lstVal = [];
            $('input:checkbox:checked').each(function () {
                lstVal.push($(this).attr('value'));
            });
            Ext.net.DirectMethods.Insert(lstVal, {
                success: function (result) {
                    var danhmuc = Ext.getCmp('hdDanhmuc').getValue();
                    loadVideo(danhmuc);
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        function Delete() {
            var lstVal = [];
            $('input:checkbox:checked').each(function () {
                lstVal.push($(this).attr('value'));
            });
            Ext.net.DirectMethods.Delete(lstVal, {
                success: function (result) {
                    var danhmuc = Ext.getCmp('hdDanhmuc').getValue();
                    loadVideo(danhmuc);
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }

        function cbDanhmuc_Chang(el) {
            Ext.getCmp('hdDanhmuc').setValue(el.value);
            var danhmuc = Ext.getCmp('hdDanhmuc').getValue();
            loadVideo(danhmuc);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">

        <!----Goi ung dung ext------>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Hidden runat="server" ID="hdValue" />
        <ext:Viewport runat="server" Layout="border">
            <Items>
                <ext:TabPanel runat="server" Region="Center" ID="tabPanel" ActiveIndex="0">
                    <Items>
                        <ext:Panel runat="server" ID="Thuvienanh" Title="Thư viện video" Icon="Pictures" Border="false">
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdDanhmuc" />
                                        <ext:ComboBox runat="server" ID="cbDanhmuc" FieldLabel="Danh mục" LabelWidth="70" ClientIDMode="Static"
                                            DisplayField="TenDanhMuc" ValueField="DanhMucID" Width="250" EmptyText="--Chọn danh mục--">
                                            <Store>
                                                <ext:Store runat="server" ID="stDanhmuc">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="DanhMucID" />
                                                                <ext:RecordField Name="TenDanhMuc" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Select Handler="#{cbDanhmucUp}.setValue(#{cbDanhmuc}.getValue());cbDanhmuc_Chang(#{cbDanhmuc});" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:Button runat="server" ID="lbnInsert" Text="Chèn video" Margins="0 20">
                                            <Listeners>
                                                <Click Fn="Insert" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="lbnDelete" Text="Xóa video đã chọn">
                                            <Listeners>
                                                <Click Fn="Delete" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:Panel ID="Panel1" runat="server" Region="Center" Margins="0" Frame="true" Padding="10">
                                    <Content>
                                        <div class="message" id="lib">
                                            <asp:Repeater runat="server" ID="rptVideo">
                                                <ItemTemplate>
                                                    <div class="img_detail">
                                                        <input type="checkbox" id="cb<%#Container.ItemIndex %>" value="<%#Eval("VideoID") %>" data-src="/FileUpload/Images/<%#Eval("AnhMoTa") %>" />
                                                        <label for="cb<%#Container.ItemIndex %>">

                                                            <img class="thumb" src="/FileUpload/Images/<%#Eval("AnhMoTa") %>" /></label>
                                                        <p><a href="/FileUpload/Video/<%#Eval("FileUpload") %>" target="_blank"><%#Eval("TenVideo") %></a></p>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <div id="black"></div>
                                    </Content>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="Uploadanh" runat="server" Title="Upload video" Layout="fit" Icon="PictureAdd">
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:ComboBox runat="server" ID="cbDanhmucUp" FieldLabel="Danh mục " LabelWidth="50" ClientIDMode="Static"
                                            DisplayField="TenDanhMuc" ValueField="DanhMucID" Width="300" EmptyText="--Chọn danh mục tải ảnh lên--">
                                            <Store>
                                                <ext:Store runat="server" ID="stDanhmucUp">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="DanhMucID" />
                                                                <ext:RecordField Name="TenDanhMuc" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>

                                            <Listeners>
                                                <Change Handler="#{cbDanhmuc}.setValue(#{cbDanhmucUp}.getValue());cbDanhmuc_Chang(#{cbDanhmucUp});" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:Panel ID="Panel2" runat="server" Region="Center" Margins="0" Frame="true"
                                    Title="Chọn video tải lên" Icon="LayoutHeader" Padding="10">
                                    <Content>
                                        <ext:Hidden runat="server" ID="hdAnhMoTa" />
                                        <table style="color: rgb(41, 84, 149); font: 13px arial,tahoma,sans-serif;">
                                            <tr>
                                                <td>Tên video: </td>
                                                <td>
                                                    <ext:TextField runat="server" ID="txtTenVideo" Width="300" IndicatorCls="*" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Chọn ảnh: </td>
                                                <td>
                                                    <ext:Panel runat="server" ID="pnImage">
                                                        <Content>
                                                            <uc1:ImageOnly runat="server" ID="ImageOnly" />
                                                        </Content>
                                                    </ext:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>File video: </td>
                                                <td>
                                                    <asp:FileUpload ID="fVideo" runat="server" ClientIDMode="Static" onchange="handleFileSelect(event)" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Url: </td>
                                                <td>
                                                    <ext:TextField runat="server" ID="txtUrl" Width="300" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <div class="control-bottom">
                                                        <%--                                                        <ext:Button runat="server" ID="btnUpload" Text="Tải lên" Icon="ArrowUp">
                                                            <DirectEvents>
                                                                <Click OnEvent="btnUpload_Click" />
                                                            </DirectEvents>
                                                        </ext:Button>--%>
                                                        <a href="#" id="btnUpload" class="ajax-file-upload-green">Upload All</a>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ext:Panel>

                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="Danhmucanh" runat="server" Title="Danh mục video" Padding="10" Layout="BorderLayout" Icon="PictureEdit">
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button ID="btnUpdate" runat="server" Text="Thêm mới" Icon="Add">
                                            <DirectEvents>
                                                <Click OnEvent="btnUpdate_Click" />
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" runat="server" Text="Xóa" Icon="Delete">
                                            <DirectEvents>
                                                <Click OnEvent="btnDelete_Click">
                                                    <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>

                            <Items>
                                <ext:Panel Region="West" runat="server" Split="true" Width="200"
                                    Collapsible="true" Title="Chọn danh mục video" Icon="BookAddresses">
                                    <Items>
                                        <ext:TreePanel
                                            ID="TreePanel1"
                                            runat="server"
                                            AutoHeight="true"
                                            Border="false">
                                            <Root>
                                                <ext:AsyncTreeNode NodeID="0" Text="Danh mục gốc" />
                                            </Root>
                                            <Listeners>
                                                <BeforeLoad Fn="NodeLoadType" />
                                                <Click Fn="getInfoType" />
                                            </Listeners>
                                        </ext:TreePanel>
                                    </Items>
                                </ext:Panel>

                                <ext:Panel ID="Panel3" runat="server" Region="Center" Margins="0" Frame="true" Padding="10" Width="540">
                                    <Content>
                                        <ext:TextField runat="server" ID="txtTendanhmuc" Width="300" FieldLabel="Tên danh mục" />
                                        <ext:ComboBox runat="server" ID="cmbDanhmuccha" FieldLabel="Danh mục cha"
                                            DisplayField="TenDanhMuc" ValueField="DanhMucID" Width="300" EmptyText="--Chọn danh mục cha--">
                                            <Store>
                                                <ext:Store runat="server" ID="stDanhmuccha">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="DanhMucID" />
                                                                <ext:RecordField Name="TenDanhMuc" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>
                                        <ext:TextArea runat="server" ID="txtMota" Width="300" FieldLabel="Mô tả" />
                                    </Content>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
            </Items>
        </ext:Viewport>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            var danhmuc = $('#<%=hdDanhmuc.ClientID%>').val();
            loadVideo(danhmuc);
        });
        function loadVideo(danhmuc) {
            if (typeof danhmuc == 'undefined' && danhmuc != '' && danhmuc != '0') {
                var obj = {};
                obj.danhmuc = danhmuc;
                $.ajax({
                    type: "POST",
                    url: "/WebService/UpdateFile.asmx/LoadVideoByDanhMuc",
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
                                img.setAttribute("src", '/FileUpload/Videos/' + json[i][3]);
                                label.insertBefore(img, null);

                                div.insertBefore(label, null);
                                div.insertBefore(checkbox, label);

                                output.insertBefore(div, null);
                            }
                        }
                        var totalrow = $("#lib .img_detail").length;
                        $('#black').smartpaginator({ totalrecords: totalrow, recordsperpage: 10, lenght: 4, datacontainer: 'lib', dataelement: '.img_detail', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });

                    },
                    error: function (err) {
                        //$('.message').html(xhr.responseText);
                        return;
                    }
                });
            }
        }

        var data = new FormData();
        var video = [];

        function handleFileSelect(event) {
            var files = event.target.files; //FileList object
            if (files.length > 0) {
                for (var i = 0, f; f = files[i]; i++) {
                    if (!f.type.match('video.*')) {
                        alert('Chỉ được phép up video')
                        continue;
                    }
                    video.push(f.name);
                    data.append(f.name, f);
                }
            }
        }

        $("#btnUpload").click(function (evt) {
            var danhmuc = $('#hdDanhmuc').val();
            if (typeof danhmuc !== 'undefined' && danhmuc != '') {
                $.ajax({
                    url: "UpVideo.ashx",
                    type: "POST",
                    data: data,
                    contentType: false,
                    processData: false,
                    success: function (result) {
                        evt.preventDefault();

                        Ext.net.DirectMethods.SaveVideo(video, danhmuc, {
                            success: function (result) {
                                Ext.Msg.alert('Thông báo', 'Upload video thành công!!!');

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
                Ext.Msg.alert('Lỗi', 'Bạn chưa chọn danh mục video');
            }
        });
    </script>
</body>
</html>
