<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageManager1.aspx.cs" Inherits="NghiepVu_Control_ImageManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Scripts/jquery-1.7.1.min.js"></script>
    <link href="/css/uploadfile.css" rel="stylesheet" />
    <link href="/css/smartpaginator.css" rel="stylesheet" />
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

        var lstVal = [];
        function Insert() {
            //var lstVal = [];
            //$('input:checkbox:checked').each(function () {
            //    lstVal.push($(this).attr('value'));
            //});
            if (lstVal.length > 0) {
                Ext.net.DirectMethods.Insert(lstVal, {
                    success: function (result) {
                        loadImage(1, 10);
                    },
                    failure: function (errorMsg) {
                        Ext.Msg.alert('Failure', errorMsg);
                    }
                });
            }
            else {
                Ext.Msg.alert('Cảnh báo','Bạn chưa chọn ảnh nào.')
            }
        }
        function Delete() {
            //var lstVal = [];
            //$('input:checkbox:checked').each(function () {
            //    lstVal.push($(this).attr('value'));
            //});
            Ext.net.DirectMethods.Delete(lstVal, {
                success: function (result) {
                    loadImage(1,10);
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }

        function cbDanhmuc_Chang(el) {
            $('#hdDanhmuc').val(el.value);
            loadImage(1, 10);
            getPaging();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">

        <!----Goi ung dung ext------>
        <ext:resourcemanager id="ResourceManager1" runat="server" />
        <ext:hidden runat="server" id="hdValue" />
        <ext:viewport runat="server" layout="border">
            <Items>
                <ext:TabPanel runat="server" Region="Center" ID="tabPanel" ActiveIndex="0">
                    <Items>
                        <ext:Panel runat="server" ID="Thuvienanh" Title="Thư viện ảnh" Icon="Pictures" Layout="fit" Border="false">
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdDanhmuc" ClientIDMode="Static" />
                                        <ext:ComboBox runat="server" ID="cbDanhmuc" FieldLabel="Danh mục " LabelWidth="50" ClientIDMode="Static"
                                            DisplayField="TenDanhMuc" ValueField="DanhMucID" Width="300" EmptyText="--Chọn danh mục--">
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
                                        <ext:Button runat="server" ID="lbnInsert" Text="Chèn ảnh đã chọn" Margins="0 20">
                                            <Listeners>
                                                <Click Fn="Insert" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="lbnDelete" Text="Xóa ảnh đã chọn">
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
                                            <asp:Repeater runat="server" ID="rptImage">
                                                <ItemTemplate>
                                                    <div class="img_detail">
                                                        <input type="checkbox" id="cb<%#Container.ItemIndex %>" value="<%#Eval("ImageID") %>" data-src="/FileUpload/Images/<%#Eval("TenAnh") %>" />
                                                        <label for="cb<%#Container.ItemIndex %>">
                                                            <img class="thumb" src="/FileUpload/Images/<%#Eval("TenAnh") %>" /></label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <div id="black">
                                        </div>
                                    </Content>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="Uploadanh" runat="server" Title="Upload ảnh" Layout="fit" Icon="PictureAdd">
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

                                <ext:Panel ID="Panel2" runat="server" Margins="0" Frame="true" Padding="10">
                                    <Content>
                                        <ext:Hidden runat="server" ID="hdImgUpload" Text="" />
                                        <label class="ajax-file-upload">
                                            Chọn ảnh
                                            <asp:FileUpload ID="FileUpload1" multiple="true" runat="server" ClientIDMode="Static" onchange="handleFileSelect(event)" />
                                        </label>

                                        <div id="message" class="message"></div>
                                        <div style="clear: both"></div>
                                        <div class="control-bottom">
                                            <a href="#" id="btnUpload" class="ajax-file-upload-green">Upload All</a>
                                        </div>
                                    </Content>
                                </ext:Panel>

                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="Danhmucanh" runat="server" Title="Danh mục ảnh" Padding="10" Layout="BorderLayout" Icon="PictureEdit">
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
        </ext:viewport>
    </form>
    
    <script src="/Scripts/smartpaginator.js"></script>
    <%--<script type="text/javascript">
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
                url: "/WebService/UpdateFile.asmx/LoadImages",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    if (data.d != '') {
                        var totalrow = $("#lib .img_detail").length;
                        $('#black').smartpaginator({ totalrecords: totalrow, recordsperpage: 10, lenght: 4, datacontainer: 'lib', dataelement: '.img_detail', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });
                        $(document).on('click', '#black li a', pagingItem);
                    }
                },
                error: function (err) {
                    //alert('error r');
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
        
        function loadImage(index,count) {
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
                    var totalrow = $("#lib .img_detail").length;
                    $('#black').smartpaginator({ totalrecords: totalrow, recordsperpage: 10, lenght: 4, datacontainer: 'lib', dataelement: '.img_detail', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });

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

    </script>--%>
</body>
</html>
