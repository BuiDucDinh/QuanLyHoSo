<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoManager.aspx.cs" Inherits="Control_Video_VideoManager" %>

<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                    loadImage();
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
                    loadImage();
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }

        function cbDanhmuc_Chang(el) {
            $('#hdDanhmuc').val(el.value);
            loadImage();
        }

        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("btnUpload").click();
            }
        }
        var GetImage = function (value) {
            return "<img src='/FileUpload/Images/" + value + "' style=\'width:50px; height:auto\'/>";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:ObjectDataSource ID="odsVideo" runat="server" OnSelected="odsVideo_Selected" SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="Start" Type="Int32" />
                <asp:Parameter Name="Limit" Type="Int32" />
                <asp:Parameter Name="WhereString" Type="String" />
                <asp:Parameter Name="SortString" Type="String" />
                <asp:Parameter Direction="Output" Name="Count" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <!----Goi ung dung ext------>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Viewport runat="server" Layout="border">
            <Items>

                <ext:TabPanel runat="server" Region="Center" ID="tabPanel">
                    <Items>
                        <ext:Panel runat="server" ID="Thuvienvideo" Title="Thư viện video" Icon="Film" Layout="fit" Border="false">
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdimg" />
                                        <ext:Button runat="server" ID="lbnInsert" Text="Chọn video" Margins="0 20">
                                            <DirectEvents>
                                                <Click OnEvent="lbnInsert_Click">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="lbnDelete" Text="Xóa video đã chọn">
                                            <DirectEvents>
                                                <Click OnEvent="lbnDelete_Click">
                                                    <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa những ảnh đã chọn?" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Content>
                                <ext:Hidden runat="server" ID="hdDanhmuc" />
                                <ext:GridPanel ID="gridVideo" runat="server" Title="" Margins="0" Header="false"
                                    Icon="UserSuit" AutoHeight="true" AutoWidth="true" AutoExpandColumn="TenVideo">
                                    <Store>
                                        <ext:Store ID="stVideo" runat="server" RemoteSort="true" DataSourceID="odsVideo" OnRefreshData="stVideo_RefreshData">
                                            <AutoLoadParams>
                                                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                                <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                                            </AutoLoadParams>
                                            <Proxy>
                                                <ext:PageProxy />
                                            </Proxy>
                                            <Reader>
                                                <ext:JsonReader IDProperty="VideoID">
                                                    <Fields>
                                                        <ext:RecordField Name="VideoID" />
                                                        <ext:RecordField Name="TenVideo" />
                                                        <ext:RecordField Name="AnhMoTa" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                            <SortInfo Field="TenVideo" Direction="ASC" />
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="TenVideo" DataIndex="TenVideo" Header="Tên video" Width="150">
                                            </ext:Column>
                                            <ext:Column ColumnID="AnhMoTa" Header="Video" DataIndex="AnhMoTa" Width="300">
                                                <Renderer Fn="GetImage" />
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel runat="server" />
                                    </SelectionModel>
                                    <DirectEvents>
                                        <Command OnEvent="DelVideo" Buffer="250">
                                            <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa video này?" />
                                            <EventMask ShowMask="true" />
                                            <ExtraParams>
                                                <ext:Parameter Name="command" Value="command" Mode="Raw" />
                                                <ext:Parameter Name="rowIndex" Value="record.data.VideoID" Mode="Raw" />
                                            </ExtraParams>
                                        </Command>
                                    </DirectEvents>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="30" DisplayInfo="true"
                                            DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" />
                                    </BottomBar>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Content>
                        </ext:Panel>

                        <ext:Panel ID="Uploadvideo" runat="server" Title="Upload video" Layout="fit" Icon="FilmAdd">
                            <Content>
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
                                                    <td>File đính kèm: </td>
                                                    <td>
                                                        <ext:FileUploadField ID="fFile" runat="server" Width="300" Icon="FilmAdd">
                                                          <%--  <DirectEvents>
                                                                <FileSelected OnEvent="FileUploadField_FileSelected" IsUpload="true" />
                                                            </DirectEvents>--%>
                                                        </ext:FileUploadField>
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
                                                        <ext:Button runat="server" ID="btnFinish" Text="Hoàn thành">
                                                            <DirectEvents>
                                                                <Click OnEvent="btnFinish_Click" />
                                                            </DirectEvents>
                                                        </ext:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                    </Content>
                                </ext:Panel>
                            </Content>
                        </ext:Panel>
                        <ext:Panel ID="Danhmucvideo" runat="server" Title="Danh mục video" Padding="10" Layout="" Icon="FilmEdit">
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
                                    Collapsible="true" Title="Chọn danh mục ảnh" Icon="BookAddresses">
                                    <Content>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </Content>
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
            loadImage();
        });
        function loadImage() {
            var danhmuc = $('#hdDanhmuc').val();
            if (typeof danhmuc == 'undefined') {
                danhmuc = '';
            }
            var obj = {};
            obj.danhmuc = danhmuc;
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
                    var totalrow = $("#lib .img_detail").length;
                    $('#black').smartpaginator({ totalrecords: totalrow, recordsperpage: 10, lenght: 4, datacontainer: 'lib', dataelement: '.img_detail', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });

                },
                error: function (err) {
                    alert('error r');
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
                    img.push(f.name);
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
                    success: function (result) { },
                    error: function (err) {
                        alert('error r');
                        return;
                    }
                });
                evt.preventDefault();

                Ext.net.DirectMethods.SaveImage(img, danhmuc, {
                    success: function (result) {
                        Ext.Msg.alert('Thông báo', 'Upload ảnh thành công!!!');
                    },
                    failure: function (errorMsg) {
                        Ext.Msg.alert('Failure', errorMsg);
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

    </script>
</body>
</html>
